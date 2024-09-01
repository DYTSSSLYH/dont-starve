namespace DYT.Map.rooms
{
    public class TerrainCaveRoom
    {
        static TerrainCaveRoom()
        {
            Rooms.AddRoom("BGNoisyCave", new Room
            {
                colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
                value = Constant.GROUND.CAVE_NOISE,
                contents =
                {
                    distributepercent = 0.1f,
                    distributeprefabs =
                    {
                        ["stalagmite"] = 0.5f,
                        ["stalagmite_med"] = 0.5f,
                        ["stalagmite_low"] = 0.5f,

                    }
                }
            });
            Rooms.AddRoom("BGCaveRoom", new Room
            {
                colour = { r = 0.25f, g = 0.28f, b = 0.25f, a = 0.50f },
                value = Constant.GROUND.CAVE_NOISE,
                //--tags = {"ForceConnected"},
                contents =
                {
                    distributepercent = 0.175f,
                    distributeprefabs =
                    {
                        //--spiderhole=0.001f,
                        ["flint"] = 0.5f,
                        ["rocks"] = 0.5f,
                        //--fireflies = 0.1f,

                        //-- stalagmite=0.03f,
                        ["stalagmite_tall"] = 0.2f,
                        ["stalagmite_tall_med"] = 0.8f,
                        ["stalagmite_tall_low"] = 1,

                        //--stalagmite_gold=0.02f,
                        ["pillar_cave"] = 0.15f,
                        ["pillar_stalactite"] = 0.15f,
                        //--blue_mushroom = 0.5f,
                        //--slurtlehole = 0.001f,
                    },
                }
            });
        }
    }
}