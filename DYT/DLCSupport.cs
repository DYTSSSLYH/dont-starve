using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace DYT
{
    public static class DLCSupport
    {
        public const int MAIN_GAME = 0;
        public const int REIGN_OF_GIANTS = 1;
        public const int CAPY_DLC = 2;
        public const int PORKLAND_DLC = 3;

        public class DLCTable
        {
            public bool REIGN_OF_GIANTS;
            public bool CAPY_DLC;
            public bool PORKLAND_DLC;
        }
        public static readonly DLCTable NO_DLC_TABLE = new()
        {
            REIGN_OF_GIANTS=false, CAPY_DLC=false, PORKLAND_DLC = false
        };
        public static DLCTable ALL_DLC_TABLE = new()
        {
            REIGN_OF_GIANTS = true, CAPY_DLC = true, PORKLAND_DLC = true
        };
        public static List<int> DLC_LIST = new() { REIGN_OF_GIANTS, CAPY_DLC, PORKLAND_DLC };
    
        public static readonly List<MethodInfo> RegisteredDLC = new();
        public static object ActiveDLC = new();

        #region locals

        private static void AddPrefab(string prefabName)
        {
            if (PrefabList.PREFABFILES.Contains(prefabName)) return;
            PrefabList.PREFABFILES.Add(prefabName);
        }

        private static List<string> GetDLCPrefabFiles(string filename)
        {
            Debug.Log($"Load {filename}");
            Type type = Type.GetType(filename);
            Assert.IsNotNull(type, $"Could not load file {filename}");
            // Debug.Assert(type != null, $"Could not load file {filename}");
            FieldInfo fieldInfo = type.GetField("PREFABFILES");
            Debug.Assert(fieldInfo != null, $"Error loading file  {filename}");
            return (List<string>)fieldInfo.GetValue(null);
        }
    
        private static void RegisterPrefabs(int index)
        {
            string dlcPrefabFilename = $"DYT.DLC{index:D3}PrefabFiles";
            List<string> dlcprefabfiles = GetDLCPrefabFiles(dlcPrefabFilename);
        
            foreach (string dlcprefabfile in dlcprefabfiles) AddPrefab(dlcprefabfile);
        }

        // Load the base prefablist and merge in all additional prefabs for the DLCs
        private static void ReloadPrefabList()
        {
            for (int i = 0; i < RegisteredDLC.Count; i++) RegisterPrefabs(i + 1);
        }

        #endregion

        #region globals

        public static void RegisterAllDLC()
        {
            for (int i = 1; i <= 10; i++)
            {
                string filename = $"DYT.DLC{i:D4}";
                Type type = Type.GetType(filename);
                if (type == null) continue;
                MethodInfo methodInfo = type.GetMethod("Setup");
                if (methodInfo == null) continue;

                RegisteredDLC.Add(methodInfo);
            }
            ReloadPrefabList();
        }
        
        // This one is somewhat important, it can be used to load prefabs
        // that are not referenced by any prefab and thus not loaded
        public static void InitAllDLC()
        {
            foreach (MethodInfo methodInfo in RegisteredDLC) methodInfo.Invoke(null, null);
        }

        #endregion

        #region
    
        private static bool[] _dlcEnabled { get; set; } = { false, false, false, false };


        public static bool IsDLCEnabled(int index)
        {
            return _dlcEnabled[index];
        }

        public static void SetBGcolor(Image background, bool scriptError)
        {
            if (IsDLCEnabled(PORKLAND_DLC))
            {
                if (scriptError)
                    background.color = new Color(
                        Constant.BGCOLOURS.GREEN[0] * 0.4f,
                        Constant.BGCOLOURS.GREEN[1] * 0.4f,
                        Constant.BGCOLOURS.GREEN[2] * 0.4f,
                        1
                    );
                else
                    background.color = new Color(
                        Constant.BGCOLOURS.GREEN[0],
                        Constant.BGCOLOURS.GREEN[1],
                        Constant.BGCOLOURS.GREEN[2],
                        1
                    );
            }
            else if (IsDLCEnabled(CAPY_DLC))
                background.color = new Color(
                    Constant.BGCOLOURS.TEAL[0],
                    Constant.BGCOLOURS.TEAL[1],
                    Constant.BGCOLOURS.TEAL[2],
                    1
                );
            else if (IsDLCEnabled(REIGN_OF_GIANTS))
                background.color = new Color(
                    Constant.BGCOLOURS.PURPLE[0],
                    Constant.BGCOLOURS.PURPLE[1],
                    Constant.BGCOLOURS.PURPLE[2],
                    1
                );
            else
                background.color = new Color(
                    Constant.BGCOLOURS.RED[0],
                    Constant.BGCOLOURS.RED[1],
                    Constant.BGCOLOURS.RED[2],
                    1
                );
        }

        public static void SetManualBGColor(Image background, int dlc)
        {
            string selectedColor = dlc == MAIN_GAME ? "RED" :
                dlc == REIGN_OF_GIANTS ? "PURPLE" :
                dlc == CAPY_DLC ? "TEAL" :
                dlc == PORKLAND_DLC ? "GREEN" : "GREEN";

            float[] value = (float[])typeof(Constant.BGCOLOURS).GetField(selectedColor).GetValue(null);
            background.color = new Color(value[0], value[1], value[2], 1);
        }

        public static List<string> GetOfficialCharacterList()
        {
            List<string> list = Constant.MAIN_CHARACTER_LIST;

            if (IsDLCEnabled(REIGN_OF_GIANTS)) list = Util.JoinArrays(list, Constant.ROG_CHARACTER_LIST);
            else if (IsDLCEnabled(CAPY_DLC))
            {
                list = Util.JoinArrays(list, Constant.ROG_CHARACTER_LIST);
                list = Util.JoinArrays(list, Constant.SHIPWRECKED_CHARACTER_LIST);
            }
            else if (IsDLCEnabled(PORKLAND_DLC))
            {
                list = Util.JoinArrays(list, Constant.ROG_CHARACTER_LIST);
                list = Util.JoinArrays(list, Constant.SHIPWRECKED_CHARACTER_LIST);
                list = Util.JoinArrays(list, Constant.PORKLAND_CHARACTER_LIST);
            }

            return list;
        }

        public static List<string> GetActiveCharacterList()
        {
            return Util.JoinArrays(GetOfficialCharacterList(), Constant.MOD_CHARACTER_LIST);
        }

        public static List<string> GetActiveCharacterListForSelection()
        {
            List<string> list = GetActiveCharacterList();

            foreach (string retiredCharacter in Constant.RETIRED_CHARACTER_LIST)
                if (list.Contains(retiredCharacter))
                    list.Remove(retiredCharacter);

            return list;
        }

        #endregion
    }
}