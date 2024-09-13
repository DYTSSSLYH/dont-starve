namespace DYT.Map
{
    public class ForestMap
    {
        private static bool SKIP_GEN_CHECKS = false;

        static ForestMap()
        {
            new Terrain();
            new Water();
            new TreasureHunt();
        }
    }
}