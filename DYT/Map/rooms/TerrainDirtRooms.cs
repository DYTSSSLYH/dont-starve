namespace DYT.Map.rooms
{
    public class TerrainDirtRooms
    {
        static TerrainDirtRooms()
        {
            Rooms.AddRoom("BGDirt", new Room
            {
                colour = { r = 1.0f, g = 0.8f, b = 0.66f, a = 0.50f },
                value = Constant.GROUND.DIRT,
                tags = { "ExitPiece", "Chester_Eyebone" },
                contents =
                {
                    distributepercent = 0.1f,
                    distributeprefabs =
                    {
                        ["rock1"] = 1,
                        ["rock2"] = 1,
                        ["rock_ice"] = 0.2f,
                    },
                }
            });
        }
    }
}