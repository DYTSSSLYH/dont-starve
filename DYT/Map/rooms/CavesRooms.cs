using System.Collections.Generic;

namespace DYT.Map.rooms
{
    public class CavesRooms
    {
        static CavesRooms()
        {
	        Rooms.AddRoom("FungusRoom", new Room
	        {
		        colour = { r = 0.36f, g = 0.32f, b = 0.38f, a = 0.50f },
		        value = Constant.GROUND.FUNGUS,
		        custom_tiles = new RoomFunctions.Runca
		        {
			        GeneratorFunction = RoomFunctions.RUNCA.GeneratorFunction,
			        data =
			        {
				        iterations = 8, seed_mode = Constant.CA_SEED_MODE.SEED_RANDOM, num_random_points = 2,
				        translate = new List<RoomFunctions.Translate>
				        {
					        new() { tile = Constant.GROUND.FUNGUSRED, items = { "mushtree_medium" }, item_count = 4 },
					        new() { tile = Constant.GROUND.FUNGUSGREEN, items = { "mushtree_small" }, item_count = 4 },
					        new() { tile = Constant.GROUND.FUNGUS, items = { "mushtree_tall" }, item_count = 4 },
// //new RoomFunctions.Translate{tile=GROUND.FUNGUSRED, items={"red_mushroom"}, item_count=7},
					        new() { tile = Constant.GROUND.FUNGUSGREEN, items = { "green_mushroom" }, item_count = 7 },
					        new() { tile = Constant.GROUND.FUNGUS, items = { "blue_mushroom" }, item_count = 7 },
				        },
			        },
		        },

		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["MushroomRingMedium"] = () =>
				        {
					        if (WorldGenMain.random.Next(0, 200) > 185)
						        return 1;

					        return 0;
				        }
			        },
			        distributepercent = 0.15f,
			        distributeprefabs =
			        {
				        ["mushtree_tall"] = 0.5f,
				        ["mushtree_medium"] = 0.5f,
				        ["mushtree_small"] = 0.5f,
				        ["spiderhole"] = 0.025f,
				        ["fireflies"] = 0.01f,
				        ["flower_cave"] = 0.05f,
				        ["rabbithouse"] = 0.01f,
				        ["blue_mushroom"] = 0.01f,
				        ["cave_fern"] = 0.2f,
			        },
		        }
	        });
	        Rooms.AddRoom("CaveRoom", new Room
	        {
		        colour = { r = 0.25f, g = 0.28f, b = 0.25f, a = 0.50f },
		        value = Constant.GROUND.CAVE,
		        custom_tiles =
		        {
			        GeneratorFunction = RoomFunctions.RUNCA.GeneratorFunction,
			        data =
			        {
				        iterations = 6, seed_mode = Constant.CA_SEED_MODE.SEED_WALLS, num_random_points = 1,
				        translate =
				        {
					        new RoomFunctions.Translate
						        { tile = Constant.GROUND.DIRT, items = { "red_mushroom" }, item_count = 3 },
					        new RoomFunctions.Translate
						        { tile = Constant.GROUND.UNDERROCK, items = { "spiderhole" }, item_count = 5 },
					        new RoomFunctions.Translate
						        { tile = Constant.GROUND.WALL_ROCKY, items = { "green_mushroom" }, item_count = 0 },
					        new RoomFunctions.Translate
					        {
						        tile = Constant.GROUND.CAVE, items = { "slurtlehole", "red_mushroom" }, item_count = 6
					        },
					        new RoomFunctions.Translate
						        { tile = Constant.GROUND.CAVE, items = { "fireflies" }, item_count = 6 },
				        },
			        },
		        },
		        contents =
		        {
			        distributepercent = 0.175f,
			        distributeprefabs =
			        {
				        ["stalagmite"] = 0.025f,
				        ["stalagmite_med"] = 0.025f,
				        ["stalagmite_low"] = 0.025f,

				        ["spiderhole"] = 0.025f,
				        ["fireflies"] = 0.01f,
				        ["blue_mushroom"] = 0.005f,
				        ["green_mushroom"] = 0.003f,
				        ["red_mushroom"] = 0.004f,
				        ["cave_fern"] = 0.08f,
				        ["pillar_cave"] = 0.003f,

				        ["fissure"] = 0.002f,
			        },
		        }
	        });
	        Rooms.AddRoom("SinkholeRoom", new Room
	        {
		        colour = { r = 0.15f, g = 0.18f, b = 0.15f, a = 0.50f },
		        value = Constant.GROUND.SINKHOLE,
		        custom_tiles =
		        {
			        GeneratorFunction = RoomFunctions.RUNCA.GeneratorFunction,
			        data =
			        {
				        iterations = 3, seed_mode = Constant.CA_SEED_MODE.SEED_CENTROID, num_random_points = 1,
				        translate =
				        {
					        new RoomFunctions.Translate
						        { tile = Constant.GROUND.GRASS, items = { "grass" }, item_count = 3 },
					        new RoomFunctions.Translate
						        { tile = Constant.GROUND.GRASS, items = { "sapling", "berrybush" }, item_count = 5 },
					        new RoomFunctions.Translate
						        { tile = Constant.GROUND.FOREST, items = { "evergreen_short" }, item_count = 17 },
					        new RoomFunctions.Translate
						        { tile = Constant.GROUND.FOREST, items = { "evergreen_normal" }, item_count = 16 },
					        new RoomFunctions.Translate
						        { tile = Constant.GROUND.FOREST, items = { "evergreen_tall" }, item_count = 16 },
				        },
				        centroid = new RoomFunctions.Translate
					        { tile = Constant.GROUND.FOREST, items = { "cavelight" }, item_count = 1 },
			        },
		        },
		        contents =
		        {
			        distributepercent = 0.175f,
			        distributeprefabs =
			        {
				        ["cavelight"] = 25,

				        ["spiderden"] = 0.1f,
				        ["rabbithouse"] = 1,

				        ["fireflies"] = 1,
				        ["sapling"] = 15,
				        ["evergreen"] = 0.25f,
				        ["berrybush"] = 0.5f,
				        ["blue_mushroom"] = 0.5f,
				        ["green_mushroom"] = 0.3f,
				        ["red_mushroom"] = 0.4f,
				        ["grass"] = 0.25f,
				        ["cave_fern"] = 20,
			        },
			        prefabdata =
			        {
				        ["spiderden"] = () =>
				        {

					        if (WorldGenMain.random.NextDouble() < 0.1f)
						        return "{growable = {stage = 3}}";
					        else
						        return "{growable = {stage = 2}}";
				        },
			        },
		        }
	        });

			// Rock Lobster Plains
			Rooms.AddRoom("RockLobsterPlains", new Room
			{
				colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
				value = Constant.GROUND.CAVE_NOISE,
				contents =
				{
					distributepercent = 0.15f,
					distributeprefabs =
					{
						["rocky"] = 0.25f,
						["goldnugget"] = 0.05f,
						["rocks"] = 0.1f,
						["flint"] = 0.05f,
						["rock_flintless"] = 0.2f,
						["rock_flintless_med"] = 0.2f,
						["rock_flintless_low"] = 0.2f,
						["pillar_cave"] = 0.02f,
						["fissure"] = 0.02f,
					}
				}
			});
			// Misty Sinkhole
			Rooms.AddRoom("MistyCavern", new Room
			{
				colour = { r = 0.15f, g = 0.18f, b = 0.15f, a = 0.50f },
				value = Constant.GROUND.MUD,
				custom_tiles =
				{
					GeneratorFunction = RoomFunctions.RUNCA.GeneratorFunction,
					data =
					{
						iterations = 5, seed_mode = Constant.CA_SEED_MODE.SEED_CENTROID, num_random_points = 1,
						translate =
						{
							new RoomFunctions.Translate
								{ tile = Constant.GROUND.GRASS, items = { "grass" }, item_count = 3 },
							new RoomFunctions.Translate
								{ tile = Constant.GROUND.GRASS, items = { "berrybush" }, item_count = 5 },
							new RoomFunctions.Translate
								{ tile = Constant.GROUND.FOREST, items = { "evergreen_short" }, item_count = 17 },
							new RoomFunctions.Translate
								{ tile = Constant.GROUND.FOREST, items = { "evergreen_normal" }, item_count = 16 },
							new RoomFunctions.Translate
								{ tile = Constant.GROUND.FOREST, items = { "evergreen_tall" }, item_count = 16 },
						},
						centroid = new RoomFunctions.Translate
							{ tile = Constant.GROUND.FOREST, items = { "cavelight" }, item_count = 1 },
					},
				},
				contents =
				{
					distributepercent = 0.175f,
					distributeprefabs =
					{
						["grass"] = 0.0025f,
						["sapling"] = 0.15f,
						["evergreen"] = 0.0025f,
						["blue_mushroom"] = 0.005f,
						["green_mushroom"] = 0.003f,
						["berrybush"] = 0.2f,
						["red_mushroom"] = 0.004f,
						["cave_fern"] = 0.2f,

					},
				}
			});
			Rooms.AddRoom("TentacleCave", new Room
			{
				colour = { r = 0.45f, g = 0.75f, b = 0.45f, a = 0.50f },
				value = Constant.GROUND.MARSH,
				contents =
				{
					distributepercent = 0.2f,
					distributeprefabs =
					{
						["tentacle_garden"] = 0.25f,
						["tentacle"] = 0.25f,

						["flower_cave"] = 0.8f,
						["flower_cave_double"] = 0.5f,
						["flower_cave_triple"] = 0.2f,
					},
				}
			});

			Rooms.AddRoom("SunkenMarsh", new Room
			{
				colour = { r = 0.45f, g = 0.75f, b = 0.45f, a = 0.50f },
				value = Constant.GROUND.MARSH,
				contents =
				{
					distributepercent = 0.3f,
					distributeprefabs =
					{
						["cavelight"] = 0.2f,
						["tentacle"] = 1,
						["reeds"] = 1,
						["marsh_bush"] = 0.8f,
						["spiderden"] = 0.2f,
					},
					prefabdata =
					{
						["spiderden"] = () =>
						{
							if (WorldGenMain.random.NextDouble() < 0.1f)
								return "{growable = {stage = 3}}";
							else
								return "{growable = {stage = 2}}";
						},
					},

				}
			});

			Rooms.AddRoom("RabitFungusRoom", new Room
			{
				colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
				value = Constant.GROUND.FUNGUS,
				// //tags = {"ForceConnected"},
				contents =
				{
					distributepercent = 0.2f,
					distributeprefabs =
					{
						["flower_cave"] = 0.5f,
						["flower_cave_triple"] = 0.15f,
						["flower_cave_double"] = 0.1f,
						["carrot_planted"] = 1,

						["green_mushroom"] = 0.5f,
						["blue_mushroom"] = 0.5f,
						["red_mushroom"] = 0.5f,

						// //                mushtree_tall = 0.5f,
						// // mushtree_medium = 0.5f,
						// // mushtree_small = 0.5f,

						["rabbithouse"] = 0.51f,
						["cave_fern"] = 0.5f,
					}
				}
			});

			Rooms.AddRoom("GreenMush", new Room
			{
				colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
				value = Constant.GROUND.FUNGUSGREEN,
				// //tags = {"ForceConnected"},
				contents =
				{
					distributepercent = 0.175f,
					distributeprefabs =
					{
						["slurtlehole"] = 0.05f,
						["worm"] = 0.05f,

						["cave_fern"] = 0.5f,
						["flower_cave"] = 0.5f,
						["flower_cave_triple"] = 0.15f,
						["flower_cave_double"] = 0.1f,

						["green_mushroom"] = 0.9f,
						["mushtree_small"] = 0.5f,

					}
				}
			});

			Rooms.AddRoom("RedMush", new Room
			{
				colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
				value = Constant.GROUND.FUNGUSRED,
				//tags = {"ForceConnected"},
				contents =
				{
					distributepercent = 0.175f,
					distributeprefabs =
					{
						["slurtlehole"] = 0.05f,
						["worm"] = 0.05f,

						["cave_fern"] = 0.5f,
						["flower_cave"] = 0.5f,
						["flower_cave_triple"] = 0.15f,
						["flower_cave_double"] = 0.1f,

						["red_mushroom"] = 0.9f,
						["mushtree_medium"] = 0.5f,

					}
				}
			});

			Rooms.AddRoom("BlueMush", new Room
			{
				colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
				value = Constant.GROUND.FUNGUS,
				//tags = {"ForceConnected"},
				contents =
				{
					distributepercent = 0.175f,
					distributeprefabs =
					{
						["slurtlehole"] = 0.05f,
						["worm"] = 0.05f,

						["cave_fern"] = 0.5f,
						["flower_cave"] = 0.5f,
						["flower_cave_triple"] = 0.15f,
						["flower_cave_double"] = 0.1f,

						["blue_mushroom"] = 0.9f,
						["mushtree_tall"] = 0.5f,

					}
				}
			});

			Rooms.AddRoom("NoisyFungus", new Room
			{
				colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
				value = Constant.GROUND.FUNGUS_NOISE,
				//tags = {"ForceConnected"},
				contents =
				{
					distributepercent = 0.2f,
					distributeprefabs =
					{

						["flower_cave"] = 1,
						["flower_cave_double"] = 0.6f,
						["flower_cave_triple"] = 0.4f,

						["mushtree_tall"] = 0.5f,
						["mushtree_medium"] = 0.5f,
						["mushtree_small"] = 0.5f,

						["cave_fern"] = 0.02f,
						["goldnugget"] = 0.05f,

						["slurtlehole"] = 0.1f,
						["worm"] = 0.1f,

					}
				}
			});
			Rooms.AddRoom("NoisyCave", new Room
			{
				colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
				value = Constant.GROUND.CAVE_NOISE,
				contents =
				{
					distributepercent = 0.15f,
					distributeprefabs =
					{
						["stalagmite"] = 0.15f,
						["stalagmite_med"] = 0.15f,
						["stalagmite_low"] = 0.15f,

						//stalagmite_tall=0.5f,
						//stalagmite_gold = 0.05f,
						["spiderhole"] = 0.125f,
						//slurtlehole = 0.01f,
						["pillar_cave"] = 0.08f,
						["fissure"] = 0.05f,
					}
				}
			});
			Rooms.AddRoom("BatCaveRoom", new Room
			{
				colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
				value = Constant.GROUND.CAVE,
				contents =
				{
					distributepercent = 0.15f,
					distributeprefabs =
					{
						["bat"] = 0.25f,
						["guano"] = 0.27f,
						["goldnugget"] = 0.05f,
						["flint"] = 0.05f,
						["stalagmite_tall"] = 0.4f,
						["stalagmite_tall_med"] = 0.4f,
						["stalagmite_tall_low"] = 0.4f,
						["pillar_cave"] = 0.08f,
						["fissure"] = 0.05f,
					}
				}
			});
			// Bat Cave antichamber (warn of impending bats)
			Rooms.AddRoom("BatCaveRoomAntichamber", new Room
			{
				colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
				value = Constant.GROUND.CAVE,
				contents =
				{
					distributepercent = 0.3f,
					distributeprefabs =
					{
						["guano"] = 1.0f,
						["stalagmite_tall"] = 0.4f,
						["stalagmite_tall_med"] = 0.4f,
						["stalagmite_tall_low"] = 0.4f,

						["pillar_cave"] = 0.03f,
						["fissure"] = 0.03f,
					}
				}
			});
			Rooms.AddRoom("PitRoom", new Room
			{
				colour = { r = 0.25f, g = 0.28f, b = 0.25f, a = 0.50f },
				value = Constant.GROUND.IMPASSABLE,
				internal_type = Constant.NODE_INTERNAL_CONNECTION_TYPE.EdgeCentroid,
				contents = { },
			});
			Rooms.AddRoom("PitEdgeCave", new Room
			{
				colour = { r = 0.25f, g = 0.28f, b = 0.25f, a = 0.50f },
				value = Constant.GROUND.IMPASSABLE,
				internal_type = Constant.NODE_INTERNAL_CONNECTION_TYPE.EdgeEdgeRight,
				custom_tiles =
				{
					GeneratorFunction = RoomFunctions.RUNCA.GeneratorFunction,
					data =
					{
						iterations = 2, seed_mode = Constant.CA_SEED_MODE.SEED_WALLS, num_random_points = 1,
						translate =
						{
							new RoomFunctions.Translate
								{ tile = Constant.GROUND.IMPASSABLE, items = { "stalagmite" }, item_count = 0 },
							new RoomFunctions.Translate
								{ tile = Constant.GROUND.IMPASSABLE, items = { "stalagmite" }, item_count = 0 },
							new RoomFunctions.Translate
								{ tile = Constant.GROUND.CAVE, items = { "stalagmite" }, item_count = 0 },
							new RoomFunctions.Translate
								{ tile = Constant.GROUND.CAVE, items = { "stalagmite" }, item_count = 0 },
							new RoomFunctions.Translate
								{ tile = Constant.GROUND.CAVE, items = { "stalagmite" }, item_count = 0 },
						},
					},
				},
			});
			Rooms.AddRoom("PitCave", new Room
			{
				////
				colour = { r = 0.25f, g = 0.28f, b = 0.25f, a = 0.50f },
				value = Constant.GROUND.CAVE_NOISE,
				tags = { "ForceConnected" },
				internal_type = Constant.NODE_INTERNAL_CONNECTION_TYPE.EdgeCentroid,
				custom_tiles =
				{
					GeneratorFunction = RoomFunctions.RUNCA.GeneratorFunction,
					data =
					{
						iterations = 3, seed_mode = Constant.CA_SEED_MODE.SEED_CENTROID, num_random_points = 1,
						translate =
						{
							new RoomFunctions.Translate
								{ tile = Constant.GROUND.IMPASSABLE, items = { "stalagmite" }, item_count = 0 },
							new RoomFunctions.Translate
								{ tile = Constant.GROUND.IMPASSABLE, items = { "stalagmite" }, item_count = 0 },
							new RoomFunctions.Translate
								{ tile = Constant.GROUND.IMPASSABLE, items = { "stalagmite" }, item_count = 0 },
							new RoomFunctions.Translate
								{ tile = Constant.GROUND.WALL_CAVE, items = { "stalagmite" }, item_count = 0 },
							new RoomFunctions.Translate
								{ tile = Constant.GROUND.WALL_CAVE, items = { "stalagmite" }, item_count = 0 },
						},
					},
				},
				contents =
				{
					distributepercent = 0.15f,
					distributeprefabs =
					{
						["stalagmite_tall_med"] = 1,
						["stalagmite_tall_low"] = 1,
						["pillar_cave"] = 0.2f,
						["pillar_stalactite"] = 0.2f,
					}
				}

			});
			Rooms.AddRoom("MistyPitRoom", new Room
			{
				colour = { r = 0.25f, g = 0.28f, b = 0.25f, a = 0.50f },
				value = Constant.GROUND.IMPASSABLE,
			});
			Rooms.AddRoom("WaterFilledAbyss", new Room
			{
				colour = { r = 0.25f, g = 0.28f, b = 0.25f, a = 0.50f },
				value = Constant.GROUND.IMPASSABLE,
			});


			Rooms.AddRoom("Stairs", new Room
			{
				// This room is used to tag for the next level of caves - it will be removed later
				colour = { r = 0, g = 0, b = 0, a = 0.9f },
				value = Constant.GROUND.CAVE_NOISE,
				contents =
				{
					countprefabs =
					{
						["cave_stairs"] = () => 1,
					},
					distributepercent = 0.3f,
					distributeprefabs =
					{
						["bat"] = 0.15f,
						["spiderhole"] = 0.15f,

						["stalagmite"] = 0.04f,
						["stalagmite_med"] = 0.04f,
						["stalagmite_low"] = 0.04f,


						["stalagmite_tall"] = 0.04f,
						["stalagmite_tall_med"] = 0.04f,
						["stalagmite_tall_low"] = 0.04f,

						["pillar_cave"] = 0.01f,
						["pillar_stalactite"] = 0.01f,
						["fissure"] = 0.01f,
					}
				}
			});
			Rooms.AddRoom("EmptyCave", new Room
			{
				colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
				value = Constant.GROUND.CAVE,
				contents =
				{
				}
			});

			Rooms.AddRoom("CaveBase", new Room
			{
				colour = { r = 0, g = 0, b = 0, a = 0.9f },
				value = Constant.GROUND.CAVE,
				contents =
				{
					countstaticlayouts =
					{
						["CaveBase"] = () => 1,
					},
					distributepercent = 0.15f,
					distributeprefabs =
					{
						["fireflies"] = 0.3f,

						["bat"] = 0.15f,
						["guano"] = 0.05f,

						["stalagmite_tall_low"] = 1,
						["stalagmite_tall_med"] = 0.6f,
						["stalagmite_tall"] = 0.2f,

						["pillar_cave"] = 0.05f,
						["pillar_stalactite"] = 0.05f,
					},

				}
			});

			Rooms.AddRoom("SinkBase", new Room
			{
				colour = { r = 0, g = 0, b = 0, a = 0.9f },
				value = Constant.GROUND.SINKHOLE,
				contents =
				{
					countstaticlayouts =
					{
						["SinkBase"] = () => 1,
					},
					distributepercent = 0.15f,
					distributeprefabs =
					{

						["grass"] = 1,
						["sapling"] = 0.8f,
						["evergreen"] = 0.3f,
						["cave_fern"] = 0.75f,
						["berrybush"] = 0.2f,
						["fireflies"] = 0.1f,
						["cavelight"] = 0.01f,

					},
				}
			});

			Rooms.AddRoom("MushBase", new Room
			{
				colour = { r = 0, g = 0, b = 0, a = 0.9f },
				value = Constant.GROUND.FUNGUS,
				contents =
				{
					countstaticlayouts =
					{
						["MushBase"] = () => 1,
					},
					distributepercent = 0.15f,
					distributeprefabs =
					{
						["mushtree_tall"] = 1,
						["mushtree_medium"] = 1,
						["mushtree_small"] = 1,

						["cave_fern"] = 0.5f,
						["fireflies"] = 0.1f,
						["tentacle"] = 0.8f,

						["flower_cave"] = 0.1f,
						["flower_cave_double"] = 0.05f,
						["flower_cave_triple"] = 0.01f,
					},
				}
			});

			Rooms.AddRoom("RabbitTown", new Room
			{
				colour = { r = 0, g = 0, b = 0, a = 0.9f },
				value = Constant.GROUND.FUNGUS,
				contents =
				{
					countstaticlayouts =
					{
						["RabbitTown"] = () => 1,
					},
					distributepercent = 0.2f,
					distributeprefabs =
					{
						["mushtree_tall"] = 0.5f,
						["mushtree_medium"] = 0.5f,
						["mushtree_small"] = 0.5f,
						["flower_cave"] = 0.75f,
						["carrot_planted"] = 1,
						["cave_fern"] = 0.75f,
						["rabbithouse"] = 0.51f,
					}
				}
			});
			Rooms.AddRoom("RabbitCity", new Room
			{
				colour = { r = 0.9f, g = 0.9f, b = 0.2f, a = 0.50f },
				value = Constant.GROUND.UNDERROCK,
				tags = { "Town" },
				contents =
				{
					countstaticlayouts =
					{
						["RabbitCity"] = () => 1 + WorldGenMain.random.Next(2),
						["TorchRabbitking"] = () => 1 + WorldGenMain.random.Next(2),
					},
					countprefabs =
					{
						["mermhead"] = () => WorldGenMain.random.Next(3),
					},
				}
			});
        }
    }
}