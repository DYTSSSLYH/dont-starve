// // --------------------------------------------------------------------------------
// // -- Spider 
// // --------------------------------------------------------------------------------
//
// using UnityEngine;
//
// namespace DYT.Map.rooms
// {
//     public class SpiderRooms
//     {
//         static SpiderRooms()
//         {
// 	        Rooms.AddRoom("SpiderCity", new Room
// 	        {
// 		        colour = new Color{r = 0.30f, g = 0.20f, b = 0.50f, a = 0.50f },
// 		        value = Constant.GROUND.FOREST,
// 		        contents =
// 		        {
// 			        countprefabs =
// 			        {
// 				        ["goldnugget"] = () => 3 + Random.Range(0,3),
// 			        },
// 			        distributepercent = 0.3f,
// 			        distributeprefabs =
// 			        {
// 				        ["evergreen_sparse"] = 3,
// 				        ["spiderden"] = 0.3f,
// 			        },
// 			        prefabdata =
// 			        {
// 				        ["spiderden"] = ()=>
// 				        {
// 					        if (Random.value < 0.2)
// 						        return "{ growable={stage=3}}";
// 					        else
// 						        return "{ growable={stage=2}}";
//
// 				        },
// 			        },
// 		        }
// 	        });
//
// 	        Rooms.AddRoom("SpiderVillage", new Room
// 	        {
// 		        colour = new Color{r = 0.30f, g = 0.20f, b = 0.50f, a = 0.50f },
// 		        value = Constant.GROUND.ROCKY,
// 		        contents =
// 		        {
// 			        countprefabs =
// 			        {
// 				        ["goldnugget"] = () => 3 + Random.Range(0,3),
// 				        ["spiderden"] = () => 5 + Random.Range(0,3)
// 			        },
// 			        distributepercent = 0.1f,
// 			        distributeprefabs =
// 			        {
// 				        ["rock1"] = 1,
// 				        ["rock2"] = 1,
// 				        ["rocks"] = 1,
// 			        },
// 			        prefabdata =
// 			        {
// 				        ["spiderden"] = ()=>
// 				        {
// 					        if (Random.value < 0.2)
// 						        return "{ growable={stage=2}}";
// 					        else
// 						        return "{ growable={stage=1}}";
//
// 				        },
// 			        },
// 		        }
// 	        });
// 	        Rooms.AddRoom("SpiderVillageSwamp", new Room
// 	        {
// 		        colour = new Color{r = 0.30f, g = 0.20f, b = 0.50f, a = 0.50f },
// 		        value = Constant.GROUND.MARSH,
// 		        contents =
// 		        {
// 			        countprefabs =
// 			        {
// 				        ["goldnugget"] = () => 3 + Random.Range(0,3),
// 				        ["spiderden"] = () => 5 + Random.Range(0,3)
// 			        },
// 			        distributepercent = 0.1f,
// 			        distributeprefabs =
// 			        {
// 				        ["marsh_tree"] = 1,
// 				        ["marsh_bush"] = 1,
// 			        },
// 			        prefabdata =
// 			        {
// 				        ["spiderden"] = ()=>
// 				        {
// 					        if (Random.value < 0.2)
// 						        return "{ growable={stage=2}}";
// 					        else
// 						        return "{ growable={stage=1}}";
//
// 				        },
// 			        },
// 		        }
// 	        });
//         }
//     }
// }