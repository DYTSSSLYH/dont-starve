using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using DYT.Enums;
using DYT.Tools;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Networking;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace DYT
{
    public class TheSim : MonoBehaviour
    {
        public static TheSim instance;
        private static string _persistStringPath;
        private static string _dataPath;

        public GameObject cameraGameObject;
        public AudioMixer audioMixer;
    
        private Camera _mainCamera;
        private static bool _useUnicode;
        private static Dictionary<string, Dictionary<string, string>> settingDictionary = new();
        private static Dictionary<string, GameObject> _loadedPrefabCache = new();


        private void Awake()
        {
            _mainCamera = cameraGameObject.GetComponent<Camera>();
        }

        private IEnumerator Start()
        {
            _persistStringPath = Application.persistentDataPath;
            _dataPath = Application.dataPath;
            instance = this;
        
            string path = $"{Application.streamingAssetsPath}/settings.ini";
            UnityWebRequest request;
#if UNITY_ANDROID || UNITY_IOS
            path = $"{Application.persistentDataPath}/settings.ini";
            if (!File.Exists(path))
            {
                request = new UnityWebRequest($"{Application.streamingAssetsPath}/settings.ini");
                request.downloadHandler = new DownloadHandlerFile(path);
                yield return request.SendWebRequest();
            }
#endif
            IniTool.LoadConfigFile(path);
        }
    

        public static void GetPersistentString(string fileName, Action<bool, string> callback, bool encode = false)
        {
            string path = Path.Combine(_persistStringPath, fileName);
        
            if (File.Exists(path)) callback(true, File.ReadAllText(fileName, Encoding.UTF8));
            else callback(false, null);
        }
        public static void SetPersistentString(string filePath, string data, bool encode,
            Action callback, bool local_save = false)
        {
            File.WriteAllText(filePath, data, encode ? Encoding.UTF8 : Encoding.Default);

            callback?.Invoke();
        }

        public static string GetSetting(string type, string settingName)
        {
            return IniTool.GetContent(type, settingName);
        }
        public static void SetSetting(string settingType, string settingName, string settingValue)
        {
            if (!settingDictionary.ContainsKey(settingType))
                settingDictionary.Add(settingType, new Dictionary<string, string> { { settingName, settingValue } });
            else if (!settingDictionary[settingType].ContainsKey(settingName))
                settingDictionary[settingType].Add(settingName, settingValue);
            else settingDictionary[settingType][settingName] = settingValue;
        }

        public static void SetUseUnicode(bool useUnicode)
        {
            _useUnicode = useUnicode;
        }

        public static int GetRealTime()
        {
            return (int)Time.unscaledTime * 1000;
        }
        public static float GetTick()
        {
            return Time.fixedDeltaTime;
        }
        public static int GetTickTime()
        {
            return Time.frameCount;
        }

        public float GetSoundVolume(string sound)
        {
            audioMixer.GetFloat(sound, out float volume);
            return (volume + 80) / 100;
        }
        public void SetSoundVolume(string sound, float volume)
        {
            audioMixer.SetFloat(sound, volume * 100 - 80);
        }

        public static string[] GetModDirectoryNames()
        {
            return Directory.GetDirectories($"{_dataPath}/Mods/");
        }

        public static bool LoadModInfo(string modName, ref KnownModIndex.ModInfo modInfo)
        {
            string path = $"{_dataPath}/Mods/{modName}/mod_info.txt";
            if (!File.Exists(path)) return false;

            bool hasConfig = false;
            KnownModIndex.Config config = null;
            bool hasOption = false;
            KnownModIndex.Option option = null;
            foreach (string line in File.ReadAllLines(path))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
            
                if (line == "[config]")
                {
                    if (modInfo.configList == null)
                        modInfo.configList = new List<KnownModIndex.Config>();

                    hasConfig = true;
                    hasOption = false;
                    config = new KnownModIndex.Config();
                    modInfo.configList.Add(config);
                    continue;
                }
                else if (line == "[option]")
                {
                    if (config.optionList == null) config.optionList = new List<KnownModIndex.Option>();

                    hasOption = true;
                    option = new KnownModIndex.Option();
                    config.optionList.Add(option);
                    continue;
                }
            
                Match match = Regex.Match(line, @"\s*(\S+)\s*=\s*(\S+)");
                string key = match.Groups[1].Value;
                string value = match.Groups[2].Value;
            
                if (hasConfig)
                {
                    if (hasOption)
                    {
                        if (key == "description") option.description = value;
                        else if (key == "data") option.data = value;
                        else if (key == "hover") option.hover = value;
                    }
                    else
                    {
                        if (key == "name") config.name = value;
                        else if (key == "label") config.label = value;
                        else if (key == "hover") config.hover = value;
                        else if (key == "default") config.defaultValue = value;
                    }
                }
                else
                {
                    string fieldName = NameTool.TransformName(key, NameStyle.LowerCamel);
                    Type type = typeof(KnownModIndex.ModInfo);
                    FieldInfo fieldInfo = type.GetField(fieldName);
                    fieldInfo.SetValue(modInfo, value);
                }
            }

            return true;
        }

        public void SetCameraPos(float px, float py, float pz)
        {
            cameraGameObject.transform.position = new Vector3(px, py, pz);
        }

        public void SetCameraDir(float dx, float dy, float dz)
        {
            cameraGameObject.transform.rotation = Quaternion.Euler(dx, dy, dz);
        }
    
        public void SetCameraFOV(float fov)
        {
            _mainCamera.fieldOfView = fov;
        }

        public static void LoadPrefabs(params string[] prefabNameArray)
        {
            foreach (string prefabName in prefabNameArray)
            {
                GameObject gameObject = Instantiate(Main.Prefabs[prefabName]);
                _loadedPrefabCache.Add(prefabName, gameObject);
            }
        }
        public static void LoadPrefabs(List<string> prefabNameList)
        {
            LoadPrefabs(prefabNameList.ToArray());
        }
        public static void UnloadPrefabs(List<string> prefabNameArray)
        {
            foreach (string prefabName in prefabNameArray)
            {
                if (_loadedPrefabCache.ContainsKey(prefabName)) Object.Destroy(_loadedPrefabCache[prefabName]);
            }
        }

        // TODO: TheSim.GetUserID()
        public static string GetUserID()
        {
            return "111";
        }

        public static void CheckPersistentStringExists(string path, Action<bool> action)
        {
            string allFilePath = Path.Combine(_persistStringPath, path);
            action?.Invoke(File.Exists(allFilePath));
        }

        public static void SetInstanceParameters(string param)
        {
            SetPersistentString(_persistStringPath + "/instance-parameters", param, false, null);
        }
    
        public static void SetReverbPreset(string str){}
    
        public static void ResetSim(){}
    
        public static void ForceAbort(){}
    
        public static void FileBugReport(string str){}

        public static bool IsBugReportRunning()
        {
            return Random.Range(0, 2) < 1;
        }

        public static bool DidBugReportSucceed()
        {
            return Random.Range(0, 2) < 1;
        }

        // TODO: GenerateNewWorld
        public static void GenerateNewWorld(string genparam, string modparam, Action<string> handler)
        {
            Main.GEN_PARAMETERS = genparam;
            handler("123");
        }

    
    
        private static int statusState;
        private static int statusProgress;
        public static Dictionary<string, string> GetWorkshopUpdateStatus()
        {
            Dictionary<string, string> status = new Dictionary<string, string>();

            if (statusState == 3)
            {
                status.Add("state", "download");
            
                int range = Random.Range(statusProgress, 101);
                status.Add("progress", range.ToString());
                statusProgress = range + 1;

                if (range == 100)
                {
                    statusState = 0;
                    statusProgress = 0;
                }
            }
            else
            {
                int range = Random.Range(statusState, 3);
                status.Add("state", range == 0 ? "list" : range == 1 ? "details" : "download");
                statusState = range + 1;
            
                status.Add("progress", statusProgress.ToString());
                if (statusState == 3) statusProgress = 1;
            }

            return status;
        }
    }
}