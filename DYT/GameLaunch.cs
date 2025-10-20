using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unity.SharpZipLib.Zip;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using XLua;
using ZipFile = Unity.SharpZipLib.Zip.ZipFile;

namespace DYT
{
    public class GameLaunch : MonoBehaviour
    {
        // 说明：
        // - 把需要“Lua 调 C#”的类型放进 LuaCallCSharp 列表
        // - 把需要“C# 调 Lua”的委托/接口签名放进 CSharpCallLua 列表
        // - 修改后执行菜单 XLua/Generate Code
        
        [LuaCallCSharp]
        public static List<Type> LuaCallCSharp = new List<Type>
        {
            // 你在 Lua 里直接访问到的类型
            typeof(GameLaunch),               // Lua: CS.DYT.GameLaunch.KleiloadText(...)
            typeof(TheSimBridge),             // Lua: TheSim:Method(...)
            typeof(EntityBridge),   // 新增：允许 Lua 调用 entity:SetCanSleep(...)
            typeof(TheSystemServiceBridge),   // Lua: TheSystemService:SetStalling(...)
            typeof(TheInputProxyBridge),      // Lua: TheInputProxy:...

            // 委托类型：Lua 将直接调用该 C# 委托（如 walltime）
            typeof(Func<double>),
        };

        [CSharpCallLua]
        public static List<Type> CSharpCallLua = new List<Type>
        {
            // 仅当你从 Lua 传函数进 C# 并由 C# 回调时才需要。
            // 示例：如果 TheSimBridge 有如下签名：
            // public delegate void PersistentStringCallback(bool success, string data);
            // public delegate void SimpleCallback(bool success);
            // 则把这些委托类型加入列表：
            typeof(TheSimBridge.PersistentStringCallback),
            typeof(TheSimBridge.SimpleCallback),

            // 如果你用系统委托来收 Lua 回调（例如 Action<bool,string>），也需要列出来：
            // typeof(System.Action<bool, string>),
            // typeof(System.Action<bool>),
        };
        
        [Header("UI 可选：拖一个 Slider 进来显示进度")]
        [SerializeField] Slider slider;
        
        public TheSimBridge theSimBridge;

        public string RES_ZIP = "dont_starve_copy";          // StreamingAssets 里的资源包
        static string FlagFile => $"{Application.persistentDataPath}/.unpacked";

        /* 公开事件：解压完成 / 启动完成 */
        public static event Action onUnpackDone;   // 可在这里切 UI
        public static event Action onLuaStartDone; // Lua 已 ready

        /* 单例供外部取 LuaEnv */
        public static LuaEnv LUA_ENV;

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
        public static byte[] Loader(ref string name)
        {
            string packagePath = LUA_ENV.Global.Get<LuaTable>("package").Get<string>("path");;
            string[] postPathArray = packagePath.Replace("?", name).Split(';');
            foreach (string postPath in postPathArray)
            {
                string filePath = GetFilePath(postPath);
                if (filePath != null) return File.ReadAllBytes(filePath);
            }
            
            Debug.LogError($"GameLaunch.cs -> Loader()\nParam: {name}");
            return null;
        }
        
        // kleifileexists 的具体实现
        private static bool KleiFileExistsImpl(string kleiPath)
        {
            if (string.IsNullOrEmpty(kleiPath))
                return false;

            // 规范化路径分隔符
            string norm = kleiPath.Replace('\\', '/');

            // 1) 使用你已有的解析方法（应当把 Klei 的相对路径映射到磁盘实际路径）
            string resolved = GetFilePath(norm);
            if (!string.IsNullOrEmpty(resolved))
                return true;

            return false;
        }
        
        public static string KleiloadText(string name)
        {
            string filePath = GetFilePath(name);
            if (filePath != null)
            {
                byte[] bytes = File.ReadAllBytes(filePath);
                
                // Most DS scripts are UTF-8
                return Encoding.UTF8.GetString(bytes);
            }
            
            Debug.LogError($"GameLaunch.cs -> KleiloadText()\nParam: {name}");
            return null;
        }
        
        Func<double> walltime = () => Time.realtimeSinceStartupAsDouble;
        
        /* 2. 启动 xLua 并设置路径 */
        private void StartLua()
        {
            LUA_ENV = new LuaEnv();

            // 让 Lua 从 persistentDataPath 加载脚本
            LUA_ENV.AddLoader(Loader);

            // Lua 5.1 兼容：提供 loadstring / unpack 等缺失全局
            // 注意：必须在 require 任何脚本之前注入，避免 strict.lua 报未声明变量
            LUA_ENV.DoString(@"
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
            LUA_ENV.DoString(@"
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
            
            LUA_ENV.DoString(
                $"package.cpath = '{Application.persistentDataPath}/dont_starve_copy/bin/lualib/?.dll'"
            );
            LUA_ENV.DoString("package.path = 'scripts/?.lua;scriptlibs/?.lua'");

            // 注入 Lua 5.1 兼容：loaders -> searchers；并提供 kleiloadlua 的空实现（让搜索链继续）
            LUA_ENV.DoString(@"
                local pkg = package
                pkg.loaders = pkg.loaders or pkg.searchers
            ", "compat_preload");

            // NEW: Provide global kleiloadlua using C# KleiloadText helper
            LUA_ENV.DoString(@"
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
            LUA_ENV.Global.Set("TheSim", theSimBridge);
            LUA_ENV.Global.Set("TheInputProxy", new TheInputProxyBridge());
            LUA_ENV.Global.Set("TheSystemService", new TheSystemServiceBridge());
            LUA_ENV.Global.Set("TheGameService", new TheGameServiceBridge());

            // 注入 FRAMES（与 DST 兼容：1/30 秒每帧）
            LUA_ENV.DoString(@"
                if rawget(_G, 'FRAMES') == nil then
                    FRAMES = TheSim:GetTickTime()
                end
            ", "compat_frames");

            // 其他桥接/常量
            LUA_ENV.Global.Set("CONFIGURATION", "PRODUCTION");
            LUA_ENV.Global.Set("PLATFORM", "WIN32_STEAM");
            LUA_ENV.Global.Set("APP_REGION", "NONE");
            LUA_ENV.Global.Set("RUN_GLOBAL_INIT", true);
            
            LUA_ENV.Global.Set("walltime", walltime);
            LUA_ENV.Global.Set("kleifileexists", new Func<string, bool>(KleiFileExistsImpl));

            // 启动主脚本
            LUA_ENV.DoString("require 'main'");

            onLuaStartDone?.Invoke();
            Debug.Log(">>> Lua 虚拟机启动完成");
        }
    }
}
