namespace DYT.Map.tasks
{
    public class MaxwellTasks
    {
        static MaxwellTasks()
        {
            Tasks.AddTask("MaxPuzzle1", new Task
            {
                locks = { "PIGKING" },
                keys_given = { "WOOD" },
                room_choices =
                {
                    ["MaxPuzzle1"] = 1,
                    ["SpiderMarsh"] = 2 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
                },
                room_bg = Constant.GROUND.MARSH,
                background_room = "BGMarsh",
                colour = { r = 0.05f, g = 0.05f, b = 0.05f, a = 1 }
            });
            Tasks.AddTask("MaxPuzzle2", new Task
            {
                locks = { "PIGKING" },
                keys_given = { "WOOD" },
                room_choices =
                {
                    ["MaxPuzzle2"] = 1,
                    ["SpiderMarsh"] = 2 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
                },
                room_bg = Constant.GROUND.MARSH,
                background_room = "BGMarsh",
                colour = { r = 0.05f, g = 0.05f, b = 0.05f, a = 1 }
            });
            Tasks.AddTask("MaxPuzzle3", new Task
            {
                locks = { "PIGKING" },
                keys_given = { "WOOD" },
                room_choices =
                {
                    ["MaxPuzzle3"] = 1,
                    ["SpiderMarsh"] = 2 + WorldGenMain.random.Next(Tasks.SIZE_VARIATION),
                },
                room_bg = Constant.GROUND.MARSH,
                background_room = "BGMarsh",
                colour = { r = 0.05f, g = 0.05f, b = 0.05f, a = 1 }
            });

            Tasks.AddTask("MaxHome", new Task
            {
                locks = { "NONE" },
                keys_given = { "NONE" },
                room_choices =
                {
                    ["MaxHome"] = 1,
                },
                room_bg = Constant.GROUND.IMPASSABLE,
                background_room = "BGImpassable",
                colour = { r = 0.05f, g = 0.05f, b = 0.05f, a = 1 }
            });
        }
    }
}