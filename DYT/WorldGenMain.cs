namespace DYT
{
    public class WorldGenMain
    {
        public static long? SEED;
    
        static WorldGenMain()
        {
            if (!SEED.HasValue){}
        }
    
        public static bool IsRail()
        {
            return Main.PLATFORM == "WIN32_RAIL";
        }
    }
}