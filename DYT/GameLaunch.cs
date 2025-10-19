using System;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Text;
using Unity.SharpZipLib.Utils;
using Unity.SharpZipLib.Zip;
using UnityEngine;
using UnityEngine.Networking;
using XLua;
using ZipFile = Unity.SharpZipLib.Zip.ZipFile;

namespace DYT
{
    public class GameLaunch : MonoBehaviour
    {
        [Header("UI 可选：拖一个 Slider 进来显示进度")]
        [SerializeField] UnityEngine.UI.Slider slider;

        public string RES_ZIP = "dont_starve_copy";          // StreamingAssets 里的资源包
        static string FlagFile => $"{Application.persistentDataPath}/.unpacked";

        /* 公开事件：解压完成 / 启动完成 */
        public static event Action onUnpackDone;   // 可在这里切 UI
        public static event Action onLuaStartDone; // Lua 已 ready

        /* 单例供外部取 LuaEnv */
        public static LuaEnv luaEnv { get; private set; }

        private IEnumerator Start()
        {
            string flag = Path.Combine(Application.persistentDataPath, ".unpacked");
            if (!File.Exists(flag))
            {
                string tempZip = Path.Combine(Application.persistentDataPath, RES_ZIP + ".zip");

                // 1. 把 StreamingAssets 里的大文件 **流式拷贝** 到可写目录
                yield return CopyStreamingAssetsToTemp();

                // 2. **分段解压** 临时文件
                yield return UnzipWithFileStream(tempZip, Application.persistentDataPath);

                // 3. 清理临时 zip
                File.Delete(tempZip);
                File.WriteAllText(flag, "1");

                Debug.Log(">>> 大 ZIP 本地解压完成");
            }

            StartLua();
        }
        
        /* 1. 流式拷贝（>2 GB 也安全） */
        IEnumerator CopyStreamingAssetsToTemp()
        {
            // Android 真机：jar:file:/// 路径，必须用 UnityWebRequest 读取
            using (var uwr = UnityWebRequest.Get(Path.Combine(Application.streamingAssetsPath, RES_ZIP + ".zip")))
            {
                // **关键**：不下载到内存，直接写文件
                uwr.downloadHandler = new DownloadHandlerFile(Path.Combine(Application.persistentDataPath, RES_ZIP + ".zip"), false);
                uwr.SendWebRequest();

                while (!uwr.isDone)
                {
                    if (slider) slider.value = uwr.downloadProgress;
                    yield return null;
                }
                if (uwr.result != UnityWebRequest.Result.Success)
                    throw new Exception("拷贝失败: " + uwr.error);
            }
            Debug.Log(">>> 大文件已拷贝到临时目录");
        }

        /* 核心：FileStream + SharpZipLib 解压 */
        IEnumerator UnzipWithFileStream(string zipPath, string targetDir)
        {
            using (var fs   = new FileStream(zipPath, FileMode.Open, FileAccess.Read))
            using (var zip  = new ZipFile(fs))        // SharpZipLib 入口
            {
                long totalBytes = 0;
                long doneBytes  = 0;

                // 先算总大小
                foreach (ZipEntry e in zip)
                    if (!e.IsDirectory) totalBytes += e.Size;

                foreach (ZipEntry entry in zip)
                {
                    if (entry.IsDirectory) continue;

                    string outPath = Path.Combine(targetDir, entry.Name);
                    Directory.CreateDirectory(Path.GetDirectoryName(outPath));

                    using (var zs = zip.GetInputStream(entry))   // 文件流读
                    using (var ds = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[100 * 1024 * 1024]; // 100 MB 缓冲区
                        int read;
                        while ((read = zs.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ds.Write(buffer, 0, read);
                            doneBytes += read;

                            float p = (float)doneBytes / totalBytes;
                            if (slider) slider.value = p;
                            yield return null; // 每写一块就让出
                        }
                    }
                }
            }
            Debug.Log(">>> FileStream+SharpZipLib 解压完成 → " + targetDir);
        }
        
        

        public static string GetFilePath(string postPath)
        {
            string prePath = $"{Application.persistentDataPath}/dont_starve_copy/data";
            
            string filePath = $"{prePath}/DLC0003/{postPath}";
            if (File.Exists(filePath)) return filePath;
            
            filePath = $"{prePath}/DLC0002/{postPath}";
            if (File.Exists(filePath)) return filePath;
            
            filePath = $"{prePath}/DLC0001/{postPath}";
            if (File.Exists(filePath)) return filePath;
            
            filePath = $"{prePath}/{postPath}";
            if (File.Exists(filePath)) return filePath;

            return null;
        }
        private static byte[] Loader(ref string name)
        {
            string packagePath = luaEnv.Global.Get<LuaTable>("package").Get<string>("path");;
            string[] postPathArray = packagePath.Replace("?", name).Split(';');
            foreach (string postPath in postPathArray)
            {
                string filePath = GetFilePath(postPath);
                if (filePath != null) return File.ReadAllBytes(filePath);
            }
            return null;
        }

        // NEW: Expose a helper to Lua that reuses our Loader to read a module as text
        [LuaCallCSharp]
        public static string KleiloadText(string name)
        {
            try
            {
                string tmp = name; // Loader requires ref string
                var bytes = Loader(ref tmp);
                if (bytes == null || bytes.Length == 0) return null;
                // Most DS scripts are UTF-8
                return Encoding.UTF8.GetString(bytes);
            }
            catch (Exception e)
            {
                Debug.LogWarning($"[KleiloadText] Failed to load '{name}': {e}");
                return null;
            }
        }

        /* 2. 启动 xLua 并设置路径 */
        void StartLua()
        {
            luaEnv = new LuaEnv();

            // 让 Lua 从 persistentDataPath 加载脚本
            luaEnv.AddLoader(Loader);

            // Lua 5.1 兼容：提供 loadstring / unpack 等缺失全局
            // 注意：必须在 require 任何脚本之前注入，避免 strict.lua 报未声明变量
            luaEnv.DoString(@"
                local g = _G
                -- Lua 5.1: loadstring → Lua 5.2/5.3 的 load
                if g.loadstring == nil then
                    g.loadstring = function(src, chunkname)
                        return load(src, chunkname)
                    end
                end
                -- Lua 5.1: unpack → Lua 5.2/5.3 的 table.unpack
                if g.unpack == nil then
                    g.unpack = table.unpack
                end
            ", "compat_lua51");

            // Lua 5.1: module / package.seeall 兼容垫片（legacy: module('xxx', package.seeall)）
            // 注意：使用 rawset 避开 strict.lua 的 __newindex
            luaEnv.DoString(@"
                local g = _G
                if rawget(g, 'module') == nil then
                    local function _seeall(m)
                        local mt = getmetatable(m)
                        if not mt then
                            mt = {}
                            setmetatable(m, mt)
                        end
                        mt.__index = g
                        return m
                    end

                    if rawget(package, 'seeall') == nil then
                        rawset(package, 'seeall', _seeall)
                    end

                    local function _module(name, ...)
                        assert(type(name) == 'string', 'bad argument #1 to module (string expected)')
                        local m = package.loaded[name]
                        if type(m) ~= 'table' then
                            m = {}
                            package.loaded[name] = m
                        end
                        -- 关键：在 strict 开启时，必须用 rawset 才能写入全局而不触发 __newindex
                        rawset(g, name, m)
                        for i = 1, select('#', ...) do
                            local arg = select(i, ...)
                            if arg == package.seeall then _seeall(m) end
                        end
                        return m
                    end
                    -- 同样用 rawset 安全注册 module 全局
                    rawset(g, 'module', _module)
                end
            ", "compat_module51");
            
            luaEnv.DoString(
                $"package.cpath = '{Application.persistentDataPath}/dont_starve_copy/bin/lualib/?.dll'"
            );
            luaEnv.DoString("package.path = 'scripts/?.lua;scriptlibs/?.lua'");

            // 注入 Lua 5.1 兼容：loaders -> searchers；并提供 kleiloadlua 的空实现（让搜索链继续）
            luaEnv.DoString(@"
                local pkg = package
                pkg.loaders = pkg.loaders or pkg.searchers
            ", "compat_preload");

            // NEW: Provide global kleiloadlua using C# KleiloadText helper
            luaEnv.DoString(@"
                if rawget(_G, 'kleiloadlua') == nil then
                    function kleiloadlua(name)
                        local src = CS.DYT.GameLaunch.KleiloadText(name)
                        if not src or src == '' then
                            return '\n\tno file ' .. tostring(name) .. ' in package.path'
                        end
                        local chunk, err = load(src, name)
                        if not chunk then
                            return err or ('\n\tfailed to compile ' .. tostring(name))
                        end
                        return chunk
                    end
                end
            ", "compat_kleiloadlua");

            // 注入 C# 桥接类（实例）——支持 Lua 冒号语法 TheSim:Func(...)
            luaEnv.Global.Set("TheSim", new TheSimBridge());

            // 注入 FRAMES（与 DST 兼容：1/30 秒每帧）
            luaEnv.DoString(@"
                if rawget(_G, 'FRAMES') == nil then
                    FRAMES = TheSim:GetTickTime()
                end
            ", "compat_frames");

            // 其他桥接/常量
            luaEnv.Global.Set("DATA", typeof(DataPath));
            luaEnv.Global.Set("CONFIGURATION", "PRODUCTION");
            luaEnv.Global.Set("PLATFORM", "WIN32_STEAM");

            // 启动主脚本
            luaEnv.DoString("require 'main'");

            onLuaStartDone?.Invoke();
            Debug.Log(">>> Lua 虚拟机启动完成");
        }

        void OnDestroy()
        {
            luaEnv?.Dispose();
            luaEnv = null;
        }
    }

    /* 供 Lua 调用的示例桥 */
    public static class DataPath
    {
        public static string Root => Application.persistentDataPath;
    }
    
    // Delegates for Lua callbacks (xLua will map Lua functions to these)
    [CSharpCallLua] public delegate void PersistentStringCallback(bool success, string data);
    [CSharpCallLua] public delegate void SimpleCallback(bool success);

    [LuaCallCSharp]
    public class TheSimBridge
    {
        private readonly string _saveRoot;
        
        private readonly GameObject _audioGo;
        private readonly AudioReverbFilter _reverb;

        public TheSimBridge()
        {
            // 独立的音频节点，常驻场景
            _audioGo = new GameObject("TheSimAudio");
            UnityEngine.Object.DontDestroyOnLoad(_audioGo);

            // 使用全局 ReverbFilter 控制环境混响
            _audioGo.AddComponent<AudioSource>();
            _reverb = _audioGo.AddComponent<AudioReverbFilter>();
            _reverb.enabled = false;
            _reverb.reverbPreset = AudioReverbPreset.Off;
        }
        
        // TheSim:LuaPrint → used by debugprint.lua/print(...)
        public void LuaPrint(string message)
        {
            // Unity 控制台标准输出
            Debug.Log(message ?? string.Empty);
        }
        
        // Settings: simple persistence via PlayerPrefs
        public void SetSetting(string section, string key, string value)
        {
            PlayerPrefs.SetString($"{section}-{key}", value ?? "");
            PlayerPrefs.Save();
        }

        public string GetSetting(string section, string key)
        {
            string k = $"{section}-{key}";
            return PlayerPrefs.HasKey(k) ? PlayerPrefs.GetString(k) : null;
        }

        public void DeleteSetting(string section, string key)
        {
            string k = $"{section}-{key}";
            if (!PlayerPrefs.HasKey(k)) return;
            
            PlayerPrefs.DeleteKey(k);
            PlayerPrefs.Save();
        }

        public void SetAgreementsSetting(string section, string key, string value)
        {
            PlayerPrefs.SetString($"agreements:{section}:{key}", value ?? "");
            PlayerPrefs.Save();
        }

        public string GetAgreementsSetting(string section, string key)
        {
            string k = $"agreements:{section}:{key}";
            return PlayerPrefs.HasKey(k) ? PlayerPrefs.GetString(k) : null;
        }

        // Lua: TheSim:GetPersistentString(name, function(success, data) ... end, allow_po)
        public void GetPersistentString(string name, PersistentStringCallback callback, bool _allowPo)
        {
            string path = Path.Combine(Application.persistentDataPath, name);
            try
            {
                if (File.Exists(path))
                {
                    string data = File.ReadAllText(path);
                    callback?.Invoke(true, data);
                }
                else
                {
                    callback?.Invoke(false, "");
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"[TheSimBridge] GetPersistentString('{name}') error: {e}");
                callback?.Invoke(false, "");
            }
        }

        // Lua: TheSim:SetPersistentString(name, data, encode, function(success) ... end)
        // Note: encode is ignored here (data is already encoded/decoded by Lua if needed).
        public void SetPersistentString(string name, string data, bool _encode, SimpleCallback callback)
        {
            string path = Path.Combine(Application.persistentDataPath, name);
            try
            {
                File.WriteAllText(path, data ?? "");
                callback?.Invoke(true);
            }
            catch (Exception e)
            {
                Debug.LogError($"[TheSimBridge] SetPersistentString('{name}') error: {e}");
                callback?.Invoke(false);
            }
        }

        // Return multiple values to Lua: object[] becomes multiple return values in xLua
        public object[] UpdateDeviceCaps(int a, int b)
        {
            // Minimal no-op implementation: just echo back what came in
            return new object[] { a, b };
        }

        // 与 DST 语义对齐：每逻辑帧时长 = 1/30 秒
        // Lua 侧经常用 FRAMES = TheSim:GetTickTime()
        public float GetTickTime()
        {
            return 1f / 30f;
        }

        // 可选：补充常见时间相关 API，避免下一个脚本再缺
        public double GetTime()            => Time.timeAsDouble;                 // 受 timeScale 影响
        public double GetRealTime()        => Time.realtimeSinceStartupAsDouble; // 不受 timeScale 影响
        public float  GetTimeScale()       => Time.timeScale;
        public void   SetTimeScale(float s)=> Time.timeScale = Mathf.Clamp(s, 0f, 10f);

        // 兼容脚本：获取文件修改时间（秒，UTC）
        public long GetFileModificationTime(string relativePath)
        {
            try
            {
                string p = GameLaunch.GetFilePath(relativePath) ?? relativePath;
                if (!File.Exists(p)) return 0;
                DateTime t = File.GetLastWriteTimeUtc(p);
                return new DateTimeOffset(t).ToUnixTimeSeconds();
            }
            catch (Exception e)
            {
                Debug.LogWarning($"[TheSim] GetFileModificationTime('{relativePath}') 失败：{e.Message}");
                return 0;
            }
        }

        // Lua: TheSim:LoadTexture("relative/path.png")
        public string LoadTexture(string relPath)
        {
            // 这里只是返回路径，真正解码可再包一层
            return Path.Combine(DataPath.Root, relPath);
        }

        // Lua: TheSim:SetReverbPreset("default")
        // 语义：根据预设名切换环境混响；"off"/nil 关闭混响；未知值降级为 Generic
        public void SetReverbPreset(string presetName)
        {
            if (string.IsNullOrEmpty(presetName) || presetName.Equals("off", StringComparison.OrdinalIgnoreCase) ||
                presetName.Equals("none", StringComparison.OrdinalIgnoreCase))
            {
                _reverb.enabled = false;
                _reverb.reverbPreset = AudioReverbPreset.Off;
                Debug.Log("[TheSim] Reverb OFF");
                return;
            }

            AudioReverbPreset preset = MapPresetName(presetName);
            _reverb.reverbPreset = preset;
            _reverb.enabled = preset != AudioReverbPreset.Off;
            Debug.Log($"[TheSim] Reverb set to {preset} (input='{presetName}')");
        }

        private static AudioReverbPreset MapPresetName(string raw)
        {
            // 依据 Don't Starve 的常见环境名进行直观映射；大小写不敏感
            string key = raw.Trim().ToLowerInvariant();
            switch (key)
            {
                case "default":
                case "generic":
                case "normal":
                    return AudioReverbPreset.Generic;

                case "cave":
                case "ruins":
                case "stone":
                case "stone_room":
                    return AudioReverbPreset.Cave;

                case "forest":
                case "woods":
                    return AudioReverbPreset.Forest;

                case "hallway":
                case "corridor":
                case "stonecorridor":
                    return AudioReverbPreset.Hallway;

                case "bathroom":
                case "bath_room":
                    return AudioReverbPreset.Bathroom;

                case "room":
                case "livingroom":
                    return AudioReverbPreset.Livingroom;

                case "arena":
                case "auditorium":
                case "concerthall":
                case "concert_hall":
                    return AudioReverbPreset.Concerthall;

                case "alley":
                    return AudioReverbPreset.Alley;

                case "city":
                    return AudioReverbPreset.City;

                case "mountains":
                case "mountain":
                    return AudioReverbPreset.Mountains;

                case "underwater":
                    return AudioReverbPreset.Underwater;

                case "hangar":
                    return AudioReverbPreset.Hangar;

                case "sewer":
                case "sewerpipe":
                    return AudioReverbPreset.SewerPipe;

                case "plain":
                case "plains":
                    return AudioReverbPreset.Plain;

                case "parkinglot":
                case "parking_lot":
                    return AudioReverbPreset.ParkingLot;

                case "off":
                case "none":
                    return AudioReverbPreset.Off;

                default:
                    Debug.LogWarning($"[TheSim] Unknown reverb preset '{raw}', fallback to Generic");
                    return AudioReverbPreset.Generic;
            }
        }
    }
}