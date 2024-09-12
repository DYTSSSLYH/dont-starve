using System.Collections.Generic;

namespace DYT.Map.tasks
{
    public class VolcanoTasks
    {
        static VolcanoTasks()
        {
            Tasks.AddTask("Volcano", new Task
            {
                locks = { "NONE" },
                keys_given = { "ISLAND1" },
                crosslink_factor = 0,
                make_loop = true,
                gen_method = "volcano",
                room_choices = new List<Dictionary<string, int>>
                {
                    new()
                    {
                        ["VolcanoLava"] = 6 + WorldGenMain.random.Next(0, 1)
                    },
                    new()
                    {
                        ["VolcanoNoise"] = 10 + WorldGenMain.random.Next(0, 1)
                    },
                    new()
                    {
                        ["VolcanoNoise"] = 13 + WorldGenMain.random.Next(0, 1)
                    },
                    new()
                    {
                        ["VolcanoStart"] = 1,
                        ["VolcanoAltar"] = 1,
                        ["VolcanoObsidianBench"] = 1,
                        ["VolcanoCage"] = 1,
                        ["VolcanoNoise"] = 13 + WorldGenMain.random.Next(0, 1)
                    },
                },
                room_bg = Constant.GROUND.VOLCANO,
                //--background_room={"Volcano"},
                colour = { r = 1, g = 1, b = 0, a = 1 }
            });
        }
    }
}