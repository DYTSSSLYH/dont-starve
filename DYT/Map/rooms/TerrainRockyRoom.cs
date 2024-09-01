namespace DYT.Map.rooms
{
    public class TerrainRockyRoom
    {
        static TerrainRockyRoom()
        {
	        Rooms.AddRoom("BGChessRocky", new Room
	        {
		        colour = { r = 0.66f, g = 0.66f, b = 0.66f, a = 0.50f },
		        value = Constant.GROUND.ROCKY,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["ChessSpot1"] = () => WorldGenMain.random.Next(0, 3),
				        ["ChessSpot2"] = () => WorldGenMain.random.Next(0, 3),
				        ["ChessSpot3"] = () => WorldGenMain.random.Next(0, 3),
			        },
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["flint"] = 0.5f,
				        ["rock1"] = 1,
				        ["rock2"] = 1,
				        ["tallbirdnest"] = 0.008f,
			        },
		        }
	        });

	        Rooms.AddRoom("BGRocky", new Room
	        {
		        colour = { r = 0.66f, g = 0.66f, b = 0.66f, a = 0.50f },
		        value = Constant.GROUND.ROCKY,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["flint"] = 0.5f,
				        ["rock1"] = 1,
				        ["rock2"] = 1,
				        ["rock_ice"] = 0.4f, //-- Was removed, needs to be changed if we have ROG installed or not
				        ["tallbirdnest"] = 0.008f,
			        },
		        }
	        });
			//-- No trees, lots of rocks, rare tallbird nest, very rare spiderden
			Rooms.AddRoom("Rocky", new Room
			{
				colour = { r = 0.55f, g = 0.75f, b = 0.75f, a = 0.50f },
				value = Constant.GROUND.ROCKY,
				tags = { "ExitPiece", "Chester_Eyebone" },
				contents =
				{
					distributepercent = 0.1f,
					distributeprefabs =
					{
						["rock1"] = 0.5f,
						["rock2"] = 0.3f,
						["rock_ice"] = 1, //-- Was removed, needs to be changed if we have ROG installed or not
						["tallbirdnest"] = 0.4f, //--was 0.1f
						["spiderden"] = 0.01f,
						["blue_mushroom"] = 0.02f, //--was 0.002f
						["goldnugget"] = 1,
					},
				}
			});


			//----------------------------------------------
			//-------------- Added with RoG ----------------
			//----------------------------------------------

	        Rooms.AddRoom("RockyBuzzards", new Room
	        {
		        colour = { r = 0.55f, g = 0.75f, b = 0.75f, a = 0.50f },
		        value = Constant.GROUND.ROCKY,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["rock1"] = 0.5f,
				        ["rock2"] = 0.3f,
				        ["buzzardspawner"] = 0.1f, //-- Was removed, needs to be changed if we have ROG installed or not
				        ["blue_mushroom"] = 0.002f,
			        },
		        }
	        });

	        Rooms.AddRoom("GenericRockyNoThreat", new Room
	        {
		        colour = { r = 0.55f, g = 0.75f, b = 0.75f, a = 0.50f },
		        value = Constant.GROUND.ROCKY,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["rock1"] = 0.5f,
				        ["rock2"] = 0.3f,
				        ["rock_ice"] = 0.75f, //-- Was removed, needs to be changed if we have ROG installed or not
				        ["rocks"] = 1,
				        ["flint"] = 1,
				        ["blue_mushroom"] = 0.002f,
				        ["green_mushroom"] = 0.002f,
				        ["red_mushroom"] = 0.002f,
			        },
		        }
	        });

	        Rooms.AddRoom("MolesvilleRocky", new Room
	        {
		        //-- Replaced for MolesvilleRockyIsland in island.lua
		        colour = { r = 0.55f, g = 0.75f, b = 0.75f, a = 0.50f },
		        value = Constant.GROUND.ROCKY,
		        contents =
		        {
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["marsh_bush"] = 0.2f,
				        ["rock1"] = 0.5f,
				        ["rock2"] = 0.3f,
				        ["rock_ice"] = 0.3f, //-- Was removed, needs to be changed if we have ROG installed or not
				        ["rocks"] = 0.5f,
				        ["flint"] = 0.1f,
				        ["grass"] = 0.1f,
				        ["molehill"] = 1, //-- Was removed, needs to be changed if we have ROG installed or not

			        },
		        }
	        });

			//-----------------------------------------------------------------------------
			//-------- Added with Shipwrecked, only those should contain magmarocks -------
			//-----------------------------------------------------------------------------

	        Rooms.AddRoom("MolesvilleRockyIsland", new Room
	        {
		        //-- Exists in island.lua
		        colour = { r = 0.55f, g = 0.75f, b = 0.75f, a = 0.50f },
		        value = Constant.GROUND.ROCKY,
		        contents =
		        {
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["marsh_bush"] = 0.2f,
				        ["magmarock"] = 1,
				        ["magmarock_gold"] = 1,
				        ["rock1"] = 0.5f,
				        ["rock2"] = 0.3f,
				        ["rock_ice"] = 0.3f, //-- Was removed, needs to be changed if we have ROG installed or not
				        ["rocks"] = 0.5f,
				        ["flint"] = 0.1f,
				        ["grass"] = 0.1f,
				        //--molehill = 1,

			        },
		        }
	        });



	        Rooms.AddRoom("RockySpiders", new Room
	        {
		        colour = { r = 0.55f, g = 0.75f, b = 0.75f, a = 0.50f },
		        value = Constant.GROUND.ROCKY,
		        contents =
		        {
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["marsh_bush"] = 0.2f,
				        ["magmarock"] = 1,
				        ["magmarock_gold"] = 1,
				        ["rock1"] = 0.5f,
				        ["rock2"] = 0.3f,
				        ["rocks"] = 0.5f,
				        ["flint"] = 0.1f,
				        ["grass"] = 0.1f,
				        ["spiderden"] = 1, //--0.5f,
			        },
		        }
	        });

	        Rooms.AddRoom("RockyGold", new Room
	        {
		        colour = { r = 0.55f, g = 0.75f, b = 0.75f, a = 0.50f },
		        value = Constant.GROUND.ROCKY,
		        contents =
		        {
			        distributepercent = 0.3f,
			        distributeprefabs =
			        {
				        ["magmarock"] = 0.8f,
				        ["magmarock_gold"] = 1.2f, //--gold
				        ["rock1"] = 0.5f,
				        ["rock2"] = 0.3f,
				        ["rock_flintless"] = 0.5f,
				        ["rocks"] = 1,
				        ["flint"] = 0.5f,
				        ["goldnugget"] = 0.25f,
			        },
		        }
	        });

	        Rooms.AddRoom("RockyFlint", new Room
	        {
		        colour = { r = 0.55f, g = 0.75f, b = 0.75f, a = 0.50f },
		        value = Constant.GROUND.ROCKY,
		        contents =
		        {
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["magmarock"] = 1,
				        ["magmarock_gold"] = 0.8f, //--gold
				        ["rock1"] = 0.5f,
				        ["rock2"] = 0.3f,
				        ["rocks"] = 0.5f,
				        ["flint"] = 1.2f,
			        },
		        }
	        });

	        Rooms.AddRoom("RockyTallBird", new Room
	        {
		        colour = { r = 0.55f, g = 0.75f, b = 0.75f, a = 0.50f },
		        value = Constant.GROUND.ROCKY,
		        contents =
		        {
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["magmarock"] = 1,
				        ["magmarock_gold"] = 1,
				        ["rock1"] = 0.5f,
				        ["rock2"] = 0.3f,
				        ["rocks"] = 1,
				        ["rock_flintless"] = 1,
				        ["tallbirdnest"] = 1,
			        },
		        }
	        });

	        Rooms.AddRoom("RockyBlueMushroom", new Room
	        {
		        colour = { r = 0.55f, g = 0.75f, b = 0.75f, a = 0.50f },
		        value = Constant.GROUND.ROCKY,
		        contents =
		        {
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["magmarock"] = 1,
				        ["magmarock_gold"] = 1,
				        ["rock1"] = 0.5f,
				        ["rock2"] = 0.3f,
				        ["blue_mushroom"] = 1,
			        },
		        }
	        });

	        Rooms.AddRoom("RockyGoldBoon", new Room
	        {
		        colour = { r = 0.55f, g = 0.75f, b = 0.75f, a = 0.50f },
		        value = Constant.GROUND.ROCKY,
		        contents =
		        {
			        distributepercent = 0.25f,
			        distributeprefabs =
			        {
				        ["magmarock_gold"] = 1,
				        ["rock1"] = 0.5f,
				        ["rock2"] = 0.3f,
				        ["rocks"] = 3,
				        ["flint"] = 1,
				        ["goldnugget"] = 1,
			        },
		        }
	        });


			//-- No trees, lots of rocks, rare tallbird nest, very rare spiderden
			//-- Shipwrecked version os Rocky (can be seen above)
	        Rooms.AddRoom("RockyIsland", new Room
	        {
		        colour = { r = 0.55f, g = 0.75f, b = 0.75f, a = 0.50f },
		        value = Constant.GROUND.ROCKY,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["magmarock"] = 1,
				        ["magmarock_gold"] = 1,
				        ["rock1"] = 0.5f,
				        ["rock2"] = 0.3f,
				        ["tallbirdnest"] = 0.4f, //--was 0.1f
				        ["spiderden"] = 0.01f,
				        ["blue_mushroom"] = 0.02f, //--was 0.002f
				        ["goldnugget"] = 1,
			        },
		        }
	        });
        }
    }
}