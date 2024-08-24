namespace DYT.Map.rooms
{
    public class TerrainForestRooms
    {
        static TerrainForestRooms()
        {
	        Rooms.AddRoom("BGCrappyForest", new Room
	        {
		        colour = { r = 0.1f, g = 0.8f, b = 0.1f, a = 0.50f },
		        value = Constant.GROUND.FOREST,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
			        distributepercent = 0.6f,
			        distributeprefabs =
			        {
				        ["gravestone"] = 0.01f,
				        ["pighouse"] = 0.015f,
				        ["spiderden"] = 0.04f,
				        ["grass"] = 0.0025f,
				        ["sapling"] = 0.15f,
				        ["rock1"] = 0.008f,
				        ["rock2"] = 0.008f,
				        ["evergreen_sparse"] = 1.5f,
				        ["flower"] = 0.05f,
				        ["pond"] = 0.001f,
				        ["green_mushroom"] = 0.025f,
				        ["red_mushroom"] = 0.025f,
			        },
		        }
	        });
	        Rooms.AddRoom("BGForest", new Room
	        {
		        colour = { r = 0.1f, g = 0.8f, b = 0.1f, a = 0.50f },
		        value = Constant.GROUND.FOREST,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
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
				        ["green_mushroom"] = 0.025f,
				        ["red_mushroom"] = 0.025f,
				        //--trees = {weight = 1.5f, prefabs = {"evergreen", "evergreen_sparse"}}
			        },
		        }
	        });
	        Rooms.AddRoom("BGDeepForest", new Room
	        {
		        colour = { r = 0.1f, g = 0.8f, b = 0.1f, a = 0.50f },
		        value = Constant.GROUND.FOREST,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["MushroomRingSmall"] = () =>
				        {
					        if (WorldGenMain.random.Next(0, 1000) > 985)
						        return 1;

					        return 0;

				        }
			        },
			        distributepercent = 0.8f,
			        distributeprefabs =
			        {
				        ["spiderden"] = 0.05f,
				        ["rock1"] = 0.004f,
				        ["rock2"] = 0.004f,
				        ["evergreen"] = 4.5f,
				        ["fireflies"] = 0.1f,
				        ["blue_mushroom"] = 0.025f,
				        ["green_mushroom"] = 0.005f,
				        ["red_mushroom"] = 0.005f,
			        },
			        prefabdata =
			        {
				        ["spiderden"] = () =>
				        {
					        if (WorldGenMain.random.NextDouble() < 0.1f)
						        return "{growable = {stage = 2}}";
					        else
						        return "{growable = {stage = 1}}";
				        },
			        },
		        }
	        });
	        Rooms.AddRoom("BurntForest", new Room
	        {
		        colour = { r = 0.090f, g = 0.10f, b = 0.010f, a = 0.50f },
		        value = Constant.GROUND.FOREST,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
			        distributepercent = 0.4f,
			        distributeprefabs =
			        {
				        ["evergreen"] = 3 + WorldGenMain.random.Next(4),
			        },
			        prefabdata =
			        {
				        ["evergreen"] = () => "{burnt=true}",
			        }
		        }
	        });
	        Rooms.AddRoom("CrappyDeepForest", new Room
	        {
		        colour = { r = 0, g = 0.9f, b = 0, a = 0.50f },
		        value = Constant.GROUND.FOREST,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
			        distributepercent = 0.8f,
			        distributeprefabs =
			        {
				        ["fireflies"] = 0.1f,
				        ["evergreen_sparse"] = 6,
				        ["spiderden"] = 0.01f,
				        ["grass"] = 0.05f,
				        ["sapling"] = 0.5f,
				        ["berrybush"] = 0.02f,
				        ["blue_mushroom"] = 0.02f,
			        },
		        }

	        });
	        Rooms.AddRoom("DeepForest", new Room
	        {
		        colour = { r = 0, g = 0.9f, b = 0, a = 0.50f },
		        value = Constant.GROUND.FOREST,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["LivingTree"] = () => WorldGenMain.random.NextDouble() > Tuning.LIVINGTREE_CHANCE ? 1 : 0
			        },

			        //-- countprefabs =
			        //-- {
			        //-- 	livingtree = ()=>(WorldGenMain.random.Next() > TUNING.LIVINGTREE_CHANCE and 1) or 0 									
			        //-- },
			        distributepercent = 0.8f,
			        distributeprefabs =
			        {
				        ["fireflies"] = 0.1f,
				        //--	evergreen = 6,
				        ["grass"] = 0.05f,
				        ["sapling"] = 0.5f,
				        ["berrybush"] = 0.02f,
				        ["blue_mushroom"] = 0.02f,
				        ["trees"] = new Room.Contents.DistributePrefab()
					        { weight = 6, prefabs = { "evergreen", "evergreen_sparse" } }

			        },
		        }

	        });
			//-- Trees, very few rocks, very few rabbit holes
			Rooms.AddRoom("Forest", new Room
			{
				colour = { r = 0.5f, g = 0.6f, b = 0.080f, a = 0.10f },
				value = Constant.GROUND.FOREST,
				tags = { "ExitPiece", "Chester_Eyebone" },
				contents =
				{
					distributepercent = 0.3f,
					distributeprefabs =
					{
						["fireflies"] = 0.2f,
						//--evergreen = 6,
						["rock1"] = 0.05f,
						["grass"] = 0.05f,
						["sapling"] = 0.8f,
						["berrybush"] = 0.03f,
						["red_mushroom"] = 0.03f,
						["green_mushroom"] = 0.02f,
						["trees"] = new Room.Contents.DistributePrefab()
							{ weight = 6, prefabs = { "evergreen", "evergreen_sparse" } }
					},
				}
			});
			//-- Trees, very few rocks, very few molehills
			Rooms.AddRoom("ForestMole", new Room
			{
				colour = { r = 0.5f, g = 0.6f, b = 0.080f, a = 0.10f },
				value = Constant.GROUND.FOREST,
				tags = { "ExitPiece", "Chester_Eyebone" },
				contents =
				{
					distributepercent = 0.3f,
					distributeprefabs =
					{
						["fireflies"] = 0.2f,
						//--evergreen = 6,
						["rock1"] = 0.05f,
						["grass"] = 0.05f,
						["sapling"] = 0.8f,
						["molehill"] = 0.3f,
						["berrybush"] = 0.03f,
						["red_mushroom"] = 0.03f,
						["green_mushroom"] = 0.02f,
						["trees"] = new Room.Contents.DistributePrefab()
							{ weight = 6, prefabs = { "evergreen", "evergreen_sparse" } }
					},
				}
			});
			Rooms.AddRoom("CrappyForest", new Room
			{
				colour = { r = 0.5f, g = 0.6f, b = 0.080f, a = 0.10f },
				value = Constant.GROUND.FOREST,
				tags = { "ExitPiece", "Chester_Eyebone" },
				contents =
				{
					distributepercent = 0.3f,
					distributeprefabs =
					{
						["fireflies"] = 0.2f,
						["evergreen_sparse"] = 6,
						["rock1"] = 0.05f,
						["grass"] = 0.05f,
						["sapling"] = 0.8f,
						["molehill"] = 0.05f,
						["berrybush"] = 0.03f,
						["red_mushroom"] = 0.03f,
						["green_mushroom"] = 0.02f,

					},
				}
			});
			Rooms.AddRoom("SpiderForest", new Room
			{
				colour = { r = 0.80f, g = 0.34f, b = 0.80f, a = 0.50f },
				value = Constant.GROUND.FOREST,
				tags = { "ExitPiece", "Chester_Eyebone" },
				contents =
				{
					distributepercent = 0.2f,
					distributeprefabs =
					{
						["evergreen_sparse"] = 6,
						["rock1"] = 0.05f,
						["sapling"] = 0.05f,
						["spiderden"] = 1,
					},
					prefabdata =
					{
						["spiderden"] = () =>
						{
							if (WorldGenMain.random.NextDouble() < 0.2f)
								return "{ growable={stage=2}}";
							else
								return "{ growable={stage=1}}";
						},
					},
				}
			});
			Rooms.AddRoom("BurntClearing", new Room
			{
				colour = { r = 0.8f, g = 0.5f, b = 0.7f, a = 0.50f },
				value = Constant.GROUND.FOREST,
				tags = { "ExitPiece", "Chester_Eyebone" },
				contents =
				{
					distributepercent = 0.1f,
					distributeprefabs =
					{
						["evergreen"] = 0.15f,
						["grass"] = 0.1f,
						["sapling"] = 0.2f,
					},
					prefabdata =
					{
						["evergreen"] = () => "{burnt=true}",
					}
				}
			});
			//-- Trees on the outside, empty in the middle
			Rooms.AddRoom("Clearing", new Room
			{
				colour = { r = 0.8f, g = 0.5f, b = 0.6f, a = 0.50f },
				value = Constant.GROUND.FOREST,
				tags = { "ExitPiece", "Chester_Eyebone" },
				contents =
				{
					countstaticlayouts =
					{
						["MushroomRingLarge"] = () =>
						{
							if (WorldGenMain.random.Next(0, 1000) > 985)
								return 1;

							return 0;
						}
					},
					distributepercent = 0.1f,
					distributeprefabs =
					{
						["pighouse"] = 0.015f,
						["fireflies"] = 1,
						["evergreen"] = 1.5f,
						["grass"] = 0.1f,
						["sapling"] = 0.8f,
						["berrybush"] = 0.1f,
						["beehive"] = 0.05f,
						["red_mushroom"] = 0.01f,
						["green_mushroom"] = 0.02f,
					},
				}
			});
        }
    }
}