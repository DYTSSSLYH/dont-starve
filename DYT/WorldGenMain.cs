using System;
using System.Collections.Generic;
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


        private static void OverrideTweaks(Level level, CustomScreen.ChangedOption world_gen_choices)
        {
            Customise customise = CustomisePork.Instance();
            foreach ((object k, object v) in level.overrides)
            {
                string name = null;
                if (k.GetType() == typeof(List<string>))
                    name = ((List<string>)k)[UnityEngine.Random.Range(0, ((List<string>)k).Count)];
                else if (k is string) name = (string)k;
                
                string value;
                if (v.GetType() == typeof(List<string>))
                    value = ((List<string>)v)[UnityEngine.Random.Range(0, ((List<string>)v).Count)];
                else if (v is string) value = (string)v;

                string area = customise.GetGroupForItem(name);
                //-- Modify world now
            }
        }

        private static void FixWesUnlock(Level level, int progress, PlayerProfile.Data profile)
        {
            bool should_wes = profile != null &&
                              !profile.unlocked_characters.Contains("wes") && progress == 3;
            if (!should_wes)
            {
                DebugPrint.print("No wes allowed on this level!");
                level.set_pieces.Remove("WesUnlock");
            }
            else DebugPrint.print("Wes setpiece allowed in this level.");
        }

        public static object GenerateNew(bool debug, GenParameters parameters)
        {
            //--print("Generate New map", debug, parameters.gen_type,
            //"type: "..parameters.level_type, parameters.current_level, parameters.world_gen_choices)
            new ForestMap();

            Level level = Levels.test_level;

            if (!string.IsNullOrWhiteSpace(parameters.level_type) &&
                parameters.level_type.ToUpper() == "CAVE")
            {
                if (!parameters.current_level.HasValue ||
                    parameters.current_level.Value > Levels.cave_levels.Count)
                {
                    parameters.current_level = 1;
                }

                level = Levels.cave_levels[parameters.current_level.Value];
            }
            else if (!string.IsNullOrWhiteSpace(parameters.level_type) &&
                parameters.level_type.ToUpper() == "ADVENTURE")
            {
                level = Levels.story_levels[parameters.current_level.Value];
                
                FixWesUnlock(level, parameters.adventure_progress, parameters.profiledata);
                DebugPrint.print("\n#######\n#\n" +
                                 $"# Generating {level.name}({parameters.current_level})\n#\n#######\n");
            }
            else if (!string.IsNullOrWhiteSpace(parameters.level_type) &&
                parameters.level_type.ToUpper() == "TEST")
            {
                DebugPrint.print("\n#######\n#\n# Generating TEST Mode Level\n#\n#######\n");
            }
            else if (!string.IsNullOrWhiteSpace(parameters.level_type) &&
                parameters.level_type.ToUpper() == "SURVIVAL")
            {
                if (parameters.world_gen_choices.preset.data == null)
                    parameters.world_gen_choices.preset.data = "SURVIVAL_DEFAULT";
                DebugPrint.print("WORLDGEN PRESET: ", parameters.world_gen_choices.preset.data);
                for (int i = 0; i < Levels.sandbox_levels.Count; i++)
                {
                    Level sandboxLevel = Levels.sandbox_levels[i];
                    if (sandboxLevel.id == parameters.world_gen_choices.preset.data)
                    {
                        parameters.world_gen_choices.level_id = i;
                        break;
                    }
                }

                DebugPrint.print("WORLDGEN LEVEL ID: ", parameters.world_gen_choices.level_id);
                if (parameters.world_gen_choices.level_id > Levels.sandbox_levels.Count)
                    parameters.world_gen_choices.level_id = 1;

                level = Levels.sandbox_levels[parameters.world_gen_choices.level_id];
                
                DebugPrint.print("\n#######\n#\n" +
                                 $"# Generating Normal Mode {level.name} Level\n#\n#######\n");
            }
            else if (!string.IsNullOrWhiteSpace(parameters.level_type) &&
                parameters.level_type.ToUpper() == "SHIPWRECKED")
            {
                if (parameters.world_gen_choices.preset.data == null)
                    parameters.world_gen_choices.preset.data = "SHIPWRECKED_DEFAULT";
                DebugPrint.print("WORLDGEN PRESET: ", parameters.world_gen_choices.preset.data);
                for (int i = 0; i < Levels.shipwrecked_levels.Count; i++)
                {
                    Level shipwreckedLevel = Levels.shipwrecked_levels[i];
                    if (shipwreckedLevel.id == parameters.world_gen_choices.preset.data)
                    {
                        parameters.world_gen_choices.level_id = i;
                        break;
                    }
                }

                DebugPrint.print("WORLDGEN LEVEL ID: ", parameters.world_gen_choices.level_id);
                if (parameters.world_gen_choices.level_id > Levels.shipwrecked_levels.Count)
                    parameters.world_gen_choices.level_id = 1;

                level = Levels.shipwrecked_levels[parameters.world_gen_choices.level_id];
                
                DebugPrint.print("\n#######\n#\n" +
                                 $"# Generating Shipwrecked Mode {level.name} Level\n#\n#######\n");
            }
            else if (!string.IsNullOrWhiteSpace(parameters.level_type) &&
                parameters.level_type.ToUpper() == "VOLCANO")
            {
                if (parameters.current_level.HasValue &&
                    parameters.current_level.Value > Levels.volcano_levels.Count)
                {
                    parameters.current_level = 1;
                }
                level = Levels.volcano_levels[parameters.current_level.Value];
                
                DebugPrint.print("\n#######\n#\n" +
                                 $"# Generating Volcano {level.name} Level\n#\n#######\n");
            }
            else if (!string.IsNullOrWhiteSpace(parameters.level_type) &&
                     parameters.level_type.ToUpper() == "PORKLAND")
            {
                if (parameters.world_gen_choices.preset.data == null)
                    parameters.world_gen_choices.preset.data = "PORKLAND_DEFAULT";
                DebugPrint.print("WORLDGEN PRESET: ", parameters.world_gen_choices.preset.data);
                for (int i = 0; i < Levels.porkland_levels.Count; i++)
                {
                    Level porklandLevel = Levels.porkland_levels[i];
                    if (porklandLevel.id == parameters.world_gen_choices.preset.data)
                    {
                        parameters.world_gen_choices.level_id = i;
                        break;
                    }
                }

                DebugPrint.print("WORLDGEN LEVEL ID: ", parameters.world_gen_choices.level_id);
                if (parameters.world_gen_choices.level_id > Levels.porkland_levels.Count)
                    parameters.world_gen_choices.level_id = 1;

                level = Levels.porkland_levels[parameters.world_gen_choices.level_id];
                
                DebugPrint.print("\n#######\n#\n" +
                                 $"# Generating Porkland Mode {level.name} Level\n#\n#######\n");
            }
            else
            {
                //-- Probably got here from a mod, up to the mod to tell us what to load.
                level = Levels.custom_levels[parameters.world_gen_choices.level_id];
                DebugPrint.print("\n#######\n#\n# " +
                                 $"Special: Generating {parameters.level_type} mode {level.name} Level" +
                                 "\n#\n#######\n");
            }

            List<ModManager.ParamObjectArrayHandler> modfns =
                ModManager.GetPostInitFns("LevelPreInit", level.id);
            foreach (ModManager.ParamObjectArrayHandler modfn in modfns)
            {
                DebugPrint.print($"Applying mod to level '{level.id}'");
                modfn(level);
            }
            modfns = ModManager.GetPostInitFns("LevelPreInitAny");
            foreach (ModManager.ParamObjectArrayHandler modfn in modfns)
            {
                DebugPrint.print("Applying mod to current level");
                modfn(level);
            }
            
            OverrideTweaks(level, parameters.world_gen_choices);

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