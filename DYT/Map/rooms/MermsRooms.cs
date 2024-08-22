// --------------------------------------------------------------------------------
// -- Merms 
// --------------------------------------------------------------------------------
namespace DYT.Map.rooms
{
    public class MermsRooms
    {
        static MermsRooms()
        {
            Rooms.AddRoom("MermTown", new Room
            {
                colour =
                {
                    r = 0.5f, g = 0.18f, b = 0.35f, a = 0.50f
                },
                value = Constant.GROUND.MARSH,
                contents =
                {
                    countprefabs =
                    {
                        ["pighead"] = () => WorldGenMain.random.Next(6),
                    },
                    distributepercent = 0.1f,
                    distributeprefabs =
                    {
                        // --merm = 0.1,
                        ["mermhouse"] = 1,
                        ["tentacle"] = 1,
                        ["reeds"] = 2,
                        ["pond_mos"] = 0.5f,
                    },
                }
            });
        }
    }
}