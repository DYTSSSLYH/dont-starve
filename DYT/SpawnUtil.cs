using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace DYT
{
    public class SpawnUtil
    {
        private static Dictionary<
            string,
            Func<int, int, Dictionary<string, List<Vector2>>, bool>
        > commonspawnfn = new()
        {
            {
                "spiderden",
                (x, y, ents) => !IsCloseToWater(x, y, 5) && GetDistToSpawnPoint(x, y, ents) >= 100
            },
            {
                "fishinhole",
                (x, y, ents) =>
                {
                    int tile = WorldSim.GetTile(x, y);
                    return (
                                tile == Constant.GROUND.OCEAN_CORAL || tile == Constant.GROUND.MANGROVE ||
                                (
                                    WorldSim.IsWater(tile) &&
                                    !IsCloseToTileType(x, y, 5, Constant.GROUND.OCEAN_SHALLOW)
                                )
                           ) &&
                           IsSurroundedByWater(x, y, 1);
                }
            },
            {
                "tidalpool",
                (x, y, ents) =>
                    !IsCloseToWater(x, y, 2) &&
                    GetShortestDistToPrefab(x, y, ents, "tidalpool") >= 3 * Constant.TILE_SCALE
            },

            {"seashell_beached", (x, y, ents) => (!IsCloseToWater(x, y, 1)) && IsCloseToWater(x,y,4)},
            {
                "mangrovetree",
                (x, y, ents) =>
                    WorldSim.GetTile(x, y) == Constant.GROUND.MANGROVE &&
                    IsSurroundedByWater(x, y, 1)
            },
            {
                "grass_water",
                (x, y, ents) =>
                    WorldSim.GetTile(x, y) == Constant.GROUND.MANGROVE &&
                    IsSurroundedByWater(x, y, 1)
            },
            {"grass_tall_patch", (x, y, ents) => !IsCloseToWater(x, y, 3)},
        };

        private static List<string> waterprefabs = new()
        {
            "coralreef", "seaweed_planted", "mussel_farm", "lobsterhole", "messagebottle",
            "messagebottleempty", "wreck"
        };

        private static List<string> landprefabs = new()
        {
            "jungletree", "palmtree", "bush_vine", "limpetrock", "sandhill", "sapling", "poisonhole",
            "wildborehouse", "mermhouse", "magmarock", "magmarock_gold", "flower", "fireflies", "grass",
            "bambootree", "berrybush", "berrybush_snake", "berrybush2", "berrybush2_snake", "crabhole", "rock1",
            "rock2",
            "rock_flintless", "rocks", "flint", "goldnugget", "gravestone", "mound", "red_mushroom", "blue_mushroom",
            "green_mushroom", "carrot_planted", "beehive", "reeds", "marsh_tree", "snakeden", "pond", "primeapebarrel",
            "mandrake", "mermhouse_fisher", "sweet_potato_planted", "flup", "flupspawner_sparse", "wasphive",
            "beachresurrector", "flower_evil", "crate", "tallbirdnest",

            //-- Porkland prefabs

            "clawpalmtree", "grass_tall", "flower_rainforest", "dungpile", "randomdust", "rock_flippable",
            "aloe_planted", "asparagus_planted", "radish_planted", "rainforesttree", "peagawk", "pog",
            "tubertree", "nitre", "teatree", "nettle", "pig_ruins_torch", "adult_flytrap", "charcoal",
            "randomrelic", "randomruin", "pig_ruins_entrance_small", "rainforesttree_rot", "meteor_impact",
            "anthill", "anthill_exit", "pighead", "tree_pillar", "mandrakehouse", "rainforesttree_burnt",
            "gnatmound", "iron", "thunderbirdnest", "sedimentpuddle", "vampirebatcave_potential",
            "ancient_robot_claw", "ancient_robot_leg", "ancient_robot_ribs", "ancient_robot_head",
            "spoiled_food",
        };

        private static List<string> landprefabs_patch = new()
        {
            "deep_jungle_fern_noise", "teatree_piko_nest_patch", "hanging_vine_patch",
        };
        

        static SpawnUtil()
        {
            AddCommonSpawnTestFn(waterprefabs, surroundedbywater);
            AddCommonSpawnTestFn(landprefabs, notclosetowater);
            AddCommonSpawnTestFn(landprefabs_patch, notclosetowater_patch);
        }


        public static float GetShortestDistToPrefab(int x, int y, Dictionary<string, List<Vector2>> ents,
            string prefab)
        {
            Vector2 worldSize = WorldSim.GetWorldSize();
            float halfWidth = worldSize.x / 2;
            float halfHeight = worldSize.y / 2;
            float shortestDistance = 100000;
            if (ents != null && ents[prefab] != null)
            {
                foreach (Vector2 spawn in ents[prefab])
                {
                    float deltaX = (x - halfWidth) * Constant.TILE_SCALE - spawn.x;
                    float deltaY = (y - halfHeight) * Constant.TILE_SCALE - spawn.y;
                    float tempDistance = Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY);
                    if (tempDistance < shortestDistance) shortestDistance = tempDistance;
                    //--print(string.format("GetShortestDistToPrefab (%d, %d) -> (%d, %d) = %d", x, y, sx, sy, dist))
                }
            }
            return shortestDistance;
        }

        public static float GetDistToSpawnPoint(int x, int y, Dictionary<string, List<Vector2>> ents)
        {
            return GetShortestDistToPrefab(x, y, ents, "spawnpoint");
        }

        public static bool IsSurroundedByWater(int x, int y, int radius)
        {
            for (int i = -radius; i <= radius; i++)
            {
                if (!WorldSim.IsWater(WorldSim.GetTile(x - radius, y + i)) ||
                    !WorldSim.IsWater(WorldSim.GetTile(x + radius, y + i)))
                {
                    return false;
                }
            }
            for (int i = -(radius - 1); i <= radius - 1; i++)
            {
                if (!WorldSim.IsWater(WorldSim.GetTile(x + i, y - radius)) ||
                    !WorldSim.IsWater(WorldSim.GetTile(x + i, y + radius)))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsCloseToWater(int x, int y, int radius)
        {
            for (int i = -radius; i <= radius; i++)
            {
                if (!WorldSim.IsWater(WorldSim.GetTile(x - radius, y + i)) ||
                    !WorldSim.IsWater(WorldSim.GetTile(x + radius, y + i)))
                {
                    return true;
                }
            }
            for (int i = -(radius - 1); i <= radius - 1; i++)
            {
                if (!WorldSim.IsWater(WorldSim.GetTile(x + i, y - radius)) ||
                    !WorldSim.IsWater(WorldSim.GetTile(x + i, y + radius)))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsCloseToTileType(int x, int y, int radius, int tile)
        {
            for (int i = -radius; i <= radius; i++)
            {
                if (WorldSim.GetTile(x - radius, y + i) == tile ||
                    WorldSim.GetTile(x + radius, y + i) == tile)
                {
                    return true;
                }
            }
            for (int i = -(radius - 1); i <= radius - 1; i++)
            {
                if (WorldSim.GetTile(x + i, y - radius) == tile ||
                    WorldSim.GetTile(x + i, y + radius) == tile)
                {
                    return true;
                }
            }
            return false;
        }
        
        
        private static bool surroundedbywater(int x, int y, Dictionary<string, List<Vector2>> ents)
        {
            return IsSurroundedByWater(x, y, 1);
        }
        
        private static bool notclosetowater(int x, int y, Dictionary<string, List<Vector2>> ents)
        {
            return IsCloseToWater(x, y, 1);
        }
        
        private static bool notclosetowater_patch(int x, int y,
            Dictionary<string, List<Vector2>> ents)
        {
            return IsCloseToWater(x, y, 2);
        }
        
        private static void AddCommonSpawnTestFn(List<string> prefab_table,
            Func<int, int, Dictionary<string, List<Vector2>>, bool> test_fn)
        {
            foreach (string prefab in prefab_table)
            {
                //-- don't replace an existing one
                Assert.IsTrue(!commonspawnfn.ContainsKey(prefab),
                    $"{prefab} already exists in commonspawnfn table");
                commonspawnfn.Add(prefab, test_fn);
            }
        }
    }
}