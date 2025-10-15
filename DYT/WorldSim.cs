using UnityEngine;

namespace DYT
{
    public static class WorldSim
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Constant.GROUND</returns>
        public static int GetTile(int x, int y)
        {
            return 0;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tile">Constant.GROUND</param>
        /// <returns></returns>
        public static bool IsWater(int tile)
        {
            return tile >= 55;
        }
        
        public static bool IsShore(int tile)
        {
            return tile == Constant.GROUND.OCEAN_SHORE || tile == Constant.GROUND.MANGROVE_SHORE ||
                   tile == Constant.GROUND.OCEAN_CORAL_SHORE ||
                   tile == Constant.GROUND.OCEAN_SHIPGRAVEYARD_SHORE;
        }

        public static Vector2 GetWorldSize()
        {
            return new Vector2(Screen.width, Screen.height);
        }

        public static void ResetAll(){}

        public static void AddIslandRegionMapping(string a, string b){}
        
        public static void AddChild(
            string parentGraphId, string childGraphId, int room_bg, float r, float g, float b, float a,
            object type = null, int? internal_type = null
        ){}
        
        public static void AddLink(string node1Id, string node2Id){}
        public static void AddExternalLink(string node1Id, string node2Id){}
    }
}