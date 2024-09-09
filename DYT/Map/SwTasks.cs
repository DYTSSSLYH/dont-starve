using DYT.Map.tasks;

namespace DYT.Map
{
    public class SwTasks
    {
        static SwTasks()
        {
	        // -- The standard tasks
	        
	        Tasks.AddTask("Make a pick", new Task
	        {
		        locks = { "NONE" },
		        keys_given = { "PICKAXE", "AXE", "GRASS", "WOOD", "TIER1" },
		        room_choices =
		        {
			        ["Forest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["BarePlain"] = 1,
			        ["Plain"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["Clearing"] = 1,
		        },
		        room_bg = Constant.GROUND.GRASS,
		        background_room = "BGGrass",
		        colour = { r = 0, g = 1, b = 0, a = 1 }
	        });
	        Tasks.AddTask("Resource-rich Tier2", new Task
	        {
		        locks = { "NONE" }, //-- Special story starting node
		        keys_given = { "PICKAXE", "AXE", "GRASS", "WOOD", "TIER1", "TIER2" },
		        room_choices =
		        {
			        ["Forest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["BarePlain"] = 1,
			        ["Plain"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["Clearing"] = 1,
		        },
		        room_bg = Constant.GROUND.GRASS,
		        background_room = "BGGrass",
		        colour = { r = 0, g = 1, b = 0, a = 1 }
	        });
	        Tasks.AddTask("Resource-Rich", new Task
	        {
		        locks = { "NONE" },
		        keys_given = { "TIER1" }, //-- Special story node has only one key
		        room_choices =
		        {
			        ["Forest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["BarePlain"] = 1,
			        ["Plain"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["Clearing"] = 1,
		        },
		        room_bg = Constant.GROUND.GRASS,
		        background_room = "BGGrass",
		        colour = { r = 0, g = 1, b = 0, a = 1 }
	        });
	        Tasks.AddTask("Wasps and Frogs and bugs", new Task
	        {
		        locks = { "BASIC_COMBAT", "TIER3" },
		        keys_given = { "MEAT", "GRASS", "HONEY", "TIER2" },
		        entrance_room = BlockerSets.all_bees,
		        room_choices =
		        {
			        ["Pondopolis"] = 1,
			        ["BeeClearing"] = 1,
			        ["EvilFlowerPatch"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["Clearing"] = 2,
		        },
		        room_bg = Constant.GROUND.GRASS,
		        background_room = "BGGrass",
		        colour = { r = 0, g = 1, b = 0, a = 1 }
	        });
	        Tasks.AddTask("Frogs and bugs", new Task
	        {
		        locks = { "BASIC_COMBAT", "TIER1" },
		        keys_given = { "MEAT", "GRASS", "HONEY", "TIER2" },
		        room_choices =
		        {
			        ["Pondopolis"] = 1,
			        ["BeeClearing"] = 1,
			        ["FlowerPatch"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["Clearing"] = 2,
			        ["GrassyMoleColony"] = 1,
		        },
		        room_bg = Constant.GROUND.GRASS,
		        background_room = "BGGrass",
		        colour = { r = 0, g = 1, b = 0, a = 1 }
	        });
	        Tasks.AddTask("Hounded Magic meadow", new Task
	        {
		        locks = { "TIER4" },
		        keys_given = { "MEAT", "WOOD", "HOUNDS", "TIER2" },
		        entrance_room_chance = 0.7f,
		        entrance_room = BlockerSets.all_hounds,
		        room_choices =
		        {
			        ["Pondopolis"] = 2,
			        ["Clearing"] = 2, //-- have to have at least a few rooms for tagging
		        },
		        room_bg = Constant.GROUND.FOREST,
		        background_room = "Clearing",
		        colour = { r = 0, g = 1, b = 0, a = 1 }
	        });
	        Tasks.AddTask("Magic meadow", new Task
	        {
		        locks = { "TIER1" },
		        keys_given = { "GRASS", "MEAT", "TIER1" },
		        room_choices =
		        {
			        ["Pondopolis"] = 2,
			        ["Clearing"] = 2, //-- have to have at least a few rooms for tagging
		        },
		        room_bg = Constant.GROUND.FOREST,
		        background_room = "Clearing",
		        colour = { r = 0, g = 1, b = 0, a = 1 }
	        });
	        Tasks.AddTask("Waspy The hunters", new Task
	        {
		        locks = { "ADVANCED_COMBAT", "MONSTERS_DEFEATED", "TIER4" },
		        keys_given = { "WALRUS", "TIER5" },
		        entrance_room = BlockerSets.all_bees,
		        room_choices =
		        {
			        ["WalrusHut_Plains"] = 1,
			        ["WalrusHut_Grassy"] = 1,
			        ["WalrusHut_Rocky"] = 1,
			        ["Clearing"] = 2,
			        ["BGGrass"] = 2,
			        ["BGRocky"] = 2,
		        },
		        room_bg = Constant.GROUND.SAVANNA,
		        background_room = "BGSavanna",
		        colour = { r = 0, g = 1, b = 0, a = 1 }
	        });
	        Tasks.AddTask("The hunters", new Task
	        {
		        locks = { "ADVANCED_COMBAT", "MONSTERS_DEFEATED", "TIER4" },
		        keys_given = { "WALRUS", "TIER5" },
		        room_choices =
		        {
			        ["WalrusHut_Plains"] = 1,
			        ["WalrusHut_Grassy"] = 1,
			        ["WalrusHut_Rocky"] = 1,
			        ["Clearing"] = 2,
			        ["BGGrass"] = 2,
			        ["BGRocky"] = 2,
		        },
		        room_bg = Constant.GROUND.SAVANNA,
		        background_room = "BGSavanna",
		        colour = { r = 0, g = 1, b = 0, a = 1 }
	        });
	        Tasks.AddTask("Guarded Walrus Desolate", new Task
	        {
		        locks = { "ADVANCED_COMBAT", "MONSTERS_DEFEATED", "TIER4" },
		        keys_given = { "HARD_WALRUS", "TIER5" },
		        entrance_room = Util.ArrayUnion(BlockerSets.rocky_hard, BlockerSets.all_walls),
		        room_choices =
		        {
			        ["WalrusHut_Plains"] = 1,
			        ["WalrusHut_Grassy"] = 1,
			        ["WalrusHut_Rocky"] = 1,
			        ["BGRocky"] = 2,
		        },
		        room_bg = Constant.GROUND.ROCKY,
		        background_room = "BGRocky",
		        colour = { r = 0, g = 1, b = 0, a = 1 }
	        });
	        Tasks.AddTask("Walrus Desolate", new Task
	        {
		        locks = { "ADVANCED_COMBAT", "MONSTERS_DEFEATED", "TIER4" },
		        keys_given = { "HARD_WALRUS", "TIER5" },
		        room_choices =
		        {
			        ["WalrusHut_Plains"] = 1,
			        ["WalrusHut_Grassy"] = 1,
			        ["WalrusHut_Rocky"] = 1,
			        ["BGRocky"] = 2,
		        },
		        room_bg = Constant.GROUND.ROCKY,
		        background_room = "BGRocky",
		        colour = { r = 0, g = 1, b = 0, a = 1 }
	        });
	        Tasks.AddTask("Insanity-Blocked Necronomicon", new Task
	        {
		        locks = { "TIER3" },
		        keys_given = { "TRINKETS", "WOOD", "TIER3" },
		        entrance_room = BlockerSets.all_walls,
		        room_choices =
		        {
			        ["Graveyard"] = 3,
			        ["Forest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["DeepForest"] = 2,
		        },
		        room_bg = Constant.GROUND.ROCKY,
		        background_room = "BGRocky",
		        colour = { r = 0, g = 1, b = 0, a = 1 }
	        });
	        Tasks.AddTask("Necronomicon", new Task
	        {
		        locks = { "ROCKS", "TIER2" },
		        keys_given = { "TRINKETS", "WOOD", "TIER3" },
		        room_choices =
		        {
			        ["Graveyard"] = 3,
			        ["Forest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["DeepForest"] = 2,
		        },
		        room_bg = Constant.GROUND.ROCKY,
		        background_room = "BGRocky",
		        colour = { r = 0, g = 1, b = 0, a = 1 }
	        });

	        Tasks.AddTask("Easy Blocked Dig that rock", new Task
	        {
		        locks = { "ROCKS", "TIER1" },
		        keys_given = { "TRINKETS", "STONE", "WOOD", "TIER1" },
		        entrance_room_chance = 0.5f,
		        entrance_room = BlockerSets.all_easy,
		        room_choices =
		        {
			        ["Graveyard"] = 1,
			        //--["Wormhole"] = 1,
			        ["Rocky"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["Forest"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["Clearing"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION)
		        },
		        room_bg = Constant.GROUND.ROCKY,
		        background_room = "BGNoise",
		        colour = { r = 0, g = 0, b = 1, a = 1 }
	        });

	        Tasks.AddTask("Dig that rock", new Task
	        {
		        locks = { "ROCKS" },
		        keys_given = { "TRINKETS", "STONE", "WOOD", "TIER1" },
		        room_choices =
		        {
			        ["Graveyard"] = 1,
			        ["Sinkhole"] = 1,
			        ["Rocky"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["Forest"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["Clearing"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION)
		        },
		        room_bg = Constant.GROUND.ROCKY,
		        background_room = "BGNoise",
		        colour = { r = 0, g = 0, b = 1, a = 1 }
	        });

	        Tasks.AddTask("Tentacle-Blocked The Deep Forest", new Task
	        {
		        locks = { "TREES", "TIER3" },
		        keys_given = { "TENTACLES", "PIGS", "WOOD", "MEAT", "TIER3" },
		        entrance_room = BlockerSets.all_tentacles,
		        room_choices =
		        {
			        //--["Wormhole"] = 1,
			        ["PigVillage"] = 1,
			        ["BGForest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["Marsh"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["DeepForest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["Clearing"] = 1
		        },
		        room_bg = Constant.GROUND.FOREST,
		        background_room = "BGDeepForest",
		        colour = { r = 1, g = 0, b = 0, a = 1 }
	        });
	        Tasks.AddTask("The Deep Forest", new Task
	        {
		        locks = { "TREES", "TIER2" },
		        keys_given = { "PIGS", "WOOD", "MEAT", "TIER2" },
		        room_choices =
		        {
			        //--["Wormhole"] = 1,
			        ["PigVillage"] = 1,
			        ["Forest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["Marsh"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["DeepForest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
			        ["Clearing"] = 1,
			        ["Sinkhole"] = 1
		        },
		        room_bg = Constant.GROUND.FOREST,
		        background_room = "BGDeepForest",
		        colour = { r = 1, g = 0, b = 0, a = 1 }
	        });

			//--------------------------------------------------------------------------------
			//-- Moles
			//--------------------------------------------------------------------------------

			Tasks.AddTask("Mole Colony Deciduous", new Task
			{
				locks = { "TIER1" },
				keys_given = { "TIER2" },
				room_choices =
				{
					["MolesvilleDeciduous"] = 1,
					["DeepDeciduous"] = 2,
					["DeciduousMole"] = 2,
					["DeciduousClearing"] = 1,
				},
				room_bg = Constant.GROUND.DECIDUOUS,
				background_room = "BGDeciduous",
				colour = { r = 0.15f, g = 0.5f, b = 0.05f, a = 1 }
			});

			Tasks.AddTask("Mole Colony Rocks", new Task
			{
				locks = { "TIER1" },
				keys_given = { "ROCKS", "GOLD", "TIER2" },
				room_choices =
				{
					["RockyBuzzards"] = 1,
					//--["Wormhole"] = 1,
					["GenericRockyNoThreat"] = 2 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["MolesvilleRocky"] = 1,
				},
				room_bg = Constant.GROUND.ROCKY,
				background_room = "BGRocky",
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});

			//--------------------------------------------------------------------------------
			//-- Pigs 
			//--------------------------------------------------------------------------------
			Tasks.AddTask("Trapped Befriend the pigs", new Task
			{
				locks = { "PIGGIFTS", "TIER2" },
				keys_given = { "PIGS", "MEAT", "GRASS", "WOOD", "TIER2" },
				entrance_room = { "Trapfield" },
				room_choices =
				{
					["PigVillage"] = 1,
					//--["Wormhole"] = 1,
					["Forest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Marsh"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["DeepForest"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Clearing"] = 1
				},
				room_bg = Constant.GROUND.FOREST,
				background_room = "BGForest",
				colour = { r = 1, g = 0, b = 0, a = 1 }
			});
			Tasks.AddTask("Befriend the pigs", new Task
			{
				locks = { "PIGGIFTS", "TIER1" },
				keys_given = { "PIGS", "MEAT", "GRASS", "WOOD", "TIER2" },
				room_choices =
				{
					["PigVillage"] = 1,
					//--["Wormhole"] = 1,
					["Forest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Marsh"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["DeepForest"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Clearing"] = 1
				},
				room_bg = Constant.GROUND.FOREST,
				background_room = "BGForest",
				colour = { r = 1, g = 0, b = 0, a = 1 }
			});
			Tasks.AddTask("Pigs in the city", new Task
			{
				locks = { "PIGGIFTS" },
				keys_given = { "PIGS" },
				room_choices =
				{
					["PigCity"] = 1,
					["Forest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Clearing"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["DeepForest"] = 1,
				},
				room_bg = Constant.GROUND.SAVANNA,
				background_room = "BGSavanna",
				colour = { r = 1, g = 0, b = 0, a = 1 }
			});
			Tasks.AddTask("The Pigs are back in town", new Task
			{
				locks = { "PIGGIFTS" },
				keys_given = { "PIGS" },
				room_choices =
				{
					["PigTown"] = 1,
					["Forest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Clearing"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["DeepForest"] = 1,
				},
				room_bg = Constant.GROUND.GRASS,
				background_room = "BGForest",
				colour = { r = 1, g = 0, b = 0, a = 1 }
			});
			Tasks.AddTask("Guarded King and Spiders", new Task
			{
				locks = { "PIGKING" },
				keys_given = { "PIGS" },
				entrance_room = { "PigGuardpost" },
				room_choices =
				{
					["PigKingdom"] = 1,
					//--["Wormhole"] = 1,
					["Graveyard"] = 1,
					["CrappyDeepForest"] = 1,
					["SpiderForest"] = 3,
				},
				room_bg = Constant.GROUND.FOREST,
				background_room = "BGCrappyForest",
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});
			Tasks.AddTask("Guarded Speak to the king", new Task
			{
				locks = { "PIGKING" },
				keys_given = { "PIGS" },
				entrance_room = BlockerSets.all_pigs,
				room_choices =
				{
					["PigKingdom"] = 1,
					//--["Wormhole"] = 1,
					["DeepForest"] = 3 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.FOREST,
				background_room = "BGForest",
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});
			Tasks.AddTask("King and Spiders", new Task
			{
				locks = { "PIGKING" },
				keys_given = { "PIGS" },
				room_choices =
				{
					["PigKingdom"] = 1,
					//--["Wormhole"] = 1,
					["Graveyard"] = 1,
					["CrappyDeepForest"] = 1,
					["SpiderForest"] = 3,
				},
				room_bg = Constant.GROUND.FOREST,
				background_room = "BGCrappyForest",
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});
			Tasks.AddTask("Speak to the king", new Task
			{
				locks = { "PIGKING", "TIER2" },
				keys_given = { "PIGS", "GOLD", "TIER3" },
				room_choices =
				{
					["PigKingdom"] = 1,
					["GrassySinkhole"] = 1,
					["MagicalDeciduous"] = 1,
					["DeepDeciduous"] = 3 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.GRASS,
				background_room = "BGDeciduous",
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});
			//--------------------------------------------------------------------------------
			//-- Beefalo 
			//--------------------------------------------------------------------------------
			Tasks.AddTask("Hounded Greater Plains", new Task
			{
				locks = { "ADVANCED_COMBAT", "TIER4" },
				keys_given = { "MEAT", "WOOL", "POOP", "HOUNDS", "WALRUS", "TIER4" },
				entrance_room = BlockerSets.all_hounds,
				room_choices =
				{
					["BeefalowPlain"] = 3 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					//--["Wormhole_Plains"] = 1,
					["WalrusHut_Plains"] = 1,
					["Plain"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.SAVANNA,
				background_room = "BGSavanna",
				colour = { r = 0, g = 1, b = 1, a = 1 }
			});
			Tasks.AddTask("Greater Plains", new Task
			{
				locks = { "ADVANCED_COMBAT", "TIER3" },
				keys_given = { "MEAT", "WOOL", "POOP", "WALRUS", "TIER4" },
				room_choices =
				{
					["BeefalowPlain"] = 3 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					//--["Wormhole_Plains"] = 1,
					["WalrusHut_Plains"] = 1,
					["Plain"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.SAVANNA,
				background_room = "BGSavanna",
				colour = { r = 0, g = 1, b = 1, a = 1 }
			});
			Tasks.AddTask("Sanity-Blocked Great Plains", new Task
			{
				locks = { "ROCKS", "BASIC_COMBAT", "TIER4" },
				keys_given = { "MEAT", "POOP", "WOOL", "GRASS", "TIER2" },
				entrance_room = { "SanityWall" },
				room_choices =
				{
					["BeefalowPlain"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					//--["Wormhole_Plains"] = 1,
					["Plain"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Clearing"] = 2,
				},
				room_bg = Constant.GROUND.SAVANNA,
				background_room = "BGSavanna",
				colour = { r = 0, g = 1, b = 1, a = 1 }
			});
			Tasks.AddTask("Great Plains", new Task
			{
				locks = { "ROCKS", "BASIC_COMBAT", "TIER1" },
				keys_given = { "MEAT", "POOP", "WOOL", "GRASS", "TIER2" },
				room_choices =
				{
					["BeefalowPlain"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					//--["Wormhole_Plains"] = 1,
					["Plain"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Clearing"] = 2,
				},
				room_bg = Constant.GROUND.SAVANNA,
				background_room = "BGSavanna",
				colour = { r = 0, g = 1, b = 1, a = 1 }
			});
			//--------------------------------------------------------------------------------
			//-- Hounds 
			//--------------------------------------------------------------------------------
			Tasks.AddTask("Rock-Blocked HoundFields", new Task
			{
				locks = { "MEAT" },
				keys_given = { "MEAT" },
				entrance_room = { "DenseRocks" },
				room_choices =
				{
					["Moundfield"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Plain"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.FOREST,
				background_room = "BGRocky",
				colour = { r = 0, g = 1, b = 1, a = 1 }
			});
			Tasks.AddTask("HoundFields", new Task
			{
				locks = { "MEAT" },
				keys_given = { "MEAT" },
				room_choices =
				{
					["Moundfield"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Plain"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.FOREST,
				background_room = "BGRocky",
				colour = { r = 0, g = 1, b = 1, a = 1 }
			});
			//--------------------------------------------------------------------------------
			//-- Merms 
			//--------------------------------------------------------------------------------
			Tasks.AddTask("Merms ahoy", new Task
			{
				locks = { "SPIDERDENS", "BASIC_COMBAT", "MONSTERS_DEFEATED", "TIER3" },
				keys_given = { "MERMS", "MEAT", "SPIDERS", "SILK", "TIER4" },
				room_choices =
				{
					["MermTown"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["SpiderMarsh"] = 3 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Marsh"] = 3 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["DeepForest"] = 2 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.MARSH,
				background_room = "BGMarsh",
				colour = { r = 1, g = 0, b = 0, a = 1 }
			});
			Tasks.AddTask("Sane-Blocked Swamp", new Task
			{
				locks = { "BASIC_COMBAT", "TIER4" },
				keys_given = { "TENTACLES", "WOOD", "TIER2" },
				entrance_room = { "SanityWall" },
				room_choices =
				{
					//--["Wormhole"] = 1,
					["Marsh"] = 2 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Forest"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["DeepForest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.MARSH,
				background_room = "BGMarsh",
				colour = { r = 0.05f, g = 0.05f, b = 0.05f, a = 1 }
			});
			Tasks.AddTask("Guarded Squeltch", new Task
			{
				locks = { "SPIDERDENS", "TIER2" },
				keys_given = { "MEAT", "SILK", "SPIDERS", "TIER2" },
				entrance_room_chance = 0.7f,
				entrance_room = BlockerSets.all_marsh,
				room_choices =
				{
					//--["Wormhole"] = 1,
					["Marsh"] = 2 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Forest"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["DeepForest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["SlightlyMermySwamp"] = 1,
				},
				room_bg = Constant.GROUND.MARSH,
				background_room = "BGMarsh",
				colour = { r = 0.05f, g = 0.05f, b = 0.05f, a = 1 }
			});
			Tasks.AddTask("Squeltch", new Task
			{
				locks = { "SPIDERDENS", "TIER2" },
				keys_given = { "MEAT", "SILK", "SPIDERS", "TIER3" },
				room_choices =
				{
					["Sinkhole"] = 1,
					["Marsh"] = 5 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					//--["Forest"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION), 
					//--["DeepForest"] = 1+WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["SlightlyMermySwamp"] = 1,
				},
				room_bg = Constant.GROUND.MARSH,
				background_room = "BGMarsh",
				colour = { r = 0.05f, g = 0.05f, b = 0.05f, a = 1 }
			});
			Tasks.AddTask("Swamp start", new Task
			{
				locks = { "NONE" },
				keys_given = { "MERMS", "TIER2", "TIER3" },
				room_choices =
				{
					["SafeSwamp"] = 2,
					//--["Wormhole_Swamp"] = 1,
					["Marsh"] = 2 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["SlightlyMermySwamp"] = 1,
				},
				room_bg = Constant.GROUND.MARSH,
				background_room = "BGMarsh",
				colour = { r = 0.05f, g = 0.5f, b = 0.5f, a = 1 }
			});
			Tasks.AddTask("Tentacle-Blocked Spider Swamp", new Task
			{
				locks = { "SPIDERDENS", "BASIC_COMBAT", "TIER3" },
				keys_given = { "MEAT", "TENTACLES", "SPIDERS", "TIER3", "GOLD" },
				entrance_room = BlockerSets.all_tentacles,
				room_choices =
				{
					["SpiderVillageSwamp"] = 1,
					["SpiderMarsh"] = 2 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Forest"] = 2,
				},
				room_bg = Constant.GROUND.MARSH,
				background_room = "BGMarsh",
				colour = { r = 0.5f, g = 0.05f, b = 0.05f, a = 1 }
			});
			Tasks.AddTask("Lots-o-Spiders", new Task
			{
				locks =
				{
					"ONLYTIER1"
				}, //-- note: adventure level, tier1 lock and abundant keys is to control world shape
				keys_given = { "SPIDERS", "TIER3", "AXE" },
				entrance_room = BlockerSets.all_spiders,
				room_choices =
				{
					["SpiderCity"] = 1,
					["SpiderVillage"] = 2,
					["SpiderMarsh"] = 2 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["CrappyForest"] = 2,
				},
				room_bg = Constant.GROUND.MARSH,
				background_room = "BGMarsh",
				colour = { r = 0.05f, g = 0.5f, b = 0.05f, a = 1 }
			});
			Tasks.AddTask("Lots-o-Tentacles", new Task
			{
				locks =
				{
					"ONLYTIER1"
				}, //-- note: adventure level, tier1 lock and abundant keys is to control world shape
				keys_given = { "TENTACLES", "TIER3", "AXE" },
				entrance_room = { "TentaclelandA" },
				room_choices =
				{
					["MermTown"] = 1,
					["Marsh"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["SlightlyMermySwamp"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.MARSH,
				background_room = "BGMarsh",
				colour = { r = 0.05f, g = 0.05f, b = 0.5f, a = 1 }
			});
			Tasks.AddTask("Lots-o-Tallbirds", new Task
			{
				locks =
				{
					"ONLYTIER1"
				}, //-- note: adventure level, tier1 lock and abundant keys is to control world shape
				keys_given = { "TALLBIRDS", "MEAT", "WOOL", "POOP", "TIER3", "TIER4", "GOLD", "AXE" },
				entrance_room = BlockerSets.all_tallbirds,
				room_choices =
				{
					["WalrusHut_Rocky"] = 1,
					["WalrusHut_Plains"] = 1,
					["BeefalowPlain"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["TallbirdNests"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.ROCKY,
				background_room = "BGRocky",
				colour = { r = 0.5f, g = 0.3f, b = 0.05f, a = 1 }
			});
			Tasks.AddTask("Lots-o-Chessmonsters", new Task
			{
				locks =
				{
					"ONLYTIER1"
				}, //-- note: adventure level, tier1 lock and abundant keys is to control world shape
				keys_given = { "CHESSMEN", "GEARS", "WOOL", "POOP", "TIER3", "TIER4", "GOLD" },
				entrance_room = BlockerSets.all_chess,
				room_choices =
				{
					["ChessForest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["ChessBarrens"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["ChessMarsh"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.ROCKY,
				background_room = "BGChessRocky",
				colour = { r = 0.8f, g = 0.08f, b = 0.05f, a = 1 }
			});
			Tasks.AddTask("Spider swamp", new Task
			{
				locks = { "SPIDERDENS", "BASIC_COMBAT", "TIER3" },
				keys_given = { "MEAT", "SPIDERS", "TIER3", "GOLD" },
				room_choices =
				{
					//--["Wormhole_Swamp"] = 1,
					["SpiderVillageSwamp"] = 1,
					["SpiderMarsh"] = 2 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Forest"] = 2,
				},
				room_bg = Constant.GROUND.MARSH,
				background_room = "BGMarsh",
				colour = { r = 0.15f, g = 0.05f, b = 0.7f, a = 1 }
			});
			//--Task("Into the Nothing small", {
				//--lock,"ROCKS",
				//--keys_given={"MEAT"},
				//--room_choices={
				//--},
				//--room_choices={
					//--["Forest"] = 1, 
					//--["Nothing"] = 1+WorldGenMain.random.Next(Tasks.SIZE_VARIATION)
				//--},  
				//--room_bg=GROUND.IMPASSABLE,
				//--colour={r=0.05f,g=0.05f,b=0.05f,a=1}
			//--}),
			Tasks.AddTask("Sanity-Blocked Spider Queendom", new Task
			{
				locks = { "PIGKING", "SPIDERDENS", "ADVANCED_COMBAT", "TIER5" },
				keys_given = { "SPIDERS", "HARD_SPIDERS", "TIER5", "TRINKETS" },
				entrance_room = BlockerSets.all_walls,
				room_choices =
				{
					["SpiderCity"] = 4,
					["Graveyard"] = 1,
					["CrappyDeepForest"] = 2,
				},
				room_bg = Constant.GROUND.FOREST,
				background_room = "SpiderForest",
				colour = { r = 1, g = 1, b = 0, a = 1 }
			});
			Tasks.AddTask("Spider Queendom", new Task
			{
				locks = { "PIGKING" },
				keys_given = { "PIGS" },
				room_choices =
				{
					["SpiderCity"] = 4,
					//--["Wormhole_Plains"] = 1,
					["Graveyard"] = 1,
					["CrappyDeepForest"] = 2,
				},
				room_bg = Constant.GROUND.FOREST,
				background_room = "SpiderForest",
				colour = { r = 1, g = 1, b = 0.2f, a = 1 }
			});

			Tasks.AddTask("Guarded For a nice walk", new Task
			{
				locks = { "BASIC_COMBAT", "TIER2" },
				keys_given = { "POOP", "WOOL", "WOOD", "GRASS", "TIER2" },
				entrance_room_chance = 0.3f,
				entrance_room = Util.ArrayUnion(BlockerSets.forest_easy, BlockerSets.all_grass, BlockerSets.walls_easy),
				room_choices =
				{
					["BeefalowPlain"] = 1,
					["MandrakeHome"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					//--["Wormhole"] = 1,
					["DeepForest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Forest"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.FOREST,
				background_room = "BGForest",
				colour = { r = 1, g = 0, b = 1, a = 1 }
			});
			Tasks.AddTask("For a nice walk", new Task
			{
				locks = { "BASIC_COMBAT", "TIER2" },
				keys_given = { "POOP", "WOOL", "WOOD", "GRASS", "TIER2" },
				room_choices =
				{
					["BeefalowPlain"] = 1,
					["MandrakeHome"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					//--["Wormhole"] = 1,
					["DeepForest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Forest"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.FOREST,
				background_room = "BGForest",
				colour = { r = 1, g = 0, b = 1, a = 1 }
			});
			Tasks.AddTask("Mine Forest", new Task
			{
				locks = { "SPIDERDENS" },
				keys_given = { "MEAT" },
				room_choices =
				{
					["Trapfield"] = 4,
					["Clearing"] = 2
				},
				room_bg = Constant.GROUND.FOREST,
				background_room = "BGCrappyForest",
				colour = { r = 0.05f, g = 0.5f, b = 0.05f, a = 1 }
			});
			Tasks.AddTask("Battlefield", new Task
			{
				locks = { "SPIDERDEN", "BASIC_COMBAT", "TIER4" },
				keys_given = { "SPIDERS", "PIGS", "SILK", "TIER5" },
				entrance_room = { "Trapfield" },
				room_choices =
				{
					["Trapfield"] = 1,
					["SpiderVillage"] = 2,
					//--["Wormhole"] = 1,
					["PigCamp"] = 2,
					["BGForest"] = 1,
					["DeepForest"] = 1,
					["Clearing"] = 1,
				},
				room_bg = Constant.GROUND.ROCKY,
				background_room = "BGRocky",
				colour = { r = 0.05f, g = 0.8f, b = 0.05f, a = 1 }
			});
			Tasks.AddTask("Guarded Forest hunters", new Task
			{
				locks = { "ADVANCED_COMBAT", "MONSTERS_DEFEATED", "TIER4" },
				keys_given = { "WALRUS", "TIER4" },
				entrance_room = BlockerSets.all_forest,
				room_choices =
				{
					["WalrusHut_Grassy"] = 1,
					//--["Wormhole"] = 1,
					["BGForest"] = 2,
					["DeepForest"] = 1,
					["Clearing"] = 1,
				},
				room_bg = Constant.GROUND.FOREST,
				background_room = "BGForest",
				colour = { r = 0.05f, g = 0.5f, b = 0.15f, a = 1 }
			});
			Tasks.AddTask("Trapped Forest hunters", new Task
			{
				locks = { "ADVANCED_COMBAT", "MONSTERS_DEFEATED", "TIER4" },
				keys_given = { "WALRUS", "TIER4" },
				entrance_room = { "Trapfield" },
				room_choices =
				{
					["WalrusHut_Grassy"] = 1,
					//--["Wormhole"] = 1,
					["Forest"] = 2,
					["DeepForest"] = 1,
					["Clearing"] = 1,
				},
				room_bg = Constant.GROUND.FOREST,
				background_room = "BGForest",
				colour = { r = 0.05f, g = 0.5f, b = 0.15f, a = 1 }
			});
			Tasks.AddTask("Forest hunters", new Task
			{
				locks = { "ADVANCED_COMBAT", "MONSTERS_DEFEATED", "TIER3" },
				keys_given = { "WALRUS", "TIER4" },
				room_choices =
				{
					["WalrusHut_Grassy"] = 1,
					//--["Wormhole"] = 1,
					["Forest"] = 1,
					["ForestMole"] = 2,
					["DeepForest"] = 1,
					["Clearing"] = 1,
				},
				room_bg = Constant.GROUND.FOREST,
				background_room = "BGForest",
				colour = { r = 0.15f, g = 0.5f, b = 0.05f, a = 1 }
			});
			Tasks.AddTask("Walled Kill the spiders", new Task
			{
				locks = { "SPIDERDENS", "MONSTERS_DEFEATED", "TIER3" },
				keys_given = { "SPIDERS", "TIER4" },
				entrance_room_chance = 0.4f,
				entrance_room = BlockerSets.walls_easy,
				room_choices =
				{
					["SpiderVillage"] = 2,
					//--["Wormhole"] = 1,
					["CrappyForest"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["CrappyDeepForest"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Clearing"] = 1
				},
				room_bg = Constant.GROUND.ROCKY,
				background_room = "BGRocky",
				colour = { r = 0.15f, g = 0.5f, b = 0.15f, a = 1 }
			});
			Tasks.AddTask("Kill the spiders", new Task
			{
				locks = { "SPIDERDENS", "MONSTERS_DEFEATED", "TIER3" },
				keys_given = { "SPIDERS", "TIER4" },
				room_choices =
				{
					["SpiderVillage"] = 2,
					//--["Wormhole"] = 1,
					["CrappyForest"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["CrappyDeepForest"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Clearing"] = 1
				},
				room_bg = Constant.GROUND.ROCKY,
				background_room = "BGRocky",
				colour = { r = 0.25f, g = 0.4f, b = 0.06f, a = 1 }
			});
			Tasks.AddTask("Waspy Beeeees!", new Task
			{
				locks = { "BEEHIVE", "TIER1" },
				keys_given = { "HONEY", "TIER2" },
				entrance_room_chance = 0.8f,
				entrance_room = BlockerSets.all_bees,
				room_choices =
				{
					["BeeClearing"] = 1,
					//--["Wormhole"] = 1,
					["Forest"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["FlowerPatch"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.GRASS,
				background_room = "BGGrass",
				colour = { r = 0, g = 1, b = 0.3f, a = 1 }
			});
			Tasks.AddTask("Beeeees!", new Task
			{
				locks = { "BEEHIVE", "TIER1" },
				keys_given = { "HONEY", "TIER2" },
				room_choices =
				{
					["BeeClearing"] = 1,
					//--["Wormhole"] = 1,
					["Forest"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["FlowerPatch"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.GRASS,
				background_room = "BGGrass",
				colour = { r = 0, g = 1, b = 0.3f, a = 1 }
			});
			Tasks.AddTask("Killer Bees!", new Task
			{
				locks = { "KILLERBEES", "TIER3" },
				keys_given = { "HONEY", "TIER3" },
				entrance_room = { "Waspnests" },
				room_choices =
				{
					//--["Wormhole"] = 1,
					["Waspnests"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Forest"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["FlowerPatch"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.GRASS,
				background_room = "BGGrass",
				colour = { r = 1, g = 0.1f, b = 0.1f, a = 1 }
			});
			Tasks.AddTask("Pretty Rocks Burnt", new Task
			{
				locks = { "SPIDERDENS" },
				keys_given = { "BEEHAT" },
				room_choices =
				{
					//--["Wormhole_Plains"] = 1,
					["Rocky"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["FlowerPatch"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.GRASS,
				background_room = "BGGrassBurnt",
				colour = { r = 1, g = 1, b = 0.5f, a = 1 }
			});
			Tasks.AddTask("Make A Beehat", new Task
			{
				locks = { "SPIDERS_DEFEATED", "TIER1" },
				keys_given = { "BEEHAT", "GRASS", "TIER1" },
				room_choices =
				{
					//--["Wormhole_Plains"] = 1,
					["Rocky"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["FlowerPatch"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.GRASS,
				background_room = "BGGrass",
				colour = { r = 1, g = 1, b = 0.5f, a = 1 }
			});
			Tasks.AddTask("The charcoal forest", new Task
			{
				locks = { "NONE" },
				keys_given = { "NONE" },
				room_choices =
				{
					//--["Wormhole_Burnt"] = 1,
					["BurntForestStart"] = 1,
					["BurntForest"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["BurntClearing"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
				},
				room_bg = Constant.GROUND.GRASS,
				background_room = "BGGrassBurnt",
				colour = { r = 1, g = 1, b = 0.5f, a = 1 }
			});
			Tasks.AddTask("Land of Plenty", new Task
			{
				locks = { "NONE" },
				keys_given = { "MEAT" },
				room_choices =
				{
					["PigCamp"] = 2,
					["PigTown"] = 2,
					["PigCity"] = 1,
					["BeeClearing"] = 1,
					["MandrakeHome"] = 2,
					["BeefalowPlain"] = 2,
					["Graveyard"] = 2,
					["Forest"] = 2,
					["DeepForest"] = 1,
					["BGRocky"] = 1,
				},
				room_bg = Constant.GROUND.GRASS,
				background_room = "BGGrass",
				colour = { r = 0.05f, g = 0.5f, b = 0.05f, a = 1 }
			});
			Tasks.AddTask("The other side", new Task
			{
				locks = { "MEAT" },
				keys_given = { "NONE" },
				entrance_room = { "SanityWormholeBlocker" },
				room_choices =
				{
					["Graveyard"] = WorldGenMain.random.Next(2),
					["SpiderCity"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Waspnests"] = 1,
					["WalrusHut_Rocky"] = WorldGenMain.random.Next(1),
					["Pondopolis"] = WorldGenMain.random.Next(2),
					["Tentacleland"] = WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Moundfield"] = WorldGenMain.random.Next(2),
					["MermTown"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["Trapfield"] = 1 + WorldGenMain.random.Next(2),
					["ChessArea"] = WorldGenMain.random.Next(2),
					["ChessMarsh"] = 1,
					["SpiderMarsh"] = 2 + WorldGenMain.random.Next(2),
				},
				room_bg = Constant.GROUND.MARSH,
				background_room = "BGMarsh",
				colour = { r = 0.05f, g = 0.5f, b = 0.05f, a = 1 }
			});
			Tasks.AddTask("Chessworld", new Task
			{
				locks = { "ADVANCED_COMBAT", "MONSTERS_DEFEATED", "TIER5" },
				keys_given = { "CHESSMEN", "TIER5" },
				entrance_room = BlockerSets.all_chess,
				room_choices =
				{
					["ChessArea"] = 2,
					["MarbleForest"] = 1 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
					["ChessBarrens"] = 2,
				},
				room_bg = Constant.GROUND.MARSH,
				background_room = "BGChessRocky",
				colour = { r = 0.05f, g = 0.5f, b = 0.05f, a = 1 },
			});



			new MaxwellTasks();
        }
    }
}