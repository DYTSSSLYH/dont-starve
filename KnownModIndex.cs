using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DYT;
using Mods;
using Newtonsoft.Json;
using UnityEngine;

public class KnownModIndex
{
    private static string modConfigPath = "mod-config-data/";
    
    public class Option
    {
        public string description;
        public object data;
        public string hover;
    }
    public class Config
    {
        public string name;
        public string label;
        public string hover;
        public object defaultValue;
        public object saved;
        public List<Option> optionList = new List<Option>();
        
        public int defaultIndex = 0;
        public int savedIndex = -1;
        public int currentIndex = -1;
    }
    public class ModInfo
    {
        public string folder_name;
        public string locale;
        public Func<Dictionary<string, object>, object> ChooseTranslationTable;
        public string modinfo_message;
        public bool standalone;
        
        public string name;
        public string icon = "portrait_bg";
        public string iconAtlas = "Images/ui";
        public string author = "unknown";
        public string description;
        public string version;
        public string forumThread = "http://forums.kleientertainment.com/index.php?/forum/26-dont-starve-mods-and-tools/";
        public int? apiVersion;

        public List<Config> configList;
        
        public bool failed;
        public bool old;

        public int priority;
        
        public bool dontStarveCompatible;
        public bool dontStarveCompatibilitySpecified;
        public bool reginOfGiantsCompatible;
        public bool reginOfGiantsCompatibilitySpecified;
        public bool shipwreckedCompatible;
        public bool shipwreckedCompatibilitySpecified;
        public bool hamletCompatible;
        public bool hamletCompatibilitySpecified;
    }
    public class ModData
    {
        public bool? enabled;
        public bool? was_enabled;
        public bool? disabled_bad;
        public bool? disabled_old;
        public bool? disabled_incompatible_with_mode;
        public int? seen_api_version;
        public ModInfo modinfo;
    }
    public class SaveData
    {
        public Dictionary<string, ModData> known_mods = new();
        public int? known_api_version = 0;
    }
    private static SaveData savedata = new();
    public class ModSetting
    {
        public List<string> forceenable;
        public bool initdebugprint;
    }
    private static ModSetting modsettings;
    public class CachedData
    {
        public SaveData saveData;
        public ModSetting modSettings;
    }
    private static CachedData cachedData = new();
    
    private static bool startingup = false;
    private static bool badload = false;

    
    private static void modprint(params object[] objects){}
    
    
    public static string GetModIndexName()
    {
        return "modindex";
    }

    public static string GetModConfigurationPath(string modname = null)
    {
        return modname == null ? modConfigPath : modConfigPath + GetModConfigurationName(modname);
    }

    public static string GetModConfigurationName(string modname)
    {
        return $"modconfiguration_{modname}";
    }
    
    public static void BeginStartupSequence(Action callback)
    {
        startingup = true;
        string filename = $"boot_{GetModIndexName()}";
        TheSim.GetPersistentString(filename, (load_success, str) =>
        {
            if (load_success && str == "loading")
            {
                List<string> modsenabled = GetModsToLoad();
                if (modsenabled.Count > 0)
                {
                    badload = true;
                    Debug.Log("ModIndex: Detected bad load, disabling all mods.");
                    DisableAllMods();
                    Save(null); //write to disk that all mods were disabled!
                }
                callback();
            }
            else
            {
                Debug.Log("ModIndex: Beginning normal load sequence.\n");
                MainFunctions.SavePersistentString(filename, "loading", false, callback);
            }
        });
    }
    
    public static void EndStartupSequence(Action callback)
    {
        startingup = false;
        string filename = $"boot_{GetModIndexName()}";
        MainFunctions.SavePersistentString(filename, "done", false, callback);
        DebugPrint.Print("ModIndex: Load sequence finished successfully.\n");
    }

    public static bool WasLoadBad()
    {
        return badload;
    }

    public static List<string> GetModNames()
    {
        List<string> names = new List<string>();
        foreach (string name in savedata.known_mods.Keys) names.Add(name);
        return names;
    }

    public static void Save(Action callback = null)
    {
        if (Main.PLATFORM == "PS4") return;

        SaveData newData = new SaveData { known_mods = new Dictionary<string, ModData>() };
        newData.known_api_version = ModManager.MOD_API_VERSION;
        
        foreach (string name in savedata.known_mods.Keys)
        {
            ModData data = savedata.known_mods[name];
            newData.known_mods.Add(name, new ModData());
            newData.known_mods[name].enabled = data.enabled;
            newData.known_mods[name].disabled_bad = data.disabled_bad;
            newData.known_mods[name].disabled_old = data.disabled_old;
            newData.known_mods[name].disabled_incompatible_with_mode = data.disabled_incompatible_with_mode;
            newData.known_mods[name].seen_api_version = ModManager.MOD_API_VERSION;
        }
        
        MainFunctions.SavePersistentString(
            GetModIndexName(), JsonConvert.SerializeObject(newData), Main.ENCODE_SAVES, callback);
    }

    public static List<string> GetModsToLoad(bool cached = false)
    {
        List<string> ret = new List<string>();
        if (!cached)
        {
            string[] moddirs = TheSim.GetModDirectoryNames();
            foreach (string moddir in moddirs)
            {
                if (IsModEnabled(moddir) || IsModForceEnabled(moddir)) ret.Add(moddir);
            }
        }
        else
        {
            if (savedata != null && savedata.known_mods != null)
            {
                foreach (string modname in savedata.known_mods.Keys)
                {
                    if (IsModEnabled(modname) || IsModForceEnabled(modname)) ret.Add(modname);
                }
            }
        }
        foreach (string modname in ret)
        {
            if (IsModStandalone(modname))
            {
                Debug.Log($"\n\n{ModUtil.ModInfoname(modname)} " +
                          "Loading a standalone mod! No other mods will be loaded.\n");
                return new List<string> { modname };
            }
        }
        return ret;
    }

    public static ModInfo GetModInfo(string modName)
    {
        if (savedata.known_mods.ContainsKey(modName))
        {
            return savedata.known_mods[modName].modinfo == null ? new ModInfo()
                : savedata.known_mods[modName].modinfo;
        }
        else return null;
    }
    
    public static void UpdateModInfo()
    {
        modprint("Updating all mod info.");

        List<string> modNames = new List<string>(TheSim.GetModDirectoryNames());

        foreach (string knownModsKey in savedata.known_mods.Keys)
        {
            if (!modNames.Contains(knownModsKey)) savedata.known_mods.Remove(knownModsKey);
        }

        
        foreach (string modName in modNames)
        {
            if (!savedata.known_mods.ContainsKey(modName)) savedata.known_mods.Add(modName, new ModData());
            savedata.known_mods[modName].modinfo = LoadModInfo(modName);
        }
    }

    public static ModInfo LoadModInfo(string modname)
    {
        modprint($"Updating mod info for '{modname}'");

        ModInfo info = InitializeModInfo(modname);

        if (info.old && IsModNewlyOld(modname))
        {
            modprint("  It's using an old api_version.");
            DisableBecauseOld(modname);
        }
        else if (info.failed)
        {
            modprint("  But there was an error loading it.");
            DisableBecauseBad(modname);
        }
        else
        {
            // we've already "dealt" with this in the past;
            // if the user chooses to enable it, then try loading it!
        }

        savedata.known_mods[modname].modinfo = info;

        info.version ??= "";
        info.version = info.version.ToLower();

        return info;
    }
    
    public static ModInfo InitializeModInfo(string modname)
    {
        ModInfo env = new ModInfo();
        
        // If modinfo hasn't been updated to specify compatibility yet,
        // set it to true for both modes and set a flag
        env.dontStarveCompatible = true;
        env.dontStarveCompatibilitySpecified = false;
        env.reginOfGiantsCompatible = true;
        env.reginOfGiantsCompatibilitySpecified = false;
        env.shipwreckedCompatible = true;
        env.shipwreckedCompatibilitySpecified = false;
        env.hamletCompatible = true;
        env.hamletCompatibilitySpecified = false;
        
        bool fn = TheSim.LoadModInfo(modname, ref env);
        env.folder_name = modname;
        env.locale = Loc.GetLocaleCode();
        env.ChooseTranslationTable = tbl =>
        {
            string locale = Loc.GetLocaleCode();
            return tbl.ContainsKey(locale) ? tbl[locale] : tbl.First(pair => true);
        };

        string modinfo_message = "";
        if (!fn)
        {
            modinfo_message += "No modinfo.lua, using defaults... ";
            env.old = true;
        }
        else
        {
            string apiVersionString = env.apiVersion.HasValue ? env.apiVersion.Value.ToString() : "";
            if (!env.apiVersion.HasValue || env.apiVersion < ModManager.MOD_API_VERSION)
            {
                modinfo_message += $"Old API! (mod: {apiVersionString} game: {ModManager.MOD_API_VERSION}) ";
                env.old = true;
            }
            else if (env.apiVersion > ModManager.MOD_API_VERSION)
            {
                string old = $"api_version for {modname} is in the future, please set to the current version." +
                             $" (api_version is version {apiVersionString}," +
                             $" game is version {ModManager.MOD_API_VERSION}.)";
                Debug.Log($"Error loading mod: {ModUtil.ModInfoname(modname)}!\n {old}\n");
                env.failed = true;
            }
            else
            {
                string[] checkinfo =
                {
                    "name", "author", "version", "description", "forumThread",
                    "apiVersion", "configOptionList", "dontStarveCompatible",
                    "reginOfGiantsCompatible", "shipwreckedCompatible", "hamletCompatible"
                };
                List<string> missing = new List<string>();

                Type type = typeof(ModInfo);
                foreach (string v in checkinfo)
                {
                    FieldInfo fieldInfo = type.GetField(v);
                    object value = fieldInfo.GetValue(env);
                    if (value == null)
                    {
                        if (v == "dontStarveCompatible") //Print a warning but let the mod load
                        {
                            Debug.Log("WARNING loading modinfo.lua: " +
                                      $"{modname} does not specify if it is compatible with the base game." +
                                      " It may not work properly.");
                        }
                        else if (v == "reginOfGiantsCompatible") //Print a warning but let the mod load
                        {
                            Debug.Log("WARNING loading modinfo.lua: " +
                                      $"{modname} does not specify if it is compatible with Reign of Giants" +
                                      " It may not work properly.");
                        }
                        else if (v == "shipwreckedCompatible") //Print a warning but let the mod load
                        {
                            Debug.Log("WARNING loading modinfo.lua: " +
                                      $"{modname} does not specify if it is compatible with Shipwrecked" +
                                      " It may not work properly.");
                        }
                        else if (v == "hamletCompatible") //Print a warning but let the mod load
                        {
                            Debug.Log("WARNING loading modinfo.lua: " +
                                      $"{modname} does not specify if it is compatible with Hamlet" +
                                      " It may not work properly.");
                        }
                        else if (v == ""){} //Do nothing. It's perfectly fine not to have config options!
                        else missing.Add(v);
                    }
                }

                if (missing.Count > 0)
                {
                    Debug.Log("Error loading modinfo.lua. " +
                              $"These fields are required: {string.Concat(missing, ", ")}");

                    env.failed = true;
                }
                else{} //everything loaded okay!
            }
        }

        env.modinfo_message = modinfo_message;

        return env;
    }

    public static string GetModFancyName(string modName)
    {
        return savedata.known_mods.ContainsKey(modName) ? savedata.known_mods[modName].modinfo.name : modName;
    }

    public static void Load(Action callback)
    {
        UpdateModSettings();

        string filename = GetModIndexName();
        
        TheSim.GetPersistentString(filename, (load_success, str) =>
        {
            if (load_success && !string.IsNullOrWhiteSpace(str))
            {
                savedata = JsonConvert.DeserializeObject<SaveData>(str);

                foreach (ModData info in savedata.known_mods.Values) info.was_enabled = info.enabled;
                
                Debug.Log($"loaded {filename}");
                
                UpdateModInfo();
            }
            else Debug.Log($"Could not load {filename}");
            
            callback();
        });
    }

    public static bool IsModCompatibleWithMode(string modname, object dlcmode = null) //TODO: dlcmode
    {
        ModData known_mod = savedata.known_mods.ContainsKey(modname) ? savedata.known_mods[modname] : null;
        bool reignofgiants = DLCSupport.IsDLCEnabled(DLCSupport.REIGN_OF_GIANTS);
        bool shipwrecked = DLCSupport.IsDLCEnabled(DLCSupport.CAPY_DLC);
        bool hamlet = DLCSupport.IsDLCEnabled(DLCSupport.PORKLAND_DLC);

        if (known_mod != null)
        {
            if (reignofgiants || shipwrecked || hamlet)
            {
                return (reignofgiants && known_mod.modinfo.reginOfGiantsCompatible)
                       || (shipwrecked && known_mod.modinfo.shipwreckedCompatible)
                       || (hamlet && known_mod.modinfo.hamletCompatible);
            }
            else return known_mod.modinfo.dontStarveCompatible;
        }

        return false;
    }
    
    public static bool HasModConfigurationOptions(string modname)
    {
        ModInfo modInfo = GetModInfo(modname);
        return modInfo != null && modInfo.configList != null && modInfo.configList.Count > 0;
    }
    
    public static void UpdateConfigurationOptions(List<Config> config_options, List<Config> savedata)
    {
        foreach (Config savedConfig in savedata)
        {
            foreach (Config config in config_options)
            {
                if (savedConfig.name == config.name && savedConfig.saved != null)
                    config.saved = savedConfig.saved;
            }
        }
    }
    
    // Just returns the table itself
    public static List<Config> GetModConfigurationOptions(string modname)
    {
        return savedata.known_mods.ContainsKey(modname)
            ? savedata.known_mods[modname].modinfo.configList
            : new List<Config>();
    }
    
    // Loads the actual file from disk
    public static List<Config> LoadModConfigurationOptions(string modname)
    {
        ModData known_mod = savedata.known_mods.ContainsKey(modname) ? savedata.known_mods[modname] : null;
        // Try to find saved config settings first
        string filename = GetModConfigurationPath(modname);
        TheSim.GetPersistentString(filename, (load_success, str) =>
        {
            if (load_success && !string.IsNullOrWhiteSpace(str))
            {
                List<Config> savedata = JsonConvert.DeserializeObject<List<Config>>(str);
                // Carry over saved data from old versions when possible
                if (HasModConfigurationOptions(modname))
                    UpdateConfigurationOptions(known_mod.modinfo.configList, savedata);
                else known_mod.modinfo.configList = savedata;
                Debug.Log($"loaded {filename}");
            }
            else Debug.Log($"Could not load {filename}");
        });

        return known_mod != null && known_mod.modinfo != null && known_mod.modinfo.configList != null
            ? known_mod.modinfo.configList
            : new List<Config>();
    }

    public static void SaveConfigurationOptions(Action callback, string modName, List<Config> configData)
    {
        if (configData.Count == 0) return;
        
        string filePath = GetModConfigurationPath(modName);
        string data = "";
        foreach (Config configOption in configData)
            data += configOption.name + "=" + configOption.currentIndex + "\n";
        
        MainFunctions.SavePersistentString(filePath, data, Main.ENCODE_SAVES, callback);
    }

    public static bool IsModEnabled(string modName)
    {
        ModData knownMod = savedata.known_mods.ContainsKey(modName) ? savedata.known_mods[modName] : null;
        return knownMod != null && knownMod.enabled.HasValue && knownMod.enabled.Value;
    }

    public static bool IsModForceEnabled(string modname)
    {
        return modsettings.forceenable.Contains(modname);
    }

    public static bool IsModStandalone(string modname)
    {
        ModData known_mod = savedata.known_mods.ContainsKey(modname) ? savedata.known_mods[modname] : null;
        return known_mod != null && known_mod.modinfo != null && known_mod.modinfo.standalone;
    }

    public static bool IsModInitPrintEnabled()
    {
        return modsettings.initdebugprint;
    }

    // Note: Installed means enabled + ran in this terminology
    public static bool WasModEnabled(string modName)
    {
        ModData knownMod = savedata.known_mods.ContainsKey(modName) ? savedata.known_mods[modName] : null;
        return knownMod != null && knownMod.was_enabled.HasValue && knownMod.was_enabled.Value;
    }

    public static void Disable(string modname)
    {
        if (!savedata.known_mods.ContainsKey(modname)) savedata.known_mods.Add(modname, new ModData());
        savedata.known_mods[modname].enabled = false;
    }

    public static void DisableAllMods()
    {
        foreach (string key in savedata.known_mods.Keys) Disable(key);
    }

    public static void DisableBecauseBad(string modname)
    {
        if (!savedata.known_mods.ContainsKey(modname)) savedata.known_mods.Add(modname, new ModData());
        savedata.known_mods[modname].disabled_bad = true;
        savedata.known_mods[modname].enabled = false;
    }

    public static void DisableBecauseOld(string modname)
    {
        if (!savedata.known_mods.ContainsKey(modname)) savedata.known_mods.Add(modname, new ModData());
        savedata.known_mods[modname].disabled_old = true;
        savedata.known_mods[modname].enabled = false;
    }

    public static bool IsModNewlyBad(string modname)
    {
        return savedata.known_mods.TryGetValue(modname, out ModData known_mod)
               && known_mod.modinfo.failed;
    }

    public static int KnownAPIVersion(string modname)
    {
        ModData known_mod = savedata.known_mods.GetValueOrDefault(modname, null);
        // If we've never seen the mod before, we assume it's REALLY old
        if (known_mod == null || known_mod.modinfo == null) return -2;
        // If we've seen it but it has no info, it's just "Old"
        else if (known_mod.modinfo.apiVersion == null) return -1;
        else return known_mod.modinfo.apiVersion.Value;
    }

    public static bool IsModNewlyOld(string modname)
    {
        if (KnownAPIVersion(modname) < ModManager.MOD_API_VERSION && savedata.known_mods.ContainsKey(modname)
            && savedata.known_mods[modname].seen_api_version != null
            && savedata.known_mods[modname].seen_api_version < ModManager.MOD_API_VERSION)
        {
            return true;
        }
        return false;
    }

    public static bool IsModKnownBad(string modName)
    {
        return savedata.known_mods.ContainsKey(modName)
               && savedata.known_mods[modName].disabled_bad.HasValue
               && savedata.known_mods[modName].disabled_bad.Value;
    }

    public static void RestoreCachedSaveData(CachedData extraData)
    {
        if (extraData != null)
        {
            savedata = extraData.saveData;
            modsettings = extraData.modSettings;
        }
        else if (cachedData != null)
        {
            savedata = cachedData.saveData;
            modsettings = cachedData.modSettings;
        }
    }

    private static void ForceEnableMod(string modname)
    {
        Debug.Log($"WARNING: Force-enabling mod '{ModUtil.ModInfoname(modname)}' from modsettings.lua! " +
                  "If you are not developing a mod, please use the in-game menu instead.");
        
        modsettings.forceenable.Add(modname);
    }
    private static void EnableModDebugPrint()
    {
        modsettings.initdebugprint = true;
    }
    
    // When the user changes settings it messes directly with the index data, so make a backup
    public static CachedData CacheSaveData()
    {
        cachedData = new CachedData
        {
            saveData = Util.deepcopy(savedata),
            modSettings = Util.deepcopy(modsettings)
        };
        return cachedData;
    }
    
    public static void UpdateModSettings()
    {
        modsettings = new ModSetting { forceenable = new List<string>() };

        ModSettings.ForceEnableMod = ForceEnableMod;
        ModSettings.EnableModDebugPrint = EnableModDebugPrint;
        ModSettings.Init();
    }
}