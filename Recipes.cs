using System.Collections.Generic;
using DYT;

public class Recipes
{
    private static List<string> mergedGameTypes = new List<string>
    {
        Constant.RECIPE_GAME_TYPE.VANILLA,
        Constant.RECIPE_GAME_TYPE.SHIPWRECKED,
        Constant.RECIPE_GAME_TYPE.PORKLAND
    };
    private static string[] cityRecipeGameTypes = { Constant.RECIPE_GAME_TYPE.COMMON };
    // Note: If you want to add a new tech tree you must also add it into the "TECH" constant in constants.lua


    public static void Init()
    {
        #region LIGHT

        new Recipe("campfire", new[] { new Ingredient("cutgrass", 3), new Ingredient("log", 2) },
            Constant.RECIPETABS.LIGHT, Constant.TECH.NONE, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "campfire_placer");
        new Recipe("firepit", new[] { new Ingredient("log", 2), new Ingredient("rocks", 12) },
            Constant.RECIPETABS.LIGHT, Constant.TECH.NONE, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "firepit_placer");
        new Recipe("chiminea",
            new[] { new Ingredient("limestone", 2), new Ingredient("sand", 2), new Ingredient("log", 2) },
            Constant.RECIPETABS.LIGHT, Constant.TECH.NONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "chiminea_placer");
        new Recipe("torch", new[] { new Ingredient("cutgrass", 2), new Ingredient("twigs", 2) },
            Constant.RECIPETABS.LIGHT, Constant.TECH.NONE);
        new Recipe("tarlamp", new[] { new Ingredient("seashell", 1), new Ingredient("tar", 1) },
            Constant.RECIPETABS.LIGHT, Constant.TECH.NONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });

        new Recipe("coldfire", new[] { new Ingredient("cutgrass", 3), new Ingredient("nitre", 2) },
            Constant.RECIPETABS.LIGHT, Constant.TECH.SCIENCE_ONE, new[]
            {
                Constant.RECIPE_GAME_TYPE.VANILLA,
                Constant.RECIPE_GAME_TYPE.ROG,
                Constant.RECIPE_GAME_TYPE.SHIPWRECKED
            }, "coldfire_placer");
        new Recipe("coldfirepit",
            new[] { new Ingredient("nitre", 2), new Ingredient("cutstone", 4), new Ingredient("transistor", 2) },
            Constant.RECIPETABS.LIGHT, Constant.TECH.SCIENCE_TWO, new[]
            {
                Constant.RECIPE_GAME_TYPE.VANILLA,
                Constant.RECIPE_GAME_TYPE.ROG,
                Constant.RECIPE_GAME_TYPE.SHIPWRECKED
            }, "coldfirepit_placer");
        new Recipe("obsidianfirepit", new[] { new Ingredient("log", 3), new Ingredient("obsidian", 8) },
            Constant.RECIPETABS.LIGHT, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "obsidianfirepit_placer");

        new Recipe("candlehat", new[] { new Ingredient("cork", 4), new Ingredient("iron", 2) },
            Constant.RECIPETABS.LIGHT, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("minerhat",
            new[] { new Ingredient("strawhat", 1), new Ingredient("goldnugget", 1), new Ingredient("fireflies", 1) },
            Constant.RECIPETABS.LIGHT, Constant.TECH.SCIENCE_TWO);

        new Recipe("bottlelantern",
            new[] { new Ingredient("messagebottleempty", 1), new Ingredient("bioluminescence", 2) },
            Constant.RECIPETABS.LIGHT, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("boat_torch", new[] { new Ingredient("twigs", 2), new Ingredient("torch", 1) },
            Constant.RECIPETABS.LIGHT, Constant.TECH.SCIENCE_ONE, new[]
            {
                Constant.RECIPE_GAME_TYPE.SHIPWRECKED, Constant.RECIPE_GAME_TYPE.PORKLAND
            });
        new Recipe("boat_lantern",
            new[]
            {
                new Ingredient("messagebottleempty", 1), new Ingredient("twigs", 2), new Ingredient("fireflies", 1)
            },
            Constant.RECIPETABS.LIGHT, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("sea_chiminea",
            new[] { new Ingredient("sand", 4), new Ingredient("tar", 6), new Ingredient("limestone", 6) },
            Constant.RECIPETABS.LIGHT, Constant.TECH.NONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "sea_chiminea_placer", null, null, null, true);

        #endregion

        #region ROG

        new Recipe("molehat",
            new[] { new Ingredient("mole", 2), new Ingredient("transistor", 2), new Ingredient("wormlight", 1) },
            Constant.RECIPETABS.LIGHT, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.ROG });
        new Recipe("bathat",
            new[] { new Ingredient("pigskin", 2), new Ingredient("batwing", 1), new Ingredient("compass", 1) },
            Constant.RECIPETABS.LIGHT, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("pumpkin_lantern", new[] { new Ingredient("pumpkin", 1), new Ingredient("fireflies", 1) },
            Constant.RECIPETABS.LIGHT, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.VANILLA });
        new Recipe("lantern",
            new[] { new Ingredient("twigs", 3), new Ingredient("rope", 2), new Ingredient("lightbulb", 2) },
            Constant.RECIPETABS.LIGHT, Constant.TECH.SCIENCE_TWO,
            new[] { Constant.RECIPE_GAME_TYPE.VANILLA, Constant.RECIPE_GAME_TYPE.PORKLAND });

        #endregion

        #region STRUCTURES

        new Recipe("treasurechest", new[] { new Ingredient("boards", 3) }, Constant.RECIPETABS.TOWN,
            Constant.TECH.SCIENCE_ONE,
            new[] { Constant.RECIPE_GAME_TYPE.COMMON }, "treasurechest_placer", 1);
        new Recipe("waterchest", new[] { new Ingredient("tar", 1), new Ingredient("boards", 4) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "waterchest_placer", 1, null, null, true);
        new Recipe("corkchest", new[] { new Ingredient("cork", 2), new Ingredient("rope", 1) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND },
            "corkchest_placer", 1);
        new Recipe("homesign", new[] { new Ingredient("boards", 1) }, Constant.RECIPETABS.TOWN,
            Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.COMMON }, "homesign_placer");
        new Recipe("minisign_item", new[] { new Ingredient("boards", 1) }, Constant.RECIPETABS.TOWN,
            Constant.TECH.SCIENCE_ONE, null, null, null, null, 4);

        new Recipe("fence_gate_item", new[] { new Ingredient("boards", 2), new Ingredient("rope", 1) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_TWO, null, null, null, null, 1);
        new Recipe("fence_item", new[] { new Ingredient("twigs", 3), new Ingredient("rope", 1) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_ONE, null, null, null, null, 6);

        new Recipe("wall_hay_item", new[] { new Ingredient("cutgrass", 4), new Ingredient("twigs", 2) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.COMMON }, null, null,
            null, 4);
        new Recipe("wall_wood_item", new[] { new Ingredient("boards", 2), new Ingredient("rope", 1) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.COMMON }, null, null,
            null, 8);
        new Recipe("wall_stone_item", new[] { new Ingredient("cutstone", 2) }, Constant.RECIPETABS.TOWN,
            Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.COMMON }, null, null, null, 6);
        new Recipe("wall_limestone_item", new[] { new Ingredient("limestone", 2) }, Constant.RECIPETABS.TOWN,
            Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED }, null, null, null, 6);
        new Recipe("wall_enforcedlimestone_item",
            new[] { new Ingredient("limestone", 2), new Ingredient("seaweed", 4) }, Constant.RECIPETABS.TOWN,
            Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED }, null, null, null, 6);
        new Recipe("pighouse",
            new[] { new Ingredient("boards", 4), new Ingredient("cutstone", 3), new Ingredient("pigskin", 4) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.VANILLA },
            "pighouse_placer");
        new Recipe("wildborehouse",
            new[] { new Ingredient("bamboo", 8), new Ingredient("palmleaf", 5), new Ingredient("pigskin", 4) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "wildborehouse_placer");

        new Recipe("ballphinhouse",
            new[] { new Ingredient("limestone", 4), new Ingredient("seaweed", 4), new Ingredient("dorsalfin", 2) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "ballphinhouse_placer", 100, null, null, true);
        new Recipe("primeapebarrel",
            new[] { new Ingredient("twigs", 10), new Ingredient("cave_banana", 3), new Ingredient("poop", 4) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "primeapebarrel_placer");
        new Recipe("dragoonden",
            new[] { new Ingredient("dragoonheart", 1), new Ingredient("rocks", 5), new Ingredient("obsidian", 4) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "dragoonden_placer");
        new Recipe("rabbithouse",
            new[] { new Ingredient("boards", 4), new Ingredient("carrot", 10), new Ingredient("manrabbit_tail", 4) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.VANILLA },
            "rabbithouse_placer");
        new Recipe("birdcage",
            new[] { new Ingredient("papyrus", 2), new Ingredient("goldnugget", 6), new Ingredient("seeds", 2) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "birdcage_placer");

        new Recipe("turf_road", new[] { new Ingredient("turf_rocky", 1), new Ingredient("boards", 1) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_TWO,
            new[] { Constant.RECIPE_GAME_TYPE.VANILLA, Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("turf_road", new[] { new Ingredient("turf_magmafield", 1), new Ingredient("boards", 1) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("turf_woodfloor", new[] { new Ingredient("boards", 1) }, Constant.RECIPETABS.TOWN,
            Constant.TECH.SCIENCE_TWO);

        new Recipe("turf_checkerfloor", new[] { new Ingredient("marble", 1) }, Constant.RECIPETABS.TOWN,
            Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.VANILLA, Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("turf_carpetfloor", new[] { new Ingredient("boards", 1), new Ingredient("beefalowool", 1) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_TWO,
            new[] { Constant.RECIPE_GAME_TYPE.VANILLA, Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("turf_snakeskinfloor", new[] { new Ingredient("snakeskin", 2), new Ingredient("fabric", 1) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });

        new Recipe("turf_beard_hair", new[] { new Ingredient("beardhair", 1), new Ingredient("cutgrass", 1) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });

        new Recipe("turf_lawn", new[] { new Ingredient("cutgrass", 2), new Ingredient("nitre", 1) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("turf_fields", new[] { new Ingredient("turf_rainforest", 1), new Ingredient("ash", 1) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("turf_deeprainforest_nocanopy",
            new[] { new Ingredient("bramble_bulb", 1), new Ingredient("cutgrass", 2), new Ingredient("ash", 1) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });

        new Recipe("pottedfern", new[] { new Ingredient("foliage", 2), new Ingredient("slurtle_shellpieces", 1) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.VANILLA },
            "pottedfern_placer", 0.9f);
        new Recipe("sandbagsmall_item", new[] { new Ingredient("fabric", 2), new Ingredient("sand", 3) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED }, null,
            null, null, 4);
        new Recipe("sand_castle",
            new[] { new Ingredient("sand", 4), new Ingredient("palmleaf", 2), new Ingredient("seashell", 3) },
            Constant.RECIPETABS.TOWN, Constant.TECH.NONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "sandcastle_placer");
        new Recipe("dragonflychest",
            new[] { new Ingredient("dragon_scales", 1), new Ingredient("boards", 4), new Ingredient("goldnugget", 10) },
            Constant.RECIPETABS.TOWN, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.ROG },
            "dragonflychest_placer", 1.5f);

        #endregion

        #region FARM

        new Recipe("mussel_stick",
            new[] { new Ingredient("bamboo", 2), new Ingredient("vine", 1), new Ingredient("seaweed", 1) },
            Constant.RECIPETABS.FARM, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("slow_farmplot",
            new[] { new Ingredient("cutgrass", 8), new Ingredient("poop", 4), new Ingredient("log", 4) },
            Constant.RECIPETABS.FARM, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "slow_farmplot_placer");
        new Recipe("fast_farmplot",
            new[] { new Ingredient("cutgrass", 10), new Ingredient("poop", 6), new Ingredient("rocks", 4) },
            Constant.RECIPETABS.FARM, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "fast_farmplot_placer");
        new Recipe("fertilizer",
            new[] { new Ingredient("poop", 3), new Ingredient("boneshard", 2), new Ingredient("log", 4) },
            Constant.RECIPETABS.FARM, Constant.TECH.SCIENCE_TWO);
        new Recipe("beebox",
            new[] { new Ingredient("boards", 2), new Ingredient("honeycomb", 1), new Ingredient("bee", 4) },
            Constant.RECIPETABS.FARM, Constant.TECH.SCIENCE_ONE,
            new[]
            {
                Constant.RECIPE_GAME_TYPE.VANILLA, Constant.RECIPE_GAME_TYPE.ROG, Constant.RECIPE_GAME_TYPE.SHIPWRECKED
            }, "beebox_placer");
        new Recipe("meatrack",
            new[] { new Ingredient("twigs", 3), new Ingredient("charcoal", 2), new Ingredient("rope", 3) },
            Constant.RECIPETABS.FARM, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "meatrack_placer");
        new Recipe("cookpot",
            new[] { new Ingredient("cutstone", 3), new Ingredient("charcoal", 6), new Ingredient("twigs", 6) },
            Constant.RECIPETABS.FARM, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "cookpot_placer");
        new Recipe("icebox",
            new[] { new Ingredient("goldnugget", 2), new Ingredient("gears", 1), new Ingredient("cutstone", 1) },
            Constant.RECIPETABS.FARM, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "icebox_placer", 1.5f);
        new Recipe("fish_farm",
            new[] { new Ingredient("coconut", 4), new Ingredient("rope", 2), new Ingredient("silk", 2) },
            Constant.RECIPETABS.FARM, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "fish_farm_placer", null, null, null, true);
        new Recipe("mussel_bed", new[] { new Ingredient("mussel", 1), new Ingredient("coral", 1) },
            Constant.RECIPETABS.FARM, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("sprinkler",
            new[] { new Ingredient("alloy", 2), new Ingredient("bluegem", 1), new Ingredient("ice", 6) },
            Constant.RECIPETABS.FARM, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND },
            "sprinkler_placer");

        #endregion

        #region SURVIVAL

        new Recipe("trap", new[] { new Ingredient("twigs", 2), new Ingredient("cutgrass", 6) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.NONE);
        new Recipe("birdtrap", new[] { new Ingredient("twigs", 3), new Ingredient("silk", 4) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_ONE);

        new Recipe("bugnet", new[] { new Ingredient("twigs", 4), new Ingredient("silk", 2), new Ingredient("rope", 1) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_ONE);
        new Recipe("bundlewrap", new[] { new Ingredient("waxpaper", 1), new Ingredient("rope", 1) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.LOST, new[] { Constant.RECIPE_GAME_TYPE.COMMON });
        new Recipe("fishingrod", new[] { new Ingredient("twigs", 2), new Ingredient("silk", 2) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_ONE);
        new Recipe("monkeyball",
            new[] { new Ingredient("snakeskin", 2), new Ingredient("cave_banana", 1), new Ingredient("rope", 2) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });

        new Recipe("grass_umbrella",
            new[] { new Ingredient("twigs", 4), new Ingredient("cutgrass", 3), new Ingredient("petals", 6) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.NONE, new[] { Constant.RECIPE_GAME_TYPE.ROG });
        new Recipe("palmleaf_umbrella",
            new[] { new Ingredient("twigs", 4), new Ingredient("palmleaf", 3), new Ingredient("petals", 6) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.NONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("umbrella",
            new[] { new Ingredient("twigs", 6), new Ingredient("pigskin", 1), new Ingredient("silk", 2) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_ONE);

        new Recipe("bugrepellent", new[] { new Ingredient("tuber_crop", 6), new Ingredient("venus_stalk", 1) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });

        new Recipe("bandage", new[] { new Ingredient("papyrus", 1), new Ingredient("honey", 2) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_TWO);
        new Recipe("healingsalve",
            new[] { new Ingredient("ash", 2), new Ingredient("rocks", 1), new Ingredient("spidergland", 1) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_ONE);
        new Recipe("antivenom",
            new[] { new Ingredient("venomgland", 1), new Ingredient("seaweed", 3), new Ingredient("coral", 2) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("compass", new[] { new Ingredient("goldnugget", 1), new Ingredient("papyrus", 1) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_ONE);
        new Recipe("heatrock",
            new[] { new Ingredient("rocks", 10), new Ingredient("pickaxe", 1), new Ingredient("flint", 3) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_TWO,
            new[]
            {
                Constant.RECIPE_GAME_TYPE.VANILLA, Constant.RECIPE_GAME_TYPE.ROG, Constant.RECIPE_GAME_TYPE.SHIPWRECKED
            });

        new Recipe("thatchpack", new[] { new Ingredient("palmleaf", 4) }, Constant.RECIPETABS.SURVIVAL,
            Constant.TECH.NONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("backpack", new[] { new Ingredient("cutgrass", 4), new Ingredient("twigs", 4) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_ONE);
        new Recipe("piggyback",
            new[] { new Ingredient("pigskin", 4), new Ingredient("silk", 6), new Ingredient("rope", 2) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_TWO);
        new Recipe("bedroll_straw", new[] { new Ingredient("cutgrass", 6), new Ingredient("rope", 1) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_ONE);
        new Recipe("bedroll_furry", new[] { new Ingredient("bedroll_straw", 1), new Ingredient("manrabbit_tail", 2) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.VANILLA });
        new Recipe("tent", new[] { new Ingredient("silk", 6), new Ingredient("twigs", 4), new Ingredient("rope", 3) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "tent_placer");
        new Recipe("siestahut",
            new[] { new Ingredient("silk", 2), new Ingredient("boards", 4), new Ingredient("rope", 3) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "siestahut_placer");
        new Recipe("palmleaf_hut",
            new[] { new Ingredient("palmleaf", 4), new Ingredient("bamboo", 4), new Ingredient("rope", 3) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "palmleaf_hut_placer");
        new Recipe("featherfan",
            new[] { new Ingredient("goose_feather", 5), new Ingredient("cutreeds", 2), new Ingredient("rope", 2) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_TWO,
            new[] { Constant.RECIPE_GAME_TYPE.ROG, Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("tropicalfan",
            new[] { new Ingredient("doydoyfeather", 5), new Ingredient("cutreeds", 2), new Ingredient("rope", 2) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("icepack",
            new[] { new Ingredient("bearger_fur", 1), new Ingredient("gears", 1), new Ingredient("transistor", 1) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.ROG });
        new Recipe("seasack",
            new[] { new Ingredient("seaweed", 5), new Ingredient("vine", 2), new Ingredient("shark_gills", 1) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("doydoynest",
            new[] { new Ingredient("twigs", 8), new Ingredient("doydoyfeather", 2), new Ingredient("poop", 4) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "doydoynest_placer");

        new Recipe("antler",
            new[] { new Ingredient("hippo_antler", 1), new Ingredient("bill_quill", 3), new Ingredient("flint", 1) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });

        #endregion

        #region TOOLS

        new Recipe("axe", new[] { new Ingredient("twigs", 1), new Ingredient("flint", 1) }, Constant.RECIPETABS.TOOLS,
            Constant.TECH.NONE);
        new Recipe("goldenaxe", new[] { new Ingredient("twigs", 4), new Ingredient("goldnugget", 2) },
            Constant.RECIPETABS.TOOLS, Constant.TECH.SCIENCE_TWO);

        new Recipe("machete", new[] { new Ingredient("twigs", 1), new Ingredient("flint", 3) },
            Constant.RECIPETABS.TOOLS, Constant.TECH.NONE);
        new Recipe("goldenmachete", new[] { new Ingredient("twigs", 4), new Ingredient("goldnugget", 2) },
            Constant.RECIPETABS.TOOLS, Constant.TECH.SCIENCE_TWO);

        new Recipe("pickaxe", new[] { new Ingredient("twigs", 2), new Ingredient("flint", 2) },
            Constant.RECIPETABS.TOOLS, Constant.TECH.NONE);
        new Recipe("goldenpickaxe", new[] { new Ingredient("twigs", 4), new Ingredient("goldnugget", 2) },
            Constant.RECIPETABS.TOOLS, Constant.TECH.SCIENCE_TWO);

        new Recipe("shears", new[] { new Ingredient("twigs", 2), new Ingredient("iron", 2) }, Constant.RECIPETABS.TOOLS,
            Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });

        new Recipe("shovel", new[] { new Ingredient("twigs", 2), new Ingredient("flint", 2) },
            Constant.RECIPETABS.TOOLS, Constant.TECH.SCIENCE_ONE);
        new Recipe("goldenshovel", new[] { new Ingredient("twigs", 4), new Ingredient("goldnugget", 2) },
            Constant.RECIPETABS.TOOLS, Constant.TECH.SCIENCE_TWO);

        new Recipe("hammer",
            new[] { new Ingredient("twigs", 3), new Ingredient("rocks", 3), new Ingredient("cutgrass", 6) },
            Constant.RECIPETABS.TOOLS, Constant.TECH.NONE);
        new Recipe("pitchfork", new[] { new Ingredient("twigs", 2), new Ingredient("flint", 2) },
            Constant.RECIPETABS.TOOLS, Constant.TECH.SCIENCE_ONE);
        new Recipe("razor", new[] { new Ingredient("twigs", 2), new Ingredient("flint", 2) }, Constant.RECIPETABS.TOOLS,
            Constant.TECH.SCIENCE_ONE);
        new Recipe("featherpencil",
            new[] { new Ingredient("twigs", 1), new Ingredient("charcoal", 1), new Ingredient("feather_crow", 1) },
            Constant.RECIPETABS.TOOLS, Constant.TECH.SCIENCE_ONE);

        new Recipe("saddlehorn",
            new[] { new Ingredient("twigs", 2), new Ingredient("boneshard", 2), new Ingredient("feather_crow", 1) },
            Constant.RECIPETABS.TOOLS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.VANILLA });
        new Recipe("saddle_basic",
            new[] { new Ingredient("beefalowool", 4), new Ingredient("pigskin", 4), new Ingredient("goldnugget", 4) },
            Constant.RECIPETABS.TOOLS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.VANILLA });
        new Recipe("saddle_war",
            new[] { new Ingredient("rabbit", 4), new Ingredient("steelwool", 4), new Ingredient("log", 10) },
            Constant.RECIPETABS.TOOLS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.VANILLA });
        new Recipe("saddle_race",
            new[] { new Ingredient("livinglog", 2), new Ingredient("silk", 4), new Ingredient("butterflywings", 68) },
            Constant.RECIPETABS.TOOLS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.VANILLA });
        new Recipe("brush",
            new[] { new Ingredient("walrus_tusk", 1), new Ingredient("steelwool", 1), new Ingredient("goldnugget", 2) },
            Constant.RECIPETABS.TOOLS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.VANILLA });
        new Recipe("saltlick", new[] { new Ingredient("boards", 2), new Ingredient("nitre", 4) },
            Constant.RECIPETABS.TOOLS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.VANILLA },
            "saltlick_placer");

        #endregion

        #region SCIENCE

        new Recipe("researchlab",
            new[] { new Ingredient("goldnugget", 1), new Ingredient("log", 4), new Ingredient("rocks", 4) },
            Constant.RECIPETABS.SCIENCE, Constant.TECH.NONE, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "researchlab_placer");
        new Recipe("researchlab2",
            new[] { new Ingredient("boards", 4), new Ingredient("cutstone", 2), new Ingredient("transistor", 2) },
            Constant.RECIPETABS.SCIENCE, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "researchlab2_placer");
        new Recipe("researchlab5",
            new[] { new Ingredient("limestone", 4), new Ingredient("sand", 2), new Ingredient("transistor", 2) },
            Constant.RECIPETABS.SCIENCE, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "researchlab5_placer", null, null, null, true);
        new Recipe("transistor", new[] { new Ingredient("goldnugget", 2), new Ingredient("cutstone", 1) },
            Constant.RECIPETABS.SCIENCE, Constant.TECH.SCIENCE_ONE);
        new Recipe("diviningrod",
            new[] { new Ingredient("twigs", 1), new Ingredient("nightmarefuel", 4), new Ingredient("gears", 1) },
            Constant.RECIPETABS.SCIENCE, Constant.TECH.SCIENCE_TWO);
        new Recipe("winterometer", new[] { new Ingredient("boards", 2), new Ingredient("goldnugget", 2) },
            Constant.RECIPETABS.SCIENCE, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "winterometer_placer");
        new Recipe("rainometer",
            new[] { new Ingredient("boards", 2), new Ingredient("goldnugget", 2), new Ingredient("rope", 2) },
            Constant.RECIPETABS.SCIENCE, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "rainometer_placer");
        new Recipe("gunpowder",
            new[] { new Ingredient("rottenegg", 1), new Ingredient("charcoal", 1), new Ingredient("nitre", 1) },
            Constant.RECIPETABS.SCIENCE, Constant.TECH.SCIENCE_TWO);
        new Recipe("lightning_rod", new[] { new Ingredient("goldnugget", 4), new Ingredient("cutstone", 1) },
            Constant.RECIPETABS.SCIENCE, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "lightning_rod_placer");
        new Recipe("firesuppressor",
            new[] { new Ingredient("gears", 2), new Ingredient("ice", 15), new Ingredient("transistor", 2) },
            Constant.RECIPETABS.SCIENCE, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "firesuppressor_placer");
        new Recipe("smelter",
            new[] { new Ingredient("cutstone", 6), new Ingredient("boards", 4), new Ingredient("redgem", 1) },
            Constant.RECIPETABS.SCIENCE, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND },
            "smetler_placer");
        new Recipe("basefan",
            new[] { new Ingredient("alloy", 2), new Ingredient("transistor", 2), new Ingredient("gears", 1) },
            Constant.RECIPETABS.SCIENCE, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND },
            "basefan_placer");
        new Recipe("icemaker",
            new[] { new Ingredient("heatrock", 1), new Ingredient("bamboo", 5), new Ingredient("transistor", 2) },
            Constant.RECIPETABS.SCIENCE, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "icemaker_placer");
        new Recipe("quackendrill",
            new[] { new Ingredient("quackenbeak", 1), new Ingredient("gears", 1), new Ingredient("transistor", 2) },
            Constant.RECIPETABS.SCIENCE, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });

        #endregion

        #region MAGIC

        new Recipe("hogusporkusator",
            new[]
            {
                new Ingredient("pigskin", 4), new Ingredient("boards", 4), new Ingredient("feather_robin_winter", 4)
            }, Constant.RECIPETABS.MAGIC, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND },
            "hogusporkusator_placer");
        new Recipe("piratihatitator",
            new[] { new Ingredient("parrot", 1), new Ingredient("boards", 4), new Ingredient("piratehat", 1) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "piratihatitator_placer");
        new Recipe("researchlab4",
            new[] { new Ingredient("rabbit", 4), new Ingredient("boards", 4), new Ingredient("tophat", 1) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.VANILLA },
            "researchlab4_placer");
        new Recipe("researchlab3",
            new[]
            {
                new Ingredient("livinglog", 3), new Ingredient("purplegem", 1), new Ingredient("nightmarefuel", 7)
            }, Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_TWO, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "researchlab3_placer");
        new Recipe("resurrectionstatue",
            new[] { new Ingredient("boards", 4), new Ingredient("cookedmeat", 4), new Ingredient("beardhair", 4) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_TWO, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "resurrectionstatue_placer");
        new Recipe("panflute",
            new[] { new Ingredient("cutreeds", 5), new Ingredient("mandrake", 1), new Ingredient("rope", 1) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_TWO);
        new Recipe("ox_flute",
            new[] { new Ingredient("ox_horn", 1), new Ingredient("nightmarefuel", 2), new Ingredient("rope", 1) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });

        new Recipe("bell", new[] { new Ingredient("glommerwings", 1), new Ingredient("glommerflower", 1) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.LOST,
            new[] { Constant.RECIPE_GAME_TYPE.ROG, Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("onemanband",
            new[] { new Ingredient("goldnugget", 2), new Ingredient("nightmarefuel", 4), new Ingredient("pigskin", 2) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_TWO);
        new Recipe("nightlight",
            new[] { new Ingredient("goldnugget", 8), new Ingredient("nightmarefuel", 2), new Ingredient("redgem", 1) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_TWO, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "nightlight_placer");
        new Recipe("armor_sanity", new[] { new Ingredient("nightmarefuel", 5), new Ingredient("papyrus", 3) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_THREE);

        new Recipe("armorvortexcloak",
            new[] { new Ingredient("ancient_remnant", 5), new Ingredient("armor_sanity", 1) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.LOST, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("antler_corrupted", new[] { new Ingredient("antler", 1), new Ingredient("ancient_remnant", 2) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_TWO, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("living_artifact", new[] { new Ingredient("infused_iron", 6), new Ingredient("waterdrop", 1) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.LOST, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });

        new Recipe("nightsword", new[] { new Ingredient("nightmarefuel", 5), new Ingredient("livinglog", 1) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_THREE);
        new Recipe("batbat",
            new[] { new Ingredient("batwing", 3), new Ingredient("livinglog", 2), new Ingredient("purplegem", 1) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_THREE,
            new[] { Constant.RECIPE_GAME_TYPE.VANILLA, Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("armorslurper",
            new[] { new Ingredient("slurper_pelt", 6), new Ingredient("rope", 2), new Ingredient("nightmarefuel", 2) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_THREE, new[] { Constant.RECIPE_GAME_TYPE.VANILLA });

        new Recipe("roottrunk_child",
            new[] { new Ingredient("bramble_bulb", 1), new Ingredient("venus_stalk", 2), new Ingredient("boards", 3) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_TWO, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "roottrunk_child_placer");

        new Recipe("amulet",
            new[] { new Ingredient("goldnugget", 3), new Ingredient("nightmarefuel", 2), new Ingredient("redgem", 1) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_TWO);
        new Recipe("blueamulet", new[] { new Ingredient("goldnugget", 3), new Ingredient("bluegem", 1) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_TWO);
        new Recipe("purpleamulet",
            new[]
            {
                new Ingredient("goldnugget", 6), new Ingredient("nightmarefuel", 4), new Ingredient("purplegem", 2)
            }, Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_THREE);
        new Recipe("firestaff",
            new[] { new Ingredient("nightmarefuel", 2), new Ingredient("spear", 1), new Ingredient("redgem", 1) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_THREE);
        new Recipe("icestaff", new[] { new Ingredient("spear", 1), new Ingredient("bluegem", 1) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_TWO);
        new Recipe("bonestaff",
            new[]
            {
                new Ingredient("pugalisk_skull", 1), new Ingredient("boneshard", 1), new Ingredient("nightmarefuel", 2)
            }, Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_THREE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("telestaff",
            new[]
            {
                new Ingredient("nightmarefuel", 4), new Ingredient("livinglog", 2), new Ingredient("purplegem", 2)
            }, Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_THREE, null);
        new Recipe("telebase",
            new[]
            {
                new Ingredient("nightmarefuel", 4), new Ingredient("livinglog", 4), new Ingredient("goldnugget", 8)
            }, Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_THREE, null, "telebase_placer");
        new Recipe("shipwrecked_entrance",
            new[]
            {
                new Ingredient("nightmarefuel", 4), new Ingredient("livinglog", 4),
                new Ingredient("sunken_boat_trinket_4", 1)
            }, Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_THREE,
            new[]
            {
                Constant.RECIPE_GAME_TYPE.VANILLA, Constant.RECIPE_GAME_TYPE.ROG, Constant.RECIPE_GAME_TYPE.SHIPWRECKED
            }, "shipwrecked_entrance_placer");
        // This is here so that the exit in the world can be hammered for goods.
        new Recipe("shipwrecked_exit",
            new[]
            {
                new Ingredient("nightmarefuel", 4), new Ingredient("livinglog", 4),
                new Ingredient("sunken_boat_trinket_4", 1)
            }, null, Constant.TECH.LOST, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "shipwrecked_entrance_placer");
        new Recipe("porkland_entrance",
            new[]
            {
                new Ingredient("nightmarefuel", 4), new Ingredient("livinglog", 4),
                new Ingredient("trinket_giftshop_4", 1)
            }, Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_THREE, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
            "porkland_entrance_placer");

        #endregion

        #region REFINE

        new Recipe("rope", new[] { new Ingredient("cutgrass", 3) }, Constant.RECIPETABS.REFINE,
            Constant.TECH.SCIENCE_ONE);
        new Recipe("boards", new[] { new Ingredient("log", 4) }, Constant.RECIPETABS.REFINE, Constant.TECH.SCIENCE_ONE);
        new Recipe("cutstone", new[] { new Ingredient("rocks", 3) }, Constant.RECIPETABS.REFINE,
            Constant.TECH.SCIENCE_ONE);
        new Recipe("clawpalmtree_sapling", new[] { new Ingredient("cork", 1), new Ingredient("poop", 1) },
            Constant.RECIPETABS.REFINE, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("papyrus", new[] { new Ingredient("cutreeds", 4) }, Constant.RECIPETABS.REFINE,
            Constant.TECH.SCIENCE_ONE);
        new Recipe("fabric", new[] { new Ingredient("bamboo", 3) }, Constant.RECIPETABS.REFINE,
            Constant.TECH.SCIENCE_ONE,
            new[]
            {
                Constant.RECIPE_GAME_TYPE.SHIPWRECKED, Constant.RECIPE_GAME_TYPE.VANILLA, Constant.RECIPE_GAME_TYPE.ROG
            });
        new Recipe("limestone", new[] { new Ingredient("coral", 3) }, Constant.RECIPETABS.REFINE,
            Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("nubbin", new[] { new Ingredient("limestone", 3), new Ingredient("corallarve", 1) },
            Constant.RECIPETABS.REFINE, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("goldnugget", new[] { new Ingredient("gold_dust", 6) }, Constant.RECIPETABS.REFINE,
            Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("goldnugget", new[] { new Ingredient("dubloon", 3) }, Constant.RECIPETABS.REFINE,
            Constant.TECH.SCIENCE_ONE);
        new Recipe("venomgland", new[] { new Ingredient("froglegs_poison", 3) }, Constant.RECIPETABS.REFINE,
            Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });

        new Recipe("ice", new[] { new Ingredient("hail_ice", 4) }, Constant.RECIPETABS.REFINE,
            Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("messagebottleempty", new[] { new Ingredient("sand", 3) }, Constant.RECIPETABS.REFINE,
            Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("nightmarefuel", new[] { new Ingredient("petals_evil", 4) }, Constant.RECIPETABS.REFINE,
            Constant.TECH.MAGIC_TWO);
        new Recipe("purplegem", new[] { new Ingredient("redgem", 1), new Ingredient("bluegem", 1) },
            Constant.RECIPETABS.REFINE, Constant.TECH.MAGIC_TWO);

        new Recipe("beeswax", new[] { new Ingredient("honeycomb", 1) }, Constant.RECIPETABS.REFINE,
            Constant.TECH.SCIENCE_ONE);
        new Recipe("waxpaper", new[] { new Ingredient("beeswax", 1), new Ingredient("papyrus", 1) },
            Constant.RECIPETABS.REFINE, Constant.TECH.SCIENCE_ONE);

        #endregion

        #region WAR

        new Recipe("spear", new[] { new Ingredient("twigs", 2), new Ingredient("rope", 1), new Ingredient("flint", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_ONE);
        new Recipe("halberd", new[] { new Ingredient("alloy", 1), new Ingredient("twigs", 2) }, Constant.RECIPETABS.WAR,
            Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("spear_poison", new[] { new Ingredient("spear", 1), new Ingredient("venomgland", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });

        new Recipe("cork_bat", new[] { new Ingredient("cork", 3), new Ingredient("boards", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });

        new Recipe("hambat",
            new[] { new Ingredient("pigskin", 1), new Ingredient("twigs", 2), new Ingredient("meat", 2) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_TWO);
        new Recipe("nightstick",
            new[]
            {
                new Ingredient("lightninggoathorn", 1), new Ingredient("transistor", 2), new Ingredient("nitre", 2)
            }, Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.ROG });
        new Recipe("armorgrass", new[] { new Ingredient("cutgrass", 10), new Ingredient("twigs", 2) },
            Constant.RECIPETABS.WAR, Constant.TECH.NONE, new[] { Constant.RECIPE_GAME_TYPE.VANILLA });
        new Recipe("armorwood", new[] { new Ingredient("log", 8), new Ingredient("rope", 2) }, Constant.RECIPETABS.WAR,
            Constant.TECH.SCIENCE_ONE);
        new Recipe("armorseashell",
            new[] { new Ingredient("seashell", 10), new Ingredient("seaweed", 2), new Ingredient("rope", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("armormarble", new[] { new Ingredient("marble", 6), new Ingredient("rope", 2) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.VANILLA });
        new Recipe("armorlimestone", new[] { new Ingredient("limestone", 3), new Ingredient("rope", 2) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("armorcactus", new[] { new Ingredient("needlespear", 3), new Ingredient("armorwood", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("armor_weevole", new[] { new Ingredient("weevole_carapace", 4), new Ingredient("chitin", 2) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });

        new Recipe("antmaskhat", new[] { new Ingredient("chitin", 5), new Ingredient("footballhat", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("antsuit", new[] { new Ingredient("chitin", 5), new Ingredient("armorwood", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });

        new Recipe("footballhat", new[] { new Ingredient("pigskin", 1), new Ingredient("rope", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_TWO);
        new Recipe("oxhat",
            new[] { new Ingredient("ox_horn", 1), new Ingredient("seashell", 4), new Ingredient("rope", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });

        new Recipe("metalplatehat", new[] { new Ingredient("alloy", 3), new Ingredient("cork", 3) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("armor_metalplate", new[] { new Ingredient("alloy", 3), new Ingredient("hammer", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });

        new Recipe("blowdart_pipe",
            new[]
            {
                new Ingredient("cutreeds", 2), new Ingredient("houndstooth", 1),
                new Ingredient("feather_robin_winter", 1)
            }, Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_ONE);
        new Recipe("blowdart_sleep",
            new[] { new Ingredient("cutreeds", 2), new Ingredient("stinger", 1), new Ingredient("feather_crow", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_ONE);
        new Recipe("blowdart_fire",
            new[] { new Ingredient("cutreeds", 2), new Ingredient("charcoal", 1), new Ingredient("feather_robin", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_ONE);
        new Recipe("blowdart_poison",
            new[] { new Ingredient("cutreeds", 2), new Ingredient("venomgland", 1), new Ingredient("feather_crow", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("boomerang",
            new[] { new Ingredient("boards", 1), new Ingredient("silk", 1), new Ingredient("charcoal", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_TWO);
        new Recipe("beemine",
            new[] { new Ingredient("boards", 1), new Ingredient("bee", 4), new Ingredient("flint", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_ONE);
        new Recipe("trap_teeth",
            new[] { new Ingredient("log", 1), new Ingredient("rope", 1), new Ingredient("houndstooth", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_TWO);
        new Recipe("coconade",
            new[] { new Ingredient("coconut", 1), new Ingredient("gunpowder", 1), new Ingredient("rope", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });

        new Recipe("spear_launcher", new[] { new Ingredient("bamboo", 3), new Ingredient("jellyfish", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });

        new Recipe("cutlass",
            new[] { new Ingredient("dead_swordfish", 1), new Ingredient("goldnugget", 2), new Ingredient("twigs", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("armordragonfly",
            new[] { new Ingredient("dragon_scales", 1), new Ingredient("armorwood", 1), new Ingredient("pigskin", 3) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.ROG });
        new Recipe("staff_tornado",
            new[]
            {
                new Ingredient("goose_feather", 10), new Ingredient("lightninggoathorn", 1), new Ingredient("gears", 1)
            }, Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.ROG });
        new Recipe("blunderbuss",
            new[] { new Ingredient("boards", 2), new Ingredient("oinc10", 1), new Ingredient("gears", 1) },
            Constant.RECIPETABS.WAR, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });

        #endregion

        #region DRESSUP

        new Recipe("sewing_kit",
            new[] { new Ingredient("log", 1), new Ingredient("silk", 8), new Ingredient("houndstooth", 2) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO);
        new Recipe("flowerhat", new[] { new Ingredient("petals", 12) }, Constant.RECIPETABS.DRESS, Constant.TECH.NONE);
        new Recipe("strawhat", new[] { new Ingredient("cutgrass", 12) }, Constant.RECIPETABS.DRESS, Constant.TECH.NONE);
        new Recipe("tophat", new[] { new Ingredient("silk", 6) }, Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_ONE);
        new Recipe("rainhat",
            new[] { new Ingredient("mole", 2), new Ingredient("strawhat", 1), new Ingredient("boneshard", 1) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.ROG }, null, null,
            null, null, true);

        new Recipe("earmuffshat", new[] { new Ingredient("rabbit", 2), new Ingredient("twigs", 1) },
            Constant.RECIPETABS.DRESS, Constant.TECH.NONE, new[] { Constant.RECIPE_GAME_TYPE.VANILLA });
        new Recipe("beefalohat", new[] { new Ingredient("beefalowool", 8), new Ingredient("horn", 1) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.VANILLA });
        new Recipe("winterhat", new[] { new Ingredient("beefalowool", 4), new Ingredient("silk", 4) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.VANILLA });
        new Recipe("catcoonhat", new[] { new Ingredient("coontail", 1), new Ingredient("silk", 4) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.ROG });

        new Recipe("gasmaskhat",
            new[] { new Ingredient("peagawkfeather", 4), new Ingredient("pigskin", 1), new Ingredient("fabric", 1) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND }, null,
            null, null, null, true);

        new Recipe("brainjellyhat",
            new[] { new Ingredient("coral_brain", 1), new Ingredient("jellyfish", 1), new Ingredient("rope", 2) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("watermelonhat", new[] { new Ingredient("watermelon", 1), new Ingredient("twigs", 3) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_ONE,
            new[]
            {
                Constant.RECIPE_GAME_TYPE.VANILLA, Constant.RECIPE_GAME_TYPE.ROG, Constant.RECIPE_GAME_TYPE.SHIPWRECKED
            });
        new Recipe("pithhat",
            new[] { new Ingredient("fabric", 1), new Ingredient("vine", 3), new Ingredient("cork", 6) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("thunderhat",
            new[] { new Ingredient("feather_thunder", 1), new Ingredient("goldnugget", 1), new Ingredient("cork", 2) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("shark_teethhat", new[] { new Ingredient("houndstooth", 5), new Ingredient("goldnugget", 1) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("icehat",
            new[] { new Ingredient("transistor", 2), new Ingredient("rope", 4), new Ingredient("ice", 10) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO,
            new[]
            {
                Constant.RECIPE_GAME_TYPE.VANILLA, Constant.RECIPE_GAME_TYPE.ROG, Constant.RECIPE_GAME_TYPE.SHIPWRECKED
            });
        new Recipe("beehat", new[] { new Ingredient("silk", 8), new Ingredient("rope", 1) }, Constant.RECIPETABS.DRESS,
            Constant.TECH.SCIENCE_TWO,
            new[]
            {
                Constant.RECIPE_GAME_TYPE.VANILLA, Constant.RECIPE_GAME_TYPE.ROG, Constant.RECIPE_GAME_TYPE.SHIPWRECKED
            });
        new Recipe("featherhat",
            new[]
            {
                new Ingredient("feather_crow", 3), new Ingredient("feather_robin", 2),
                new Ingredient("tentaclespots", 2)
            }, Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO);
        new Recipe("bushhat",
            new[] { new Ingredient("strawhat", 1), new Ingredient("rope", 1), new Ingredient("dug_berrybush", 1) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO);

        new Recipe("snakeskinhat",
            new[] { new Ingredient("snakeskin", 1), new Ingredient("strawhat", 1), new Ingredient("boneshard", 1) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO,
            new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED, Constant.RECIPE_GAME_TYPE.PORKLAND }, null, null, null, null,
            true);
        new Recipe("raincoat",
            new[] { new Ingredient("tentaclespots", 2), new Ingredient("rope", 2), new Ingredient("boneshard", 2) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.ROG }, null, null,
            null, null, true);

        new Recipe("armor_snakeskin",
            new[] { new Ingredient("snakeskin", 2), new Ingredient("vine", 2), new Ingredient("boneshard", 2) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.COMMON }, null,
            null, null, null, true);
        new Recipe("blubbersuit",
            new[] { new Ingredient("blubber", 4), new Ingredient("fabric", 2), new Ingredient("palmleaf", 2) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO,
            new[]
            {
                Constant.RECIPE_GAME_TYPE.VANILLA, Constant.RECIPE_GAME_TYPE.ROG, Constant.RECIPE_GAME_TYPE.SHIPWRECKED
            }, null, null, null, null, true);
        new Recipe("tarsuit",
            new[] { new Ingredient("tar", 4), new Ingredient("fabric", 2), new Ingredient("palmleaf", 2) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED }, null,
            null, null, null, true);
        new Recipe("sweatervest", new[] { new Ingredient("houndstooth", 8), new Ingredient("silk", 6) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.VANILLA });
        new Recipe("trunkvest_summer", new[] { new Ingredient("trunk_summer", 1), new Ingredient("silk", 8) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.VANILLA });
        new Recipe("trunkvest_winter",
            new[] { new Ingredient("trunk_winter", 1), new Ingredient("silk", 8), new Ingredient("beefalowool", 2) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.VANILLA });
        new Recipe("reflectivevest",
            new[] { new Ingredient("rope", 1), new Ingredient("feather_robin", 3), new Ingredient("pigskin", 2) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_ONE,
            new[]
            {
                Constant.RECIPE_GAME_TYPE.VANILLA, Constant.RECIPE_GAME_TYPE.ROG, Constant.RECIPE_GAME_TYPE.SHIPWRECKED
            });
        new Recipe("hawaiianshirt",
            new[] { new Ingredient("papyrus", 3), new Ingredient("silk", 3), new Ingredient("petals", 5) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("hawaiianshirt",
            new[] { new Ingredient("papyrus", 3), new Ingredient("silk", 3), new Ingredient("cactus_flower", 5) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.ROG });
        new Recipe("cane",
            new[] { new Ingredient("goldnugget", 2), new Ingredient("walrus_tusk", 1), new Ingredient("twigs", 4) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.VANILLA });
        new Recipe("beargervest",
            new[] { new Ingredient("bearger_fur", 1), new Ingredient("sweatervest", 1), new Ingredient("rope", 2) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.ROG });
        new Recipe("eyebrellahat",
            new[]
            {
                new Ingredient("deerclops_eyeball", 1), new Ingredient("twigs", 15), new Ingredient("boneshard", 4)
            }, Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.ROG });
        new Recipe("double_umbrellahat",
            new[] { new Ingredient("shark_gills", 2), new Ingredient("umbrella", 1), new Ingredient("strawhat", 1) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("armor_windbreaker",
            new[] { new Ingredient("blubber", 2), new Ingredient("fabric", 1), new Ingredient("rope", 1) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO,
            new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED }); // CHECK  THIS
        new Recipe("gashat",
            new[]
            {
                new Ingredient("messagebottleempty", 2), new Ingredient("coral", 3), new Ingredient("jellyfish", 1)
            }, Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("aerodynamichat",
            new[] { new Ingredient("shark_fin", 1), new Ingredient("vine", 2), new Ingredient("coconut", 1) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });

        #endregion

        #region ANCIENT

        new Recipe("thulecite", new[] { new Ingredient("thulecite_pieces", 6) }, Constant.RECIPETABS.ANCIENT,
            Constant.TECH.ANCIENT_TWO, mergedGameTypes.ToArray(), null, null, true);

        new Recipe("wall_ruins_item", new[] { new Ingredient("thulecite", 1) }, Constant.RECIPETABS.ANCIENT,
            Constant.TECH.ANCIENT_TWO, mergedGameTypes.ToArray(), null, null, true, 6);

        new Recipe("nightmare_timepiece", new[] { new Ingredient("thulecite", 2), new Ingredient("nightmarefuel", 2) },
            Constant.RECIPETABS.ANCIENT, Constant.TECH.ANCIENT_TWO, mergedGameTypes.ToArray(), null, null, true);

        new Recipe("orangeamulet",
            new[]
            {
                new Ingredient("thulecite", 2), new Ingredient("nightmarefuel", 3), new Ingredient("orangegem", 1)
            }, Constant.RECIPETABS.ANCIENT, Constant.TECH.ANCIENT_FOUR, mergedGameTypes.ToArray(), null, null, true);
        new Recipe("yellowamulet",
            new[]
            {
                new Ingredient("thulecite", 2), new Ingredient("nightmarefuel", 3), new Ingredient("yellowgem", 1)
            }, Constant.RECIPETABS.ANCIENT, Constant.TECH.ANCIENT_TWO, mergedGameTypes.ToArray(), null, null, true);
        new Recipe("greenamulet",
            new[] { new Ingredient("thulecite", 2), new Ingredient("nightmarefuel", 3), new Ingredient("greengem", 1) },
            Constant.RECIPETABS.ANCIENT, Constant.TECH.ANCIENT_TWO, mergedGameTypes.ToArray(), null, null, true);

        new Recipe("orangestaff",
            new[] { new Ingredient("nightmarefuel", 2), new Ingredient("cane", 1), new Ingredient("orangegem", 2) },
            Constant.RECIPETABS.ANCIENT, Constant.TECH.ANCIENT_FOUR, mergedGameTypes.ToArray(), null, null, true);
        new Recipe("yellowstaff",
            new[]
            {
                new Ingredient("nightmarefuel", 4), new Ingredient("livinglog", 2), new Ingredient("yellowgem", 2)
            }, Constant.RECIPETABS.ANCIENT, Constant.TECH.ANCIENT_TWO, mergedGameTypes.ToArray(), null, null, true);
        new Recipe("greenstaff",
            new[] { new Ingredient("nightmarefuel", 4), new Ingredient("livinglog", 2), new Ingredient("greengem", 2) },
            Constant.RECIPETABS.ANCIENT, Constant.TECH.ANCIENT_TWO, mergedGameTypes.ToArray(), null, null, true);

        new Recipe("multitool_axe_pickaxe",
            new[]
            {
                new Ingredient("goldenaxe", 1), new Ingredient("goldenpickaxe", 1), new Ingredient("thulecite", 2)
            }, Constant.RECIPETABS.ANCIENT, Constant.TECH.ANCIENT_FOUR, mergedGameTypes.ToArray(), null, null, true);

        new Recipe("ruinshat", new[] { new Ingredient("thulecite", 4), new Ingredient("nightmarefuel", 4) },
            Constant.RECIPETABS.ANCIENT, Constant.TECH.ANCIENT_FOUR, mergedGameTypes.ToArray(), null, null, true);
        new Recipe("armorruins", new[] { new Ingredient("thulecite", 6), new Ingredient("nightmarefuel", 4) },
            Constant.RECIPETABS.ANCIENT, Constant.TECH.ANCIENT_FOUR, mergedGameTypes.ToArray(), null, null, true);
        new Recipe("ruins_bat",
            new[]
            {
                new Ingredient("livinglog", 3), new Ingredient("thulecite", 4), new Ingredient("nightmarefuel", 4)
            }, Constant.RECIPETABS.ANCIENT, Constant.TECH.ANCIENT_FOUR, mergedGameTypes.ToArray(), null, null, true);
        new Recipe("eyeturret_item",
            new[]
            {
                new Ingredient("deerclops_eyeball", 1), new Ingredient("minotaurhorn", 1),
                new Ingredient("thulecite", 5)
            }, Constant.RECIPETABS.ANCIENT, Constant.TECH.ANCIENT_FOUR, mergedGameTypes.ToArray(), null, null, true);

        if (Main.ACCOMPLISHMENTS_ENABLED)
            new Recipe("accomplishment_shrine",
                new[] { new Ingredient("goldnugget", 10), new Ingredient("cutstone", 1), new Ingredient("gears", 6) },
                Constant.RECIPETABS.SCIENCE, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.COMMON },
                "accomplishment_shrine_placer");

        #endregion

        #region NAUTICAL

        new Recipe("lograft", new[] { new Ingredient("log", 6), new Ingredient("cutgrass", 4) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.NONE,
            new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED, Constant.RECIPE_GAME_TYPE.PORKLAND }, "lograft_placer", null,
            null, null, true, 4);
        new Recipe("raft", new[] { new Ingredient("bamboo", 4), new Ingredient("vine", 3) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.NONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "raft_placer", null, null, null, true, 4);
        new Recipe("rowboat", new[] { new Ingredient("boards", 3), new Ingredient("vine", 4) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_ONE,
            new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED, Constant.RECIPE_GAME_TYPE.PORKLAND }, "rowboat_placer", null,
            null, null, true, 4);
        new Recipe("corkboat", new[] { new Ingredient("cork", 4), new Ingredient("rope", 1) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND },
            "corkboat_placer", null, null, null, true, 4);
        new Recipe("cargoboat", new[] { new Ingredient("boards", 6), new Ingredient("rope", 3) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_TWO,
            new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED, Constant.RECIPE_GAME_TYPE.PORKLAND }, "cargoboat_placer",
            null, null, null, true, 4);
        new Recipe("armouredboat",
            new[] { new Ingredient("boards", 6), new Ingredient("rope", 3), new Ingredient("seashell", 10) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "armouredboat_placer", null, null, null, true, 4);
        new Recipe("encrustedboat",
            new[] { new Ingredient("boards", 6), new Ingredient("rope", 3), new Ingredient("limestone", 4) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "encrustedboat_placer", null, null, null, true, 4);
        new Recipe("boatrepairkit",
            new[] { new Ingredient("boards", 2), new Ingredient("stinger", 2), new Ingredient("rope", 2) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_ONE,
            new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED, Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("sail",
            new[] { new Ingredient("bamboo", 2), new Ingredient("vine", 2), new Ingredient("palmleaf", 4) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("clothsail",
            new[] { new Ingredient("bamboo", 2), new Ingredient("rope", 2), new Ingredient("fabric", 2) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("snakeskinsail",
            new[] { new Ingredient("log", 4), new Ingredient("rope", 2), new Ingredient("snakeskin", 2) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_TWO,
            new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED, Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("feathersail",
            new[] { new Ingredient("bamboo", 2), new Ingredient("rope", 2), new Ingredient("doydoyfeather", 4) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("ironwind",
            new[]
            {
                new Ingredient("turbine_blades", 1), new Ingredient("transistor", 1), new Ingredient("goldnugget", 2)
            }, Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_TWO,
            new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("boatcannon",
            new[] { new Ingredient("log", 5), new Ingredient("gunpowder", 4), new Ingredient("coconut", 6) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("seatrap",
            new[]
            {
                new Ingredient("palmleaf", 4), new Ingredient("messagebottleempty", 2), new Ingredient("jellyfish", 1)
            }, Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_ONE,
            new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("trawlnet", new[] { new Ingredient("rope", 3), new Ingredient("bamboo", 2) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("telescope",
            new[]
            {
                new Ingredient("messagebottleempty", 1), new Ingredient("pigskin", 1), new Ingredient("goldnugget", 1)
            }, Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_ONE,
            new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("supertelescope",
            new[] { new Ingredient("telescope", 1), new Ingredient("tigereye", 1), new Ingredient("goldnugget", 1) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("captainhat",
            new[] { new Ingredient("seaweed", 1), new Ingredient("boneshard", 1), new Ingredient("strawhat", 1) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("piratehat",
            new[] { new Ingredient("boneshard", 2), new Ingredient("rope", 1), new Ingredient("silk", 2) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("armor_lifejacket",
            new[] { new Ingredient("fabric", 2), new Ingredient("vine", 2), new Ingredient("messagebottleempty", 3) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });
        new Recipe("buoy",
            new[]
            {
                new Ingredient("messagebottleempty", 1), new Ingredient("bamboo", 4),
                new Ingredient("bioluminescence", 2)
            }, Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "buoy_placer", null, null, null, true);
        new Recipe("quackeringram",
            new[] { new Ingredient("quackenbeak", 1), new Ingredient("bamboo", 4), new Ingredient("rope", 4) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED });

        new Recipe("tar_extractor",
            new[] { new Ingredient("coconut", 2), new Ingredient("bamboo", 4), new Ingredient("limestone", 4) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "tar_extractor_placer", 0, null, null, true);
        new Recipe("sea_yard",
            new[] { new Ingredient("log", 4), new Ingredient("tar", 6), new Ingredient("limestone", 6) },
            Constant.RECIPETABS.NAUTICAL, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.SHIPWRECKED },
            "sea_yard_placer", null, null, null, true);

        new Recipe("obsidianmachete",
            new[] { new Ingredient("machete", 1), new Ingredient("obsidian", 3), new Ingredient("dragoonheart", 1) },
            Constant.RECIPETABS.OBSIDIAN, Constant.TECH.OBSIDIAN_TWO, mergedGameTypes.ToArray(), null, null, true);
        new Recipe("obsidianaxe",
            new[] { new Ingredient("axe", 1), new Ingredient("obsidian", 2), new Ingredient("dragoonheart", 1) },
            Constant.RECIPETABS.OBSIDIAN, Constant.TECH.OBSIDIAN_TWO, mergedGameTypes.ToArray(), null, null, true);
        new Recipe("spear_obsidian",
            new[] { new Ingredient("spear", 1), new Ingredient("obsidian", 3), new Ingredient("dragoonheart", 1) },
            Constant.RECIPETABS.OBSIDIAN, Constant.TECH.OBSIDIAN_TWO, mergedGameTypes.ToArray(), null, null, true);
        new Recipe("volcanostaff",
            new[] { new Ingredient("firestaff", 1), new Ingredient("obsidian", 4), new Ingredient("dragoonheart", 1) },
            Constant.RECIPETABS.OBSIDIAN, Constant.TECH.OBSIDIAN_TWO, mergedGameTypes.ToArray(), null, null, true);
        new Recipe("armorobsidian",
            new[] { new Ingredient("armorwood", 1), new Ingredient("obsidian", 5), new Ingredient("dragoonheart", 1) },
            Constant.RECIPETABS.OBSIDIAN, Constant.TECH.OBSIDIAN_TWO, mergedGameTypes.ToArray(), null, null, true);
        new Recipe("obsidiancoconade",
            new[] { new Ingredient("coconade", 3), new Ingredient("obsidian", 3), new Ingredient("dragoonheart", 1) },
            Constant.RECIPETABS.OBSIDIAN, Constant.TECH.OBSIDIAN_TWO, mergedGameTypes.ToArray(), null, null, true, 3);
        new Recipe("wind_conch",
            new[] { new Ingredient("obsidian", 4), new Ingredient("purplegem", 1), new Ingredient("magic_seal", 1) },
            Constant.RECIPETABS.OBSIDIAN, Constant.TECH.OBSIDIAN_TWO, mergedGameTypes.ToArray(), null, null, true);
        new Recipe("sail_stick",
            new[]
            {
                new Ingredient("obsidian", 2), new Ingredient("nightmarefuel", 3), new Ingredient("magic_seal", 1)
            }, Constant.RECIPETABS.OBSIDIAN, Constant.TECH.OBSIDIAN_TWO, mergedGameTypes.ToArray(), null, null, true);

        #endregion

        #region ARCHAEOLOGY

        new Recipe("disarming_kit", new[] { new Ingredient("iron", 2), new Ingredient("cutreeds", 2) },
            Constant.RECIPETABS.ARCHAEOLOGY, Constant.TECH.NONE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("ballpein_hammer", new[] { new Ingredient("iron", 2), new Ingredient("twigs", 1) },
            Constant.RECIPETABS.ARCHAEOLOGY, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("goldpan", new[] { new Ingredient("iron", 2), new Ingredient("hammer", 1) },
            Constant.RECIPETABS.ARCHAEOLOGY, Constant.TECH.SCIENCE_ONE, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });
        new Recipe("magnifying_glass",
            new[] { new Ingredient("iron", 1), new Ingredient("twigs", 1), new Ingredient("bluegem", 1) },
            Constant.RECIPETABS.ARCHAEOLOGY, Constant.TECH.SCIENCE_TWO, new[] { Constant.RECIPE_GAME_TYPE.PORKLAND });

        #endregion

        #region CITY

        new Recipe("turf_foundation", new[] { new Ingredient("cutstone", 1) }, Constant.RECIPETABS.CITY,
            Constant.TECH.CITY, cityRecipeGameTypes, null, null, true);
        new Recipe("turf_cobbleroad", new[] { new Ingredient("cutstone", 2), new Ingredient("boards", 1) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, null, null, true);
        new Recipe("city_lamp",
            new[] { new Ingredient("alloy", 1), new Ingredient("transistor", 1), new Ingredient("lantern", 1) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, "city_lamp_placer", null, true);

        new Recipe("pighouse_city",
            new[] { new Ingredient("boards", 4), new Ingredient("cutstone", 3), new Ingredient("pigskin", 4) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, "pighouse_city_placer", null, true);

        new Recipe("pig_shop_deli",
            new[] { new Ingredient("boards", 4), new Ingredient("honeyham", 1), new Ingredient("pigskin", 4) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, "pig_shop_deli_placer", null, true);
        new Recipe("pig_shop_general",
            new[] { new Ingredient("boards", 4), new Ingredient("axe", 3), new Ingredient("pigskin", 4) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, "pig_shop_general_placer", null, true);

        new Recipe("pig_shop_hoofspa",
            new[] { new Ingredient("boards", 4), new Ingredient("bandage", 3), new Ingredient("pigskin", 4) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, "pig_shop_hoofspa_placer", null, true);
        new Recipe("pig_shop_produce",
            new[] { new Ingredient("boards", 4), new Ingredient("eggplant", 3), new Ingredient("pigskin", 4) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, "pig_shop_produce_placer", null, true);

        new Recipe("pig_shop_florist",
            new[] { new Ingredient("boards", 4), new Ingredient("petals", 12), new Ingredient("pigskin", 4) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, "pig_shop_florist_placer", null, true);
        new Recipe("pig_shop_antiquities",
            new[] { new Ingredient("boards", 4), new Ingredient("ballpein_hammer", 3), new Ingredient("pigskin", 4) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, "pig_shop_antiquities_placer", null,
            true);

        new Recipe("pig_shop_arcane",
            new[] { new Ingredient("boards", 4), new Ingredient("nightmarefuel", 1), new Ingredient("pigskin", 4) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, "pig_shop_arcane_placer", null, true);
        new Recipe("pig_shop_weapons",
            new[] { new Ingredient("boards", 4), new Ingredient("spear", 3), new Ingredient("pigskin", 4) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, "pig_shop_weapons_placer", null, true);
        new Recipe("pig_shop_hatshop",
            new[] { new Ingredient("boards", 4), new Ingredient("tophat", 2), new Ingredient("pigskin", 4) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, "pig_shop_hatshop_placer", null, true);
        new Recipe("pig_shop_bank",
            new[] { new Ingredient("cutstone", 4), new Ingredient("oinc", 100), new Ingredient("pigskin", 4) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, "pig_shop_bank_placer", null, true);

        new Recipe("pig_shop_tinker", new[] { new Ingredient("magnifying_glass", 2), new Ingredient("pigskin", 4) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, "pig_shop_tinker_placer", null, true);

        new Recipe("pig_shop_cityhall_player",
            new[] { new Ingredient("boards", 4), new Ingredient("goldnugget", 4), new Ingredient("pigskin", 4) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, "pig_shop_cityhall_placer", null, true);

        new Recipe("pig_guard_tower",
            new[] { new Ingredient("cutstone", 3), new Ingredient("halberd", 1), new Ingredient("pigskin", 4) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, "pig_guard_tower_placer", null, true);

        new Recipe("securitycontract", new[] { new Ingredient("oinc", 10) }, Constant.RECIPETABS.CITY,
            Constant.TECH.CITY, cityRecipeGameTypes, null, null, true);

        new Recipe("playerhouse_city",
            new[] { new Ingredient("boards", 4), new Ingredient("cutstone", 3), new Ingredient("oinc", 30) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, "playerhouse_city_placer", null, true);

        new Recipe("hedge_block_item", new[] { new Ingredient("clippings", 9), new Ingredient("nitre", 1) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, null, null, true, 3);
        new Recipe("hedge_cone_item", new[] { new Ingredient("clippings", 9), new Ingredient("nitre", 1) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, null, null, true, 3);
        new Recipe("hedge_layered_item", new[] { new Ingredient("clippings", 9), new Ingredient("nitre", 1) },
            Constant.RECIPETABS.CITY, Constant.TECH.CITY, cityRecipeGameTypes, null, null, true, 3);

        new Recipe("lawnornament_1", new[] { new Ingredient("oinc", 10) }, Constant.RECIPETABS.CITY, Constant.TECH.CITY,
            cityRecipeGameTypes, "lawnornament_1_placer", 1, true);
        new Recipe("lawnornament_2", new[] { new Ingredient("oinc", 10) }, Constant.RECIPETABS.CITY, Constant.TECH.CITY,
            cityRecipeGameTypes, "lawnornament_2_placer", 1, true);
        new Recipe("lawnornament_3", new[] { new Ingredient("oinc", 10) }, Constant.RECIPETABS.CITY, Constant.TECH.CITY,
            cityRecipeGameTypes, "lawnornament_3_placer", 1, true);
        new Recipe("lawnornament_4", new[] { new Ingredient("oinc", 10) }, Constant.RECIPETABS.CITY, Constant.TECH.CITY,
            cityRecipeGameTypes, "lawnornament_4_placer", 1, true);
        new Recipe("lawnornament_5", new[] { new Ingredient("oinc", 10) }, Constant.RECIPETABS.CITY, Constant.TECH.CITY,
            cityRecipeGameTypes, "lawnornament_5_placer", 1, true);
        new Recipe("lawnornament_6", new[] { new Ingredient("oinc", 10) }, Constant.RECIPETABS.CITY, Constant.TECH.CITY,
            cityRecipeGameTypes, "lawnornament_6_placer", 1, true);
        new Recipe("lawnornament_7", new[] { new Ingredient("oinc", 10) }, Constant.RECIPETABS.CITY, Constant.TECH.CITY,
            cityRecipeGameTypes, "lawnornament_7_placer", 1, true);

        #endregion

        #region TINKER SHOP BLUEPRINT ITEMS

        new Recipe("eyebrellahat",
            new[]
            {
                new Ingredient("deerclops_eyeball", 1), new Ingredient("twigs", 15), new Ingredient("boneshard", 4)
            }, Constant.RECIPETABS.DRESS, Constant.TECH.LOST, cityRecipeGameTypes);
        new Recipe("cane",
            new[] { new Ingredient("goldnugget", 2), new Ingredient("walrus_tusk", 1), new Ingredient("twigs", 4) },
            Constant.RECIPETABS.DRESS, Constant.TECH.LOST, cityRecipeGameTypes);
        new Recipe("icepack",
            new[] { new Ingredient("bearger_fur", 1), new Ingredient("gears", 1), new Ingredient("transistor", 1) },
            Constant.RECIPETABS.SURVIVAL, Constant.TECH.LOST, cityRecipeGameTypes);
        new Recipe("staff_tornado",
            new[]
            {
                new Ingredient("goose_feather", 10), new Ingredient("lightninggoathorn", 1), new Ingredient("gears", 1)
            }, Constant.RECIPETABS.WAR, Constant.TECH.LOST, cityRecipeGameTypes);
        new Recipe("armordragonfly",
            new[] { new Ingredient("dragon_scales", 1), new Ingredient("armorwood", 1), new Ingredient("pigskin", 3) },
            Constant.RECIPETABS.WAR, Constant.TECH.LOST, cityRecipeGameTypes);
        new Recipe("dragonflychest",
            new[] { new Ingredient("dragon_scales", 1), new Ingredient("boards", 4), new Ingredient("goldnugget", 10) },
            Constant.RECIPETABS.TOWN, Constant.TECH.LOST, cityRecipeGameTypes, "dragonflychest_placer", 1.5f);
        new Recipe("molehat",
            new[] { new Ingredient("mole", 2), new Ingredient("transistor", 2), new Ingredient("wormlight", 1) },
            Constant.RECIPETABS.LIGHT, Constant.TECH.SCIENCE_TWO, cityRecipeGameTypes);
        new Recipe("beargervest",
            new[] { new Ingredient("bearger_fur", 1), new Ingredient("sweatervest", 1), new Ingredient("rope", 2) },
            Constant.RECIPETABS.DRESS, Constant.TECH.SCIENCE_TWO, cityRecipeGameTypes);
        new Recipe("ox_flute",
            new[] { new Ingredient("ox_horn", 1), new Ingredient("nightmarefuel", 2), new Ingredient("rope", 1) },
            Constant.RECIPETABS.MAGIC, Constant.TECH.MAGIC_TWO, cityRecipeGameTypes);

        #endregion

        #region HOME

        new Recipe("player_house_cottage_craft", new[] { new Ingredient("oinc", 10) },
            Constant.RENO_RECIPETABS.HOME_KITS, Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("player_house_tudor_craft", new[] { new Ingredient("oinc", 10) }, Constant.RENO_RECIPETABS.HOME_KITS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("player_house_gothic_craft", new[] { new Ingredient("oinc", 10) },
            Constant.RENO_RECIPETABS.HOME_KITS, Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("player_house_brick_craft", new[] { new Ingredient("oinc", 10) }, Constant.RENO_RECIPETABS.HOME_KITS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("player_house_turret_craft", new[] { new Ingredient("oinc", 10) },
            Constant.RENO_RECIPETABS.HOME_KITS, Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("player_house_villa_craft", new[] { new Ingredient("oinc", 30) }, Constant.RENO_RECIPETABS.HOME_KITS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("player_house_manor_craft", new[] { new Ingredient("oinc", 30) }, Constant.RENO_RECIPETABS.HOME_KITS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);

        new Recipe("deco_chair_classic", new[] { new Ingredient("oinc", 2) }, Constant.RENO_RECIPETABS.CHAIRS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "chair_classic_placer", null, true, null, null, null, true,
            false, "reno_chair_classic");
        new Recipe("deco_chair_corner", new[] { new Ingredient("oinc", 2) }, Constant.RENO_RECIPETABS.CHAIRS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "chair_corner_placer", null, true, null, null, null, true,
            true, "reno_chair_corner");
        new Recipe("deco_chair_bench", new[] { new Ingredient("oinc", 2) }, Constant.RENO_RECIPETABS.CHAIRS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "chair_bench_placer", null, true, null, null, null, true, true,
            "reno_chair_bench");
        new Recipe("deco_chair_horned", new[] { new Ingredient("oinc", 2) }, Constant.RENO_RECIPETABS.CHAIRS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "chair_horned_placer", null, true, null, null, null, true,
            true, "reno_chair_horned");
        new Recipe("deco_chair_footrest", new[] { new Ingredient("oinc", 2) }, Constant.RENO_RECIPETABS.CHAIRS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "chair_footrest_placer", null, true, null, null, null, true,
            true, "reno_chair_footrest");
        new Recipe("deco_chair_lounge", new[] { new Ingredient("oinc", 2) }, Constant.RENO_RECIPETABS.CHAIRS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "chair_lounge_placer", null, true, null, null, null, true,
            true, "reno_chair_lounge");
        new Recipe("deco_chair_massager", new[] { new Ingredient("oinc", 2) }, Constant.RENO_RECIPETABS.CHAIRS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "chair_massager_placer", null, true, null, null, null, true,
            true, "reno_chair_massager");
        new Recipe("deco_chair_stuffed", new[] { new Ingredient("oinc", 2) }, Constant.RENO_RECIPETABS.CHAIRS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "chair_stuffed_placer", null, true, null, null, null, true,
            true, "reno_chair_stuffed");
        new Recipe("deco_chair_rocking", new[] { new Ingredient("oinc", 2) }, Constant.RENO_RECIPETABS.CHAIRS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "chair_rocking_placer", null, true, null, null, null, true,
            true, "reno_chair_rocking");
        new Recipe("deco_chair_ottoman", new[] { new Ingredient("oinc", 2) }, Constant.RENO_RECIPETABS.CHAIRS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "chair_ottoman_placer", null, true, null, null, null, true,
            true, "reno_chair_ottoman");

        new Recipe("shelves_wood", new[] { new Ingredient("oinc", 2) }, Constant.RENO_RECIPETABS.SHELVES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "shelves_wood_placer", null, true, null, null, null, true,
            false, "reno_shelves_wood", true);
        new Recipe("shelves_basic", new[] { new Ingredient("oinc", 2) }, Constant.RENO_RECIPETABS.SHELVES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "shelves_basic_placer", null, true, null, null, null, true,
            false, "reno_shelves_basic", true);
        new Recipe("shelves_cinderblocks", new[] { new Ingredient("oinc", 1) }, Constant.RENO_RECIPETABS.SHELVES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "shelves_cinderblocks_placer", null, true, null, null, null,
            true, false, "reno_shelves_cinderblocks", true);
        new Recipe("shelves_marble", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.SHELVES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "shelves_marble_placer", null, true, null, null, null, true,
            false, "reno_shelves_marble", true);
        new Recipe("shelves_glass", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.SHELVES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "shelves_glass_placer", null, true, null, null, null, true,
            false, "reno_shelves_glass", true);
        new Recipe("shelves_ladder", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.SHELVES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "shelves_ladder_placer", null, true, null, null, null, true,
            false, "reno_shelves_ladder", true);
        new Recipe("shelves_hutch", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.SHELVES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "shelves_hutch_placer", null, true, null, null, null, true,
            false, "reno_shelves_hutch", true);
        new Recipe("shelves_industrial", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.SHELVES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "shelves_industrial_placer", null, true, null, null, null,
            true, false, "reno_shelves_industrial", true);
        new Recipe("shelves_adjustable", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.SHELVES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "shelves_adjustable_placer", null, true, null, null, null,
            true, false, "reno_shelves_adjustable", true);
        new Recipe("shelves_midcentury", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.SHELVES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "shelves_midcentury_placer", null, true, null, null, null,
            true, false, "reno_shelves_midcentury", true);
        new Recipe("shelves_wallmount", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.SHELVES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "shelves_wallmount_placer", null, true, null, null, null, true,
            false, "reno_shelves_wallmount", true);
        new Recipe("shelves_aframe", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.SHELVES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "shelves_aframe_placer", null, true, null, null, null, true,
            false, "reno_shelves_aframe", true);
        new Recipe("shelves_crates", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.SHELVES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "shelves_crates_placer", null, true, null, null, null, true,
            false, "reno_shelves_crates", true);
        new Recipe("shelves_fridge", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.SHELVES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "shelves_fridge_placer", null, true, null, null, null, true,
            false, "reno_shelves_fridge", true);
        new Recipe("shelves_floating", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.SHELVES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "shelves_floating_placer", null, true, null, null, null, true,
            false, "reno_shelves_floating", true);
        new Recipe("shelves_pipe", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.SHELVES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "shelves_pipe_placer", null, true, null, null, null, true,
            false, "reno_shelves_pipe", true);
        new Recipe("shelves_hattree", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.SHELVES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "shelves_hattree_placer", null, true, null, null, null, true,
            false, "reno_shelves_hattree", true);
        new Recipe("shelves_pallet", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.SHELVES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "shelves_pallet_placer", null, true, null, null, null, true,
            false, "reno_shelves_pallet", true);

        new Recipe("rug_round", new[] { new Ingredient("oinc", 2) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_round_placer", null, true, null, null, null, true, true,
            "reno_rug_round");
        new Recipe("rug_square", new[] { new Ingredient("oinc", 2) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_square_placer", null, true, null, null, null, true, true,
            "reno_rug_square");
        new Recipe("rug_oval", new[] { new Ingredient("oinc", 2) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_oval_placer", null, true, null, null, null, true, true,
            "reno_rug_oval");
        new Recipe("rug_rectangle", new[] { new Ingredient("oinc", 3) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_rectangle_placer", null, true, null, null, null, true,
            true, "reno_rug_rectangle");
        new Recipe("rug_fur", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_fur_placer", null, true, null, null, null, true, true,
            "reno_rug_fur");
        new Recipe("rug_hedgehog", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_hedgehog_placer", null, true, null, null, null, true,
            true, "reno_rug_hedgehog");
        new Recipe("rug_porcupuss", new[] { new Ingredient("oinc", 10) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_porcupuss_placer", null, true, null, null, null, true,
            true, "reno_rug_porcupuss");
        new Recipe("rug_hoofprint", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_hoofprint_placer", null, true, null, null, null, true,
            true, "reno_rug_hoofprint");
        new Recipe("rug_octagon", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_octagon_placer", null, true, null, null, null, true, true,
            "reno_rug_octagon");
        new Recipe("rug_swirl", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_swirl_placer", null, true, null, null, null, true, true,
            "reno_rug_swirl");
        new Recipe("rug_catcoon", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_catcoon_placer", null, true, null, null, null, true, true,
            "reno_rug_catcoon");
        new Recipe("rug_rubbermat", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_rubbermat_placer", null, true, null, null, null, true,
            true, "reno_rug_rubbermat");
        new Recipe("rug_web", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_web_placer", null, true, null, null, null, true, true,
            "reno_rug_web");
        new Recipe("rug_metal", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_metal_placer", null, true, null, null, null, true, true,
            "reno_rug_metal");
        new Recipe("rug_wormhole", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_wormhole_placer", null, true, null, null, null, true,
            true, "reno_rug_wormhole");
        new Recipe("rug_braid", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_braid_placer", null, true, null, null, null, true, true,
            "reno_rug_braid");
        new Recipe("rug_beard", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_beard_placer", null, true, null, null, null, true, true,
            "reno_rug_beard");
        new Recipe("rug_nailbed", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_nailbed_placer", null, true, null, null, null, true, true,
            "reno_rug_nailbed");
        new Recipe("rug_crime", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_crime_placer", null, true, null, null, null, true, true,
            "reno_rug_crime");
        new Recipe("rug_tiles", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.RUGS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "rug_tiles_placer", null, true, null, null, null, true, true,
            "reno_rug_tiles");

        new Recipe("deco_chaise", new[] { new Ingredient("oinc", 15) }, Constant.RENO_RECIPETABS.CHAIRS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_chaise_placer", null, true, null, null, null, true, true,
            "reno_chair_chaise");

        new Recipe("deco_lamp_fringe", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_fringe_placer", null, true, null, null, null, true,
            false, "reno_lamp_fringe");
        new Recipe("deco_lamp_stainglass", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_stainglass_placer", null, true, null, null, null,
            true, false, "reno_lamp_stainglass");
        new Recipe("deco_lamp_downbridge", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_downbridge_placer", null, true, null, null, null,
            true, true, "reno_lamp_downbridge");
        new Recipe("deco_lamp_2embroidered", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_2embroidered_placer", null, true, null, null, null,
            true, true, "reno_lamp_2embroidered");
        new Recipe("deco_lamp_ceramic", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_ceramic_placer", null, true, null, null, null, true,
            false, "reno_lamp_ceramic");
        new Recipe("deco_lamp_glass", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_glass_placer", null, true, null, null, null, true,
            false, "reno_lamp_glass");
        new Recipe("deco_lamp_2fringes", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_2fringes_placer", null, true, null, null, null,
            true, false, "reno_lamp_2fringes");
        new Recipe("deco_lamp_candelabra", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_candelabra_placer", null, true, null, null, null,
            true, false, "reno_lamp_candelabra");
        new Recipe("deco_lamp_elizabethan", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_elizabethan_placer", null, true, null, null, null,
            true, false, "reno_lamp_elizabethan");
        new Recipe("deco_lamp_gothic", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_gothic_placer", null, true, null, null, null, true,
            false, "reno_lamp_gothic");
        new Recipe("deco_lamp_orb", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_orb_placer", null, true, null, null, null, true,
            false, "reno_lamp_orb");
        new Recipe("deco_lamp_bellshade", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_bellshade_placer", null, true, null, null, null,
            true, true, "reno_lamp_bellshade");
        new Recipe("deco_lamp_crystals", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_crystals_placer", null, true, null, null, null,
            true, true, "reno_lamp_crystals");
        new Recipe("deco_lamp_upturn", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_upturn_placer", null, true, null, null, null, true,
            false, "reno_lamp_upturn");
        new Recipe("deco_lamp_2upturns", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_2upturns_placer", null, true, null, null, null,
            true, true, "reno_lamp_2upturns");
        new Recipe("deco_lamp_spool", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_spool_placer", null, true, null, null, null, true,
            false, "reno_lamp_spool");
        new Recipe("deco_lamp_edison", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_edison_placer", null, true, null, null, null, true,
            false, "reno_lamp_edison");
        new Recipe("deco_lamp_adjustable", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_adjustable_placer", null, true, null, null, null,
            true, true, "reno_lamp_adjustable");
        new Recipe("deco_lamp_rightangles", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_rightangles_placer", null, true, null, null, null,
            true, true, "reno_lamp_rightangles");
        new Recipe("deco_lamp_hoofspa", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_lamp_hoofspa_placer", null, true, null, null, null, true,
            true, "reno_lamp_hoofspa");

        new Recipe("deco_plantholder_basic", new[] { new Ingredient("oinc", 6) },
            Constant.RENO_RECIPETABS.PLANT_HOLDERS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_plantholder_basic_placer", null, true, null, null, null, true, true, "reno_plantholder_basic");
        new Recipe("deco_plantholder_wip", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.PLANT_HOLDERS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_plantholder_wip_placer", null, true, null, null, null,
            true, true, "reno_plantholder_wip");
        new Recipe("deco_plantholder_marble", new[] { new Ingredient("oinc", 6) },
            Constant.RENO_RECIPETABS.PLANT_HOLDERS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_plantholder_marble_placer", null, true, null, null, null, true, true, "reno_plantholder_marble");
        new Recipe("deco_plantholder_bonsai", new[] { new Ingredient("oinc", 6) },
            Constant.RENO_RECIPETABS.PLANT_HOLDERS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_plantholder_bonsai_placer", null, true, null, null, null, true, true, "reno_plantholder_bonsai");
        new Recipe("deco_plantholder_dishgarden", new[] { new Ingredient("oinc", 6) },
            Constant.RENO_RECIPETABS.PLANT_HOLDERS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_plantholder_dishgarden_placer", null, true, null, null, null, true, true,
            "reno_plantholder_dishgarden");
        new Recipe("deco_plantholder_philodendron", new[] { new Ingredient("oinc", 6) },
            Constant.RENO_RECIPETABS.PLANT_HOLDERS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_plantholder_philodendron_placer", null, true, null, null, null, true, true,
            "reno_plantholder_philodendron");
        new Recipe("deco_plantholder_orchid", new[] { new Ingredient("oinc", 6) },
            Constant.RENO_RECIPETABS.PLANT_HOLDERS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_plantholder_orchid_placer", null, true, null, null, null, true, true, "reno_plantholder_orchid");
        new Recipe("deco_plantholder_draceana", new[] { new Ingredient("oinc", 6) },
            Constant.RENO_RECIPETABS.PLANT_HOLDERS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_plantholder_draceana_placer", null, true, null, null, null, true, true, "reno_plantholder_draceana");
        new Recipe("deco_plantholder_xerographica", new[] { new Ingredient("oinc", 6) },
            Constant.RENO_RECIPETABS.PLANT_HOLDERS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_plantholder_xerographica_placer", null, true, null, null, null, true, true,
            "reno_plantholder_xerographica");
        new Recipe("deco_plantholder_birdcage", new[] { new Ingredient("oinc", 6) },
            Constant.RENO_RECIPETABS.PLANT_HOLDERS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_plantholder_birdcage_placer", null, true, null, null, null, true, true, "reno_plantholder_birdcage");
        new Recipe("deco_plantholder_palm", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.PLANT_HOLDERS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_plantholder_palm_placer", null, true, null, null, null,
            true, true, "reno_plantholder_palm");
        new Recipe("deco_plantholder_zz", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.PLANT_HOLDERS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_plantholder_zz_placer", null, true, null, null, null,
            true, true, "reno_plantholder_zz");
        new Recipe("deco_plantholder_fernstand", new[] { new Ingredient("oinc", 6) },
            Constant.RENO_RECIPETABS.PLANT_HOLDERS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_plantholder_fernstand_placer", null, true, null, null, null, true, true,
            "reno_plantholder_fernstand");
        new Recipe("deco_plantholder_fern", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.PLANT_HOLDERS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_plantholder_fern_placer", null, true, null, null, null,
            true, true, "reno_plantholder_fern");
        new Recipe("deco_plantholder_terrarium", new[] { new Ingredient("oinc", 6) },
            Constant.RENO_RECIPETABS.PLANT_HOLDERS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_plantholder_terrarium_placer", null, true, null, null, null, true, true,
            "reno_plantholder_terrarium");
        new Recipe("deco_plantholder_plantpet", new[] { new Ingredient("oinc", 6) },
            Constant.RENO_RECIPETABS.PLANT_HOLDERS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_plantholder_plantpet_placer", null, true, null, null, null, true, true, "reno_plantholder_plantpet");
        new Recipe("deco_plantholder_traps", new[] { new Ingredient("oinc", 6) },
            Constant.RENO_RECIPETABS.PLANT_HOLDERS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_plantholder_traps_placer", null, true, null, null, null, true, true, "reno_plantholder_traps");
        new Recipe("deco_plantholder_pitchers", new[] { new Ingredient("oinc", 6) },
            Constant.RENO_RECIPETABS.PLANT_HOLDERS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_plantholder_pitchers_placer", null, true, null, null, null, true, true, "reno_plantholder_pitchers");


        new Recipe("deco_plantholder_winterfeasttreeofsadness",
            new[] { new Ingredient("oinc", 2), new Ingredient("twigs", 1) },
            new Constant.RecipeTab { str = cityRecipeGameTypes[0] }, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_plantholder_winterfeasttreeofsadness_placer", null, true, null, null, null, true, true,
            "reno_plantholder_winterfeasttreeofsadness");
        new Recipe("deco_plantholder_winterfeasttree", new[] { new Ingredient("oinc", 50) },
            new Constant.RecipeTab { str = cityRecipeGameTypes[0] },
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_plantholder_winterfeasttree_placer", null, true, null,
            null,
            null, true, false, "reno_lamp_festivetree");

        new Recipe("deco_table_round", new[] { new Ingredient("oinc", 2) }, Constant.RENO_RECIPETABS.TABLES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_table_round_placer", null, true, null, null, null, true,
            true, "reno_table_round");
        new Recipe("deco_table_banker", new[] { new Ingredient("oinc", 4) }, Constant.RENO_RECIPETABS.TABLES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_table_banker_placer", null, true, null, null, null, true,
            false, "reno_table_banker");
        new Recipe("deco_table_diy", new[] { new Ingredient("oinc", 3) }, Constant.RENO_RECIPETABS.TABLES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_table_diy_placer", null, true, null, null, null, true,
            true, "reno_table_diy");
        new Recipe("deco_table_raw", new[] { new Ingredient("oinc", 1) }, Constant.RENO_RECIPETABS.TABLES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_table_raw_placer", null, true, null, null, null, true,
            false, "reno_table_raw");
        new Recipe("deco_table_crate", new[] { new Ingredient("oinc", 1) }, Constant.RENO_RECIPETABS.TABLES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_table_crate_placer", null, true, null, null, null, true,
            true, "reno_table_crate");
        new Recipe("deco_table_chess", new[] { new Ingredient("oinc", 1) }, Constant.RENO_RECIPETABS.TABLES,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_table_chess_placer", null, true, null, null, null, true,
            false, "reno_table_chess");

        new Recipe("deco_wallornament_photo", new[] { new Ingredient("oinc", 2) }, Constant.RENO_RECIPETABS.ORNAMENTS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_wallornament_photo_placer", null, true, null, null, null,
            true, false, "reno_wallornament_photo", true);
        new Recipe("deco_wallornament_embroidery_hoop", new[] { new Ingredient("oinc", 3) },
            Constant.RENO_RECIPETABS.ORNAMENTS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_wallornament_embroidery_hoop_placer", null, true, null, null, null, true, false,
            "reno_wallornament_embroidery_hoop", true);
        new Recipe("deco_wallornament_mosaic", new[] { new Ingredient("oinc", 4) }, Constant.RENO_RECIPETABS.ORNAMENTS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_wallornament_mosaic_placer", null, true, null, null,
            null, true, false, "reno_wallornament_mosaic", true);
        new Recipe("deco_wallornament_wreath", new[] { new Ingredient("oinc", 4) }, Constant.RENO_RECIPETABS.ORNAMENTS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_wallornament_wreath_placer", null, true, null, null,
            null, true, false, "reno_wallornament_wreath", true);
        new Recipe("deco_wallornament_axe", new[] { new Ingredient("oinc", 5), new Ingredient("axe", 1) },
            Constant.RENO_RECIPETABS.ORNAMENTS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_wallornament_axe_placer", null, true, null, null, null, true, false, "reno_wallornament_axe", true);
        new Recipe("deco_wallornament_hunt", new[] { new Ingredient("oinc", 5), new Ingredient("spear", 1) },
            Constant.RENO_RECIPETABS.ORNAMENTS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_wallornament_hunt_placer", null, true, null, null, null, true, false, "reno_wallornament_hunt", true);
        new Recipe("deco_wallornament_periodic_table", new[] { new Ingredient("oinc", 5) },
            Constant.RENO_RECIPETABS.ORNAMENTS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_wallornament_periodic_table_placer", null, true, null, null, null, true, false,
            "reno_wallornament_periodic_table", true);
        new Recipe("deco_wallornament_gears_art", new[] { new Ingredient("oinc", 8) },
            Constant.RENO_RECIPETABS.ORNAMENTS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_wallornament_gears_art_placer", null, true, null, null, null, true, false,
            "reno_wallornament_gears_art", true);
        new Recipe("deco_wallornament_cape", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.ORNAMENTS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_wallornament_cape_placer", null, true, null, null, null,
            true, false, "reno_wallornament_cape", true);
        new Recipe("deco_wallornament_no_smoking", new[] { new Ingredient("oinc", 3) },
            Constant.RENO_RECIPETABS.ORNAMENTS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_wallornament_no_smoking_placer", null, true, null, null, null, true, false,
            "reno_wallornament_no_smoking", true);
        new Recipe("deco_wallornament_black_cat", new[] { new Ingredient("oinc", 5) },
            Constant.RENO_RECIPETABS.ORNAMENTS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_wallornament_black_cat_placer", null, true, null, null, null, true, false,
            "reno_wallornament_black_cat", true);
        new Recipe("deco_antiquities_wallfish", new[] { new Ingredient("oinc", 2), new Ingredient("fish", 1) },
            Constant.RENO_RECIPETABS.ORNAMENTS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_antiquities_wallfish_placer", null, true, null, null, null, true, false, "reno_antiquities_wallfish",
            true);
        new Recipe("deco_antiquities_beefalo", new[] { new Ingredient("oinc", 10), new Ingredient("horn", 1) },
            Constant.RENO_RECIPETABS.ORNAMENTS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "deco_antiquities_beefalo_placer", null, true, null, null, null, true, false, "reno_antiquities_beefalo",
            true);

        new Recipe("window_small_peaked_curtain", new[] { new Ingredient("oinc", 3) }, Constant.RENO_RECIPETABS.WINDOWS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "window_small_peaked_curtain_placer", null, true, null, null,
            null, true, false, "reno_window_small_peaked_curtain", true);
        new Recipe("window_round_burlap", new[] { new Ingredient("oinc", 3) }, Constant.RENO_RECIPETABS.WINDOWS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "window_round_burlap_placer", null, true, null, null, null,
            true, false, "reno_window_round_burlap", true);
        new Recipe("window_small_peaked", new[] { new Ingredient("oinc", 3) }, Constant.RENO_RECIPETABS.WINDOWS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "window_small_peaked_placer", null, true, null, null, null,
            true, false, "reno_window_small_peaked", true);
        new Recipe("window_large_square", new[] { new Ingredient("oinc", 4) }, Constant.RENO_RECIPETABS.WINDOWS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "window_large_square_placer", null, true, null, null, null,
            true, false, "reno_window_large_square", true);
        new Recipe("window_tall", new[] { new Ingredient("oinc", 4) }, Constant.RENO_RECIPETABS.WINDOWS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "window_tall_placer", null, true, null, null, null, true,
            false, "reno_window_tall", true);
        new Recipe("window_large_square_curtain", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.WINDOWS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "window_large_square_curtain_placer", null, true, null, null,
            null, true, false, "reno_window_large_square_curtain", true);
        new Recipe("window_tall_curtain", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.WINDOWS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "window_tall_curtain_placer", null, true, null, null, null,
            true, false, "reno_window_tall_curtain", true);

        new Recipe("window_greenhouse", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.WINDOWS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "window_greenhouse_placer", null, true, null, null, null, true,
            false, "reno_window_greenhouse", true);

        new Recipe("deco_wood", new[] { new Ingredient("oinc", 1) }, Constant.RENO_RECIPETABS.COLUMNS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_wood_cornerbeam_placer", null, true, null, null, null,
            true, false, "reno_cornerbeam_wood", true);
        new Recipe("deco_millinery", new[] { new Ingredient("oinc", 1) }, Constant.RENO_RECIPETABS.COLUMNS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_millinery_cornerbeam_placer", null, true, null, null,
            null, true, false, "reno_cornerbeam_millinery", true);
        new Recipe("deco_round", new[] { new Ingredient("oinc", 1) }, Constant.RENO_RECIPETABS.COLUMNS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_round_cornerbeam_placer", null, true, null, null, null,
            true, false, "reno_cornerbeam_round", true);
        new Recipe("deco_marble", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.COLUMNS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "deco_marble_cornerbeam_placer", null, true, null, null, null,
            true, false, "reno_cornerbeam_marble", true);

        new Recipe("interior_floor_wood", new[] { new Ingredient("oinc", 5) }, Constant.RENO_RECIPETABS.FLOORING,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_floor_marble", new[] { new Ingredient("oinc", 15) }, Constant.RENO_RECIPETABS.FLOORING,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_floor_check", new[] { new Ingredient("oinc", 7) }, Constant.RENO_RECIPETABS.FLOORING,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_floor_plaid_tile", new[] { new Ingredient("oinc", 10) }, Constant.RENO_RECIPETABS.FLOORING,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_floor_sheet_metal", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.FLOORING,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);

        new Recipe("interior_floor_gardenstone", new[] { new Ingredient("oinc", 10) },
            Constant.RENO_RECIPETABS.FLOORING, Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_floor_geometrictiles", new[] { new Ingredient("oinc", 12) },
            Constant.RENO_RECIPETABS.FLOORING, Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_floor_shag_carpet", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.FLOORING,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_floor_transitional", new[] { new Ingredient("oinc", 6) },
            Constant.RENO_RECIPETABS.FLOORING, Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_floor_woodpanels", new[] { new Ingredient("oinc", 10) }, Constant.RENO_RECIPETABS.FLOORING,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_floor_herringbone", new[] { new Ingredient("oinc", 12) },
            Constant.RENO_RECIPETABS.FLOORING, Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_floor_hexagon", new[] { new Ingredient("oinc", 12) }, Constant.RENO_RECIPETABS.FLOORING,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_floor_hoof_curvy", new[] { new Ingredient("oinc", 12) }, Constant.RENO_RECIPETABS.FLOORING,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_floor_octagon", new[] { new Ingredient("oinc", 12) }, Constant.RENO_RECIPETABS.FLOORING,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);

        new Recipe("interior_wall_wood", new[] { new Ingredient("oinc", 1) }, Constant.RENO_RECIPETABS.WALLPAPER,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_wall_checkered", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.WALLPAPER,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_wall_floral", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.WALLPAPER,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_wall_sunflower", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.WALLPAPER,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_wall_harlequin", new[] { new Ingredient("oinc", 10) }, Constant.RENO_RECIPETABS.WALLPAPER,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);

        new Recipe("interior_wall_peagawk", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.WALLPAPER,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_wall_plain_ds", new[] { new Ingredient("oinc", 4) }, Constant.RENO_RECIPETABS.WALLPAPER,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_wall_plain_rog", new[] { new Ingredient("oinc", 4) }, Constant.RENO_RECIPETABS.WALLPAPER,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_wall_rope", new[] { new Ingredient("oinc", 6) }, Constant.RENO_RECIPETABS.WALLPAPER,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_wall_circles", new[] { new Ingredient("oinc", 10) }, Constant.RENO_RECIPETABS.WALLPAPER,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_wall_marble", new[] { new Ingredient("oinc", 15) }, Constant.RENO_RECIPETABS.WALLPAPER,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_wall_mayorsoffice", new[] { new Ingredient("oinc", 15) },
            Constant.RENO_RECIPETABS.WALLPAPER, Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_wall_fullwall_moulding", new[] { new Ingredient("oinc", 15) },
            Constant.RENO_RECIPETABS.WALLPAPER, Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("interior_wall_upholstered", new[] { new Ingredient("oinc", 8) }, Constant.RENO_RECIPETABS.WALLPAPER,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);

        new Recipe("swinging_light_basic_bulb", new[] { new Ingredient("oinc", 5) },
            Constant.RENO_RECIPETABS.HANGING_LAMPS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "swinging_light_basic_bulb_placer", null, true, null, null, null, true, false, "reno_light_basic_bulb");
        new Recipe("swinging_light_basic_metal", new[] { new Ingredient("oinc", 6) },
            Constant.RENO_RECIPETABS.HANGING_LAMPS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "swinging_light_basic_metal_placer", null, true, null, null, null, true, false, "reno_light_basic_metal");
        new Recipe("swinging_light_chandalier_candles", new[] { new Ingredient("oinc", 8) },
            Constant.RENO_RECIPETABS.HANGING_LAMPS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "swinging_light_chandalier_candles_placer", null, true, null, null, null, true, false,
            "reno_light_chandalier_candles");
        new Recipe("swinging_light_rope_1", new[] { new Ingredient("oinc", 1) }, Constant.RENO_RECIPETABS.HANGING_LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "swinging_light_rope_1_placer", null, true, null, null, null,
            true, false, "reno_light_rope_1");
        new Recipe("swinging_light_rope_2", new[] { new Ingredient("oinc", 1) }, Constant.RENO_RECIPETABS.HANGING_LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "swinging_light_rope_2_placer", null, true, null, null, null,
            true, false, "reno_light_rope_2");
        new Recipe("swinging_light_floral_bulb", new[] { new Ingredient("oinc", 10) },
            Constant.RENO_RECIPETABS.HANGING_LAMPS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "swinging_light_floral_bulb_placer", null, true, null, null, null, true, false, "reno_light_floral_bulb");
        new Recipe("swinging_light_pendant_cherries", new[] { new Ingredient("oinc", 12) },
            Constant.RENO_RECIPETABS.HANGING_LAMPS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "swinging_light_pendant_cherries_placer", null, true, null, null, null, true, false,
            "reno_light_pendant_cherries");
        new Recipe("swinging_light_floral_scallop", new[] { new Ingredient("oinc", 12) },
            Constant.RENO_RECIPETABS.HANGING_LAMPS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "swinging_light_floral_scallop_placer", null, true, null, null, null, true, false,
            "reno_light_floral_scallop");
        new Recipe("swinging_light_floral_bloomer", new[] { new Ingredient("oinc", 12) },
            Constant.RENO_RECIPETABS.HANGING_LAMPS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "swinging_light_floral_bloomer_placer", null, true, null, null, null, true, false,
            "reno_light_floral_bloomer");
        new Recipe("swinging_light_tophat", new[] { new Ingredient("oinc", 12) },
            Constant.RENO_RECIPETABS.HANGING_LAMPS, Constant.TECH.HOME_TWO, cityRecipeGameTypes,
            "swinging_light_tophat_placer", null, true, null, null, null, true, false, "reno_light_tophat");
        new Recipe("swinging_light_derby", new[] { new Ingredient("oinc", 12) }, Constant.RENO_RECIPETABS.HANGING_LAMPS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "swinging_light_derby_placer", null, true, null, null, null,
            true, false, "reno_light_derby");

        #endregion

        #region DOORS

        new Recipe("wood_door", new[] { new Ingredient("oinc", 10) }, Constant.RENO_RECIPETABS.DOORS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "wood_door_placer", null, true, null, null, null, true, false,
            "wood_door", true);
        new Recipe("stone_door", new[] { new Ingredient("oinc", 10) }, Constant.RENO_RECIPETABS.DOORS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "stone_door_placer", null, true, null, null, null, true, false,
            "stone_door", true);
        new Recipe("organic_door", new[] { new Ingredient("oinc", 15) }, Constant.RENO_RECIPETABS.DOORS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "organic_door_placer", null, true, null, null, null, true,
            false, "organic_door", true);
        new Recipe("iron_door", new[] { new Ingredient("oinc", 15) }, Constant.RENO_RECIPETABS.DOORS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "iron_door_placer", null, true, null, null, null, true, false,
            "iron_door", true);
        new Recipe("curtain_door", new[] { new Ingredient("oinc", 15) }, Constant.RENO_RECIPETABS.DOORS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "curtain_door_placer", null, true, null, null, null, true,
            false, "curtain_door", true);
        new Recipe("plate_door", new[] { new Ingredient("oinc", 15) }, Constant.RENO_RECIPETABS.DOORS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "plate_door_placer", null, true, null, null, null, true, false,
            "plate_door", true);
        new Recipe("round_door", new[] { new Ingredient("oinc", 20) }, Constant.RENO_RECIPETABS.DOORS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "round_door_placer", null, true, null, null, null, true, false,
            "round_door", true);
        new Recipe("pillar_door", new[] { new Ingredient("oinc", 20) }, Constant.RENO_RECIPETABS.DOORS,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, "pillar_door_placer", null, true, null, null, null, true,
            false, "pillar_door", true);

        new Recipe("construction_permit", new[] { new Ingredient("oinc", 50) }, Constant.RECIPETABS.HOME,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);
        new Recipe("demolition_permit", new[] { new Ingredient("oinc", 10) }, Constant.RECIPETABS.HOME,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes, null, null, true);

        #endregion

        #region Recipes for the interior crafting categories

        new RecipeCategory("reno_tab_floors", Constant.RENO_RECIPETABS.FLOORING, Constant.RECIPETABS.HOME,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes);
        new RecipeCategory("reno_tab_shelves", Constant.RENO_RECIPETABS.SHELVES, Constant.RECIPETABS.HOME,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes);
        new RecipeCategory("reno_tab_plantholders", Constant.RENO_RECIPETABS.PLANT_HOLDERS, Constant.RECIPETABS.HOME,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes);
        new RecipeCategory("reno_tab_columns", Constant.RENO_RECIPETABS.COLUMNS, Constant.RECIPETABS.HOME,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes);
        new RecipeCategory("reno_tab_wallpaper", Constant.RENO_RECIPETABS.WALLPAPER, Constant.RECIPETABS.HOME,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes);
        new RecipeCategory("reno_tab_hanginglamps", Constant.RENO_RECIPETABS.HANGING_LAMPS, Constant.RECIPETABS.HOME,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes);
        new RecipeCategory("reno_tab_chairs", Constant.RENO_RECIPETABS.CHAIRS, Constant.RECIPETABS.HOME,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes);
        new RecipeCategory("reno_tab_homekits", Constant.RENO_RECIPETABS.HOME_KITS, Constant.RECIPETABS.HOME,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes);
        new RecipeCategory("reno_tab_doors", Constant.RENO_RECIPETABS.DOORS, Constant.RECIPETABS.HOME,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes);
        new RecipeCategory("reno_tab_windows", Constant.RENO_RECIPETABS.WINDOWS, Constant.RECIPETABS.HOME,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes);
        new RecipeCategory("reno_tab_rugs", Constant.RENO_RECIPETABS.RUGS, Constant.RECIPETABS.HOME,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes);
        new RecipeCategory("reno_tab_lamps", Constant.RENO_RECIPETABS.LAMPS, Constant.RECIPETABS.HOME,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes);
        new RecipeCategory("reno_tab_tables", Constant.RENO_RECIPETABS.TABLES, Constant.RECIPETABS.HOME,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes);
        new RecipeCategory("reno_tab_ornaments", Constant.RENO_RECIPETABS.ORNAMENTS, Constant.RECIPETABS.HOME,
            Constant.TECH.HOME_TWO, cityRecipeGameTypes);

        #endregion

        #region Deconstruction Recipes

        // These recipes are for other characters' structures to drop their loot
        // and for some things to be deconstructable.
        // Character recipes here will be overwritten in the character file,
        // so it's safe to register them without tests.

        new DeconstructRecipe("woodlegsboat",
            new[] { new Ingredient("boatcannon", 1), new Ingredient("boards", 4), new Ingredient("dubloon", 4) });
        new DeconstructRecipe("surfboard", new[] { new Ingredient("boards", 1), new Ingredient("seashell", 2) });
        new DeconstructRecipe("telipad",
            new[] { new Ingredient("gears", 1), new Ingredient("transistor", 1), new Ingredient("cutstone", 2) });
        new DeconstructRecipe("thumper",
            new[] { new Ingredient("gears", 1), new Ingredient("flint", 6), new Ingredient("hammer", 2) });


        new DeconstructRecipe("minisign", new[] { new Ingredient("boards", 1) });
        new DeconstructRecipe("spiderhat",
            new[] { new Ingredient("silk", 4), new Ingredient("spidergland", 2), new Ingredient("monstermeat", 1) });

        new DeconstructRecipe("pig_guard_tower_palace",
            new[] { new Ingredient("cutstone", 3), new Ingredient("halberd", 2), new Ingredient("pigskin", 4) });
        new DeconstructRecipe("pig_shop_academy",
            new[]
            {
                new Ingredient("boards", 4), new Ingredient("relic_1", 1), new Ingredient("relic_2", 1),
                new Ingredient("pigskin", 4)
            });
        new DeconstructRecipe("pighouse_farm",
            new[]
            {
                new Ingredient("cutstone", 3), new Ingredient("pitchfork", 1), new Ingredient("seeds", 6),
                new Ingredient("pigskin", 4)
            });
        new DeconstructRecipe("pighouse_mine",
            new[] { new Ingredient("cutstone", 3), new Ingredient("pickaxe", 2), new Ingredient("pigskin", 4) });
        new DeconstructRecipe("mandrakehouse",
            new[] { new Ingredient("boards", 3), new Ingredient("mandrake", 2), new Ingredient("cutgrass", 10) });

        new DeconstructRecipe("topiary_1", new[] { new Ingredient("oinc", 20) });
        new DeconstructRecipe("topiary_2", new[] { new Ingredient("oinc", 20) });
        new DeconstructRecipe("topiary_3", new[] { new Ingredient("oinc", 20) });
        new DeconstructRecipe("topiary_4", new[] { new Ingredient("oinc", 20) });

        #endregion
    }
}