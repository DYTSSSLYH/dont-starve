using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

namespace DYT
{
    public class TheSimBridge
    {
        // Delegates for Lua callbacks (xLua will map Lua functions to these)
        public delegate void PersistentStringCallback(bool success, string data);
        public delegate void SimpleCallback(bool success);
        
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

            // 可选：在此处接入你的埋点/分析开关
            // 例如 Unity Analytics、GameAnalytics、自研埋点等
            // #if USE_UNITY_ANALYTICS
            // AnalyticsService.Instance.SetAnalyticsEnabled(enabled);
            // #endif

            Debug.Log($"[TheSim] User data collection {(enabled ? "ENABLED" : "DISABLED")}");

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