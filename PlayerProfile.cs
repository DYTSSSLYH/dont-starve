using System;
using System.Collections.Generic;
using DYT;
using Newtonsoft.Json;
using UnityEngine;

/**
 * 存储游戏外的数据，如玩家经验、解锁角色等
 */
public class PlayerProfile
{
    public class Control
    {
        public int guid;
        public object data;
        public bool enabled;
    }
    public class Data
    {
        public int xp { get; set; } = 0;
        public object unlockedWorldGen { get; set; } = new object();
        public Constant.RenderQuality renderQuality { get; set; } = Constant.RenderQuality.Default;
        public string characterInthrone { get; set; } = "maxwell";
        // Controlls should be a seperate file
        public List<Control> controls = new();
        public int starts = 0;
        public bool sawDisplayAdjustmentPopup { get; set; } = false;
        public int device_caps_a { get; set; } = 0;
        public int device_caps_b { get; set; } = 20;

        public Constant.LANGUAGE? languageId;
        public bool? autoSave { get; set; }
        public bool hamletClicked { get; set; }

        public List<string> unlockedCharacterList { get; set; } = new();
        public List<Level>[] customPresets { get; set; } = {new(), new(), new(), new()};
    }
    
    
    public Data persistData = new();
    private static bool dirty = true;

    #region 1

    public void SoftReset()
    {
        persistData.xp = 0;
        persistData.unlockedWorldGen = new object();
        persistData.unlockedCharacterList = new List<string>();
        persistData.characterInthrone = "maxwell";
        persistData.sawDisplayAdjustmentPopup = false;
        persistData.device_caps_a = 0;
        persistData.device_caps_b = 20;
        persistData.customPresets = new []
        {
            new List<Level>(),
            new List<Level>(),
            new List<Level>(),
            new List<Level>()
        };

        // and apply these values
        Set(JsonConvert.SerializeObject(persistData), null);
    }

    public object GetValue(string name)
    {
        return typeof(Data).GetField(name).GetValue(persistData);
    }
    public void SetValue(string name, object value)
    {
        dirty = true;
        typeof(Data).GetField(name).SetValue(persistData, value);
    }

    public static void GetVolume(out int ambient, out int sfx, out int music)
    {
        string volumeString = TheSim.GetSetting("audio", "volume_ambient");
        ambient = int.Parse(string.IsNullOrWhiteSpace(volumeString) ? "10" : volumeString);
        volumeString = TheSim.GetSetting("audio", "volume_sfx");
        sfx = int.Parse(string.IsNullOrWhiteSpace(volumeString) ? "10" : volumeString);
        volumeString = TheSim.GetSetting("audio", "volume_music");
        music = int.Parse(string.IsNullOrWhiteSpace(volumeString) ? "10" : volumeString);
    }
    public static void SetVolume(int ambient, int sfx, int music)
    {
        TheSim.SetSetting("audio", "volume_ambient", ambient.ToString());
        TheSim.SetSetting("audio", "volume_sfx", sfx.ToString());
        TheSim.SetSetting("audio", "volume_music", music.ToString());
    }

    #region SCREEN FLASH
    
    public static int GetScreenFlash()
    {
        Debug.Log("Loading Screen Flash");

        string setting = TheSim.GetSetting("graphics", "screen-flash");
        Debug.Log($"Use Setting File: {setting}");
        return setting == null ? 1 : int.Parse(setting);
    }
    public static void SetScreenFlash(int value)
    {
        Debug.Log("SETTING SCREEN FLASH");
        TheSim.SetSetting("graphics", "screen-flash", value.ToString());
    }

    #endregion
    
    public static bool GetBloomEnabled()
    {
        return TheSim.GetSetting("graphics", "bloom") == "true";
    }
    public static void SetBloomEnabled(bool enabled)
    {
        TheSim.SetSetting("graphics", "bloom", enabled.ToString());
    }
    
    public static int GetHUDSize()
    {
        string hudSizeString = TheSim.GetSetting("graphics", "hud-size");
        return hudSizeString == null ? 5 : int.Parse(hudSizeString);
    }
    public static void SetHUDSize(int hudSize)
    {
        TheSim.SetSetting("graphics", "HUD-size", hudSize.ToString());
    }

    public static bool GetDLCSetting(string dlcName, string name)
    {
        string setting = TheSim.GetSetting(dlcName, name);
        return setting == null ? true : setting == "true";
    }
    public static void SetDLCSetting(string dlcName, string name, bool value)
    {
        TheSim.SetSetting(dlcName, name, value.ToString());
    }
    
    public static bool GetDistortionEnabled()
    {
        string bloom = TheSim.GetSetting("graphics", "distortion");
        return bloom == null ? true : bloom == "true";
    }
    public static void SetDistortionEnabled(bool enabled)
    {
        TheSim.SetSetting("graphics", "distortion", enabled.ToString());
    }
    
    public static bool IsScreenShakeEnabled()
    {
        string screenShakeString = TheSim.GetSetting("graphics", "screen-shake");
        if (screenShakeString != null) return screenShakeString == "true";
        return true;
    }
    public static void SetScreenShakeEnabled(bool enabled)
    {
        TheSim.SetSetting("graphics", "screen-shake", enabled.ToString());
    }
    
    public static bool IsWathgrithrFontEnabled()
    {
        string wathgrithrFont = TheSim.GetSetting("misc", "wathgrithr-font");
        return wathgrithrFont == null ? true : wathgrithrFont == "true";
    }
    public static void SetWathgrithrFontEnabled(bool enabled)
    {
        TheSim.SetSetting("misc", "wathgrithr-font", enabled.ToString());
    }

    public static bool GetVibrationEnabled()
    {
        string setting = TheSim.GetSetting("misc", "vibration");
        if (setting != null) return setting == "true";
        return false;
    }
    public static void SetVibrationEnabled(bool enabled)
    {
        TheSim.SetSetting("misc", "vibration", enabled.ToString());
    }

    public static bool GetAgreementsSetting()
    {
        string setting = TheSim.GetSetting("data-collection", "enabled");
        // Default to true this value hasn't been created yet
        if (setting == null) return true;
        else
        {
            DebugPrint.Print("FOUND THE NEW DATA", setting);
            return setting == "true";
        }
    }
    public static void SetAgreementsSetting(bool enabled)
    {
        TheSim.SetSetting("data-collection", "enabled", enabled.ToString());
    }

    
    public bool GetHamletClicked()
    {
        return persistData.hamletClicked;
    }
    public void SetHamletClicked(bool clicked)
    {
        persistData.hamletClicked = clicked;
        dirty = true;
    }

    public static void SetModsWarning(bool enabled)
    {
        TheSim.SetSetting("misc", "modswarning", enabled.ToString());
    }
    public static bool GetModsWarning()
    {
        return TheSim.GetSetting("misc", "modswarning") != "false";
    }
    
    public List<Level> GetWorldCustomizationPresets(int worldIndex)
    {
        return persistData.customPresets[worldIndex];
    }
    public void AddWorldCustomizationPreset(int worldIndex, Level preset, int index)
    {
        if (index >= 0) persistData.customPresets[worldIndex].Insert(index, preset);
        else persistData.customPresets[worldIndex].Add(preset);

        dirty = true;
    }

    public static bool GetIntegratedBackpack()
    {
        string setting = TheSim.GetSetting("misc", "integrated-backpack");
        if (setting != null) return setting == "true";
        return false;
    }
    public static void SetIntegratedBackpack(bool enabled)
    {
        TheSim.SetSetting("misc", "integrated-backpack", enabled.ToString());
    }
    
    #endregion

    #region 2
    
    public bool IsCharacterUnlocked(string character)
    {
        if (persistData.unlockedCharacterList.Contains(character)) return true;

        if (!DLCSupport.GetOfficialCharacterList().Contains(character)) return true;

        return false;
    }
    public List<string> GetUnlockedCharacters()
    {
        return persistData.unlockedCharacterList;
    }
    public void UnlockCharacter(string character)
    {
        persistData.unlockedCharacterList.Add(character);
    }
    
    #endregion

    #region 3
    #endregion

    #region 4

    public static string GetSaveName()
    {
        return "profile";
    }
    
    public void Save(Action<bool> callback = null)
    {
        MainFunctions.Print(Constant.VERBOSITY.DEBUG, "SAVING");
        if (dirty)
        {
            string str = JsonConvert.SerializeObject(persistData);
            TheSim.SetPersistentString("profile", str, Main.ENCODE_SAVES, () => callback(false));
        }
        else callback?.Invoke(true);
    }

    public static void Load(Action<bool> callback, bool minimalLoad = false)
    {
        TheSim.GetPersistentString(GetSaveName(), (loadSuccess, str) => GameLogic.Profile.Set(str, callback, minimalLoad), false);
    }

    private static object GetValueOrDefault(object value, object defaultValue)
    {
        return value == null ? defaultValue : value;
    }
    
    public void Set(string str, Action<bool> callback, bool minimalLoad = false)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            Debug.Log($"could not load {GetSaveName()}");

            if (callback != null)
            {
                SoftReset(); //this is purposely inside the if
                callback(false);
            }
        }
        else
        {
            Debug.Log($"loaded {GetSaveName()}");
            dirty = false;
            
            persistData = JsonConvert.DeserializeObject<Data>(str);

            if (!persistData.autoSave.HasValue) persistData.autoSave = true;
            
            if (minimalLoad)
            {
                Debug.Assert(callback == null);
                return;
            }
            
            GetVolume(out int ambient, out int sfx, out int music);
            MainFunctions.Print(Constant.VERBOSITY.DEBUG, "volumes", ambient, sfx, music);
            
            TheMixer.SetLevel("set_sfx", sfx / 10f);
            TheMixer.SetLevel("set_ambience", ambient / 10f);
            TheMixer.SetLevel("set_music", music / 10f);

            if (Main.TheFrontEnd)
            {
                bool bloom_enabled = GetBloomEnabled();
                bool distortion_enabled = GetDistortionEnabled();
                
                DebugPrint.Print("bloom_enabled", bloom_enabled);
            }

            // old save data will not have the controls section so create it
            if (persistData.controls == null) persistData.controls = new List<Control>();
            
            // TODO: 获取设备实际cap
            // self.persistdata.device_caps_a, self.persistdata.device_caps_b =
            //     TheSim:UpdateDeviceCaps(self.persistdata.device_caps_a, self.persistdata.device_caps_b)
            dirty = true;

            callback?.Invoke(true);
        }
    }

    public void SetControls(int guid, object data, bool enabled)
    {
        // check if this device is already in the list and update if found
        Control find = persistData.controls.Find(control => control.guid == guid);
        if (find == null)
        {
            // not an existing device so add it
            persistData.controls.Add(new Control{guid = guid, data = data, enabled = enabled});
        }
        else
        {
            find.data = data;
            find.enabled = enabled;
        }

        dirty = true;
    }

    public static bool SawControllerPopup()
    {
        return TheSim.GetSetting("misc", "controller_popup") == "true";
    }

    public static void ShowedControllerPopup()
    {
        TheSim.SetSetting("misc", "controller_popup", "true");
    }

    public Constant.LANGUAGE GetLanguageID()
    {
        return persistData.languageId.GetValueOrDefault(Constant.LANGUAGE.ENGLISH);
    }

    #endregion
}