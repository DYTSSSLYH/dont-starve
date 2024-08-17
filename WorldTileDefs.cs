using System.Collections.Generic;

public class WorldTileDefs
{
    public class Layer
    {
        public string name;
        public string noise_texture;
        public string runsound;
        public string walksound;
        public string snowsound;
        public string mudsound;
    }

    
    private static List<string> ADDITIONAL_TEXTURES = new List<string>
    {
	    // "levels/textures/fog_cloud.tex"
	    "levels/textures/ds_fog1.tex",

	    "levels/textures/water_fall_mangrove_opaque.tex",
	    "levels/textures/interiors/harlequin_panel.tex",
	    "levels/textures/interiors/ground_ruins_slab.tex",

	    "levels/textures/interiors/shop_wall_woodwall.tex",
	    "levels/textures/interiors/shop_wall_sunflower.tex",
	    "levels/textures/interiors/shop_wall_floraltrim2.tex",
	    "levels/textures/interiors/shop_wall_sunflower2.tex",
	    "levels/textures/interiors/shop_wall_marble.tex",
	    "levels/textures/interiors/shop_wall_tiles.tex",
	    "levels/textures/interiors/shop_wall_checkered.tex",
	    "levels/textures/interiors/shop_wall_checkered_metal.tex",
	    "levels/textures/interiors/shop_wall_upholstered.tex",
	    "levels/textures/interiors/shop_wall_moroc.tex",
	    "levels/textures/interiors/shop_wall_circles.tex",
	    "levels/textures/interiors/shop_wall_bricks.tex",

	    "levels/textures/interiors/shop_floor_checker.tex",
	    "levels/textures/interiors/shop_floor_checkered.tex",
	    "levels/textures/interiors/shop_floor_marble.tex",
	    "levels/textures/interiors/shop_floor_woodmetal.tex",
	    "levels/textures/interiors/shop_floor_sheetmetal.tex",
	    "levels/textures/interiors/shop_floor_herringbone.tex",
	    "levels/textures/interiors/shop_floor_octagon.tex",
	    "levels/textures/interiors/shop_floor_hexagon.tex",
	    "levels/textures/interiors/shop_floor_woodpaneling2.tex",

	    "levels/textures/interiors/floor_gardenstone.tex",
	    "levels/textures/interiors/floor_geometrictiles.tex",
	    "levels/textures/interiors/floor_shag_carpet.tex",
	    "levels/textures/interiors/floor_transitional.tex",
	    "levels/textures/interiors/floor_woodpanels.tex",

	    "levels/textures/interiors/wall_peagawk.tex",
	    "levels/textures/interiors/wall_plain_DS.tex",
	    "levels/textures/interiors/wall_plain_RoG.tex",
	    "levels/textures/interiors/wall_rope.tex",

	    "levels/textures/interiors/pig_ruins_panel.tex",
	    "levels/textures/interiors/pig_ruins_panel_blue.tex",

	    "levels/textures/interiors/batcave_floor.tex",
	    "levels/textures/interiors/batcave_wall_rock.tex",

	    "levels/textures/interiors/antcave_floor.tex",
	    "levels/textures/interiors/antcave_wall_rock.tex",

	    "levels/textures/interiors/wall_mayorsoffice_whispy.tex",
	    "levels/textures/interiors/floor_cityhall.tex",

	    "levels/textures/interiors/shop_floor_hoof_curvy.tex",
	    "levels/textures/interiors/shop_wall_fullwall_moulding.tex",

	    "levels/textures/interiors/wall_royal_high.tex",
	    "levels/textures/interiors/floor_marble_royal.tex",

	    // "levels/textures/map_interior/minimap_floor.tex",
	    "levels/textures/map_interior/mini_ruins_slab.tex",
	    "levels/textures/map_interior/mini_vamp_cave_noise.tex",
	    "levels/textures/map_interior/mini_antcave_floor.tex",
	    "levels/textures/map_interior/mini_floor_marble_royal.tex",

	    "levels/textures/map_interior/exit.tex",
	    "levels/textures/map_interior/frame.tex",
	    "levels/textures/map_interior/passage.tex",
	    "levels/textures/map_interior/passage_blocked.tex",
	    "levels/textures/map_interior/passage_unknown.tex",


	    "levels/textures/interiors/ground_ruins_slab_blue.tex",
	    "levels/textures/interiors/shop_wall_fullwall_moulding.tex",
	    "levels/textures/interiors/shop_floor_hoof_curvy.tex",
    };

    private static Dictionary<object, Layer>

	    GROUND_PROPERTIES = new Dictionary<object, Layer>
	    {
		    // DIRT AND GRASS REVERSED

		    {
			    Constant.GROUND.INTERIOR,
			    new Layer
			    {
				    name = "blocky", noise_texture = "levels/textures/interior.tex", runsound = "run_dirt",
				    walksound = "walk_dirt", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },

		    {
			    Constant.GROUND.BEACH,
			    new Layer
			    {
				    name = "beach", noise_texture = "levels/textures/Ground_noise_sand.tex", runsound = "run_sand",
				    walksound = "walk_sand", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.ROAD,
			    new Layer
			    {
				    name = "cobblestone", noise_texture = "images/square.tex", runsound = "run_dirt",
				    walksound = "walk_dirt", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.MARSH,
			    new Layer
			    {
				    name = "marsh", noise_texture = "levels/textures/Ground_noise_marsh.tex", runsound = "run_marsh",
				    walksound = "walk_marsh", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.ROCKY,
			    new Layer
			    {
				    name = "rocky", noise_texture = "levels/textures/noise_rocky.tex", runsound = "run_dirt",
				    walksound = "walk_dirt", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.SAVANNA,
			    new Layer
			    {
				    name = "yellowgrass", noise_texture = "levels/textures/Ground_noise_grass_detail.tex",
				    runsound = "run_tallgrass", walksound = "walk_tallgrass", snowsound = "run_snow",
				    mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.FOREST,
			    new Layer
			    {
				    name = "forest", noise_texture = "levels/textures/Ground_noise.tex", runsound = "run_woods",
				    walksound = "walk_woods", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.GRASS,
			    new Layer
			    {
				    name = "grass", noise_texture = "levels/textures/Ground_noise.tex", runsound = "run_grass",
				    walksound = "walk_grass", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.DIRT,
			    new Layer
			    {
				    name = "dirt", noise_texture = "levels/textures/Ground_noise_dirt.tex", runsound = "run_dirt",
				    walksound = "walk_dirt", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.DECIDUOUS,
			    new Layer
			    {
				    name = "deciduous", noise_texture = "levels/textures/Ground_noise_deciduous.tex",
				    runsound = "run_carpet", walksound = "walk_carpet", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.DESERT_DIRT,
			    new Layer
			    {
				    name = "desert_dirt", noise_texture = "levels/textures/Ground_noise_dirt.tex",
				    runsound = "run_dirt", walksound = "walk_dirt", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },

		    {
			    Constant.GROUND.VOLCANO_ROCK,
			    new Layer
			    {
				    name = "rocky", noise_texture = "levels/textures/ground_volcano_noise.tex", runsound = "run_rock",
				    walksound = "walk_rock", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.VOLCANO,
			    new Layer
			    {
				    name = "cave", noise_texture = "levels/textures/ground_lava_rock.tex", runsound = "run_rock",
				    walksound = "walk_rock", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.ASH,
			    new Layer
			    {
				    name = "cave", noise_texture = "levels/textures/ground_ash.tex", runsound = "run_dirt",
				    walksound = "walk_dirt", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },

		    {
			    Constant.GROUND.JUNGLE,
			    new Layer
			    {
				    name = "jungle", noise_texture = "levels/textures/Ground_noise_jungle.tex", runsound = "run_woods",
				    walksound = "walk_woods", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.SWAMP,
			    new Layer
			    {
				    name = "swamp", noise_texture = "levels/textures/Ground_noise_swamp.tex", runsound = "run_marsh",
				    walksound = "walk_marsh", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.MAGMAFIELD,
			    new Layer
			    {
				    name = "cave", noise_texture = "levels/textures/Ground_noise_magmafield.tex", runsound = "run_dirt",
				    walksound = "walk_dirt", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.TIDALMARSH,
			    new Layer
			    {
				    name = "tidalmarsh", noise_texture = "levels/textures/Ground_noise_tidalmarsh.tex",
				    runsound = "run_marsh", walksound = "walk_marsh", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.MEADOW,
			    new Layer
			    {
				    name = "jungle", noise_texture = "levels/textures/Ground_noise_savannah_detail.tex",
				    runsound = "run_tallgrass", walksound = "walk_tallgrass", snowsound = "run_snow",
				    mudsound = "run_mud"
			    }
		    },

		    {
			    Constant.GROUND.CAVE,
			    new Layer
			    {
				    name = "cave", noise_texture = "levels/textures/noise_cave.tex", runsound = "run_dirt",
				    walksound = "walk_dirt", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.FUNGUS,
			    new Layer
			    {
				    name = "cave", noise_texture = "levels/textures/noise_fungus.tex", runsound = "run_moss",
				    walksound = "walk_moss", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.FUNGUSRED,
			    new Layer
			    {
				    name = "cave", noise_texture = "levels/textures/noise_fungus_red.tex", runsound = "run_moss",
				    walksound = "walk_moss", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.FUNGUSGREEN,
			    new Layer
			    {
				    name = "cave", noise_texture = "levels/textures/noise_fungus_green.tex", runsound = "run_moss",
				    walksound = "walk_moss", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },

		    {
			    Constant.GROUND.SINKHOLE,
			    new Layer
			    {
				    name = "cave", noise_texture = "levels/textures/noise_sinkhole.tex", runsound = "run_dirt",
				    walksound = "walk_dirt", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.UNDERROCK,
			    new Layer
			    {
				    name = "cave", noise_texture = "levels/textures/noise_rock.tex", runsound = "run_dirt",
				    walksound = "walk_dirt", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.MUD,
			    new Layer
			    {
				    name = "cave", noise_texture = "levels/textures/noise_mud.tex", runsound = "run_mud",
				    walksound = "walk_mud", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },

		    {
			    Constant.GROUND.PIGRUINS,
			    new Layer
			    {
				    name = "blocky", noise_texture = "levels/textures/interiors/ground_ruins_slab.tex",
				    runsound = "run_dirt", walksound = "walk_dirt", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.PIGRUINS_NOCANOPY,
			    new Layer
			    {
				    name = "blocky", noise_texture = "levels/textures/interiors/ground_ruins_slab.tex",
				    runsound = "run_dirt", walksound = "walk_dirt", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },

		    {
			    Constant.GROUND.DEEPRAINFOREST_NOCANOPY,
			    new Layer
			    {
				    name = "jungle_deep", noise_texture = "levels/textures/Ground_noise_jungle_deep.tex",
				    runsound = "run_woods", walksound = "walk_woods", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },

		    {
			    Constant.GROUND.PAINTED,
			    new Layer
			    {
				    name = "swamp", noise_texture = "levels/textures/Ground_bog.tex", runsound = "run_sand",
				    walksound = "walk_sand", snowsound = "run_snow", mudsound = "run_sand"
			    }
		    },

		    {
			    Constant.GROUND.PLAINS,
			    new Layer
			    {
				    name = "jungle", noise_texture = "levels/textures/Ground_plains.tex", runsound = "run_tallgrass",
				    walksound = "walk_tallgrass", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },

		    {
			    Constant.GROUND.RAINFOREST,
			    new Layer
			    {
				    name = "rain_forest", noise_texture = "levels/textures/Ground_noise_rainforest.tex",
				    runsound = "run_woods", walksound = "walk_woods", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.DEEPRAINFOREST,
			    new Layer
			    {
				    name = "jungle_deep", noise_texture = "levels/textures/Ground_noise_jungle_deep.tex",
				    runsound = "run_woods", walksound = "walk_woods", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },

		    {
			    Constant.GROUND.BATTLEGROUND,
			    new Layer
			    {
				    name = "jungle_deep", noise_texture = "levels/textures/Ground_battlegrounds.tex",
				    runsound = "run_woods", walksound = "walk_woods", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },

		    {
			    Constant.GROUND.FIELDS,
			    new Layer
			    {
				    name = "jungle", noise_texture = "levels/textures/noise_farmland.tex", runsound = "run_woods",
				    walksound = "walk_woods", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.SUBURB,
			    new Layer
			    {
				    name = "deciduous", noise_texture = "levels/textures/noise_mossy_blossom.tex",
				    runsound = "run_dirt", walksound = "walk_dirt", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.FOUNDATION,
			    new Layer
			    {
				    name = "blocky", noise_texture = "levels/textures/noise_ruinsbrick_scaled.tex",
				    runsound = "run_slate", walksound = "walk_slate", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.LAWN,
			    new Layer
			    {
				    name = "pebble", noise_texture = "levels/textures/ground_noise_checkeredlawn.tex",
				    runsound = "run_grass", walksound = "walk_grass", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.COBBLEROAD,
			    new Layer
			    {
				    name = "stoneroad", noise_texture = "levels/textures/Ground_noise_cobbleroad.tex",
				    runsound = "run_rock", walksound = "walk_rock", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.GASJUNGLE,
			    new Layer
			    {
				    name = "jungle_deep", noise_texture = "levels/textures/ground_noise_gas.tex", runsound = "run_moss",
				    walksound = "walk_moss", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },

		    {
			    Constant.GROUND.BRICK_GLOW,
			    new Layer
			    {
				    name = "cave", noise_texture = "levels/textures/noise_ruinsbrick.tex", runsound = "run_dirt",
				    walksound = "walk_dirt", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.BRICK,
			    new Layer
			    {
				    name = "cave", noise_texture = "levels/textures/noise_ruinsbrickglow.tex", runsound = "run_moss",
				    walksound = "walk_moss", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.TILES_GLOW,
			    new Layer
			    {
				    name = "cave", noise_texture = "levels/textures/noise_ruinstile.tex", runsound = "run_dirt",
				    walksound = "walk_dirt", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.TILES,
			    new Layer
			    {
				    name = "cave", noise_texture = "levels/textures/noise_ruinstileglow.tex", runsound = "run_dirt",
				    walksound = "walk_dirt", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.TRIM_GLOW,
			    new Layer
			    {
				    name = "cave", noise_texture = "levels/textures/noise_ruinstrim.tex", runsound = "run_dirt",
				    walksound = "walk_dirt", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.TRIM,
			    new Layer
			    {
				    name = "cave", noise_texture = "levels/textures/noise_ruinstrimglow.tex", runsound = "run_dirt",
				    walksound = "walk_dirt", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.FLOOD,
			    new Layer
			    {
				    name = "flood", noise_texture = "levels/textures/Ground_noise_flood.tex", runsound = "run_marsh",
				    walksound = "walk_marsh", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },

		    {
			    Constant.GROUND.WOODFLOOR,
			    new Layer
			    {
				    name = "blocky", noise_texture = "levels/textures/noise_woodfloor.tex", runsound = "run_wood",
				    walksound = "walk_wood", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.CHECKER,
			    new Layer
			    {
				    name = "blocky", noise_texture = "levels/textures/noise_checker.tex", runsound = "run_marble",
				    walksound = "walk_marble", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.SNAKESKIN,
			    new Layer
			    {
				    name = "carpet", noise_texture = "levels/textures/noise_snakeskinfloor.tex",
				    runsound = "run_carpet", walksound = "walk_carpet", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.CARPET,
			    new Layer
			    {
				    name = "carpet", noise_texture = "levels/textures/noise_carpet.tex", runsound = "run_carpet",
				    walksound = "walk_carpet", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },

		    {
			    Constant.GROUND.BEARDRUG,
			    new Layer
			    {
				    name = "carpet", noise_texture = "levels/textures/Ground_beard_hair.tex", runsound = "run_carpet",
				    walksound = "walk_carpet", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },

		    {
			    Constant.GROUND.LILYPOND,
			    new Layer
			    {
				    name = "water_medium", noise_texture = "levels/textures/Ground_lilypond2.tex",
				    runsound = "run_marsh", walksound = "walk_marsh", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },

		    {
			    Constant.GROUND.MANGROVE,
			    new Layer
			    {
				    name = "water_medium", noise_texture = "levels/textures/Ground_water_mangrove.tex",
				    runsound = "run_marsh", walksound = "walk_marsh", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },

		    {
			    Constant.GROUND.MANGROVE_SHORE,
			    new Layer
			    {
				    name = "water_medium", noise_texture = "levels/textures/Ground_water_mangrove.tex",
				    runsound = "run_marsh", walksound = "walk_marsh", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.OCEAN_SHORE,
			    new Layer
			    {
				    name = "water_medium", noise_texture = "levels/textures/Ground_noise_water_shallow.tex",
				    runsound = "run_marsh", walksound = "walk_marsh", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.OCEAN_SHALLOW,
			    new Layer
			    {
				    name = "water_medium", noise_texture = "levels/textures/Ground_noise_water_shallow.tex",
				    runsound = "run_marsh", walksound = "walk_marsh", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.OCEAN_CORAL,
			    new Layer
			    {
				    name = "water_medium", noise_texture = "levels/textures/Ground_water_coral.tex",
				    runsound = "run_marsh", walksound = "walk_marsh", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.OCEAN_CORAL_SHORE,
			    new Layer
			    {
				    name = "water_medium", noise_texture = "levels/textures/Ground_water_coral.tex",
				    runsound = "run_marsh", walksound = "walk_marsh", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.OCEAN_MEDIUM,
			    new Layer
			    {
				    name = "water_medium", noise_texture = "levels/textures/Ground_noise_water_medium.tex",
				    runsound = "run_marsh", walksound = "walk_marsh", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.OCEAN_DEEP,
			    new Layer
			    {
				    name = "water_medium", noise_texture = "levels/textures/Ground_noise_water_deep.tex",
				    runsound = "run_marsh", walksound = "walk_marsh", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    Constant.GROUND.OCEAN_SHIPGRAVEYARD,
			    new Layer
			    {
				    name = "water_medium", noise_texture = "levels/textures/Ground_water_graveyard.tex",
				    runsound = "run_marsh", walksound = "walk_marsh", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },

		    // USED FOR INTERIOR FLOORS
		    {
			    "WOOD",
			    new Layer
			    {
				    runsound = "run_wood", walksound = "walk_wood", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    "STONE",
			    new Layer
			    {
				    runsound = "run_dirt", walksound = "walk_dirt", snowsound = "run_ice", mudsound = "run_mud"
			    }
		    },
		    {
			    "CARPET",
			    new Layer
			    {
				    runsound = "run_carpet", walksound = "walk_carpet", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
		    {
			    "DIRT",
			    new Layer
			    {
				    runsound = "run_dirt", walksound = "walk_dirt", snowsound = "run_snow", mudsound = "run_mud"
			    }
		    },
	    },

	    WALL_PROPERTIES = new Dictionary<object, Layer>
	    {
		    { Constant.GROUND.UNDERGROUND, new Layer { name = "falloff", noise_texture = "images/square.tex" } },
		    {
			    Constant.GROUND.WALL_MARSH, new Layer { name = "walls", noise_texture = "images/square.tex" }
		    }, //"levels/textures/wall_marsh_01.tex" } },
		    {
			    Constant.GROUND.WALL_ROCKY, new Layer { name = "walls", noise_texture = "images/square.tex" }
		    }, //"levels/textures/wall_rock_01.tex" } },
		    {
			    Constant.GROUND.WALL_DIRT, new Layer { name = "walls", noise_texture = "images/square.tex" }
		    }, //"levels/textures/wall_dirt_01.tex" } },

		    {
			    Constant.GROUND.WALL_CAVE, new Layer { name = "walls", noise_texture = "images/square.tex" }
		    }, //"levels/textures/wall_cave_01.tex" } },
		    {
			    Constant.GROUND.WALL_FUNGUS, new Layer { name = "walls", noise_texture = "images/square.tex" }
		    }, //"levels/textures/wall_fungus_01.tex" } },
		    {
			    Constant.GROUND.WALL_SINKHOLE, new Layer { name = "walls", noise_texture = "images/square.tex" }
		    }, //"levels/textures/wall_sinkhole_01.tex" } },
		    {
			    Constant.GROUND.WALL_MUD, new Layer { name = "walls", noise_texture = "images/square.tex" }
		    }, //"levels/textures/wall_mud_01.tex" } },
		    {
			    Constant.GROUND.WALL_TOP, new Layer { name = "walls", noise_texture = "images/square.tex" }
		    }, //"levels/textures/cave_topper.tex" } },
		    {
			    Constant.GROUND.WALL_WOOD, new Layer { name = "walls", noise_texture = "images/square.tex" }
		    }, //"levels/textures/cave_topper.tex" } },

		    {
			    Constant.GROUND.WALL_HUNESTONE_GLOW, new Layer { name = "walls", noise_texture = "images/square.tex" }
		    }, //"levels/textures/wall_cave_01.tex" } },
		    {
			    Constant.GROUND.WALL_HUNESTONE, new Layer { name = "walls", noise_texture = "images/square.tex" }
		    }, //"levels/textures/wall_fungus_01.tex" } },
		    {
			    Constant.GROUND.WALL_STONEEYE_GLOW, new Layer { name = "walls", noise_texture = "images/square.tex" }
		    }, //"levels/textures/wall_sinkhole_01.tex" } },
		    {
			    Constant.GROUND.WALL_STONEEYE, new Layer { name = "walls", noise_texture = "images/square.tex" }
		    }, //"levels/textures/wall_mud_01.tex" } },
	    },

	    underground_layers = new Dictionary<object, Layer>
	    {
		    { Constant.GROUND.UNDERGROUND, new Layer { name = "falloff", noise_texture = "images/square.tex" } },
	    },

	    GROUND_CREEP_PROPERTIES = new Dictionary<object, Layer>
	    {
		    { 1, new Layer { name = "web", noise_texture = "levels/textures/web_noise.tex" } },
	    },

	    FLOODING_PROPERTIES = new Dictionary<object, Layer>
	    {
		    { 2, new Layer { name = "flood", noise_texture = "levels/textures/Ground_noise_flood.tex" } },
	    };

    public static string GroundImage(string name)
    {
        return $"levels/tiles/{name}tex";
    }
    
    private static void AddAssets(List<Asset> assets, Dictionary<object, Layer> layers)
    {
        foreach (object tile_type in layers.Keys)
        {
            Layer properties = layers[tile_type];
            if (!string.IsNullOrWhiteSpace(properties.name)
                && !string.IsNullOrWhiteSpace(properties.noise_texture))
            {
                assets.Add(new Asset("IMAGE", properties.noise_texture));
                assets.Add(new Asset("IMAGE", GroundImage(properties.name)));
                assets.Add(new Asset("FILE", GroundImage(properties.name)));
            }
        }
    }
    
    public static Dictionary<object, Layer>
	    ground = GROUND_PROPERTIES,
	    creep = GROUND_CREEP_PROPERTIES,
	    flooding = FLOODING_PROPERTIES,
	    wall = WALL_PROPERTIES,
	    underground = underground_layers;
    public static readonly List<Asset> assets = new List<Asset>();
    
    
    public static void Init()
    {
        AddAssets(assets, WALL_PROPERTIES);
        AddAssets(assets, GROUND_PROPERTIES);
        AddAssets(assets, underground_layers);
        AddAssets(assets, GROUND_CREEP_PROPERTIES);
        
        foreach (string v in ADDITIONAL_TEXTURES) assets.Add(new Asset("IMAGE", v));
    }
}