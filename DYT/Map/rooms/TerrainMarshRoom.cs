namespace DYT.Map.rooms
{
    public class TerrainMarshRoom
    {
        static TerrainMarshRoom()
        {
	        Rooms.AddRoom("BGMarsh", new Room
	        {
		        colour = { r = 0.6f, g = 0.2f, b = 0.8f, a = 0.50f },
		        value = Constant.GROUND.MARSH,
		        tags = { "ExitPiece", "Chester_Eyebone" },
		        contents =
		        {
			        countstaticlayouts =
			        {
				        ["MushroomRingMedium"] = () =>
				        {
					        if (WorldGenMain.random.Next(0, 1000) >
					            985)
						        return 1;

					        return 0;
				        }
			        },
			        distributepercent = 0.25f,
			        distributeprefabs =
			        {
				        ["spiderden"] = 0.003f,
				        ["sapling"] = 0.0001f,
				        ["pond_mos"] = 0.005f,
				        ["reeds"] = 0.005f,
				        ["tentacle"] = 0.095f,
				        ["marsh_bush"] = 0.05f,
				        ["marsh_tree"] = 0.1f,
				        ["blue_mushroom"] = 0.01f,
				        ["mermhouse"] = 0.004f,
			        },
		        }
	        });
			//-- No trees, no rocks, very rare spiderden
			Rooms.AddRoom("Marsh", new Room
			{
				colour = { r = 0.45f, g = 0.75f, b = 0.45f, a = 0.50f },
				value = Constant.GROUND.MARSH,
				tags = { "ExitPiece", "Chester_Eyebone" },
				contents =
				{
					countstaticlayouts =
					{
						["MushroomRingMedium"] = () =>
						{
							if (WorldGenMain.random.Next(0, 1000) > 985) return 1;

							return 0;
						}
					},
					distributepercent = 0.1f,
					distributeprefabs =
					{
						["evergreen"] = 1.0f,
						["tentacle"] = 3,
						["pond_mos"] = 1,
						["reeds"] = 4, //--function () return 3 + WorldGenMain.random.Next(4) end,
						["mandrake"] = 0.0001f,
						["spiderden"] = 0.01f,
						["blue_mushroom"] = 0.01f,
						["green_mushroom"] = 2.02f,
					},
				}
			});
			Rooms.AddRoom("SpiderMarsh", new Room
			{
				colour = { r = 0.45f, g = 0.75f, b = 0.45f, a = 0.50f },
				value = Constant.GROUND.MARSH,
				tags = { "ExitPiece", "Chester_Eyebone" },
				contents =
				{
					distributepercent = 0.1f,
					distributeprefabs =
					{
						["evergreen"] = 1.0f,
						["tentacle"] = 2,
						["pond_mos"] = 0.1f,
						["blue_mushroom"] = 0.1f,
						["reeds"] = 4, //--function () return 3 + WorldGenMain.random.Next(4) end,
						["mandrake"] = 0.0001f,
						["spiderden"] = 3.15f,
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
			Rooms.AddRoom("SlightlyMermySwamp", new Room
			{
				colour = { r = 0.5f, g = 0.18f, b = 0.35f, a = 0.50f },
				value = Constant.GROUND.MARSH,
				contents =
				{

					distributepercent = 0.1f,
					distributeprefabs =
					{
						//--merm = 0.1f,
						["mermhouse"] = 0.1f,
						["pighead"] = 0.01f,
						["tentacle"] = 1,
						["marsh_tree"] = 2,
						["marsh_bush"] = 1.5f,
					},
				}
			});
        }
    }
}