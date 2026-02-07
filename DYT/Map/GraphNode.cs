// using System.Collections.Generic;
// using System.Linq;
// using UnityEngine;
// using UnityEngine.Assertions;
//
// namespace DYT.Map
// {
//     public class Node
//     {
//         public string id;
//         public Graph graph;
//         public Graph delta_graph;
//         public List<Edge> edges;
//         public Room data;
//         public bool visited;
//         public Color colour;
//         public object ents;
//         public object populateFn;
//         public object tileFn;
//         public bool populated;
//         public bool children_populated;
//         public object custom_tiles_data;
//         public object custom_objects_data;
//         
//         
//         public Node(){}
//         public Node(string id, Room data)
//         {
//             this.id = id;
//             graph = null;
//             delta_graph = null;
//             
//             //-- Graph properties
//             edges = new List<Edge>();
//             
//             //-- Data
//             this.data = data;
//             
//             //-- Search
//             visited = false;
//             
//             colour = data.colour ?? new Color{r=255,g=255,b=0,a=55};
//             
//             ents = null;
//             populateFn = null;
//             tileFn = null;
//             populated = false;
//             children_populated = false;
//
//             if (this.data.custom_tiles != null)
//             {
//                 SetTilesFunction(this.data.custom_tiles);
//                 this.data.custom_tiles = null;
//             }
//             if (this.data.custom_objects != null)
//             {
//                 SetPopulateFunction(this.data.custom_objects);
//                 this.data.custom_objects = null;
//             }
//         }
//
//
//         public bool IsConnectedTo(Node node)
//         {
//             Assert.IsNotNull(node);
//             return edges.Any(edge => edge.node1 == node || edge.node2 == node);
//         }
//
//         public void SetPopulateFunction(object custom_objects_data)
//         {
//             this.custom_objects_data = custom_objects_data;
//             populated = false;
//             //-- Set tag to run here
//         }
//
//         public void SetTilesFunction(object custom_tiles_data)
//         {
//             this.custom_tiles_data = custom_tiles_data;
//             //-- Set tag to run here
//         }
//     }
//     
//     public class GraphNode
//     {
//         
//     }
// }