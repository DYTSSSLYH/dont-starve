using System;
using DYT.Map;
using DYT.Screens;
using Newtonsoft.Json;

namespace DYT
{
    public class GenParameters
    {
        public string level_type;
        public CustomScreen.ChangedOption world_gen_choices;
        public int? current_level;
        public int adventure_progress;
        public PlayerProfile.Data profiledata;
        public bool[] DLCEnabled;
        public bool ROGEnabled;
    }
    
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


        public static object GenerateNew(bool debug, GenParameters parameters)
        {
            //--print("Generate New map", debug, parameters.gen_type,
            //"type: "..parameters.level_type, parameters.current_level, parameters.world_gen_choices)
            new ForestMap();
            
            
            
            return null;
        }

        private static object LoadParametersAndGenerate(bool debug)
        {
            DebugPrint.print("LoadParametersAndGenerate", "GEN_PARAMETERS", GEN_PARAMETERS);

            GenParameters parameters;
            if (string.IsNullOrWhiteSpace(GEN_PARAMETERS))
            {
                DebugPrint.print("WARNING: No parameters found, using defaults. " +
                                 "This should only happen from the test harness!");
                parameters = new GenParameters
                {
                    level_type = "adventure", current_level = 5,
                    adventure_progress = 3, profiledata = { unlocked_characters = { "wes" } }
                };
            }
            else parameters = JsonConvert.DeserializeObject<GenParameters>(GEN_PARAMETERS);

            if (parameters.world_gen_choices == null)
                parameters.world_gen_choices = new CustomScreen.ChangedOption();
            DLCSupportWorldGen.SetDLCEnabled(parameters.DLCEnabled);
            
            //-- parameters.worldgen_type, parameters.level_type,
            //parameters.current_level, parameters.world_gen_choices)
            return GenerateNew(debug, parameters);
        }
    }
}