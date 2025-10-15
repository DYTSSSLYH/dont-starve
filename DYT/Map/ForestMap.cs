using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Random = UnityEngine.Random;

namespace DYT.Map
{
    class StoryGenParams
    {
        public int impassible_value;
        public string level_type;
        public string start_setpeice;
    }
    
    public class ForestMap
    {
        public static
            Func<string, int, int, List<Task>, CustomScreen.ChangedOption, string, Level, object> Generate;
        public static Dictionary<string, float> MULTIPLY = new()
        {
            ["never"] = 0,
            ["rare"] = 0.5f,
            ["default"] = 1,
            ["often"] = 1.5f,
            ["mostly"] = 1.67f, //-- Not sure this is getting used...?
            ["always"] = 2,
        };
        
        private static bool SKIP_GEN_CHECKS = false;
        private static string level_type = "";
        private static List<string> merm = new(){ "mermhouse" };
        private static List<string> trees = new()
        {
            "evergreen", "evergreen_sparse", "deciduoustree", "marsh_tree"
        };
        private static List<string> rocks = new(){"rocks", "rock1", "rock2", "rock_flintless"};
        private static List<string> grass = new(){"grass","grass_tall","grass_tall_patch"};
        private static Customise customise;

        
        static ForestMap()
        {
            new Water();
            new TreasureHunt();


            if (!string.IsNullOrWhiteSpace(WorldGenMain.GEN_PARAMETERS))
            {
                GenParameters parameters =
                    JsonConvert.DeserializeObject<GenParameters>(WorldGenMain.GEN_PARAMETERS);
                level_type = parameters.level_type;
            }

            if (level_type == "shipwrecked" || level_type == "volcano")
            {
                merm = new List<string> { "mermhouse_fisher" };
                trees = new List<string> { "jungletree", "palmtree", "mangrovetree" };
                rocks = new List<string>
                {
                    "rocks", "rock1", "rock2", "rock_flintless", "magmarock", "magmarock_gold"
                };
                grass = new List<string> { "grass", "grass_water" };
            }


            customise = new CustomisePork();

            Generate = GenerateVoro;
        }


        private static string pickspawnprefab(Dictionary<string, int> items_in, int ground_type)
        {
            Dictionary<string, int> items = new Dictionary<string, int>();
            if (ground_type != null)
            {
                //-- Filter the items
                foreach ((string item, object v) in items_in)
                {
                    items.Add(item, items_in[item]);
                    if (Terrain.terrain.filter[item] != null)
                    {
                        foreach (int gt in Terrain.terrain.filter[item])
                        {
                            if (gt == ground_type) items.Remove(item);
                            //--print ("Filtered", item, GROUND_NAMES[ground_type],
                            //" (".. terrain.filter.Print(terrain.filter[item])..")")
                        }
                    }
                }
            }
            int total = 0;
            foreach ((string key, int value) in items) total += value;
            if (total > 0)
            {
                float rnd = Random.value * total;
                foreach ((string key, int value) in items)
                {
                    rnd -= value;
                    if (rnd <= 0) return key;
                }
            }

            return null;
        }

        private static Task.Substitute pickspawngroup(Dictionary<string, Task.Substitute> groups)
        {
            foreach ((string key, Task.Substitute value) in groups)
                if (Random.value < value.percent) return value;
            
            return null;
        }

        private static object GenerateVoro(string prefab, int map_width, int map_height, List<Task> tasks,
            CustomScreen.ChangedOption world_gen_choices, string level_type, Level level)
        {
            float start_time = MainFunctions.GetTimeReal();

            object check_col = new object();

            CustomScreen.ChangedOption current_gen_params = Util.deepcopy(world_gen_choices);

            object start_node_override = null;
            object islandpercent = null;
            Dictionary<string, object> story_gen_params = new Dictionary<string, object>();

            int defalt_impassible_tile = Constant.GROUND.IMPASSABLE;
            if (prefab == "cave") defalt_impassible_tile = Constant.GROUND.WALL_ROCKY;
            else if (prefab == "shipwrecked") defalt_impassible_tile = Constant.GROUND.IMPASSABLE;
            else if (prefab == "porkland")
            {
                WorldSim.AddIslandRegionMapping("Edge_of_the_unknown", 			"A");
                WorldSim.AddIslandRegionMapping("painted_sands", 				"A");
                WorldSim.AddIslandRegionMapping("plains", 						"A");
                WorldSim.AddIslandRegionMapping("rainforests", 					"A");
                WorldSim.AddIslandRegionMapping("rainforest_ruins", 			"A");
                WorldSim.AddIslandRegionMapping("plains_ruins", 				"A");  
                WorldSim.AddIslandRegionMapping("Edge_of_civilization", 		"A");  
                WorldSim.AddIslandRegionMapping("Deep_rainforest", 				"A");
                WorldSim.AddIslandRegionMapping("Pigtopia", 					"A");
                WorldSim.AddIslandRegionMapping("Pigtopia_capital", 			"A");
                WorldSim.AddIslandRegionMapping("Deep_lost_ruins_gas", 			"A");		
                WorldSim.AddIslandRegionMapping("Edge_of_the_unknown_2", 		"A");
                WorldSim.AddIslandRegionMapping("Lilypond_land", 				"A");				
                WorldSim.AddIslandRegionMapping("Lilypond_land_2", 				"A");	
                WorldSim.AddIslandRegionMapping("this_is_how_you_get_ants", 	"A");
                WorldSim.AddIslandRegionMapping("Deep_rainforest_2", 			"A");
                WorldSim.AddIslandRegionMapping("Lost_Ruins_1", 				"A");
                WorldSim.AddIslandRegionMapping("Lost_Ruins_4", 				"A");		

                WorldSim.AddIslandRegionMapping("Deep_rainforest_3", 			"B");		
                WorldSim.AddIslandRegionMapping("Deep_rainforest_mandrake", 	"B");			
                WorldSim.AddIslandRegionMapping("Path_to_the_others", 			"B");
                WorldSim.AddIslandRegionMapping("Other_edge_of_civilization", 	"B");
                WorldSim.AddIslandRegionMapping("Other_pigtopia", 				"B");
                WorldSim.AddIslandRegionMapping("Other_pigtopia_capital", 		"B");

                WorldSim.AddIslandRegionMapping("Deep_lost_ruins4", 			"C");		
                WorldSim.AddIslandRegionMapping("lost_rainforest", 				"C");

                WorldSim.AddIslandRegionMapping("pincale", "E");

                WorldSim.AddIslandRegionMapping("Deep_wild_ruins4", 			"F");
                WorldSim.AddIslandRegionMapping("wild_rainforest", 			    "F");
                WorldSim.AddIslandRegionMapping("wild_ancient_ruins", 			"F");
            }

            story_gen_params["impassible_value"] = defalt_impassible_tile;
            story_gen_params["level_type"] = level_type;

            if (current_gen_params.tweak != null && current_gen_params.tweak["misc"] != null)
            {
                if (current_gen_params.tweak["misc"]["start_setpeice"] != null)
                {
                    story_gen_params["start_setpeice"] = current_gen_params.tweak["misc"]["start_setpeice"];
                    current_gen_params.tweak["misc"]["start_setpeice"] = null;
                }
                
                if (current_gen_params.tweak["misc"]["start_node"] != null)
                {
                    story_gen_params["start_node"] = current_gen_params.tweak["misc"]["start_node"];
                    current_gen_params.tweak["misc"]["start_node"] = null;
                }
                
                if (current_gen_params.tweak["misc"]["start_task"] != null)
                {
                    story_gen_params["start_task"] = current_gen_params.tweak["misc"]["start_task"];
                    current_gen_params.tweak["misc"]["start_task"] = null;
                }
                
                if (current_gen_params.tweak["misc"]["islands"] != null)
                {
                    Dictionary<string, float> percent = new Dictionary<string, float>()
                    {
                        ["always"] = 1, ["never"] = 0, ["default"] = 0.2f,
                        ["sometimes"] = 0.1f, ["often"] = 0.8f
                    };
                    story_gen_params["islands"] = percent[current_gen_params.tweak["misc"]["islands"]];
                    current_gen_params.tweak["misc"]["islands"] = null;
                }
                
                if (current_gen_params.tweak["misc"]["branching"] != null)
                {
                    story_gen_params["branching"] = current_gen_params.tweak["misc"]["branching"];
                    current_gen_params.tweak["misc"]["branching"] = null;
                }
                
                if (current_gen_params.tweak["misc"]["world_size"] != null)
                {
                    story_gen_params["world_size"] = current_gen_params.tweak["misc"]["world_size"];
                    current_gen_params.tweak["misc"]["world_size"] = null;
                }
                
                if (current_gen_params.tweak["misc"]["loop"] != null)
                {
                    Dictionary<string, float> loop_percent = new()
                    {
                        ["never"] = 0, ["default"] = 0, ["always"] = 1,
                    };
                    Dictionary<string, string> loop_target = new ()
                    {
                        ["never"] = "any", ["default"] = null, ["always"] = "end",
                    };
                    story_gen_params["loop_percent"] = loop_percent[current_gen_params.tweak["misc"]["loop"]];
                    story_gen_params["loop_target"] = loop_target[current_gen_params.tweak["misc"]["loop"]];
                    current_gen_params.tweak["misc"]["loop"] = null;
                }
            }
            
            DebugPrint.print("Creating story...");
            object topology_save;

            if (prefab == "shipwrecked")
                topology_save = StoryGen.SHIPWRECKED_STORY(tasks, story_gen_params, level);
            else if (prefab == "volcanolevel")
                topology_save = StoryGen.VOLCANO_STORY(tasks, story_gen_params, level);
            else if (prefab == "porkland")
                topology_save = StoryGen.PORKLAND_STORY(tasks, story_gen_params, level);
            else topology_save = StoryGen.DEFAULT_STORY(tasks, story_gen_params, level);

            return null;
        }
    }
}