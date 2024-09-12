using System;
using System.Collections.Generic;

namespace DYT.Map.tasks
{
    public class PorklandTasks
    {
        static PorklandTasks()
        {
	        Tasks.AddTask("Edge_of_the_unknown", new Task
	        {
		        locks = { "NONE" },
		        keys_given = { "JUNGLE_DEPTH_1" },
		        room_choices=new Dictionary<string, int>{
			        ["BG_plains_base"] = 2,
		        },
		        room_bg = Constant.GROUND.PLAINS,
		        background_room = "BG_plains_base",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });

	        Tasks.AddTask("painted_sands", new Task
	        {
		        locks = { "JUNGLE_DEPTH_1" },
		        keys_given = { "JUNGLE_DEPTH_1" },
		        room_choices=new Dictionary<string, int>{
			        ["BG_painted_base"] = new Random().Next(2, 3),
			        ["BG_battleground_base"] = new Random().Next(0, 1),
			        ["battleground_ribs"] = 1,
			        ["battleground_claw"] = 1,
			        ["battleground_leg"] = 1,
		        },
		        room_bg = Constant.GROUND.PLAINS,
		        background_room = "BG_painted_base",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });
	        Tasks.AddTask("plains", new Task
	        {
		        locks = { "JUNGLE_DEPTH_1" },
		        keys_given = { "JUNGLE_DEPTH_1" },
		        room_choices=new Dictionary<string, int>{
			        ["plains_tallgrass"] = new Random().Next(2, 3),
			        ["plains_pogs"] = 1,
		        },
		        room_bg = Constant.GROUND.PLAINS,
		        background_room = "BG_plains_base",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });
	        Tasks.AddTask("rainforests", new Task
	        {
		        locks = { "JUNGLE_DEPTH_1" },
		        keys_given = { "JUNGLE_DEPTH_1" },
		        room_choices=new Dictionary<string, int>{
			        ["BG_rainforest_base"] = new Random().Next(2, 3),
		        },
		        room_bg = Constant.GROUND.PLAINS,
		        background_room = "BG_rainforest_base",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f },
	        });
	        Tasks.AddTask("rainforest_ruins", new Task
	        {
		        locks = { "JUNGLE_DEPTH_1" },
		        keys_given = { "JUNGLE_DEPTH_1" },
		        room_choices=new Dictionary<string, int>{
			        ["rainforest_ruins"] = new Random().Next(2, 3),
		        },
		        room_bg = Constant.GROUND.PLAINS,
		        background_room = "BG_rainforest_base",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });
	        Tasks.AddTask("plains_ruins", new Task
	        {
		        locks = { "JUNGLE_DEPTH_1" },
		        keys_given = { "JUNGLE_DEPTH_1" },
		        room_choices=new Dictionary<string, int>{
			        ["plains_ruins"] = new Random().Next(2, 3),
			        ["plains_pogs"] = new Random().Next(0, 1),
		        },
		        room_bg = Constant.GROUND.PLAINS,
		        background_room = "BG_plains_base",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });

	        Tasks.AddTask("Edge_of_civilization", new Task
	        {
		        locks = { "JUNGLE_DEPTH_1" },
		        keys_given = { "CIVILIZATION_1" },
		        room_choices=new Dictionary<string, int>{
			        ["cultivated_base_1"] = new Random().Next(3, 5),
			        ["piko_land"] = new Random().Next(2, 3),
		        },
		        room_bg = Constant.GROUND.FIELDS,
		        background_room = "cultivated_base_1",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });

	        Tasks.AddTask("Deep_rainforest", new Task
	        {
		        locks = { "JUNGLE_DEPTH_1" },
		        keys_given = { "JUNGLE_DEPTH_2", "JUNGLE_DEPTH_3" },
		        room_choices=new Dictionary<string, int>{
			        ["BG_rainforest_base"] = new Random().Next(2, 3),
			        ["BG_deeprainforest_base"] = 1,
			        ["deeprainforest_spider_monkey_nest"] = new Random().Next(1, 2),
			        ["deeprainforest_fireflygrove"] = new Random().Next(1, 1),
			        ["deeprainforest_flytrap_grove"] = new Random().Next(1, 2),
			        ["deeprainforest_anthill_exit"] = 1,
		        },
		        set_pieces =
		        {
			        new Task.Piece { name = "PigRuinsHead" },
			        new Task.Piece { name = "PigRuinsHead" },
			        new Task.Piece { name = "PigRuinsArtichoke" },
			        new Task.Piece { name = "PigRuinsArtichoke" },
		        },
		        room_bg = Constant.GROUND.DEEPRAINFOREST,
		        background_room = "BG_deeprainforest_base",
		        colour = { r = 0.2f, g = 0.6f, b = 0.2f, a = 0.3f }
	        });
	        Tasks.AddTask("Pigtopia", new Task
	        {
		        locks = { "CIVILIZATION_1" },
		        keys_given = { "CIVILIZATION_2" },
		        room_choices=new Dictionary<string, int>{
			        ["suburb_base_1"] = new Random().Next(2, 3),
		        },
		        room_bg = Constant.GROUND.SUBURB,
		        background_room = "suburb_base_1",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });
	        Tasks.AddTask("Pigtopia_capital", new Task
	        {
		        locks = { "CIVILIZATION_2" },
		        keys_given = { "ISLAND_2" },
		        room_choices=new Dictionary<string, int>{
			        ["city_base_1"] = new Random().Next(2, 3),
		        },
		        room_bg = Constant.GROUND.SUBURB,
		        background_room = "suburb_base_1",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });
	        Tasks.AddTask("Deep_lost_ruins_gas", new Task
	        {
		        locks = { "JUNGLE_DEPTH_3" },
		        keys_given = { "JUNGLE_DEPTH_3" },
		        room_choices=new Dictionary<string, int>{
			        ["deeprainforest_gas"] = new Random().Next(3, 4),
			        ["deeprainforest_gas_flytrap_grove"] = new Random().Next(2),
		        },
		        set_pieces =
		        {
			        new Task.Piece { name = "PigRuinsEntrance3" },
			        new Task.Piece { name = "PigRuinsHead" },
			        new Task.Piece { name = "PigRuinsArtichoke" },
			        new Task.Piece { name = "PigRuinsEntrance4" },
		        },
		        room_bg = Constant.GROUND.GASJUNGLE,
		        background_room = "deeprainforest_gas",
		        colour = { r = 0.8f, g = 0.6f, b = 0.2f, a = 0.3f }
	        });
	        Tasks.AddTask("Edge_of_the_unknown_2", new Task
	        {
		        locks = { "CIVILIZATION_1" },
		        keys_given = { "JUNGLE_DEPTH_1" },
		        room_choices=new Dictionary<string, int>{
			        ["BG_rainforest_base"] = new Random().Next(2, 3),
			        ["plains_tallgrass"] = new Random().Next(1, 2),
			        ["plains_pogs"] = new Random().Next(0, 2),
			        ["rainforest_ruins"] = new Random().Next(2, 3),
			        ["BG_painted_base"] = new Random().Next(1, 2),
			        ["BG_rainforest_base"] = new Random().Next(1, 3),

			        ["battleground_head"] = 1,
			        ["battleground_claw"] = 1,
			        ["battleground_leg"] = 1,
		        },
		        room_bg = Constant.GROUND.PLAINS,
		        background_room = "BG_plains_base",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });
	        Tasks.AddTask("Lilypond_land", new Task
	        {
		        locks = { "JUNGLE_DEPTH_1" },
		        keys_given = { "JUNGLE_DEPTH_2" },
		        room_choices=new Dictionary<string, int>{
			        ["rainforest_lillypond"] = new Random().Next(3, 5),
		        },
		        room_bg = Constant.GROUND.RAINFOREST,
		        background_room = "BG_rainforest_base",
		        colour = { r = 1, g = 0.3f, b = 0.3f, a = 0.3f }
	        });
	        Tasks.AddTask("Lilypond_land_2", new Task
	        {
		        locks = { "JUNGLE_DEPTH_1" },
		        keys_given = { "JUNGLE_DEPTH_2" },
		        room_choices=new Dictionary<string, int>{
			        ["rainforest_lillypond"] = new Random().Next(2, 3),
		        },
		        room_bg = Constant.GROUND.RAINFOREST,
		        background_room = "BG_rainforest_base",
		        colour = { r = 1, g = 0.3f, b = 0.3f, a = 0.3f }
	        });
	        Tasks.AddTask("this_is_how_you_get_ants", new Task
	        {
		        locks = { "JUNGLE_DEPTH_2" },
		        keys_given = { "JUNGLE_DEPTH_2", "JUNGLE_DEPTH_3" },
		        room_choices=new Dictionary<string, int>{
			        ["deeprainforest_anthill"] = 1,
		        },
		        room_bg = Constant.GROUND.DEEPRAINFOREST,
		        background_room = "BG_deeprainforest_base",
		        colour = { r = 0, g = 0, b = 1, a = 0.3f }
	        });
	        Tasks.AddTask("Deep_rainforest_2", new Task
	        {
		        locks = { "JUNGLE_DEPTH_1" },
		        keys_given = { "JUNGLE_DEPTH_2", "JUNGLE_DEPTH_3" },
		        room_choices=new Dictionary<string, int>{
			        ["BG_deeprainforest_base"] = new Random().Next(1, 2),
			        ["deeprainforest_spider_monkey_nest"] = new Random().Next(1, 2),
			        ["deeprainforest_fireflygrove"] = new Random().Next(0, 2),
			        ["deeprainforest_flytrap_grove"] = new Random().Next(1, 3),
			        ["deeprainforest_anthill_exit"] = 1,
		        },
		        set_pieces =
		        {
			        new Task.Piece { name = "PigRuinsEntrance2" },
			        new Task.Piece { name = "PigRuinsHead" },
			        new Task.Piece { name = "PigRuinsArtichoke" },
			        new Task.Piece { name = "PigRuinsArtichoke" },
		        },
		        room_bg = Constant.GROUND.DEEPRAINFOREST,
		        background_room = "BG_deeprainforest_base",
		        colour = { r = 0.2f, g = 0.6f, b = 0.2f, a = 0.3f }
	        });
	        Tasks.AddTask("Lost_Ruins_1", new Task
	        {
		        locks = { "JUNGLE_DEPTH_3" },
		        keys_given = { "NONE" },
		        room_choices=new Dictionary<string, int>{
			        ["deeprainforest_ruins_entrance"] = 1,
		        },
		        set_pieces =
		        {
			        new Task.Piece { name = "PigRuinsEntrance1" }
		        },
		        room_bg = Constant.GROUND.DEEPRAINFOREST,
		        background_room = "BG_deeprainforest_base",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });



	        Tasks.AddTask("Land_Divide_1", new Task
	        {
		        locks = { "ISLAND_2" },
		        keys_given = { "LAND_DIVIDE_1" },
		        room_choices=new Dictionary<string, int>{
			        ["ForceDisconnectedRoom"] = 5, //--20, 
		        },
		        room_bg = Constant.GROUND.DEEPRAINFOREST,
		        background_room = "ForceDisconnectedRoom",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });

			/*--[[
			for i=1,49 do
				AddTask("Land_Divide_1_"..i, {
					locks={
						LOCKS.ISLAND_2,
						LOCKS.JUNGLE_DEPTH_1,
						LOCKS.JUNGLE_DEPTH_2,
						LOCKS.JUNGLE_DEPTH_3,
						LOCKS.CIVILIZATION_1,
						LOCKS.CIVILIZATION_2,
						LOCKS.RUINS_ENTRANCE_1,
						LOCKS.RUINS_EXIT_1,
					},
					keys_given={"LAND_DIVIDE_1"},
					room_choices=new Dictionary<string, int>{ 
						["ForceDisconnectedRoom"] = 1, 
					},  
					room_bg=Constant.GROUND.DEEPRAINFOREST,
					background_room="ForceDisconnectedRoom",
					colour={r=1,g=1,b=1,a=0.3f}
				}) 
			end
			]]*/

			//-- THE OTHER PIG CITY
	        Tasks.AddTask("Deep_rainforest_3", new Task
	        {
		        locks = { "LAND_DIVIDE_1" },
		        keys_given = { "OTHER_JUNGLE_DEPTH_2" },
		        //--	entrance_room = "ForceDisconnectedRoom",   --  THIS IS HOW THEY ARE ON SEPARATE ISLANDS
		        room_choices=new Dictionary<string, int>{
			        ["BG_deeprainforest_base"] = new Random().Next(2, 4),
			        ["deeprainforest_fireflygrove"] = new Random().Next(0, 1),
			        ["deeprainforest_flytrap_grove"] = new Random().Next(1, 2),
			        //--	["deeprainforest_ruins_exit"] = 1, 
		        },
		        set_pieces =
		        {
			        new Task.Piece { name = "PigRuinsExit1" },
			        new Task.Piece { name = "PigRuinsHead" },
			        new Task.Piece { name = "PigRuinsArtichoke" },
			        new Task.Piece { name = "PigRuinsArtichoke" },
		        },
		        room_bg = Constant.GROUND.DEEPRAINFOREST,
		        background_room = "BG_deeprainforest_base",
		        colour = { r = 0.2f, g = 0.6f, b = 0.2f, a = 0.3f }
	        });

	        Tasks.AddTask("Deep_rainforest_mandrake", new Task
	        {
		        locks = { "OTHER_JUNGLE_DEPTH_2" },
		        keys_given = { "NONE" },
		        //--	entrance_room = "ForceDisconnectedRoom",   --  THIS IS HOW THEY ARE ON SEPARATE ISLANDS
		        room_choices=new Dictionary<string, int>{
			        ["deeprainforest_mandrakeman"] = 1,
		        },
		        set_pieces =
		        {
			        new Task.Piece { name = "mandraketown" },
		        },
		        room_bg = Constant.GROUND.DEEPRAINFOREST,
		        background_room = "BG_deeprainforest_base",
		        colour = { r = 0.2f, g = 0.6f, b = 0.2f, a = 0.3f }
	        });


	        Tasks.AddTask("Path_to_the_others", new Task
	        {
		        locks = { "OTHER_JUNGLE_DEPTH_2" },
		        keys_given = { "OTHER_JUNGLE_DEPTH_1" },
		        room_choices=new Dictionary<string, int>{
			        ["BG_plains_base"] = new Random().Next(1, 2),
			        ["plains_tallgrass"] = new Random().Next(1, 2),
			        ["plains_pogs"] = new Random().Next(1, 2),
		        },
		        room_bg = Constant.GROUND.RAINFOREST,
		        background_room = "BG_rainforest_base",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });

	        Tasks.AddTask("Other_edge_of_civilization", new Task
	        {
		        locks = { "OTHER_JUNGLE_DEPTH_1" },
		        keys_given = { "OTHER_CIVILIZATION_1" },
		        room_choices=new Dictionary<string, int>{
			        ["cultivated_base_2"] = new Random().Next(1, 3),
		        },
		        room_bg = Constant.GROUND.FIELDS,
		        background_room = "cultivated_base_2",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });

	        Tasks.AddTask("Other_pigtopia", new Task
	        {
		        locks = { "OTHER_CIVILIZATION_1" },
		        keys_given = { "OTHER_CIVILIZATION_2" },
		        room_choices=new Dictionary<string, int>{
			        ["suburb_base_2"] = new Random().Next(2, 3),
		        },
		        room_bg = Constant.GROUND.SUBURB,
		        background_room = "suburb_base_2",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });

	        Tasks.AddTask("Other_pigtopia_capital", new Task
	        {
		        locks = { "OTHER_CIVILIZATION_2" },
		        keys_given = { "ISLAND_3" },
		        room_choices=new Dictionary<string, int>{
			        ["city_base_2"] = new Random().Next(2, 3),
		        },
		        room_bg = Constant.GROUND.SUBURB,
		        background_room = "suburb_base_2",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });

	        Tasks.AddTask("Land_Divide_2", new Task
	        {
		        locks = { "ISLAND_3" },
		        keys_given = { "LAND_DIVIDE_2" },
		        room_choices=new Dictionary<string, int>{
			        ["ForceDisconnectedRoom"] = 5, //--20, 
		        },
		        room_bg = Constant.GROUND.DEEPRAINFOREST,
		        background_room = "ForceDisconnectedRoom",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });

			//-- Other Jungle 
	        Tasks.AddTask("Deep_lost_ruins4", new Task
	        {
		        locks = { "LAND_DIVIDE_2" },
		        keys_given = { "LOST_JUNGLE_DEPTH_2" },
//--		entrance_room = "ForceDisconnectedRoom", --  THIS IS HOW THEY ARE ON SEPARATE ISLANDS
		        room_choices=new Dictionary<string, int>{
			        ["BG_deeprainforest_base"] = new Random().Next(2, 4),
			        ["deeprainforest_flytrap_grove"] = new Random().Next(2, 3),
		        },
		        set_pieces =
		        {
			        new Task.Piece { name = "PigRuinsExit2" },
			        new Task.Piece { name = "PigRuinsHead" },
			        new Task.Piece { name = "PigRuinsArtichoke" },
			        new Task.Piece { name = "PigRuinsArtichoke" },
			        new Task.Piece { name = "nettlegrove" },
			        new Task.Piece { name = "nettlegrove" },
		        },
		        room_bg = Constant.GROUND.DEEPRAINFOREST,
		        background_room = "BG_deeprainforest_base",
		        colour = { r = 0.2f, g = 0.6f, b = 0.2f, a = 0.3f }
	        });

	        Tasks.AddTask("lost_rainforest", new Task
	        {
		        locks = { "LOST_JUNGLE_DEPTH_2" },
		        keys_given = { "ISLAND_4" },
		        room_choices=new Dictionary<string, int>{
			        ["BG_plains_base"] = new Random().Next(1, 4),
			        ["rainforest_lillypond"] = new Random().Next(2, 4),
		        },
		        set_pieces =
		        {
			        new Task.Piece { name = "fountain_of_youth" },
			        new Task.Piece { name = "pig_ruins_nocanopy" },
			        new Task.Piece { name = "pig_ruins_nocanopy_2" },
			        new Task.Piece { name = "pig_ruins_nocanopy_2" },
			        new Task.Piece { name = "pig_ruins_nocanopy_3" },
			        new Task.Piece { name = "pig_ruins_nocanopy_3" },
			        new Task.Piece { name = "pig_ruins_nocanopy_4" },
			        new Task.Piece { name = "pig_ruins_nocanopy_4" },
		        },
		        room_bg = Constant.GROUND.RAINFOREST,
		        background_room = "BG_rainforest_base",
		        colour = { r = 0.2f, g = 0.6f, b = 0.2f, a = 0.3f }
	        });

	        Tasks.AddTask("Land_Divide_3", new Task
	        {
		        locks = { "ISLAND_4" },
		        keys_given = { "LAND_DIVIDE_3" },
		        room_choices=new Dictionary<string, int>{
			        ["ForceDisconnectedRoom"] = 20,
		        },
		        room_bg = Constant.GROUND.DEEPRAINFOREST,
		        background_room = "ForceDisconnectedRoom",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });

			//-- BFB nest area
	        Tasks.AddTask("pincale", new Task
	        {
		        locks = { "LAND_DIVIDE_3" },
		        keys_given = { "PINACLE" },
		        room_choices=new Dictionary<string, int>{
			        ["BG_pinacle_base"] = 1,
		        },
		        set_pieces =
		        {
			        new Task.Piece { name = "roc_nest" },
			        new Task.Piece { name = "roc_cave" },
		        },
		        room_bg = Constant.GROUND.ROCKY,
		        background_room = "BG_pinacle_base",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });

	        Tasks.AddTask("Land_Divide_4", new Task
	        {
		        locks = { "PINACLE" },
		        keys_given = { "LAND_DIVIDE_4" },
		        room_choices=new Dictionary<string, int>{
			        ["ForceDisconnectedRoom"] = 20,
		        },
		        room_bg = Constant.GROUND.DEEPRAINFOREST,
		        background_room = "ForceDisconnectedRoom",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });



			//-- Other Jungle 
	        Tasks.AddTask("Deep_wild_ruins4", new Task
	        {
		        locks = { "LAND_DIVIDE_4" },
		        keys_given = { "WILD_JUNGLE_DEPTH_1" },
//--		entrance_room = "ForceDisconnectedRoom", --  THIS IS HOW THEY ARE ON SEPARATE ISLANDS
		        room_choices=new Dictionary<string, int>{
			        ["deeprainforest_base_nobatcave"] = new Random().Next(2, 4),
			        ["deeprainforest_flytrap_grove"] = new Random().Next(2, 3),
		        },
		        set_pieces =
		        {
			        new Task.Piece { name = "PigRuinsExit4" },
		        },
		        room_bg = Constant.GROUND.DEEPRAINFOREST,
		        background_room = "deeprainforest_base_nobatcave",
		        colour = { r = 0.2f, g = 0.6f, b = 0.2f, a = 0.3f }
	        });

	        Tasks.AddTask("wild_rainforest", new Task
	        {
		        locks = { "WILD_JUNGLE_DEPTH_1" },
		        keys_given = { "WILD_JUNGLE_DEPTH_2" },
		        room_choices=new Dictionary<string, int>{
			        ["plains_base_nobatcave"] = new Random().Next(3, 4),
			        ["rainforest_lillypond"] = new Random().Next(3, 4),
			        ["painted_base_nobatcave"] = new Random().Next(3, 4),
			        ["rainforest_base_nobatcave"] = new Random().Next(3, 4),
		        },
		        room_bg = Constant.GROUND.RAINFOREST,
		        background_room = "rainforest_base_nobatcave",
		        colour = { r = 0.2f, g = 0.6f, b = 0.2f, a = 0.3f }
	        });
	        Tasks.AddTask("wild_ancient_ruins", new Task
	        {
		        locks = { "WILD_JUNGLE_DEPTH_2" },
		        keys_given = { "ISLAND_5" },
		        room_choices=new Dictionary<string, int>{
			        ["deeprainforest_flytrap_grove"] = new Random().Next(4, 5),
		        },
		        set_pieces =
		        {
			        new Task.Piece { name = "PigRuinsEntrance5" },
		        },
		        room_bg = Constant.GROUND.RAINFOREST,
		        background_room = "rainforest_base_nobatcave",
		        colour = { r = 0.2f, g = 0.6f, b = 0.2f, a = 0.3f }
	        });

	        Tasks.AddTask("Land_Divide_5", new Task
	        {
		        locks = { "ISLAND_5" },
		        keys_given = { "LAND_DIVIDE_5" },
		        room_choices=new Dictionary<string, int>{
			        ["ForceDisconnectedRoom"] = 20,
		        },
		        room_bg = Constant.GROUND.DEEPRAINFOREST,
		        background_room = "ForceDisconnectedRoom",
		        colour = { r = 1, g = 1, b = 1, a = 0.3f }
	        });
        }
    }
}