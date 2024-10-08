﻿using UnityEngine;

namespace DYT.Map.levels
{
    public class CaveLevels
    {
        static CaveLevels()
        {
            //----------------------------------
            //-- Cave levels
            //----------------------------------

            Levels.AddLevel(LEVELTYPE.CAVE, new Level
            {
                id = "CAVE_LEVEL_1",
                name = "CAVE_LEVEL_1",
                overrides =
                {
                    { "world_size", "tiny" },
                    //-- {"day", 			"onlynight"}, 
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
                    "SingleBatCaveTask",
                    "RabbitsAndFungs",
                    "FungalPlain",
                    "Cavern",
                },
                numoptionaltasks = Random.Range(2, 3),
                optionaltasks =
                {
                    "CaveBase",
                    "MushBase",
                    "SinkBase",
                    "RabbitTown",
                    "RedFungalComplex",
                    "GreenFungalComplex",
                    "BlueFungalComplex",
                },
            });

            Levels.AddLevel(LEVELTYPE.CAVE, new Level
            {
                id = "CAVE_LEVEL_2",
                name = "CAVE_LEVEL_2",
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
                    { "start_setpeice", "RuinsStart" },
                    { "start_node", "BGWilds" },
                },
                tasks =
                {
                    "RuinsStart",
                    "TheLabyrinth",
                    "Residential",
                    "Military",
                    "Sacred",
                },
                numoptionaltasks = Random.Range(1, 2),
                optionaltasks =
                {
                    "MoreAltars",
                    "SacredDanger",
                    "FailedCamp",
                    "Residential2",
                    "Residential3",
                    "Military2",
                    "Sacred2",
                },

                required_prefabs =
                {
                    "minotaur"
                },

            });
        }
    }
}