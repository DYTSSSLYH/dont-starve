using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace DYT
{
    public class Main : MonoBehaviour
    {
        public GameObject scriptErrorScreen;
    
        public static string packagePath = Application.dataPath + "/";
        public static string PLATFORM = "WIN32_STEAM";
        public static string BRANCH = "release";
        public static string CONFIGURATION = "PRODUCTION";
        public static string APP_REGION = "NONE";
        public static bool RUN_GLOBAL_INIT = true;
        public static string APP_VERSION;

        // defines
        public static int MAIN = 1;
        public static bool ENCODE_SAVES = BRANCH != "dev";
        public static bool SOUNDDEBUG_ENABLED = false;
        public static bool MODS_ENABLED = PLATFORM != "PS4" && PLATFORM != "NACL";
        public static bool ACCOMPLISHMENTS_ENABLED = PLATFORM == "PS4";
        public static bool CHEATS_ENABLED =
            BRANCH == "dev" || (PLATFORM == "PS4" && CONFIGURATION != "PRODUCTION");
        public static bool DEBUG_MENU_ENABLED =
            BRANCH == "dev" || (PLATFORM == "PS4" && CONFIGURATION != "PRODUCTION");

        public static bool POT_GENERATION = false;
        public static bool CONSOLE_ENABLED = true;
        public static bool SHOWLOG_ENABLED = true;
        public static bool DEBUGRENDER_ENABLED = true;
        public static bool SKIP_MAXWELL_INTRO = false;
        // Notes(DW): Override the variable pushed by the engine.
        public static bool ENABLE_BUG_REPORTER = false;
    
        public static bool USE_SEASON_DSP = true;
    
        public static int MEM_TRACKING_INTERVAL = 5*60;
    
        public static bool ExecutingLongUpdate = false;
        public static bool ExecutingCaveCatchup = false;
    
        public static bool EARLYACCESS_ON = false;
    
        // return false
        public static bool IsConsole()
        {
            return (PLATFORM == "PS4") || (PLATFORM == "XBONE");
        }
        public static bool IsNotConsole()
        {
            return !IsConsole();
        }
    
        public static bool IsSteam()
        {
            return PLATFORM == "WIN32_STEAM" || PLATFORM == "LINUX_STEAM" || PLATFORM == "OSX_STEAM";
        }
    
        public static bool IsRail()
        {
            return PLATFORM == "WIN32_RAIL";
        }
    
        public static bool DEBUGGER_ENABLED = IsNotConsole() && CONFIGURATION != "PRODUCTION";

        private static Dictionary<string, string> servers = new()
        {
            {"release", "https://dontstarve-release.appspot.com"},
            {"dev", "https://dontstarve-dev.appspot.com"},
            {"staging", "https://dontstarve-staging.appspot.com"}
        };
        public static string GAME_SERVER = servers.ContainsKey(BRANCH) ? servers[BRANCH] : servers["release"];
    
        public static void VisitURL(string url, bool notrack = false)
        {
            Debug.Log(notrack ? $"VisitURLNoTrack:{url}" : $"VisitURL:{url}");
        }

        // used for A/B testing and preview features. Gets serialized into and out of save games
        public static object GameplayOptions = new object();
    
    
        public static object RequiredFilesForReload = new object();

        public static void loadfile(string filename){}
    
        public static Constant.VERBOSITY VERBOSITY_LEVEL = Constant.VERBOSITY.ERROR;

        private static bool user_metrics_option = PlayerProfile.GetAgreementsSetting();
        public static bool METRICS_ENABLED = (PLATFORM != "PS4") && user_metrics_option;


        public static Dictionary<string, GameObject> Prefabs = new();
        public static Dictionary<int, EntityScript> Ents = new();
        public static object AwakeEnts = new object();
        public static object UpdatingEnts = new object();
        public static object NewUpdatingEnts = new object();
        public static object StopUpdatingEnts = new object();
    
        public static object StopUpdatingComponents = new object();
    
        public static object WallUpdatingEnts = new object();
        public static Dictionary<int, EntityScript> NewWallUpdatingEnts = new();
        public static int num_updating_ents = 0;
        public static int NumEnts = 0;
    
    
        public static EntityScript TheGlobalInstance = null;
    
        public static FollowCamera TheCamera = null;
        public static object SplatManager = null;
        public static object ShadowManager = null;
        public static object RoadManager = null;
        public static object EnvelopeManager = null;
        public static object PostProcessor = null;
    
        public static object FontManager = null;
        public static object MapLayerManager = null;
        // TODO: Ask Jason about how safe this is later, regarding non-Porkland builds.
        public static object InteriorManager = null;
        public static object Roads = null;
        public static FrontEnd TheFrontEnd = null;
    
        public static bool inGamePlay = false;

        private static void ModSafeStartup()
        {
            // If we failed to boot last time, disable all mods
            // Otherwise, set a flag file to test for boot success.
        
            // PREFABS AND ENTITY INSTANTIATION
        
            ModManager.LoadMods();
        
            // Apply translations
            LanguageTranslator.TranslateStringTable();
        
            // Register every standard prefab with the engine
        
            // This one needs to be active from the get-go.
            MainFunctions.LoadPrefabFile("Prefabs/Global");
            MainFunctions.LoadAchievements();

            TheCamera = new FollowCamera();

            #region GLOBAL ENTITY

            TheGlobalInstance = MainFunctions.CreateEntity();
            DontDestroyOnLoad(TheGlobalInstance.entity);
            TheGlobalInstance.AddTag("NOBLOCK");

            #endregion
        
            if (RUN_GLOBAL_INIT) MainFunctions.GlobalInit();
        
            // TODO
            // SplatManager = TheGlobalInstance.entity:AddSplatManager() //雨滴声
            // ShadowManager = TheGlobalInstance.entity:AddShadowManager()
            // ShadowManager:SetTexture( "images/shadow.tex" ) //人物脚下阴影
            // RoadManager = TheGlobalInstance.entity:AddRoadManager() //岩石路等
            // EnvelopeManager = TheGlobalInstance.entity:AddEnvelopeManager() //未知
        
            // PostProcessor = TheGlobalInstance.entity:AddPostProcessor() //后处理器
            // local IDENTITY_COLOURCUBE = "images/colour_cubes/identity_colourcube.tex"
            // PostProcessor:SetColourCubeData( 0, IDENTITY_COLOURCUBE, IDENTITY_COLOURCUBE )
            // PostProcessor:SetColourCubeData( 1, IDENTITY_COLOURCUBE, IDENTITY_COLOURCUBE )
            // PostProcessor:SetBlurEnabled(false)
            // FontManager = TheGlobalInstance.entity:AddFontManager() //字体管理器
        
            // Ask Jason about this later to see if this is safe for non-Porkland builds.
            // InteriorManager = TheGlobalInstance.entity:AddInteriorManager()
            // MapLayerManager = TheGlobalInstance.entity:AddMapLayerManager() //小地图相关
        }


    
        private void Awake()
        {
            APP_VERSION = Application.version;
        }

        private void Start1()
        {
            TheConfig.Init();
        
            // true to indicate minimal load required for language.lua to read the profile.
            PlayerProfile.Load(null, true);
        
            Language.Init();
        
            Strings.Init();
        
            Actions.Init();
        
            Recipes.Init();
        
            TheInput.Init();
        
            if (METRICS_ENABLED) Overseer.Init();
        
            FontsDefault.Init();
        
            WorldTileDefs.Init();
        
            if (TheConfig.IsEnabled("force_netbookmode")){}
        
            Debug.Log("running main.lua\n");
        
            // uncomment this line to override
            VERBOSITY_LEVEL = Constant.VERBOSITY.WARNING;

            float SEED = TheSim.GetRealTime();
            DebugPrint.print("Sim Seed = ", SEED);
            // math.randomseed(SEED)
        
            // instantiate the mixer
            Mixes.Init();
            // TheMixer.PushMix("start");

            if (!MODS_ENABLED) ModSafeStartup();
            else KnownModIndex.Load(() => KnownModIndex.BeginStartupSequence(ModSafeStartup));

            ModManager.scriptErrorScreen = scriptErrorScreen;
        }
    }
}