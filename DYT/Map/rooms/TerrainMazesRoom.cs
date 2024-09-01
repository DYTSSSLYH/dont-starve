namespace DYT.Map.rooms
{
    public class TerrainMazesRoom
    {
        static TerrainMazesRoom()
        {
            Rooms.AddRoom("LabyrinthGuarden", new Room
            {
                colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
                value = Constant.GROUND.BRICK,
                tags = { "LabyrinthEntrance" },
                contents =
                {
                    countstaticlayouts =
                    {
                        ["WalledGarden"] = () => 1,
                    },
                },
            });

            Rooms.AddRoom("BGLabyrinth", new Room
            {
                colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
                value = Constant.GROUND.CAVE_NOISE,
                tags = { "Labyrinth" },
                contents =
                {
                    distributepercent = 0.04f,
                    distributeprefabs =
                    {
                        ["nightmarelight"] = 0.45f,
                        ["dropperweb"] = 1,
                    }
                }
            });
            Rooms.AddRoom("BGMaze", new Room
            {
                colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
                value = Constant.GROUND.MUD,
                tags = { "Maze" },
                contents =
                {
                    distributepercent = 0.15f,
                    distributeprefabs =
                    {
                        ["lichen"] = 0.001f,
                        ["cave_fern"] = 0.0015f,
                        //--pond_cave = 0.002f,
                        ["pillar_algae"] = 0.0001f,
                        ["slurper"] = 0.0002f,
                    }
                }
            });
        }
    }
}