using System.Collections.Generic;

namespace DYT.Map.tasks
{
    public class RuinsTasks
    {
        static RuinsTasks()
        {
			//------------------------------------------------------------
			//-- Caves Ruins Level
			//------------------------------------------------------------
			//-- Tasks.AddTask("CityInRuins",new Task{
			//-- 		locks={"RUINS"},
			//-- 		keys_given={"RUINS"},
			//-- 		entrance_room={"RuinedCityEntrance"},
			//-- 		room_choices=new Dictionary<string, int>{
			//-- 			["BGMaze"] = 10+WorldGenMain.random.Next(Tasks.SIZE_VARIATION), 
			//-- 		},
			//-- 		room_bg=GROUND.TILES,
			//-- 		maze_tiles = {rooms={"default", "hallway_shop", "hallway_residential", "room_residential" }, bosses={"room_residential"}},
			//-- 		background_room="BGMaze",
			//-- 		colour={r=1,g=0,b=0.6f,a=1},
			//-- 	})
			//-- Tasks.AddTask("AlterAhead",new Task{
			//-- 		locks={"RUINS"},
			//-- 		keys_given={"RUINS"},
			//-- 		entrance_room={"LabyrinthCityEntrance"},
			//-- 		room_choices=new Dictionary<string, int>{
			//-- 			["BGMaze"] = 6+WorldGenMain.random.Next(Tasks.SIZE_VARIATION), 
			//-- 		},
			//-- 		room_bg=GROUND.TILES,
			//-- 		maze_tiles = {rooms={"default", "hallway", "hallway_armoury", "room_armoury" }, bosses={"room_armoury"}} ,
			//-- 		background_room="BGMaze",
			//-- 		colour={r=1,g=0,b=0.6f,a=1},
			//-- 	})
			//-- Tasks.AddTask("TownSquare",new Task{
			//-- 		locks = {"LABYRINTH"},
			//-- 		keys_given={"NONE"},
			//-- 		entrance_room={"RuinedCityEntrance"},
			//-- 		room_choices =
			//-- 		{
			//-- 			["BGMaze"] = 6+WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			//-- 		},
			//-- 		room_bg = GROUND.TILES,
			//-- 		maze_tiles = {"room_open"},
			//-- 		background_room="BGMaze",
			//-- 		colour={r=1,g=0,b=0.6f,a=1},
			//-- 	})
			Tasks.AddTask("RuinsStart", new Task
			{
				locks = { "NONE" },
				keys_given = { "LABYRINTH", "RUINS" },
				room_choices=new Dictionary<string, int>{
					["PondWilds"] = WorldGenMain.random.Next(1, 3),
					["SlurperWilds"] = WorldGenMain.random.Next(1, 3),
					["LushWilds"] = WorldGenMain.random.Next(1, 2),
					["LightWilds"] = WorldGenMain.random.Next(1, 3),
				},
				room_bg = Constant.GROUND.MUD,
				background_room = "BGWilds",
				colour = { r = 1, g = 0, b = 0.6f, a = 1 },
			});
			Tasks.AddTask("TheLabyrinth", new Task
			{
				locks = { "LABYRINTH" },
				keys_given = { "SACRED" },
				entrance_room = { "LabyrinthEntrance" },
				room_choices=new Dictionary<string, int>{
					["BGLabyrinth"] = 3 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["LabyrinthGuarden"] = 1,
				},
				room_bg = Constant.GROUND.BRICK,
				background_room = "BGLabyrinth",
				colour = { r = 1, g = 0, b = 0.6f, a = 1 },
			});

			Tasks.AddTask("Residential", new Task
			{
				locks = { "RUINS" },
				keys_given = { "NONE" },
				entrance_room = { "RuinedCityEntrance" },
				room_choices=new Dictionary<string, int>{
					["Vacant"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["BGMonkeyWilds"] = 4 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.TILES,
				maze_tiles =
				{
					rooms =
					{
						"room_residential", "room_residential_two", "hallway_residential", "hallway_residential_two"
					},
					bosses = { "room_residential" }
				},
				background_room = "BGMonkeyWilds",
				colour = { r = 1, g = 0, b = 0.6f, a = 1 },
			});


			Tasks.AddTask("Military", new Task
			{
				locks = { "RUINS" },
				keys_given = { "NONE" },
				entrance_room = { "MilitaryEntrance" },
				room_choices=new Dictionary<string, int>{
					["BGMilitary"] = 4 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.TILES,
				maze_tiles =
				{
					rooms = { "room_armoury", "hallway_armoury", "room_armoury_two" }, bosses = { "room_armoury_two" }
				},
				background_room = "BGMilitary",
				colour = { r = 1, g = 0, b = 0.6f, a = 1 },
			});

			Tasks.AddTask("Sacred", new Task
			{
				locks = { "SACRED" },
				keys_given = { "SACRED" },
				room_choices=new Dictionary<string, int>{
					["Barracks"] = WorldGenMain.random.Next(1, 2),
					["Bishops"] = WorldGenMain.random.Next(1, 2),
					["Spiral"] = WorldGenMain.random.Next(1, 2),
					["BrokenAltar"] = WorldGenMain.random.Next(1, 2),
					["Altar"] = 1
				},
				room_bg = Constant.GROUND.TILES,
				background_room = "BGSacredGround",
				colour = { r = 1, g = 0, b = 0.6f, a = 1 },
			});




			//----Optional Ruins Tasks----



			Tasks.AddTask("MoreAltars", new Task
			{
				locks = { "SACRED" },
				keys_given = { "SACRED" },
				room_choices=new Dictionary<string, int>{
					["BrokenAltar"] = WorldGenMain.random.Next(1, 2),
					["Altar"] = WorldGenMain.random.Next(1, 2)
				},
				room_bg = Constant.GROUND.TILES,
				background_room = "BGSacredGround",
				colour = { r = 1, g = 0, b = 0.6f, a = 1 },
			});
			Tasks.AddTask("SacredDanger", new Task
			{
				locks = { "SACRED" },
				keys_given = { "SACRED" },
				room_choices=new Dictionary<string, int>{
					["Barracks"] = WorldGenMain.random.Next(1, 2),
				},
				room_bg = Constant.GROUND.TILES,
				background_room = "BGSacredGround",
				colour = { r = 1, g = 0, b = 0.6f, a = 1 },
			});
			Tasks.AddTask("FailedCamp", new Task
			{
				locks = { "RUINS" },
				keys_given = { "NONE" },
				room_choices=new Dictionary<string, int>{
					["RuinsCamp"] = 1,
				},
				room_bg = Constant.GROUND.MUD,
				background_room = "BGWilds",
				colour = { r = 1, g = 0, b = 0.6f, a = 1 },
			});

			Tasks.AddTask("Military2", new Task
			{
				locks = { "RUINS" },
				keys_given = { "NONE" },
				entrance_room = { "MilitaryEntrance" },
				room_choices=new Dictionary<string, int>{
					["BGMilitary"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.TILES,
				maze_tiles =
				{
					rooms = { "room_armoury", "hallway_armoury", "room_armoury_two" }, bosses = { "room_armoury_two" }
				},
				background_room = "BGMilitary",
				colour = { r = 1, g = 0, b = 0.6f, a = 1 },
			});
			Tasks.AddTask("Sacred2", new Task
			{
				locks = { "SACRED" },
				keys_given = { "SACRED" },
				room_choices=new Dictionary<string, int>{
					["Barracks"] = WorldGenMain.random.Next(1, 2),
					["Bishops"] = WorldGenMain.random.Next(1, 2),
					["Spiral"] = WorldGenMain.random.Next(1, 2),
					["BrokenAltar"] = WorldGenMain.random.Next(1, 2),
				},
				room_bg = Constant.GROUND.TILES,
				background_room = "BGSacredGround",
				colour = { r = 1, g = 0, b = 0.6f, a = 1 },
			});

			Tasks.AddTask("Residential2", new Task
			{
				locks = { "RUINS" },
				keys_given = { "NONE" },
				entrance_room = { "RuinedCityEntrance" },
				room_choices=new Dictionary<string, int>{
					["BGMonkeyWilds"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.TILES,
				maze_tiles =
				{
					rooms =
					{
						"room_residential", "room_residential_two", "hallway_residential", "hallway_residential_two"
					},
					bosses = { "room_residential" }
				},
				background_room = "BGMonkeyWilds",
				colour = { r = 1, g = 0, b = 0.6f, a = 1 },
			});

			Tasks.AddTask("Residential3", new Task
			{
				locks = { "RUINS" },
				keys_given = { "NONE" },
				room_choices=new Dictionary<string, int>{
					["Vacant"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.TILES,
				background_room = "BGWilds",
				colour = { r = 1, g = 0, b = 0.6f, a = 1 },
			});
        }
    }
}