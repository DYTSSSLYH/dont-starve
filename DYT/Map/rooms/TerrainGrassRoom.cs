using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DYT.Map.rooms
{
    public class TerrainGrassRoom
    {
        static TerrainGrassRoom()
        {
	        Rooms.AddRoom("BGGrassBurnt", new Room
	        {
		        colour = { r = 0.5f, g = 0.8f, b = 0.5f, a = 0.50f },
		        value = Constant.GROUND.GRASS,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
			        distributepercent = 0.275f,
			        distributeprefabs =
			        {
				        ["rock1"] = 0.01f,
				        ["rock2"] = 0.01f,
				        ["spiderden"] = 0.001f,
				        ["beehive"] = 0.003f,
				        ["flower"] = 0.112f,
				        ["grass"] = 0.2f,
				        ["smallmammal"] = "{weight = 0.02f, prefabs = {\"rabbithole\", \"molehill\"}}",
				        ["flint"] = 0.05f,
				        ["sapling"] = 0.2f,
				        ["evergreen"] = 0.3f,
			        },
			        prefabdata =
			        {
				        ["evergreen"] = () => "{burnt=true}",
			        }
		        }
	        });

			//-- Nothing to see here buddy... keep scrolling...
	        List<string> tree_prefabs = new(){ "evergreen" };
	        if (!string.IsNullOrWhiteSpace(WorldGenMain.GEN_PARAMETERS))
	        {
		        JObject parameters = JsonConvert.DeserializeObject<JObject>(WorldGenMain.GEN_PARAMETERS);
		        if (parameters["ROGEnabled"].Value<bool>() ||
		            parameters["level_type"].Value<string>() == "shipwrecked" ||
		            parameters["level_type"].Value<string>() == "volcano")
		        {
			        tree_prefabs = new List<string> { "evergreen", "deciduoustree" };
		        }
	        }

	        Rooms.AddRoom("BGGrass", new Room
	        {
		        colour = { r = 0.5f, g = 0.8f, b = 0.5f, a = 0.50f },
		        value = Constant.GROUND.GRASS,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
			        distributepercent = 0.275f,
			        distributeprefabs =
			        {
				        ["spiderden"] = 0.001f,
				        ["beehive"] = 0.003f,
				        ["flower"] = 0.112f,
				        ["grass"] = 0.4f, //--raised from0.2f
				        ["smallmammal"] = "{weight = 0.02f, prefabs = {\"rabbithole\", \"molehill\"}}",
				        ["carrot_planted"] = 0.05f,
				        ["flint"] = 0.05f,
				        ["berrybush"] = 0.05f,
				        ["sapling"] = 0.2f,
				        ["tree"] = "{weight = 0.3f, prefabs = tree_prefabs}",
				        ["pond"] = 0.001f,
				        ["blue_mushroom"] = 0.005f,
				        ["green_mushroom"] = 0.003f,
				        ["red_mushroom"] = 0.004f,
			        },
		        }
	        });
	        Rooms.AddRoom("BGGrassIsland", new Room
	        {
		        colour = { r = 0.5f, g = 0.8f, b = 0.5f, a = 0.50f },
		        value = Constant.GROUND.GRASS,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
			        distributepercent = 0.275f,
			        distributeprefabs =
			        {
				        ["spiderden"] = 0.001f,
				        //--	beehive=0.003f,
				        ["flower"] = 0.112f,
				        ["grass"] = 0.4f, //--raised from0.2f
				        //--	smallmammal = {weight = 0.02f, prefabs = {"rabbithole", "molehill"}},
				        ["carrot_planted"] = 0.05f,
				        ["flint"] = 0.05f,
				        ["berrybush"] = 0.05f,
				        ["sapling"] = 0.2f,
				        //--	tree = {weight = 0.3f, prefabs = {"evergreen", "deciduoustree"}},
				        //--	pond=0.001f, cut until we change it
				        ["blue_mushroom"] = 0.005f,
				        ["green_mushroom"] = 0.003f,
				        ["red_mushroom"] = 0.004f,
			        },
		        }
	        });


	        Rooms.AddRoom("FlowerPatch", new Room
	        {
		        colour = { r = 0.5f, g = 1, b = 0.8f, a = 0.50f },
		        value = Constant.GROUND.GRASS,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["fireflies"] = 1,
				        ["flower"] = 2,
				        ["beehive"] = 1,
			        },
		        }
	        });
	        Rooms.AddRoom("GrassyMoleColony", new Room
	        {
		        colour = { r = 0.5f, g = 1, b = 0.8f, a = 0.50f },
		        value = Constant.GROUND.GRASS,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["flower"] = 1,
				        ["molehill"] = 2,
				        ["rocks"] = 0.3f,
				        ["flint"] = 0.3f,
			        },
		        }
	        });
	        Rooms.AddRoom("EvilFlowerPatch", new Room
	        {
		        colour = { r = 0.8f, g = 1, b = 0.4f, a = 0.50f },
		        value = Constant.GROUND.GRASS,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["fireflies"] = 1,
				        ["flower_evil"] = 2,
				        ["wasphive"] = 0.5f,
			        },
		        }
	        });

        }
    }
}