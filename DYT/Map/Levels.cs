using System.Collections.Generic;
using DYT.Map.levels;

namespace DYT.Map
{
    public class Levels
    {
        public static List<Level> story_levels = levellist[LEVELTYPE.ADVENTURE];
        public static List<Level> sandbox_levels = levellist[LEVELTYPE.SURVIVAL];
        public static List<Level> cave_levels = levellist[LEVELTYPE.CAVE];
        public static Level test_level;
        public static List<Level> custom_levels = levellist[LEVELTYPE.CUSTOM];
        public static List<Level> volcano_levels = levellist[LEVELTYPE.VOLCANO];
        public static List<Level> shipwrecked_levels = levellist[LEVELTYPE.SHIPWRECKED];
        public static List<Level> porkland_levels = levellist[LEVELTYPE.PORKLAND];
        public static int CAMPAIGN_LENGTH = AdventureLevels.CAMPAIGN_LENGTH;
        
        private static Dictionary<int, List<Level>> levellist = new()
        {
            [LEVELTYPE.SURVIVAL] = {Capacity = 0},
            [LEVELTYPE.CAVE] = {Capacity = 0},
            [LEVELTYPE.ADVENTURE] = {Capacity = 0},
            [LEVELTYPE.TEST] = {Capacity = 0},
            [LEVELTYPE.CUSTOM] = {Capacity = 0},
            [LEVELTYPE.VOLCANO] = {Capacity = 0},
            [LEVELTYPE.SHIPWRECKED] = {Capacity = 0},
            [LEVELTYPE.PORKLAND] = {Capacity = 0},
        };


        static Levels()
        {
            new AdventureLevels();
            new CaveLevels();
            new SurvivalLevels();
            new VolcanoLevels();
            new ShipwreckedLevels();
            new PorklandLevels();
            
            AddLevel(LEVELTYPE.TEST, new Level
            {
                name = "TEST_LEVEL",
                id = "TEST",
                overrides =
                {
                    { "world_size", "tiny" },
                    { "day", "onlynight" },
                    { "waves", "off" },
                    { "location", "cave" },
                    { "boons", "never" },
                    { "poi", "never" },
                    { "traps", "never" },
                    { "protected", "never" },
                    { "start_setpeice", "CaveStart" },
                    { "start_node", "BGSinkholeRoom" },
                },
                tasks =
                {
                    "CavesStart",
                    "CavesAlternateStart",
                    "FungalBatCave",
                    "BatCaves",
                    "TentacledCave",
                    "LargeFungalComplex",
                    "SingleBatCaveTask",
                    "RabbitsAndFungs",
                    "FungalPlain",
                    "Cavern",
                },
                numoptionaltasks = 1,
                optionaltasks =
                {
                    "CaveBase",
                    "MushBase",
                    "SinkBase",
                    "RabbitTown",
                },
                override_triggers =
                {
                    //-- ["RuinsStart"] = {	
                    //-- 	{"SeasonColourCube", "caves"}, 
                    //-- 	-- {"SeasonColourCube", SEASONS.CAVES}, 
                    //-- },
                    //-- ["TheLabyrinth"] = {	
                    //-- 	{"SeasonColourCube", "caves_ruins"}, 
                    //-- 	-- {"SeasonColourCube", 	{	DAY = "images/colour_cubes/ruins_light_cc.tex",
                    //-- 	-- 							DUSK = "images/colour_cubes/ruins_dim_cc.tex",
                    //-- 	-- 							NIGHT = "images/colour_cubes/ruins_dark_cc.tex",
                    //-- 	-- 						},
                    //-- 					-- }, 
                    //-- },
                    //-- ["CityInRuins"] = {	
                    //-- 	{"SeasonColourCube", "caves_ruins"}, 
                    //-- 	-- {"SeasonColourCube", 	{	DAY = "images/colour_cubes/ruins_light_cc.tex",
                    //-- 	-- 							DUSK = "images/colour_cubes/ruins_dim_cc.tex",
                    //-- 	-- 							NIGHT = "images/colour_cubes/ruins_dark_cc.tex",
                    //-- 	-- 						},
                    //-- 	-- 				},
                    //-- },
                },
            });
            
            //--free_level=levellist[LEVELTYPE.SURVIVAL][1],
            test_level = levellist[LEVELTYPE.TEST][1];
        }


        public static void AddLevel(int type, Level data)
        {
            levellist[type].Add(new Level(data));
        }
    
        public static int GetTypeForLevelID(string id)
        {
            if (id == null || id == "unknown") return LEVELTYPE.UNKNOWN;
        
            foreach (int levelListKey in levellist.Keys)
            {
                foreach (Level level in levellist[levelListKey])
                {
                    if (level.id == id) return levelListKey;
                }
            }
        
            return LEVELTYPE.UNKNOWN;
        }
    }
}