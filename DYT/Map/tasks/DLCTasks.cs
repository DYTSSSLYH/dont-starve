using System.Collections.Generic;

namespace DYT.Map.tasks
{
    public class DLCTasks
    {
        static DLCTasks()
        {
            Tasks.AddTask("Badlands", new Task
            {
                locks = { "ADVANCED_COMBAT", "MONSTERS_DEFEATED", "TIER4" },
                keys_given = { "HOUNDS", "TIER5", "ROCKS" },
                room_choices=new Dictionary<string, int>{
                    ["Lightning"] = 1,
                    ["Badlands"] = 3,
                    ["HoundyBadlands"] = 2,
                    ["BarePlain"] = 1,
                    ["BuzzardyBadlands"] = 2,
                },
                room_bg = Constant.GROUND.DIRT,
                background_room = "BGBadlands",
                colour = { r = 1, g = 0.6f, b = 1, a = 1 },
            });


            Tasks.AddTask("Oasis", new Task
            {
                locks = { "ADVANCED_COMBAT", "TIER4", "MONSTERS_DEFEATED" },
                keys_given = { "ROCKS", "TIER5" },
                room_choices=new Dictionary<string, int>{
                    ["Badlands"] = 3,
                    ["PondyGrass"] = 1,
                    ["BuzzardyBadlands"] = 2,
                },
                room_bg = Constant.GROUND.DIRT,
                background_room = "BGBadlands",
                colour = { r = 0.05f, g = 0.5f, b = 0.05f, a = 1 },
            });
        }
    }
}