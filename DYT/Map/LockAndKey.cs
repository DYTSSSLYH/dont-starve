using System.Collections.Generic;
using UnityEngine.Assertions;

namespace DYT.Map
{
    public class LockAndKey
    {
        // List of locks
        public static readonly List<string> LOCKS_ARRAY = new()
        {
            "NONE",
            "PIGGIFTS",
            "TREES",
            "SPIDERDENS",
            "ROCKS",
            "FARM",
            "MEAT",
            "BEEHIVE",
            "KILLERBEES",
            "PIGKING",
            "MONSTERS_DEFEATED",
            "HARD_MONSTERS_DEFEATED",
            "SPIDERS_DEFEATED",
            "BASIC_COMBAT",
            "ADVANCED_COMBAT",
            "ONLYTIER1",
            "TIER1",
            "TIER2",
            "TIER3",
            "TIER4",
            "TIER5",
            "LIGHT",
            "FUNGUS",
            "CAVE",
            "LABYRINTH",
            "WILDS",
            "RUINS",
            "SACRED",
            "BADLANDS",
            "HOUNDS",
            // --"ADVANCED_COMBAT",
            "ISLAND1",
            "ISLAND2",
            "ISLAND3",
            "ISLAND4",
            "ISLAND5",
            "ISLAND6",
            "ISLAND7",


            // --PORKLAND
            "JUNGLE_DEPTH_1",
            "JUNGLE_DEPTH_2",
            "JUNGLE_DEPTH_3",
            "CIVILIZATION_1",
            "CIVILIZATION_2",
            "RUINS_ENTRANCE_1",
            "RUINS_EXIT_1",

            "OTHER_CIVILIZATION_1",
            "OTHER_CIVILIZATION_2",
            "OTHER_JUNGLE_DEPTH_1",
            "OTHER_JUNGLE_DEPTH_2",

            "LOST_JUNGLE_DEPTH_1",
            "LOST_JUNGLE_DEPTH_2",

            "WILD_JUNGLE_DEPTH_1",
            "WILD_JUNGLE_DEPTH_2",
            "WILD_JUNGLE_DEPTH_3",

            "PINACLE",

            "IMPASS",

            "ISLAND_1",
            "ISLAND_2",
            "ISLAND_3",
            "ISLAND_4",
            "ISLAND_5",

            "INTERIOR",

            "LAND_DIVIDE_1",
            "LAND_DIVIDE_2",
            "LAND_DIVIDE_3",
            "LAND_DIVIDE_4",
            "LAND_DIVIDE_5",
        };
        public static readonly List<string> LOCKS = new();
        
        // List of keys
        public static readonly List<string> KEYS_ARRAY = new()
        {
            "NONE",
            "PICKAXE",
            "AXE",
            "GRASS",
            "STONE",
            "WOOD",
            "MEAT",
            "PIGS",
            "FIRE",
            "POOP",
            "WOOL",
            "FARM",
            "HONEY",
            "GOLD",
            "BEEHAT",
            "TRINKETS",
            "HARD_WALRUS",
            "HARD_SPIDERS",
            "HARD_HOUNDS",
            "HARD_MERMS",
            "HARD_TENTACLES",
            "WALRUS",
            "SPIDERS",
            "HOUNDS",
            "MERMS",
            "GEARS",
            "CHESSMEN",
            "TENTACLES",
            "TIER1",
            "TIER2",
            "TIER3",
            "TIER4",
            "TIER5",
            "TIER6",
            "LIGHT",
            "FUNGUS",
            "CAVE",
            "LABYRINTH",
            "WILDS",
            "RUINS",
            "SACRED",
            "BADLANDS",
            "ISLAND1",
            "ISLAND2",
            "ISLAND3",
            "ISLAND4",
            "ISLAND5",
            "ISLAND6",
            "ISLAND7",

            // --PORKLAND
            "JUNGLE_DEPTH_1",
            "JUNGLE_DEPTH_2",
            "JUNGLE_DEPTH_3",
            "CIVILIZATION_1",
            "CIVILIZATION_2",
            "RUINS_ENTRANCE_1",
            "RUINS_EXIT_1",

            "OTHER_CIVILIZATION_1",
            "OTHER_CIVILIZATION_2",
            "OTHER_JUNGLE_DEPTH_1",
            "OTHER_JUNGLE_DEPTH_2",

            "LOST_JUNGLE_DEPTH_1",
            "LOST_JUNGLE_DEPTH_2",

            "WILD_JUNGLE_DEPTH_1",
            "WILD_JUNGLE_DEPTH_2",
            "WILD_JUNGLE_DEPTH_3",

            "PINACLE",

            "IMPASS",

            "ISLAND_1",
            "ISLAND_2",
            "ISLAND_3",
            "ISLAND_4",
            "ISLAND_5",

            "INTERIOR",

            "LAND_DIVIDE_1",
            "LAND_DIVIDE_2",
            "LAND_DIVIDE_3",
            "LAND_DIVIDE_4",
            "LAND_DIVIDE_5",
        };
        public static readonly List<string> KEYS = new();
        
        // -- Locks are unlocked if ANY key is provided.
		// -- However, ALL locks must be opened for a task to be unlocked.
	    public static Dictionary<string, List<string>> LOCKS_KEYS = new()
	    {
		    ["NONE"] = new List<string>(),
		    ["HARD_MONSTERS_DEFEATED"] =
		    {
			    "HARD_WALRUS",
			    "HARD_SPIDERS",
			    "HARD_HOUNDS",
			    "HARD_MERMS",
			    "HARD_TENTACLES",
			    "CHESSMEN",
		    },
		    ["MONSTERS_DEFEATED"] =
		    {
			    "WALRUS",
			    "SPIDERS",
			    "HOUNDS",
			    "MERMS",
			    "TENTACLES",
			    "CHESSMEN",
		    },
		    ["SPIDERS_DEFEATED"] =
		    {
			    "SPIDERS",
		    },
		    ["BASIC_COMBAT"] =
		    {
			    "AXE",
			    "PIGS",
		    },
		    ["ADVANCED_COMBAT"] =
		    {
			    "GOLD",
			    "HONEY",
		    },
		    ["ROCKS"] =
		    {
			    "PICKAXE"
		    },
		    ["PIGGIFTS"] =
		    {
			    "MEAT",
			    "AXE",
			    "PICKAXE",
		    },
		    ["TREES"] =
		    {
			    "AXE",
			    "FIRE",
		    },
		    ["SPIDERDENS"] =
		    {
			    "PIGS",
			    "FIRE",
			    "AXE",
			    "PICKAXE",
			    "HONEY",
		    },
		    ["BEEHIVE"] =
		    {
			    "AXE",
		    },
		    ["FARM"] =
		    {
			    "POOP",
		    },
		    ["MEAT"] =
		    {
			    "SPIDERS",
			    "PIGS",
			    "FARM",
		    },
		    ["KILLERBEES"] =
		    {
			    "BEEHAT",
		    },
		    ["PIGKING"] =
		    {
			    "TRINKETS",
		    },
		    ["TREES"] =
		    {
			    "AXE",
			    "PIGS",
		    },
		    ["ONLYTIER1"] =
		    {
			    "TIER1",
		    },
		    ["TIER1"] =
		    {
			    "TIER1",
			    "TIER2",
		    },
		    ["TIER2"] =
		    {
			    "TIER2",
			    "TIER3",
		    },
		    ["TIER3"] =
		    {
			    "TIER3",
			    "TIER4",
		    },
		    ["TIER4"] =
		    {
			    "TIER4",
			    "TIER5",
		    },
		    ["TIER5"] =
		    {
			    "TIER5",
			    "TIER6",
		    },

		    ["LIGHT"] =
		    {
			    "LIGHT",
		    },
		    ["CAVE"] =
		    {
			    "CAVE",
		    },
		    ["FUNGUS"] =
		    {
			    "FUNGUS",
		    },
		    ["LABYRINTH"] =
		    {
			    "LABYRINTH",
		    },
		    ["WILDS"] =
		    {
			    "WILDS",
		    },
		    ["RUINS"] =
		    {
			    "RUINS"
		    },
		    ["SACRED"] =
		    {
			    "SACRED"
		    },
		    ["ISLAND1"] =
		    {
			    "ISLAND1"
		    },
		    ["ISLAND2"] =
		    {
			    "ISLAND2"
		    },
		    ["ISLAND3"] =
		    {
			    "ISLAND3"
		    },
		    ["ISLAND4"] =
		    {
			    "ISLAND4"
		    },
		    ["ISLAND5"] =
		    {
			    "ISLAND5"
		    },
		    ["ISLAND6"] =
		    {
			    "ISLAND6"
		    },
		    ["ISLAND7"] =
		    {
			    "ISLAND7"
		    },

		    // --PORKLAND
		    ["JUNGLE_DEPTH_1"] =
		    {
			    "JUNGLE_DEPTH_1",
		    },
		    ["JUNGLE_DEPTH_2"] =
		    {
			    "JUNGLE_DEPTH_2",
		    },
		    ["JUNGLE_DEPTH_3"] =
		    {
			    "JUNGLE_DEPTH_3",
		    },
		    ["CIVILIZATION_1"] =
		    {
			    "CIVILIZATION_1",
		    },
		    ["CIVILIZATION_2"] =
		    {
			    "CIVILIZATION_2",
		    },
		    ["OTHER_CIVILIZATION_1"] =
		    {
			    "OTHER_CIVILIZATION_1",
		    },
		    ["OTHER_CIVILIZATION_2"] =
		    {
			    "OTHER_CIVILIZATION_2",
		    },
		    ["OTHER_JUNGLE_DEPTH_1"] =
		    {
			    "OTHER_JUNGLE_DEPTH_1",
		    },
		    ["OTHER_JUNGLE_DEPTH_2"] =
		    {
			    "OTHER_JUNGLE_DEPTH_2",
		    },
		    ["LOST_JUNGLE_DEPTH_1"] =
		    {
			    "LOST_JUNGLE_DEPTH_1",
		    },
		    ["LOST_JUNGLE_DEPTH_2"] =
		    {
			    "LOST_JUNGLE_DEPTH_2",
		    },
		    ["WILD_JUNGLE_DEPTH_1"] =
		    {
			    "WILD_JUNGLE_DEPTH_1",
		    },
		    ["WILD_JUNGLE_DEPTH_2"] =
		    {
			    "WILD_JUNGLE_DEPTH_2",
		    },
		    ["WILD_JUNGLE_DEPTH_3"] =
		    {
			    "WILD_JUNGLE_DEPTH_3",
		    },

		    ["RUINS_ENTRANCE_1"] =
		    {
			    "RUINS_ENTRANCE_1",
		    },
		    ["RUINS_EXIT_1"] =
		    {
			    "RUINS_EXIT_1",
		    },

		    ["IMPASS"] =
		    {
			    "IMPASS",
		    },

		    ["ISLAND_1"] =
		    {
			    "ISLAND_1",
		    },
		    ["ISLAND_2"] =
		    {
			    "ISLAND_2",
		    },
		    ["ISLAND_3"] =
		    {
			    "ISLAND_3",
		    },
		    ["ISLAND_4"] =
		    {
			    "ISLAND_4",
		    },
		    ["ISLAND_5"] =
		    {
			    "ISLAND_5",
		    },


		    ["INTERIOR"] =
		    {
			    "INTERIOR",
		    },

		    ["LAND_DIVIDE_1"] =
		    {
			    "LAND_DIVIDE_1",
		    },
		    ["LAND_DIVIDE_2"] =
		    {
			    "LAND_DIVIDE_2",
		    },
		    ["LAND_DIVIDE_3"] =
		    {
			    "LAND_DIVIDE_3",
		    },
		    ["LAND_DIVIDE_4"] =
		    {
			    "LAND_DIVIDE_4",
		    },
		    ["LAND_DIVIDE_5"] =
		    {
			    "LAND_DIVIDE_5",
		    },

		    ["PINACLE"] =
		    {
			    "PINACLE",
		    },
	    };
        
	    
        static LockAndKey()
        {
            foreach (string locks in LOCKS_ARRAY)
            {
                Assert.IsFalse(LOCKS.Contains(locks), $"Lock {locks} is defined twice!");
                LOCKS.Add(locks);
            }
            
            foreach (string key in KEYS_ARRAY)
            {
                Assert.IsFalse(KEYS.Contains(key), $"Key {key} is defined twice!");
                KEYS.Add(key);
            }
            
            foreach (string lockKey in LOCKS_KEYS.Keys)
            {
	            Assert.IsTrue(LOCKS.Contains(lockKey), "A lock in the lock_keys is misnamed!");
	            foreach (string key in LOCKS_KEYS[lockKey])
	            {
		            Assert.IsTrue(KEYS.Contains(key), $"A key in lock {lockKey} is misnamed!");
	            }
            }
        }
    }
}