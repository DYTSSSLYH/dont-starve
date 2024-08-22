// --------------------------------------------------------------------------------
// -- Walrus 
// --------------------------------------------------------------------------------
namespace DYT.Map.rooms
{
    public class WalrusRooms
    {
        static WalrusRooms()
        {
            Rooms.AddRoom("WalrusHut_Plains", new Room
            {
                colour = { r = 0.30f, g = 0.20f, b = 0.50f, a = 0.50f },
                value = Constant.GROUND.SAVANNA,
                contents =
                {
                    countprefabs =
                    {
                        ["walrus_camp"] = () => 1
                    },
                    distributepercent = 0.1f,
                    distributeprefabs =
                    {
                        ["grass"] = 0.09f,
                        ["flower"] = 0.003f,
                    },
                }
            });
            Rooms.AddRoom("WalrusHut_Grassy", new Room
            {
                colour = { r = 0.30f, g = 0.20f, b = 0.50f, a = 0.50f },
                value = Constant.GROUND.GRASS,
                contents =
                {
                    countprefabs =
                    {
                        ["walrus_camp"] = () => 1
                    },
                    distributepercent = 0.275f,
                    distributeprefabs =
                    {
                        ["flower"] = 0.112f,
                        ["grass"] = 0.2f,
                        ["carrot_planted"] = 0.05f,
                        ["flint"] = 0.05f,
                        ["sapling"] = 0.2f,
                        ["evergreen"] = 0.3f,
                        ["pond"] = 0.005f,
                    },
                }
            });
            Rooms.AddRoom("WalrusHut_Rocky", new Room
            {
                colour = { r = 0.30f, g = 0.20f, b = 0.50f, a = 0.50f },
                value = Constant.GROUND.ROCKY,
                contents =
                {
                    countprefabs =
                    {
                        ["walrus_camp"] = () => 1
                    },
                    distributepercent = 0.1f,
                    distributeprefabs =
                    {
                        ["flint"] = 0.5f,
                        ["rock1"] = 1,
                        ["rock2"] = 1,
                        ["tallbirdnest"] = 0.3f,
                    },
                }
            });
        }
    }
}