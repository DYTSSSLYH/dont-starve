using System;
using System.Collections.Generic;

namespace DYT.Map
{
    public class Layout
    {
        public class Item
        {
            public string type;
            public string name;
            public string shape;
            public float x;
            public float y;
            public float width;
            public float height;
            public bool visible;
            public float opacity;
            public Dictionary<string, object> properties;
            public string encoding;
            public List<int> data;
            public List<Item> objects;
        }
        public class Areas
        {
            public List<string> item_area;
        }
        public class Tile
        {
            public string name;
            public int firstgid;
            public int tilewidth;
            public int tileheight;
            public int spacing;
            public int margin;
            public string image;
            public int imagewidth;
            public int imageheight;
            public Dictionary<string, string> properties;
            public List<Tile> tiles;
        }
        
        public int type;
        public bool water;
        public string version;
        public string luaversion;
        public string orientation;
        public int width;
        public int height;
        public int tilewidth;
        public int tileheight;
        public int start_mask;
        public int fill_mask;
        public int layout_position;
        public Dictionary<string, int> count;
        public Dictionary<string, List<Item>> layout;
        public Areas areas;
        public int scale;
        public List<int> ground_types;
        public List<int> ground;
        public Dictionary<string, string> properties;
        public List<Tile> tilesets;
        public List<Item> layers;

        public Action<Dictionary<string, List<Item>>> initfn;
    }
}