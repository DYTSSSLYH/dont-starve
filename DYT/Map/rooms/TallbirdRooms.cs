namespace DYT.Map.rooms
{
    public class TallbirdRooms
    {
        static TallbirdRooms()
        {
            Rooms.AddRoom("TallbirdNests", new Room
            {
                colour = { r = 0.55f, g = 0.75f, b = 0.75f, a = 0.50f },
                value = Constant.GROUND.ROCKY,
                tags = { "ExitPiece", "Chester_Eyebone" },
                contents =
                {
                    distributepercent = 0.1f,
                    distributeprefabs =
                    {
                        ["rock1"] = 2,
                        ["rock2"] = 2,
                        ["rock_ice"] = 0.5f,
                        ["tallbirdnest"] = 1.8f,
                        ["spiderden"] = 0.01f,
                        ["blue_mushroom"] = 0.02f,
                    },
                }
            });
        }
    }
}