namespace DYT.Map.rooms
{
    public class TerrainNoiseRoom
    {
        static TerrainNoiseRoom()
        {
            Rooms.AddRoom("BGNoise", new Room
            {
                colour = { r = 0.66f, g = 0.66f, b = 0.66f, a = 0.50f },
                value = Constant.GROUND.GROUND_NOISE,
                tags = { "ExitPiece", "Chester_Eyebone" },
                contents =
                {
                    distributepercent = 0.15f,
                    //-- A bit of everything, and let terrain filters handle the rest.
                    distributeprefabs =
                    {
                        ["flint"] = 0.4,
                        ["rocks"] = 0.4,
                        ["rock1"] = 0.1,
                        ["rock2"] = 0.1,
                        ["grass"] = 0.09,
                        ["smallmammal"] = "{weight = 0.025, prefabs = {\"rabbithole\", \"molehill\"}}",
                        ["flower"] = 0.003,
                        ["spiderden"] = 0.001,
                        ["beehive"] = 0.003,
                        ["berrybush"] = 0.05,
                        ["sapling"] = 0.2,
                        ["pond"] = .001,
                        ["blue_mushroom"] = .001,
                        ["green_mushroom"] = .001,
                        ["red_mushroom"] = .001,
                        ["evergreen"] = 1.5,
                    },
                }
            });
        }
    }
}