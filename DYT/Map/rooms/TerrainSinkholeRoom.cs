namespace DYT.Map.rooms
{
    public class TerrainSinkholeRoom
    {
        static TerrainSinkholeRoom()
        {
            Rooms.AddRoom("BGSinkholeRoom", new Room
            {
                colour = { r = 0.15f, g = 0.18f, b = 0.15f, a = 0.50f },
                value = Constant.GROUND.SINKHOLE,
                //--tags = {"ForceConnected"},
                contents =
                {
                    distributepercent = 0.175f,
                    distributeprefabs =
                    {
                        ["grass"] = 0.0025,
                        ["sapling"] = 0.15,
                        ["evergreen"] = 0.0025,
                        ["berrybush"] = 0.005,
                        ["spiderden"] = 0.01,
                        ["fireflies"] = 0.01,
                        ["blue_mushroom"] = .005,
                        ["green_mushroom"] = .003,
                        ["red_mushroom"] = .004,
                        ["mandrake"] = 0.001,
                        ["slurtlehole"] = 0.001,
                    },
                    prefabdata =
                    {
                        ["spiderden"] = () =>
                        {
                            if (WorldGenMain.random.NextDouble() < 0.1f)
                                return "{ growable={stage=3}}";
                            else
                                return "{ growable={stage=2}}";

                        },
                    },
                }
            });
        }
    }
}