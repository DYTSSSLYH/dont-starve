using System;
using DYT.Map;

namespace DYT
{
    public class WorldGenMain
    {
        public static string GEN_PARAMETERS;
        
        public static long SEED = TheSim.getrealtime();
        public static bool DEBUGSIGNS_ENABLED = false;
        public static Random random = new((int)SEED);
        public static int WORLDGEN_MAIN = 1;
        public static bool POT_GENERATION = false;
    
        static WorldGenMain()
        {
            DebugPrint.print("worldgen_main.lua MAIN = 1");
            
            // require("simutil")
            //
            // require("strict")
            // require("debugprint")
            
            // require("json")
            // require("vector3")
            // require("tuning")
            // require("dlcsupport_worldgen")
            // require("strings")
            // require("dlcsupport_strings")
            // require("constants")
            // require("class")
            // require("debugtools")
            // require("util")
            // require("prefabs")
            // require("profiler")
            // require("dumper")
            //
            // require("mods")
            // require("modindex")

            new Tasks();
            DebugPrint.print("worldgen_main.lua MAIN = 2");
            
            DebugPrint.print("SEED = ", SEED);
            
            LoadParametersAndGenerate(false);
        }
        
        
        public static void GenerateNew(){}

        private static void LoadParametersAndGenerate(bool debug)
        {
            DebugPrint.print("LoadParametersAndGenerate", "GEN_PARAMETERS", GEN_PARAMETERS);
        }
    }
}