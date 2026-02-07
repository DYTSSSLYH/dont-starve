// using System.Collections.Generic;
//
// namespace DYT.Map
// {
//     public class Traps : SandboxAndLayouts
//     {
//         private Dictionary<string, Layout>
//             Rare = new()
//             {
//                 //--["Dev Graveyard"] = StaticLayout.Get("map/static_layouts/dev_graveyard"),
//             },
//             Jungle = new()
//             {
//                 ["PoisonVines"] = new Layout
//                 {
//                     type = Constant.LAYOUT.STATIC,
//                     width = 8,
//                     height = 8,
//                     start_mask = Constant.PLACE_MASK.NORMAL,
//                     fill_mask = Constant.PLACE_MASK.IGNORE_IMPASSABLE_BARREN_RESERVED,
//                     layout_position = Constant.LAYOUT_POSITION.CENTER,
//                     layout =
//                     {
//                         ["bush_vine"] =
//                         {
//                             new Layout.Item() { x = 0.866f, y = 0.5f, properties = { ["scenario"] = "vine_hideout" } },
//                             new Layout.Item() { x = 0.866f, y = -0.5f, properties = { ["scenario"] = "vine_hideout" } },
//                             new Layout.Item() { x = 0, y = -1, properties = { ["scenario"] = "vine_hideout" } },
//                             new Layout.Item()
//                                 { x = -0.866f, y = -0.5f, properties = { ["scenario"] = "vine_hideout" } },
//                             new Layout.Item() { x = -0.866f, y = 0.5f, properties = { ["scenario"] = "vine_hideout" } },
//                             new Layout.Item() { x = 0, y = 1, properties = { ["scenario"] = "vine_hideout" } }
//                         },
//                         ["item_area"] =
//                         {
//                             new Layout.Item()
//                             {
//                                 x = 0, y = 0, width = 0.4f, height = 0.4f,
//                                 properties = { ["scenario"] = "snake_ambush" }
//                             }
//                         }
//                     },
//                     areas =
//                     {
//                         item_area = { "venomgland", "venomgland", "venomgland" }
//                     },
//
//                     scale = 2
//                 },
//             },
//             TidalMarsh = new()
//             {
//                 ["AirPollution"] =
//                 {
//                     type = Constant.LAYOUT.CIRCLE_EDGE,
//                     width = 8,
//                     height = 8,
//                     start_mask = Constant.PLACE_MASK.NORMAL,
//                     fill_mask = Constant.PLACE_MASK.IGNORE_IMPASSABLE_BARREN_RESERVED,
//                     layout_position = Constant.LAYOUT_POSITION.CENTER,
//                     count =
//                     {
//                         ["poisonhole"] = 6,
//                     },
//                     layout =
//                     {
//                         ["item_area"] = { new Layout.Item() { x = 0, y = 0, width = 0.4f, height = 0.4f } }
//                     },
//                     areas =
//                     {
//                         item_area = { "spear_poison", "venomgland", "venomgland", "tentacle", "tentacle", "tentacle" }
//                     },
//
//                     scale = 3,
//                 },
//             },
//             OceanDeep = new()
//             {
//                 ["FeedingFrenzy"] =
//                 {
//                     type = Constant.LAYOUT.STATIC,
//                     water = true,
//                     layout =
//                     {
//                         ["cargoboat"] =
//                             { new Layout.Item { x = 0, y = 0, properties = { ["scenario"] = "sharx_ambush" } } },
//                     },
//                     scale = 1,
//                 },
//             },
//             AnyGround = new()
//             {
//                 //-- ["Airstrike"] = StaticLayout.Get("map/static_layouts/traps/airstrike"),
//                 ["Airstrike"] =
//                 {
//                     type = Constant.LAYOUT.CIRCLE_EDGE,
//                     width = 8,
//                     height = 8,
//                     start_mask = Constant.PLACE_MASK.NORMAL,
//                     fill_mask = Constant.PLACE_MASK.IGNORE_IMPASSABLE_BARREN_RESERVED,
//                     layout_position = Constant.LAYOUT_POSITION.CENTER,
//                     count =
//                     {
//                         ["obsidian"] = 6,
//                     },
//                     layout =
//                     {
//                         ["volcanostaff"] =
//                             { new Layout.Item() { x = 0, y = 0, properties = { ["scenario"] = "staff_erruption" } } },
//                     },
//
//                     scale = 2,
//                 },
//             };
//         
//         public Traps()
//         {
//             new StaticLayout();
//
//             Dictionary<object, Dictionary<string, Layout>> SandboxModeTraps = new()
//             {
//                 ["Rare"] = Rare,
//                 ["Shipwrecked_Any"] = AnyGround,
//                 [Constant.GROUND.JUNGLE] = Jungle,
//                 [Constant.GROUND.TIDALMARSH] = TidalMarsh,
//                 [Constant.GROUND.OCEAN_DEEP] = OceanDeep,
//                 //--[GROUND.ROCKY] = Rocky,
//                 //--[GROUND.SAVANNA] = Savanna,
//                 //--[GROUND.GRASS] = Grasslands,
//                 //--[GROUND.FOREST] = Forest,
//                 //--[GROUND.MARSH] = Swamp,
//                 //--[GROUND.DIRT] = Badlands,
//             };
//
//             Dictionary<string, Layout> layouts = new();
//             foreach ((object key, Dictionary<string, Layout> area) in SandboxModeTraps)
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
//             Sandbox = SandboxModeTraps;
//             Layouts = layouts;
//         }
//     }
// }