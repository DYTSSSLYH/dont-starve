using System.Collections.Generic;

public class Levels
{
    private static Dictionary<Level.LevelType, List<Level>> levelList =
        new Dictionary<Level.LevelType, List<Level>> {
            {Level.LevelType.Survival, new List<Level> {
                new Level("SURVIVAL_DEFAULT", "Default",
                    "The standard Don't Starve experience", new Dictionary<string, string> {
                        {"start_setpeice", "DefaultStart"},
                        {"start_node", "Clearing"},
                        {"season_start", "autumn"},
                        {"spring", "no_season"},
                        {"summer", "no_season"}
                    }
                ),
                new Level("SURVIVAL_DEFAULT_PLUS", "Default Plus",
                    "A quicker start in a harsher world.", new Dictionary<string, string> {
                        {"start_setpeice", "DefaultStart"},
                        {"start_node", "Clearing"},
                        {"boons", "often"},
                        {"spiders", "often"},
                        {"berry_bush", "rare"},
                        {"carrot", "rare"},
                        {"rabbits", "rare"}
                    }
                ),
                new Level("COMPLETE_DARKNESS", "Lights Out",
                    "A dark twist on the standard Don't Starve experience.", new Dictionary<string, string> {
                        {"start_setpeice", "DarknessStart"},
                        {"start_node", "Clearing"},
                        {"day", "only_night"}
                    }
                )
            }},
            {Level.LevelType.ReginOfGiants, new List<Level> {
                new Level("SURVIVAL_DEFAULT", "Default",
                    "The standard Don't Starve experience", new Dictionary<string, string> {
                        {"start_setpeice", "DefaultStart"},
                        {"start_node", "Clearing"}
                    }
                ),
                new Level("SURVIVAL_DEFAULT_PLUS", "Default Plus",
                    "A quicker start in a harsher world.", new Dictionary<string, string> {
                        {"start_setpeice", "DefaultPlusStart"},
                        {"boons", "often"},
                        {"spiders", "often"},
                        {"berry_bush", "rare"},
                        {"carrot", "rare"},
                        {"rabbits", "rare"}
                    }
                ),
                new Level("COMPLETE_DARKNESS", "Lights Out",
                    "A dark twist on the standard Don't Starve experience.", new Dictionary<string, string> {
                        {"start_setpeice", "DarknessStart"},
                        {"day", "only_night"}
                    }
                )
            }},
            {Level.LevelType.Shipwrecked, new List<Level> {
                new Level("SHIPWRECKED_DEFAULT", "Shipwrecked",
                    "A tropical paradise?", new Dictionary<string, string> {
                        {"start_setpeice", "ShipwreckedStart"},
                        {"start_node", "BeachSand"},
                        {"start_task", "HomeIsland"},
                        {"location", "shipwrecked"},
                        {"roads", "never"},
                        {"loop", "never"},
                        {"poi", "never"},
                        {"world_size", "default"}
                    }
                )
            }},
            {Level.LevelType.Hamlet, new List<Level> {
                new Level("PORKLAND_DEFAULT", "Default",
                    "The standard Don't Starve experience", new Dictionary<string, string> {
                        {"roads", "never"},
                        {"start_setpeice", "PorklandStart"},
                        {"start_node", "BG_rainforest_base"},
                        {"spring", "no_season"},
                        {"summer", "no_season"},
                        {"branching", "least"},
                        {"location", "porkland"}
                    }
                )
            }},
            {Level.LevelType.Cave, new List<Level>()},
            {Level.LevelType.Adventure, new List<Level>()},
            {Level.LevelType.Volcano, new List<Level>()},
            {Level.LevelType.Test, new List<Level>()},
            {Level.LevelType.Custom, new List<Level>()}
        };
    
    public static List<Level> sandboxLevels = levelList[Level.LevelType.Survival];
    public static List<Level> reginOfGiantsLevels = levelList[Level.LevelType.ReginOfGiants];
    public static List<Level> shipwreckedLevels = levelList[Level.LevelType.Shipwrecked];
    public static List<Level> hamletLevels = levelList[Level.LevelType.Hamlet];
    
    
    public static Level.LevelType GetTypeForLevelID(string id)
    {
        if (id == null || id == "unknown") return Level.LevelType.Unknown;
        
        foreach (Level.LevelType levelListKey in levelList.Keys)
        {
            foreach (Level level in levelList[levelListKey])
            {
                if (level.id == id) return levelListKey;
            }
        }
        
        return Level.LevelType.Unknown;
    }
}