using System.Collections.Generic;

namespace DYT.Map.levels
{
	public class Substitute
	{
		public float perstory;
		public float pertask;
		public int weight;
	}
	
    public class AdventureLevels
    {
        public static int CAMPAIGN_LENGTH = 5;
        
        private static Dictionary<string, Substitute> SUBS_1 = new()
        {
	        ["evergreen"] = { perstory = 0.5f, pertask = 1, weight = 1 },
	        ["evergreen_short"] = { perstory = 1, pertask = 1, weight = 1 },
	        ["evergreen_normal"] = { perstory = 1, pertask = 1, weight = 1 },
	        ["evergreen_tall"] = { perstory = 1, pertask = 1, weight = 1 },
	        ["sapling"] = { perstory = 0.6f, pertask = 0.95f, weight = 1 },
	        ["beefalo"] = { perstory = 1, pertask = 1, weight = 1 },
	        ["rabbithole"] = { perstory = 1, pertask = 1, weight = 1 },
	        ["rock1"] = { perstory = 0.3f, pertask = 1, weight = 1 },
	        ["rock2"] = { perstory = 0.5f, pertask = 0.8f, weight = 1 },
	        ["grass"] = { perstory = 0.5f, pertask = 0.9f, weight = 1 },
	        ["flint"] = { perstory = 0.5f, pertask = 1, weight = 1 },
	        ["spiderden"] = { perstory = 1, pertask = 1, weight = 1 },
        };

        
        static AdventureLevels()
        {
            //----------------------------------
            //-- Adventure levels
            //----------------------------------
            Levels.AddLevel(LEVELTYPE.ADVENTURE, new Level
            {
	            id = "RAINY", //-- A Cold Reception
	            name = STRINGS.UI.SANDBOXMENU.ADVENTURELEVELS[1],
	            min_playlist_position = 1,
	            max_playlist_position = 3,
	            overrides =
	            {
		            { "world_size", "default" },
		            { "day", "longdusk" },
		            { "weather", "squall" },
		            { "weather_start", "wet" },
		            { "frograin", "often" },

		            { "start_setpeice", "WinterStartEasy" },
		            { "start_node", "Forest" },

		            { "season", "autumn" },
		            { "season_start", "autumn" },

		            { "deerclops", "never" },
		            { "bearger", "never" },
		            { "dragonfly", "never" },
		            { "goosemoose", "never" },
		            { "hounds", "never" },
		            { "mactusk", "always" },
		            { "leifs", "always" },

		            { "trees", "often" },
		            { "carrot", "default" },
		            { "berrybush", "never" },
	            },
	            substitutes = GetRandomSubstituteList(SUBS_1, 3),
	            tasks =
	            {
		            "Make a pick",
		            "Easy Blocked Dig that rock",
		            "Great Plains",
		            "Guarded Speak to the king",
	            },
	            numoptionaltasks = 4,
	            optionaltasks =
	            {
		            "Waspy Beeeees!",
		            "Guarded Squeltch",
		            "Guarded Forest hunters",
		            "Befriend the pigs",
		            "Guarded For a nice walk",
		            "Walled Kill the spiders",
		            "Killer bees!",
		            "Make a Beehat",
		            "Waspy The hunters",
		            "Hounded Magic meadow",
		            "Wasps and Frogs and bugs",
		            "Guarded Walrus Desolate",
	            },
	            set_pieces =
	            {
		            ["WesUnlock"] =
		            {
			            restrict_to = "background", tasks =
			            {
				            "Easy Blocked Dig that rock",
				            "Great Plains",
				            "Guarded Speak to the king",
				            "Waspy Beeeees!",
				            "Guarded Squeltch",
				            "Guarded Forest hunters",
				            "Befriend the pigs",
				            "Guarded For a nice walk",
				            "Walled Kill the spiders",
				            "Killer bees!",
				            "Make a Beehat",
				            "Waspy The hunters",
				            "Hounded Magic meadow",
				            "Wasps and Frogs and bugs",
				            "Guarded Walrus Desolate"
			            }
		            },
		            ["ResurrectionStoneWinter"] =
		            {
			            count = 1, tasks =
			            {
				            "Make a pick",
				            "Easy Blocked Dig that rock",
				            "Great Plains",
				            "Guarded Speak to the king",
				            "Waspy Beeeees!",
				            "Guarded Squeltch",
				            "Guarded Forest hunters",
				            "Befriend the pigs",
				            "Guarded For a nice walk",
				            "Walled Kill the spiders",
				            "Killer bees!",
				            "Make a Beehat",
				            "Waspy The hunters",
				            "Hounded Magic meadow",
				            "Wasps and Frogs and bugs",
				            "Guarded Walrus Desolate"
			            }
		            },
	            },
	            ordered_story_setpieces =
	            {
		            "TeleportatoRingLayout",
		            "TeleportatoBoxLayout",
		            "TeleportatoCrankLayout",
		            "TeleportatoPotatoLayout",
		            "TeleportatoBaseAdventureLayout",
	            },
	            required_prefabs =
	            {
		            "teleportato_ring", "teleportato_box", "teleportato_crank", "teleportato_potato",
		            "teleportato_base", "chester_eyebone"
	            },
            });
            Levels.AddLevel(LEVELTYPE.ADVENTURE, new Level
            {
	            id = "WINTER",
	            name = STRINGS.UI.SANDBOXMENU.ADVENTURELEVELS[2],
	            min_playlist_position = 1,
	            max_playlist_position = 4,
	            overrides =
	            {
		            //--{"world_size", 		"medium"},
		            { "day", "longdusk" },

		            { "start_setpeice", "WinterStartMedium" },
		            { "start_node", "Clearing" },

		            { "loop", "never" },
		            { "branching", "least" },

		            { "season", "onlywinter" },
		            { "season_start", "winter" },
		            { "weather", new List<string> { "always", "often" } },

		            { "deerclops", "often" },
		            { "bearger", "never" },
		            { "dragonfly", "never" },
		            { "goosemoose", "never" },
		            { "hounds", "never" },
		            { "mactusk", "always" },

		            { new List<string> { "carrot", "berrybush" }, new List<string> { "never", "rare" } },
	            },
	            substitutes = GetRandomSubstituteList(SUBS_1, 1),
	            tasks =
	            {
		            "Resource-rich Tier2",
		            "Sanity-Blocked Great Plains",
		            "Hounded Greater Plains",
		            "Insanity-Blocked Necronomicon",
	            },
	            numoptionaltasks = 2,
	            optionaltasks =
	            {
		            "Walrus Desolate",
		            "Walled Kill the spiders",
		            "The Deep Forest",
		            "Forest hunters",
	            },
	            set_pieces =
	            {
		            ["WesUnlock"] =
		            {
			            restrict_to = "background", tasks =
			            {
				            "Hounded Greater Plains", "Walrus Desolate", "Walled Kill the spiders",
				            "The Deep Forest", "Forest hunters"
			            }
		            },
		            ["MacTuskTown"] =
		            {
			            tasks =
			            {
				            "Insanity-Blocked Necronomicon", "Hounded Greater Plains", "Sanity-Blocked Great Plains"
			            }
		            },
		            ["ResurrectionStoneWinter"] =
		            {
			            count = 1, tasks =
			            {
				            "Resource-rich Tier2",
				            "Sanity-Blocked Great Plains",
				            "Hounded Greater Plains",
				            "Insanity-Blocked Necronomicon",
				            "Walrus Desolate",
				            "Walled Kill the spiders",
				            "The Deep Forest",
				            "Forest hunters"
			            }
		            },
	            },
	            ordered_story_setpieces =
	            {
		            "TeleportatoRingLayout",
		            "TeleportatoBoxLayout",
		            "TeleportatoCrankLayout",
		            "TeleportatoPotatoLayout",
		            "TeleportatoBaseAdventureLayout",
	            },
	            required_prefabs =
	            {
		            "teleportato_ring", "teleportato_box", "teleportato_crank", "teleportato_potato",
		            "teleportato_base", "chester_eyebone"
	            },
            });
			//-- Weather: start with very short winter, then endless summer.
			Levels.AddLevel(LEVELTYPE.ADVENTURE, new Level
			{
				id = "HUB",
				name = STRINGS.UI.SANDBOXMENU.ADVENTURELEVELS[3],
				min_playlist_position = 1,
				max_playlist_position = 4,
				overrides =
				{
					//--{"world_size", 		"medium"},
					{ "day", "longdusk" },

					{ "start_setpeice", "PreSummerStart" },
					{ "start_node", "Clearing" },

					{
						"season", "preonlysummer"
					}, //--The world begins in winter, and will turn to endless spring (summer in vanilla) after 10 days
					{ "season_start", "winter" },
					{ "spiders", "often" },

					{ "branching", "default" },
					{ "loop", "never" },

					{ "bearger", "never" },
					{ "dragonfly", "never" },
					{ "goosemoose", "never" },
					{ "deerclops", "never" },

				},
				substitutes = GetRandomSubstituteList(SUBS_1, 3),
				//-- Enemies: Lots of hound mounds and maxwell traps everywhere. Frequent hound invasions.
				tasks =
				{
					"Resource-Rich",
					"Lots-o-Spiders",
					"Lots-o-Tentacles",
					"Lots-o-Tallbirds",
					"Lots-o-Chessmonsters",
				},
				numoptionaltasks = 4,
				optionaltasks =
				{
					"The hunters",
					"Trapped Forest hunters",
					"Wasps and Frogs and bugs",
					"Tentacle-Blocked The Deep Forest",
					"Hounded Greater Plains",
					"Merms ahoy",
				},
				set_pieces =
				{
					["SimpleBase"] =
						{ tasks = { "Lots-o-Spiders", "Lots-o-Tentacles", "Lots-o-Tallbirds", "Lots-o-Chessmonsters" } },
					["WesUnlock"] =
					{
						restrict_to = "background",
						tasks =
						{
							"The hunters", "Trapped Forest hunters", "Wasps and Frogs and bugs",
							"Tentacle-Blocked The Deep Forest", "Hounded Greater Plains", "Merms ahoy"
						}
					},
					["ResurrectionStone"] =
					{
						count = 1, tasks =
						{
							"Resource-Rich",
							"Lots-o-Spiders",
							"Lots-o-Tentacles",
							"Lots-o-Tallbirds",
							"Lots-o-Chessmonsters", "The hunters",
							"Trapped Forest hunters",
							"Wasps and Frogs and bugs",
							"Tentacle-Blocked The Deep Forest",
							"Hounded Greater Plains",
							"Merms ahoy"
						}
					},
				},
				ordered_story_setpieces =
				{
					"TeleportatoRingLayout",
					"TeleportatoBoxLayout",
					"TeleportatoCrankLayout",
					"TeleportatoPotatoLayout",
					"TeleportatoBaseAdventureLayout",
				},
				required_prefabs =
				{
					"teleportato_ring", "teleportato_box", "teleportato_crank", "teleportato_potato", "teleportato_base",
					"chester_eyebone"
				},
			});
			Levels.AddLevel(LEVELTYPE.ADVENTURE, new Level
			{
				id = "ISLANDHOP",
				name = STRINGS.UI.SANDBOXMENU.ADVENTURELEVELS[4],
				min_playlist_position = 1,
				max_playlist_position = 4,
				overrides =
				{
					{ "islands", "always" },
					{ "roads", "never" },
					{ "start_node", "BGGrass" },
					{ "season_start", "autumn" },
					{ "season_mode", "classic" },
					{ "start_setpeice", "ThisMeansWarStart" },
					{ "weather", new List<string> { "rare", "default", "often" } },
					{ "bearger", "never" },
					{ "dragonfly", "never" },
					{ "goosemoose", "never" },
				},
				substitutes = GetRandomSubstituteList(SUBS_1, 3),
				tasks =
				{
					"IslandHop_Start",
					"IslandHop_Hounds",
					"IslandHop_Forest",
					"IslandHop_Savanna",
					"IslandHop_Rocky",
					"IslandHop_Merm",
				},
				numoptionaltasks = 0,
				optionaltasks =
				{
				},
				set_pieces =
				{
					["WesUnlock"] =
					{
						restrict_to = "background",
						tasks =
						{
							"IslandHop_Start", "IslandHop_Hounds", "IslandHop_Forest", "IslandHop_Savanna",
							"IslandHop_Rocky", "IslandHop_Merm"
						}
					},
				},
				ordered_story_setpieces =
				{
					"TeleportatoRingLayout",
					"TeleportatoBoxLayout",
					"TeleportatoCrankLayout",
					"TeleportatoPotatoLayout",
					"TeleportatoBaseAdventureLayout",
				},
				required_prefabs =
				{
					"teleportato_ring", "teleportato_box", "teleportato_crank", "teleportato_potato",
					"teleportato_base", "chester_eyebone"
				},
			});
			Levels.AddLevel(LEVELTYPE.ADVENTURE, new Level
			{
				id = "TWOLANDS",
				name = STRINGS.UI.SANDBOXMENU.ADVENTURELEVELS[5],
				override_level_string = true,
				min_playlist_position = 3,
				max_playlist_position = 4,
				overrides =
				{
					//--{"world_size", 		"medium"},
					{ "day", "longday" },
					{ "season", "onlysummer" },
					{ "season_start", "autumn" },

					{ "islands", "always" },
					{ "roads", "never" },

					{ "start_setpeice", "BargainStart" },
					{ "start_node", "Clearing" },

					{ "bearger", "never" },
					{ "dragonfly", "never" },
					{ "goosemoose", "never" },

				},
				substitutes = GetRandomSubstituteList(SUBS_1, 3),
				tasks =
				{
					//-- Part 1 - Easy peasy - lots of stuff
					"Land of Plenty",

					//-- Part 2 - Lets kill them off
					"The other side",
				},
				override_triggers =
				{
					["START"] =
					{
						//-- Quick (localised) fix for area-aware bug #677
						new List<string> { "weather", "never" },
						new List<string> { "day", "longday" },
					},
					["Land of Plenty"] =
					{
						new List<string> { "weather", "never" },
						new List<string> { "day", "longday" },
					},
					["The other side"] =
					{
						new List<string> { "weather", "often" },
						new List<string> { "day", "longdusk" },
					},
				},
				set_pieces =
				{
					["MaxPigShrine"] = { tasks = { "Land of Plenty" } },
					["MaxMermShrine"] = { tasks = { "The other side" } },
					["ResurrectionStone"] = { count = 2, tasks = { "Land of Plenty", "The other side" } },
				},
				ordered_story_setpieces =
				{
					"TeleportatoRingLayout",
					"TeleportatoBoxLayout",
					"TeleportatoCrankLayout",
					"TeleportatoPotatoLayout",
					"TeleportatoBaseAdventureLayout",
				},
				required_prefabs =
				{
					"teleportato_ring", "teleportato_box", "teleportato_crank", "teleportato_potato",
					"teleportato_base", "chester_eyebone"
				},
			});

			Levels.AddLevel(LEVELTYPE.ADVENTURE, new Level
			{
				id = "DARKNESS",
				name = STRINGS.UI.SANDBOXMENU.ADVENTURELEVELS[6],
				min_playlist_position = CAMPAIGN_LENGTH,
				max_playlist_position = CAMPAIGN_LENGTH,
				overrides =
				{
					{ "branching", "never" },
					{ "day", "onlynight" },
					{ "season_start", "autumn" },
					{ "season", "onlysummer" },
					{ "weather", "often" }, //-- always

					{ "boons", "always" },

					{ "roads", "never" },
					//--{"carrot", 			"rare"},
					{ "berrybush", "never" },
					{ "spiders", "often" },

					{ "fireflies", "always" },

					{ "start_setpeice", "NightmareStart" }, //--ThisMeansWarStart"},
					{ "start_node", "BGGrass" },

					{ "maxwelllight_area", "always" },
					{ "bearger", "never" },
					{ "dragonfly", "never" },
					{ "goosemoose", "never" },

				},
				substitutes = Util.MergeMaps(
					new Dictionary<string, Substitute> { ["pighouse"] = { perstory = 1, weight = 1, pertask = 1 } },
					GetRandomSubstituteList(SUBS_1, 3)),
				tasks =
				{
					"Swamp start",
					"Battlefield",
					"Walled Kill the spiders",
					"Sanity-Blocked Spider Queendom",
				},
				numoptionaltasks = 2,
				optionaltasks =
				{
					"Killer Bees!",
					"Chessworld",
					"Tentacle-Blocked The Deep Forest",
					"Tentacle-Blocked Spider Swamp",
					"Trapped Forest hunters",
					"Waspy The hunters",
					"Hounded Magic meadow",
				},
				//-- override_triggers = {
				//-- 	[5] = {	
				//-- 		{"season", 		"onlywinter"},
				//-- 		{"season_start","winter"}, 
				//-- 		{"weather", 	"always"},
				//-- 		{"day", 		"onlynight"}, 
				//-- 		--{"start_setpeice", 	"PermaWinterNight"},
				//-- 	},
				//--},	
				set_pieces =
				{
					["RuinedBase"] =
						{ tasks = { "Swamp start", "Battlefield", "Walled Kill the spiders", "Killer Bees!" } },
					["ResurrectionStoneLit"] =
					{
						count = 4, tasks =
						{
							"Swamp start", "Battlefield", "Walled Kill the spiders", "Sanity-Blocked Spider Queendom",
							"Killer Bees!",
							"Chessworld",
							"Tentacle-Blocked The Deep Forest",
							"Tentacle-Blocked Spider Swamp",
							"Trapped Forest hunters",
							"Waspy The hunters",
							"Hounded Magic meadow",
						}
					},
				},
				ordered_story_setpieces =
				{
					"TeleportatoRingLayout",
					"TeleportatoBoxLayout",
					"TeleportatoCrankLayout",
					"TeleportatoPotatoLayout",
					"TeleportatoBaseAdventureLayout",
				},
				required_prefabs =
				{
					"teleportato_ring", "teleportato_box", "teleportato_crank", "teleportato_potato",
					"teleportato_base", "chester_eyebone"
				},
			});
			Levels.AddLevel(LEVELTYPE.ADVENTURE, new Level
			{
				id = "ENDING",
				name = STRINGS.UI.SANDBOXMENU.ADVENTURELEVELS[7],
				nomaxwell = true,
				min_playlist_position =
					CAMPAIGN_LENGTH +
					1, //-- IMPORTANT! This should be the only level allowed to play after the campaign
				max_playlist_position = CAMPAIGN_LENGTH + 1,
				overrides =
				{
					{ "day", "onlynight" },
					{ "season", "onlysummer" },
					{ "weather", "never" },
					{ "creepyeyes", "always" },
					{ "waves", "off" },
					{ "boons", "never" },
					{ "bearger", "never" },
					{ "dragonfly", "never" },
					{ "goosemoose", "never" },
					{ "hounds", "never" }
				},
				tasks =
				{
					"MaxHome",
				},
				numoptionaltasks = 0,
				hideminimap = true,
				teleportaction = "restart",
				teleportmaxwell = "ADVENTURE_6_TELEPORTFAIL",

				optionaltasks =
				{
				},
				override_triggers =
				{
					["MaxHome"] =
					{
						new List<string> { "areaambient", "VOID" },
					},
				},
			});
        }

        
        private static Dictionary<string, Substitute> GetRandomSubstituteList(
	        Dictionary<string, Substitute> substitutes, int  num_choices)
        {
	        Dictionary<string, Substitute> subs = new();
	        Dictionary<string, int> list = new();
	        
	        foreach ((string key, Substitute value) in substitutes)
	        {
		        list.TryAdd(key, value.weight);
		        list[key] = value.weight;
	        }

	        for (int i = 0; i < num_choices; i++)
	        {
		        string choice = Util.weighted_random_choice(list);
		        list.Remove(choice);
		        subs.Add(choice, substitutes[choice]);
	        }

	        return subs;
        }
    }
}