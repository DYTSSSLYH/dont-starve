using System;
using System.Collections;
using System.Collections.Generic;
using DYT.Map;
using DYT.Screens;
using DYT.Widgets;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Assertions;

namespace DYT
{
    public class GameLogic : MonoBehaviour
    {
        public GameObject broadcastingWidget;
        public GameObject loadingWidget;
        public GameObject mainScreen;
        public WorldGenScreen worldGenScreen;
        
        public static bool PRINT_TEXTURE_INFO = false;
        public static BroadcastingWidget global_broadcastnig_widget;
        public static LoadingWidget global_loading_widget;
        public static object LOADED_CHARACTER;
        public static bool STATS_ENABLE;
        
        private bool LOAD_UPFRONT_MODE = false;
        
        
        private IEnumerator KeepAlive()
        {
            if (global_loading_widget && global_loading_widget.is_enabled)
            {
                global_loading_widget.ShowNextFrame();
                yield return new WaitForEndOfFrame();
                global_loading_widget.ShowNextFrame();
            }
        }

        private void ShowLoading()
        {
            if (global_loading_widget) global_loading_widget.SetEnabled(true);
        }

        private void AddToRecipePrefabs(Dictionary<string, Recipe> recipes, List<string> RECIPE_PREFABS)
        {
            foreach (Recipe recipe in recipes.Values)
            {
                RECIPE_PREFABS.Add(recipe.name);
                if (!string.IsNullOrWhiteSpace(recipe.placer)) RECIPE_PREFABS.Add(recipe.placer);
            }
        }

        private void LoadAssets(string asset_set)
        {
            if (LOAD_UPFRONT_MODE) return;
            
            // The Adventure Mode needs to show a title instead of background images.
            if (SaveGameIndex.GetCurrentMode() != "adventure") ShowLoading();
            
            Assert.IsNotNull(asset_set);
            MainFunctions.Settings.current_asset_set = asset_set;

            Constant.RECIPE_PREFABS = new List<string>();
            
            AddToRecipePrefabs(Recipe.Common_Recipes, Constant.RECIPE_PREFABS);
            AddToRecipePrefabs(Recipe.Vanilla_Recipes, Constant.RECIPE_PREFABS);
            AddToRecipePrefabs(Recipe.RoG_Recipes, Constant.RECIPE_PREFABS);
            AddToRecipePrefabs(Recipe.Shipwrecked_Recipes, Constant.RECIPE_PREFABS);
            AddToRecipePrefabs(Recipe.Porkland_Recipes, Constant.RECIPE_PREFABS);
            
            StartCoroutine(KeepAlive());
            
            if (MainFunctions.Settings.current_asset_set == "FRONTEND")
            {
                if (MainFunctions.Settings.last_reset_action == "FRONTEND")
                {
                    DebugPrint.print("\tFE assets already loaded");
                    DLCSupport.RegisterAllDLC();
                    foreach (string file in PrefabList.PREFABFILES)
                    {
                        MainFunctions.LoadPrefabFile($"Prefabs/{file}");
                    }
                    ModManager.RegisterPrefabs();
                }
                else
                {
                    Debug.Log("\tUnload BE");
                    TheSim.UnloadPrefabs(Constant.RECIPE_PREFABS);
                    TheSim.UnloadPrefabs(Constant.BACKEND_PREFABS);
                    Debug.Log("\tUnload BE done");
                    StartCoroutine(KeepAlive());
                    
                    DLCSupport.RegisterAllDLC();
                    foreach (string file in PrefabList.PREFABFILES)
                    {
                        MainFunctions.LoadPrefabFile($"Prefabs/{file}");
                    }
                    ModManager.RegisterPrefabs();
                    StartCoroutine(KeepAlive());
                    Debug.Log("\tLoad FE");
                    TheSim.LoadPrefabs(Constant.FRONTEND_PREFABS);
                    Debug.Log("\tLoad FE: done");
                    StartCoroutine(KeepAlive());
                }
            }
            else
            {
                if (MainFunctions.Settings.last_asset_set == "BACKEND")
                {
                    DebugPrint.print("\tBE assets already loaded");
                    DLCSupport.RegisterAllDLC();
                    foreach (string file in PrefabList.PREFABFILES)
                    {
                        MainFunctions.LoadPrefabFile($"Prefabs/{file}");
                    }
                    ModManager.RegisterPrefabs();
                }
                else
                {
                    DebugPrint.print("\tUnload FE");
                    TheSim.UnloadPrefabs(Constant.FRONTEND_PREFABS);
                    DebugPrint.print("\tUnload FE done");
                    StartCoroutine(KeepAlive());
                    
                    DLCSupport.RegisterAllDLC();
                    foreach (string file in PrefabList.PREFABFILES)
                    {
                        MainFunctions.LoadPrefabFile($"Prefabs/{file}");
                    }
                    DLCSupport.InitAllDLC();
                    ModManager.RegisterPrefabs();
                    StartCoroutine(KeepAlive());
                    
                    DebugPrint.print("\tLoad BE");
                    TheSim.LoadPrefabs(Constant.BACKEND_PREFABS);
                    StartCoroutine(KeepAlive());
                    TheSim.LoadPrefabs(PrefabList.PREFABFILES);
                    Debug.Log("\tLoad BE: done");
                    StartCoroutine(KeepAlive());
                }
            }

            MainFunctions.Settings.last_reset_action = MainFunctions.Settings.current_asset_set;
        }


        // OK, we have our savedata and a profile. Instatiate everything and start the game!
        public static void DoInitGame(string playercharacter, SaveIndex.SaveData savedata,
            PlayerProfile profile, object next_world_playerdata, object fast, object playerevent)
        {
            bool was_file_load = MainFunctions.Settings.playeranim == "file_load";
            
            Main.TheFrontEnd.ClearScreens();
            
            Assert.IsNotNull(savedata.map, "Map missing from savedata on load");
            Assert.IsNotNull(savedata.map.prefab, "Map prefab missing from savedata on load");
            Assert.IsNotNull(savedata.map.tiles, "Map tiles missing from savedata on load");
            Assert.IsNotNull(savedata.map.width, "Map width missing from savedata on load");
            Assert.IsNotNull(savedata.map.height, "Map height missing from savedata on load");
            
            Assert.IsNotNull(savedata.map.topology, "Map topology missing from savedata on load");
            Assert.IsNotNull(savedata.map.topology.colours,
                "Topology entity colours are missing from savedata on load");
            Assert.IsNotNull(savedata.map.topology.edges, "Topology edges are missing from savedata on load");
            Assert.IsNotNull(savedata.map.topology.nodes, "Topology nodes are missing from savedata on load");
            Assert.IsNotNull(savedata.map.topology.level_type,
                "Topology level type is missing from savedata on load");
            Assert.IsNotNull(savedata.map.topology.overrides,
                "Topology overrides is missing from savedata on load");
            
            Assert.IsNotNull(savedata.playerinfo, "Playerinfo missing from savedata on load");
            Assert.IsNotNull(savedata.playerinfo.x, "Playerinfo.x missing from savedata on load");
            Assert.IsNotNull(savedata.playerinfo.z, "Playerinfo.z missing from savedata on load");
            
            Assert.IsNotNull(savedata.ents, "Entites missing from savedata on load");

            if (savedata.map.roads != null)
            {
                Main.Roads = savedata.map.roads;
            }
        }

        
        #region THESE FUNCTIONS HANDLE STARTUP FLOW

        private void onload(SaveIndex.SaveData savedata, int saveslot,
            object playerdataoverride, object playerevent)
        {
            DoInitGame(SaveGameIndex.GetSlotCharacter(saveslot), savedata, Profile,
                playerdataoverride, null, playerevent);
        }
        private void DoLoadWorld(int saveslot, object playerdataoverride, object playerevent)
        {
            SaveGameIndex.GetSaveData(saveslot, SaveGameIndex.GetCurrentMode(saveslot),
                savedData => onload(savedData, saveslot, playerdataoverride, playerevent));
        }

        public class WorldGenOptions
        {
            public string level_type;
            public CustomScreen.ChangedOption custom_options;
            public int level_world;
            public PlayerProfile.Data profiledata;
            public int? adventure_progress;
            public int cave_progress;
        }
        private void onsaved(int saveslot, string savedata, object playerevent)
        {
            SaveIndex.SaveData world_table = JsonConvert.DeserializeObject<SaveIndex.SaveData>(savedata);
            LoadAssets("BACKEND");
            DoInitGame(SaveGameIndex.GetSlotCharacter(saveslot), world_table, Profile,
                SaveGameIndex.GetPlayerData(), null, playerevent);
        }
        private void onComplete(string savedata, int saveslot, object playerevent)
        {
            Assert.IsNotNull(savedata, "DoGenerateWorld: Savedata is NIL on load");
            Assert.IsTrue(savedata.Length > 0, "DoGenerateWorld: Savedata is empty on load");

            if (savedata.StartsWith("error"))
            {
                // TODO
                DebugPrint.print("Worldgen had an error, displaying...");
            }
            else
            {
                SaveGameIndex.OnGenerateNewWorld(saveslot, savedata,
                    () => onsaved(saveslot, savedata, playerevent));
            }
        }
        private void DoGenerateWorld(int saveslot, string type_override, object playerevent)
        {
            WorldGenOptions worldGenOptions = new()
            {
                level_type = string.IsNullOrWhiteSpace(type_override)
                    ? SaveGameIndex.GetCurrentMode(saveslot) : type_override,
                custom_options = SaveGameIndex.GetSlotGenOptions(saveslot, SaveGameIndex.GetCurrentMode()),
                level_world = SaveGameIndex.GetSlotLevelIndexFromPlaylist(saveslot),
                profiledata = Profile.persistData,
            };

            if (worldGenOptions.level_type == "adventure")
            {
                worldGenOptions.adventure_progress = SaveGameIndex.GetSlotWorld(saveslot);
            }
            else if (worldGenOptions.level_type == "cave")
            {
                worldGenOptions.cave_progress = SaveGameIndex.GetCurrentCaveLevel();
            }

            Main.TheFrontEnd.PushScreen(worldGenScreen.Init(
                Profile, savedata => onComplete(savedata, saveslot, playerevent), worldGenOptions));
        }

        private int? ShouldSkipMainScreen()
        {
            string slotNumString = TheSim.GetSetting("misc", "skip_to_slot");

            if (!string.IsNullOrWhiteSpace(slotNumString))
            {
                int slotnum = Convert.ToInt32(slotNumString);
                if (slotnum < 1 || slotnum > 5) return null;
                return slotnum;
            }
            return null;
        }

        private void SkipMainScreen(int slotnum)
        {
            // TODO
        }

        private void MainScreenFlow()
        {
            int? skip_slot = ShouldSkipMainScreen();
            if (skip_slot.HasValue &&
                MainFunctions.Settings.last_reset_action != Constant.RESET_ACTION.LOAD_SLOT.ToString())
            {
                SkipMainScreen(skip_slot.Value);
            }
            else
            {
                LoadAssets("FRONTEND");
                MainScreen screen = Instantiate(mainScreen).GetComponent<MainScreen>();
                screen.Start();
                Main.TheFrontEnd.ShowScreen(screen);
            }
        }

        private void LoadSlot(int slot, object playerevent)
        {
            Main.TheFrontEnd.ClearScreens();
            DebugPrint.print($"Loading slot {slot}");
            if (SaveGameIndex.HasWorld(slot, SaveGameIndex.GetCurrentMode(slot)))
            {
                DebugPrint.print("Load Slot: Has World");
                SaveGameIndex.SetCurrentIndex(slot);
                LoadAssets("BACKEND");
                DoLoadWorld(slot,
                    SaveGameIndex.GetModeData(slot, SaveGameIndex.GetCurrentMode(slot)).playerdata, playerevent);
            }
            else
            {
                DebugPrint.print("Load Slot: Has no World");
                if ((SaveGameIndex.GetCurrentMode(slot) == "survival" ||
                     SaveGameIndex.GetCurrentMode(slot) == "survival" ||
                     SaveGameIndex.GetCurrentMode(slot) == "survival")
                    && SaveGameIndex.IsContinuePending(slot))
                {
                }
                else
                {
                    DebugPrint.print("Load Slot: ... generating new world");
                    DoGenerateWorld(slot, null, playerevent);
                }
            }
        }

        #endregion
        
        
        #region LOAD THE PROFILE AND THE SAVE INDEX, AND START THE FRONTEND

        private void DoResetAction()
        {
            // TODO
            if (LOAD_UPFRONT_MODE)
            {
            }

            if (!string.IsNullOrWhiteSpace(MainFunctions.Settings.reset_action))
            {
                if (MainFunctions.Settings.reset_action == Constant.RESET_ACTION.DO_DEMO)
                {
                    
                }
                else if (MainFunctions.Settings.reset_action == Constant.RESET_ACTION.LOAD_SLOT)
                {
                    if (string.IsNullOrWhiteSpace(
                            SaveGameIndex.GetCurrentMode(MainFunctions.Settings.save_slot)))
                    {
                        LoadAssets("FRONTEND");
                        MainScreen screen = Instantiate(mainScreen).GetComponent<MainScreen>();
                        screen.Start();
                        Main.TheFrontEnd.ShowScreen(screen);
                    }
                    else LoadSlot(MainFunctions.Settings.save_slot.Value, MainFunctions.Settings.playerevent);
                }
                else if (MainFunctions.Settings.reset_action == "printtextureinfo")
                {
                    
                }
                else
                {
                    
                }
            }
            else
            {
                if (PRINT_TEXTURE_INFO)
                {
                }
                else MainScreenFlow();
            }
        }
        
        private void OnUpdatePurchaseStateComplete()
        {
            Debug.Log("OnUpdatePurchaseStateComplete");
            
            DoResetAction();
        }
        
        private void OnFilesLoaded()
        {
            Debug.Log("OnFilesLoaded()");
            Upsell.UpdateGamePurchasedState(b => OnUpdatePurchaseStateComplete());
        }

        public static PlayerProfile Profile = new();
        public static readonly SaveIndex SaveGameIndex = new();

        #endregion
        
        
        public void Init()
        {
            TreasureHunt.Init();
            
            // Always on broadcasting widget
            if (Main.PLATFORM == "WIN32_STEAM" || Main.PLATFORM == "WIN32")
            {
                global_broadcastnig_widget = Instantiate(broadcastingWidget).GetComponent<BroadcastingWidget>();
            }
            
            global_loading_widget = Instantiate(loadingWidget).GetComponent<LoadingWidget>();
            global_loading_widget.Awake();
            
            
            MainFunctions.Print(Constant.VERBOSITY.DEBUG, "[Loading frontend assets]");

            LOADED_CHARACTER = null;

            #region LOAD THE PROFILE AND THE SAVE INDEX, AND START THE FRONTEND

            STATS_ENABLE = Main.METRICS_ENABLED;
            
            MainFunctions.Print(Constant.VERBOSITY.DEBUG, "[Loading Morgue]");
            Morgue.Load(did_it_load => {});
            
            MainFunctions.Print(Constant.VERBOSITY.DEBUG, "[Loading profile and save index]");
            PlayerProfile.Load(b => SaveGameIndex.Load(OnFilesLoaded));
            
            // dont_load_save in profile

            #endregion
        }
    }
}