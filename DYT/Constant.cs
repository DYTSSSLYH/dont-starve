using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace DYT
{
	public class Constant
	{
		public const float PI = 3.14159f;
		public static float DEGREES = PI / 180;
		public static float RADIANS = 180 / PI;
		public static float FRAMES = 1 / 30f;
		public static int TILE_SCALE = 4;
		
		public static int
			ANCHOR_MIDDLE = 0,
			ANCHOR_LEFT = 1,
			ANCHOR_RIGHT = 2,
			ANCHOR_TOP = 1,
			ANCHOR_BOTTOM = 2,

			MOVE_UP = 0,
			MOVE_DOWN = 1,
			MOVE_LEFT = 2,
			MOVE_RIGHT = 3;
	
		#region Controls
    
		// Must match the Control enum in DontStarveInputHandler.h
		// Must match STRINGS.UI.CONTROLSSCREEN.CONTROLS

		#region player action controls

		public static int
			CONTROL_PRIMARY = 0,
			CONTROL_SECONDARY = 1,
			CONTROL_ATTACK = 2,
			CONTROL_INSPECT = 3,
			CONTROL_ACTION = 4;

		#endregion

		#region player movement controls

		public static int
			CONTROL_MOVE_UP = 5,
			CONTROL_MOVE_DOWN = 6,
			CONTROL_MOVE_LEFT = 7,
			CONTROL_MOVE_RIGHT = 8;

		#endregion

		#region view controls

		public static int
			CONTROL_ZOOM_IN = 9,
			CONTROL_ZOOM_OUT = 10,
			CONTROL_ROTATE_LEFT = 11,
			CONTROL_ROTATE_RIGHT = 12;

		#endregion

		#region player movement controls

		public static int
			CONTROL_PAUSE = 13,
			CONTROL_MAP = 14,
			CONTROL_INV_1 = 15,
			CONTROL_INV_2 = 16,
			CONTROL_INV_3 = 17,
			CONTROL_INV_4 = 18,
			CONTROL_INV_5 = 19,
			CONTROL_INV_6 = 20,
			CONTROL_INV_7 = 21,
			CONTROL_INV_8 = 22,
			CONTROL_INV_9 = 23,
			CONTROL_INV_10 = 24,

			CONTROL_FOCUS_UP = 25,
			CONTROL_FOCUS_DOWN = 26,
			CONTROL_FOCUS_LEFT = 27,
			CONTROL_FOCUS_RIGHT = 28,

			CONTROL_ACCEPT = 29,
			CONTROL_CANCEL = 30,
			CONTROL_PAGELEFT = (int)Key.PageUp,
			CONTROL_PAGERIGHT = (int)Key.PageDown,

			CONTROL_PREVVALUE = 33,
			CONTROL_NEXTVALUE = 34,

			CONTROL_SPLITSTACK = 35,
			CONTROL_TRADEITEM = 36,
			CONTROL_TRADESTACK = 37,
			CONTROL_FORCE_INSPECT = 38,
			CONTROL_FORCE_ATTACK = 39,
			CONTROL_FORCE_TRADE = 40,
			CONTROL_FORCE_STACK = 41,

			CONTROL_OPEN_DEBUG_CONSOLE = 42,
			CONTROL_TOGGLE_LOG = 43,
			CONTROL_TOGGLE_DEBUGRENDER = 44,

			CONTROL_OPEN_INVENTORY = 45,
			CONTROL_OPEN_CRAFTING = 46,
			CONTROL_INVENTORY_LEFT = 47,
			CONTROL_INVENTORY_RIGHT = 48,
			CONTROL_INVENTORY_UP = 49,
			CONTROL_INVENTORY_DOWN = 50,
			CONTROL_INVENTORY_EXAMINE = 51,
			CONTROL_INVENTORY_USEONSELF = 52,
			CONTROL_INVENTORY_USEONSCENE = 53,
			CONTROL_INVENTORY_DROP = 54,
			CONTROL_PUTSTACK = 55,
			CONTROL_CONTROLLER_ATTACK = 56,
			CONTROL_CONTROLLER_ACTION = 57,
			CONTROL_CONTROLLER_ALTACTION = 58,
			CONTROL_USE_ITEM_ON_ITEM = 59,

			CONTROL_MAP_ZOOM_IN = 60,
			CONTROL_MAP_ZOOM_OUT = 61,

			CONTROL_OPEN_DEBUG_MENU = 62,

			CONTROL_TOGGLE_BROADCASTING = 63,

			CONTROL_SCROLLBACK = 64,
			CONTROL_SCROLLFWD = 65,

			CONTROL_CUSTOM_START = 100;

		#endregion

		#endregion

		public static List<string> BACKEND_PREFABS = new()
		{
			"hud", "forest", "cave", "shipwrecked", "porkland", "volcanolevel",
			"maxwell", "fire", "character_fire", "shatter"
		};
		public static List<string> FRONTEND_PREFABS = new() {"frontend"};
		public static List<string> RECIPE_PREFABS = new();
    
		public static List<String> MAIN_CHARACTER_LIST = new()
		{
			"wilson",
			"willow",
			"wolfgang",
			"wendy",
			"wx78",
			"wickerbottom",
			"woodie",
			"wes",
			"maxwell",
			"wagstaff"
		};
    
		public static List<String> ROG_CHARACTER_LIST = new()
		{
			"wathgrithr",
			"webber"
		};
    
		public static List<String> SHIPWRECKED_CHARACTER_LIST = new()
		{
			"walani"
		};
    
		// REMEMBER THE CONSTANT FILES IN THE OTHER DLCs TOO!!
		public static List<String> PORKLAND_CHARACTER_LIST = new()
		{
			"warbucks",
			"wilba",
			"wormwood"
		};
    
		public static List<String> RETIRED_CHARACTER_LIST = new()
		{
			"warbucks"
		};
    
		public class RECIPE_GAME_TYPE
		{
			public static string
				SHIPWRECKED = "shipwrecked",
				ROG = "rog",
				COMMON = "common",
				VANILLA = "vanilla",
				PORKLAND = "porkland";
		}
    
		public static List<String> MOD_CHARACTER_LIST = new();
    
		// See map_painter.h
		public class GROUND
		{
			public static int
				INVALID = 255,
				IMPASSABLE = 1,

				ROAD = 2,
				ROCKY = 3,
				DIRT = 4,
				SAVANNA = 5,
				GRASS = 6,
				FOREST = 7,
				MARSH = 8,
				WEB = 9,
				WOODFLOOR = 10,
				CARPET = 11,
				CHECKER = 12,

				// CAVES
				CAVE = 13,
				FUNGUS = 14,
				SINKHOLE = 15,
				UNDERROCK = 16,
				MUD = 17,
				BRICK = 18,
				BRICK_GLOW = 19,
				TILES = 20,
				TILES_GLOW = 21,
				TRIM = 22,
				TRIM_GLOW = 23,
				FUNGUSRED = 24,
				FUNGUSGREEN = 25,

				DEEPRAINFOREST = 26, //porkland
				FOUNDATION = 27, //porkland
				COBBLEROAD = 28, //porkland
				LAWN = 29, //porkland

				DECIDUOUS = 30,
				DESERT_DIRT = 31,

				GASJUNGLE = 32, //porkland
				RAINFOREST = 33, //porkland
				INTERIOR = 34, //porkland

				SNAKESKIN = 35,

				FIELDS = 36, //porkland
				SUBURB = 37, //porkland
				PIGRUINS = 38, //porkland
				PIGRUINS_NOCANOPY = 39, //porkland
				BATTLEGROUND = 40, //porkland
				PLAINS = 41, //porkland
				PAINTED = 42, //porkland				

				// SHIPWRECKED
				VOLCANO_ROCK = 43,
				MEADOW = 44,
				BEACH = 45,
				JUNGLE = 46,
				SWAMP = 47,
				FLOOD = 48,
				VOLCANO = 49,
				VOLCANO_LAVA = 50,
				ASH = 51,

				MANGROVE = 52,
				MAGMAFIELD = 53,
				TIDALMARSH = 54,
				OCEAN_SHALLOW = 55,
				OCEAN_MEDIUM = 56,
				OCEAN_DEEP = 57,
				OCEAN_SHORE = 58,
				OCEAN_CORAL = 59,
				OCEAN_CORAL_SHORE = 60,
				MANGROVE_SHORE = 61,
				OCEAN_SHIPGRAVEYARD = 62,
				OCEAN_SHIPGRAVEYARD_SHORE = 63,
				LILYPOND = 64, //porkland

				BEARDRUG = 65, //porkland
				DEEPRAINFOREST_NOCANOPY = 66, //porkland

				// The water tiles in SW need to be higher values than the land tiles 
				// Don't add land tile types greater than 55

				// Noise
				BATTLEGROUND_PLAINS_NOISE = 119, //PORKLAND
				BATTLEGROUND_RAINFOREST_NOISE = 120, //PORKLAND

				JUNGLE_NOISE = 121,
				VOLCANO_NOISE = 122,
				DIRT_NOISE = 123,
				ABYSS_NOISE = 124,
				GROUND_NOISE = 125,
				CAVE_NOISE = 126,
				FUNGUS_NOISE = 127,

				UNDERGROUND = 128,



				WALL_ROCKY = 151,
				WALL_DIRT = 152,
				WALL_MARSH = 153,
				WALL_CAVE = 154,
				WALL_FUNGUS = 155,
				WALL_SINKHOLE = 156,
				WALL_MUD = 157,
				WALL_TOP = 158,
				WALL_WOOD = 159,
				WALL_HUNESTONE = 160,
				WALL_HUNESTONE_GLOW = 161,
				WALL_STONEEYE = 162,
				WALL_STONEEYE_GLOW = 163;
		}
    
		public class Tech
		{
			public int SCIENCE = 0, MAGIC = 0, ANCIENT = 0, OBSIDIAN = 0, HOME = 0, CITY = 0, LOST = 0;
		}
		public class TECH
		{
			public static Tech
				NONE = new() { SCIENCE = 0, MAGIC = 0, ANCIENT = 0, OBSIDIAN = 0, LOST = 0 },
				SCIENCE_ONE = new() { SCIENCE = 1 },
				SCIENCE_TWO = new() { SCIENCE = 2 },
				SCIENCE_THREE = new() { SCIENCE = 3 },
				// Magic starts at level 2 so it's not teased from the start.
				MAGIC_TWO = new() { MAGIC = 2 },
				MAGIC_THREE = new() { MAGIC = 3 },
				ANCIENT_TWO = new() { ANCIENT = 2 },
				ANCIENT_THREE = new() { ANCIENT = 3 },
				ANCIENT_FOUR = new() { ANCIENT = 4 },
				OBSIDIAN_TWO = new() { OBSIDIAN = 2 },
				HOME_TWO = new() { HOME = 2 },
				CITY = new() { CITY = 2 },

				LOST = new() { LOST = 10 };
		}
    
		public class CHARACTER_INGREDIENT
		{
			// NOTE: Value is used as key for NAME string and inventory image
			public static string
				HEALTH = "decrease_health",
				MAX_HEALTH = "half_health",
				SANITY = "decrease_sanity",
				MAX_SANITY = "half_sanity";
		}

		// Character ingredient amounts must be multiples of 5
		public static int CHARACTER_INGREDIENT_SEG = 5;
		
		// See cell_data.h
		public class NODE_INTERNAL_CONNECTION_TYPE
		{
			public static int
				EdgeCentroid = 0,
				EdgeSite = 1,
				EdgeEdgeDirect = 2,
				EdgeEdgeLeft = 3,
				EdgeEdgeRight = 4,
				EdgeData = 5;
		} 
		
		public class CA_SEED_MODE
		{
			public static int
				SEED_RANDOM = 0,
				SEED_CENTROID = 1,
				SEED_SITE = 2,
				SEED_WALLS = 3;
		}
    
		public class RecipeTab
		{
			public string str;
			public int sort;
			public string icon;
        
			public int priority;
			public bool crafting_station = false;

			public bool isReno = false;


			public RecipeTab(){}
			public RecipeTab(string str, int sort, string icon)
			{
				this.str = str;
				this.sort = sort;
				this.icon = icon;
			}
		}
		public class RECIPETABS
		{
			public static RecipeTab TOOLS = new("TOOLS", 0, "tab_tool");
			public static RecipeTab LIGHT = new("LIGHT", 1, "tab_light");
			public static RecipeTab ARCHAEOLOGY = new("ARCHAEOLOGY", 2, "tab_archaeology");
			public static RecipeTab SURVIVAL = new("SURVIVAL", 3, "tab_trap");
			public static RecipeTab NAUTICAL = new("NAUTICAL", 4, "tab_nautical");
			public static RecipeTab FARM = new("FARM", 5, "tab_farm");
			public static RecipeTab SCIENCE = new("SCIENCE", 6, "tab_science");
			public static RecipeTab WAR = new("WAR", 7, "tab_fight");
			public static RecipeTab TOWN = new("TOWN", 8, "tab_build");
			public static RecipeTab REFINE = new("REFINE", 9, "tab_refine");
			public static RecipeTab MAGIC = new("MAGIC", 10, "tab_arcane");
			public static RecipeTab DRESS = new("DRESS", 11, "tab_dress");
        
			// tabs can also go in the multitab CRAFTINGSTATIONS.
			// All are on index 12, priority determines their sorting order in the multitab (0 first)
			public static RecipeTab CRAFTINGSTATIONS = new("CRAFTINGSTATIONS", 12, "tab_crafting"),
				HOME = new()
				{
					str = "HOME", sort = 12, priority = 0, icon = "tab_home_decor.tex", crafting_station = true
				},
				CITY = new()
				{
					str = "CITY", sort = 12, priority = 1, icon = "tab_city.tex", crafting_station = true
				},
				ANCIENT = new()
				{
					str = "ANCIENT", sort = 12, priority = 2,
					icon = "tab_crafting_table.tex", crafting_station = true
				},
				OBSIDIAN = new()
				{
					str = "OBSIDIAN", sort = 12, priority = 3, icon = "tab_obsidian.tex", crafting_station = true
				};
		}
		public class RENO_RECIPETABS
		{
			public static RecipeTab
				DOORS = new() { str = "DOORS", sort = 13, icon = "reno_doors_plate.tex", isReno = true },
				HOME_KITS = new() { str = "HOME KITS", sort = 14, icon = "reno_tab_homekits.tex", isReno = true },
				CHAIRS = new() { str = "CHAIRS", sort = 15, icon = "reno_tab_chairs.tex", isReno = true },
				SHELVES = new() { str = "SHELVES", sort = 16, icon = "reno_tab_shelves.tex", isReno = true },
				RUGS = new() { str = "RUGS", sort = 17, icon = "reno_tab_rugs.tex", isReno = true },
				LAMPS = new() { str = "LAMPS", sort = 18, icon = "reno_tab_lamps.tex", isReno = true },
				PLANT_HOLDERS = new() { str = "PLANT HOLDERS", sort = 19, icon = "reno_tab_plantholders.tex", isReno = true },
				TABLES = new() { str = "TABLES", sort = 20, icon = "reno_tab_tables.tex", isReno = true },
				ORNAMENTS = new() { str = "ORNAMENTS", sort = 21, icon = "reno_tab_ornaments.tex", isReno = true },
				WINDOWS = new() { str = "WINDOWS", sort = 22, icon = "reno_tab_windows.tex", isReno = true },
				COLUMNS = new() { str = "COLUMNS", sort = 23, icon = "reno_tab_columns.tex", isReno = true },
				FLOORING = new() { str = "FLOORING", sort = 24, icon = "reno_tab_floors.tex", isReno = true },
				WALLPAPER = new() { str = "WALL PAPER", sort = 25, icon = "reno_tab_wallpaper.tex", isReno = true },
				HANGING_LAMPS = new() { str = "HANGING LAMPS", sort = 26, icon = "reno_tab_hanginglamps.tex", isReno = true };
		}
    
		public enum VERBOSITY
		{
			ERROR = 0,
			WARNING = 1,
			INFO = 2,
			DEBUG = 3
		}
		
		public enum RenderQuality
		{
			Low = 0,
			Default = 1,
			High = 2
		}
    
		public class BG_LOADING_IMAGES
		{
			public static List<string> MAIN_GAME = new()
			{
				"loading_wagstaff",
				"loading_maxwell",
				"loading_newhorizons",
				"loading_wendy",
				"loading_wickerbottom",
				"loading_wolfgang",
				"loading_woodie2_trailer",
				"loading_woodie_trailer",
				"loading_night",
			};

			public static List<List<string>> DLCS = new()
			{
				new List<string> //RoG
				{
					"loading_webber",
					"loading_wigfrid",
				},
				new List<string> //SW
				{
					"loading_ballphins",
					"loading_volcano",
					"loading_warly",
					"loading_wilson_boat",
					"loading_wilson_escape",
					"loading_wilson_seamonster",
				},
				new List<string> //HAM
				{
					"loading_aporkalypse",
					"loading_ironlord",
					"loading_citypigs",
					"loading_werewilba",
					"loading_wheeler",
					"loading_wilson_E3",
					"loading_wormwood2_trailer",
					"loading_wormwood_trailer",
				}
			};
		}

		public class BGCOLOURS
		{
			public static float[]
				RED = { 255 / 255f, 89 / 255f, 46 / 255f },
				PURPLE = { 184 / 255f, 87 / 255f, 198 / 255f },
				YELLOW = { 255 / 255f, 196 / 255f, 45 / 255f },
				TEAL = { 80 / 255f, 193 / 255f, 204 / 255f },
				GREEN = { 87 / 255f, 164 / 255f, 86 / 255f };
		}
    
		public class RESET_ACTION
		{
			public static string
				LOAD_FRONTEND = "0",
				LOAD_SLOT = "1",
				DO_DEMO = "2";
		}

		public static int NUM_SAVE_SLOTS = 10;
    
		// Mirrors enum in SystemService.h
		public enum LANGUAGE
		{
			ENGLISH = 0,
			ENGLISH_UK = 1,
			FRENCH = 2,
			FRENCH_CA = 3,
			SPANISH = 4,
			SPANISH_LA = 5,
			GERMAN = 6,
			ITALIAN = 7,
			PORTUGUESE = 8,
			PORTUGUESE_BR = 9,
			DUTCH = 10,
			FINNISH = 11,
			SWEDISH = 12,
			DANISH = 13,
			NORWEGIAN = 14,
			POLISH = 15,
			RUSSIAN = 16,
			TURKISH = 17,
			ARABIC = 18,
			KOREAN = 19,
			JAPANESE = 20,
			CHINESE_T = 21,
			CHINESE_S = 22,
			CHINESE_S_RAIL = 23,
        
			Null
		}
	}
}