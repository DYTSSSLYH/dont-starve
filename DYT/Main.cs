using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

namespace DYT
{
    public static class Main
    {
        [CSharpCallLua]
        public static List<Type> C_SHARP_CALL_LUA_TYPE_LIST = new List<Type>()
        {
            typeof(Action<bool, string>),
        };

        public static LuaEnv LUA_ENV;

        public static void Start()
        {
            LUA_ENV = new LuaEnv();
            LUA_ENV.AddLoader(Loader);
            
            LUA_ENV.DoString("package.path = 'scripts/?.lua;scriptlibs/?.lua'");
            LUA_ENV.DoString("TheSim = CS.DYT.TheSim.INSTANCE");
            LUA_ENV.DoString("loadstring = CS.Newtonsoft.Json.DeserializeObject");
            LUA_ENV.DoString("CONFIGURATION = 'PRODUCTION'");
            LUA_ENV.DoString("PLATFORM = 'WIN32_STEAM'");
            LUA_ENV.DoString("APP_REGION = 'NONE'");
            LUA_ENV.DoString("walltime = TheSim.getrealtime");
            LUA_ENV.DoString("TheInputProxy = CS.DYT.TheInputProxy");
            LUA_ENV.DoString("unpack = CS.DYT.Lua.unpack");
            LUA_ENV.DoString("TheSystemService = CS.DYT.TheSystemService");
            LUA_ENV.DoString("kleiloadlua = CS.DYT.Lua.kleiloadlua");
            LUA_ENV.DoString("setfenv = CS.DYT.Lua.setfenv");
            LUA_ENV.DoString("kleifileexists = CS.DYT.Lua.kleifileexists");
            LUA_ENV.DoString("TheGameService = CS.DYT.TheGameService");
            LUA_ENV.DoString("RUN_GLOBAL_INIT = true");
            
            LUA_ENV.DoString("require 'main'");
        }

        public static string GetFilePath(string postPath)
        {
            string prePath = $"{Application.persistentDataPath}/data";
            
            string filePath = $"{prePath}/DLC0003/{postPath}";
            if (File.Exists(filePath)) return filePath;
            
            filePath = $"{prePath}/DLC0002/{postPath}";
            if (File.Exists(filePath)) return filePath;
            
            filePath = $"{prePath}/DLC0001/{postPath}";
            if (File.Exists(filePath)) return filePath;
            
            filePath = $"{prePath}/{postPath}";
            if (File.Exists(filePath)) return filePath;

            return null;
        }
        private static byte[] Loader(ref string name)
        {
            string packagePath = (string)LUA_ENV.DoString("return package.path")[0];
            string[] postPathArray = packagePath.Replace("?", name).Split(";");
            foreach (string postPath in postPathArray)
            {
                string filePath = GetFilePath(postPath);
                if (filePath != null) return File.ReadAllBytes(filePath);
            }
            return null;
        }
    }
}