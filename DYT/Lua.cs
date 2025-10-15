using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using XLua;

namespace DYT
{
    public class Lua
    {
        public string luaName;
        
        public static void unpack(LuaTable luaTable, out object obj1, out object obj2, out object obj3)
        {
            obj1 = null;
            obj2 = null;
            obj3 = null;
            
            List<object> list = new List<object>();
            foreach (object key in luaTable.GetKeys()) list.Add(luaTable.Get<object, object>(key));
            
            if (list.Count > 0) obj1 = list[0];
            if (list.Count > 1) obj2 = list[1];
            if (list.Count > 2) obj3 = list[2];
        }

        public static LuaFunction kleiloadlua(string filePath)
        {
            filePath = Main.GetFilePath(filePath);
            return filePath == null
                ? null : Main.LUA_ENV.LoadString(File.ReadAllText(filePath, Encoding.UTF8));
        }
        
        public static void setfenv(LuaFunction luaFunction, LuaTable luaTable)
        {
            luaFunction.SetEnv(luaTable);
        }

        public static bool kleifileexists(string filePath)
        {
            string path = Main.GetFilePath(filePath);
            return File.Exists(path);
        }
    }
}