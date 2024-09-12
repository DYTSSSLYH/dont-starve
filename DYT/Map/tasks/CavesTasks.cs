using System.Collections.Generic;

namespace DYT.Map.tasks
{
    public class CavesTasks
    {
        static CavesTasks()
        {
			//------------------------------------------------------------
			//-- Caves Initial Level
			//------------------------------------------------------------
	        Tasks.AddTask("CavesStart", new Task
	        {
		        locks = { "NONE" },
		        keys_given = { "LIGHT" },
		        room_choices=new Dictionary<string, int>{
			        ["MistyCavern"] = WorldGenMain.random.Next(2),
			        ["PitCave"] = WorldGenMain.random.NextDouble() > 0.5f ? 1 : 0,
			        ["RockLobsterPlains"] = 1,
			        //--["BGCaveRoom"] = 4+WorldGenMain.random.Next(2),
		        },
		        room_bg = Constant.GROUND.WALL_ROCKY,
		        background_room = "BGCaveRoom",
		        colour = { r = 1, g = 0.7f, b = 1, a = 1 },
	        });

	        Tasks.AddTask("CavesAlternateStart", new Task
	        {
		        locks = { "NONE" },
		        keys_given = { "LIGHT" },
		        room_choices=new Dictionary<string, int>{
			        ["SinkholeRoom"] = 3 + WorldGenMain.random.Next(2),
			        ["MistyCavern"] = 1,
			        ["RockLobsterPlains"] = 1 + WorldGenMain.random.Next(2),
		        },
		        room_bg = Constant.GROUND.SINKHOLE,
		        background_room = "BGCaveRoom",
		        colour = { r = 1, g = 0.5f, b = 1, a = 1 },
	        });

	        Tasks.AddTask("BatCaves", new Task
	        {
		        locks = { "LIGHT" },
		        keys_given = { "CAVE" },
		        entrance_room = { "BatCaveRoomAntichamber" },
		        room_choices=new Dictionary<string, int>{
			        //--["CaveRoom"] = 2+WorldGenMain.random.Next(2),
			        ["BatCaveRoom"] = 2 + WorldGenMain.random.Next(2),
		        },
		        room_bg = Constant.GROUND.CAVE,
		        background_room = "BGCaveRoom",
		        colour = { r = 1, g = 0.6f, b = 1, a = 1 },
	        });

	        Tasks.AddTask("FungalBatCave", new Task
	        {
		        locks = { "LIGHT" },
		        keys_given = { "FUNGUS" },
		        room_choices=new Dictionary<string, int>{
			        ["FungusRoom"] = 2 + WorldGenMain.random.Next(2),
			        ["SunkenMarsh"] = 2 + WorldGenMain.random.Next(2),
			        ["BatCaveRoom"] = 1 + WorldGenMain.random.Next(2),
		        },
		        room_bg = Constant.GROUND.FUNGUS,
		        background_room = "BGFungusRoom",
		        colour = { r = 1, g = 0, b = 0.5f, a = 1 },
	        });

	        Tasks.AddTask("TentacledCave", new Task
	        {
		        locks = { "LIGHT" },
		        keys_given = { "NONE" },
		        room_choices=new Dictionary<string, int>{
			        ["PitRoom"] = 1 + WorldGenMain.random.Next(2),
			        ["TentacleCave"] = 1 + WorldGenMain.random.Next(4),
		        },
		        room_bg = Constant.GROUND.MARSH,
		        background_room = "BGFungusRoom",
		        colour = { r = 0.5f, g = 0, b = 1, a = 1 },
	        });

	        Tasks.AddTask("LargeFungalComplex", new Task
	        {
		        locks = { "LIGHT" },
		        keys_given = { "CAVE" },
		        room_choices=new Dictionary<string, int>{
			        ["BatCaveRoom"] = 3 + WorldGenMain.random.Next(4),
			        ["PitRoom"] = 10 + WorldGenMain.random.Next(7),
		        },
		        room_bg = Constant.GROUND.WALL_ROCKY,
		        background_room = "BGFungusRoom",
		        colour = { r = 0.6f, g = 0, b = 1, a = 1 },
	        });

			//----------

			Tasks.AddTask("RedFungalComplex", new Task
			{
				locks = { "LIGHT" },
				keys_given = { "CAVE" },
				room_choices=new Dictionary<string, int>{
					["BatCaveRoom"] = WorldGenMain.random.Next(4),
					["PitRoom"] = 2 + WorldGenMain.random.Next(5),
				},
				room_bg = Constant.GROUND.WALL_ROCKY,
				background_room = "RedMush",
				colour = { r = 0.6f, g = 0, b = 1, a = 1 },
			});

			Tasks.AddTask("GreenFungalComplex", new Task
			{
				locks = { "LIGHT" },
				keys_given = { "CAVE" },
				room_choices=new Dictionary<string, int>{
					["BatCaveRoom"] = WorldGenMain.random.Next(4),
					["PitRoom"] = 2 + WorldGenMain.random.Next(5),
				},
				room_bg = Constant.GROUND.WALL_ROCKY,
				background_room = "GreenMush",
				colour = { r = 0.6f, g = 0, b = 1, a = 1 },
			});

			Tasks.AddTask("BlueFungalComplex", new Task
			{
				locks = { "LIGHT" },
				keys_given = { "CAVE" },
				room_choices=new Dictionary<string, int>{
					["BatCaveRoom"] = WorldGenMain.random.Next(4),
					["PitRoom"] = 2 + WorldGenMain.random.Next(5),
				},
				room_bg = Constant.GROUND.WALL_ROCKY,
				background_room = "BlueMush",
				colour = { r = 0.6f, g = 0, b = 1, a = 1 },
			});

			//------------

			Tasks.AddTask("RabbitsAndFungs", new Task
			{
				locks = { "LIGHT" },
				keys_given = { "CAVE" },
				room_choices=new Dictionary<string, int>{
					["RabitFungusRoom"] = 1 + WorldGenMain.random.Next(2),
					["SunkenMarsh"] = WorldGenMain.random.Next() > 0.5f ? 1 : 2,
					["Stairs"] = 1,
					["BGCaveRoom"] = 2 + WorldGenMain.random.Next(2),
				},
				room_bg = Constant.GROUND.WALL_ROCKY,
				background_room = "BGFungusRoom",
				colour = { r = 0.8f, g = 0, b = 1, a = 1 },
			});
			Tasks.AddTask("SingleBatCaveTask", new Task
			{
				locks = { "LIGHT" },
				keys_given = { "CAVE" },
				room_choices=new Dictionary<string, int>{
					["BatCaveRoom"] = 1,
				},
				room_bg = Constant.GROUND.CAVE,
				background_room = "BGCaveRoom",
				colour = { r = 1, g = 1, b = 1, a = 1 },
			});

			Tasks.AddTask("FungalPlain", new Task
			{
				locks = { "CAVE", "FUNGUS" },
				keys_given = { "NONE" },
				room_choices=new Dictionary<string, int>{
					//--["NoisyFungus"] = 3+WorldGenMain.random.Next(2),

					["GreenMush"] = WorldGenMain.random.NextDouble() > 0.5f ? WorldGenMain.random.Next(5) : 0,
					["RedMush"] = WorldGenMain.random.NextDouble() > 0.5f ? WorldGenMain.random.Next(5) : 0,
					["BlueMush"] = WorldGenMain.random.NextDouble() > 0.5f ? WorldGenMain.random.Next(5) : 0,

					["RabitFungusRoom"] = 1 + WorldGenMain.random.Next(2),
					["RockLobsterPlains"] = 1 + WorldGenMain.random.Next(2),
				},
				room_bg = Constant.GROUND.WALL_ROCKY,
				background_room = WorldGenMain.random.NextDouble() > 0.5f ? "BGFungusRoom" : "BGNoisyFungus",
				colour = { r = 1, g = 0, b = 0.6f, a = 1 },
			});

			Tasks.AddTask("Cavern", new Task
			{
				locks = { "LIGHT", "FUNGUS" },
				keys_given = { "NONE" },
				room_choices=new Dictionary<string, int>{
					["NoisyCave"] = 5 + WorldGenMain.random.Next(6),
					["RockLobsterPlains"] = 1,
				},
				room_bg = Constant.GROUND.CAVE_NOISE,
				background_room = "BGNoisyCave",
				colour = { r = 1, g = 0, b = 0.7f, a = 1 },
			});

			Tasks.AddTask("FungalRabitCityPlain", new Task
			{
				locks = { "CAVE", "FUNGUS" },
				keys_given = { "NONE" },
				room_choices=new Dictionary<string, int>{
					["GreenMush"] = WorldGenMain.random.Next() > 0.5f ? WorldGenMain.random.Next(5) : 0,
					["RedMush"] = WorldGenMain.random.Next() > 0.5f ? WorldGenMain.random.Next(5) : 0,
					["BlueMush"] = WorldGenMain.random.Next() > 0.5f ? WorldGenMain.random.Next(5) : 0,

					["RabitFungusRoom"] = 1 + WorldGenMain.random.Next(2),
					["RockLobsterPlains"] = 1 + WorldGenMain.random.Next(2),
					["RabbitCity"] = 4 + WorldGenMain.random.Next(2),
				},
				room_bg = Constant.GROUND.UNDERROCK,
				background_room = WorldGenMain.random.Next() > 0.5f ? "BGFungusRoom" : "BGNoisyFungus",
				colour = { r = 1, g = 0, b = 0.6f, a = 1 },
			});










			//------------------------------------------------------------
			//-- CAVE "BASE" TASKS
			//------------------------------------------------------------

			Tasks.AddTask("CaveBase", new Task
			{
				locks = { "CAVE" },
				keys_given = { "NONE" },
				room_choices=new Dictionary<string, int>{
					["CaveBase"] = 1,
				},
				room_bg = Constant.GROUND.CAVE,
				background_room = "BGNoisyCave",
				colour = { r = 1, g = 0, b = 0.7f, a = 1 },
			});

			Tasks.AddTask("MushBase", new Task
			{
				locks = { "FUNGUS" },
				keys_given = { "NONE" },
				room_choices=new Dictionary<string, int>{
					["MushBase"] = 1,
				},
				room_bg = Constant.GROUND.FUNGUS,
				background_room = "BGFungusRoom",
				colour = { r = 1, g = 0, b = 0.6f, a = 1 },
			});

			Tasks.AddTask("SinkBase", new Task
			{
				locks = { "LIGHT" },
				keys_given = { "NONE" },
				room_choices=new Dictionary<string, int>{
					["SinkBase"] = 1,
				},
				room_bg = Constant.GROUND.SINKHOLE,
				background_room = "BGSinkholeRoom",
				colour = { r = 1, g = 0, b = 0.7f, a = 1 },
			});

			Tasks.AddTask("RabbitTown", new Task
			{
				locks = { "LIGHT" },
				keys_given = { "NONE" },
				room_choices=new Dictionary<string, int>{
					["RabbitTown"] = 1,
				},
				room_bg = Constant.GROUND.SINKHOLE,
				background_room = "BGSinkholeRoom",
				colour = { r = 1, g = 0, b = 0.7f, a = 1 },
			});
        }
    }
}