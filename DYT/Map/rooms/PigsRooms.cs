// --------------------------------------------------------------------------------
// -- Pigs 
// --------------------------------------------------------------------------------
namespace DYT.Map.rooms
{
    public class PigsRooms
    {
        static PigsRooms()
        {
	        Rooms.AddRoom("PigTown", new Room
	        {
		        colour = { r = 0.3f, g = 0.8f, b = 0.5f, a = 0.50f },
		        value = Constant.GROUND.GRASS,
		        tags = { "Town" },
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["PigTown"] = () => 1,
			        },
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["grass"] = 0.05f,
				        ["berrybush"] = 0.05f,
			        },
		        }
	        });
	        Rooms.AddRoom("PigVillage", new Room
	        {
		        colour = { r = 0.3f, g = 0.8f, b = 0.5f, a = 0.50f },
		        value = Constant.GROUND.GRASS,
		        tags = { "Town" },
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["Farmplot"] = () => WorldGenMain.random.Next(2, 5),
				        ["VillageSquare"] = () =>
				        {
					        if (WorldGenMain.random.NextDouble() > 0.97) return 1;
					        return 0;
				        },
			        },
			        countprefabs =
			        {
				        // --bonfire = 1,
				        ["pighouse"] = () => 3 + WorldGenMain.random.Next(4),
				        ["mermhead"] = () => WorldGenMain.random.Next(3),
			        },
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["grass"] = 0.05f,
				        ["berrybush"] = 0.05f,
			        },
		        }
	        });
	        Rooms.AddRoom("PigKingdom", new Room
	        {
		        colour = { r = 0.8f, g = 0.8f, b = 0.1f, a = 0.50f },
		        value = Constant.GROUND.GRASS,
		        tags = { "Town" },
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["DefaultPigking"] = () => 1,
				        ["CropCircle"] = () => WorldGenMain.random.Next(0, 1),
				        ["TreeFarm"] = () =>
				        {
					        if (WorldGenMain.random.NextDouble() > 0.97)
						        return WorldGenMain.random.Next(1, 2);
					        return 0;
				        }
			        },
			        countprefabs =
			        {
				        ["pighouse"] = () => 5 + WorldGenMain.random.Next(4),
			        }
		        }
	        });
	        Rooms.AddRoom("PigCity", new Room
	        {
		        colour = { r = 0.9f, g = 0.9f, b = 0.2f, a = 0.50f },
		        value = Constant.GROUND.ROCKY,
		        tags = { "Town" },
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["PigTown"] = () => 1 + WorldGenMain.random.Next(2),
				        ["TorchPigking"] = () => 1,
			        },
			        countprefabs =
			        {
				        ["mermhead"] = () => WorldGenMain.random.Next(3),
			        },
		        }
	        });
	        Rooms.AddRoom("PigCamp", new Room
	        {
		        colour = { r = 1f, g = 0.8f, b = 0.8f, a = 0.50f },
		        value = Constant.GROUND.GRASS,
		        tags = { "Town" },
		        contents =
		        {
			        countprefabs =
			        {
				        ["pighouse"] = () => 4 + WorldGenMain.random.Next(4),
				        ["mermhead"] = () => WorldGenMain.random.Next(3),
			        },
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["poop"] = 0.01f,
				        ["wall_hay"] = 0.01f,
				        ["grass"] = 0.15f,
				        ["berrybush"] = 0.05f,
			        },
		        }
	        });
	        Rooms.AddRoom("PigShrine", new Room
	        {
		        colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
		        value = Constant.GROUND.FOREST,
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["MaxPigShrine"] = () => 1,
			        },
			        countprefabs =
			        {
				        ["flower"] = () => 8 + WorldGenMain.random.Next(4),
			        },
			        distributepercent = 0.4f,
			        distributeprefabs =
			        {
				        ["evergreen_normal"] = 1,
				        ["evergreen_tall"] = 1,
			        },
		        }
	        });
	        Rooms.AddRoom("Pondopolis", new Room
	        {
		        colour = { r = 0.30f, g = 0.20f, b = 0.50f, a = 0.50f },
		        value = Constant.GROUND.GRASS,
		        contents =
		        {
			        countprefabs =
			        {
				        ["pond"] = () => 5 + WorldGenMain.random.Next(3)
			        },
			        distributepercent = 0.1f,
			        distributeprefabs =
			        {
				        ["grass"] = 8,
				        ["flower"] = 6,
				        ["sapling"] = 1,
			        },
		        }
	        });

        }
    }
}