using System;
using System.Collections.Generic;
using UnityEngine;

public class ModUtil
{
    public static string ModInfoname(string name)
    {
        string prettyName = KnownModIndex.GetModFancyName(name);
        return prettyName == name ? name : $"{name} ({prettyName})";
    }

    // This isn't for modders to use: see mods.lua, CreateEnvironment function (line 94 specifically)
    public static object GetModConfigData(string optionname, string modname)
    {
        Debug.Assert(modname != null,
            "modname must be supplied manually if calling GetModConfigData " +
            "from outside of modmain or modworldgenmain. " +
            "Use ModIndex:GetModActualName(fancyname) function [fancyname is name string from modinfo].");

        List<KnownModIndex.Config> configList = KnownModIndex.GetModConfigurationOptions(modname);
        if (configList != null)
        {
            foreach (KnownModIndex.Config config in configList)
            {
                if (config.name == optionname)
                {
                    if (config.saved == null) return config.defaultValue;
                    else return config.saved;
                }
            }
        }
        
        return null;
    }
    
    public static Func<string, object> GetModConfigDataFn(string modname)
    {
        return optionname => GetModConfigData(optionname, modname);
    }


    private static void initprint(string modName, params object[] objects)
    {
        if (KnownModIndex.IsModInitPrintEnabled()) DebugPrint.print(ModInfoname(modName), objects);
    }
    
    public static void InsertPostInitFunctions(ModManager.Environment env)
    {
        // TODO
        env.postinitfns = new ModManager.PostInitFns();

        env.postinitfns.ComponentPostInit =
            new Dictionary<string, List<ModManager.ParamObjectArrayHandler>>();
        env.AddComponentPostInit = (component, fn) =>
        {
            initprint("AddComponentPostInit", component);
            if (!env.postinitfns.ComponentPostInit.ContainsKey(component))
            {
                env.postinitfns.ComponentPostInit.Add(component,
                    new List<ModManager.ParamObjectArrayHandler>());
            }
            env.postinitfns.ComponentPostInit[component].Add(fn);
        };

        env.postinitfns.GamePostInit = new List<ModManager.ParamObjectArrayHandler>();
        env.AddGamePostInit = fn =>
        {
            initprint("AddGamePostInit");
            env.postinitfns.GamePostInit.Add(fn);
        };
    }
}