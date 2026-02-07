// using System.Collections.Generic;
// using UnityEngine;
//
// namespace DYT.Map
// {
//     public class Task
//     {
//         public class MazeTiles
//         {
//             public List<string> rooms;
//             public List<string> bosses;
//         }
//         public class Substitute
//         {
//             public string name;
//             public float percent;
//         }
//         
//         public string id;
//         public List<string> locks; //-- what locks this task
//         public List<string> keys_given; //-- the key that this task provides
//         public List<string> entrance_room;
//         public float entrance_room_chance;
//         public object room_choices;
//         public int room_bg;
//         public object background_room;
//         public Color colour;
//         public MazeTiles maze_tiles;
//         public List<SetPiece> set_pieces;
//         public List<SetPiece> random_set_pieces;
//         public int? crosslink_factor;
//         public bool make_loop;
//         public string gen_method;
//         public Dictionary<string, Substitute> substitutes;
//         public List<TreasureHunt.Treasure> treasures;
//         public List<TreasureHunt.Treasure> random_treasures;
//
//         public Task(){}
//         public Task(string id, Task data)
//         {
//             this.id = id;
//             
//             locks = data.locks;
//             keys_given = data.keys_given;
//
//             entrance_room = data.entrance_room;
//             entrance_room_chance = data.entrance_room_chance;
//             room_choices = data.room_choices;
//             room_bg = data.room_bg;
//             background_room = data.background_room;
//             colour = data.colour;
//             maze_tiles = data.maze_tiles;
//             crosslink_factor = data.crosslink_factor;
//             make_loop = data.make_loop;
//             gen_method = string.IsNullOrWhiteSpace(data.gen_method) ? "default" : data.gen_method;
//
//             set_pieces = data.set_pieces ?? new List<SetPiece>();
//         }
//     }
// }