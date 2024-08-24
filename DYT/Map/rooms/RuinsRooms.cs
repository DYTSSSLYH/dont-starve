// ------------------------------------------------------------------------------------
// -- Ruins ---------------------------------------------------------------------------
// ------------------------------------------------------------------------------------
namespace DYT.Map.rooms
{
    public class RuinsRooms
    {
        static RuinsRooms()
        {
	        Rooms.AddRoom("Labyrinth", new Room
	        {
		        //-- Not a real Labyrinth.. more of a maze really.
		        colour = { r = 0.25f, g = 0.28f, b = 0.25f, a = 0.50f },
		        value = Constant.GROUND.MUD,
		        tags = { "Labyrinth" },
		        internal_type = Constant.NODE_INTERNAL_CONNECTION_TYPE.EdgeCentroid,
	        });
	        Rooms.AddRoom("LabyrinthEntrance", new Room
	        {
		        colour = { r = 0.2f, g = 0.0f, b = 0.2f, a = 0.3f },
		        value = Constant.GROUND.MUD,
		        tags = { "ForceConnected", "LabyrinthEntrance" }, //--"Labyrinth",
		        contents =
		        {
			        distributepercent = 0.2f,
			        distributeprefabs =
			        {
				        ["lichen"] = 0.8f,
				        ["cave_fern"] = 1,
				        ["pillar_algae"] = 0.05f,

				        ["flower_cave"] = 0.2f,
				        ["flower_cave_double"] = 0.1f,
				        ["flower_cave_triple"] = 0.05f,
			        },
		        }
	        });

			//-- TODO: need a way to force connect to previous story? ForceConnected doesnt seem to work
	        Rooms.AddRoom("LabyrinthCityEntrance", new Room
	        {
		        colour = { r = 0.2f, g = 0.0f, b = 0.2f, a = 0.3f },
		        value = Constant.GROUND.MUD,
		        tags = { "ForceConnected", "MazeEntrance", "LabyrinthEntrance" }, //-- MazeExit?
		        contents =
		        {
			        distributepercent = 0.2f,
			        distributeprefabs =
			        {
				        ["lichen"] = 0.8f,
				        ["cave_fern"] = 1,
			        },
		        }
	        });

	        Rooms.AddRoom("RuinedCity", new Room
	        {
		        //-- Maze used to define room connectivity
		        colour = { r = 0.25f, g = 0.28f, b = 0.25f, a = 0.50f },
		        value = Constant.GROUND.CAVE,
		        tags = { "Maze" },
		        internal_type = Constant.NODE_INTERNAL_CONNECTION_TYPE.EdgeCentroid,
	        });
	        Rooms.AddRoom("RuinedCityEntrance", new Room
	        {
		        colour = { r = 0.2f, g = 0.0f, b = 0.2f, a = 0.3f },
		        value = Constant.GROUND.MUD,
		        tags = { "ForceConnected", "MazeEntrance" }, //--"Maze",
		        contents =
		        {
			        distributepercent = 0.07f,
			        distributeprefabs =
			        {
				        ["blue_mushroom"] = 1,
				        ["cave_fern"] = 1,
				        ["lichen"] = 0.5f,
			        },
		        }
	        });



	        Rooms.AddRoom("RuinedGuarden", new Room
	        {
		        colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
		        value = Constant.GROUND.FUNGUS,
		        contents =
		        {

			        countprefabs =
			        {
				        ["mushtree"] = () => 3 + WorldGenMain.random.Next(3),
				        ["flower_cave"] = () => 5 + WorldGenMain.random.Next(3),
				        ["gravestone"] = () => 4 + WorldGenMain.random.Next(4),
				        ["mound"] = () => 4 + WorldGenMain.random.Next(4)
			        }
		        }
	        });


			//---SACRED

	        Rooms.AddRoom("SacredEntrance", new Room
	        {
		        colour = { r = 0.2f, g = 0.0f, b = 0.2f, a = 0.3f },
		        value = Constant.GROUND.TILES,
		        tags = { "ForceConnected", "MazeEntrance" }, //--"Maze",
		        contents =
		        {
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["nightmarelight"] = 1,
			        },
		        }
	        });

	        Rooms.AddRoom("BGSacredGround", new Room
	        {
		        colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
		        value = Constant.GROUND.TILES,
		        contents =
		        {
			        distributepercent = 0.03f,
			        distributeprefabs =
			        {
				        ["chessjunk1"] = 0.1f,
				        ["chessjunk2"] = 0.1f,
				        ["chessjunk3"] = 0.1f,

				        ["nightmarelight"] = 1,

				        ["ruins_statue_head"] = 0.1f,
				        ["ruins_statue_head_nogem"] = 0.2f,

				        ["ruins_statue_mage"] = 0.1f,
				        ["ruins_statue_mage_nogem"] = 0.2f,

				        ["rook_nightmare"] = 0.07f,
				        ["bishop_nightmare"] = 0.07f,
				        ["knight_nightmare"] = 0.07f,
			        }
		        }
	        });

	        Rooms.AddRoom("Altar", new Room
	        {
		        colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
		        value = Constant.GROUND.TILES,
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["AltarRoom"] = () => 1,
			        },
			        distributepercent = 0.03f,
			        distributeprefabs =
			        {
				        ["chessjunk1"] = 0.1f,
				        ["chessjunk2"] = 0.1f,
				        ["chessjunk3"] = 0.1f,

				        ["nightmarelight"] = 1,

				        ["ruins_statue_head"] = 0.1f,
				        ["ruins_statue_head_nogem"] = 0.2f,

				        ["ruins_statue_mage"] = 0.1f,
				        ["ruins_statue_mage_nogem"] = 0.2f,

				        ["rook_nightmare"] = 0.07f,
				        ["bishop_nightmare"] = 0.07f,
				        ["knight_nightmare"] = 0.07f,
			        }

		        }
	        });

	        Rooms.AddRoom("Barracks", new Room
	        {
		        colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
		        value = Constant.GROUND.TILES,
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["Barracks"] = () => 1,
			        },

			        distributepercent = 0.03f,
			        distributeprefabs =
			        {
				        ["chessjunk1"] = 0.1f,
				        ["chessjunk2"] = 0.1f,
				        ["chessjunk3"] = 0.1f,

				        ["nightmarelight"] = 1,

				        ["ruins_statue_head"] = 0.1f,
				        ["ruins_statue_head_nogem"] = 0.2f,

				        ["ruins_statue_mage"] = 0.1f,
				        ["ruins_statue_mage_nogem"] = 0.2f,

				        ["rook_nightmare"] = 0.07f,
				        ["bishop_nightmare"] = 0.07f,
				        ["knight_nightmare"] = 0.07f,


			        }
		        }
	        });

	        Rooms.AddRoom("Bishops", new Room
	        {
		        colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
		        value = Constant.GROUND.TILES,
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["Barracks2"] = () => 1,
			        },
			        distributepercent = 0.03f,
			        distributeprefabs =
			        {
				        ["chessjunk1"] = 0.1f,
				        ["chessjunk2"] = 0.1f,
				        ["chessjunk3"] = 0.1f,

				        ["nightmarelight"] = 1,

				        ["ruins_statue_head"] = 0.1f,
				        ["ruins_statue_head_nogem"] = 0.2f,

				        ["ruins_statue_mage"] = 0.1f,
				        ["ruins_statue_mage_nogem"] = 0.2f,

				        ["rook_nightmare"] = 0.07f,
				        ["bishop_nightmare"] = 0.1f,
				        ["knight_nightmare"] = 0.07f,
			        }

		        }
	        });

	        Rooms.AddRoom("Spiral", new Room
	        {
		        colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
		        value = Constant.GROUND.TILES,
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["Spiral"] = () => 1,
			        },

			        distributepercent = 0.03f,
			        distributeprefabs =
			        {
				        ["chessjunk1"] = 0.1f,
				        ["chessjunk2"] = 0.1f,
				        ["chessjunk3"] = 0.1f,

				        ["nightmarelight"] = 1,

				        ["ruins_statue_head"] = 0.1f,
				        ["ruins_statue_head_nogem"] = 0.2f,

				        ["ruins_statue_mage"] = 0.1f,
				        ["ruins_statue_mage_nogem"] = 0.2f,

				        ["rook_nightmare"] = 0.07f,
				        ["bishop_nightmare"] = 0.07f,
				        ["knight_nightmare"] = 0.07f,
			        }
		        }
	        });

	        Rooms.AddRoom("BrokenAltar", new Room
	        {
		        colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
		        value = Constant.GROUND.TILES,
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["BrokenAltar"] = () => 1,
			        },

			        distributepercent = 0.05f,
			        distributeprefabs =
			        {
				        ["chessjunk1"] = 0.1f,
				        ["chessjunk2"] = 0.1f,
				        ["chessjunk3"] = 0.1f,

				        ["nightmarelight"] = 1,

				        ["ruins_statue_head"] = 0.1f,
				        ["ruins_statue_head_nogem"] = 0.2f,

				        ["ruins_statue_mage"] = 0.1f,
				        ["ruins_statue_mage_nogem"] = 0.2f,

				        ["rook_nightmare"] = 0.07f,
				        ["bishop_nightmare"] = 0.07f,
				        ["knight_nightmare"] = 0.07f,
			        }

		        }
	        });

			//--"WILDS"

	        Rooms.AddRoom("RuinsCamp", new Room
	        {
		        colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
		        value = Constant.GROUND.MUD,
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["RuinsCamp"] = () => 1,
			        },
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["lichen"] = 0.1f,
				        ["cave_fern"] = 1,
				        ["pillar_algae"] = 0.01f,

				        ["flower_cave"] = 0.05f,
				        ["flower_cave_double"] = 0.03f,
				        ["flower_cave_triple"] = 0.01f,
			        }
		        }
	        });

	        Rooms.AddRoom("BGWilds", new Room
	        {
		        colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
		        value = Constant.GROUND.MUD,
		        contents =
		        {
			        distributepercent = 0.15f,
			        distributeprefabs =
			        {
				        ["lichen"] = 0.1f,
				        ["cave_fern"] = 1,
				        ["pillar_algae"] = 0.01f,

				        ["flower_cave"] = 0.05f,
				        ["flower_cave_double"] = 0.03f,
				        ["flower_cave_triple"] = 0.01f,
				        ["worm"] = 0.07f,

				        ["fissure_lower"] = 0.04f,
			        }
		        }
	        });

	        Rooms.AddRoom("PondWilds", new Room
	        {
		        colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
		        value = Constant.GROUND.MUD,
		        contents =
		        {
			        distributepercent = 0.15f,
			        distributeprefabs =
			        {
				        ["blue_mushroom"] = 0.15f,
				        ["cave_fern"] = 0.1f,
				        ["pillar_algae"] = 0.01f,
				        ["pond_cave"] = 0.1f,
				        ["fissure_lower"] = 0.05f,

			        }
		        }
	        });

	        Rooms.AddRoom("SlurperWilds", new Room
	        {
		        colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
		        value = Constant.GROUND.MUD,
		        contents =
		        {
			        distributepercent = 0.15f,
			        distributeprefabs =
			        {
				        ["blue_mushroom"] = 0.15f,
				        ["lichen"] = 0.25f,
				        ["cave_fern"] = 1,
				        ["pillar_algae"] = 0.01f,
				        ["slurper"] = 0.35f,

			        }
		        }
	        });

	        Rooms.AddRoom("LushWilds", new Room
	        {
		        colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
		        value = Constant.GROUND.MUD,
		        contents =
		        {
			        distributepercent = 0.25f,
			        distributeprefabs =
			        {
				        ["blue_mushroom"] = 0.15f,
				        ["lichen"] = 0.25f,
				        ["cave_fern"] = 1,
				        ["pillar_algae"] = 0.05f,

				        ["worm"] = 0.01f,

				        ["fissure_lower"] = 0.07f,

				        ["flower_cave"] = 0.1f,
				        ["flower_cave_double"] = 0.03f,
				        ["flower_cave_triple"] = 0.01f,
			        }
		        }
	        });

	        Rooms.AddRoom("LightWilds", new Room
	        {
		        colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
		        value = Constant.GROUND.MUD,
		        contents =
		        {
			        distributepercent = 0.15f,
			        distributeprefabs =
			        {
				        ["blue_mushroom"] = 0.1f,
				        ["lichen"] = 0.1f,
				        ["cave_fern"] = 0.7f,
				        ["pillar_algae"] = 0.05f,

				        ["flower_cave"] = 0.75f,
				        ["flower_cave_double"] = 0.33f,
				        ["flower_cave_triple"] = 0.15f,

				        ["fissure_lower"] = 0.07f,
			        }
		        }
	        });

			//--"MILITARY"


			Rooms.AddRoom("BGMilitary", new Room
			{
				colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
				value = Constant.GROUND.UNDERROCK,
				tags = { "Maze" },
				contents =
				{
					distributepercent = 0.05f,
					distributeprefabs =
					{
						["dropperweb"] = 1,
						["pillar_ruins"] = 0.33f,
						["nightmarelight"] = 0.33f,
						["rock_flintless"] = 0.66f,
					}
				}
			});

			Rooms.AddRoom("MilitaryEntrance", new Room
			{
				colour = { r = 0.2f, g = 0.0f, b = 0.2f, a = 0.3f },
				value = Constant.GROUND.UNDERROCK,
				tags = { "ForceConnected", "MazeEntrance" },
				contents =
				{

					countstaticlayouts =
					{
						["MilitaryEntrance"] = () => 1,
					},
				}
			});


	        //----"VILLAGE"


	        Rooms.AddRoom("BGMonkeyWilds", new Room
	        {
		        colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
		        value = Constant.GROUND.MUD,
		        tags = { "Maze" },
		        contents =
		        {
			        distributepercent = 0.09f,
			        distributeprefabs =
			        {
				        ["lichen"] = 0.3f,
				        ["cave_fern"] = 1,
				        ["pillar_algae"] = 0.05f,

				        ["cave_banana_tree"] = 0.1f,
				        ["monkeybarrel"] = 0.06f,
				        ["slurper"] = 0.06f,
				        ["pond_cave"] = 0.07f,
				        ["fissure_lower"] = 0.04f,
				        ["worm"] = 0.04f,
			        }
		        }
	        });

	        Rooms.AddRoom("Vacant", new Room
	        {
		        colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
		        value = Constant.GROUND.MUD,
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["CornerWall"] = () => WorldGenMain.random.Next(1, 3),
				        ["StraightWall"] = () => WorldGenMain.random.Next(1, 2),
				        ["CornerWall2"] = () => WorldGenMain.random.Next(1, 2),
				        ["StraightWall2"] = () => WorldGenMain.random.Next(1, 3),
			        },
			        distributepercent = 0.12f,
			        distributeprefabs =
			        {
				        ["lichen"] = 0.4f,
				        ["cave_fern"] = 0.6f,
				        ["pillar_algae"] = 0.01f,
				        ["slurper"] = 0.15f,
				        ["cave_banana_tree"] = 0.1f,
				        ["monkeybarrel"] = 0.2f,
				        ["dropperweb"] = 0.1f,
				        ["ruins_rubble_table"] = 0.1f,
				        ["ruins_rubble_chair"] = 0.1f,
				        ["ruins_rubble_vase"] = 0.1f,
			        }
		        }
	        });
        }
    }
}