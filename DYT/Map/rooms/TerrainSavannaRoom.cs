namespace DYT.Map.rooms
{
    public class TerrainSavannaRoom
    {
        static TerrainSavannaRoom()
        {
            Rooms.AddRoom("BGSavanna", new Room
            {
                colour = { r = 0.8f, g = 0.8f, b = 0.2f, a = 0.50f },
                value = Constant.GROUND.SAVANNA,
                tags = { "ExitPiece", "Chester_Eyebone" },
                contents =
                {
                    distributepercent = 0.1f,
                    distributeprefabs =
                    {
                        ["spiderden"] = 0.001f,
                        ["grass"] = 0.09f,
                        ["rabbithole"] = 0.025f,
                        ["flower"] = 0.003f,
                    },
                }
            });
            //-- Very few Trees, very few rocks, rabbit holes, some beefalow, some grass
            Rooms.AddRoom("Plain", new Room
            {
                colour = { r = 0.8f, g = 0.4f, b = 0.4f, a = 0.50f },
                value = Constant.GROUND.SAVANNA,
                tags = { "ExitPiece", "Chester_Eyebone" },
                contents =
                {
                    distributepercent = 0.2f,
                    distributeprefabs =
                    {
                        ["rock1"] = 0.05f,
                        ["grass"] = 0.5f,
                        ["rabbithole"] = 0.25f,
                        ["green_mushroom"] = 0.005f,
                    },
                }
            });
            //-- Rabbit holes, Beefalow hurds if bigger
            Rooms.AddRoom("BarePlain", new Room
            {
                colour = { r = 0.5f, g = 0.5f, b = 0.45f, a = 0.50f },
                value = Constant.GROUND.SAVANNA,
                tags = { "ExitPiece", "Chester_Eyebone" },
                contents =
                {
                    distributepercent = 0.1f,
                    distributeprefabs =
                    {
                        ["grass"] = 0.8f,
                        ["rabbithole"] = 0.4f,
                        //--					                    beefalo=0.2f
                    },
                }
            });
        }
    }
}