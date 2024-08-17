using System;
using System.Collections.Generic;

namespace DYT.Map
{
    public class TreasureHunt
    {
        public class Treasure
        {
            public string treasure_set_piece;
            public string treasure_prefab;
            public string map_set_piece;
            public string map_prefab;
            public string loot;
            public int tier;
        }
        private static Dictionary<string, List<Treasure>> internaltreasure =
            new Dictionary<string, List<Treasure>>
            {
                {
                    "TestTreasure", new List<Treasure>
                    {
                        new Treasure
                        {
                            //Set piece with the treasure prefab
                            treasure_set_piece = "BuriedTreasureLayout",

                            //The treasure prefab itself. If treasure_set_piece is set this is the prefab
                            //inside the set piece. If treasure_set_piece is not set this prefab will be spawned
                            //during worldgen
                            treasure_prefab = "buriedtreasure",

                            //Set piece with the map prefab, only for the first stage in multi stage treasures
                            map_set_piece = "TreasureHunterBoon",

                            //currently unused
                            map_prefab = "messagebottle",

                            //Reference to the loot table for the treasure when it is dug up
                            loot = "snaketrap"
                        }
                    }
                },
                {
                    "PirateBank", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "10dubloons",
                        }
                    }
                },

                {
                    "SuperTelescope", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "SuperTelescope",
                        }
                    }
                },

                {
                    "WoodlegsKey1", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "WoodlegsKey1",
                        }
                    }
                },

                {
                    "WoodlegsKey2", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "WoodlegsKey2",
                        }
                    }
                },

                {
                    "WoodlegsKey3", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "WoodlegsKey3",
                        }
                    }
                },

                {
                    "PiratePeanuts", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "1dubloon",
                        }
                    }
                },

                {
                    "minerhat", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "minerhat",
                        }
                    }
                },

                {
                    "RandomGem", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "gems",
                        }
                    }
                },


                {
                    "DubloonsGem", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "dubloonsandgem",
                        }
                    }
                },


                {
                    "SeamansCarePackage", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "seamanscarepackage",
                        }
                    }
                },

                {
                    "ChickenOfTheSea", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "ChickenOfTheSea",
                        }
                    }
                },

                {
                    "BootyInDaBooty", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "BootyInDaBooty",
                        }
                    }
                },

                {
                    "OneTrueEarring", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "OneTrueEarring",
                        }
                    }
                },

                {
                    "PegLeg", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "PegLeg",
                        }
                    }
                },

                {
                    "VolcanoStaff", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "VolcanoStaff",
                        }
                    }
                },

                {
                    "Gladiator", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "Gladiator",
                        }
                    }
                },

                {
                    "FancyHandyMan", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "FancyHandyMan",
                        }
                    }
                },

                {
                    "LobsterMan", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "LobsterMan",
                        }
                    }
                },

                {
                    "Compass", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "Compass",
                        }
                    }
                },

                {
                    "Scientist", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "Scientist",
                        }
                    }
                },

                {
                    "Alchemist", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "Alchemist",
                        }
                    }
                },

                {
                    "Shaman", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "Shaman",
                        }
                    }
                },

                {
                    "FireBrand", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "FireBrand",
                        }
                    }
                },

                {
                    "SailorsDelight", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "SailorsDelight",
                        }
                    }
                },

                {
                    "WarShip", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "WarShip",
                        }
                    }
                },

                {
                    "Desperado", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "Desperado",
                        }
                    }
                },

                {
                    "JewelThief", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "JewelThief",
                        }
                    }
                },

                {
                    "AntiqueWarrior", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "AntiqueWarrior",
                        }
                    }
                },

                {
                    "Yaar", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "Yaar",
                        }
                    }
                },

                {
                    "GdayMate", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "GdayMate",
                        }
                    }
                },

                {
                    "ToxicAvenger", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "ToxicAvenger",
                        }
                    }
                },

                {
                    "MadBomber", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "MadBomber",
                        }
                    }
                },

                {
                    "FancyAdventurer", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "FancyAdventurer",
                        }
                    }
                },

                {
                    "ThunderBall", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "ThunderBall",
                        }
                    }
                },

                {
                    "TombRaider", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "TombRaider",
                        }
                    }
                },

                {
                    "SteamPunk", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "SteamPunk",
                        }
                    }
                },

                {
                    "CapNCrunch", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "CapNCrunch",
                        }
                    }
                },

                {
                    "AyeAyeCapn", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "AyeAyeCapn",
                        }
                    }
                },

                {
                    "BreakWind", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "BreakWind",
                        }
                    }
                },

                {
                    "Diviner", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "Diviner",
                        }
                    }
                },

                {
                    "GoesComesAround", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "GoesComesAround",
                        }
                    }
                },

                {
                    "GoldGoldGold", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "GoldGoldGold",
                        }
                    }
                },

                {
                    "FirePoker", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "FirePoker",
                        }
                    }
                },

                {
                    "DeadmansTreasure", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "RockSkull",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "DeadmansTreasure",
                        }
                    }
                },

                {
                    "TestMultiStage", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "1dubloon",
                        },
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "1dubloon",
                        },
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "gems",
                        },
                    }
                },

                {
                    "SeaPackageQuest", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "1dubloon",
                        },
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "dubloonsandgem",
                        },
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "seamanscarepackage",
                        },
                    }
                },

                {
                    "TierQuest", new List<Treasure>
                    {
                        new Treasure
                        {
                            treasure_set_piece = "BuriedTreasureLayout",
                            treasure_prefab = "buriedtreasure",
                            map_prefab = "messagebottle",
                            loot = "seamanscarepackage",
                        },
                        new Treasure
                        {
                            tier = 1,
                        },
                        new Treasure
                        {
                            tier = 2,
                        },
                        new Treasure
                        {
                            tier = 2,
                        },
                        new Treasure
                        {
                            tier = 3,
                        },
                    }
                }
            };

        public class TreasureLoot
        {
            // {Optional] container that spawns with the loot in it see prefabs/treasurechest.lua
            // any prefab with a container component should work
            // chest = "treasurechest"
            public string chest;

            // All items in loot is given when a treasure is dug up
            // loot =
            // {
            //     dubloon = 2,
            //     redgem = 4
            // }
            public Dictionary<string, int> loot;

            // 'num_random_loot' items are given from random_loot (a weighted table)
            // num_random_loot = 1
            public int num_random_loot;

            // random_loot =
            // {
            //     purplegem = 1,
            //     orangegem = 1,
            //     yellowgem = 1,
            //     greengem = 1,
            //     redgem = 5,
            //     bluegem = 5,
            // }
            public Dictionary<string, int> random_loot;

            // Every item in chance_loot has a custom chance of being given
            // Possible for nothing or everything to be given
            // chance_loot =
            // {
            //     dubloon = 0.25,
            //     goldnugget = 0.25,
            //     bluegem = 0.1
            // }
            public Dictionary<string, float> chance_loot;

            // A custom function used to give items
            // custom_lootfn = function(lootlist) end
            public Action<object> custom_lootfn;
        }
        private static Dictionary<string, TreasureLoot> internalloot = new Dictionary<string, TreasureLoot>
        {
            {
                "snaketrap", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "snake", 3 },
                        { "dubloon", 3 },
                    },
                    random_loot = new Dictionary<string, int>
                    {
                        { "purplegem", 1 },
                        { "orangegem", 1 },
                        { "yellowgem", 1 },
                        { "greengem", 1 },
                        { "redgem", 5 },
                        { "bluegem", 5 },
                    },
                }
            },
            {
                "1dubloon", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 1 },
                    }
                }
            },
            {
                "3dubloons", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 3 },
                    }
                }
            },
            {
                "10dubloons", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 10 },
                    }
                }
            },
            {
                "SuperTelescope", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "supertelescope", 1 },
                        { "dubloon", 5 },
                        { "spear_poison", 1 },
                        { "boat_lantern", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },
                }
            },

            #region

            // Took the actual keys out of these now that they're granted in other ways.
            // Don't want to remove the loot tables incase people have saved worlds with these loots set.

            {
                "WoodlegsKey1", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 10 },
                    }
                }
            },
            {
                "WoodlegsKey2", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 10 },
                    }
                }
            },
            {
                "WoodlegsKey3", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 10 },
                    }
                }
            },
            {
                "minerhat", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "minerhat", 1 },
                        { "dubloon", 5 },
                        { "obsidianaxe", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },
                }
            },
            {
                "seamanscarepackage", new TreasureLoot
                {
                    chest = "pandoraschest",
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 5 },
                        { "telescope", 1 },
                        { "armor_lifejacket", 1 },
                        { "captainhat", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },
                }
            },
            {
                "gems", new TreasureLoot
                {
                    chest = "treasurechest",
                    loot = new Dictionary<string, int>
                    {
                        { "goldnugget", 3 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.5f },
                        { "orangegem", 0.25f },
                        { "yellowgem", 0.25f },
                        { "greengem", 0.25f },
                    },
                }
            },
            {
                "dubloonsandgem", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 5 },
                    },
                    random_loot = new Dictionary<string, int>
                    {
                        { "purplegem", 1 },
                        { "redgem", 5 },
                        { "bluegem", 5 },
                    }
                }
            },
            {
                "ChickenOfTheSea", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 5 },
                        { "tunacan", 5 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },

            #endregion

            #region DAN ADDED FROM HERE

            {
                "BootyInDaBooty", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 5 },
                        { "piratepack", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "OneTrueEarring", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "earring", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },
                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "PegLeg", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 2 },
                        { "peg_leg", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "VolcanoStaff", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 6 },
                        { "volcanostaff", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "Gladiator", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 2 },
                        { "footballhat", 1 },
                        { "spear", 1 },
                        { "armorseashell", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "FancyHandyMan", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 1 },
                        { "goldenaxe", 1 },
                        { "goldenshovel", 1 },
                        { "goldenpickaxe", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "LobsterMan", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 4 },
                        { "boat_lantern", 1 },
                        { "seatrap", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "Compass", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 3 },
                        { "compass", 1 },
                        { "boneshard", 2 },
                        { "messagebottleempty", 1 },
                        { "sand", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    }
                }
            },
            {
                "Scientist", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 3 },
                        { "transistor", 1 },
                        { "gunpowder", 3 },
                        { "heatrock", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "Alchemist", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 2 },
                        { "antivenom", 1 },
                        { "healingsalve", 3 },
                        { "blowdart_sleep", 2 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "Shaman", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 1 },
                        { "nightsword", 1 },
                        { "amulet", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "FireBrand", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 2 },
                        { "obsidianaxe", 1 },
                        { "gunpowder", 2 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "SailorsDelight", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 4 },
                        { "clothsail", 1 },
                        { "boatrepairkit", 1 },
                        { "boat_lantern", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "WarShip", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 3 },
                        { "coconade", 3 },
                        { "boatcannon", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "Desperado", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 1 },
                        { "snakeskinhat", 1 },
                        { "armor_snakeskin", 1 },
                        { "spear_launcher", 2 },
                        { "spear", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "JewelThief", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 5 },
                        { "goldnugget", 6 },
                        { "purplegem", 2 },
                        { "redgem", 4 },
                        { "bluegem", 3 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    }
                }
            },
            {
                "AntiqueWarrior", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 5 },
                        { "ruins_bat", 1 },
                        { "ruinshat", 1 },
                        { "armorruins", 1 },
                        { "bluegem", 2 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    }
                }
            },
            {
                "Yaar", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 1 },
                        { "telescope", 1 },
                        { "piratehat", 1 },
                        { "boatcannon", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "GdayMate", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 3 },
                        { "boomerang", 1 },
                        { "snakeskin", 3 },
                        { "strawhat", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "ToxicAvenger", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 1 },
                        { "gashat", 1 },
                        { "venomgland", 3 },
                        { "spear_poison", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "MadBomber", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 2 },
                        { "coconade", 2 },
                        { "obsidiancoconade", 1 },
                        { "gunpowder", 2 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "FancyAdventurer", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 4 },
                        { "goldenmachete", 1 },
                        { "tophat", 1 },
                        { "rope", 3 },
                        { "telescope", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    }
                }
            },
            {
                "ThunderBall", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 6 },
                        { "spear_launcher", 2 },
                        { "spear", 1 },
                        { "blubbersuit", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "TombRaider", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 4 },
                        { "boneshard", 3 },
                        { "nightmarefuel", 4 },
                        { "purplegem", 2 },
                        { "goldnugget", 3 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    }
                }
            },
            {
                "SteamPunk", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 1 },
                        { "gears", 4 },
                        { "transistor", 2 },
                        { "telescope", 1 },
                        { "goldnugget", 2 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    }
                }
            },
            {
                "CapNCrunch", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 4 },
                        { "piratehat", 1 },
                        { "boatcannon", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "AyeAyeCapn", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 1 },
                        { "captainhat", 1 },
                        { "armor_lifejacket", 1 },
                        { "tunacan", 1 },
                        { "trawlnet", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    }
                }
            },
            {
                "BreakWind", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 4 },
                        { "armor_windbreaker", 1 },
                        { "obsidianmachete", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "Diviner", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 4 },
                        { "diviningrod", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "GoesComesAround", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 3 },
                        { "boomerang", 1 },
                        { "trap_teeth", 2 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "GoldGoldGold", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 6 },
                        { "goldnugget", 5 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "FirePoker", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 2 },
                        { "spear_obsidian", 1 },
                        { "armorobsidian", 1 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "blueprint", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "purplegem", 0.1f },
                        { "redgem", 0.25f },
                        { "bluegem", 0.25f },
                    }
                }
            },
            {
                "DeadmansTreasure", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 4 },
                        { "boatrepairkit", 1 },
                        { "goldenmachete", 1 },
                        { "obsidiancoconade", 3 },
                    },

                    random_loot = new Dictionary<string, int>
                    {
                        { "fabric", 1 },
                        { "papyrus", 1 },
                        { "tunacan", 1 },
                        { "goldnugget", 1 },
                        { "gears", 1 },
                        { "purplegem", 1 },
                        { "redgem", 1 },
                        { "bluegem", 1 },
                        { "rope", 1 },
                    },

                    chance_loot = new Dictionary<string, float>
                    {
                        { "harpoon", 0.1f },
                        { "boatcannon", 0.01f },
                        { "rope", 0.25f },
                    }
                }
            },

            #endregion

            #region GOOD LIST

            {
                "staydry", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "palmleaf_umbrella", 1 },
                        { "armor_snakeskin", 1 },
                        { "snakeskinhat", 1 },
                    },
                }
            },
            {
                "gears", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "gears", 5 },
                    },
                }
            },
            {
                "cooloff", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "ice", 3 },
                        { "hawaiianshirt", 1 },
                        { "umbrella", 1 },
                    },
                }
            },
            {
                "birders", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "birdtrap", 1 },
                        { "featherhat", 1 },
                        { "seeds", 4 },
                    },
                }
            },
            {
                "slot_anotherspin", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dubloon", 1 },
                    },
                }
            },
            {
                "slot_goldy", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "goldnugget", 5 },
                    },
                }
            },
            {
                "slot_honeypot", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "beehat", 1 },
                        { "bandage", 1 },
                        { "honey", 5 },
                    },
                }
            },
            {
                "slot_warrior1", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "footballhat", 1 },
                        { "armorwood", 1 },
                        { "spear", 1 },
                    },
                }
            },
            {
                "slot_warrior2", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "armormarble", 1 },
                        { "hambat", 1 },
                        { "blowdart_pipe", 1 },
                    },
                }
            },
            {
                "slot_warrior3", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "trap_teeth", 1 },
                        { "armorgrass", 1 },
                        { "boomerang", 1 },
                    },
                }
            },
            {
                "slot_warrior4", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "spear_launcher", 1 },
                        { "spear_poison", 1 },
                        { "armorseashell", 1 },
                        { "coconade", 1 },
                    },
                }
            },
            {
                "slot_scientist", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "transistor", 3 },
                        { "heatrock", 1 },
                        { "gunpowder", 3 },
                    },
                }
            },
            {
                "slot_walker", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "cane", 1 },
                        { "goldnugget", 3 },
                    },
                }
            },
            {
                "slot_gemmy", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "redgem", 3 },
                        { "bluegem", 3 },
                    },
                }
            },
            {
                "slot_bestgem", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "purplegem", 3 },
                    },
                }
            },
            {
                "slot_lifegiver", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "amulet", 1 },
                        { "goldnugget", 3 },
                    },
                }
            },
            {
                "slot_chilledamulet", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "blueamulet", 1 },
                        { "goldnugget", 3 },
                    },
                }
            },
            {
                "slot_icestaff", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "icestaff", 1 },
                        { "goldnugget", 3 },
                    },
                }
            },
            {
                "slot_firestaff", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "firestaff", 1 },
                        { "goldnugget", 3 },
                    },
                }
            },
            {
                "slot_coolasice", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "icehat", 1 },
                        // tropicalfan = 1,
                        { "palmleaf_umbrella", 1 },
                    },
                }
            },
            {
                "slot_gunpowder", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "gunpowder", 5 },
                    },
                }
            },
            {
                "slot_darty", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "blowdart_pipe", 1 },
                        { "blowdart_sleep", 1 },
                        { "blowdart_fire", 1 },
                    },
                }
            },
            {
                "slot_firedart", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "blowdart_fire", 3 },
                        { "goldnugget", 3 },
                    },
                }
            },
            {
                "slot_sleepdart", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "blowdart_sleep", 3 },
                        { "goldnugget", 3 },
                    },
                }
            },
            {
                "slot_blowdart", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "blowdart_pipe", 3 },
                        { "goldnugget", 3 },
                    },
                }
            },
            {
                "slot_speargun", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "spear_launcher", 1 },
                        { "spear", 1 },
                        { "goldnugget", 3 },
                    },
                }
            },
            {
                "slot_dapper", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "cane", 1 },
                        { "goldnugget", 3 },
                        { "tophat", 1 },
                    },
                }
            },
            {
                "slot_speed", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "yellowamulet", 1 },
                        { "nightmarefuel", 3 },
                        { "goldnugget", 3 },
                    },
                }
            },
            {
                "slot_coconades", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "coconade", 3 },
                        { "goldnugget", 3 },
                    },
                }
            },
            {
                "slot_obsidian", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "obsidian", 5 },
                    },
                }
            },
            {
                "slot_thuleciteclub", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "ruins_bat", 1 },
                        { "goldnugget", 3 },
                    },
                }
            },
            {
                "slot_thulecitesuit", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "armorruins", 1 },
                        { "goldnugget", 3 },
                    },
                }
            },
            {
                "slot_ultimatewarrior", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "armorruins", 1 },
                        { "ruins_bat", 1 },
                        { "ruinshat", 1 },
                    },
                }
            },
            {
                "slot_goldenaxe", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "goldenaxe", 1 },
                        { "goldnugget", 3 },
                    },
                }
            },
            {
                "slot_monkeyball", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "monkeyball", 1 },
                        { "cave_banana", 2 },
                    },
                }
            },

            #endregion

            #region OK LIST

            {
                "firestarter", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "log", 2 },
                        // twigs = 1,
                        { "cutgrass", 3 },
                    },
                }
            },
            {
                "geologist", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "rocks", 1 },
                        { "goldnugget", 1 },
                        { "obsidian", 1 },
                    },
                }
            },
            {
                "3cutgrass", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "cutgrass", 5 },
                    },
                }
            },
            {
                "3logs", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "log", 3 },
                    },
                }
            },
            {
                "3twigs", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "twigs", 3 },
                    },
                }
            },
            {
                "slot_torched", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "torch", 1 },
                        { "charcoal", 2 },
                        { "ash", 2 },
                    },
                }
            },
            {
                "slot_jelly", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "jellyfish_dead", 3 },
                    },
                }
            },
            {
                "slot_handyman", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "axe", 1 },
                        { "hammer", 1 },
                        { "shovel", 1 },
                    },
                }
            },
            {
                "slot_poop", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "poop", 5 },
                    },
                }
            },
            {
                "slot_berry", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "berries", 5 },
                    },
                }
            },
            {
                "slot_limpets", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "limpets", 5 },
                    },
                }
            },
            {
                "slot_seafoodsurprise", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "limpets", 2 },
                        { "jellyfish_dead", 1 },
                        { "tropical_fish", 2 },
                        { "fish_med", 1 },
                    },
                }
            },
            {
                "slot_bushy", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "berries", 3 },
                        { "dug_berrybush2", 1 }, //cut down from 3
                    },
                }
            },
            {
                "slot_bamboozled", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "dug_bambootree", 1 },
                        { "bamboo", 3 },
                    },
                }
            },
            {
                "slot_grassy", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "trap", 1 },
                        { "cutgrass", 3 },
                        { "strawhat", 1 },
                    },
                }
            },
            {
                "slot_prettyflowers", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "petals", 5 },
                        { "flowerhat", 1 },
                    },
                }
            },
            {
                "slot_witchcraft", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "flower_evil", 5 },
                        { "red_cap", 1 },
                        { "green_cap", 1 },
                        { "blue_cap", 1 },
                    },
                }
            },
            {
                "slot_bugexpert", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "bugnet", 1 },
                        { "fireflies", 3 },
                        { "butterfly", 3 },
                    },
                }
            },
            {
                "slot_flinty", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "flint", 5 },
                    },
                }
            },
            {
                "slot_fibre", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "cave_banana", 1 },
                        { "dragonfruit", 1 },
                        { "watermelon", 1 },
                    },
                }
            },
            {
                "slot_drumstick", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "drumstick", 3 },
                    },
                }
            },
            {
                "slot_fisherman", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "fishingrod", 1 },
                        { "fish_med", 3 },
                        { "tropical_fish", 3 },
                    },
                }
            },
            {
                "slot_bonesharded", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "hammer", 1 },
                        { "skeleton", 3 },
                    },
                }
            },
            {
                "slot_jerky", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "meat_dried", 3 },
                    },
                }
            },
            {
                "slot_coconutty", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "coconut", 5 },
                    },
                }
            },
            {
                "slot_camper", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "heatrock", 1 },
                        { "bedroll_straw", 1 },
                        { "meat_dried", 1 },
                    },
                }
            },
            {
                "slot_ropey", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "rope", 5 },
                    },
                }
            },
            {
                "slot_tailor", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "sewing_kit", 1 },
                        { "fabric", 3 },
                        { "tophat", 1 },
                    },
                }
            },
            {
                "slot_spiderboon", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "spidergland", 2 },
                        { "silk", 5 },
                        { "monstermeat", 3 },
                    },
                }
            },

            #endregion

            #region BAD LIST

            {
                "slot_spiderattack", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "spider", 3 },
                    },
                }
            },
            {
                "slot_mosquitoattack", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "mosquito_poison", 5 },
                    },
                }
            },
            {
                "slot_snakeattack", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "snake", 3 },
                    },
                }
            },
            {
                "slot_monkeysurprise", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "primeape", 2 },
                    },
                }
            },
            {
                "slot_poisonsnakes", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "snake_poison", 2 },
                    },
                }
            },
            {
                "slot_hounds", new TreasureLoot
                {
                    loot = new Dictionary<string, int>
                    {
                        { "hound", 2 },
                    },
                }
            }

            #endregion
        };

        private static Dictionary<string, List<Treasure>> TreasureList =
            new Dictionary<string, List<Treasure>>();
        private static Dictionary<string, TreasureLoot> TreasureLootList =
            new Dictionary<string, TreasureLoot>();

        public static void AddTreasure(string name, List<Treasure> data)
        {
            TreasureList.Add(name, data);
        }

        public static void AddTreasureLoot(string name, TreasureLoot data)
        {
            TreasureLootList.Add(name, data);
        }


        public static void Init()
        {
            foreach (string name in internaltreasure.Keys) AddTreasure(name, internaltreasure[name]);
            
            foreach (string name in internalloot.Keys) AddTreasureLoot(name, internalloot[name]);
            
            SpawnUtil.Init();
        }
    }
}