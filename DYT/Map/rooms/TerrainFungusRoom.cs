namespace DYT.Map.rooms
{
    public class TerrainFungusRoom
    {
        static TerrainFungusRoom()
        {
            Rooms.AddRoom("BGNoisyFungus", new Room
            {
                colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
                value = Constant.GROUND.FUNGUS_NOISE,
                //--tags = {"ForceConnected"},
                contents =
                {
                    distributepercent = 0.1f,
                    distributeprefabs =
                    {

                        ["flower_cave"] = 0.5f,
                        ["flower_cave_double"] = 0.4f,
                        ["flower_cave_triple"] = 0.33f,

                        ["blue_mushroom"] = 0.33f,
                        ["green_mushroom"] = 0.33f,
                        ["red_mushroom"] = 0.33f,

                        ["mushtree_tall"] = 1,
                        ["mushtree_medium"] = 1,
                        ["mushtree_small"] = 1,

                        ["cave_fern"] = 0.1f,
                        ["fireflies"] = 0.1f,
                        ["slurtlehole"] = 0.1f,
                        ["carrot"] = 0.1f,
                        ["tentacle"] = 0.1f,
                    }
                }
            });
            Rooms.AddRoom("BGFungusRoom", new Room
            {
                colour = { r = 0.36f, g = 0.32f, b = 0.38f, a = 0.50f },
                value = Constant.GROUND.FUNGUS,
                //--tags = {"ForceConnected"},
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
                        ["fireflies"] = 0.1f,
                        ["tentacle"] = 0.1f,
                        ["slurtlehole"] = 0.33f,
                        ["cave_fern"] = 0.1f,

                        ["flower_cave"] = 0.5f,
                        ["flower_cave_double"] = 0.4f,
                        ["flower_cave_triple"] = 0.33f,

                        //-- blue_mushroom = 0.33f,
                        //-- green_mushroom = 0.33f,
                        //-- red_mushroom = 0.33f,

                        //--                mushtree_tall = 0.66f,
                        //-- 			mushtree_medium = 0.66f,
                        //-- mushtree_small = 0.66f,
                    },
                }
            });
        }
    }
}