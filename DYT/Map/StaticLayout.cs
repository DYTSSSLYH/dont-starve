// using System;
// using System.Collections.Generic;
// using System.Reflection;
// using Random = UnityEngine.Random;
//
// namespace DYT.Map
// {
//     public class StaticLayout
//     {
//         //-- must define it first so we can recurse
//         private static void ParseNestedKey(Dictionary<string, object> obj, string[] key, object value)
//         {
//             if (key.Length == 1)
//             {
//                 obj[key[0]] = value;
//                 return;
//             }
//
//             string key_head = key[0];
//             if (key_head == null) return;
//
//             List<string> key_tail = new List<string>();
//             for (int i = 1; i < key.Length; i++) key_tail.Add(key[i]);
//             if (obj[key_head] == null) obj[key_head] = new Dictionary<string, object>();
//             ParseNestedKey((Dictionary<string, object>)obj[key_head], key_tail.ToArray(), value);
//         }
//         
//         public static Layout Get(string layoutSrc, Layout additionalProps = null)
//         {
//             Type type = Type.GetType(layoutSrc);
//             MethodInfo methodInfo = type.GetMethod("Main");
//             Layout staticLayout = (Layout)methodInfo.Invoke(null, null);
//             
//             Layout layout = additionalProps ?? new Layout();
// 		
//             //-- add stuff
//             layout.type = Constant.LAYOUT.STATIC;
//             layout.scale = 1;
// 	
//             //-- See \tools\tiled\dont_starve\tiles.png for tiles
//             layout.ground_types = new List<int>
//             {
//                 //--Translates tile type index from constants.lua into tiled tileset. 
//                 //--Order they appear here is the order they will be used in tiled.
//                 Constant.GROUND.IMPASSABLE, Constant.GROUND.ROAD, Constant.GROUND.ROCKY, Constant.GROUND.DIRT,
//                 Constant.GROUND.SAVANNA, Constant.GROUND.GRASS, Constant.GROUND.FOREST, Constant.GROUND.MARSH,
//
//                 Constant.GROUND.WOODFLOOR, Constant.GROUND.CARPET, Constant.GROUND.CHECKER, Constant.GROUND.CAVE,
//                 Constant.GROUND.FUNGUS, Constant.GROUND.SINKHOLE, Constant.GROUND.WALL_ROCKY, Constant.GROUND.WALL_DIRT,
//
//                 Constant.GROUND.WALL_MARSH, Constant.GROUND.WALL_CAVE, Constant.GROUND.WALL_FUNGUS,
//                 Constant.GROUND.WALL_SINKHOLE,
//                 Constant.GROUND.UNDERROCK, Constant.GROUND.MUD, Constant.GROUND.WALL_MUD, Constant.GROUND.WALL_WOOD,
//
//                 Constant.GROUND.BRICK, Constant.GROUND.BRICK_GLOW, Constant.GROUND.TILES, Constant.GROUND.TILES_GLOW,
//                 Constant.GROUND.TRIM, Constant.GROUND.TRIM_GLOW, Constant.GROUND.WALL_HUNESTONE,
//                 Constant.GROUND.WALL_HUNESTONE_GLOW,
//
//                 Constant.GROUND.WALL_STONEEYE, Constant.GROUND.WALL_STONEEYE_GLOW, Constant.GROUND.FUNGUSRED,
//                 Constant.GROUND.FUNGUSGREEN,
//                 Constant.GROUND.BEACH, Constant.GROUND.JUNGLE, Constant.GROUND.SWAMP, Constant.GROUND.OCEAN_SHALLOW,
//
//                 Constant.GROUND.OCEAN_MEDIUM, Constant.GROUND.OCEAN_DEEP, Constant.GROUND.OCEAN_CORAL,
//                 Constant.GROUND.MANGROVE,
//                 Constant.GROUND.MAGMAFIELD, Constant.GROUND.TIDALMARSH, Constant.GROUND.MEADOW, Constant.GROUND.VOLCANO,
//
//                 Constant.GROUND.VOLCANO_LAVA, Constant.GROUND.ASH, Constant.GROUND.VOLCANO_ROCK,
//                 Constant.GROUND.OCEAN_SHIPGRAVEYARD,
//                 Constant.GROUND.COBBLEROAD, Constant.GROUND.FOUNDATION, Constant.GROUND.DEEPRAINFOREST,
//                 Constant.GROUND.LAWN,
//
//                 Constant.GROUND.PIGRUINS, Constant.GROUND.LILYPOND, Constant.GROUND.GASJUNGLE, Constant.GROUND.SUBURB,
//                 Constant.GROUND.RAINFOREST, Constant.GROUND.PIGRUINS_NOCANOPY, Constant.GROUND.PLAINS,
//                 Constant.GROUND.PAINTED,
//
//                 Constant.GROUND.BATTLEGROUND, Constant.GROUND.INTERIOR, Constant.GROUND.FIELDS
//             };
//             layout.ground = new List<int>();
//
//             //-- so we can support both 16 wide grids and 64 wide grids from tiled
//             int tilefactor = 64 / staticLayout.tilewidth;
// 	
//             //-- See \tools\tiled\dont_starve\objecttypes.xml for objects
//             layout.layout = new Dictionary<string, List<Layout.Item>>();
//
//             foreach (Layout.Item layer in staticLayout.layers)
//             {
//                 if (layer.type == "tilelayer" && layer.name == "BG_TILES")
//                 {
//                     float val_per_row = layer.width * (tilefactor - 1);
//                     int i = (int)val_per_row;
//
//                     while (i < layer.data.Count)
//                     {
//                         List<int> data = new();
//                         int j = 1;
//                         while (j < layer.width && i + j < layer.data.Count)
//                         {
//                             data.Add(layer.data[i + j]);
//                             j += tilefactor;
//                         }
//                         layout.ground.AddRange(data);
//                         i += (int)(val_per_row + layer.width);
//                     }
//                 }
//                 else if (layer.type == "objectgroup" && layer.name == "FG_OBJECTS")
//                 {
//                     foreach (Layout.Item obj in layer.objects)
//                     {
//                         if (layout.layout[obj.type] == null)
//                             layout.layout[obj.type] = new List<Layout.Item>();
//                         
//                         //-- TODO: Check the object properties for other options to substitute here
//                         float x = obj.x + obj.width / 2;
//                         x = x / (float)64.0 - (staticLayout.width / tilefactor) / 2;
//                         float y = obj.y + obj.height / 2;
//                         y = y / (float)64.0 - (staticLayout.height / tilefactor) / 2;
//
//                         float width = obj.width / (float)64.0;
//                         float height = obj.height / (float)64.0;
//
//                         Dictionary<string, object> properties = new();
//                         if (obj.properties != null)
//                         {
//                             foreach ((string key, object value) in obj.properties)
//                             {
//                                 string[] keys = key.Split(".");
//                                 if (value == "true" || value == "false")
//                                     ParseNestedKey(properties, keys, value);
//                                 else ParseNestedKey(properties, keys, value);
//                             }
//                             
//                             //--print("Static Layout Properties for ", layoutsrc)
//                             //--dumptable(properties,1,10)
//                         }
//
//                         if (properties["chance"] == null || Random.value < (float)properties["chance"])
//                         {
//                             layout.layout[obj.type].Add(new Layout.Item
//                             {
//                                 x = x, y = y, properties = properties, width = width, height = height
//                             });
//                         }
//                     }
//
//                     layout.initfn?.Invoke(layout.layout);
//                 }
//             }
//
//             return layout;
//         }
//     }
// }