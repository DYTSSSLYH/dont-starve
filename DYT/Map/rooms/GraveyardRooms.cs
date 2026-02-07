// using UnityEngine;
//
// namespace DYT.Map.rooms
// {
//     public class GraveyardRooms
//     {
//         static GraveyardRooms()
//         {
//             Rooms.AddRoom("Graveyard", new Room
//             {
//                 colour = new Color{r = 0.010f, g = 0.010f, b = 0.10f, a = 0.50f },
//                 value = Constant.GROUND.FOREST,
//                 tags = { "Town" },
//                 contents =
//                 {
//                     countprefabs =
//                     {
//                         ["evergreen"] = () => 3,
//                         ["goldnugget"] = () => Random.Range(0,5),
//                         ["gravestone"] = () => 4 + Random.Range(0,4),
//                         ["mound"] = () => 4 + Random.Range(0,4)
//                     }
//                 }
//             });
//         }
//     }
// }