namespace DYT.Map.rooms
{
    public class BeeRooms
    {
        static BeeRooms()
        {
            Rooms.AddRoom("BeeClearing", new Room
            {
                colour = { r = 0.8f, g = 1, b = 0.8f, a = 0.50f },
                value = Constant.GROUND.GRASS,
                contents =
                {
                    countprefabs =
                    {
                        ["fireflies"] = () => 1,
                        ["flower"] = () => 6,
                        ["beehive"] = () => 1,
                    }
                }
            });
        }
    }
}