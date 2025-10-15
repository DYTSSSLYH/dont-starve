// --------------------------------------------------------------------------------
// -- Pigs 
// --------------------------------------------------------------------------------

using UnityEngine;

namespace DYT.Map.rooms
{
    public class PigsRooms
    {
        static PigsRooms()
        {
	        Rooms.AddRoom("PigTown", new Room
	        {
		        colour = new Color{r = 0.3f, g = 0.8f, b = 0.5f, a = 0.50f },
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
		        colour = new Color{r = 0.3f, g = 0.8f, b = 0.5f, a = 0.50f },
		        value = Constant.GROUND.GRASS,
		        tags = { "Town" },
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["Farmplot"] = () => Random.Range(2, 5),
				        ["VillageSquare"] = () =>
				        {
					        if (Random.value > 0.97) return 1;
					        return 0;
				        },
			        },
			        countprefabs =
			        {
				        // --bonfire = 1,
				        ["pighouse"] = () => 3 + Random.Range(0,4),
				        ["mermhead"] = () => Random.Range(0,3),
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
		        colour = new Color{r = 0.8f, g = 0.8f, b = 0.1f, a = 0.50f },
		        value = Constant.GROUND.GRASS,
		        tags = { "Town" },
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["DefaultPigking"] = () => 1,
				        ["CropCircle"] = () => Random.Range(0, 1),
				        ["TreeFarm"] = () =>
				        {
					        if (Random.value > 0.97)
						        return Random.Range(1, 2);
					        return 0;
				        }
			        },
			        countprefabs =
			        {
				        ["pighouse"] = () => 5 + Random.Range(0,4),
			        }
		        }
	        });
	        Rooms.AddRoom("PigCity", new Room
	        {
		        colour = new Color{r = 0.9f, g = 0.9f, b = 0.2f, a = 0.50f },
		        value = Constant.GROUND.ROCKY,
		        tags = { "Town" },
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["PigTown"] = () => 1 + Random.Range(0,2),
				        ["TorchPigking"] = () => 1,
			        },
			        countprefabs =
			        {
				        ["mermhead"] = () => Random.Range(0,3),
			        },
		        }
	        });
	        Rooms.AddRoom("PigCamp", new Room
	        {
		        colour = new Color{r = 1f, g = 0.8f, b = 0.8f, a = 0.50f },
		        value = Constant.GROUND.GRASS,
		        tags = { "Town" },
		        contents =
		        {
			        countprefabs =
			        {
				        ["pighouse"] = () => 4 + Random.Range(0,4),
				        ["mermhead"] = () => Random.Range(0,3),
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
		        colour = new Color{r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
		        value = Constant.GROUND.FOREST,
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["MaxPigShrine"] = () => 1,
			        },
			        countprefabs =
			        {
				        ["flower"] = () => 8 + Random.Range(0,4),
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
		        colour = new Color{r = 0.30f, g = 0.20f, b = 0.50f, a = 0.50f },
		        value = Constant.GROUND.GRASS,
		        contents =
		        {
			        countprefabs =
			        {
				        ["pond"] = () => 5 + Random.Range(0,3)
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