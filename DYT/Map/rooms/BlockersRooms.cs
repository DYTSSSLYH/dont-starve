// ------------------------------------------------------------------------------------
// -- BLOCKERS ------------------------------------------------------------------------
// ------------------------------------------------------------------------------------
namespace DYT.Map.rooms
{
    public class BlockersRooms
    {
        static BlockersRooms()
        {
	        Rooms.AddRoom("Deerclopsfield", new Room
	        {
		        colour = { r = 0.2f, g = 0.0f, b = 0.2f, a = 0.3f },
		        value = Constant.GROUND.FOREST,
		        tags = { "ForceConnected", "RoadPoison" },
		        contents =
		        {
			        countprefabs =
			        {
				        ["deerclops"] = () => 1,
			        },
			        distributepercent = 0.6f,
			        distributeprefabs =
			        {
				        ["gravestone"] = 0.01f,
				        ["pighouse"] = 0.015f,
				        ["spiderden"] = 0.02f,
				        ["grass"] = 0.0025f,
				        ["sapling"] = 0.15f,
				        ["berrybush"] = 0.005f,
				        ["rock1"] = 0.004f,
				        ["rock2"] = 0.004f,
				        ["evergreen"] = 1.5f,
				        ["flower"] = 0.05f,
				        ["pond"] = 0.001f,
				        ["blue_mushroom"] = 0.02f,
				        ["green_mushroom"] = 0.02f,
				        ["red_mushroom"] = 0.02f,
			        },
		        }
	        });
	        Rooms.AddRoom("Walrusfield", new Room
	        {
		        colour = { r = 0.2f, g = 0.0f, b = 0.2f, a = 0.3f },
		        value = Constant.GROUND.GRASS,
		        tags = { "ForceConnected", "RoadPoison" },
		        contents =
		        {
			        countprefabs =
			        {
				        ["walrus_camp"] = () => 6,
			        },
			        distributepercent = 0.275f,
			        distributeprefabs =
			        {
				        ["flower"] = 0.112f,
				        ["grass"] = 0.2f,
				        ["carrot_planted"] = 0.05f,
				        ["flint"] = 0.05f,
				        ["sapling"] = 0.2f,
				        ["evergreen"] = 0.3f,
				        ["pond"] = 0.005f,
			        },
		        }
	        });
	        Rooms.AddRoom("Chessfield", new Room
	        {
		        colour = { r = 0.2f, g = 0.0f, b = 0.2f, a = 0.3f },
		        value = Constant.GROUND.CHECKER,
		        tags = { "ForceConnected", "RoadPoison" },
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["ChessSpot1"] = () => WorldGenMain.random.Next(2, 3),
				        ["ChessSpot2"] = () => WorldGenMain.random.Next(2, 3),
			        },
			        distributepercent = 0.4f,
			        distributeprefabs =
			        {
				        ["marblepillar"] = 1,
				        ["knight"] = 0.8f,
				        ["bishop"] = 0.5f,
				        ["rook"] = 0.05f,
				        ["marbletree"] = 2,
				        ["flower_evil"] = 2,
			        }
		        }
	        });
	        Rooms.AddRoom("ChessfieldA", Rooms.MakeSetpieceBlockerRoom("ChessBlocker"));
	        Rooms.AddRoom("ChessfieldB", Rooms.MakeSetpieceBlockerRoom("ChessBlockerB"));
	        Rooms.AddRoom("ChessfieldC", Rooms.MakeSetpieceBlockerRoom("ChessBlockerC"));
	        Rooms.AddRoom("Tallbirdfield", new Room
	        {
		        colour = { r = 0.2f, g = 0.0f, b = 0.2f, a = 0.3f },
		        value = Constant.GROUND.ROCKY,
		        tags = { "ForceConnected", "RoadPoison" },
		        contents =
		        {
			        countprefabs =
			        {
				        ["tallbirdnest"] = () => 1,
			        },
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["rock1"] = 1,
				        ["rock2"] = 1,
				        ["tallbirdnest"] = 1,
			        }
		        }
	        });
	        Rooms.AddRoom("TallbirdfieldSmallA", Rooms.MakeSetpieceBlockerRoom("TallbirdBlockerSmall"));
	        Rooms.AddRoom("TallbirdfieldA", Rooms.MakeSetpieceBlockerRoom("TallbirdBlocker"));
	        Rooms.AddRoom("TallbirdfieldB", Rooms.MakeSetpieceBlockerRoom("TallbirdBlockerB"));
	        Rooms.AddRoom("Mermfield", new Room
	        {
		        colour = { r = 0.2f, g = 0.0f, b = 0.2f, a = 0.3f },
		        value = Constant.GROUND.MARSH,
		        tags = { "ForceConnected", "RoadPoison" },
		        contents =
		        {
			        countprefabs =
			        {
				        ["pighead"] = () => WorldGenMain.random.Next(6),
			        },
			        distributepercent = 0.3f,
			        distributeprefabs =
			        {
				        ["mermhouse"] = 1,
				        ["reeds"] = 2,
				        ["pond_mos"] = 0.5f,
				        ["marsh_bush"] = 2,
			        }
		        }
	        });
	        Rooms.AddRoom("Moundfield", new Room
	        {
		        colour = { r = 0.2f, g = 0.0f, b = 0.2f, a = 0.3f },
		        value = Constant.GROUND.DIRT,
		        tags = { "ForceConnected", "RoadPoison" },
		        contents =
		        {
			        countprefabs =
			        {
				        ["houndmound"] = () => 1, //-- sometimes zero spawn, so lets have at least one
			        },
			        distributepercent = 0.2f,
			        distributeprefabs =
			        {
				        ["houndmound"] = 0.4f,
				        ["houndbone"] = 3,
				        ["marsh_bush"] = 1,
				        ["marsh_tree"] = 0.3f,
				        ["rock1"] = 0.5f,
				        ["rock2"] = 0.5f,
				        ["rocks"] = 0.05f,
			        }
		        }
	        });
	        Rooms.AddRoom("Minefield", new Room
	        {

		        //-- DO NOT USE -- it destroys performance, so many mosquitos!!
		        colour = { r = 0.2f, g = 0.0f, b = 0.2f, a = 0.3f },
		        value = Constant.GROUND.MARSH,
		        tags = { "ForceConnected", "RoadPoison" },
		        contents =
		        {
			        distributepercent = 0.5f,
			        distributeprefabs =
			        {
				        ["marsh_tree"] = 1,
				        ["beemine_maxwell"] = 4,
			        }
		        }
	        });
	        Rooms.AddRoom("Trapfield", new Room
	        {
		        colour = { r = 0.0f, g = 0.4f, b = 0.2f, a = 0.3f },
		        value = Constant.GROUND.DIRT,
		        tags = { "ForceConnected", "RoadPoison" },
		        contents =
		        {
			        countprefabs =
			        {
				        ["homesign"] = () => 2,
			        },
			        distributepercent = 0.4f,
			        distributeprefabs =
			        {
				        ["houndbone"] = 1,
				        ["trap_teeth_maxwell"] = 1,
			        }
		        }
	        });
	        Rooms.AddRoom("TrappedForest", new Room
	        {
		        colour = { r = 0.0f, g = 0.4f, b = 0.2f, a = 0.3f },
		        value = Constant.GROUND.FOREST,
		        tags = { "ForceConnected", "RoadPoison" },
		        contents =
		        {
//--									countstaticlayouts={
//--										["FisherPig"]=1//--()=>WorldGenMain.random.Next(0,1) ,
//--										},
			        distributepercent = 1.0f,
			        distributeprefabs =
			        {
				        ["evergreen_sparse"] = 1,
				        ["trap_teeth_maxwell"] = 1,
			        }
		        }
	        });
	        Rooms.AddRoom("SpiderfieldEasy", new Room
	        {
		        colour = { r = 0.0f, g = 0.4f, b = 0.2f, a = 0.3f },
		        value = Constant.GROUND.FOREST,
		        tags = { "ForceConnected", "RoadPoison" },
		        contents =
		        {
//--									countstaticlayouts={
//--										["FisherPig"]=1//--()=>WorldGenMain.random.Next(0,1) ,
//--										},
			        distributepercent = 0.4f,
			        distributeprefabs =
			        {
				        ["evergreen_sparse"] = 1,
				        ["spiderden"] = 0.1f,
			        },
			        prefabdata =
			        {
				        ["spiderden"] = () => "{growable={stage=2}}",
			        },
		        }
	        });
	        Rooms.AddRoom("Spiderfield", new Room
	        {
		        colour = { r = 0.0f, g = 0.4f, b = 0.2f, a = 0.3f },
		        value = Constant.GROUND.FOREST,
		        tags = { "ForceConnected", "RoadPoison" },
		        contents =
		        {
//--									countstaticlayouts={
//--										["FisherPig"]=1//--()=>WorldGenMain.random.Next(0,1) ,
//--										},
			        distributepercent = 0.4f,
			        distributeprefabs =
			        {
				        ["evergreen_sparse"] = 1,
				        ["spiderden"] = 0.15f,
			        },
			        prefabdata =
			        {
				        ["spiderden"] = () => "{growable={stage=3}}",
			        },
		        }
	        });
	        Rooms.AddRoom("SpiderfieldEasyA", Rooms.MakeSetpieceBlockerRoom("SpiderBlockerEasy"));
	        Rooms.AddRoom("SpiderfieldEasyB", Rooms.MakeSetpieceBlockerRoom("SpiderBlockerEasyB"));
	        Rooms.AddRoom("SpiderfieldA", Rooms.MakeSetpieceBlockerRoom("SpiderBlocker"));
	        Rooms.AddRoom("SpiderfieldB", Rooms.MakeSetpieceBlockerRoom("SpiderBlockerB"));
	        Rooms.AddRoom("SpiderfieldC", Rooms.MakeSetpieceBlockerRoom("SpiderBlockerC"));
	        Rooms.AddRoom("DenseForest", Rooms.MakeSetpieceBlockerRoom("TreeBlocker")); //-- DO NOT USE! The trees right now don't block...
	        Rooms.AddRoom("DenseRocks", Rooms.MakeSetpieceBlockerRoom("RockBlocker"));
	        Rooms.AddRoom("InsanityWall", Rooms.MakeSetpieceBlockerRoom("InsanityBlocker"));
	        Rooms.AddRoom("SanityWall", Rooms.MakeSetpieceBlockerRoom("SanityBlocker"));
	        Rooms.AddRoom("PigGuardpostEasy", Rooms.MakeSetpieceBlockerRoom("PigGuardsEasy"));
	        Rooms.AddRoom("PigGuardpost", Rooms.MakeSetpieceBlockerRoom("PigGuards"));
	        Rooms.AddRoom("PigGuardpostB", Rooms.MakeSetpieceBlockerRoom("PigGuardsB"));
	        Rooms.AddRoom("SpiderCon", new Room
	        {
		        colour = { r = 0.5f, g = 0.7f, b = 0.5f, a = 0.3f },
		        value = Constant.GROUND.MARSH,
		        tags = { "ForceConnected", "RoadPoison" },
		        contents =
		        {
			        countstaticlayouts = { ["StoneHenge"] = () => WorldGenMain.random.Next(0, 1) },
			        distributepercent = 0.2f,
			        distributeprefabs =
			        {
				        ["spider"] = 0.5f,
				        ["spider_warrior"] = 0.2f,
				        //--TODO: Right now the warrior wanders off from his starting location; not good enough.
				        ["marsh_tree"] = 6,
				        ["marsh_bush"] = 4,
			        }
		        }
	        });
	        Rooms.AddRoom("Waspnests", new Room
	        {
		        colour = { r = 0.9f, g = 0.1f, b = 0.1f, a = 0.3f },
		        value = Constant.GROUND.GRASS,
		        tags = { "ForceConnected", "RoadPoison" },
		        contents =
		        {
			        distributepercent = 0.5f,
			        distributeprefabs =
			        {
				        ["flower"] = 6,
				        ["beehive"] = 1,
				        ["grass"] = 2,
				        ["wasphive"] = 1,
			        }
		        }
	        });

	        Rooms.AddRoom("Tentacleland", new Room
	        {
		        colour = { r = 0.45f, g = 0.75f, b = 0.45f, a = 0.50f },
		        value = Constant.GROUND.MARSH,
		        tags = { "ForceConnected", "RoadPoison" },
		        contents =
		        {
			        distributepercent = 0.3f,
			        distributeprefabs =
			        {
				        ["tentacle"] = 14,
				        ["pond_mos"] = 0.1f,
				        ["reeds"] = 0.2f, //--()=>3 + WorldGenMain.random.Next(4),
				        ["mandrake"] = 0.0001f,
				        ["marsh_bush"] = 1.5f,
				        ["marsh_tree"] = 1.1f,
			        },
		        }
	        });
	        Rooms.AddRoom("TentaclelandA", Rooms.MakeSetpieceBlockerRoom("TentacleBlocker"));
	        Rooms.AddRoom("TentaclelandSmallA", Rooms.MakeSetpieceBlockerRoom("TentacleBlockerSmall"));

	        Rooms.AddRoom("SanityWormholeBlocker", new Room
	        {
		        colour = { r = 0.45f, g = 0.75f, b = 0.45f, a = 0.50f },
		        type = "blank",
		        tags = { "OneshotWormhole", "ForceDisconnected" },
		        value = Constant.GROUND.IMPASSABLE,
		        contents = { },
	        });
	        Rooms.AddRoom("ForceDisconnectedRoom", new Room
	        {
		        colour = { r = 0.45f, g = 0.75f, b = 0.45f, a = 0.50f },
		        type = "blank",
		        tags = { "ForceDisconnected" },
		        value = Constant.GROUND.IMPASSABLE,
		        contents = { },
	        });
        }
    }
}