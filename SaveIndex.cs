using System;
using System.Collections.Generic;
using System.Reflection;
using DYT;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

public class SaveIndex
{
    public class Mode
    {
        public string file;
        public List<string> files;
        public int? world;
        public int day;
        public int? currentCave;
        public Dictionary<int, int> currentLevel;
        public CustomScreen.ChangedOption options;
        public object playerdata;
        public List<int> playlist;
    }
    public class Modes
    {
        public object empty;
        public Mode survival;
    }
    public class Slot
    {
        public string currentMode;
        public string character;
        public Modes modes;
        public object resurrectors;
        public DLCSupport.DLCTable dlc;
        public List<string> mods;
        public string save_id;
        public bool continue_pending;
    }
    public class Data
    {
        public List<Slot> slotList;
    }
    
    public class Topology
    {
        public object ids;
        public object colours;
        public object edges;
        public object nodes;
        public object level_type;
        public object overrides;
    }
    public class Map
    {
        public object prefab;
        public object tiles;
        public object width;
        public object height;
        public Topology topology;
        public object roads;
    }
    public class PlayerInfo
    {
        public object x;
        public object z;
    }
    public class SaveData
    {
        public Map map;
        public PlayerInfo playerinfo;
        public object ents;
    }
    
    
    public Data data;
    public int current_slot;
    
    private string DEFAULT_BACKUP_POSTFIX = "hamlet_beta";
    
    public SaveIndex()
    {
        Init();
        GuaranteeMinNumSlots(Constant.NUM_SAVE_SLOTS);
    }

    public void Init()
    {
        data = new Data
        {
            slotList = new List<Slot>()
        };

        for (int k = 0; k < Constant.NUM_SAVE_SLOTS; k++)
        {
            string filename = $"latest_{k}";
            
            data.slotList.Add(new Slot
            {
                currentMode = null,
                modes = new Modes{survival= new Mode{file = filename}},
                resurrectors = new object(),
                dlc = new DLCSupport.DLCTable(),
                mods = new List<string>(),
            });
        }

        current_slot = 0;
    }

    public void GuaranteeMinNumSlots(int numslots)
    {
        if (data.slotList.Count >= numslots) return;
        
        for (int i = data.slotList.Count; i < Constant.NUM_SAVE_SLOTS; i++)
        {
            string filename = $"latest_{i}";

            data.slotList.Add(new Slot
            {
                currentMode = null,
                modes = new Modes{survival= new Mode{file = filename}},
                resurrectors = new object(),
                dlc = new DLCSupport.DLCTable(),
                mods = new List<string>(),
            });
        }
    }

    public string GetSaveGameName(string type, int slot)
    {
        string savename = null;
        if (type == null) type = "unknown";

        if (type == "cave")
        {
            int caveNum = GetCurrentCaveNum(slot);
            int levelnum = GetCurrentCaveLevel(slot, caveNum);
            savename = $"{type}_{caveNum}_{levelnum}_{slot}";
        }
        else savename = $"{type}_{slot}";
        
        return savename;
    }

    public string GetSaveIndexName()
    {
        return "saveindex";
    }

    public void Save(Action callback = null, string indexName = null, bool isbackup = false)
    {
        // Will happen most of the time
        if (indexName == null) indexName = GetSaveIndexName();

        TheSim.SetPersistentString(
            indexName, JsonConvert.SerializeObject(data), Main.ENCODE_SAVES, callback, isbackup);
    }

    public void Load(Action callback)
    {
        // This happens on game start.
        string filename = GetSaveIndexName();
        Debug.Log($"Attempting to load save file {filename}");
        TheSim.GetPersistentString(filename, (load_success, str) =>
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                data = JsonConvert.DeserializeObject<Data>(str);
                Debug.Log($"loaded {filename}");
            }
            else Debug.Log($"Could not load {filename}");

            VerifyFiles(callback);
            GuaranteeMinNumSlots(Constant.NUM_SAVE_SLOTS);
        });
    }
    
    // this also does recovery of pre-existing save files (sort of)
    public void VerifyFiles(Action completion_callback)
    {
        for (int i = 0; i < data.slotList.Count; i++)
        {
            Slot slot = data.slotList[i];
            List<string> files = new List<string>();
            if (slot.currentMode == "empty") slot.currentMode = null;
            if (slot.modes != null)
            {
                slot.modes.empty = null;
                foreach (FieldInfo fieldInfo in typeof(Modes).GetFields())
                {
                    if (fieldInfo.FieldType != typeof(Mode)) continue;
                    
                    Mode mode = (Mode)fieldInfo.GetValue(slot.modes);
                    files.Add(mode.file);
                }
            }
            if (slot.save_id == null) slot.save_id = GenerateSaveID(i);
            
            FileUtil.CheckFiles(status =>
            {
                if (slot.modes != null)
                {
                    foreach (FieldInfo fieldInfo in typeof(Modes).GetFields())
                    {
                        if (fieldInfo.FieldType != typeof(Mode)) continue;
                        
                        Mode mode = (Mode)fieldInfo.GetValue(slot.modes);
                        if (!string.IsNullOrWhiteSpace(mode.file) && !status[mode.file]) mode.file = null;
                    }

                    if (string.IsNullOrWhiteSpace(slot.currentMode)
                        && slot.modes.survival != null && string.IsNullOrWhiteSpace(slot.modes.survival.file))
                    {
                        slot.currentMode = "survival";
                    }
                }
                
                if (i == data.slotList.Count - 1) Save(completion_callback);
            }, files);
        }
    }

    public Mode GetModeData(int? slot = null, string mode = null)
    {
        if (slot.HasValue && !string.IsNullOrWhiteSpace(mode) && data.slotList.Count > slot)
        {
            if (data.slotList[slot.Value].modes == null) data.slotList[slot.Value].modes = new Modes();
            
            FieldInfo fieldInfo = typeof(Modes).GetField(mode);
            object value = fieldInfo.GetValue(data.slotList[slot.Value].modes);
            if (value == null)
            {
                value = new Mode();
                fieldInfo.SetValue(data.slotList[slot.Value].modes, value);
            }
            
            return (Mode)value;
        }

        return new Mode();
    }


    public void GetSaveDataForFile(string file, Action<SaveData> cb)
    {
        TheSim.GetPersistentString(file, (load_success, str) =>
        {
            Assert.IsTrue(load_success, $"SaveIndex:GetSaveData: Load failed for file [{file}] " +
                                        "please consider deleting this save slot and trying again.");
            
            Assert.IsNotNull(str, $"SaveIndex:GetSaveData: Encoded Savedata is NIL on load [{file}]");
            Assert.IsFalse(string.IsNullOrWhiteSpace(str),
                $"SaveIndex:GetSaveData: Encoded Savedata is empty on load [{file}]");

            SaveData savedata = JsonConvert.DeserializeObject<SaveData>(str);
            cb(savedata);
        });
    }

    public void GetSaveData(int slot, string mode, Action<SaveData> cb, bool ignoreslot = false)
    {
        if (!ignoreslot) current_slot = slot; //Added for backup stuff
        string file = GetModeData(slot, mode).file;
        
        GetSaveDataForFile(file, cb);
    }

    public object GetPlayerData(int? slot = null, string mode = null)
    {
        slot = slot.GetValueOrDefault(current_slot);
        return GetModeData(slot.Value, mode == null ? data.slotList[slot.Value].currentMode : mode)
            .playerdata;
    }
    
    
    private void print_flags(DLCSupport.DLCTable dlcFlags)
    {
        DebugPrint.print("REIGN_OF_GIANTS ", dlcFlags.REIGN_OF_GIANTS);
        DebugPrint.print("CAPY_DLC " + dlcFlags.CAPY_DLC);
        DebugPrint.print("PORKLAND_DLC " + dlcFlags.PORKLAND_DLC);
    }
    public DLCSupport.DLCTable VerifyDLCFlags(int? slot = null)
    {
        
        DLCSupport.DLCTable dlcFlags = data.slotList[slot.GetValueOrDefault(current_slot)].dlc;

        if (dlcFlags != null)
        {
            if (dlcFlags.PORKLAND_DLC && (dlcFlags.REIGN_OF_GIANTS || dlcFlags.CAPY_DLC))
            {
                DebugPrint.print($"SLOT DLC FLAG ERROR, FIXING SLOT", slot);

                dlcFlags.CAPY_DLC = false;
                dlcFlags.REIGN_OF_GIANTS = false;
                data.slotList[slot.GetValueOrDefault(current_slot)].dlc = dlcFlags;
                Save();

                print_flags(dlcFlags);
            }
            else if (dlcFlags.CAPY_DLC && dlcFlags.REIGN_OF_GIANTS)
            {
                DebugPrint.print("SLOT DLC FLAG ERROR, FIXING");

                dlcFlags.REIGN_OF_GIANTS = false;
                data.slotList[slot.GetValueOrDefault(current_slot)].dlc = dlcFlags;
                Save();

                print_flags(dlcFlags);
            }
        }

        return dlcFlags == null ? DLCSupport.NO_DLC_TABLE : dlcFlags;
    }
    
    public DLCSupport.DLCTable GetSlotDLC(int slot)
    {
        return VerifyDLCFlags(slot);
    }

    public void SetCurrentIndex(int saveslot)
    {
        current_slot = saveslot;
    }


    // called upon relaunch when a new level needs to be loaded
    private void onsavedatasaved(string filename, Action cb)
    {
        data.slotList[current_slot].continue_pending = false;
        string currentMode = data.slotList[current_slot].currentMode;
        Mode modeData = GetModeData(current_slot, currentMode);
        modeData.file = filename;
        if (modeData.files == null) modeData.files = new List<string>();
        modeData.day = 1;

        if (!modeData.files.Contains(filename)) modeData.files.Add(filename);
        
        
        
        Save(cb);
    }
    public void OnGenerateNewWorld(int saveslot, string savedata, Action cb)
    {
        current_slot = saveslot;
        string filename = GetSaveGameName(data.slotList[current_slot].currentMode, current_slot);
        
        TheSim.SetPersistentString(filename, savedata, Main.ENCODE_SAVES,
            () => onsavedatasaved(filename, cb));
    }


    public Slot GetOrCreateSlot(int saveslot)
    {
        if (data.slotList.Count <= saveslot)
        {
            for (int i = data.slotList.Count; i <= saveslot; i++) data.slotList.Add(new Slot());
        }
        
        return data.slotList[saveslot];
    }

    public string PickRandomCharacter()
    {
        List<string> characterList = DLCSupport.GetActiveCharacterList();
        if (characterList.Count == 0) return "wilson";
        return characterList[Random.Range(0, characterList.Count)];
    }
    
    // call after you have worldgen data to initialize a new survival save slot
    public void StartSurvivalMode(int saveslot, string character, CustomScreen.ChangedOption customOption,
        Action onsavedcb, DLCSupport.DLCTable dlc = null, string startWorldName = null)
    {
        current_slot = saveslot;
        Slot slot = GetOrCreateSlot(saveslot);

        if (character == "random") character = GameLogic.SaveGameIndex.PickRandomCharacter();

        slot.character = character;
        slot.currentMode = string.IsNullOrWhiteSpace(startWorldName) ? "survival" : startWorldName;
        slot.save_id = GenerateSaveID(current_slot);
        slot.dlc = dlc == null ? DLCSupport.NO_DLC_TABLE : dlc;
        slot.mods = ModManager.GetEnabledModNames();
        DebugPrint.print("SaveIndex:StartSurvivalMode!:",
            "ROG", slot.dlc.REIGN_OF_GIANTS, "SW", slot.dlc.CAPY_DLC, "HAM", slot.dlc.PORKLAND_DLC);

        slot.modes = new Modes();
        typeof(Modes).GetField(slot.currentMode).SetValue(slot.modes,
            new Mode{day = 1, world = 1, options = Util.deepcopy(customOption)});

        GameLogic.Profile.persistData.starts++;
        GameLogic.Profile.Save(_ => Save(onsavedcb));
    }
    
    public string GenerateSaveID(int slot)
    {
        DateTime startTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
        long timeStamp = (long)(DateTime.Now - startTime).TotalSeconds;
        return $"{TheSim.GetUserID()}-{timeStamp}-{slot}";
    }
    
    // The WORLD is the "depth" the player has traversed through the teleporters. 1, 2, 3, 4...
    // Contrast with the LEVEL, below.
    public int GetSlotWorld(int? slot = null)
    {
        slot = slot.GetValueOrDefault(current_slot);
        string currentMode = data.slotList[slot.Value].currentMode;
        Mode modeData = GetModeData(slot, currentMode);
        return modeData.world.GetValueOrDefault(1);
    }

    // The LEVEL is the index from levels.lua to load. This gets shuffled via the playlist.
    public int GetSlotLevelIndexFromPlaylist(int? slot = null)
    {
        slot = slot.GetValueOrDefault(current_slot);
        string currentMode = data.slotList[slot.Value].currentMode;
        Mode modeData = GetModeData(slot, currentMode);
        int world = modeData.world.GetValueOrDefault(1);
        if (modeData.playlist != null && world <= modeData.playlist.Count)
        {
            int level = modeData.playlist[world];
            return level;
        }
        else return world;
    }

    public bool HasWorld(int? slot = null, string mode = null)
    {
        slot = slot.GetValueOrDefault(current_slot);
        string current_mode =
            string.IsNullOrWhiteSpace(mode) ? data.slotList[slot.Value].currentMode : mode;
        Mode modeData = GetModeData(slot, current_mode);
        return !string.IsNullOrWhiteSpace(modeData.file);
    }

    public CustomScreen.ChangedOption GetSlotGenOptions(int? slot = null, object mode = null)
    {
        slot = slot.GetValueOrDefault(current_slot);
        string currentMode = data.slotList[slot.Value].currentMode;
        Mode modeData = GetModeData(slot, currentMode);
        return modeData.options;
    }

    public bool IsContinuePending(int? slot = null)
    {
        return data.slotList[slot.GetValueOrDefault(current_slot)].continue_pending;
    }
    
    public string GetCurrentMode(int? slot = null)
    {
        return data.slotList[slot.GetValueOrDefault(current_slot)].currentMode;
    }
    
    public int GetCurrentCaveLevel(int? slot = null, int? caveNum = null)
    {
        slot = slot.GetValueOrDefault(current_slot);
        Mode caveData = GetModeData(slot, "cave");
        caveNum = caveNum.GetValueOrDefault(caveData.currentCave.GetValueOrDefault(1));
        return caveData.currentLevel != null && caveData.currentLevel.ContainsKey(caveNum.Value)
            ? caveData.currentLevel[caveNum.Value] : 1;
    }
    
    public int GetCurrentCaveNum(int? slot = null)
    {
        slot = slot.GetValueOrDefault(current_slot);
        Mode caveData = GetModeData(slot, "cave");
        return caveData.currentCave.GetValueOrDefault(1);
    }

    #region
    
    public int GetSlotDay(int slot)
    {
        string currentMode = GameLogic.SaveGameIndex.GetCurrentMode(slot);
        Mode modeData = GetModeData(slot, currentMode);
        return modeData.day <= 0 ? 1 : modeData.day;
    }
    public string GetSlotCharacter(int slot)
    {
        string character = GameLogic.SaveGameIndex.data.slotList[slot == -1 ? current_slot : slot].character;
        List<string> activeCharacterList = DLCSupport.GetActiveCharacterList();
        if (!activeCharacterList.Contains(character)) character = "wilson";
        return character;
    }

    #endregion
}