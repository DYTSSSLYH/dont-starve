﻿using System.Collections.Generic;

public static class PrefabList
{
    // Generated by exportprefabs.lua
    public static List<string> PREFABFILES = new()
    {
        "abigail",
        "frontend",
        /*
        "abigail_flower",
        "accomplishment_shrine",
        "adventure_portal",
        "altar_prototyper",
        "amulet",
        "anim_test",
        "animal_track",
        "armor_grass",
        "armor_marble",
        "armor_ruins",
        "armor_sanity",
        "armor_slurper",
        "armor_snurtleshell",
        "armor_wood",
        "ash",
        "axe",
        "axe_pickaxe",
        "babybeefalo",
        "backpack",
        "balloon",
        "balloons_empty",
        "bandage",
        "basalt",
        "bat",
        "batbat",
        "batcave",
        "beardhair",
        "bedroll_furry",
        "bedroll_straw",
        "bee",
        "beebox",
        "beefalo",
        "beefaloherd",
        "beefalowool",
        "beehive",
        "beemine",
        "beeswax",
        "berrybush",
        "bigshadowtentacle",
        "birdcage",
        "birds",
        "birdtrap",
        "bishop",
        "bishop_charge",
        "blowdart",
        "blueprint",
        "boards",
        "boneshard",
        "bonfire",
        "books",
        "boomerang",
        "brokentool",
        "brush",
        "bugnet",
        "bundle",
        "bunnyman",
        "butter",
        "butterfly",
        "butterflywings",
        "campfire",
        "campfirefire",
        "cane",
        "carrot",
        "cave",
        "cave_banana_tree",
        "cave_entrance",
        "cave_exit",
        "cave_fern",
        "cave_regenerator",
        "cavelight",
        "cavespiders",
        "character_fire",
        "charcoal",
        "chessjunk",
        "chester",
        "chester_eyebone",
        "chesterlight",
        "compass",
        "cookpot",
        "creepyeyes",
        "cutgrass",
        "cutlichen",
        "cutreeds",
        "cutstone",
        "deadlyfeast",
        "deerclops",
        "deerclops_eyeball",
        "dirtpile",
        "diviningrod",
        "diviningrodbase",
        "diviningrodstart",
        "dropperweb",
        "eel",
        "egg",
        "evergreens",
        "exitcavelight",
        "eye_charge",
        "eyeplant",
        "eyeturret",
        "farm_decor",
        "farmplot",
        "featherpencil",
        "feathers",
        "fence",
        "fire",
        "fireflies",
        "firepit",
        "fish",
        "fishingrod",
        "flies",
        "flint",
        "flotsam",
        "flower",
        "flower_cave",
        "flower_evil",
        "foliage",
        "forcefieldfx",
        "forest",
        "frog",
        "froglegs",
        "frostbreath",
        "fryfocals_charge",
        "fx",
        "gears",
        "gem",
        "ghost",
        "global",
        "goggles",
        "goldnugget",
        "grass",
        "gravestone",
        "gridplacer",
        "ground_chunks_breaking",
        "groundpoundringfx",
        "guano",
        "gunpowder",
        "hambat",
        "hammer",
        "hats",
        "healingsalve",
        "heatrock",
        "hiddendanger_fx",
        "homesign",
        "honey",
        "honeycomb",
        "horn",
        "hound",
        "houndbone",
        "houndmound",
        "houndstooth",
        "hud",
        "icebox",
        "impact",
        "inv_marble",
        "inv_rocks",
        "knight",
        "koalefant",
        "krampus",
        "krampus_sack",
        "lanternfire",
        "lavalight",
        "leif",
        "lichen",
        "lightbulb",
        "lighter",
        "lighterfire",
        "lightning",
        "lightningrod",
        "livinglog",
        "livingtree",
        "lockedwes",
        "log",
        "lucy",
        "lureplant",
        "lureplant_bulb",
        "magicprototyper",
        "mandrake",
        "manrabbit_tail",
        "marblepillar",
        "marbletree",
        "marsh_bush",
        "marsh_plant",
        "marsh_tree",
        "maxwell",
        "maxwellendgame",
        "maxwellhead",
        "maxwellhead_trigger",
        "maxwellintro",
        "maxwellkey",
        "maxwelllight",
        "maxwelllight_flame",
        "maxwelllock",
        "maxwellphonograph",
        "maxwellthrone",
        "meatrack",
        "meats",
        "merm",
        "mermhouse",
        "minimap",
        "mininglantern",
        "minisign",
        "minotaur",
        "minotaurhorn",
        "mistarea",
        "mistparticle",
        "monkey",
        "monkeybarrel",
        "monkeyprojectile",
        "mosquito",
        "mosquitosack",
        "mound",
        "mushrooms",
        "mushtree",
        "nightlight",
        "nightlight_flame",
        "nightmare_timepiece",
        "nightmarecreature",
        "nightmarefissure",
        "nightmarefuel",
        "nightmarelight",
        "nightmarelightfx",
        "nightmarerock",
        "nightsword",
        "nitre",
        "onemanband",
        "paired_maxwelllight",
        "panflute",
        "papyrus",
        "penguin",
        "penguin_ice",
        "penguinherd",
        "perd",
        "petals",
        "petals_evil",
        "phlegm",
        "pickaxe",
        "piggyback",
        "pighouse",
        "pigking",
        "pigman",
        "pigskin",
        "pigtorch",
        "pigtorch_flame",
        "pillar",
        "pinecone",
        "pitchfork",
        "plant_normal",
        "plantables",
        "pond",
        "poop",
        "poopcloud",
        "portal_home",
        "portal_level",
        "pottedfern",
        "preparedfoods",
        "pumpkin_lantern",
        "puppet",
        "rabbit",
        "rabbithole",
        "rabbithouse",
        "rain",
        "raindrop",
        "rainometer",
        "razor",
        "reeds",
        "resurrectionstatue",
        "resurrectionstone",
        "reticule",
        "rock_light",
        "rocks",
        "rocky",
        "rockyherd",
        "rook",
        "rope",
        "rubble",
        "ruins_bat",
        "ruins_cavein_obstacle",
        "saddle",
        "saddlehorn",
        "saltlick",
        "sapling",
        "scienceprototyper",
        "seeds",
        "sewingkit",
        "shadowcreature",
        "shadowhand",
        "shadowskittish",
        "shadowtentacle",
        "shadowwatcher",
        "shadowwaxwell",
        "shatter",
        "shovel",
        "silk",
        "sinkhole",
        "skeleton",
        "slurper",
        "slurperpelt",
        "slurtle",
        "slurtle_shellpieces",
        "slurtlehole",
        "slurtleslime",
        "smallbird",
        "smashables",
        "snow",
        "sounddebugicon",
        "sparks",
        "spat",
        "spawnpoint",
        "spear",
        "spider",
        "spider_web_spit",
        "spider_web_spit_creep",
        "spiderden",
        "spidereggsack",
        "spidergland",
        "spiderhole",
        "spiderqueen",
        "splash_spiderweb",
        "spoiledfood",
        "staff",
        "staff_castinglight",
        "staff_projectile",
        "staffcastfx",
        "stafflight",
        "stalagmite",
        "stalagmite_tall",
        "statueharp",
        "statuemaxwell",
        "statueruins",
        "steelwool",
        "stickheads",
        "stinger",
        "structure_collapse_fx",
        "sunkboat",
        "sunken_boat",
        "sunken_boat_trinkets",
        "sweatervest",
        "tallbird",
        "tallbirdegg",
        "tallbirdnest",
        "teamleader",
        "telebase",
        "telebase_gemsocket",
        "telebrella",
        "teleportato",
        "teleportato_checkmate",
        "teleportato_parts",
        "teleportlocation",
        "telipad",
        "tent",
        "tentacle",
        "tentacle_arm",
        "tentacle_pillar",
        "tentaclespike",
        "tentaclespots",
        "thulecite",
        "thulecite_pieces",
        "thumper",
        "torch",
        "torchfire",
        "transistor",
        "trap",
        "trap_teeth",
        "treasurechest",
        "trinkets",
        "trunk",
        "trunkvest",
        "turfs",
        "twigs",
        "umbrella",
        "veggies",
        "wagstaff",
        "walls",
        "walrus",
        "walrus_camp",
        "walrus_tusk",
        "warningshadow",
        "wasphive",
        "waxpaper",
        "waxwell",
        "waxwelljournal",
        "wendy",
        "wes",
        "wickerbottom",
        "willow",
        "willowfire",
        "wilson",
        "winterometer",
        "wolfgang",
        "woodie",
        "world",
        "worm",
        "wormhole",
        "wormhole_limited",
        "wormlight",
        "wx78"
        */
    };
}