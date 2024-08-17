using System;
using System.Collections.Generic;
using System.Reflection;
using DYT;
using DYT.Screens;
using DYT.Widgets;
using UnityEngine;
using Object = UnityEngine.Object;

public class ModManager
{
    public static GameObject scriptErrorScreen;
    public static int MOD_API_VERSION = 6;
    
    private static List<string> modnames = new();
    public class PostInitFns
    {
        public Dictionary<string, List<ParamObjectArrayHandler>> ComponentPostInit;
        public List<ParamObjectArrayHandler> GamePostInit;
    }
    public class Environment
    {
        public string modname;
        public string MODROOT;
        public List<KnownModIndex.Config> MODCONFIG;
        public Func<string, Func<string, object>> GetModConfigData;
        public List<string> CHARACTERLIST;
        public Action<string> modimport;
        public KnownModIndex.ModInfo modinfo;

        #region PostInit

        public PostInitFns postinitfns;
        public Action<ParamObjectArrayHandler> AddGamePostInit;
        public Action<string, ParamObjectArrayHandler> AddComponentPostInit;

        #endregion

        public Func<string, GameObject> LoadPrefabFile;
        public Action<GameObject> RegisterPrefabs;
        public Dictionary<string, Prefab> Prefabs;
        public List<string> PrefabFiles;
        public FrontEnd TheFrontEnd;
        public EntityScript TheGlobalInstance;
    }
    private static List<Environment> mods = new();
    private static List<object> records = new();
    private static List<object> recordsfailedmods = new();
    private static List<string> enabledmods = new();
    private static List<string> loadedprefabs = new();

    private static bool worldgen;
    private class FailedMod
    {
        public string name;
        public string error;
    }
    private static List<FailedMod> failedmods = new();
    
    
    private static void modprint(params object[] objects){}

    public delegate void ParamObjectArrayHandler(params object[] objects);
    private static ParamObjectArrayHandler runmodfn(ParamObjectArrayHandler fn,
        Environment mod, string modtype)
    {
        return objects => fn?.Invoke(objects);
    }
    

    public static List<string> GetEnabledModNames()
    {
        return enabledmods;
    }

    public static Environment GetMod(string modname)
    {
        return mods.Find(mod => mod.modname == modname);
    }
    
    public static Environment CreateEnvironment(string modname, bool isworldgen)
    {
        Environment env = new()
        {
            modname = modname,
            MODROOT = $"Mods/{modname}/",
            // Direct access to the mod config table
            // (WARNING: modifying it directly while the game is running could result in weird behavior)
            MODCONFIG = KnownModIndex.GetModConfigurationOptions(modname),
            // Call is GetModConfigData(optionname) to fetch saved value of the specified option
            // (name must match name field in config options table)
            GetModConfigData = ModUtil.GetModConfigDataFn
        };

        if (!isworldgen) env.CHARACTERLIST = DLCSupport.GetActiveCharacterList();

        // install our crazy loader!
        env.modimport = modulename =>
        {
            Debug.Log($"modimport: {env.MODROOT}{modulename}");
        };
        
        ModUtil.InsertPostInitFunctions(env);

        return env;
    }
    
    public static void LoadMods(bool worldGenParam = false)
    {
        if (!Main.MODS_ENABLED) return;

        worldgen = worldGenParam;
        
        if (!worldgen) KnownModIndex.UpdateModInfo();
        List<string> moddirs = KnownModIndex.GetModsToLoad(worldgen);
        
        foreach (string modname in moddirs)
        {
            if (worldgen == false || (worldgen == true && KnownModIndex.IsModCompatibleWithMode(modname)))
            {
                modnames.Add(modname);

                // Make sure we load the config data before the mod (but not during worldgen)
                if (worldgen == false) KnownModIndex.LoadModConfigurationOptions(modname);

                KnownModIndex.ModInfo initenv = KnownModIndex.GetModInfo(modname);
                Environment env = CreateEnvironment(modname, worldgen);
                env.modinfo = initenv;
                
                mods.Add(env);
                string loadmsg = $"Loading mod: {ModUtil.ModInfoname(modname)}";
                if (!string.IsNullOrWhiteSpace(initenv.modinfo_message))
                    loadmsg += $" ({initenv.modinfo_message})";
                Debug.Log(loadmsg);
            }
        }
        
        // Sort the mods by priority, so that "library" mods can load first
        mods.Sort((a, b) =>
        {
            int apriority = a.modinfo == null ? 0 : a.modinfo.priority;
            int bpriority = b.modinfo == null ? 0 : b.modinfo.priority;
            return apriority - bpriority;
        });
        
        foreach (Environment mod in mods)
        {
            enabledmods.Add(mod.modname);
            InitializeModMain(mod.modname, mod, "ModWorldGenMain");
            if (!worldgen)
            {
                // worldgen has to always run (for customization screen)
                // but modmain can be skipped for worldgen.
                // This reduces a lot of issues with missing globals.
                InitializeModMain(mod.modname, mod, "ModMain");
            }
        }
    }

    public static void InitializeModMain(string modname, Environment env, string mainfile)
    {
        if (!KnownModIndex.IsModCompatibleWithMode(modname)) return;
        
        DebugPrint.Print($"Mod: {ModUtil.ModInfoname(modname)}", $"Loading {mainfile}");

        GameObject.Instantiate(Resources.Load<GameObject>($"Mods/{modname}/{mainfile}"));
    }

    public static void DisplayBadMods()
    {
        if (worldgen)
        {
            // we can't save or show errors from worldgen! Up to the main game to display the error.
            foreach (FailedMod badmod in failedmods) Debug.LogError(badmod.error);
            return;
        }
        
        
        // If the frontend isn't ready yet, just hold onto this until we can display it.

        if (failedmods.Count > 0)
        {
            foreach (FailedMod failedMod in failedmods)
            {
                KnownModIndex.DisableBecauseBad(failedMod.name);
                GetMod(failedMod.name).modinfo.failed = true;
                DebugPrint.Print(
                    $"Disabling {ModUtil.ModInfoname(failedMod.name)} because it had an error."
                );
            }
        }
        // There are several flows which may have disabled mods;
        // now is a safe place to save those changes.
        KnownModIndex.Save();

        if (Main.TheFrontEnd)
        {
            foreach (FailedMod badmod in failedmods)
            {
                Main.TheFrontEnd.DisplayError(Object.Instantiate(scriptErrorScreen)
                    .GetComponent<ScriptErrorScreen>().Init("警告！",
                        "下列模组导致了故障： " +
                        $"{KnownModIndex.GetModFancyName(badmod.name)}\n{badmod.error}\n",
                        new List<Menu.MenuItem>
                        {
                            new(){text = "退出游戏", cb = TheSim.ForceAbort},
                            new(){text = "禁用模组", cb = () =>
                            {
                                KnownModIndex.DisableAllMods();
                                KnownModIndex.Save(() => MainFunctions.SimReset());
                            }},
                            new(){text = "模组论坛", nopop = true, cb = () => Main.VisitURL(
                                "http://forums.kleientertainment.com/index.php" +
                                "?/forum/26-dont-starve-mods-and-tools/")}
                    }, Constant.ANCHOR_LEFT, "该模组将被禁用，请从模组菜单重新启用。", 20)
                );
            }
            failedmods = new List<FailedMod>();
        }
    }

    public static void RegisterPrefabs()
    {
        if (!Main.MODS_ENABLED) return;

        foreach (string modname in enabledmods)
        {
            Environment mod = GetMod(modname);

            mod.LoadPrefabFile = MainFunctions.LoadPrefabFile;
            mod.RegisterPrefabs = MainFunctions.RegisterPrefabs;
            mod.Prefabs = new Dictionary<string, Prefab>();
            
            Debug.Log($"Mod: {ModUtil.ModInfoname(mod.modname)}Registering prefabs");

            // We initialize the prefabs in the sandbox
            // and collect all the created prefabs back into the main world.
            if (mod.PrefabFiles != null)
            {
                foreach (string prefab_path in mod.PrefabFiles)
                {
                    Debug.Log($"Mod: {ModUtil.ModInfoname(mod.modname)}  " +
                              $"Registering prefab file: prefabs/{prefab_path}");

                    GameObject ret = mod.LoadPrefabFile($"Prefabs/{prefab_path}");

                    Prefab prefab = ret.GetComponent<Prefab>();
                    Debug.Log($"Mod: {ModUtil.ModInfoname(mod.modname)}    {prefab.name}");
                    mod.Prefabs.Add(prefab.name, prefab);
                }
            }

            List<string> prefabnames = new List<string>();
            foreach (string name in mod.Prefabs.Keys)
            {
                prefabnames.Add(name);
                // copy the prefabs back into the main environment
                Main.Prefabs.Add(name, mod.Prefabs[name].gameObject);
            }
            
            Debug.Log($"Mod: {ModUtil.ModInfoname(mod.modname)}  Registering default mod prefab");
            GameObject gameObject = new GameObject();
            Prefab component = gameObject.AddComponent<Prefab>();
            string newModName = $"MOD_{mod.modname}";
            component.name = $"modbaseprefabs/{newModName}";
            component.deps = prefabnames;
            MainFunctions.RegisterPrefabs(gameObject);
            
            TheSim.LoadPrefabs(newModName);
            loadedprefabs.Add(modname);
        }
    }

    public static void UnloadPrefabs()
    {
        foreach (string modname in loadedprefabs)
        {
            DebugPrint.Print($"unloading prefabs for mod {ModUtil.ModInfoname(modname)}");
            TheSim.UnloadPrefabs(new List<string>{modname});
        }
    }

    public static void SetPostEnv()
    {
        string moddetail = "";
        
        string modnames = "";
        string newmodnames = "";
        string oldmodnames = "";
        string failedmodnames = "";
        string forcemodnames = "";
        
        foreach (Environment mod in mods)
        {
            string modName = mod.modname;
            modprint($"###{modName}");
            if (KnownModIndex.IsModNewlyBad(modName))
            {
                modprint("@NEWLYBAD");
                failedmodnames += $"\"{KnownModIndex.GetModFancyName(modName)}\" ";
            }
            else if (KnownModIndex.IsModNewlyOld(modName) && KnownModIndex.WasModEnabled(modName))
            {
                modprint("@NEWLYOLD");
                oldmodnames += $"\"{KnownModIndex.GetModFancyName(modName)}\" ";
            }
            else if (KnownModIndex.IsModForceEnabled(modName))
            {
                modprint("@FORCEENABLED");
                mod.TheFrontEnd = Main.TheFrontEnd;
                mod.TheGlobalInstance = Main.TheGlobalInstance;
                
                foreach (ParamObjectArrayHandler modfn in mod.postinitfns.GamePostInit)
                {
                    runmodfn(modfn, mod, "gamepostinit")();
                }
                
                forcemodnames += $"\"{KnownModIndex.GetModFancyName(modName)}\" ";
            }
            else if (KnownModIndex.IsModEnabled(modName))
            {
                modprint("@ENABLED");
                mod.TheFrontEnd = Main.TheFrontEnd;
                mod.TheGlobalInstance = Main.TheGlobalInstance;
                
                foreach (ParamObjectArrayHandler modfn in mod.postinitfns.GamePostInit)
                {
                    runmodfn(modfn, mod, "gamepostinit")();
                }
                
                modnames += $"\"{KnownModIndex.GetModFancyName(modName)}\" ";
            }
            else modprint("@DISABLED");
        }

        if (!string.IsNullOrWhiteSpace(oldmodnames))
        {
            moddetail += $"{Strings.UI.MAINSCREEN.OLDMODS} {oldmodnames}\n";
        }
        if (!string.IsNullOrWhiteSpace(failedmodnames))
        {
            moddetail += $"{Strings.UI.MAINSCREEN.FAILEDMODS} {failedmodnames}\n";
        }
        if (!string.IsNullOrWhiteSpace(oldmodnames) || !string.IsNullOrWhiteSpace(failedmodnames))
        {
            moddetail += $"{Strings.UI.MAINSCREEN.OLDORFAILEDMODS}\n\n";
        }

        if (!string.IsNullOrWhiteSpace(newmodnames))
        {
            moddetail += $"{Strings.UI.MAINSCREEN.NEWMODDETAIL} {newmodnames}\n" +
                         $"{Strings.UI.MAINSCREEN.NEWMODDETAIL2}\n\n";
        }
        if (!string.IsNullOrWhiteSpace(modnames))
        {
            moddetail += $"{Strings.UI.MAINSCREEN.MODDETAIL} {modnames}\n\n";
        }
        if (!string.IsNullOrWhiteSpace(newmodnames) || !string.IsNullOrWhiteSpace(modnames))
        {
            moddetail += $"{Strings.UI.MAINSCREEN.MODDETAIL2}\n\n";
        }
        
        if (!string.IsNullOrWhiteSpace(forcemodnames))
        {
            moddetail += $"{Strings.UI.MAINSCREEN.FORCEMODDETAIL} {forcemodnames}\n\n";
        }
        
        if ((!string.IsNullOrWhiteSpace(modnames) || !string.IsNullOrWhiteSpace(newmodnames)
            || !string.IsNullOrWhiteSpace(oldmodnames) || !string.IsNullOrWhiteSpace(failedmodnames)
            || !string.IsNullOrWhiteSpace(forcemodnames))
            && PlayerProfile.GetModsWarning())
        {
            Main.TheFrontEnd.PushScreen(Object.Instantiate(scriptErrorScreen)
                .GetComponent<ScriptErrorScreen>().Init("模组已安装！", moddetail, new List<Menu.MenuItem>
                {
                    new(){text = "我明白", cb = () => Main.TheFrontEnd.PopScreen()},
                    new(){text = "禁用模组", cb = () =>
                    {
                        KnownModIndex.DisableAllMods();
                        KnownModIndex.Save(() => MainFunctions.SimReset());
                    }},
                    new(){text = "模组论坛", nopop = true, cb = () => Main.VisitURL(
                        "http://forums.kleientertainment.com/index.php" +
                        "?/forum/26-dont-starve-mods-and-tools/")}
                }, null, null, null, null, true)
            );
        }
        else if (KnownModIndex.WasLoadBad())
        {
            Main.TheFrontEnd.PushScreen(Object.Instantiate(scriptErrorScreen)
                .GetComponent<ScriptErrorScreen>().Init("所有模组已禁用",
                    "游戏上次未正常启动。这可能是由于某个模组所致，因此所有模组已禁用。" +
                    "\n\n你可以从模组设置页面尝试重新启用这些模组。", new List<Menu.MenuItem>
                    {
                        new(){text = "我明白", cb = () => Main.TheFrontEnd.PopScreen()},
                        new(){text = "模组论坛", nopop = true, cb = () => Main.VisitURL(
                            "http://forums.kleientertainment.com/index.php" +
                            "?/forum/26-dont-starve-mods-and-tools/")}
                    }));
        }
        
        DisplayBadMods();
    }

    public static List<ParamObjectArrayHandler> GetPostInitFns(string type, string id)
    {
        List<ParamObjectArrayHandler> retfns = new();
        foreach (string modname in enabledmods)
        {
            Environment mod = GetMod(modname);
            FieldInfo fieldInfo = typeof(PostInitFns).GetField(type);
            if (fieldInfo != null)
            {
                Dictionary<string, List<ParamObjectArrayHandler>> value =
                    (Dictionary<string, List<ParamObjectArrayHandler>>)fieldInfo.GetValue(mod.postinitfns);
                value.TryGetValue(id, out List<ParamObjectArrayHandler> modfns);
                if (modfns != null)
                {
                    foreach (ParamObjectArrayHandler modfn in modfns)
                    {
                        retfns.Add(runmodfn(modfn, mod, $"{type}: {id}"));
                    }
                }
            }
        }
        return retfns;
    }
}