using System.Collections.Generic;

namespace DYT.Map.tasks
{
    public class IsLandHoppingTasks
    {
        static IsLandHoppingTasks()
        {
            //------------------------------------------------------------
			//-- Island Hopping
			//------------------------------------------------------------

			Tasks.AddTask("IslandHop_Start", new Task
			{
				//-- Sweet starting node, horrid other than that (leave the island)
				locks = { "NONE" },
				keys_given = { "MEAT" },
				room_choices=new Dictionary<string, int>{
					["SpiderMarsh"] = 1 + WorldGenMain.random.Next(2),
				},
				room_bg = Constant.GROUND.DIRT,
				background_room = "BGMarsh",
				colour =
				{
					r = WorldGenMain.random.Next(),
					g = WorldGenMain.random.Next(),
					b = WorldGenMain.random.Next(),
					a = WorldGenMain.random.Next()
				},
			});

			Tasks.AddTask("IslandHop_Hounds", new Task
			{
				locks = { "MEAT" },
				keys_given = { "MEAT" },
				entrance_room = { "ForceDisconnectedRoom" },
				room_choices=new Dictionary<string, int>{
					["SpiderForest"] = 1 + WorldGenMain.random.Next(2),
				},
				room_bg = Constant.GROUND.DIRT,
				background_room = "BGBadlands",
				colour =
				{
					r = WorldGenMain.random.Next(),
					g = WorldGenMain.random.Next(),
					b = WorldGenMain.random.Next(),
					a = WorldGenMain.random.Next()
				},
			});

			Tasks.AddTask("IslandHop_Forest", new Task
			{
				locks = { "MEAT" },
				keys_given = { "MEAT" },
				entrance_room = { "ForceDisconnectedRoom" },
				room_choices=new Dictionary<string, int>{
					["Waspnests"] = 1 + WorldGenMain.random.Next(2),
				},
				//-- room_choices=new Dictionary<string, int>{
				//-- 	["DeepForest"] = 1+WorldGenMain.random.Next(2), 
				//-- },
				room_bg = Constant.GROUND.DIRT,
				background_room = "BGDeepForest",
				colour =
				{
					r = WorldGenMain.random.Next(), g = WorldGenMain.random.Next(), b = WorldGenMain.random.Next(),
					a = WorldGenMain.random.Next()
				},
			});

			Tasks.AddTask("IslandHop_Savanna", new Task
			{
				locks = { "MEAT" },
				keys_given = { "MEAT" },
				entrance_room = { "ForceDisconnectedRoom" },
				room_choices=new Dictionary<string, int>{
					["BeefalowPlain"] = 1 + WorldGenMain.random.Next(2),
				},
				//-- room_choices=new Dictionary<string, int>{
				//-- 	["BeefalowPlain"] = 1+WorldGenMain.random.Next(2), 
				//-- },
				room_bg = Constant.GROUND.DIRT,
				background_room = "BGSavanna",
				colour =
				{
					r = WorldGenMain.random.Next(), g = WorldGenMain.random.Next(), b = WorldGenMain.random.Next(),
					a = WorldGenMain.random.Next()
				},
			});

			Tasks.AddTask("IslandHop_Rocky", new Task
			{
				locks = { "MEAT" },
				keys_given = { "MEAT" },
				entrance_room = { "ForceDisconnectedRoom" },
				room_choices=new Dictionary<string, int>{
					["Rocky"] = 1 + WorldGenMain.random.Next(2),
				},
				room_bg = Constant.GROUND.DIRT,
				background_room = "BGRocky",
				colour =
				{
					r = WorldGenMain.random.Next(), g = WorldGenMain.random.Next(), b = WorldGenMain.random.Next(),
					a = WorldGenMain.random.Next()
				},
			});

			Tasks.AddTask("IslandHop_Merm", new Task
			{
				locks = { "MEAT" },
				keys_given = { "MEAT" },
				entrance_room = { "ForceDisconnectedRoom" },
				room_choices=new Dictionary<string, int>{
					["SlightlyMermySwamp"] = 1 + WorldGenMain.random.Next(2),
				},
				room_bg = Constant.GROUND.DIRT,
				background_room = "BGMarsh",
				colour =
				{
					r = WorldGenMain.random.Next(), g = WorldGenMain.random.Next(), b = WorldGenMain.random.Next(),
					a = WorldGenMain.random.Next()
				},
			});
        }
    }
}