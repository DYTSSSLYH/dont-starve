using System.Collections.Generic;

namespace DYT.Map.tasks
{
    public class IslandTasks
    {
        static IslandTasks()
        {
	        Tasks.AddTask("SampleTask", new Task
	        {
		        //--Name to use in the 'tasks' or 'optionaltasks' list
		        //--This is the lock that require to use the task
		        locks = { "NONE" },

		        //--These are the key(s) given when the task is used. "ISLAND1 unlocks LOCK.ISLAND1
		        keys_given = { "ISLAND1" },

		        //--This is used add links between biomes in an island which can make interesting shapes
		        //--0-1 seems to be a good amount
		        crosslink_factor = WorldGenMain.random.Next(0, 1),

		        //--When an island is generated this gives a chance the island ends will be connected making
		        //--a round island and sometimes lagoons
		        make_loop = WorldGenMain.random.Next(0, 100) < 50,

		        //--The rooms (biomes) that the task (island) contains.
		        //--Rooms can be found in the map/rooms/ folder
		        //--Shipwrecked files: terrain_beach.lua, terrain_island.lua, terrain_jungle.lua, terrain_ocean.lua, terrain_swamp.lua
		        //--See map/rooms/terrain_jungle.lua for room info
		        room_choices=new Dictionary<string, int>{
			        //--From terrain_jungle.lua, add 2 + 0 to 3 JungleClearing biomes to the island
			        ["JungleClearing"] = 2 + WorldGenMain.random.Next(0, 3),

			        //--From terrain_savanna.lua, add 1 BareMangrove biome to the island
			        ["BareMangrove"] = 1,

			        //--From terrain_savanna.lua, add 3 + 0 to 3 Plain biomes to the island
			        ["Plain"] = 3 + WorldGenMain.random.Next(0, 3),

			        //--From terrain_forest.lua, add 1 Clearing biome to the island
			        ["Clearing"] = 1,

			        //--From terrain_rocky.lua, add 1 + 0 to 3 Rocky biomes to the island
			        ["RockyIsland"] = 1 + WorldGenMain.random.Next(0, 3),

			        //--From graveyard.lua, add 0 to 1 Graveyard biomes to the island
			        ["Graveyard"] = WorldGenMain.random.Next(0, 1),

			        //--From terrain_jungle.lua, add 0 to 2 JungleDenseVery biomes to the island
			        ["JungleDenseVery"] = WorldGenMain.random.Next(0, 2),

			        //--From terrain_jungle.lua, add 0 to 2 JungleDenseVery biomes to the island
			        ["BeachPalmForest"] = WorldGenMain.random.Next(0, 2),
		        },

		        //--This is a backup basically, a background room of just this tile type is added to the task
		        //--GROUND (tile types) are in constants.lua
		        room_bg = Constant.GROUND.JUNGLE,

		        //--When background rooms are added (based on 'background_node_range' in survival.lua) rooms
		        //--from this list are randomly picked
		        //--background_room="BeachSand" --This form can be used for a single room
		        background_room = new List<string> { "BeachSand", "BeachGravel", "BeachUnkept", "Jungle" },

		        //--Used for debug stuff
		        colour = { r = 1, g = 1, b = 0, a = 1 }
	        });

	        Tasks.AddTask("HomeIslandVerySmall", new Task
	        {
		        locks = { "NONE" },
		        keys_given = { "ISLAND1" },
		        crosslink_factor = WorldGenMain.random.Next(0, 1),
		        make_loop = WorldGenMain.random.Next(0, 100) < 50,
		        room_choices=new Dictionary<string, int>{
			        ["JungleDenseMedHome"] =
				        1, //-- + WorldGenMain.random.Next(0, 2), --was 5+(0-2) --changed from JungleDense to remove monkeys
			        ["BeachSandHome"] = 2, //--was 5
			        //--["BeachUnkept"] = 2, --was 3
			        //--["BGGrassIsland"] = 3,  --added this to try it out
			        //--["BG_Mangroves"] = 1,  --Savanna --was 3 Plain
			        //--["MagmaHome"] = 1,	--was 3		
		        },
		        room_bg = Constant.GROUND.JUNGLE,
		        //--background_room=new List<string>{"BeachSandHome", "BeachSandHome", "BeachSandHome", "BeachUnkept"}, --removed BeachUnkept, added unkept above
		        colour = { r = 1, g = 1, b = 0, a = 1 }
	        });

	        Tasks.AddTask("HomeIslandSmall", new Task
	        {
		        locks = { "NONE" },
		        keys_given = { "ISLAND1" },
		        crosslink_factor = WorldGenMain.random.Next(0, 1),
		        make_loop = WorldGenMain.random.Next(0, 100) < 50,
		        room_choices=new Dictionary<string, int>{
			        ["JungleDenseMedHome"] =
				        2, //-- + WorldGenMain.random.Next(0, 2), --was 5+(0-2) --changed from JungleDense to remove monkeys
			        //--["BeachSandHome"] = 2, --was 5
			        ["BeachUnkept"] = 1, //--was 3
			        //--["BGGrassIsland"] = 3,  --added this to try it out
			        //--["BG_Mangroves"] = 1,  --Savanna --was 3 Plain
			        //--["MagmaHome"] = 1,	--was 3		
		        },
		        room_bg = Constant.GROUND.JUNGLE,
		        background_room = new List<string> { "BeachSandHome" }, //--removed BeachUnkept, added unkept above
		        colour = { r = 1, g = 1, b = 0, a = 1 }
	        });

	        Tasks.AddTask("HomeIslandSmallBoon", new Task
	        {
		        locks = { "NONE" },
		        keys_given = { "ISLAND1" },
		        crosslink_factor = WorldGenMain.random.Next(0, 1),
		        make_loop = WorldGenMain.random.Next(0, 100) < 50,
		        room_choices=new Dictionary<string, int>{
			        ["JungleDenseHome"] = 2, //-- + WorldGenMain.random.Next(0, 2), --was 5+(0-2)
			        ["JungleDenseMedHome"] =
				        1, //-- + WorldGenMain.random.Next(0, 2), --was 5+(0-2) --changed from JungleDense to remove monkeys
			        ["BeachSandHome"] = 1, //--was 5
			        ["BeachUnkept"] = 1, //--was 3
			        //--["BGGrassIsland"] = 3,  --added this to try it out
			        //--["NoOxMangrove"] = 1,  --Savanna --was 3 Plain
			        //--["MagmaHomeBoon"] = 1,	--was 3		
		        },
		        room_bg = Constant.GROUND.JUNGLE,
		        background_room = new List<string> { "BeachSandHome" }, //--removed BeachUnkept, added unkept above
		        colour = { r = 1, g = 1, b = 0, a = 1 }
	        });

	        Tasks.AddTask("HomeIslandSingleTree", new Task
	        {
		        locks = { "ISLAND2" },
		        keys_given = { "ISLAND3" },
		        crosslink_factor = WorldGenMain.random.Next(0, 1),
		        make_loop = WorldGenMain.random.Next(0, 100) < 50,
		        room_choices = new Dictionary<string, int>
		        {
			        ["OceanShallow"] = 1, //-- was BeachSinglePalmTreeHome
		        },
		        colour = { r = 1, g = 1, b = 0, a = 1 }
	        });

	        Tasks.AddTask("HomeIslandMed", new Task
	        {
		        locks = { "NONE" },
		        keys_given = { "ISLAND1" },
		        crosslink_factor = WorldGenMain.random.Next(0, 1),
		        make_loop = WorldGenMain.random.Next(0, 100) < 50,
		        room_choices = new Dictionary<string, int>
		        {
			        ["JungleDenseMedHome"] =
				        3 + WorldGenMain.random.Next(0, 3), //--was 5+(0-2) --changed from JungleDense to remove monkeys
			        //--["BeachSandHome"] = 2, --was 5
			        ["BeachUnkept"] = 1, //--was 3
			        //--["BGGrassIsland"] = 3,  --added this to try it out
			        //--["NoOxMangrove"] = 2,  --Savanna --was 3 Plain
			        //--["MagmaHome"] = 1,	--was 3		
		        },
		        room_bg = Constant.GROUND.JUNGLE,
		        background_room = new List<string> { "BeachSandHome" }, //--removed beach unkept, added unkept above
		        colour = { r = 1, g = 1, b = 0, a = 1 }
	        });

	        Tasks.AddTask("HomeIslandLarge", new Task
	        {
		        locks = { "NONE" },
		        keys_given = { "ISLAND1" },
		        crosslink_factor = WorldGenMain.random.Next(0, 1),
		        make_loop = WorldGenMain.random.Next(0, 100) < 50,
		        room_choices = new Dictionary<string, int>
		        {
			        ["JungleDenseMedHome"] =
				        3 + WorldGenMain.random.Next(0, 3), //--was 5+(0-2) --changed from JungleDense to remove monkeys
			        //--["BeachSandHome"] = 2, --was 5
			        ["BeachUnkept"] = 2, //--was 3
			        //--["BGGrassIsland"] = 3,  --added this to try it out
			        //--["NoOxMangrove"] = 2,  --Savanna --was 3 Plain
			        //--["MagmaHome"] = 2,	--was 3		
		        },
		        room_bg = Constant.GROUND.JUNGLE,
		        background_room = new List<string> { "BeachSandHome" }, //--removed BeachUnkept, added unkept above
		        colour = { r = 1, g = 1, b = 0, a = 1 }
	        });

	        Tasks.AddTask("HomeIslandLargeBoon", new Task
	        {
		        locks = { "NONE" },
		        keys_given = { "ISLAND1" },
		        crosslink_factor = WorldGenMain.random.Next(0, 1),
		        make_loop = WorldGenMain.random.Next(0, 100) < 50,
		        room_choices=new Dictionary<string, int>{
			        ["JungleDenseMedHome"] =
				        3 + WorldGenMain.random.Next(0, 3), //--was 5+(0-2) --changed from JungleDense to remove monkeys
			        //--["BeachSandHome"] = 2, --was 5
			        ["BeachUnkept"] = 2, //--was 3
			        //--["BGGrassIsland"] = 3,  --added this to try it out
			        //--["NoOxMangrove"] = 2,  --Savanna --was 3 Plain
			        //--["MagmaHomeBoon"] = 2,	--was 3		
		        },
		        room_bg = Constant.GROUND.JUNGLE,
		        background_room = new List<string> { "BeachSandHome" }, //--removed BeachUnkept, added unkept above
		        colour = { r = 1, g = 1, b = 0, a = 1 }
	        });
			/*--[[
			Tasks.AddTask("LagoonTest",new Task{
					locks={"NONE"},
					keys_given={"ISLAND1"},
					gen_method = "lagoon",
					room_choices=new Dictionary<string, int>{
						{
							["OceanShallow"] = 2
						},
						{
							["BeachSand"] = 5,
						},
						{
							["JungleDense"] = 10,
						},
						{
							["BeachUnkept"] = 18 //-- was 3*18
						}, 
					}, 
					room_bg=Constant.GROUND.JUNGLE,
					colour={r=1,g=1,b=0,a=1}
				})
			]]*/
			Tasks.AddTask("DesertIsland", new Task
			{
				locks = { "NONE" },
				keys_given = { "ISLAND1" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices=new Dictionary<string, int>{
					["BeachSand"] = 1 + WorldGenMain.random.Next(0, 3), //--CM was 5 +
				},
				room_bg = Constant.GROUND.BEACH,
				background_room = new List<string> { "BeachSand", "BeachUnkept" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("VolcanoIsland", new Task
			{
				locks = { "ISLAND4" },
				keys_given = { "NONE" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices=new Dictionary<string, int>{
					["VolcanoRock"] = 1,
					["MagmaVolcano"] = 1,
					["VolcanoObsidian"] = 1,
					["VolcanoObsidianBench"] = 1,
					["VolcanoAltar"] = 1,
					["VolcanoLava"] = 1
				},
				room_bg = Constant.GROUND.BEACH,
				background_room = new List<string> { "BeachSand", "BeachUnkept" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("JungleMarsh", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				gen_method = "lagoon",
				room_choices = new List<Dictionary<string, int>>
				{
					new()
					{
						["TidalMarsh"] = 2 //--was 3
					},
					new()
					{
						["JungleDense"] = 6, //--was 8
						["JungleDenseBerries"] = 2
					},
				},
				room_bg = Constant.GROUND.JUNGLE,
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("BeachJingleS", new Task
			{
				locks = { "NONE" },
				keys_given = { "ISLAND1" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["JungleDenseMed"] = 3, //-- MR went from 1-3
					["BeachUnkept"] = 1 //-- MR went from 1-3
				},
				room_bg = Constant.GROUND.JUNGLE,
				background_room = new List<string> { "BeachSand", "BeachSand", "BeachSand", "BeachUnkept" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("BeachBothJungles", new Task
			{
				locks = { "NONE" },
				keys_given = { "ISLAND1" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["JungleDenseMed"] = 1, //-- MR went from 1-3
					["JungleDense"] = 2, //-- MR went from 1-2
					["BeachSand"] = 3 //-- MR went from 1-4
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"BeachSand", "BeachUnkept"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("BeachJungleD", new Task
			{
				locks = { "ISLAND1" },
				keys_given = { "ISLAND2" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["JungleDense"] = 2, //-- MR went from 1-2
					["BeachSand"] = 1 //-- CM was 3
				},
				room_bg = Constant.GROUND.JUNGLE,
				background_room = new List<string> { "BeachSand", "BeachUnkept" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("BeachSavanna", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachSand"] = 2, //-- MR went from 2-4
					["NoOxMeadow"] = 2 //-- MR went from 2-4 
				},
				room_bg = Constant.GROUND.BEACH,
				background_room = new List<string> { "BeachSand", "BeachUnkept" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("GreentipA", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachSand"] = 2, //-- MR went from 1-5
					["MeadowCarroty"] = 1, //-- MR went from 1-3 Plain
					["JungleDenseMed"] = 3, //-- MR went from 1-3
					["BeachUnkept"] = 1 //--newly added to the mix
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"BeachSand", "BeachUnkept"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("GreentipB", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachSand"] = 1, //-- MR went from 1-3
					["NoOxMangrove"] = 2, //-- MR went from 1-4 Plain
					["JungleDense"] = 2 //-- MR went from 1-3
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"BeachSand", "BeachUnkept"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("HalfGreen", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachSand"] = 3, //-- MR went from 1-3
					["Mangrove"] = 1, //-- MR went from 1-3
					["JungleDenseMed"] = 1, //-- MR went from 1-2
					["NoOxMeadow"] = 1 //-- MR went from 1-2
				},
				room_bg = Constant.GROUND.JUNGLE,
				background_room = new List<string> { "BeachSand", "BeachUnkept" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("BeachRockyland", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachSand"] = 1, //--CM was 3 -- MR went from 1-5
					["Magma"] = 1 //--cm was 3 -- MR went from 1-3
				},
				room_bg = Constant.GROUND.BEACH,
				//--background_room=new List<string>{"BeachSand", "BeachUnkept"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("LotsaGrass", new Task
			{
				locks = { "ISLAND1" },
				keys_given = { "ISLAND2" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["NoOxMangrove"] = 1,
					["JungleDenseMed"] = 1,
					["NoOxMeadow"] = 2 //-- was 1
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"BeachSand", "JungleSparse"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("AllBeige", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachSand"] = 1,
					["Magma"] = 1,
					["NoOxMangrove"] = 1
				},
				room_bg = Constant.GROUND.BEACH,
				background_room = new List<string> { "BeachSand", "BeachUnkept" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("BeachMarsh", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachSand"] = 1,
					["TidalMarsh"] = 2 //--was 1
				},
				room_bg = Constant.GROUND.BEACH,
				background_room = new List<string> { "BeachSand", "BeachUnkept" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("Verdant", new Task
			{
				locks = { "ISLAND1" },
				keys_given = { "ISLAND2" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachSand"] = 1,
					["BeachPiggy"] = 1,
					["JungleDenseMed"] = 1
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"BeachSand", "BeachUnkept"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("VerdantMost", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachSand"] = 1,
					["BeachSappy"] = 1,
					["JungleDenseMed"] = 1,
					["JungleDenseBerries"] = 1
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"BeachSand", "BeachUnkept"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("Vert", new Task
			{
				locks = { "ISLAND1" },
				keys_given = { "ISLAND2" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachSand"] = 1,
					["MeadowCarroty"] = 1,
					["JungleDense"] = 1
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"BeachSand", "BeachUnkept"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			/*--[[Tasks.AddTask("JungleSparse",new Task{
					locks={"ISLAND3"},
					keys_given={"ISLAND5"},
					crosslink_factor=WorldGenMain.random.Next(0,1),
					make_loop=WorldGenMain.random.Next(0, 100) < 50,
					room_choices=new Dictionary<string, int>{
						["JungleDenseMed"] = 1
					}, 
					room_bg=Constant.GROUND.JUNGLE,
					background_room="JungleDenseMed",
					colour={r=1,g=1,b=0,a=1}
				})

			Tasks.AddTask("JungleBoth",new Task{
					locks={"ISLAND2"},
					keys_given={"ISLAND3"},
					crosslink_factor=WorldGenMain.random.Next(0,1),
					make_loop=WorldGenMain.random.Next(0, 100) < 50,
					room_choices=new Dictionary<string, int>{
						["JungleSparse"] = 1,
						["JungleDense"] = 1
					}, 
					room_bg=Constant.GROUND.JUNGLE,
					background_room=new List<string>{"JungleSparse", "JungleDense"},
					colour={r=1,g=1,b=0,a=1}
				})
			]]*/
			Tasks.AddTask("Florida Timeshare", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["TidalMarsh"] = 1,
					["JungleDenseMed"] = 1
				},
				room_bg = Constant.GROUND.JUNGLE,
				background_room = new List<string> { "BeachSand" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("JungleSRockyland", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				gen_method = "lagoon", //--was typical island 
				room_choices = new List<Dictionary<string, int>>
				{
					new()
					{
						["JungleDenseMed"] = 2 //--CM was 3 --was 1
					},
					new()
					{
						["Magma"] = 6 //--CM was 8 --was 1
					},
				},
				//--room_bg=GROUND.JUNGLE,
				//--background_room="JungleSparse",
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("JungleSSavanna", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BareMangrove"] = 1, //--was Plain, BareMangrove includes Ox
					["JungleDenseMed"] = 1
				},
				room_bg = Constant.GROUND.JUNGLE,
				background_room = new List<string> { "JungleDenseMed", "NoOxMangrove" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("JungleBeige", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BareMangrove"] = 1,
					["Magma"] = 1,
					["JungleDenseMed"] = 1
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"JungleSparse", "NoOxMangrove"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("FullofBees", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeesBeach"] = 2,
					//--["SavannaBees"] = 1, --was BareMangrove
					["JungleDense"] = 1 //--was JungleSparse
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"JungleBees", "SavannaBees"}, --was NoOxMangrove and JungleSparse
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("JungleDense", new Task
			{
				//------THIS IS A GOOD EXAMPLE OF THEMED ISLAND
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["TidalMarsh"] = 1,
					["JungleFlower"] = 1
				},
				room_bg = Constant.GROUND.JUNGLE,
				background_room = "JungleDense",
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("JungleDMarsh", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["TidalMarsh"] = 1,
					["JungleDense"] = 1
				},
				room_bg = Constant.GROUND.JUNGLE,
				background_room = new List<string> { "JungleDenseMed", "TidalMermMarsh" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("JungleDRockyland", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				gen_method = "lagoon",
				room_choices = new List<Dictionary<string, int>>
				{
					new()
					{
						["JungleDense"] = 2, //--CM was 3
					},
					new()
					{
						["Magma"] = 4 //--CM was 4 --+ WorldGenMain.random.Next(0,1),
					},
				},
				//--room_bg=GROUND.JUNGLE,
				//--background_room=new List<string>{"JungleDense", "Magma"}, --added Magma here instead ((CM - this makes it so that maybe we won't end up with any rock areas on this island))
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("JungleDRockyMarsh", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				gen_method = "lagoon", //-- normal gen
				room_choices = new List<Dictionary<string, int>>
				{
					//-- included 1: Swamp, Magma, JungleDense
					new()
					{
						["TidalMarsh"] = 2 //--CM was 3
					},
					new()
					{
						["JungleDense"] = 4, //--CM was 8
						["Magma"] = 2
					},
				},
				//--room_bg=GROUND.JUNGLE,
				//--background_room=new List<string>{"JungleDense", "BeachSand"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("JungleDSavanna", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BareMangrove"] = 1,
					["JungleDense"] = 1
				},
				room_bg = Constant.GROUND.JUNGLE,
				background_room = new List<string> { "JungleDense", "NoOxMangrove" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("JungleDSavRock", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BareMangrove"] = 1,
					["Magma"] = 1,
					["JungleDense"] = 1
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"JungleDense"}, --"NoOxMangrove",
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("HotNSticky", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["TidalMarsh"] = 2,
					["JungleDenseMed"] = 1,
					["JungleDense"] = 1
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"JungleDense", "TidalMarsh"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("Marshy", new Task
			{
				//-- not being called
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["TidalMarsh"] = 1,
					["TidalMermMarsh"] = 1
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room="TidalMarsh",
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("NoGreen A", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["TidalMarsh"] = 1,
					["Magma"] = 1
				},
				room_bg = Constant.GROUND.JUNGLE,
				background_room = new List<string> { "Magma", "TidalMarsh" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("NoGreen B", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["ToxicTidalMarsh"] = 2,
					["Magma"] = 1,
					["BareMangrove"] = 1
				},
				room_bg = Constant.GROUND.JUNGLE,
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("Savanna", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachUnkept"] = 1, //--CM was + WorldGenMain.random.Next(0, 2), was BeachGravel
					["BareMangrove"] = 1 //--CM was 5 -- MR went from 1-5
				},
				room_bg = Constant.GROUND.JUNGLE,
				background_room = "BeachNoCrabbits",
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("Rockyland", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["Magma"] = 2, //--was 1
					["ToxicTidalMarsh"] = WorldGenMain.random.Next(0, 1),
				},
				room_bg = Constant.GROUND.JUNGLE,
				background_room = new List<string> { "BeachUnkept" }, //--was BeachGravel
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("PalmTreeIsland", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = 1,
				make_loop = true,
				room_choices = new Dictionary<string, int>
				{
					["BeachSinglePalmTree"] = 1, //-- MR went from 1-5
					["OceanShallowSeaweedBed"] = 1,
					["OceanShallow"] = 1, //--CM was 4
				},
				room_bg = Constant.GROUND.OCEAN_SHALLOW,
				background_room = "OceanShallow",
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("DoydoyIslandGirl", new Task
			{
				locks = { "ISLAND4" },
				keys_given = { "NONE" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["JungleSparse"] = 2, //--CM was 2
				},
				set_pieces =
				{
					new() { name = "DoydoyGirl" }
				},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("DoydoyIslandBoy", new Task
			{
				locks = { "ISLAND4" },
				keys_given = { "NONE" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["JungleSparse"] = 2, //--CM was 2
				},
				set_pieces =
				{
					new Task.Piece { name = "DoydoyBoy" }
				},
				//--room_bg=GROUND.OCEAN_SHALLOW,
				//--background_room="OceanShallow",
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandCasino", new Task
			{
				locks = { "ISLAND4" },
				keys_given = { "ISLAND5" },
				crosslink_factor = 1, //--WorldGenMain.random.Next(0,1),
				make_loop = true, //--WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachPalmCasino"] = 1, //-- MR went from 1-5
					["Mangrove"] = WorldGenMain.random.Next(1, 2)
				},
				set_pieces =
				{
					new Task.Piece { name = "Casino" }
				},
				room_bg = Constant.GROUND.OCEAN_SHALLOW,
				background_room = "OceanShallow",
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("KelpForest", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = 1,
				make_loop = true,
				room_choices = new Dictionary<string, int>
				{
					["OceanMediumSeaweedBed"] = WorldGenMain.random.Next(1, 3), //--CM was 2, 5
				},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("GreatShoal", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = 1,
				make_loop = true,
				room_choices = new Dictionary<string, int>
				{
					["OceanMediumShoal"] = WorldGenMain.random.Next(1, 3), //--CM was 2, 5
				},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("BarrierReef", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = 0,
				make_loop = false,
				room_choices = new Dictionary<string, int>
				{
					["OceanCoral"] = WorldGenMain.random.Next(1, 3), //--CM was 2, 5
				},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			//--Test tasks ====================================================
	        Tasks.AddTask("IslandParadise", new Task
	        {
		        locks = { "NONE" },
		        keys_given = { "PICKAXE", "AXE", "GRASS", "WOOD", "TIER1", "ISLAND1" },
		        crosslink_factor = WorldGenMain.random.Next(0, 1),
		        make_loop = WorldGenMain.random.Next(0, 100) < 50,
		        room_choices = new Dictionary<string, int>
		        {
			        ["BeachSand"] = 1, //--CM + WorldGenMain.random.Next(0, 2),
			        ["Jungle"] = 2, //--CM + WorldGenMain.random.Next(0, 1),
			        ["MeadowMandrake"] = 1,
			        ["Magma"] = 1, //--CM + WorldGenMain.random.Next(0, 1),
			        ["JungleDenseVery"] = WorldGenMain.random.Next(0, 1),
			        ["BareMangrove"] = 1,
		        },
		        room_bg = Constant.GROUND.BEACH,
		        //--background_room=new List<string>{"BeachSand", "BeachGravel", "BeachUnkept", "Jungle"},
		        colour = { r = 1, g = 1, b = 0, a = 1 }
	        });

			/*--[[Tasks.AddTask("ThemePigIsland",new Task{
					locks={"ISLAND4"},
					keys_given={"NONE"},
					gen_method = "lagoon",
					room_choices=new Dictionary<string, int>{
						{
							["JunglePigs"] = 1, 
							["JungleDenseMed"] = 2
						},
						{
							["JunglePigGuards"] = 5 + WorldGenMain.random.Next(0, 3), //--was 5 +
						},
					},
					set_pieces={
						{name="DefaultPigking"}
					},
					//--room_bg=GROUND.IMPASSABLE,
					//--background_room="BGImpassable",
					room_bg=Constant.GROUND.TIDALMARSH,
					background_room=new List<string>{"BeachSand","BeachPiggy","BeachPiggy","BeachPiggy","TidalMarsh"},
					colour={r=0.5f,g=0,b=1,a=1}
				})
			]]*/
			Tasks.AddTask("PiggyParadise", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3", "ISLAND4" },
				gen_method = "lagoon",
				room_choices = new List<Dictionary<string, int>>
				{
					new()
					{
						["JungleDenseBerries"] = 3,
					},
					new()
					{
						["BeachPiggy"] = 5 + WorldGenMain.random.Next(1, 3),
					},
				},
				/*--[[set_pieces={
					{name="DefaultPigking"}
				},]]*/
				//--room_bg=GROUND.IMPASSABLE,
				//--background_room="BGImpassable",
				room_bg = Constant.GROUND.TIDALMARSH,
				background_room = new List<string>
					{ "BeachSand", "BeachPiggy", "BeachPiggy", "BeachPiggy", "TidalMarsh" },
				colour = { r = 0.5f, g = 0, b = 1, a = 1 }
			});

			Tasks.AddTask("BeachPalmForest", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3", "ISLAND4" },
				//--entrance_room={"ForceDisconnectedRoom"},
				room_choices = new Dictionary<string, int>
				{
					["BeachPalmForest"] = 1 + WorldGenMain.random.Next(0, 3),
				},
				//--room_bg=GROUND.IMPASSABLE,
				//--background_room="BGImpassable",
				room_bg = Constant.GROUND.TIDALMARSH,
				background_room = "OceanShallow",
				colour = { r = 0.5f, g = 0, b = 1, a = 1 }
			});

			Tasks.AddTask("ThemeMarshCity", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				//--entrance_room={"ForceDisconnectedRoom"},
				room_choices = new Dictionary<string, int>
				{
					["TidalMermMarsh"] = 1 + WorldGenMain.random.Next(0, 1),
					["ToxicTidalMarsh"] = 1 + WorldGenMain.random.Next(0, 1),
					["JungleSpidersDense"] = 1, //--CM was 3,
				},
				//--room_bg=GROUND.IMPASSABLE,
				//--background_room="BGImpassable",
				room_bg = Constant.GROUND.TIDALMARSH,
				//--background_room=new List<string>{"BeachSand","BeachPiggy","TidalMarsh"},
				colour = { r = 0.5f, g = 0, b = 1, a = 1 }
			});

			Tasks.AddTask("Spiderland", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["MagmaSpiders"] = 1,
					["JungleSpidersDense"] = 2,
					["JungleSpiderCity"] = 1 //--need to make this jungly instead of using basegame trees and ground
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"BeachGravel"}, --removed MagmaSpiders
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandJungleBamboozled", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["JungleBamboozled"] = 1 + WorldGenMain.random.Next(0, 1), //-- added the random bonus room
				},
				room_bg = Constant.GROUND.JUNGLE,
				background_room = new List<string> { "OceanShallow" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandJungleMonkeyHell", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["JungleMonkeyHell"] = 3,
					//--["JungleDenseBerries"] =1,
					//--["JungleDenseMedHome"] =1,
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"Jungle"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandJungleCritterCrunch", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["JungleCritterCrunch"] = 2,
					["JungleDenseCritterCrunch"] = 1,
					//--["Jungle"] = 1,
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"JungleDenseCritterCrunch"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			/*--[[Tasks.AddTask("IslandMagmaJungle",new Task{  
					locks={"ISLAND3"},
					keys_given={"ISLAND4"},
					crosslink_factor=WorldGenMain.random.Next(0,1),
					make_loop=WorldGenMain.random.Next(0, 100) < 50,
					room_choices=new Dictionary<string, int>{
						["MagmaForest"] = 1,
						//--["JungleClearing"] = 1,
						["Jungle"] = 1,
					}, 
					room_bg=Constant.GROUND.JUNGLE,
					//--background_room=new List<string>{"JungleClearing"},
					colour={r=1,g=1,b=0,a=1}
				})
			]]*/
			Tasks.AddTask("IslandJungleShroomin", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["JungleShroomin"] = 2,
					//--["JungleDenseMed"] = 1,
					//--["Jungle"] = 1,
				},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandJungleRockyDrop", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				gen_method = "lagoon",
				room_choices = new List<Dictionary<string, int>>
				{
					new()
					{
						["MagmaSpiders"] = 2 //--CM was 3
					},
					new()
					{
						["JungleRockyDrop"] = 4, //--CM was 8
						["Jungle"] = 2
					},
				},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandJungleEyePlant", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["JungleEyeplant"] = 1,
					["TidalMarsh"] = 1,
					//--["JungleDense"] = 1,
				},
				room_bg = Constant.GROUND.JUNGLE,
				background_room = new List<string> { "JungleDenseMedHome" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			/*--[[
			Tasks.AddTask("IslandJungleGrassy",new Task{  
					locks={"ISLAND1"},
					keys_given={"ISLAND2"},
					crosslink_factor=WorldGenMain.random.Next(0,1),
					make_loop=WorldGenMain.random.Next(0, 100) < 50,
					room_choices=new Dictionary<string, int>{
						["JungleGrassy"] = 1,
						["JungleDenseBerries"] = 1,
						["Jungle"] = 1,
					}, 
					room_bg=Constant.GROUND.JUNGLE,
					//--background_room=new List<string>{"JungleClearing", "JungleDense"},
					colour={r=1,g=1,b=0,a=1}
				})

			Tasks.AddTask("IslandJungleSappy",new Task{  
					locks={"ISLAND1"},
					keys_given={"ISLAND2"},
					crosslink_factor=WorldGenMain.random.Next(0,1),
					make_loop=WorldGenMain.random.Next(0, 100) < 50,
					room_choices=new Dictionary<string, int>{
						["JungleSappy"] = 1,
						["JungleDenseMedHome"] = 1,
						["JungleDenseVery"] = 1,
					}, 
					room_bg=Constant.GROUND.JUNGLE,
					//--background_room=new List<string>{"JungleClearing", "Jungle"},
					colour={r=1,g=1,b=0,a=1}
				})

			Tasks.AddTask("IslandJungleNoGrass",new Task{  
					locks={"ISLAND3"},
					keys_given={"ISLAND4"},
					crosslink_factor=WorldGenMain.random.Next(0,1),
					make_loop=WorldGenMain.random.Next(0, 100) < 50,
					room_choices=new Dictionary<string, int>{
						["JungleNoGrass"] = 2, //--CM + WorldGenMain.random.Next(0, 3),
						//--["Jungle"] = 1,
					}, 
					room_bg=Constant.GROUND.JUNGLE,
					//--background_room=new List<string>{"JungleSparseHome", "JungleDenseMed"},
					colour={r=1,g=1,b=0,a=1}
				})
			]]*/

			Tasks.AddTask("IslandJungleBerries", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["JungleDenseBerries"] = 4,
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"JungleSparse", "Jungle"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandJungleNoBerry", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["JungleNoBerry"] = 3,
					/*--[[ ["Jungle"] = 1,
					["JungleDenseVery"] = 1, ]]*/
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"JungleSparse", "Jungle"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandJungleNoRock", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["JungleNoRock"] = 1,
					//--["JungleEyeplant"] = 1,
					["TidalMarsh"] = 1,
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"JungleDenseMed", "JungleDense"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandJungleNoMushroom", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["JungleNoMushroom"] = 1,
					//--["Jungle"] = 1,
				},
				room_bg = Constant.GROUND.JUNGLE,
				background_room = new List<string> { "JungleNoMushroom" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandJungleNoFlowers", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["JungleNoFlowers"] = WorldGenMain.random.Next(3, 5),
					//--["JungleDenseMedHome"] = 1,
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"Jungle", "JungleDense"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandJungleEvilFlowers", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["JungleEvilFlowers"] = 2,
					["ToxicTidalMarsh"] = 1,
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"JungleDenseMed", "JungleClearing"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			/*--[[Tasks.AddTask("IslandJungleMorePalms",new Task{  
					locks={"ISLAND3"},
					keys_given={"ISLAND4"},
					crosslink_factor=WorldGenMain.random.Next(0,1),
					make_loop=WorldGenMain.random.Next(0, 100) < 50,
					room_choices=new Dictionary<string, int>{
						["JungleMorePalms"] = WorldGenMain.random.Next(2,3),
						//--["JungleDense"] = 1,
						//--["JungleDenseBerries"] = 1,
					}, 
					room_bg=Constant.GROUND.JUNGLE,
					//--background_room=new List<string>{"JungleSparse", "JungleDense"},
					colour={r=1,g=1,b=0,a=1}
				}) ]]*/

			Tasks.AddTask("IslandJungleSkeleton", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["JungleSkeleton"] = 1,
					["JungleDenseMedHome"] = 1,
					["TidalMermMarsh"] = 1,
				},
				room_bg = Constant.GROUND.JUNGLE,
				background_room = new List<string> { "Jungle", "JungleDense" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandBeachCrabTown", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachCrabTown"] = WorldGenMain.random.Next(1, 3),
				},
				room_bg = Constant.GROUND.BEACH,
				//--background_room=new List<string>{"BeachSand"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandBeachDunes", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachDunes"] = 1,
					["BeachUnkept"] = 1,
					//-- ["BeachSinglePalmTree"] = 1,
				},
				room_bg = Constant.GROUND.BEACH,
				background_room = new List<string> { "BeachSand", "BeachUnkept" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandBeachGrassy", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachGrassy"] = 1,
					["BeachPalmForest"] = 1,
					["BeachSandHome"] = 1,
				},
				room_bg = Constant.GROUND.BEACH,
				//--background_room=new List<string>{"BeachUnkept", "BeachGravel"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandBeachSappy", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachSappy"] = 1,
					["BeachSand"] = 1,
					["BeachUnkept"] = 1, //--was BeachGravel
				},
				room_bg = Constant.GROUND.BEACH,
				//--background_room=new List<string>{"BeachSandHome", "BeachSappy"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandBeachRocky", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachRocky"] = 1,
					//--["BeachGravel"] = 1,
					["BeachUnkept"] = 1,
					["BeachSandHome"] = 1,
				},
				room_bg = Constant.GROUND.BEACH,
				//--background_room=new List<string>{"BeachUnkept", "BeachSandHome"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandBeachLimpety", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachLimpety"] = 1,
					["BeachSand"] = 1,
				},
				room_bg = Constant.GROUND.BEACH,
				background_room = new List<string> { "BeachSand", "BeachUnkept" }, //--was BeachGravel instead of Unkept
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandBeachForest", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachPalmForest"] = 1,
					["BeachSandHome"] = 1,
					//-- ["BeachSinglePalmTree"] = 1,
				},
				room_bg = Constant.GROUND.BEACH,
				background_room = new List<string> { "BeachUnkept", "BeachSandHome" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandBeachSpider", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachSpider"] = 2,
					//--["BeachUnkept"] = 1,
				},
				room_bg = Constant.GROUND.BEACH,
				background_room = new List<string> { "BeachSand", "BeachUnkept" }, //--was BeachGravel instead of Unkept
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandBeachNoFlowers", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachNoFlowers"] = 1,
					["BeachUnkept"] = 1, //--was BeachGravel
				},
				room_bg = Constant.GROUND.BEACH,
				//--background_room=new List<string>{"BeachSand"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			/*--[[Tasks.AddTask("IslandBeachFlowers",new Task{  
					locks={"ISLAND2"},
					keys_given={"ISLAND3"},
					crosslink_factor=WorldGenMain.random.Next(0,1),
					make_loop=WorldGenMain.random.Next(0, 100) < 50,
					room_choices=new Dictionary<string, int>{
						["BeachFlowers"] = 1,
						//--["BeachSandHome"] = 1,
					}, 
					room_bg=Constant.GROUND.BEACH,
					background_room=new List<string>{"BeachSandHome", "BeachSand"}, //--removed BeachGravel
					colour={r=1,g=1,b=0,a=1}
				}) ]]*/

			Tasks.AddTask("IslandBeachNoLimpets", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachNoLimpets"] = 1,
				},
				room_bg = Constant.GROUND.BEACH,
				background_room = new List<string> { "BeachSand" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandBeachNoCrabbits", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachNoCrabbits"] = 2,
					//--["BeachSinglePalmTree"] = 1, -- this leaves a lot of empty space possibly the size of a whole screen
					//--["BeachSandHome"] = 1,
				},
				room_bg = Constant.GROUND.BEACH,
				background_room = new List<string>
					{ "BeachUnkept", "BeachUnkept" }, //--was BeachGravel instead of Unkept
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandMangroveOxBoon", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["MangroveOxBoon"] = 1,
					["MangroveWetlands"] = 1,
					["JungleNoRock"] = 1,
				},
				room_bg = Constant.GROUND.MANGROVE,
				//--background_room=new List<string>{"BeachSandHome", "BeachGravel"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			/*--[[Tasks.AddTask("IslandMeadowWetlands",new Task{  
					locks={"ISLAND3"},
					keys_given={"ISLAND4"},
					crosslink_factor=WorldGenMain.random.Next(0,1),
					make_loop=WorldGenMain.random.Next(0, 100) < 50,
					room_choices=new Dictionary<string, int>{
						["MeadowWetlands"] = 2,
						["BG_Mangrove"] = 1,
						["BareMangrove"] = 1,
						//--["NoOxMangrove"] = 1,
					}, 
					room_bg=Constant.GROUND.MANGROVE,
					//--background_room=new List<string>{"BareMangrove", "Plain"},
					colour={r=1,g=1,b=0,a=1}
				})

			Tasks.AddTask("IslandSavannaFlowery",new Task{  
					locks={"ISLAND3"},
					keys_given={"ISLAND4"},
					crosslink_factor=WorldGenMain.random.Next(0,1),
					make_loop=WorldGenMain.random.Next(0, 100) < 50,
					room_choices=new Dictionary<string, int>{
						["SavannaFlowery"] = 2,
						//--["BG_Mangroves"] = 1,
						//--["Plain"] = 1,
					}, 
					room_bg=Constant.GROUND.MANGROVE,
					//--background_room=new List<string>{"BG_Mangroves", "BareMangrove"},
					colour={r=1,g=1,b=0,a=1}
				})
			]]*/
			Tasks.AddTask("IslandMeadowBees", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["MeadowBees"] = 1,
					["NoOxMeadow"] = 1,
				},
				room_bg = Constant.GROUND.MANGROVE,
				background_room = new List<string> { "NoOxMeadow" },
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandMeadowCarroty", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["MeadowCarroty"] = 1,
					["NoOxMeadow"] = 1,
				},
				room_bg = Constant.GROUND.MANGROVE,
				//--background_room=new List<string>{"Plain", "BareMangrove"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			/*--[[Tasks.AddTask("IslandSavannaSappy",new Task{  
					locks={"ISLAND3"},
					keys_given={"ISLAND4"},
					crosslink_factor=WorldGenMain.random.Next(0,1),
					make_loop=WorldGenMain.random.Next(0, 100) < 50,
					room_choices=new Dictionary<string, int>{
						["SavannaSappy"] = 1,
						//--["BareMangrove"] = 1,
						//--["BG_Mangroves"] = 1,
					}, 
					room_bg=Constant.GROUND.MANGROVE,
					background_room=new List<string>{"SavannaSappy", "SavannaSappy", "SavannaSappy", "BareMangrove", "BeachSappy", "BeachUnkept"}, //--was BeachGravel instead of Unkept
					colour={r=1,g=1,b=0,a=1}
				})

			Tasks.AddTask("IslandSavannaSpider",new Task{  
					locks={"ISLAND2"},
					keys_given={"ISLAND3"},
					crosslink_factor=WorldGenMain.random.Next(0,1),
					make_loop=WorldGenMain.random.Next(0, 100) < 50,
					room_choices=new Dictionary<string, int>{
						["SavannaSpider"] = 3,
						//--["BareMangrove"] = 1,
						//--["NoOxMangrove"] = 1,
						//--["Plain"] = 1,
					}, 
					room_bg=Constant.GROUND.MANGROVE,
					//--background_room=new List<string>{"NoOxMangrove", "BG_Mangroves"},
					colour={r=1,g=1,b=0,a=1}
				})

			Tasks.AddTask("IslandSavannaRocky",new Task{  
					locks={"ISLAND3"},
					keys_given={"ISLAND4"},
					gen_method = "lagoon",
					room_choices=new Dictionary<string, int>{
						{
							["SavannaRocky"] = 2
						},
						{
							["BeachRocky"] = 3,  //--CM was 4
							["BeachSand"] = 3 //--CM was 4
						},
					}, 
					room_bg=Constant.GROUND.MANGROVE,
					//--background_room=new List<string>{"BareMangrove", "Plain"},
					colour={r=1,g=1,b=0,a=1}
				}) ]]*/

			Tasks.AddTask("IslandRockyGold", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["MagmaGoldBoon"] = 1,
					["MagmaGold"] = 1,
					["BeachSandHome"] = 1,
				},
				room_bg = Constant.GROUND.BEACH,
				//--background_room=new List<string>{"BeachSand", "BeachUnkept"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			/*--[[Tasks.AddTask("IslandRockyBlueMushroom",new Task{  
					locks={"ISLAND3"},
					keys_given={"ISLAND4"},
					crosslink_factor=WorldGenMain.random.Next(0,1),
					make_loop=WorldGenMain.random.Next(0, 100) < 50,
					room_choices=new Dictionary<string, int>{
						["RockyBlueMushroom"] = 1,
						["MolesvilleRockyIsland"] = 1,
						["BeachSand"] = 1,
					}, 
					room_bg=Constant.GROUND.BEACH ,
					//--background_room=new List<string>{"BeachGravel", "BeachUnkept"},
					colour={r=1,g=1,b=0,a=1}
				}) ]]*/

			Tasks.AddTask("IslandRockyTallBeach", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["MagmaTallBird"] = 1,
					["GenericMagmaNoThreat"] = 1,
					["BeachUnkept"] = 1, //--was BeachGravel
				},
				room_bg = Constant.GROUND.BEACH,
				//--background_room=new List<string>{"BeachSand", "BeachUnkept"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("IslandRockyTallJungle", new Task
			{
				locks = { "ISLAND3" },
				keys_given = { "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["MagmaTallBird"] = 1,
					["BG_Magma"] = 1,
					["JungleDenseMed"] = 1,
				},
				room_bg = Constant.GROUND.JUNGLE,
				//--background_room=new List<string>{"JungleSparseHome", "JungleDense"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("Chess", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["MarbleForest"] = 1,
					["ChessArea"] = 1,
					//--["ChessMarsh"] = 1,
					//--["ChessForest"] = 1,
				},
				colour = { r = 0.5f, g = 0.7f, b = 0.5f, a = 0.3f },
			});

			/*--[[Tasks.AddTask("IslandGravy",new Task{  
					locks={"ISLAND3"},
					keys_given={"ISLAND4"},
					gen_method = "lagoon",
					room_choices=new Dictionary<string, int>{
						{
							["SW_Graveyard"] = 2  //--CM was 3
						},
						{
							["JungleDenseMed"] = 3, //--CM was 8
							["Jungle"] = 2
						},
					}, 
					room_bg=Constant.GROUND.JUNGLE ,
					//--background_room=new List<string>{"JungleSparseHome", "JungleDense"},
					colour={r=1,g=1,b=0,a=1}
				}) ]]*/

			Tasks.AddTask("PirateBounty", new Task
			{
				locks = { "ISLAND4" },
				keys_given = { "ISLAND5" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachUnkeptDubloon"] = 1,
				},
				set_pieces =
				{
					new Task.Piece { name = "Xspot" }
				},
				room_bg = Constant.GROUND.BEACH,
				//--background_room=new List<string>{"OceanShallowSeaweedBed"}, --removed "OceanShallowReef"
				colour = { r = 0.5f, g = 0.7f, b = 0.5f, a = 0.3f },
			});

			Tasks.AddTask("IslandOasis", new Task
			{
				locks = { "ISLAND4" },
				keys_given = { "ISLAND5" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["Jungle"] = 1,
				},
				set_pieces =
				{
					new Task.Piece { name = "JungleOasis" }
				},
				room_bg = Constant.GROUND.BEACH,
				//--background_room=new List<string>{"OceanShallowSeaweedBed"}, --removed "OceanShallowReef"
				colour = { r = 0.5f, g = 0.7f, b = 0.5f, a = 0.3f },
			});

			Tasks.AddTask("ShellingOut", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3", "ISLAND4" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachShells"] = 2,
				},
				room_bg = Constant.GROUND.BEACH,
				background_room = new List<string> { "OceanShallow" }, //--removed "OceanShallowReef"
				colour = { r = 0.5f, g = 0.7f, b = 0.5f, a = 0.3f },
			});

			Tasks.AddTask("Cranium", new Task
			{
				locks = { "ISLAND4" },
				keys_given = { "ISLAND5" },
				gen_method = "lagoon",
				room_choices = new List<Dictionary<string, int>>
				{
					new()
					{
						["BeachSkull"] = 1,
					},
					new()
					{
						["Jungle"] = 6,
					},
				},
				/*--[[treasures = {
					{name="DeadmansTreasure"}
				},]]*/
				room_bg = Constant.GROUND.BEACH,
				//--background_room=new List<string>{"BeachSand", "BeachUnkept"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("CrashZone", new Task
			{
				locks = { "ISLAND2" },
				keys_given = { "ISLAND3" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["Jungle"] = 2,
					["MagmaForest"] = 1,
				},
				room_bg = Constant.GROUND.BEACH,
				//--background_room=new List<string>{"BeachSand", "BeachUnkept"},
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			Tasks.AddTask("SharkHome", new Task
			{
				locks = { "ISLAND4" },
				keys_given = { "ISLAND5" },
				crosslink_factor = WorldGenMain.random.Next(0, 1),
				make_loop = WorldGenMain.random.Next(0, 100) < 50,
				room_choices = new Dictionary<string, int>
				{
					["BeachSand"] = 1,
				},
				set_pieces =
				{
					new Task.Piece { name = "SharkHome" }
				},
				room_bg = Constant.GROUND.BEACH,
				//--background_room=new List<string>{"OceanShallowSeaweedBed"}, --removed "OceanShallowReef"
				colour = { r = 0.5f, g = 0.7f, b = 0.5f, a = 0.3f },
			});
        }
    }
}