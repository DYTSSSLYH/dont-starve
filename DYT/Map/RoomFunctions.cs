using System.Collections.Generic;

namespace DYT.Map
{
    public delegate void GeneratorFunction(object id, object entities, object data);
    public class RoomFunctions
    {
        public class Runca
        {
            public GeneratorFunction GeneratorFunction;
            public object DefaultArgs;
        }

        
        private static void RunCA(object id, object entities, object data){}
        private class DefaultArgs
        {
            public int
                iterations = 6,
                seed_mode = Constant.CA_SEED_MODE.SEED_CENTROID,
                num_random_points = 1;
        }
        public static Runca RUNCA = new() { GeneratorFunction = RunCA, DefaultArgs = new DefaultArgs()};
        
        private static void MyTestTileSetFunction(object id, object entities, object data){}
        private class Data
        {
            public int tile;
            public List<string> items;
            public int item_count;
        }
        private static List<Data> MyTestTileSetFunction_data = new()
        {
            new Data { tile = Constant.GROUND.FOREST, items = new List<string> {"evergreen_tall"}, item_count = 3},
            new Data { tile = Constant.GROUND.FOREST, items = new List<string> {"evergreen_normal"}, item_count = 5},
            new Data { tile = Constant.GROUND.FOREST, items = new List<string> {"evergreen_short"}, item_count = 7},
            new Data { tile = Constant.GROUND.GRASS, items = new List<string> {"sapling","berrybush"}, item_count = 6},
            new Data { tile = Constant.GROUND.SAVANNA, items = new List<string> {"grass"}, item_count = 6},
            new Data { tile = Constant.GROUND.DIRT},
            new Data { tile = Constant.GROUND.ROCKY},
        }; 
        public static Runca PlaceLightBeam = new() { GeneratorFunction = MyTestTileSetFunction, DefaultArgs = MyTestTileSetFunction_data};
        
        private static void NoiseTileSetFunction(object id, object entities, object data){}
        public static Runca Noise = new() { GeneratorFunction = NoiseTileSetFunction};
        
        private static void VolcanoTileSetFunction(object id, object entities, object data){}
        public static Runca VolcanoNoise = new() { GeneratorFunction = VolcanoTileSetFunction};
        
        private static void JungleTileSetFunction(object id, object entities, object data){}
        public static Runca JungleNoise = new() { GeneratorFunction = JungleTileSetFunction};
    }
}