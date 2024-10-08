﻿using System.Collections.Generic;

namespace DYT.Map.levels
{
    public class SurvivalSwLevels
    {
        static SurvivalSwLevels()
        {
            //----------------------------------
			//-- Survival levels
			//----------------------------------

			Levels.AddLevel(LEVELTYPE.SURVIVAL, new Level
			{
				id = "SURVIVAL_DEFAULT",
				name = STRINGS.UI.CUSTOMIZATIONSCREEN.PRESETLEVELS[1],
				desc = STRINGS.UI.CUSTOMIZATIONSCREEN.PRESETLEVELDESC[1],
				overrides =
				{
					{ "start_setpeice", "DefaultStart" },
					{ "start_node", "Clearing" },
				},
				tasks =
				{
					"Make a pick",
					"Dig that rock",
					"Great Plains",
					"Squeltch",
					"Beeeees!",
					"Speak to the king",
					"Forest hunters",
					"Badlands",
				},
				numoptionaltasks = 4,
				optionaltasks =
				{
					"Befriend the pigs",
					"For a nice walk",
					"Kill the spiders",
					"Killer bees!",
					"Make a Beehat",
					"The hunters",
					"Magic meadow",
					"Frogs and bugs",
					"Oasis",
					"Mole Colony Deciduous",
					"Mole Colony Rocks",
				},
				set_pieces =
				{
					["ResurrectionStone"] =
					{
						count = 2,
						tasks =
						{
							"Make a pick", "Dig that rock", "Great Plains", "Squeltch", "Beeeees!", "Speak to the king",
							"Forest hunters", "Badlands",
						}
					},
					["WormholeGrass"] =
					{
						count = 8,
						tasks =
						{
							"Make a pick", "Dig that rock", "Great Plains", "Squeltch", "Beeeees!", "Speak to the king",
							"Forest hunters", "Befriend the pigs", "For a nice walk", "Kill the spiders",
							"Killer bees!", "Make a Beehat", "The hunters", "Magic meadow", "Frogs and bugs",
							"Badlands",
						}
					},
					//--["ShipwreckedEntrance"] = { count=1, tasks={"Make a pick", "Dig that rock", "Great Plains", "Squeltch", "Beeeees!", "Speak to the king", "Forest hunters", "Badlands", } },
				},

				numrandom_set_pieces = 5,
				random_set_pieces =
				{
					"Chessy_1",
					"Chessy_2",
					"Chessy_3",
					"Chessy_4",
					"Chessy_5",
					"Chessy_6",
					"ChessSpot1",
					"ChessSpot2",
					"ChessSpot3",
					"Maxwell1",
					"Maxwell2",
					"Maxwell3",
					"Maxwell4",
					"Maxwell5",
					"Maxwell6",
					"Maxwell7",
					"Warzone_1",
					"Warzone_2",
					"Warzone_3",
				},

				ordered_story_setpieces =
				{
					"TeleportatoRingLayout",
					"TeleportatoBoxLayout",
					"TeleportatoCrankLayout",
					"TeleportatoPotatoLayout",
					"AdventurePortalLayout",
					"TeleportatoBaseLayout",
				},
				required_prefabs =
				{
					"teleportato_ring", "teleportato_box", "teleportato_crank", "teleportato_potato",
					"teleportato_base", "chester_eyebone", "adventure_portal", "pigking",
				},
			});

			if (Main.PLATFORM == "PS4")
			{
				//-- boons and spiders at default values rather than "often"
				Levels.AddLevel(LEVELTYPE.SURVIVAL, new Level
				{
					id = "SURVIVAL_DEFAULT_PLUS",
					name = STRINGS.UI.CUSTOMIZATIONSCREEN.PRESETLEVELS[2],
					desc = STRINGS.UI.CUSTOMIZATIONSCREEN.PRESETLEVELDESC[2],
					overrides =
					{
						{ "start_setpeice", "DefaultPlusStart" },
						{
							"start_node",
							new List<string> { "DeepForest", "Forest", "SpiderForest", "Plain", "Rocky", "Marsh" }
						},
						{ "berrybush", "rare" },
						{ "carrot", "rare" },
						{ "rabbits", "rare" },


					},
					tasks =
					{
						"Make a pick",
						"Dig that rock",
						"Great Plains",
						"Squeltch",
						"Beeeees!",
						"Speak to the king",
						"Tentacle-Blocked The Deep Forest",
						"Badlands",
					},
					numoptionaltasks = 4,
					optionaltasks =
					{
						"Forest hunters",
						"Befriend the pigs",
						"For a nice walk",
						"Kill the spiders",
						"Killer bees!",
						"Make a Beehat",
						"The hunters",
						"Magic meadow",
						"Hounded Greater Plains",
						"Merms ahoy",
						"Frogs and bugs",
						"Oasis",
						"Mole Colony Deciduous",
						"Mole Colony Rocks",
					},
					set_pieces =
					{
						["ResurrectionStone"] = { count = 2, tasks = { "Speak to the king", "Forest hunters" } },
						["WormholeGrass"] =
						{
							count = 8,
							tasks =
							{
								"Make a pick", "Dig that rock", "Great Plains", "Squeltch", "Beeeees!",
								"Speak to the king",
								"Forest hunters", "Befriend the pigs", "For a nice walk", "Kill the spiders",
								"Killer bees!",
								"Make a Beehat", "The hunters", "Magic meadow", "Frogs and bugs"
							}
						},
					},

					numrandom_set_pieces = 5,
					random_set_pieces =
					{
						"Chessy_1",
						"Chessy_2",
						"Chessy_3",
						"Chessy_4",
						"Chessy_5",
						"Chessy_6",
						"ChessSpot1",
						"ChessSpot2",
						"ChessSpot3",
						"Maxwell1",
						"Maxwell2",
						"Maxwell3",
						"Maxwell4",
						"Maxwell5",
						"Maxwell6",
						"Maxwell7",
						"Warzone_1",
						"Warzone_2",
						"Warzone_3",
					},

					ordered_story_setpieces =
					{
						"TeleportatoRingLayout",
						"TeleportatoBoxLayout",
						"TeleportatoCrankLayout",
						"TeleportatoPotatoLayout",
						"AdventurePortalLayout",
						"TeleportatoBaseLayout",
					},
					required_prefabs =
					{
						"teleportato_ring", "teleportato_box", "teleportato_crank", "teleportato_potato",
						"teleportato_base",
						"chester_eyebone", "adventure_portal", "pigking",
					},
				});
			}
			else
			{
				Levels.AddLevel(LEVELTYPE.SURVIVAL, new Level
				{
					id = "SURVIVAL_DEFAULT_PLUS",
					name = STRINGS.UI.CUSTOMIZATIONSCREEN.PRESETLEVELS[2],
					desc = STRINGS.UI.CUSTOMIZATIONSCREEN.PRESETLEVELDESC[2],
					overrides =
					{
						{ "start_setpeice", "DefaultPlusStart" },
						{
							"start_node",
							new List<string> { "DeepForest", "Forest", "SpiderForest", "Plain", "Rocky", "Marsh" }
						},
						{ "boons", "often" },
						{ "spiders", "often" },
						{ "berrybush", "rare" },
						{ "carrot", "rare" },
						{ "rabbits", "rare" },


					},

					tasks =
					{
						"Make a pick",
						"Dig that rock",
						"Great Plains",
						"Squeltch",
						"Beeeees!",
						"Speak to the king",
						"Tentacle-Blocked The Deep Forest",
						"Badlands",
					},
					numoptionaltasks = 4,
					optionaltasks =
					{
						"Forest hunters",
						"Befriend the pigs",
						"For a nice walk",
						"Kill the spiders",
						"Killer bees!",
						"Make a Beehat",
						"The hunters",
						"Magic meadow",
						"Hounded Greater Plains",
						"Merms ahoy",
						"Frogs and bugs",
						"Oasis",
						"Mole Colony Deciduous",
						"Mole Colony Rocks",
					},
					set_pieces =
					{
						["ResurrectionStone"] = { count = 2, tasks = { "Speak to the king", "Forest hunters" } },
						["WormholeGrass"] =
						{
							count = 8,
							tasks =
							{
								"Make a pick", "Dig that rock", "Great Plains", "Squeltch", "Beeeees!",
								"Speak to the king", "Forest hunters", "Befriend the pigs", "For a nice walk",
								"Kill the spiders", "Killer bees!", "Make a Beehat", "The hunters", "Magic meadow",
								"Frogs and bugs"
							}
						},
					},

					numrandom_set_pieces = 5,
					random_set_pieces =
					{
						"Chessy_1",
						"Chessy_2",
						"Chessy_3",
						"Chessy_4",
						"Chessy_5",
						"Chessy_6",
						"ChessSpot1",
						"ChessSpot2",
						"ChessSpot3",
						"Maxwell1",
						"Maxwell2",
						"Maxwell3",
						"Maxwell4",
						"Maxwell5",
						"Maxwell6",
						"Maxwell7",
						"Warzone_1",
						"Warzone_2",
						"Warzone_3",
					},

					ordered_story_setpieces =
					{
						"TeleportatoRingLayout",
						"TeleportatoBoxLayout",
						"TeleportatoCrankLayout",
						"TeleportatoPotatoLayout",
						"AdventurePortalLayout",
						"TeleportatoBaseLayout",
					},
					required_prefabs =
					{
						"teleportato_ring", "teleportato_box", "teleportato_crank", "teleportato_potato",
						"teleportato_base", "chester_eyebone", "adventure_portal", "pigking",
					},
				});
			}

			Levels.AddLevel(LEVELTYPE.SURVIVAL, new Level
			{
				id = "COMPLETE_DARKNESS",
				name = STRINGS.UI.CUSTOMIZATIONSCREEN.PRESETLEVELS[3],
				desc = STRINGS.UI.CUSTOMIZATIONSCREEN.PRESETLEVELDESC[3],
				overrides =
				{
					{ "start_setpeice", "DarknessStart" },
					{ "start_node", new List<string> { "DeepForest", "Forest" } },
					{ "day", "onlynight" },
				},
				tasks =
				{
					"Make a pick",
					"Dig that rock",
					"Great Plains",
					"Squeltch",
					"Beeeees!",
					"Speak to the king",
					"Forest hunters",
					"Badlands",
				},
				numoptionaltasks = 4,
				optionaltasks =
				{
					"Befriend the pigs",
					"For a nice walk",
					"Kill the spiders",
					"Killer bees!",
					"Make a Beehat",
					"The hunters",
					"Magic meadow",
					"Frogs and bugs",
					"Oasis",
					"Mole Colony Deciduous",
					"Mole Colony Rocks",
				},
				set_pieces =
				{
					["ResurrectionStone"] = { count = 2, tasks = { "Speak to the king", "Forest hunters" } },
					["WormholeGrass"] =
					{
						count = 8,
						tasks =
						{
							"Make a pick", "Dig that rock", "Great Plains", "Squeltch", "Beeeees!", "Speak to the king",
							"Forest hunters", "Befriend the pigs", "For a nice walk", "Kill the spiders",
							"Killer bees!", "Make a Beehat", "The hunters", "Magic meadow", "Frogs and bugs"
						}
					},
				},

				numrandom_set_pieces = 5,
				random_set_pieces =
				{
					"Chessy_1",
					"Chessy_2",
					"Chessy_3",
					"Chessy_4",
					"Chessy_5",
					"Chessy_6",
					"ChessSpot1",
					"ChessSpot2",
					"ChessSpot3",
					"Maxwell1",
					"Maxwell2",
					"Maxwell3",
					"Maxwell4",
					"Maxwell5",
					"Maxwell6",
					"Maxwell7",
					"Warzone_1",
					"Warzone_2",
					"Warzone_3",
				},

				ordered_story_setpieces =
				{
					"TeleportatoRingLayout",
					"TeleportatoBoxLayout",
					"TeleportatoCrankLayout",
					"TeleportatoPotatoLayout",
					"AdventurePortalLayout",
					"TeleportatoBaseLayout",
				},
				required_prefabs =
				{
					"teleportato_ring", "teleportato_box", "teleportato_crank", "teleportato_potato",
					"teleportato_base", "chester_eyebone", "adventure_portal", "pigking",
				},
			});

			//-- Levels.AddLevel(LEVELTYPE.SURVIVAL,new Level{
			//-- 	id="SURVIVAL_CAVEPREVIEW",
			//-- 	name=STRINGS.UI.CUSTOMIZATIONSCREEN.PRESETLEVELS[3],
			//-- 	desc=STRINGS.UI.CUSTOMIZATIONSCREEN.PRESETLEVELDESC[3],
			//-- 	overrides={
			//-- 			{"start_setpeice", 	"CaveTestStart"},
			//-- 			{"start_node",		"Clearing"},
			//-- 	},
			//-- 	tasks = {
			//-- 			"Make a pick",
			//-- 			"Dig that rock",
			//-- 			"Great Plains",
			//-- 			"Squeltch",
			//-- 			"Beeeees!",
			//-- 			"Speak to the king",
			//-- 			"Forest hunters",
			//-- 	},
			//-- 	numoptionaltasks = 4,
			//-- 	optionaltasks = {
			//-- 			"Befriend the pigs",
			//-- 			"For a nice walk",
			//-- 			"Kill the spiders",
			//-- 			"Killer bees!",
			//-- 			"Make a Beehat",
			//-- 			"The hunters",
			//-- 			"Magic meadow",
			//-- 			"Frogs and bugs",
			//-- 	},
			//-- 	set_pieces = {
			//-- 		["ResurrectionStone"] = { count=2, tasks={"Make a pick", "Dig that rock", "Great Plains", "Squeltch", "Beeeees!", "Speak to the king", "Forest hunters" } },
			//-- 		["WormholeGrass"] = { count=8, tasks={"Make a pick", "Dig that rock", "Great Plains", "Squeltch", "Beeeees!", "Speak to the king", "Forest hunters", "Befriend the pigs", "For a nice walk", "Kill the spiders", "Killer bees!", "Make a Beehat", "The hunters", "Magic meadow", "Frogs and bugs"} },
			//-- 	},
			//-- })
        }
    }
}