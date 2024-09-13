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
            return false;
        }

        public static Vector2 GetWorldSize()
        {
            return new Vector2(Screen.width, Screen.height);
        }
    }
}