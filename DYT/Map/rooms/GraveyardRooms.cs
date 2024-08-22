namespace DYT.Map.rooms
{
    public class GraveyardRooms
    {
        static GraveyardRooms()
        {
            Rooms.AddRoom("Graveyard", new Room
            {
                colour = { r = 0.010f, g = 0.010f, b = 0.10f, a = 0.50f },
                value = Constant.GROUND.FOREST,
                tags = { "Town" },
                contents =
                {
                    countprefabs =
                    {
                        ["evergreen"] = () => 3,
                        ["goldnugget"] = () => WorldGenMain.random.Next(5),
                        ["gravestone"] = () => 4 + WorldGenMain.random.Next(4),
                        ["mound"] = () => 4 + WorldGenMain.random.Next(4)
                    }
                }
            });
        }
    }
}