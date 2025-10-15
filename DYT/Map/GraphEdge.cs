using UnityEngine;

namespace DYT.Map
{
    public class Edge
    {
        public class Data
        {
            public Color? colour;
        }
        
        public string node1id;
        public string node2id;
        public string id;
        public object locked;
        public object lockObject;
        public Node node1;
        public Node node2;
        public bool visited;
        public bool hidden;
        public Data data;
        public object contents;
        public Color colour;
        
        public Edge(){}
        public Edge(string id, Node node1, Node node2, object locked, Data data)
        {
            this.id = id;
            //-- an edge may belong to two graphs
            
            //-- Graph properties
            this.node1 = node1;
            this.node2 = node2;
            
            node1.edges.Add(this);
            node2.edges.Add(this);

            if (node1.graph.id != node2.graph.id)
            {
                //--print("Registered Forign EDGE["..id.."] with Nodes "..node1.id.."("..node1.graph.id
                //..") and "..node2.id.."("..node2.graph.id..")")
            }
            
            visited = false;
            hidden = false;

            //-- Data
            this.data = data;
            
            //-- Default to not locked; The lock applies to node 1 so the key should always be behind node2
            //-- locks should be in the form {locktype, keytype, keynode}
            this.locked = locked;
            
            //-- What we will populate this edge with
            contents = new object();

            colour = new Color { r = 255, g = 0, b = 0, a = 255 };
            if (data != null) colour = data.colour ?? colour;
        }
    }
    
    public class GraphEdge
    {
        
    }
}