// using UnityEngine;
//
// namespace DYT.Map.rooms
// {
//     public class MandrakeRooms
//     {
//         static MandrakeRooms()
//         {
//             Rooms.AddRoom("MandrakeHome", new Room
//             {
//                 colour = new Color{r = 0.3f, g = 0.4f, b = 0.8f, a = 0.3f },
//                 value = Constant.GROUND.GRASS,
//                 contents =
//                 {
//                     countstaticlayouts =
//                     {
//                         ["InsanePighouse"] = () =>
//                         {
//                             if (Random.Range(0,1000) > 995)
//                                 return 1;
//                             else
//                                 return 0;
//                         },
//                     },
//                     countprefabs =
//                     {
//                         ["mandrake"] = () => 1,
//                     },
//                     distributepercent = 0.2f,
//                     distributeprefabs =
//                     {
//                         ["flower"] = 4,
//                         ["fireflies"] = 0.3f,
//                         ["evergreen"] = 6,
//                         ["grass"] = 0.05f,
//                         ["sapling"] = 0.5f,
//                         ["berrybush"] = 0.05f,
//                     },
//                 }
//             });
//         }
//     }
// }