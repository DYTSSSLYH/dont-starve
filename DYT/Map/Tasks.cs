// ------------------------------------------------------------------------------------------
// ---------             SAMPLE TASKS                   --------------------------------------
// ------------------------------------------------------------------------------------------

using System.Collections.Generic;
using DYT.Map.tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DYT.Map
{
    public class Tasks
    {
        public static int SIZE_VARIATION = 3;

        public static List<Task> sampletasks = new();
        // -- A set of tasks to be performed
        public static List<Task> oneofeverything = new()
        {
            new Task("One of everything", new Task
            {
                locks = {"NONE"},
                keys_given = {"PICKAXE"},
                room_choices =
                {
                    ["Graveyard"] = 1, 
                    ["BeefalowPlain"] = 1, 		
                    ["SpiderVillage"] = 1, 
                    ["PigKingdom"] = 1, 
                    ["PigVillage"] = 1, 
                    ["MandrakeHome"] = 1,
                    ["BeeClearing"] = 1,
                    ["DenseRocks"] = 1,
                    ["DenseForest"] = 1,
                    ["Rockpile"] = 1,
                    ["Woodpile"] = 1,
                    ["Trapfield"] = 1,
                    ["Minefield"] = 1,
                    ["SpiderCon"] = 1,
                    ["Forest"] = 1, 
                    ["Rocky"] = 1, 
                    ["BarePlain"] = 1, 
                    ["Plain"] = 1, 
                    ["Marsh"] = 1, 
                    ["DeepForest"] = 1, 
                    ["Clearing"] = 1,
                    ["BurntForest"] = 1,
                },
                room_bg = Constant.GROUND.GRASS,
                background_room = "BGGrass",
                colour = new Color{r=0,g=1,b=0,a=1}
            })
        };
        
        
        static Tasks()
        {
            new LockAndKey();
            new Terrain();

            
            JObject parameters = null;
            
            if (!string.IsNullOrWhiteSpace(Main.GEN_PARAMETERS))
                parameters = JsonConvert.DeserializeObject<JObject>(Main.GEN_PARAMETERS);

            if (parameters != null && parameters["level_type"].Value<string>() == "porkland")
                new PorklandTasks();
            else if (parameters["ROGEnabled"].Value<bool>() ||
                     parameters["level_type"].Value<string>() == "shipwrecked" ||
                     parameters["level_type"].Value<string>() == "volcano")
            {
                new SwTasks();
            }
            else new PorklandTasks();
        }

        
        public static void AddTask(string name, Task data)
        {
            sampletasks.Add(new Task(name, data));
        }

        public static Task GetTaskByName(string name, List<Task> tasks)
        {
            return tasks.Find(task => task.id == name);
        }
    }
}