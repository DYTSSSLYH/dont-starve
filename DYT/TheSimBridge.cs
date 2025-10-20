using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using XLua;

namespace DYT
{
    public class TheSimBridge : MonoBehaviour
    {
        // 简短说明：按文件读入并用 LuaEnv.DoString 执行，chunk 名用真实路径/文件名，避免 require 的缓存与路径映射问题。
        public void LoadPrefabs(string[] names)
        {
            foreach (string n in names)
            {
                string filePath = GameLaunch.GetFilePath($"scripts/prefabs/{n}.lua");

                GameLaunch.LUA_ENV.DoString(File.ReadAllText(filePath), n);
            }
        }
        
        // ========= 新增：资产路径解析映射 =========

        // Klei 脚本在 RegisterPrefabs 时调用 TheSim:OnAssetPathResolve(virtual, resolved)
        // 我们记录这张映射表，后续需要时可查询
        private readonly Dictionary<string, string> _assetPathMap =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // Lua: TheSim:OnAssetPathResolve(originalPath, resolvedPath)
        public void OnAssetPathResolve(string originalPath, string resolvedPath)
        {
            if (string.IsNullOrEmpty(originalPath) || string.IsNullOrEmpty(resolvedPath))
                return;

            // 规范化分隔符
            var key = originalPath.Replace('\\', '/');
            var val = resolvedPath.Replace('\\', '/');

            _assetPathMap[key] = val;
            // 可选日志：Debug.Log($"[TheSimBridge] AssetPathResolve: {key} -> {val}");
        }

        // ========= 新增：Prefab 注册/加载占位 =========

        // 记录注册过/加载中的 prefab 名称，避免 NRE
        private readonly HashSet<string> _registeredPrefabs =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly HashSet<string> _loadedPrefabs =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Lua: TheSim:RegisterPrefab(name, assets, deps)
        // 这里不做实际加载（Lua 已管理 Prefabs），仅登记名称，防止方法缺失
        public void RegisterPrefab(string name, LuaTable assets, LuaTable deps)
        {
            if (string.IsNullOrEmpty(name)) return;
            _registeredPrefabs.Add(name);
        }
        
        public GameObject FindFirstEntityWithTag(string tag)
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);
            return objs.Length > 0 ? objs[0] : null;
        }

        // CreateEntity 改为返回 EntityScriptBridge，供 Lua CreateEntity() 使用
        public EntityBridge CreateEntity()
        {
            return new EntityBridge();
        }


        // 可选：关联 Unity 的 AudioMixer 参数（比如 "volume_master" 等）
        // 你可以在 Inspector 里把 channel->exposed parameter 对应起来
        [Serializable]
        public class ChannelMapping
        {
            public string channel;          // Lua侧的通道名
            public string mixerParam;       // AudioMixer 暴露的参数名（比如 "vol_master"）
        }

        [Serializable]
        public class DspParamMapping
        {
            [Tooltip("Lua 侧类别（category）")]
            public string category;

            [Tooltip("低通滤波的暴露参数名（单位：Hz；中性值一般为 22000）")]
            public string lowPassParam;

            [Tooltip("高通滤波的暴露参数名（单位：Hz；中性值一般为 10 或 20）")]
            public string highPassParam;
        }

        [Header("Optional: Hook Unity AudioMixer")]
        public AudioMixer audioMixer;
        public AudioListener audioListener;

        // 通道名 -> AudioMixer音量参数 的映射
        private readonly Dictionary<string, string> _channelMap = new Dictionary<string, string>();

        [Tooltip("类别 -> AudioMixer滤波参数 的映射")]
        private readonly Dictionary<string, DspParamMapping> _dspParamMappings = new Dictionary<string, DspParamMapping>();
        
        // 以纯内存方式保存音量，未接入 AudioMixer 时也能工作
        private readonly Dictionary<string, float> _volumes = new Dictionary<string, float>(StringComparer.Ordinal);

        // 音效：简单的全局 Reverb（可被 SetReverbPreset 控制）
        public AudioReverbFilter reverb;
        
        // Delegates for Lua callbacks (xLua will map Lua functions to these)
        public delegate void PersistentStringCallback(bool success, string data);
        public delegate void SimpleCallback(bool success);
        
        private readonly string _saveRoot;
        
        private readonly GameObject _audioGo;

        // =========================
        // 生命周期与初始化
        // =========================

        private void Awake()
        {
            // 使用全局 ReverbFilter 控制环境混响
            reverb.enabled = false;
            reverb.reverbPreset = AudioReverbPreset.Off;

            // 示例映射（如需改为 Inspector 配置，可删除这里并改为通过序列化列表构建）
            _channelMap.Add("set_sfx/HUD", "set_sfx/HUD");
            _channelMap.Add("set_sfx/sfx", "set_sfx/sfx");
            _channelMap.Add("set_music/soundtrack", "set_music/soundtrack");
            _channelMap.Add("set_ambience/cloud", "set_ambience/cloud");
            _channelMap.Add("set_sfx/movement", "set_sfx/movement");
            _channelMap.Add("set_sfx/shadow", "set_sfx/shadow");
            _channelMap.Add("set_sfx/creature", "set_sfx/creature");
            _channelMap.Add("set_sfx/twister_attack", "set_sfx/twister_attack");
            _channelMap.Add("set_sfx/voice", "set_sfx/voice");
            _channelMap.Add("set_ambience/ambience", "set_ambience/ambience");
            _channelMap.Add("set_sfx/player", "set_sfx/player");
            _channelMap.Add("set_sfx/everything_else_muted", "set_sfx/everything_else_muted");
            
            // _dspParamMappings.Add();
        }
        
        // scripts/modindex.lua 期望 TheSim:GetModDirectoryNames() 返回 Lua table（1..n）
        public LuaTable GetModDirectoryNames()
        {
            string modsPath = Path.Combine(Application.persistentDataPath, "dont_starve_copy", "mods");
            
            string[] dirs = Directory.GetDirectories(modsPath);
            List<string> names = new List<string>(dirs.Length);
            foreach (string d in dirs)
            {
                try
                {
                    string fileName = Path.GetFileName(d);
                    if (string.IsNullOrEmpty(fileName)) continue;
                    if (fileName.StartsWith(".")) continue; // 忽略隐藏目录
                    names.Add(fileName);
                }
                catch
                {
                    // 忽略单个目录的异常，继续扫描
                }
            }

            // 将 C# 列表拷贝为 1-based Lua 表
            LuaTable tbl = GameLaunch.LUA_ENV.NewTable();
            for (int i = 0; i < names.Count; i++)
            {
                tbl.Set(i + 1, names[i]);
            }
            return tbl;
        }

        // =========================
        // 音量 / 滤波 / 混响
        // =========================

        // 0..1 线性音量 → dB（AudioMixer 使用 dB）
        private static float LinearToDb(float v)
        {
            const float minDb = -80f;
            v = Mathf.Clamp01(v);
            if (v <= 0.0001f) return minDb;
            return Mathf.Lerp(minDb, 0f, Mathf.Log10(v) + 1f); // 简单映射，可按需调整
        }

        // Lua: TheSim:SetSoundVolume(channel, volume)
        public void SetSoundVolume(string channel, float volume)
        {
            if (!_channelMap.TryGetValue(channel, out var pair))
            {
                Debug.LogError($"{channel} 音量参数未设置");
                return;
            }
            
            float v = Mathf.Clamp01(volume);
            _volumes[channel] = v;

            audioMixer.SetFloat(pair, LinearToDb(v));
        }

        // Lua: local v = TheSim:GetSoundVolume(channel)
        public float GetSoundVolume(string channel)
        {
            return _volumes[channel];
        }

        // Lua: TheSim:SetLowPassFilter(category, cutoffHz)
        public void SetLowPassFilter(string category, float cutoffHz)
        {
            if (!_dspParamMappings.TryGetValue(category, out var pair))
            {
                Debug.LogError($"{category} 滤波参数未设置");
                return;
            }
            
            // cutoffHz 通常范围 10..22000
            float hz = Mathf.Clamp(cutoffHz, 10f, 22000f);
            audioMixer.SetFloat(pair.lowPassParam, hz);
        }

        // Lua: TheSim:SetHighPassFilter(category, cutoffHz)
        public void SetHighPassFilter(string category, float cutoffHz)
        {
            if (!_dspParamMappings.TryGetValue(category, out var pair))
            {
                Debug.LogError($"{category} 滤波参数未设置");
                return;
            }
            
            // cutoffHz 通常范围 10..22000
            float hz = Mathf.Clamp(cutoffHz, 10f, 22000f);
            audioMixer.SetFloat(pair.highPassParam, hz);
        }

        // Lua: TheSim:ClearDSP(category)
        // 将该 category 的滤波参数恢复到“中性值”
        // low-pass: 22000Hz（基本不影响）
        // high-pass: 10Hz（基本不影响）
        public void ClearDSP(string category)
        {
            if (!_dspParamMappings.TryGetValue(category, out var pair))
            {
                Debug.LogError($"{category} 滤波参数未设置");
                return;
            }
            
            audioMixer.SetFloat(pair.lowPassParam, 22000f);
            audioMixer.SetFloat(pair.highPassParam, 10f);
        }
        
        // 返回按当前 Time.timeScale 缩放后的模拟 tick 计数（从 0 开始）
        // tick 时长由 GetTickTime() 决定（通常 1/30 秒）
        public long GetTick()
        {
            double tt = GetTickTime();
            if (tt <= 0) tt = 1.0 / 30.0;

            double simTime = Time.timeAsDouble; // 受 Time.timeScale 影响
            
            return (long)Math.Floor(simTime / tt);
        }
        
        public void EnableUserDataCollection(bool enabled) {
            // 保存状态，方便后续查询或上报系统使用 _userDataCollectionEnabled = enabled;
            
            // 可选：持久化，防止下次启动丢失（看你是否需要）
            PlayerPrefs.SetInt("user_data_collection", enabled ? 1 : 0);
            PlayerPrefs.Save();
        }
        
        // Default installed DLCs (match dlcsupport.lua: 1,2,3)
        // REIGN_OF_GIANTS = 1, CAPY_DLC = 2, PORKLAND_DLC = 3
        private readonly HashSet<int> _installed = new HashSet<int> { 1, 2, 3 };
        private readonly HashSet<int> _enabled = new HashSet<int>();

        public bool IsDLCInstalled(int index)
        {
            return _installed.Contains(index);
        }

        public bool IsDLCEnabled(int index)
        {
            return _enabled.Contains(index);
        }

        public void SetDLCEnabled(int index, bool enabled)
        {
            if (enabled)
                _enabled.Add(index);
            else
                _enabled.Remove(index);
        }

        // Optional: expose install/uninstall operations if needed later
        public void SetDLCInstalled(int index, bool installed)
        {
            if (installed)
                _installed.Add(index);
            else
                _installed.Remove(index);
        }

        // =========================
        // 日志 / 设置 / 持久化
        // =========================
        
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

        // =========================
        // 时间相关
        // =========================

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

        // Lua: TheSim:SetReverbPreset("default")
        // 语义：根据预设名切换环境混响；"off"/nil 关闭混响；未知值降级为 Generic
        public void SetReverbPreset(string presetName)
        {
            if (string.IsNullOrEmpty(presetName) || presetName.Equals("off", StringComparison.OrdinalIgnoreCase) ||
                presetName.Equals("none", StringComparison.OrdinalIgnoreCase))
            {
                reverb.enabled = false;
                reverb.reverbPreset = AudioReverbPreset.Off;
                Debug.Log("[TheSim] Reverb OFF");
                return;
            }

            AudioReverbPreset preset = MapPresetName(presetName);
            reverb.reverbPreset = preset;
            reverb.enabled = preset != AudioReverbPreset.Off;
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

        // =========================
        // Camera API
        // =========================

        private Vector3 cameraDir = Vector3.forward;
        private Vector3 cameraUp = Vector3.up;

        public void SetCameraPos(float x, float y, float z)
        {
            if (Camera.main != null)
            {
                Camera.main.transform.position = new Vector3(x, y, z);
            }
        }

        public void SetCameraDir(float x, float y, float z)
        {
            cameraDir = new Vector3(x, y, z).normalized;
            UpdateCameraRotation();
        }

        public void SetCameraUp(float x, float y, float z)
        {
            cameraUp = new Vector3(x, y, z).normalized;
            UpdateCameraRotation();
        }

        private void UpdateCameraRotation()
        {
            if (Camera.main != null && cameraDir != Vector3.zero && cameraUp != Vector3.zero)
            {
                Camera.main.transform.rotation = Quaternion.LookRotation(cameraDir, cameraUp);
            }
        }

        public void SetCameraFOV(float fov)
        {
            if (Camera.main != null)
            {
                Camera.main.fieldOfView = fov;
            }
        }

        // =========================
        // Audio Listener API
        // =========================

        public void SetListener(float lx, float ly, float lz, float dx, float dy, float dz, float ux, float uy, float uz)
        {
            audioListener.transform.position = new Vector3(lx, ly, lz);
            audioListener.transform.rotation = Quaternion.LookRotation(new Vector3(dx, dy, dz).normalized, new Vector3(ux, uy, uz).normalized);
        }

    }
}
