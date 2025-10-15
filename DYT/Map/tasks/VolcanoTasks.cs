using System.Collections.Generic;
using UnityEngine;

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
                    new Dictionary<string, int>
                    {
                        ["VolcanoLava"] = 6 + Random.Range(0, 1),
                    },
                    new Dictionary<string, int>
                    {
                        ["VolcanoNoise"] = 10 + Random.Range(0, 1),
                    },
                    new Dictionary<string, int>
                    {
                        ["VolcanoNoise"] = 13 + Random.Range(0, 1),
                    },
                    new Dictionary<string, int>
                    {
                        ["VolcanoStart"] = 1,
                        ["VolcanoAltar"] = 1,
                        ["VolcanoObsidianBench"] = 1,
                        ["VolcanoCage"] = 1,
                        ["VolcanoNoise"] = 13 + Random.Range(0, 1),
                    },
                },
                room_bg = Constant.GROUND.VOLCANO,
                //--background_room={"Volcano"},
                colour = { r = 1, g = 1, b = 0, a = 1 }
            });
        }
    }
}