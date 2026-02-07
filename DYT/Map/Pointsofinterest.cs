// using System.Collections.Generic;
//
// namespace DYT.Map
// {
//     public class Pointsofinterest : SandboxAndLayouts
//     {
//         private Dictionary<string, Layout>
//             Rare = new()
//             {
//                 ["skeleton_dapper"] = StaticLayout.Get("map/static_layouts/skeleton_dapper"),
//
//                 //-- Prebuilt bases
// 	            ["skeleton_researchlab1"] = StaticLayout.Get("map/static_layouts/skeleton_researchlab1"),
// 	            ["skeleton_researchlab2"] = StaticLayout.Get("map/static_layouts/skeleton_researchlab2"),
// 	            ["skeleton_researchlab3"] = StaticLayout.Get("map/static_layouts/skeleton_researchlab3"),
//             },
//             
//             Forest = new(){
//                 ["skeleton_lumberjack"] = StaticLayout.Get("map/static_layouts/skeleton_lumberjack"),
//                 ["skeleton_trapper"] = StaticLayout.Get("map/static_layouts/skeleton_trapper"),
//             },
//             
//             Grasslands = new(){
//                 ["skeleton_entomologist"] = StaticLayout.Get("map/static_layouts/skeleton_entomologist"),
//                 ["skeleton_farmer"] = StaticLayout.Get("map/static_layouts/skeleton_farmer"),
//
//                 //-- Point of no interest
//                 ["grass_spots"] = StaticLayout.Get("map/static_layouts/grass_spots"),
//             },
//             
//             Dirt = new()
//             {
//                 ["skeleton_miner_dirt"] = StaticLayout.Get("map/static_layouts/skeleton_miner_dirt"), //-- Protected by leifs
//             },
//             
//             Swamp = new()
//             {
//                 ["skeleton_hunter_swamp"] = StaticLayout.Get("map/static_layouts/skeleton_hunter_swamp"), //-- Protected by tentcles
//             },
//             
//             Rocky = new()
//             {
//                 ["skeleton_miner"] = StaticLayout.Get("map/static_layouts/skeleton_miner"),
//             },
//             
//             Savanna = new()
//             {
//                 ["skeleton_camper"] = StaticLayout.Get("map/static_layouts/skeleton_camper"),
//                 ["skeleton_hunter"] = StaticLayout.Get("map/static_layouts/skeleton_hunter"),
//             },
//             
//             Any = new()
//             {
//                 //-- Professions
//                 ["skeleton_wizard_ice"] = StaticLayout.Get("map/static_layouts/skeleton_wizard_ice"),
//                 ["skeleton_wizard_fire"] = StaticLayout.Get("map/static_layouts/skeleton_wizard_fire"),
//                 ["skeleton_warrior"] = StaticLayout.Get("map/static_layouts/skeleton_warrior"),
//                 ["skeleton_construction"] = StaticLayout.Get("map/static_layouts/skeleton_construction"),
//                 ["skeleton_fisher"] = StaticLayout.Get("map/static_layouts/skeleton_fisher"),
//                 ["skeleton_graverobber"] = StaticLayout.Get("map/static_layouts/skeleton_graverobber"),
//                 ["skeleton_night_hunter"] = StaticLayout.Get("map/static_layouts/skeleton_night_hunter"),
//                 ["skeleton_summer"] = StaticLayout.Get("map/static_layouts/skeleton_summer"),
//                 ["skeleton_rain_coat"] = StaticLayout.Get("map/static_layouts/skeleton_rain_coat"),
//             },
//             
//             //-- TODO: Add winter/summer, nighttime/dusk/day filters
//             Winter = new()
//             {
//                 ["skeleton_winter_easy"] = StaticLayout.Get("map/static_layouts/skeleton_winter_easy"),
//                 ["skeleton_winter_medium"] = StaticLayout.Get("map/static_layouts/skeleton_winter_medium"),
//                 ["skeleton_winter_hard"] = StaticLayout.Get("map/static_layouts/skeleton_winter_hard"),
//             };
//         
//         public Pointsofinterest()
//         {
//             new StaticLayout();
//
//             Dictionary<object, Dictionary<string, Layout>> SandboxModePointsofInterest = new()
//             {
//                 ["Rare"] = Rare,
//                 ["Any"] = Any,
//                 //--["Winter"] = Winter,
//                 [Constant.GROUND.ROCKY] = Rocky,
//                 [Constant.GROUND.DIRT] = Dirt,
//                 [Constant.GROUND.SAVANNA] = Savanna,
//                 [Constant.GROUND.GRASS] = Grasslands,
//                 [Constant.GROUND.FOREST] = Forest,
//                 [Constant.GROUND.MARSH] = Swamp,
//             };
//
//             Dictionary<string, Layout> layouts = new();
//             foreach ((object key, Dictionary<string, Layout> area) in SandboxModePointsofInterest)
//             {
//                 if (Util.GetTableSize(area) == 0) continue;
//                 foreach ((string name, Layout layout) in area)
//                 {
//                     layouts.TryAdd(name, layout);
//                     layouts[name] = layout;
//                 }
//             }
//
//             
//             Sandbox = SandboxModePointsofInterest;
//             Layouts = layouts;
//         }
//     }
// }