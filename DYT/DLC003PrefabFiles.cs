﻿using System.Collections.Generic;

namespace DYT
{
    public class DLC003PrefabFiles
    {
        // Generated by exportprefabs.lua
        public static List<string> PREFABFILES = new()
        {
            "abigail",
            /*
            "abigail_flower",
            "acorn",
            "acorn_door",
            "acorn_lighttest",
            "adult_flytrap",
            "alloy",
            "aloe",
            "altar_prototyper",
            "amulet",
            "ancient_herald",
            "ancient_hulk",
            "ancient_robots",
            "ancient_robots_assembly",
            "antcombhome",
            "anthill",
            "anthill_lamp",
            "anthill_stalactite",
            "antivenom",
            "antlarva",
            "antman",
            "antman_warrior",
            "antman_warrior_egg",
            "antqueen",
            "antqueen_chambers",
            "antsuit",
            "aporkalypse_clock",
            "armor_bramble",
            "armor_cactus",
            "armor_dragonfly",
            "armor_grass",
            "armor_lifejacket",
            "armor_limestone",
            "armor_marble",
            "armor_metal",
            "armor_obsidian",
            "armor_ruins",
            "armor_sanity",
            "armor_seashell",
            "armor_slurper",
            "armor_snurtleshell",
            "armor_vortex_cloak",
            "armor_weevole",
            "armor_windbreaker",
            "armor_wood",
            "ash",
            "ashfx",
            "asparagus",
            "axe",
            "axe_pickaxe",
            "babybeefalo",
            "babyox",
            "backpack",
            "balloon",
            "balloons_empty",
            "ballphin",
            "ballphin_spawner",
            "ballphinhouse",
            "ballphinpod",
            "bamboo",
            "bandage",
            "banditmap",
            "basefan",
            "bat_hide",
            "batbat",
            "batcavemanager",
            "beachresurrector",
            "beardhair",
            "bearger",
            "bearger_fur",
            "beargervest",
            "bedroll_furry",
            "bedroll_straw",
            "bee",
            "beebox",
            "beefalo",
            "beefaloherd",
            "beefalowool",
            "beehive",
            "beeswax",
            "bermudatriangle",
            "berrybush",
            "bigfoot",
            "bill",
            "bill_quill",
            "bioluminescence",
            "bioluminescence_spawner",
            "birchnutdrake",
            "birdcage",
            "birds",
            "birdtrap",
            "birdwhistle",
            "blowdart",
            "blubber",
            "blubbersuit",
            "blueprint",
            "blunderbuss",
            "boards",
            "boat",
            "boat_indicator",
            "boatcannon",
            "boatlantern",
            "boatrepairkit",
            "boatspawnpoint",
            "boattorch",
            "boneshard",
            "books",
            "boomerang",
            "bottlelantern",
            "bramble",
            "bramble_bulb",
            "brush",
            "bugfood",
            "bugnet",
            "bugrepellent",
            "bundle",
            "bunnyman",
            "buoy",
            "buriedtreasure",
            "butter",
            "butterfly",
            "butterfly_areaspawner",
            "butterflywings",
            "buzzard",
            "buzzardspawner",
            "cactus",
            "campfire",
            "campfirefire",
            "candlefire",
            "cane",
            "cannonshot",
            "catcoon",
            "catcoonden",
            "cave",
            "cave_entrance",
            "cave_entrance_roc",
            "cavespiders",
            "charcoal",
            "chess_navy_spawner",
            "chessjunk",
            "chester",
            "chester_eyebone",
            "chicken",
            "chiminea",
            "chimineafire",
            "chitin",
            "city_hammer",
            "city_lamp",
            "city_lamp_inside",
            "clawpalmtree_sapling",
            "clawpalmtrees",
            "clippings",
            "cloudpuff",
            "coconade",
            "coconut",
            "coldfire",
            "coldfirefire",
            "coldfirepit",
            "compass",
            "compostwrap",
            "construction_permit",
            "cookpot",
            "coontail",
            "coral",
            "coral_brain",
            "coral_brain_rock",
            "corallarve",
            "cork",
            "corkbat",
            "crab",
            "crabhole",
            "crate",
            "crocodog",
            "cutgrass",
            "cutlass",
            "cutlichen",
            "cutreeds",
            "cutstone",
            "deciduous_root",
            "deciduoustrees",
            "deco",
            "deco_academy",
            "deco_antiquities",
            "deco_chair",
            "deco_florist",
            "deco_lamp",
            "deco_lightglow",
            "deco_placers",
            "deco_plantholder",
            "deco_roomglow",
            "deco_ruins_fountain",
            "deco_swinging_light",
            "deco_table",
            "deco_wall_ornament",
            "deed",
            "deep_jungle_fern_noise",
            "deerclops",
            "deerclops_eyeball",
            "deflated_balloon",
            "demolition_permit",
            "devtool",
            "disarmingkit",
            "diviningrod",
            "diviningrodbase",
            "dorsalfin",
            "doydoy",
            "doydoy_mating_fx",
            "doydoyegg",
            "doydoyfeather",
            "doydoyherd",
            "doydoynest",
            "dragon_scales",
            "dragonfly",
            "dragonfly_chest",
            "dragoon",
            "dragoonden",
            "dragoonegg",
            "dragoonfire",
            "dragoonheart",
            "dragoonspit",
            "dubloon",
            "dungball",
            "dungbeetle",
            "dungpile",
            "earring",
            "edgefog",
            "eel",
            "egg",
            "elephantcactus",
            "evergreens",
            "explode_firecrackers",
            "exploderingfx",
            "exterior_texture_packages",
            "fabric",
            "farm_decor",
            "farmplot",
            "featherfan",
            "featherpencil",
            "feathers",
            "fence",
            "fertilizer",
            "firecrackers",
            "fireflies",
            "firepit",
            "firerain",
            "fireringfx",
            "firesuppressor",
            "fish",
            "fish_med",
            "fishfarm",
            "fishfarm_sign",
            "fishingrod",
            "fishinhole",
            "flamegeyser",
            "flint",
            "floor_interior",
            "flotsam",
            "flotsam_basegame",
            "flower",
            "flower_evil",
            "flower_rainforest",
            "floweroflife",
            "flup",
            "flupspawner",
            "foliage",
            "forest",
            "frog",
            "froglegs",
            "frontend",
            "fx",
            "gascloud",
            "gaze_beam",
            "gears",
            "gem",
            "generic_door",
            "generic_interior",
            "generic_interior_art",
            "generic_wall_back",
            "generic_wall_side",
            "ghost",
            "giantgrub",
            "global",
            "glommer",
            "glommerbell",
            "glommerflower",
            "glommerfuel",
            "glommerwings",
            "glowfly",
            "gnat",
            "gnatmound",
            "goatmilk",
            "gold_dust",
            "goldnugget",
            "goldpan",
            "goose_feather",
            "grabbing_vine",
            "grass",
            "grass_tall",
            "grounded_wilba",
            "groundpoundringfx",
            "guano",
            "gunpowder",
            "hail",
            "haildrop",
            "halberd",
            "hambat",
            "hammer",
            "hanging_vine",
            "harpoon",
            "hatpropeller",
            "hats",
            "hawaiianshirt",
            "healingsalve",
            "heatrock",
            "hedge",
            "herald_tatters",
            "hippo_antler",
            "hippoherd",
            "hippoptamoose",
            "home_prototyper",
            "homesign",
            "honey",
            "honeycomb",
            "horn",
            "hound",
            "houndbone",
            "houndmound",
            "houndstooth",
            "house_door",
            "hud",
            "ice_puddle",
            "ice_splash",
            "icebox",
            "icemaker",
            "icepack",
            "infused_iron",
            "interior_spawn_origin",
            "interior_texture_packages",
            "inv_bamboo",
            "inv_marble",
            "inv_rocks",
            "inv_rocks_ice",
            "inv_vine",
            "inventorygrave",
            "inventorymound",
            "inventorywaterygrave",
            "iron",
            "jellyfish",
            "jellyfish_planted",
            "jellyfish_spawner",
            "jungle_border_vine",
            "jungle_tree_burr",
            "jungletrees",
            "jungletreeseed",
            "key_to_city",
            "knightboat",
            "knightboat_cannonshot",
            "koalefant",
            "kraken",
            "kraken_projectile",
            "kraken_tentacle",
            "krampus",
            "krampus_sack",
            "laser",
            "laser_ring",
            "lavaerupt",
            "lavalight",
            "lavapool",
            "lavaspit",
            "lawnornaments",
            "lichen",
            "light_rays",
            "lightbulb",
            "lighter",
            "lightninggoat",
            "lightninggoatherd",
            "lightninggoathorn",
            "lightningrod",
            "lillypad",
            "limestone",
            "limpetrock",
            "limpets",
            "littlehammer",
            "living_artifact",
            "livingjungletree",
            "livinglog",
            "lobster",
            "lobsterhole",
            "lockedwes",
            "log",
            "lotus",
            "lotus_flower",
            "lucy",
            "lureplant",
            "lureplant_bulb",
            "machete",
            "magic_seal",
            "magicprototyper",
            "magma_rocks",
            "magnifying_glass",
            "mailpack",
            "mandrake",
            "mandrakehouse",
            "mandrakeman",
            "mangrove",
            "manrabbit_tail",
            "marsh_bush",
            "marsh_plant",
            "marsh_tree",
            "mean_flytrap",
            "meatrack",
            "meats",
            "merm",
            "mermfisher",
            "mermhouse",
            "mermhouse_fisher",
            "messagebottle",
            "meteor_impact",
            "minimap",
            "mininglantern",
            "minisign",
            "minotaur",
            "minotaurhorn",
            "mole",
            "molehill",
            "monkey",
            "monkeyball",
            "monkeybarrel",
            "monkeyprojectile",
            "moose",
            "moose_nest_fx",
            "mooseegg",
            "mosquito",
            "mosquitosack",
            "mossling",
            "mossling_spin_fx",
            "mosslingherd",
            "mound",
            "musac",
            "mushrooms",
            "mussel",
            "mussel_bed",
            "mussel_farm",
            "mussel_stick",
            "mysterymeat",
            "nectar_pod",
            "needle_dart",
            "nettle",
            "nettle_plant",
            "nightlight",
            "nightmarecreature",
            "nightmarefuel",
            "nightmarerock",
            "nightstick",
            "nightstickfire",
            "nightsword",
            "nitre",
            "nubbin",
            "obsidian",
            "obsidian_workbench",
            "obsidianfirefire",
            "obsidianfirepit",
            "oceanfog",
            "oceanspawner",
            "octopusking",
            "oinc",
            "oinc10",
            "oinc100",
            "onemanband",
            "ox",
            "ox_flute",
            "ox_horn",
            "oxherd",
            "packim",
            "packim_fishbone",
            "palmleaf",
            "palmleafhut",
            "palmtrees",
            "panflute",
            "pangolden",
            "papyrus",
            "peagawk",
            "peagawkfeather",
            "peagawkfeather_prism",
            "peekhen",
            "peekhenspawner",
            "penguin",
            "penguin_ice",
            "perd",
            "petals",
            "petals_evil",
            "pheromonestone",
            "phlegm",
            "pickaxe",
            "pig_guard_tower",
            "pig_palace",
            "pig_ruins_creeping_vines",
            "pig_ruins_dart",
            "pig_ruins_dart_statue",
            "pig_ruins_entrance",
            "pig_ruins_light_beam",
            "pig_ruins_pressure_plate",
            "pig_ruins_spear_trap",
            "pig_ruins_torch",
            "pig_scepter",
            "pig_shop",
            "pigbandit",
            "pigbanditexit",
            "pigeon_swarm",
            "piggyback",
            "pighouse",
            "pighouse_city",
            "pigking",
            "pigman",
            "pigman_city",
            "pigman_shopkeeper_desk",
            "pigskin",
            "pigthought",
            "pigtorch",
            "pike_skull",
            "piko",
            "pinecone",
            "piratepack",
            "pitchfork",
            "plant_normal",
            "plantables",
            "playerhouse_city",
            "pog",
            "pogherd",
            "poisonbalm",
            "poisonbubble",
            "poisonhole",
            "poisonmistarea",
            "poisonmistparticle",
            "pollen",
            "pond",
            "poop",
            "porkland",
            "porkland_entrance",
            "porklandintro",
            "porklandintro_wormwood",
            "portablecookpot",
            "portal_shipwrecked",
            "pottedfern",
            "preparedfoods",
            "primeape",
            "primeapebarrel",
            "prop_door",
            "pugalisk",
            "pugalisk_fountain",
            "pugalisk_ruins_pillar",
            "pugalisk_skull",
            "pugalisk_trap_door",
            "puppet",
            "quackenbeak",
            "quackendrill",
            "quackering_charge_fx",
            "quackering_wake",
            "quackering_wave",
            "quackeringram",
            "rabbit",
            "rabbithole",
            "rabbithouse",
            "rabid_beetle",
            "radish",
            "rain",
            "rainbowjellyfish",
            "rainbowjellyfish_planted",
            "rainbowjellyfish_spawner",
            "raincoat",
            "rainforesttrees",
            "rainometer",
            "rawling",
            "razor",
            "reconstruction_project",
            "redbarrel",
            "reeds",
            "reflectivevest",
            "relics",
            "renovation_poof_fx",
            "resurrectionstatue",
            "resurrectionstone",
            "ro_bin",
            "ro_bin_gizzard_stone",
            "roc",
            "roc_head",
            "roc_leg",
            "roc_nest",
            "roc_robin_egg",
            "roc_tail",
            "rock_flippable",
            "rock_ice",
            "rock_obsidian",
            "rocks",
            "rocky",
            "rockyherd",
            "roe",
            "roe_fish",
            "rook",
            "rope",
            "rowboat_wake",
            "rubble",
            "rug",
            "saddle",
            "saddlehorn",
            "sail",
            "sail_stick",
            "sand",
            "sandbag",
            "sandbagsmall",
            "sandcastle",
            "sandhill",
            "sapling",
            "scienceprototyper",
            "scorpion",
            "sea_chiminea",
            "sea_yard",
            "sea_yard_arms_fx",
            "seagullspawner",
            "seasack",
            "seashell",
            "seashell_beached",
            "seaweed",
            "seaweed_planted",
            "seaweed_stalk",
            "securitycontract",
            "sedimentpuddle",
            "seeds",
            "sewingkit",
            "shadowcreature",
            "shadowcreature_sea",
            "shadowskittish",
            "shadowwaxwell",
            "shadowwaxwell_boat",
            "shark_fin",
            "shark_gills",
            "sharkitten",
            "sharkittenspawner",
            "sharx",
            "shears",
            "shelf",
            "shelf_slot",
            "shipwrecked",
            "shipwrecked_entrance",
            "shock_fx",
            "shop_pedestals",
            "shop_spawner",
            "shop_trinket",
            "shovel",
            "side_door",
            "siestahut",
            "silk",
            "silvernecklace",
            "skeleton",
            "slotmachine",
            "slurper",
            "slurperpelt",
            "slurtle_shellpieces",
            "slurtleslime",
            "smallbird",
            "smashables",
            "smashingpot",
            "smelter",
            "smoke_plant",
            "snake",
            "snake_bone",
            "snakeden",
            "snakeoil",
            "snakeskin",
            "snakeskin_jacket",
            "snapdragon",
            "snapdragonherd",
            "solofish",
            "soundplayer",
            "sparks",
            "spear",
            "spear_wathgrithr",
            "speargun",
            "spearlauncher",
            "spicepack",
            "spider",
            "spider_monkey",
            "spider_monkey_herd",
            "spider_monkey_tree",
            "spider_web_spit",
            "spider_web_spit_creep",
            "spiderden",
            "spidereggsack",
            "spidergland",
            "spiderhole",
            "spiderqueen",
            "splash_spiderweb",
            "spoiledfood",
            "sprinkler",
            "staff",
            "staff_projectile",
            "staff_tornado",
            "statueglommer",
            "statueruins",
            "steelwool",
            "stickheads",
            "stinger",
            "structure_collapse_fx",
            "stungray",
            "stungray_spawner",
            "sunkenprefab",
            "sweatervest",
            "sweet_potato",
            "swordfish",
            "swordfish_spawner",
            "tallbird",
            "tallbirdegg",
            "tallbirdnest",
            "tar",
            "tar_extractor",
            "tar_pool",
            "tarlamp",
            "tarlampfire",
            "tarsuit",
            "teatree_nut",
            "teatrees",
            "telebase",
            "teleportato_hamlet",
            "teleportato_hamlet_parts",
            "teleportato_sw",
            "teleportato_sw_parts",
            "telescope",
            "tent",
            "tentaclespike",
            "tentaclespots",
            "test_interior_art",
            "test_interior_floor",
            "test_interior_pole",
            "thatchpack",
            "thulecite",
            "thulecite_pieces",
            "thunderbird",
            "thunderbirdnest",
            "tidalpool",
            "tigereye",
            "tigershark",
            "tigersharkshadow",
            "topiary",
            "torch",
            "torchfire",
            "transistor",
            "trap",
            "trap_bramble",
            "trawlnet",
            "treasurechest",
            "tree_creak_emitter",
            "tree_pillar",
            "treeguard",
            "treeguard_coconut",
            "trident",
            "trinkets",
            "trinkets_giftshop",
            "trunk",
            "trunkvest",
            "trusty_shooter",
            "tuber",
            "tubertrees",
            "tumbleweed",
            "tumbleweedspawner",
            "tunacan",
            "turbine_blades",
            "turfs",
            "twigs",
            "twister",
            "twister_seal",
            "umbrella",
            "vampire_bat_wing",
            "vampirebat",
            "vampirebatcave",
            "vampirebatcave_potential",
            "veggies",
            "venomgland",
            "vine",
            "volcano",
            "volcano_altar",
            "volcano_exit",
            "volcano_shrub",
            "volcanolavafx",
            "volcanolevel",
            "walani",
            "walkingstick",
            "wall_interior",
            "wall_test",
            "wallcrack_ruins",
            "walls",
            "wallyintro",
            "walrus",
            "walrus_camp",
            "walrus_tusk",
            "warbucks",
            "warg",
            "warly",
            "warningshadow",
            "water_pipe",
            "water_spray",
            "waterdrop",
            "waterfall",
            "waterprototyper",
            "wathgrithr",
            "wave_ripple",
            "wave_shimmer",
            "wave_shore",
            "waxpaper",
            "waxwell",
            "waxwelljournal",
            "webber",
            "webberskull",
            "weevole",
            "weevole_carapace",
            "wendy",
            "werewilbafur",
            "wes",
            "whale",
            "whale_bubbles",
            "whale_carcass",
            "wheeler",
            "wheeler_tracker",
            "whisperpod",
            "wickerbottom",
            "wilba",
            "wilbur",
            "wilbur_unlock",
            "wildbore",
            "wildborehouse",
            "willow",
            "wilson",
            "wind_conch",
            "windswirl",
            "windtrail",
            "winterometer",
            "wolfgang",
            "woodie",
            "woodlegs",
            "woodlegs_boatcannon",
            "woodlegs_cage",
            "woodlegs_key",
            "woodlegs_unlock",
            "world",
            "worm",
            "wormlight",
            "wormwood",
            "wormwood_plant_fx",
            "wormwood_pollen_fx",
            "wreck",
            "wx78",
            "zeb",
            "zebherd"
            */
        };
    }
}