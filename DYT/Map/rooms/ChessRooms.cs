// ------------------------------------------------------------------------------------
// -- CHESS CORRUPTION ----------------------------------------------------------------
// ------------------------------------------------------------------------------------
namespace DYT.Map.rooms
{
    public class ChessRooms
    {
        static ChessRooms()
        {
	        Rooms.AddRoom("ChessArea", new Room
	        {
		        colour = { r = 0.5f, g = 0.7f, b = 0.5f, a = 0.3f },
		        value = Constant.GROUND.CHECKER,
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["Maxwell1"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["Maxwell2"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["Maxwell3"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["Maxwell4"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["Maxwell6"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["Maxwell7"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["ChessSpot1"] = () => WorldGenMain.random.Next(0, 3),
				        ["ChessSpot2"] = () => WorldGenMain.random.Next(0, 3),
				        ["ChessSpot3"] = () => WorldGenMain.random.Next(0, 3),
			        },
			        distributepercent = 0.25f,
			        distributeprefabs =
			        {
				        ["marbletree"] = 1,
				        ["flower_evil"] = 1,
				        ["marblepillar"] = 0.1f,
				        ["knight"] = 0.1f,
				        ["bishop"] = 0.05f,
				        ["rook"] = 0.01f,
			        }
		        }
	        });
	        Rooms.AddRoom("MarbleForest", new Room
	        {
		        colour = { r = 0.5f, g = 0.7f, b = 0.5f, a = 0.3f },
		        value = Constant.GROUND.CHECKER,
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["Maxwell1"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["Maxwell2"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["Maxwell3"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["Maxwell4"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["Maxwell6"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["Maxwell7"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["ChessSpot1"] = () => WorldGenMain.random.Next(0, 3),
				        ["ChessSpot2"] = () => WorldGenMain.random.Next(0, 3),
				        ["ChessSpot3"] = () => WorldGenMain.random.Next(0, 3),
			        },
			        distributepercent = 0.75f,
			        distributeprefabs =
			        {
				        ["marbletree"] = 5,
				        ["flower_evil"] = 1,
				        ["marblepillar"] = 0.1f,
				        ["knight"] = 0.1f,
				        ["bishop"] = 0.15f,
				        ["rook"] = 0.01f,
			        }
		        }
	        });
	        Rooms.AddRoom("ChessMarsh", new Room
	        {
		        colour = { r = 0.5f, g = 0.7f, b = 0.5f, a = 0.3f },
		        value = Constant.GROUND.MARSH,
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["Maxwell1"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["Maxwell2"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["Maxwell3"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["ChessSpot1"] = () => WorldGenMain.random.Next(0, 3),
				        ["ChessSpot2"] = () => WorldGenMain.random.Next(0, 3),
				        ["ChessSpot3"] = () => WorldGenMain.random.Next(0, 3),
			        },
			        distributepercent = 0.2f,
			        distributeprefabs =
			        {
				        ["marsh_tree"] = 6,
				        ["marsh_bush"] = 4,
				        ["pond_mos"] = 0.3f,
				        ["tentacle"] = 1,
			        }
		        }
	        });
	        Rooms.AddRoom("ChessForest", new Room
	        {
		        colour = { r = 0.2f, g = 0.0f, b = 0.2f, a = 0.3f },
		        value = Constant.GROUND.FOREST,
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["Maxwell2"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["Maxwell3"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["Maxwell5"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["ChessSpot1"] = () => WorldGenMain.random.Next(0, 3),
				        ["ChessSpot2"] = () => WorldGenMain.random.Next(0, 3),
				        ["ChessSpot3"] = () => WorldGenMain.random.Next(0, 3),
			        },
			        distributepercent = 0.3f,
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
				        ["evergreen_sparse"] = 1.5f,
				        ["flower"] = 0.05f,
				        ["pond"] = 0.001f,
				        ["blue_mushroom"] = 0.02f,
				        ["green_mushroom"] = 0.02f,
				        ["red_mushroom"] = 0.02f,
			        },
		        }
	        });
	        Rooms.AddRoom("ChessBarrens", new Room
	        {
		        colour = { r = 0.66f, g = 0.66f, b = 0.66f, a = 0.50f },
		        value = Constant.GROUND.ROCKY,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["Maxwell1"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["Maxwell3"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
				        ["Maxwell5"] = () => WorldGenMain.random.Next(0, 3) < 1 ? 1 : 0,
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
        }
    }
}