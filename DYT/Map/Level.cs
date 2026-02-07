// using System;
// using System.Collections.Generic;
// using System.Linq;
// using DYT.Map.levels;
// using UnityEngine;
// using UnityEngine.Assertions;
// using Random = UnityEngine.Random;
//
// namespace DYT.Map
// {
//     public class LEVELTYPE
//     {
//         public static int
//             SURVIVAL = 1,
//             CAVE = 2,
//             ADVENTURE = 3,
//             TEST = 4,
//             UNKNOWN = 5,
//             CUSTOM = 6,
//             VOLCANO = 7,
//             SHIPWRECKED = 8,
//             PORKLAND = 9;
//     }
//     public class SetPiece
//     {
//         public string name;
//         public string restrict_to;
//         public int count;
//         public List<string> tasks;
//     }
//
//     public class Level
//     {
//         public class StartTask
//         {
//             public float weight;
//             public string start_setpiece;
//             public string start_node;
//         }
//         public class SelectedTask
//         {
//             public int min;
//             public int max;
//             public List<object> task_choices;
//         }
//         public class WaterContent
//         {
//             public Func<int, bool> checkFn;
//         }
//         public class Treasure
//         {
//             public int count;
//             public List<string> treasuretasks;
//             public List<string> maptasks;
//             public List<string> tasks;
//         }
//         
//         public bool override_level_string;
//         public object required_treasures;
//         public string id;
//         public string name;
//         public string desc;
//         public List<string> tasks;
//         public Dictionary<object, object> overrides;
//         public Dictionary<string, Substitute> substitutes;
//         public Dictionary<string, List<List<string>>> override_triggers;
//         public Dictionary<string, SetPiece> set_pieces;
//         public int numoptionaltasks;
//         public bool nomaxwell;
//         public List<object> optionaltasks;
//         public bool hideminimap;
//         public string teleportaction;
//         public string teleportmaxwell;
//         public int min_playlist_position;
//         public int max_playlist_position = 999;
//         public List<string> ordered_story_setpieces;
//         public List<string> required_prefabs;
//         public Dictionary<string, int> required_prefab_count;
//         public int[] background_node_range;
//         public int numrandom_set_pieces;
//         public List<string> random_set_pieces;
//         public List<SelectedTask> selectedtasks;
//         public Dictionary<string, StartTask> start_tasks;
//         public Dictionary<string, Treasure> treasures;
//         public int numoptional_treasures;
//         public object optional_treasures;
//         public int numrandom_treasures;
//         public List<string> random_treasures;
//         public Dictionary<string, WaterContent> water_content;
//         public Dictionary<string, SetPiece> water_setpieces;
//         public Dictionary<string, SetPiece> water_prefill_setpieces;
//
//         public Level(){}
//         public Level(Level data)
//         {
//             id = string.IsNullOrWhiteSpace(data.id) ? "UNKNOWN_ID" : data.id;
//             name = data.name ?? "";
//             desc = data.desc ?? "";
//             tasks = data.tasks ?? new List<string>();
//             overrides = data.overrides ?? new Dictionary<object, object>();
//             substitutes = data.substitutes ?? new Dictionary<string, Substitute>();
//             override_triggers = data.override_triggers;
//             set_pieces = data.set_pieces ?? new Dictionary<string, SetPiece>();
//             numoptionaltasks = data.numoptionaltasks;
//             nomaxwell = data.nomaxwell;
//             optionaltasks = data.optionaltasks ?? new List<object>();
//             hideminimap = data.hideminimap;
//             teleportaction = data.teleportaction;
//             teleportmaxwell = data.teleportmaxwell;
//             min_playlist_position = data.min_playlist_position;
//             max_playlist_position = data.max_playlist_position;
//             ordered_story_setpieces = data.ordered_story_setpieces;
//             required_prefabs = data.required_prefabs;
//             required_prefab_count = data.required_prefab_count ?? new Dictionary<string, int>();
//             background_node_range = data.background_node_range;
//
//             numrandom_set_pieces = data.numrandom_set_pieces;
//             random_set_pieces = data.random_set_pieces;
//
//             selectedtasks = data.selectedtasks ?? new List<SelectedTask>();
//             start_tasks = data.start_tasks ?? new Dictionary<string, StartTask>();
//             
//             treasures = data.treasures ?? new Dictionary<string, Treasure>();
//             numoptional_treasures = data.numoptional_treasures;
//             optional_treasures = data.optional_treasures;
//             numrandom_treasures = data.numrandom_treasures;
//             random_treasures = data.random_treasures ?? new List<string>();
//             
//             water_content = data.water_content ?? new Dictionary<string, WaterContent>();
//             water_setpieces = data.water_setpieces ?? new Dictionary<string, SetPiece>();
//             water_prefill_setpieces = data.water_prefill_setpieces ?? new Dictionary<string, SetPiece>();
//         }
//
//
//         public void ApplyModsToTasks(List<Task>tasklist)
//         {
//             foreach (Task task in tasklist)
//             {
//                 //--print(i, "modding task "..task.id)
//                 List<ActionParams> modfns =
//                     ModManager.GetPostInitFns("TaskPreInit", task.id);
//                 foreach (ActionParams modfn in modfns)
//                 {
//                     DebugPrint.print($"Applying mod to task '{task.id}'");
//                     modfn(task);
//                 }
//             }
//         }
//
//         public List<Task> GetOverridesForTasks(List<Task>tasklist)
//         {
//             //-- Update the task with whatever overrrides are going
//             new ResourceSubstitution();
//             
//             //-- WE MAKE ONE SELECTION FOR ALL TASKS or ONE PER TASK
//             foreach ((string name, Substitute overrideSubstitute) in substitutes)
//             {
//                 string substitute = ResourceSubstitution.GetSubstitute(name);
//                 
//                 if (name == substitute) continue;
//                 
//                 DebugPrint.print($"Substituting [{substitute}] for '{name}'");
//                 for (var task_idx = 0; task_idx < tasklist.Count; task_idx++)
//                 {
//                     float chance = Random.value;
//                     if (chance < overrideSubstitute.perstory)
//                     {
//                         tasklist[task_idx].substitutes ??= new Dictionary<string, Task.Substitute>();
//                         //--print(task_idx, "Overriding", name, "with", substitute,
//                         //"for:", self.name, chance, override.perstory )
//                         tasklist[task_idx].substitutes[name] = new Task.Substitute()
//                         {
//                             name = substitute, percent = overrideSubstitute.pertask
//                         };
//                     }
//                     //else print("NOT overriding ", name, "with", substitute,
//                     //"for:", self.name, chance, override.perstory)
//                 }
//             }
//             
//             return tasklist;
//         }
//         
//         public List<Task> GetTasksForLevel(List<Task> sampletasks)
//         {
//             //--print("Getting tasks for level:", self.name)
//             List<Task> tasklist = new();
//             for (int i = 0; i < tasks.Count; i++) EnqueueATask(tasklist, tasks[i], sampletasks);
//
//             if (numoptionaltasks > 0)
//             {
//                 List<object> shuffletasknames = Util.shuffleArray(optionaltasks);
//                 int numtoadd = numoptionaltasks;
//                 for (int i = 0; i < optionaltasks.Count && numtoadd > 0; i++)
//                 {
//                     if (optionaltasks[i].GetType() == typeof(List<>))
//                     {
//                         foreach (string taskname in (List<string>)(optionaltasks[i]))
//                         {
//                             EnqueueATask(tasklist, taskname, sampletasks);
//                             numtoadd--;
//                         }
//                     }
//                     else
//                     {
//                         EnqueueATask(tasklist, optionaltasks[i] as string, sampletasks);
//                         numtoadd--;
//                     }
//                 }
//             }
//             
//             for (int i = 0; i < selectedtasks.Count; i++)
//             {
//                 SelectedTask selectedTask = selectedtasks[i];
//                 List<object> shuffletasknames = Util.shuffleArray(selectedTask.task_choices);
//                 int numToAdd = Random.Range(selectedTask.min, selectedTask.max);
//                 for (int j = 0; j < selectedTask.task_choices.Count && numToAdd > 0; j++)
//                 {
//                     if (selectedTask.task_choices[i].GetType() == typeof(List<>))
//                     {
//                         foreach (string taskname in (List<string>)selectedTask.task_choices[i])
//                         {
//                             EnqueueATask(tasklist, taskname, sampletasks);
//                             numToAdd--;
//                         }
//                     }
//                     else
//                     {
//                         EnqueueATask(tasklist, selectedTask.task_choices[i] as string, sampletasks);
//                         numToAdd--;
//                     }
//                 }
//             }
//
//             for (int i = 0; i < numrandom_set_pieces; i++)
//             {
//                 //--Add random setpiece each loop.
//                 
//                 //--Get random set piece to put in task
//                 string set_piece = random_set_pieces[Random.Range(0, random_set_pieces.Count)];
//                 
//                 //--Get random task
//                 Task task = tasklist[Random.Range(0, tasklist.Count)];
//
//                 if (task.random_set_pieces == null) task.random_set_pieces = new List<SetPiece>();
//                 //--print(set_piece)
//                 random_set_pieces.Add(set_piece);
//             }
//             
//             foreach ((string name, SetPiece choicedata) in set_pieces)
//             {
//                 bool found = false;
//                 Dictionary<string, int> idx = new Dictionary<string, int>();
//                 for (int i = 0; i < tasklist.Count; i++)
//                 {
//                     Task task = tasklist[i];
//                     idx[task.id] = i;
//                 }
//                 
//                 //-- Pick one of the choces and add it to that task
//                 List<string> choices = choicedata.tasks;
//                 int count = choicedata.count == 0 ? 1 : choicedata.count;
//                 
//                 
//                 Assert.IsNotNull(choices, $"Trying to add set piece '{name}' but no choices given.");
//                 
//                 //-- Only one layout per task, so we stop when we run out of tasks or
//                 while (count > 0 && choices.Count > 0)
//                 {
//                     //-- we'll convert back to 1-index in a moment
//                     int idx_choice_offset = Random.Range(0, choices.Count) - 1;
//                     //-- To account for the fact that some of the choices
//                     //might not exist in the level (i.e. option tasks) loop through them.
//                     for (var i = 0; i < choices.Count; i++)
//                     {
//                         //-- convert back to 1-index
//                         int idx_choice = ((idx_choice_offset + i)% choices.Count) +1;
//                         int choice = idx[choices[idx_choice]];
//                         //--print(
//                         //  "choice",
//                         //  idx_choice, choice, #choices, choices[idx_choice], tasklist[choice]
//                         // )
//                         if (tasklist[choice] != null)
//                         {
//                             tasklist[choice].set_pieces ??= new List<SetPiece>();
//                             tasklist[choice].set_pieces.Add(
//                                 new SetPiece(){name=name, restrict_to=choicedata.restrict_to}
//                             );
//                             idx.Remove(choices[idx_choice]);
//                             choices.RemoveAt(choice);
//                             break;
//                         }
//                     }
//                 }
//             }
//             
//             //--treasures
//             
//             //--verify treasures exist
//             
//             ApplyModsToTasks(tasklist);
//             
//             GetOverridesForTasks(tasklist);
//
//             return tasklist;
//         }
//
//         public void EnqueueATask(List<Task> tasklist, string taskname, List<Task> sampletasks)
//         {
//             Task task = GetTaskByName(taskname, sampletasks);
//             if (task != null)
//             {
//                 //--print("\tChoosing task:",task.id)
//                 tasklist.Add(Util.deepcopy(task));
//             } else Assert.IsNotNull(task, $"Could not find a task called {taskname}");
//         }
//
//         public Task GetTaskByName(string taskname, List<Task> sampletasks)
//         {
//             return sampletasks.Find(t => taskname.ToUpper() == t.id);
//         }
//     }
// }