namespace DYT
{
    // TODO: WorldSim
    public class SpawnUtil
    {
        /*
        private Dictionary<string, Func<object, object, object, bool>> commonspawnfn = {
            {"spiderden", (x, y, ents) => !IsCloseToWater(x, y, 5) && GetDistToSpawnPoint(x, y, ents) >= 100},
            {"fishinhole", (x, y, ents) =>{local tile = WorldSim:GetTile(x, y) => (tile == GROUND.OCEAN_CORAL or tile == GROUND.MANGROVE or (WorldSim:IsWater(tile) && !IsCloseToTileType(x, y, 5, GROUND.OCEAN_SHALLOW))) && IsSurroundedByWater(x, y, 1)}},
            {"tidalpool", (x, y, ents) => !IsCloseToWater(x, y, 2) && GetShortestDistToPrefab(x, y, ents, "tidalpool") >= 3 * TILE_SCALE},

            {"seashell_beached", (x, y, ents) => (!IsCloseToWater(x, y, 1)) && IsCloseToWater(x,y,4)},
            {"mangrovetree", (x, y, ents) => WorldSim:GetTile(x, y) == GROUND.MANGROVE && IsSurroundedByWater(x, y, 1)},
            {"grass_water", (x, y, ents) => WorldSim:GetTile(x, y) == GROUND.MANGROVE && IsSurroundedByWater(x, y, 1)},
            {"grass_tall_patch", (x, y, ents) => !IsCloseToWater(x, y, 3)},
        };
        */
        
        public static void Init(){}
    }
}