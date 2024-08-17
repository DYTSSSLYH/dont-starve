using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DYT
{
    public static class DLCSupportWorldGen
    {
        public const int MAIN_GAME = 0;
        public const int REIGN_OF_GIANTS = 1;
        public const int CAPY_DLC = 2;
        public const int PORKLAND_DLC = 3;

        public static readonly bool[] NO_DLC_TABLE = new bool[3];
        public static readonly bool[] ALL_DLC_TABLE = new bool[3];
        public static readonly int[] DLC_LIST = new int[3];

        private static bool[] __DLCEnabledTable = new bool[3];
        
        
        static DLCSupportWorldGen() {
            NO_DLC_TABLE[REIGN_OF_GIANTS] = false;
            NO_DLC_TABLE[CAPY_DLC] = false;
            
            ALL_DLC_TABLE[REIGN_OF_GIANTS] = true;
            ALL_DLC_TABLE[CAPY_DLC] = true;

            DLC_LIST[1] = REIGN_OF_GIANTS;
            DLC_LIST[2] = CAPY_DLC;

            JObject parameters = JsonConvert.DeserializeObject<JObject>(Main.GEN_PARAMETERS);
            SetDLCEnabled(parameters["DLCEnabled"].Value<bool[]>());
            
            Debug.Log($"DLC(RoG) enabled : {IsDLCEnabled(REIGN_OF_GIANTS)}");
            Debug.Log($"DLC(Shipwrecked) enabled : {IsDLCEnabled(CAPY_DLC)}");
        }
        

        public static bool IsDLCEnabled(int index)
        {
            return index < __DLCEnabledTable.Length && __DLCEnabledTable[index];
        }

        public static void SetDLCEnabled([CanBeNull] bool[] tbl)
        {
            if (tbl == null) tbl = new bool[3];
            __DLCEnabledTable = tbl;
        }
        
    }
}