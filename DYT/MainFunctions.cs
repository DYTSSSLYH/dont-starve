using System;
using System.Collections.Generic;
using DYT.Components;
using DYT.Screens;
using DYT.Widgets;
using Newtonsoft.Json;
using UnityEngine;
using Object = UnityEngine.Object;
using Screen = DYT.Widgets.Screen;

namespace DYT
{
    public class MainFunctions : MonoBehaviour
    {
        public GameObject theFrontEnd;
        public GameObject gameLogic;
        public GameObject scriptErrorScreen;
        public GameObject bugReportScreen;
        public GameObject bigPopupDialogScreen;
        
        public static Action<bool, string> PlayerPauseCheck;
        public static bool LOGSPAWNS = false; //Log all spawns
        public static bool CHECKSPAWNS = true; //Check what spawns stick at 0,0,0
        
        
        private void Start()
        {
            // The screen manager
            Main.TheFrontEnd = Instantiate(theFrontEnd).GetComponent<FrontEnd>();
            Instantiate(gameLogic).GetComponent<GameLogic>().Init();

            CheckControllers();
        }
        

        public static void SavePersistentString(string name, string data, bool encode,
            Action callback, bool local_save = false)
        {
            if (Main.TheFrontEnd != null) //TODO
            {
                TheSim.SetPersistentString(name, data, encode, callback, local_save);
            }
            else TheSim.SetPersistentString(name, data, encode, callback, local_save);
        }

        public static void Print(Constant.VERBOSITY msgVerbosity, params object[] objectArray)
        {
            if (msgVerbosity <= Main.VERBOSITY_LEVEL) DebugPrint.print(objectArray);
        }


        #region PREFABS AND ENTITY INSTANTIATION

        public static void RegisterPrefabs(GameObject prefab)
        {
            Main.Prefabs.Add(prefab.name, prefab);
        }

        public static Dictionary<string, GameObject> PREFABDEFINITIONS = new Dictionary<string, GameObject>();

        public static GameObject LoadPrefabFile(string filename)
        {
            string prefabName = filename.Substring(filename.LastIndexOf('/') + 1);
            GameObject prefab = Resources.Load<GameObject>($"{filename}/{prefabName}");
            Debug.Assert(prefab != null, $"Could not load file {filename}");
        
            RegisterPrefabs(prefab);
            PREFABDEFINITIONS.Add(prefabName, prefab);

            return prefab;
        }

        public static void RegisterAchievements(List<Achievement> achievements)
        {
            foreach (Achievement achievement in achievements)
            {
                // DebugPrint.Print
                //     ("Registering achievement:", achievement.name, achievement.id.steam, achievement.id.psn);
            
                // TODO: TheGameService
                //          :RegisterAchievement(achievement.name, achievement.id.steam, achievement.id.psn)
            }
        }
    
        public static void LoadAchievements()
        {
            RegisterAchievements(Achievements.achievementList);
        }

        public static EntityScript CreateEntity()
        {
            GameObject ent = new();
            int guid = ent.GetInstanceID();
            EntityScript scr = ent.AddComponent<EntityScript>().Init();
            Main.Ents.Add(guid, scr);
            Main.NumEnts++;
            return scr;
        }

        #endregion

        #region TIME FUNCTIONS

        public static float GetTickTime()
        {
            return 0.03f;
        }

        private static float ticktime = GetTickTime();
        public static float GetTime()
        {
            return Time.time * ticktime;
        }

        public static float GetTick()
        {
            return Time.time;
        }

        public static float GetTimeReal()
        {
            return Time.unscaledTime;
        }
    
        #endregion

        #region SCRIPTING
        #endregion

        #region

        private static bool paused = false;
        private static float default_time_scale = 1;

        public static void SetPause(bool val, string reason = null)
        {
            if (val == paused) return;

            if (val)
            {
                paused = true;
                Time.timeScale = 0;
                TheMixer.PushMix("pause");
            }
            else
            {
                paused = false;
                Time.timeScale = default_time_scale;
                TheMixer.PopMix("pause");
            }

            if (SimUtil.GetWorld())
            {
                SimUtil.GetWorld().BroadcastMessage("pause", val, SendMessageOptions.DontRequireReceiver);
            }
            PlayerPauseCheck?.Invoke(val, reason);
        }

        public static bool IsPaused()
        {
            return paused;
        }
    
        #endregion

        #region EXTERNALLY SET GAME SETTINGS

        public class Setting
        {
            public int? save_slot;
            public string reset_action;
            public string last_reset_action;
            public string current_asset_set;
            public string last_asset_set;
            public object playerevent;
            public string playeranim;
        }
        public static Setting Settings = new();

        public static List<string> Purchases = new();


        private void enableControllers()
        {
            // set all connected controllers as enabled in the player profile
            for (int i = 0; i < TheInputProxy.GetInputDeviceCount() - 1; i++)
            {
                if (TheInputProxy.IsInputDeviceConnected(i))
                {
                    PlayerProfile.Control savedControl = TheInputProxy.SaveControls(i);
                    if (savedControl != null)
                    {
                        GameLogic.Profile.SetControls(savedControl.guid, savedControl.data, savedControl.enabled);
                    }
                }
            }

            PlayerProfile.ShowedControllerPopup();
            // pop after updating settings otherwise this dialog might show again!
            Main.TheFrontEnd.PopScreen();
            GameLogic.Profile.Save();
            Scheduler.ExecuteInTime(0.05f, Check_Mods);
        }
        private void disableControllers()
        {
            TheInput.DisableAllControllers();
            PlayerProfile.ShowedControllerPopup();
            // pop after updating settings otherwise this dialog might show again!
            Main.TheFrontEnd.PopScreen();
            GameLogic.Profile.Save();
            Scheduler.ExecuteInTime(0.05f, Check_Mods);
        }
        public void CheckControllers()
        {
            bool isConnected = TheInput.ControllerConnected();
            bool sawPopup = PlayerProfile.SawControllerPopup();
            if (isConnected && !sawPopup)
            {
                // store previous controller enabled state so we can revert to it,
                // then enable all controllers
                List<bool> controllers = new();
                int numControllers = TheInputProxy.GetInputDeviceCount();
                for (int i = 0; i < numControllers - 1; i++)
                {
                    bool enabled = TheInputProxy.IsInputDeviceEnabled(i);
                    controllers.Add(enabled);
                }

                // enable all controllers so they can be used in the popup if desired
                TheInput.EnableAllControllers();

                BigPopupDialogScreen popup = Instantiate(bigPopupDialogScreen)
                    .GetComponent<BigPopupDialogScreen>().Init("检测到游戏手柄",
                        "你希望使用游戏手柄来玩《饥荒》吗？\n\n我们不会再次问你这个问题，" +
                        "不过如果你改变主意了，可以在控制屏幕上更改这一设置。", new List<Menu.MenuItem>
                        {
                            new(){text = "启用游戏手柄", cb = enableControllers},
                            new(){text = "禁用游戏手柄", cb = disableControllers}
                        });
                foreach (Widget widget in popup.menu.items)
                {
                    ImageButton menuItem = (ImageButton)widget;
                    menuItem.text.SetSize(33);
                }
                Main.TheFrontEnd.PushScreen(popup);
            }
            else Check_Mods();
        }

        public void Check_Mods()
        {
            if (Main.MODS_ENABLED)
            {
                // after starting everything up, give the mods additional environment variables
                ModManager.SetPostEnv();
            
                // By this point the game should have either a) disabled bad mods, or b) be interactive
                // no callback, this doesn't need to block and we don't need the results
                KnownModIndex.EndStartupSequence(null);
            }
        
            // If we collected a non-fatal error during startup, display it now!
            foreach (string error in PendingErrors) DisplayError(error);
        }
    
        #endregion

        #region
    
        public static bool exitingGame = false;

        // Gets called ONCE when the sim first gets created.
        // Does not get called on subsequent sim recreations!
        public static void GlobalInit()
        {
            TheSim.LoadPrefabs("Global");
        
            // LoadFonts()
            // if PLATFORM == "PS4" then
            //     PreloadSounds()
            // end
            // TheSim:SendHardwareStats()
        }

        public static void StartNextInstance(Setting in_params = null, bool send_stats = false)
        {
            Setting parameters = in_params == null ? new Setting() : in_params;
            parameters.last_reset_action = Settings.reset_action;
        
            if (send_stats) Stats.SendAccumulatedProfileStats();

            if (GameLogic.LOADED_CHARACTER != null)
            {
                // TODO
            }
        
            SimReset(parameters);
        }

        public static void SimReset(Setting instanceparameters = null)
        {
            ModManager.UnloadPrefabs();

            if (instanceparameters == null) instanceparameters = new Setting();
            instanceparameters.last_asset_set = Settings.current_asset_set;
            TheSim.SetInstanceParameters(JsonConvert.SerializeObject(instanceparameters));
            if (SimUtil.GetWorld())
            {
                SimUtil.GetWorld().GetComponent<AmbientSoundMixer>().ClearReverbOverride();
            }
            TheSim.SetReverbPreset("default");
            TheSim.ResetSim();
        }
    
        private static void Shutdown()
        {
            Debug.Log("Ending the sim now!");
        }

        public static void RequestShutdown()
        {
            if (exitingGame) return;

            exitingGame = true;

            Main.TheFrontEnd.PushScreen(
                Object.Instantiate(Resources.Load<GameObject>("UI/ExitScreen")).GetComponent<Screen>());

            Dictionary<string, object> profileStats = WorldGenerateMain.GetProfileStats();

            Shutdown();
        }
    
        public static List<string> PendingErrors = new();

        public void DisplayError(string error)
        {
            if (!Main.TheFrontEnd)
            {
                DebugPrint.print(
                    "Error error! We tried displaying an error but TheFrontEnd isn't ready yet...");
                PendingErrors.Add(error);
                return;
            }

            SetPause(true, "DisplayError");
            if (Main.TheFrontEnd.IsDisplayingError()) return;
        
            DebugPrint.print(error); //Failsafe since sometimes the error screen is no shown

            List<string> modNames = ModManager.GetEnabledModNames();

            if (modNames.Count > 0)
            {
                string modnamesstr = "";
                foreach (string modName in modNames)
                {
                    modnamesstr += $"\"{KnownModIndex.GetModFancyName(modName)}\" ";
                }

                ScriptErrorScreen errorScreen = Instantiate(scriptErrorScreen)
                    .GetComponent<ScriptErrorScreen>().Init("警告！", error, new List<Menu.MenuItem>
                        {
                            new(){text = "退出游戏", cb = TheSim.ForceAbort},
                            new(){text = "禁用模组", cb = () =>
                            {
                                KnownModIndex.DisableAllMods();
                                KnownModIndex.Save(() => SimReset());
                            }},
                            new(){text = "模组论坛", nopop = true, cb = () => Main.VisitURL(
                                "http://forums.kleientertainment.com/index.php" +
                                "?/forum/26-dont-starve-mods-and-tools/")}
                        }, Constant.ANCHOR_LEFT,
                        $"此错误可能是由于你启用的某个模组所致！\n你启用了下列模组：\n{modnamesstr}", 20);
                if (Main.ENABLE_BUG_REPORTER)
                {
                    errorScreen.menu.AddItem(
                        "报告漏洞",
                        () => Main.TheFrontEnd.PushScreen(
                            Object.Instantiate(bugReportScreen).GetComponent<BugReportScreen>().Init(),
                            true
                        ),
                        null
                    );
                }
                Main.TheFrontEnd.DisplayError(errorScreen);
            }
            else
            {
                ScriptErrorScreen errorScreen = Object.Instantiate(scriptErrorScreen)
                    .GetComponent<ScriptErrorScreen>().Init("警告！", error, new List<Menu.MenuItem>
                    {
                        new(){text = "退出游戏", cb = TheSim.ForceAbort},
                        new(){text = "模组论坛", nopop = true, cb = () => Main.VisitURL(
                            "http://forums.kleientertainment.com/index.php" +
                            "?/forum/26-dont-starve-mods-and-tools/")}
                    }, Constant.ANCHOR_LEFT, null, 20);
                if (Main.ENABLE_BUG_REPORTER)
                {
                    errorScreen.menu.AddItem(
                        "报告漏洞",
                        () => Main.TheFrontEnd.PushScreen(
                            Object.Instantiate(bugReportScreen).GetComponent<BugReportScreen>().Init(),
                            true
                        ),
                        null
                    );
                }
                Main.TheFrontEnd.DisplayError(errorScreen);
            }
        }

        #endregion
    }
}