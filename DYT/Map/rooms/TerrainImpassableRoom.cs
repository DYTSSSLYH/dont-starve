namespace DYT.Map.rooms
{
    public class TerrainImpassableRoom
    {
        static TerrainImpassableRoom()
        {
            Rooms.AddRoom("BGImpassable", new Room
            {
                colour = { r = 0.6f, g = 0.35f, b = 0.8f, a = 0.50f },
                value = Constant.GROUND.IMPASSABLE,
                contents = { }
            });
            Rooms.AddRoom("BGImpassableRock", new Room
            {
                colour = { r = 0.8f, g = 0.8f, b = 0.8f, a = 0.90f },
                value = Constant.GROUND.ABYSS_NOISE,
                contents = { }
            });
            Rooms.AddRoom("Nothing", new Room
            {
                colour = { r = 0.45f, g = 0.45f, b = 0.35f, a = 0.50f },
                value = Constant.GROUND.IMPASSABLE,
                contents =
                {
                }
            });
            Rooms.AddRoom("ForceDisconnectedRoom", new Room
            {
                colour = { r = 0.45f, g = 0.75f, b = 0.45f, a = 0.50f },
                type = "blank",
                tags = { "ForceDisconnected" },
                value = Constant.GROUND.IMPASSABLE,
                contents = { },
            });
        }
    }
}