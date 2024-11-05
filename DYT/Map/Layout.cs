using System.Collections.Generic;

namespace DYT.Map
{
    public class Layout
    {
        public class Item
        {
            public float x;
            public float y;
            public float width;
            public float height;
            public Dictionary<string, string> properties;
        }
        public class Areas
        {
            public List<string> item_area;
        }
        
        public int type;
        public bool water;
        public int width;
        public int height;
        public int start_mask;
        public int fill_mask;
        public int layout_position;
        public Dictionary<string, int> count;
        public Dictionary<string, List<Item>> layout;
        public Areas areas;
        public int scale;
    }
}