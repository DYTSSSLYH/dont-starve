namespace DYT.Map.rooms
{
    public class BeefaloRooms
    {
        static BeefaloRooms()
        {
            Rooms.AddRoom("BeefalowPlain", new Room
            {
                colour = { r = 0.45f, g = 0.5f, b = 0.85f, a = 0.50f },
                value = Constant.GROUND.SAVANNA,
                contents =
                {
                    distributepercent = 0.05f,
                    distributeprefabs =
                    {
                        ["grass"] = 0.01f,
                        ["beefalo"] = 0.02f,
                    }
                }
            });
        }
    }
}