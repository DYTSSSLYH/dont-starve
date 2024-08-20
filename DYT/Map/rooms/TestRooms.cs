// ------------------------------------------------------------------------------------
// -- TEST ROOMS -----------------------------------------------------------------------
// ------------------------------------------------------------------------------------
namespace DYT.Map.rooms
{
    public class TestRooms
    {
        static TestRooms()
        {
            Rooms.AddRoom("MaxPuzzle1", new Room
            {
                colour = {r = 0.3f, g = 0.8f, b = 0.5f, a = 0.50f},
                value = Constant.GROUND.MARSH,
                contents =
                {
                    countstaticlayouts =
                    {
                        ["MaxPuzzle1"] = () => 1
                    },
                    distributepercent = 0.2f,
                    distributeprefabs =
                    {
                        ["spider_nest"] = 0.02f,
                        ["spider"] = 0.5f,
                        ["spider_warrior"] = 0.2f,
                        ["marsh_tree"] = 6,
                        ["marsh_bush"] = 4f,
                    }
                }
            });
            Rooms.AddRoom("MaxPuzzle2", new Room
            {
                colour = {r = 0.3f, g = 0.8f, b = 0.5f, a = 0.50f},
                value = Constant.GROUND.MARSH,
                contents =
                {
                    countstaticlayouts =
                    {
                        ["MaxPuzzle2"] = () => 1
                    },
                    distributepercent = 0.5f,
                    distributeprefabs =
                    {
                        ["trap_teeth_maxwell"] = 20,
                        ["spider_nest"] = 0.02f,
                        ["marsh_tree"] = 6,
                        ["marsh_bush"] = 4f,
                    }
                }
            });
            Rooms.AddRoom("MaxPuzzle3", new Room
            {
	            colour = { r = 0.3f, g = 0.8f, b = 0.5f, a = 0.50f },
	            value = Constant.GROUND.MARSH,
	            contents =
	            {
		            countstaticlayouts =
		            {
			            ["MaxPuzzle3"] = () => 1,
		            },
		            distributepercent = 0.3f,
		            distributeprefabs =
		            {
			            ["beemine_maxwell"] = 12,
			            ["spider_nest"] = 0.02f,
			            // --TODO: Right now the warrior wanders off from his starting location; not good enough.
			            ["marsh_tree"] = 6,
			            ["marsh_bush"] = 4,
		            }
	            }
            });
            Rooms.AddRoom("SymmetryRoom", new Room
            {
	            colour = { r = 0.3f, g = 0.8f, b = 0.5f, a = 0.50f },
	            value = Constant.GROUND.GRASS,
	            contents =
	            {
		            countstaticlayouts =
		            {
			            ["SymmetryTest"] = () => 2,
			            ["SymmetryTest2"] = () => 2,
		            },
	            }
            });
            Rooms.AddRoom("TEST_ROOM", new Room
            {
	            colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
	            value = Constant.GROUND.FUNGUS,
	            contents =
	            {
		            countstaticlayouts =
		            {
			            ["test"] = () => 1,
		            },
		            countprefabs =
		            {
			            ["flower"] = () => 4 + WorldGenMain.random.Next(4),
			            ["adventure_portal"] = () => 1,
		            },
		            distributepercent = 0.01f,
		            distributeprefabs =
		            {
			            ["grass"] = 1,
		            },
	            }
            });
            Rooms.AddRoom("MaxHome", new Room
            {
	            colour = { r = 0.3f, g = 0.8f, b = 0.5f, a = 0.50f },
	            value = Constant.GROUND.IMPASSABLE,
	            contents =
	            {
		            countstaticlayouts =
		            {
			            ["MaxwellHome"] = () => 1,
		            },
	            }
            });
            Rooms.AddRoom("TestMixedForest", new Room
            {
	            colour = { r = 0.3f, g = 0.8f, b = 0.5f, a = 0.50f },
	            value = Constant.GROUND.FOREST,
	            contents =
	            {
		            distributepercent = 0.8f,
		            distributeprefabs =
		            {
			            ["evergreen"] = 1,
			            ["evergreen_sparse"] = 1,
		            }
	            }
            });
            Rooms.AddRoom("TestSparseForest", new Room
            {
	            colour = { r = 0.3f, g = 0.8f, b = 0.5f, a = 0.50f },
	            value = Constant.GROUND.FOREST,
	            contents =
	            {
		            distributepercent = 0.8f,
		            distributeprefabs =
		            {
			            ["evergreen_sparse"] = 1,
		            }
	            }
            });
            Rooms.AddRoom("TestPineForest", new Room
            {
	            colour = { r = 0.3f, g = 0.8f, b = 0.5f, a = 0.50f },
	            value = Constant.GROUND.FOREST,
	            contents =
	            {
		            distributepercent = 0.8f,
		            distributeprefabs =
		            {
			            ["evergreen"] = 1,
		            }
	            }
            });
        }
    }
}