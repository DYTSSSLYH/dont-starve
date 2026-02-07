// using System.Collections.Generic;
// using UnityEngine;
// using Assert = UnityEngine.Assertions.Assert;
//
// namespace DYT.Map
// {
//     public class Graph
//     {
//         public class Data
//         {
//             public Vector2 position;
//             public Vector2 old_pos;
//             public int width;
//             public int height;
//             public int size;
//             public int value;
//             public object background;
//         }
//         
//         public string id;
//         public Graph parent;
//         public Dictionary<string, Graph> children;
//         public Dictionary<string, Node> nodes;
//         public Dictionary<string, Edge> edges;
//         public List<Node> exit_nodes;
//         public Dictionary<string, Edge> exit_edges;
//         public int story_depth = -1;
//         public bool visited;
//         public Data data;
//         public int default_bg;
//         public object background;
//         public Color? colour;
//         public List<SetPiece> set_pieces;
//         public List<SetPiece> random_set_pieces;
//         public object maze_tiles;
//         public List<TreasureHunt.Treasure> treasures;
//         public List<TreasureHunt.Treasure> random_treasures;
//         public int MIN_WORMHOLE_ID;
//         public Dictionary<string, Task.Substitute> substitutes;
//         public Node entrancenode;
//         
//         public Graph(){}
//         public Graph(string id, Graph args)
//         {
//             this.id = id;
//             //--print("Graph", id, args.parent, args.data, args.nodes, args.edges,
//             //args.exit_nodes, args.exit_edges, args.default_bg)
//             //-- Is this graph inside another graph
//             parent = args.parent;
//             parent?.AddChild(this);
//             
//             //-- Do we have any child graphs
//             children = args.children ?? new Dictionary<string, Graph>();
//             
//             //-- Nodes within a graph may have cross linking
//             nodes = args.nodes ?? new Dictionary<string, Node>();
//             //-- keep a track on the internal edges
//             edges = args.edges ?? new Dictionary<string, Edge>();
//             
//             //-- These nodes connect this subgraph to other graphs by Edges
//             exit_nodes = args.exit_nodes ?? new List<Node>();
//             exit_edges = args.exit_edges ?? new Dictionary<string, Edge>();
//             
//             //-- Used as a logical representation of progression
//             story_depth = args.story_depth;
//
//             //-- Search
//             visited = false;
//             
//             data = new Data()
//             {
//                 position = new Vector2(){x = 0, y = 0}, old_pos = new Vector2(){x = 0, y = 0},
//                 width = 0, height = 0, size = 0, value = args.default_bg, background = args.background
//             };
//             
//             colour = args.colour ?? new Color(){r=1,g=0,b=0,a=1};
//             
//             //-- a list of layouts to be distributed amongst children
//             set_pieces = args.set_pieces;
//             random_set_pieces = args.random_set_pieces;
//             maze_tiles = args.maze_tiles;
//             treasures = args.treasures;
//             random_treasures = args.random_treasures;
//             //-- print("####New node!! ",self.id, self.maze_tiles)
//             MIN_WORMHOLE_ID = 2300000;
//         }
//
//
//         #region Graph
//         public void AddChild(Graph child)
//         {
//             Assert.IsNotNull(child);
//             Assert.IsFalse(children.ContainsKey(child.id));
//             
//             children.Add(child.id, child);
//         }
//
//         public Edge LockGraph(
//             string id, Node left_exit_node, Node right_exit_node, Dictionary<string, object> lockObject
//         ) {
//             //-- Lock a graph by adding an exit edge across both nodes
//             //--print(self.id..":LockGraph: Edge id:".. id,
//             //"Left Node:"..left_exit_node.id.."("..left_exit_node.graph.id..")",
//             //"Right Node:"..right_exit_node.id.."("..right_exit_node.graph.id..")",
//             //"Lock:"..lock.type)
// 	
//             //--print(lock, lock.type, lock.key)
//             
//             Assert.IsNotNull(lockObject);
//             // --assert(lock.type)
//             // --assert(lock.key)
//             
//             if (id == null) id = $"Exit{Util.GetTableSize(exit_edges)}";
//             Assert.IsFalse(exit_edges.ContainsKey(id));
//             
//             exit_edges.Add(id, new Edge(id, left_exit_node, right_exit_node, lockObject,
//                 new Edge.Data{colour = new Color{r=255, g=255, b=255, a=255}}
//             ));
//             
//             WorldSim.AddExternalLink(left_exit_node.id, right_exit_node.id);
//             
//             return exit_edges[id];
//         }
//         #endregion
//
//         #region EDGES
//         public Edge AddEdgeByNode(string id, Node node1, Node node2, object lockObject)
//         {
//             //--print(self.id..":AddEdgeByNode: ",id, node1, node2, lock)
//             Assert.IsNotNull(node1);
//             Assert.IsNotNull(node2);
//
//             if (id == null) id = $"edge{edges.Count}";
//             Assert.IsFalse(edges.ContainsKey(id));
//
//             if (!nodes.ContainsKey(node1.id)) AddNodeByNode(node1);
//             if (!nodes.ContainsKey(node2.id)) AddNodeByNode(node2);
//
//             Edge edge = new Edge(id, node1, node2, lockObject, new Edge.Data{colour = colour});
//             edges.Add(id, edge);
//             
//             //--print(self.id.."::AddEdgeByNode: Edge ",id,"added")
//             
//             //-- The Edge constructor adds itself to its nodes, this isn't necessary (I hope)
//             //--table.insert(self.nodes[node1.id].edges, edge)
//             //--table.insert(self.nodes[node2.id].edges, edge)
//             //--self.nodes[node2.id].edges[id] = self.edges[id]
//             
//             Assert.IsTrue(nodes.ContainsKey(node1.id));
//             Assert.IsTrue(nodes.ContainsKey(node2.id));
//
//             WorldSim.AddLink(node1.id, node2.id);
//
//             return edges[id];
//         }
//         
//         public Edge AddEdge(Edge args)
//         {
//             //--print(self.id..":AddEdge:", args.id, args.node1id, args.node2id, args.lock)
//             
//             Assert.IsNotNull(args.node1id);
//             Assert.IsNotNull(args.node2id);
//             Assert.IsTrue(nodes.ContainsKey(args.node1id));
//             Assert.IsTrue(nodes.ContainsKey(args.node2id));
//
//             args.id ??= $"edge{edges.Count}";
//             Assert.IsFalse(edges.ContainsKey(args.id));
//
//             Node node1 = nodes[args.node1id];
//             Node node2 = nodes[args.node2id];
//
//             return AddEdgeByNode(args.id, node1, node2, args.lockObject);
//         }
//         #endregion
//         
//         #region NODES
//         public Node AddNodeByNode(Node node)
//         {
//             Assert.IsNotNull(node);
//             Assert.IsNotNull(node.id);
//             Assert.IsFalse(nodes.ContainsKey(node.id));
//             
//             node.graph = this;
//             nodes.Add(node.id, node);
//             
//             if (node.data.entrance) entrancenode = node;
//             
//             //--dumptable(self.nodes[node.id])
//             //--print(self.id..":Graph:AddNodeByNode ", node.id, GetTableSize(self.nodes),
//             //"Parent:"..self.nodes[node.id].graph.id)
//             //--dumptable(self.nodes)
//             
//             Assert.IsTrue(nodes.ContainsKey(node.id));
//             //--print(self.id..":Graph:AddNodeByNode ", self.id, node.id, node.data.value,
//             //node.colour.r, node.colour.g, node.colour.b, node.colour.a)
//             
//             WorldSim.AddChild(
//                 id, node.id, node.data.value, node.colour.r, node.colour.g, node.colour.b, node.colour.a,
//                 node.data.type, node.data.internal_type ?? Constant.NODE_INTERNAL_CONNECTION_TYPE.EdgeSite
//             );
//
//             if (node.data.tags != null && node.data.tags.Count > 0)
//             {
//                 //--WorldSim:SetSiteFlags(node.id, node.data.tags[1])
//             }
//             
//             return nodes[node.id];
//         }
//         
//         public Node AddNode(Node args)
//         {
//             if (args.id == null) args.id = $"node{nodes.Count}";
//             Assert.IsNotNull(args.id);
//             
//             //--print(self.id..":Graph:AddNode ", args.id, args.data)
//             //--dumptable(self.nodes)
//             Assert.IsFalse(nodes.ContainsKey(args.id));
//             
//             //--print("AddNode:", args.id, args.data)
//             //--dumptable(args.data)
//             Node node = new Node(args.id, args.data);
//             
//             return AddNodeByNode(node);
//         }
//
//         public Node GetRandomNode()
//         {
//             Node picked = null;
//             //-- We should never pick blockers
//
//             while (picked == null || picked.data.entrance)
//             {
//                 int choice = Random.Range(0, nodes.Count);
//                 //--print("Graph:GetRandomNode", choice)
//
//                 foreach ((string key, Node value) in nodes)
//                 {
//                     //--print("Graph:GetRandomNode", choice,  k,v)
//                     picked = value;
//                     if (choice <= 0) break;
//                     choice--;
//                 }
//             }
//             
//             Assert.IsNotNull(picked);
//             return picked;
//         }
//
//         //-- Each increment is one more link
//         //ie: a triangle would be factor 1, a line factor 0, a tree factor 0, a square -> 1
//         public void CrosslinkRandom(int crossLinkFactor)
//         {
//             if (nodes.Count <= 2) return;
//
//             int iterations = 0;
//             while (crossLinkFactor > 0 && iterations < 20)
//             {
//                 Node n1 = GetRandomNode();
//                 Node n2 = GetRandomNode();
//                 if (n1 != n2 && !n1.IsConnectedTo(n2) && !n1.data.entrance && !n2.data.entrance)
//                 {
//                     Edge crosslink = AddEdge(new Edge{node1id = n1.id, node2id = n2.id});
//                     //-- hide crosslinks
//                     crosslink.hidden = true;
//                     crossLinkFactor--;
//                 }
//                 iterations++;
//             }
//         }
//
//         public void MakeLoop()
//         {
//             //-- This assumes the graph is linear, and connects one end with the other
//             Node first = null;
//             Node last = null;
//             
//             foreach ((string nodeid, Node node) in nodes)
//             {
//                 //--print(self.id, nodeid, #node.edges)
//                 if (node.edges.Count != 1) continue;
//                 
//                 if (first == null) first = node;
//                 else
//                 {
//                     last = node;
//                     break;
//                 }
//             }
//
//             if (first == null || last == null)
//             {
//                 DebugPrint.print($"Warning: Tried to make {id} into a loop but couldn't find end nodes.");
//                 return;
//             }
//
//             if (first.data.entrance)
//             {
//                 if (first.edges[0].node1 == first) first = first.edges[0].node2;
//                 else first = first.edges[0].node1;
//             }
//             if (last.data.entrance)
//             {
//                 if (last.edges[0].node1 == last) last = last.edges[0].node2;
//                 else last = last.edges[0].node1;
//             }
//             
//             AddEdge(new Edge{node1id = first.id, node2id = last.id});
//         }
//         #endregion
//     }
//     
//     public class Network
//     {
//         
//     }
// }