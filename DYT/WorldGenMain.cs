using System;
using System.Collections.Generic;
using DYT.Map;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

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
        public bool show_debug;
    }
    
    public class WorldGenMain
    {
        public static string GEN_PARAMETERS;
        
        // public static long SEED = TheSim.getrealtime();
        public static bool DEBUGSIGNS_ENABLED = false;
        public static int WORLDGEN_MAIN = 1;
        public static bool POT_GENERATION = false;
    
        
        static WorldGenMain()
        {
            // Random.InitState((int)SEED);
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
            
            // DebugPrint.print("SEED = ", SEED);
            
            LoadParametersAndGenerate(false);
        }


        public static void ShowDebug(object savedata)
        {
            
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
                
                string value = null;
                if (v.GetType() == typeof(List<string>))
                    value = ((List<string>)v)[UnityEngine.Random.Range(0, ((List<string>)v).Count)];
                else if (v is string) value = (string)v;

                string area = customise.GetGroupForItem(name);
                //-- Modify world now
                if (!(world_gen_choices.tweak != null && world_gen_choices.tweak.ContainsKey(area) &&
                      world_gen_choices.tweak[area].ContainsKey(name)))
                {
                    if (world_gen_choices.tweak == null)
                        world_gen_choices.tweak = new Dictionary<string, Dictionary<string, string>>();
                    
                    world_gen_choices.tweak.TryAdd(area, new Dictionary<string, string>());
                    world_gen_choices.tweak[area].TryAdd(name, value);
                    world_gen_choices.tweak[area][name] = value;
                }
            }
        }

        private static Dictionary<string, object> GetRandomFromLayouts(
            Dictionary<object, Dictionary<string, Layout>> layouts)
        {
            List<object> areaKeys = new List<object>(layouts.Keys);
            int areaIdx = UnityEngine.Random.Range(0, areaKeys.Count);
            object area = areaKeys[areaIdx];
            if ((area == "Rare" && UnityEngine.Random.value < 0.98f) || layouts[area].Count < 1)
            {
                areaKeys.Remove(areaIdx);
                area = areaKeys[UnityEngine.Random.Range(0, areaKeys.Count)];
            }

            if (layouts[area].Count < 1) return null;

            Dictionary<string, object> target = new Dictionary<string, object>()
            {
                ["target_area"] = area,
                ["choice"] = Util.GetRandomKey(layouts[area]),
            };
            
            return target;
        }

        private static List<string> GetAreasForChoice(object area, Level level)
        {
            List<string> areas = new List<string>();
            
            foreach (string taskName in level.tasks)
            {
                Task task = Tasks.GetTaskByName(taskName, Tasks.sampletasks);
                if ((level.name == "Shipwrecked" && area == "Shipwrecked_Any")
                    || area == "Any" || area == "Rare" || (int)area == task.room_bg)
                    areas.Add(taskName);
            }
            if (areas.Count == 0) return null;
            return areas;
        }
        
        private static void AddSingleSetPeice(Level level, string choicefile)
        {
            Type type = Type.GetType(choicefile);
            SandboxAndLayouts choices = (SandboxAndLayouts)Activator.CreateInstance(type);
            Assert.IsNotNull(choices.Sandbox);

            Dictionary<string,object> chosen = GetRandomFromLayouts(choices.Sandbox);
            if (chosen == null) return;

            if (chosen["target_area"] == "Water")
            {
                if (level.water_setpieces == null)
                    level.water_setpieces = new Dictionary<string, SetPiece>();
                if (level.water_setpieces[(string)chosen["choice"]] == null)
                    level.water_setpieces[(string)chosen["choice"]] = new SetPiece() { count = 0 };
                level.water_setpieces[(string)chosen["choice"]].count += 1;
            }
            else
            {
                if (level.set_pieces == null) level.set_pieces = new Dictionary<string, SetPiece>();
                List<string> areas = GetAreasForChoice(chosen["target_area"], level);
                if (areas == null) return;

                int num_peices = 1;
                if (level.set_pieces[(string)chosen["choice"]] != null)
                    num_peices = level.set_pieces[(string)chosen["choice"]].count + 1;
                level.set_pieces[(string)chosen["choice"]] =
                    new SetPiece { count = num_peices, tasks = areas };
            }
        }

        private static void AddSetPeices(Level level, CustomScreen.ChangedOption world_gen_choices)
        {
            string boons_override = "default";
            string touchstone_override = "default";
            string traps_override = "default";
            string poi_override = "default";
            string protected_override = "default";
            
            if (world_gen_choices.tweak != null && world_gen_choices.tweak.ContainsKey("misc"))
            {
                if (world_gen_choices.tweak["misc"].ContainsKey("boons"))
                    boons_override = world_gen_choices.tweak["misc"]["boons"];
                
                if (world_gen_choices.tweak["misc"].ContainsKey("touchstone"))
                    touchstone_override = world_gen_choices.tweak["misc"]["touchstone"];
                
                if (world_gen_choices.tweak["misc"].ContainsKey("traps"))
                    traps_override = world_gen_choices.tweak["misc"]["traps"];
                
                if (world_gen_choices.tweak["misc"].ContainsKey("poi"))
                    poi_override = world_gen_choices.tweak["misc"]["poi"];
                
                if (world_gen_choices.tweak["misc"].ContainsKey("protected"))
                    protected_override = world_gen_choices.tweak["misc"]["protected"];
            }
            
            if (traps_override != "never") AddSingleSetPeice(level, "map/traps");
            if (poi_override != "never") AddSingleSetPeice(level, "map/pointsofinterest");
            if (protected_override != "never") AddSingleSetPeice(level, "map/protected_resources");

            Dictionary<string, float> multiply = new()
            {
                ["rare"] = 0.5f,
                ["default"] = 1,
                ["often"] = 1.5f,
                ["mostly"] = 2.2f,
                ["always"] = 3,
            };

            if (touchstone_override != "default" && level.set_pieces != null)
            {
                if (level.set_pieces["ResurrectionStone"] != null)
                {
                    if (touchstone_override != "never") level.set_pieces["ResurrectionStone"] = null;
                    else
                    {
                        level.set_pieces["ResurrectionStone"].count = Mathf.CeilToInt(
                            level.set_pieces["ResurrectionStone"].count * multiply[touchstone_override]
                        );
                    }
                }
                if (level.set_pieces["ResurrectionStoneSw"] != null)
                {
                    if (touchstone_override != "never") level.set_pieces["ResurrectionStoneSw"] = null;
                    else
                    {
                        level.set_pieces["ResurrectionStoneSw"].count = Mathf.CeilToInt(
                            level.set_pieces["ResurrectionStoneSw"].count * multiply[touchstone_override]
                        );
                    }
                }
            }

            if (boons_override != "never")
            {
                //--Quick hack to get the boons in
                int boons = UnityEngine.Random.Range(
                    Mathf.FloorToInt(3 * multiply[boons_override]),
                    Mathf.CeilToInt(8 * multiply[boons_override])
                );
                for (int idx = 1; idx <= boons; idx++ ) AddSingleSetPeice(level, "map/boons");
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

        private static void GetStartTask(Dictionary<string, Level.StartTask> start_tasks,
            out string last_task, out Level.StartTask last_data)
        {
            last_task = null;
            last_data = null;
            
            if (start_tasks == null) return;

            float totalweight = 0;
            foreach ((string task, Level.StartTask data) in start_tasks) totalweight += data.weight;
            float thres = Random.Range(0, totalweight);
            foreach ((string task, Level.StartTask data) in start_tasks)
            {
                thres -= data.weight;
                if (thres > 0) continue;
                last_task = task;
                last_data = data;
                return;
            }
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

            List<ActionParams> modfns =
                ModManager.GetPostInitFns("LevelPreInit", level.id);
            foreach (ActionParams modfn in modfns)
            {
                DebugPrint.print($"Applying mod to level '{level.id}'");
                modfn(level);
            }
            modfns = ModManager.GetPostInitFns("LevelPreInitAny");
            foreach (ActionParams modfn in modfns)
            {
                DebugPrint.print("Applying mod to current level");
                modfn(level);
            }
            
            OverrideTweaks(level, parameters.world_gen_choices);
            Dictionary<string,List<List<string>>> level_area_triggers = level.override_triggers;
            AddSetPeices(level, parameters.world_gen_choices);

            string id = level.id;
            bool override_level_string = level.override_level_string;
            string name = level.name ?? "ERROR";
            bool hideminimap = level.hideminimap;

            object teleportaction = level.teleportaction;
            string teleportmaxwell = level.teleportmaxwell;
            bool nomaxwell = level.nomaxwell;

            string prefab = "forest";
            if (
                parameters.world_gen_choices.tweak != null
                && parameters.world_gen_choices.tweak.ContainsKey("misc")
            )
            {
                prefab = parameters.world_gen_choices.tweak["misc"]
                    .GetValueOrDefault("location", "forest");
            }
            
            GetStartTask(level.start_tasks, out string start_task, out Level.StartTask start_data);
            if (start_task != null)
            {
                parameters.world_gen_choices.tweak["misc"]["start_task"] = start_task;
                parameters.world_gen_choices.tweak["misc"]["start_setpeice"] = start_data.start_setpiece;
                parameters.world_gen_choices.tweak["misc"]["start_node"] = start_data.start_node;
                level.tasks.Add(start_task);
            }

            List<Task> choose_tasks = level.GetTasksForLevel(Tasks.sampletasks);
            if (debug) choose_tasks = Tasks.oneofeverything;
            //--print ("Generating new world","forest", max_map_width, max_map_height, choose_tasks)

            object savedata = null;

            int max_map_width = 1024; //-- 1024--256
            int max_map_height = 1024; //-- 1024--256
            
            int tryNum = 0;
            int maxtries = 5;

            while (savedata == null)
            {
                tryNum++;
                savedata = ForestMap.Generate(
                    prefab, max_map_width, max_map_height, choose_tasks, parameters.world_gen_choices,
                    parameters.level_type, level
                );

                if (savedata == null)
                {
                    if (tryNum > maxtries)
                    {
                        DebugPrint.print(string.Format(
                            "An error occured during world gen, giving up! [try %d of %d]\\n\\n\\n\\n",
                            tryNum, maxtries
                        ));
                        return null;
                    }
                    DebugPrint.print(string.Format(
                        "An error occured during world gen, we will retry! [try %d of %d]\n\n\n\n",
                        tryNum, maxtries
                    ));
                    //--assert(try <= maxtries, "Maximum world gen retries reached!")
                    WorldSim.ResetAll();
                }
                else if (GEN_PARAMETERS == "" || parameters.show_debug) ShowDebug(savedata);
            }
            
            DebugPrint.print(string.Format("Generated a world [try %d of %d]", tryNum, maxtries));

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