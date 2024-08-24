namespace DYT.Map.rooms
{
    public class StartsRooms
    {
        static StartsRooms()
        {
            Rooms.AddRoom("BurntForestStart", new Room
            {
                colour = { r = 0.010f, g = 0.010f, b = 0.010f, a = 0.50f },
                value = Constant.GROUND.FOREST,
                contents =
                {
                    countprefabs =
                    {
                        ["firepit"] = () => 1,
                    },
                    distributepercent = 0.6f,
                    distributeprefabs =
                    {
                        ["evergreen"] = 3 + WorldGenMain.random.Next(4),
                        ["charcoal"] = 0.2f,
                    },
                    prefabdata =
                    {
                        ["evergreen"] = () => "{burnt=true}",
                    }
                }
            });
            Rooms.AddRoom("SafeSwamp", new Room
            {
                colour = { r = 0.2f, g = 0.0f, b = 0.2f, a = 0.3f },
                value = Constant.GROUND.MARSH,
                contents =
                {
                    countprefabs =
                    {
                        ["mandrake"] = () => WorldGenMain.random.Next(1, 2),
                    },
                    distributepercent = 0.2f,
                    distributeprefabs =
                    {
                        ["marsh_tree"] = 1,
                        ["marsh_bush"] = 1,
                        //--TODO: Traps need to be not "owned" by player
                    }
                }
            });
        }
    }
}