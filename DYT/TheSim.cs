// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Reflection;
// using System.Text;
// using System.Text.RegularExpressions;
// using DYT.Enums;
// using DYT.Tools;
// using UnityEngine;
// using UnityEngine.Audio;
// using UnityEngine.Networking;
// using Object = UnityEngine.Object;
// using Random = UnityEngine.Random;
//
// namespace DYT
// {
//     public class TheSim : MonoBehaviour
//     {
//         public static TheSim INSTANCE;
//         private static string _persistStringPath;
//         private static string _dataPath;
//
//         public GameObject cameraGameObject;
//         public GameObject audioListenerGameObject;
//         public AudioMixer audioMixer;
//     
//         private Camera _mainCamera;
//         private static bool _useUnicode;
//         private static Dictionary<string, Dictionary<string, string>> settingDictionary = new();
//         private static Dictionary<string, GameObject> _loadedPrefabCache = new();
//
//
//         private void Awake()
//         {
//             // _mainCamera = cameraGameObject.GetComponent<Camera>();
//         }
//
//         private IEnumerator Start()
//         {
//             _persistStringPath = Application.persistentDataPath;
//             _dataPath = Application.dataPath;
//             INSTANCE = this;
//         
//             string path = $"{Application.streamingAssetsPath}/settings.ini";
//             UnityWebRequest request;
// #if UNITY_ANDROID || UNITY_IOS
//             path = $"{Application.persistentDataPath}/settings.ini";
//             if (!File.Exists(path))
//             {
//                 request = new UnityWebRequest($"{Application.streamingAssetsPath}/settings.ini");
//                 request.downloadHandler = new DownloadHandlerFile(path);
//                 yield return request.SendWebRequest();
//             }
// #endif
//             IniTool.LoadConfigFile(path);
//             yield return null;
//         }
//     
//
//         public void GetPersistentString(string fileName, Action<bool, string> callback, bool encode = false)
//         {
//             string path = Path.Combine(_persistStringPath, fileName);
//         
//             if (File.Exists(path)) callback(true, File.ReadAllText(fileName, Encoding.UTF8));
//             else callback(false, null);
//         }
//         public void SetPersistentString(string filePath, string data, bool encode,
//             Action callback, bool? local_save = false)
//         {
//             File.WriteAllText(filePath, data, encode ? Encoding.UTF8 : Encoding.Default);
//
//             callback?.Invoke();
//         }
//
//         public string GetSetting(string type, string settingName)
//         {
//             return IniTool.GetContent(type, settingName);
//         }
//         public void SetSetting(string settingType, string settingName, string settingValue)
//         {
//             if (!settingDictionary.ContainsKey(settingType))
//                 settingDictionary.Add(settingType, new Dictionary<string, string> { { settingName, settingValue } });
//             else if (!settingDictionary[settingType].ContainsKey(settingName))
//                 settingDictionary[settingType].Add(settingName, settingValue);
//             else settingDictionary[settingType][settingName] = settingValue;
//         }
//
//         public void SetUseUnicode(bool useUnicode)
//         {
//             _useUnicode = useUnicode;
//         }
//
//         public long getrealtime()
//         {
//             return DateTimeOffset.Now.ToUnixTimeMilliseconds();
//         }
//         public int GetRealTime()
//         {
//             return (int)Time.unscaledTime * 1000;
//         }
//         public float GetTick()
//         {
//             return Time.fixedDeltaTime;
//         }
//         public int GetTickTime()
//         {
//             return Time.frameCount;
//         }
//
//         public float GetSoundVolume(string sound)
//         {
//             audioMixer.GetFloat(sound, out float volume);
//             return (volume + 80) / 100;
//         }
//         public void SetSoundVolume(string sound, float volume)
//         {
//             // volume: [0, 1]       SetFloat: [-80, 20]
//             audioMixer.SetFloat(sound, volume * 100 - 80);
//         }
//
//         public List<string> GetModDirectoryNames()
//         {
//             string modPath = $"{Application.persistentDataPath}/mods";
//             string[] modNameArray = Directory.GetDirectories(modPath);
//             return modNameArray.Select(modName => Path.GetRelativePath(modPath, modName)).ToList();
//         }
//
//         public bool LoadModInfo(string modName, ref KnownModIndex.ModInfo modInfo)
//         {
//             string path = $"{_dataPath}/Mods/{modName}/mod_info.txt";
//             if (!File.Exists(path)) return false;
//
//             bool hasConfig = false;
//             KnownModIndex.Config config = null;
//             bool hasOption = false;
//             KnownModIndex.Option option = null;
//             foreach (string line in File.ReadAllLines(path))
//             {
//                 if (string.IsNullOrWhiteSpace(line)) continue;
//             
//                 if (line == "[config]")
//                 {
//                     if (modInfo.configList == null)
//                         modInfo.configList = new List<KnownModIndex.Config>();
//
//                     hasConfig = true;
//                     hasOption = false;
//                     config = new KnownModIndex.Config();
//                     modInfo.configList.Add(config);
//                     continue;
//                 }
//                 else if (line == "[option]")
//                 {
//                     if (config.optionList == null) config.optionList = new List<KnownModIndex.Option>();
//
//                     hasOption = true;
//                     option = new KnownModIndex.Option();
//                     config.optionList.Add(option);
//                     continue;
//                 }
//             
//                 Match match = Regex.Match(line, @"\s*(\S+)\s*=\s*(\S+)");
//                 string key = match.Groups[1].Value;
//                 string value = match.Groups[2].Value;
//             
//                 if (hasConfig)
//                 {
//                     if (hasOption)
//                     {
//                         if (key == "description") option.description = value;
//                         else if (key == "data") option.data = value;
//                         else if (key == "hover") option.hover = value;
//                     }
//                     else
//                     {
//                         if (key == "name") config.name = value;
//                         else if (key == "label") config.label = value;
//                         else if (key == "hover") config.hover = value;
//                         else if (key == "default") config.defaultValue = value;
//                     }
//                 }
//                 else
//                 {
//                     string fieldName = NameTool.TransformName(key, NameStyle.LowerCamel);
//                     Type type = typeof(KnownModIndex.ModInfo);
//                     FieldInfo fieldInfo = type.GetField(fieldName);
//                     fieldInfo.SetValue(modInfo, value);
//                 }
//             }
//
//             return true;
//         }
//
//         public void SetCameraPos(float px, float py, float pz)
//         {
//             cameraGameObject.transform.position = new Vector3(px, py, pz);
//         }
//
//         public void SetCameraDir(float dx, float dy, float dz)
//         {
//             cameraGameObject.transform.forward = new Vector3(dx, dy, dz);
//         }
//
//         public void SetCameraUp(float dx, float dy, float dz)
//         {
//             // cameraGameObject.transform.up = new Vector3(dx, dy, dz);
//         }
//     
//         public void SetCameraFOV(float fov)
//         {
//             cameraGameObject.GetComponent<Camera>().fieldOfView = fov;
//         }
//
//         public void LoadPrefabs(params string[] prefabNameArray)
//         {
//         }
//         public void LoadPrefabs(List<string> prefabNameList)
//         {
//             LoadPrefabs(prefabNameList.ToArray());
//         }
//         public void UnloadPrefabs(List<string> prefabNameArray)
//         {
//             foreach (string prefabName in prefabNameArray)
//             {
//                 if (_loadedPrefabCache.ContainsKey(prefabName)) Object.Destroy(_loadedPrefabCache[prefabName]);
//             }
//         }
//
//         // TODO: TheSim.GetUserID()
//         public string GetUserID()
//         {
//             return "111";
//         }
//
//         public void CheckPersistentStringExists(string path, Action<bool> action)
//         {
//             string allFilePath = Path.Combine(_persistStringPath, path);
//             action?.Invoke(File.Exists(allFilePath));
//         }
//
//         public void SetInstanceParameters(string param)
//         {
//             SetPersistentString(_persistStringPath + "/instance-parameters", param, false, null);
//         }
//     
//         public void SetReverbPreset(string str){}
//     
//         public void ResetSim(){}
//     
//         public void ForceAbort(){}
//     
//         public void FileBugReport(string str){}
//
//         public bool IsBugReportRunning()
//         {
//             return Random.Range(0, 2) < 1;
//         }
//
//         public bool DidBugReportSucceed()
//         {
//             return Random.Range(0, 2) < 1;
//         }
//
//         // TODO: GenerateNewWorld
//         public void GenerateNewWorld(string genparam, string modparam, Action<string> handler)
//         {
//             WorldGenMain.GEN_PARAMETERS = genparam;
//             handler("123");
//         }
//
//         public void LuaPrint(params object[] args)
//         {
//             foreach (object o in args)
//             {
//                 Debug.Log(o);
//             }
//         }
//
//         public string GetAgreementsSetting(string mainKey, string subKey)
//         {
//             return GetSetting(mainKey, subKey);
//         }
//
//         public bool IsDLCInstalled(int index)
//         {
//             return true;
//         }
//         
//         public void EnableUserDataCollection(bool enable){}
//         
//         private readonly List<Prefab> _prefabList = new List<Prefab>();
//         public void RegisterPrefab(string prefabName, List<Asset> assetList, List<object> deps)
//         {
//             Prefab prefab = new Prefab
//             {
//                 name = prefabName,
//                 assets = assetList,
//                 deps = deps
//             };
//             _prefabList.Add(prefab);
//         }
//
//         public object FindFirstEntityWithTag(string tag)
//         {
//             return null;
//         }
//
//         public void SetListener(float lx, float ly, float lz,
//             float dx, float dy, float dz, float ux, float uy, float uz
//         )
//         {
//             audioListenerGameObject.transform.position = new Vector3(lx, ly, lz);
//             audioListenerGameObject.transform.forward = new Vector3(dx, dy, dz);
//             audioListenerGameObject.transform.up = new Vector3(ux, uy, uz);
//         }
//
//     
//     
//         private int statusState;
//         private int statusProgress;
//         public Dictionary<string, string> GetWorkshopUpdateStatus()
//         {
//             Dictionary<string, string> status = new Dictionary<string, string>();
//
//             if (statusState == 3)
//             {
//                 status.Add("state", "download");
//             
//                 int range = Random.Range(statusProgress, 101);
//                 status.Add("progress", range.ToString());
//                 statusProgress = range + 1;
//
//                 if (range == 100)
//                 {
//                     statusState = 0;
//                     statusProgress = 0;
//                 }
//             }
//             else
//             {
//                 int range = Random.Range(statusState, 3);
//                 status.Add("state", range == 0 ? "list" : range == 1 ? "details" : "download");
//                 statusState = range + 1;
//             
//                 status.Add("progress", statusProgress.ToString());
//                 if (statusState == 3) statusProgress = 1;
//             }
//
//             return status;
//         }
//     }
// }