using System.Collections.Generic;

namespace DYT.Map
{
	public class CustomiseItem
	{
		public string value;
		public List<SpinnerOption> spinner;
		public List<SpinnerOption> desc;
		public bool enable;
		public string atlas;
		public string image;
		public int order;
	}
	public class CustomiseGroup
	{
		public int order;
		public string text;
		public List<SpinnerOption> desc;
		public bool enable;
		public Dictionary<string, CustomiseItem> items;


		public CustomiseGroup(string text, List<SpinnerOption> spinnerOptionList,
			bool enable, Dictionary<string, CustomiseItem> itemDictionary)
		{
			this.text = text;
			desc = spinnerOptionList;
			this.enable = enable;
			items = itemDictionary;
		}
	}
    public class Customise
    {
        protected static List<SpinnerOption> freqency_descriptions;
        protected static List<SpinnerOption> freqency_descriptions_ps4_exceptions;
        protected static List<SpinnerOption> day_descriptions = new()
        {
	        new SpinnerOption{ text = Strings.UI.SANDBOXMENU.SLIDEDEFAULT, data = "default" },

	        new SpinnerOption{ text = Strings.UI.SANDBOXMENU.SLIDELONG+" "+Strings.UI.SANDBOXMENU.DAY, data = "longday" },
	        new SpinnerOption{ text = Strings.UI.SANDBOXMENU.SLIDELONG+" "+Strings.UI.SANDBOXMENU.DUSK, data = "longdusk" },
	        new SpinnerOption{ text = Strings.UI.SANDBOXMENU.SLIDELONG+" "+Strings.UI.SANDBOXMENU.NIGHT, data = "longnight" },

	        new SpinnerOption{ text = Strings.UI.SANDBOXMENU.EXCLUDE+" "+Strings.UI.SANDBOXMENU.DAY, data = "noday" },
	        new SpinnerOption{ text = Strings.UI.SANDBOXMENU.EXCLUDE+" "+Strings.UI.SANDBOXMENU.DUSK, data = "nodusk" },
	        new SpinnerOption{ text = Strings.UI.SANDBOXMENU.EXCLUDE+" "+Strings.UI.SANDBOXMENU.NIGHT, data = "nonight" },

	        new SpinnerOption{ text = Strings.UI.SANDBOXMENU.SLIDEALL+" "+Strings.UI.SANDBOXMENU.DAY, data = "onlyday" },
	        new SpinnerOption{ text = Strings.UI.SANDBOXMENU.SLIDEALL+" "+Strings.UI.SANDBOXMENU.DUSK, data = "onlydusk" },
	        new SpinnerOption{ text = Strings.UI.SANDBOXMENU.SLIDEALL+" "+Strings.UI.SANDBOXMENU.NIGHT, data = "onlynight" },
        };
        protected static List<SpinnerOption> season_length_descriptions = new()
        {

	        new SpinnerOption { text = Strings.UI.SANDBOXMENU.SLIDENEVER, data = "noseason" },
	        new SpinnerOption { text = Strings.UI.SANDBOXMENU.SLIDEVERYSHORT, data = "veryshortseason" },
	        new SpinnerOption { text = Strings.UI.SANDBOXMENU.SLIDESHORT, data = "shortseason" },
	        new SpinnerOption { text = Strings.UI.SANDBOXMENU.SLIDEDEFAULT, data = "default" },
	        new SpinnerOption { text = Strings.UI.SANDBOXMENU.SLIDELONG, data = "longseason" },
	        new SpinnerOption { text = Strings.UI.SANDBOXMENU.SLIDEVERYLONG, data = "verylongseason" },
	        new SpinnerOption { text = Strings.UI.SANDBOXMENU.RANDOM, data = "random" },
        };
        protected static List<SpinnerOption> season_start_descriptions = new()
        {
	        new SpinnerOption
	        {
		        text = Strings.UI.SANDBOXMENU.TEMPERATE, data = "temperate"
	        }, //-- 	image = "season_start_autumn.tex" },
	        new SpinnerOption
		        { text = Strings.UI.SANDBOXMENU.HUMID, data = "humid" }, //-- 	image = "season_start_winter.tex" },
	        new SpinnerOption
		        { text = Strings.UI.SANDBOXMENU.LUSH, data = "lush" }, //-- 	image = "season_start_spring.tex" },	
	        new SpinnerOption
		        { text = Strings.UI.SANDBOXMENU.RANDOM, data = "random" }, //-- 	image = "season_start_summer.tex" },
        };
        protected static List<SpinnerOption> size_descriptions;
        //-- TODO: Read this from the tasks.lua
        protected static List<SpinnerOption> yesno_descriptions = new()
        {
	        new SpinnerOption { text = Strings.UI.SANDBOXMENU.YES, data = "default" },
	        new SpinnerOption { text = Strings.UI.SANDBOXMENU.NO, data = "never" },
        };

        public Dictionary<string, CustomiseGroup> GROUP = new()
        {
	        ["monsters"] =
	        {
		        //-- These guys come after you	
		        order = 5,
		        text = Strings.UI.SANDBOXMENU.CHOICEMONSTERS,
		        desc = freqency_descriptions,
		        enable = false,
		        items =
		        {
			        ["mandrakeman"] =
				        { value = "default", enable = false, spinner = null, image = "mandrake_men.tex", order = 1 },
			        ["antman"] = { value = "default", enable = false, spinner = null, image = "mants.tex", order = 2 },
			        ["giantgrub"] =
				        { value = "default", enable = false, spinner = null, image = "giant_grubs.tex", order = 3 },
			        ["frog_poison"] =
			        {
				        value = "default", enable = false, spinner = null, image = "poison_dart_frogs.tex", order = 4
			        },
			        ["mosquito"] =
				        { value = "default", enable = false, spinner = null, image = "mosquitos.tex", order = 5 },
			        ["bat"] = { value = "default", enable = false, spinner = null, image = "bats.tex", order = 6 },
			        ["weevole"] =
				        { value = "default", enable = false, spinner = null, image = "weevole.tex", order = 7 },
			        ["gnat"] = { value = "default", enable = false, spinner = null, image = "gnat.tex", order = 8 },
			        ["bill"] =
				        { value = "default", enable = false, spinner = null, image = "platypine.tex", order = 9 },
			        ["snake"] = { value = "default", enable = false, spinner = null, image = "snakes.tex", order = 10 },
			        ["scorpion"] =
				        { value = "default", enable = false, spinner = null, image = "scorpions.tex", order = 11 },
			        ["grabbing_vine"] =
				        { value = "default", enable = false, spinner = null, image = "grabbing_vines.tex", order = 12 },
			        ["mean_flytrap"] =
				        { value = "default", enable = false, spinner = null, image = "mean_flytraps.tex", order = 13 },
			        ["adult_flytrap"] =
				        { value = "default", enable = false, spinner = null, image = "adult_flytraps.tex", order = 14 },
			        ["pigghost"] =
			        {
				        value = "default", enable = false, spinner = null, image = "pig_ghosts.tex",
				        desc = yesno_descriptions, order = 15
			        },
			        ["roc"] =
			        {
				        value = "default", enable = false, spinner = null, image = "roc.tex", desc = yesno_descriptions,
				        order = 16
			        },
			        ["pugalisk"] =
			        {
				        value = "default", enable = false, spinner = null, image = "pugalisk.tex",
				        desc = yesno_descriptions, order = 17
			        },
			        ["antqueen"] =
			        {
				        value = "default", enable = false, spinner = null, image = "mant_queen.tex",
				        desc = yesno_descriptions, order = 18
			        },
		        }
	        },
	        ["animals"] =
	        {
		        //-- These guys live and let live
		        order = 4,
		        text = Strings.UI.SANDBOXMENU.CHOICEANIMALS,
		        desc = freqency_descriptions,
		        enable = false,
		        items =
		        {
			        ["butterfly"] =
				        { value = "default", enable = false, spinner = null, image = "butterfly.tex", order = 1 },
			        ["birds"] =
			        {
				        value = "default", enable = false, spinner = null, image = "kingfisher.tex", order = 2
			        },
			        ["glowfly"] =
				        { value = "default", enable = false, spinner = null, image = "glowflies.tex", order = 3 },
			        ["hippopotamoose"] =
				        { value = "default", enable = false, spinner = null, image = "hippopotamoose.tex", order = 4 },
			        ["pog"] = { value = "default", enable = false, spinner = null, image = "pogs.tex", order = 5 },
			        ["pangolden"] =
				        { value = "default", enable = false, spinner = null, image = "pangolden.tex", order = 6 },
			        ["peagawk"] =
				        { value = "default", enable = false, spinner = null, image = "peagawk.tex", order = 7 },
			        ["thunderbird"] =
				        { value = "default", enable = false, spinner = null, image = "thunderbirds.tex", order = 8 },
			        ["dungbeetle"] =
				        { value = "default", enable = false, spinner = null, image = "dung_beetles.tex", order = 9 },
			        ["piko"] =
			        {
				        value = "default", enable = false, spinner = null, image = "orange_pikos.tex", order = 10
			        },
		        }
	        },
	        ["resources"] =
	        {
		        order = 2,
		        text = Strings.UI.SANDBOXMENU.CHOICERESOURCES,
		        desc = freqency_descriptions,
		        enable = false,
		        items =
		        {
			        ["flowers"] =
				        { value = "default", enable = false, spinner = null, image = "flowers.tex", order = 1 },
			        ["flowers_rainforest"] =
			        {
				        value = "default", enable = false, spinner = null, image = "tropical_flowers.tex", order = 2
			        },
			        ["grass"] =
			        {
				        value = "default", enable = false, spinner = null, image = "tall_grass.tex", order = 3
			        },
			        ["grass_bunches"] =
				        { value = "default", enable = false, spinner = null, image = "grass_bunches.tex", order = 4 },
			        ["sapling"] =
				        { value = "default", enable = false, spinner = null, image = "sapling.tex", order = 5 },
			        ["reeds"] = { value = "default", enable = false, spinner = null, image = "reeds.tex", order = 6 },
			        ["rainforesttree"] =
			        {
				        value = "default", enable = false, spinner = null, image = "rainforest_trees.tex", order = 7
			        },
			        ["clawpalmtree"] =
				        { value = "default", enable = false, spinner = null, image = "claw_trees.tex", order = 8 },
			        ["tubertree"] =
				        { value = "default", enable = false, spinner = null, image = "tuber_trees.tex", order = 9 },
			        ["teatree"] =
				        { value = "default", enable = false, spinner = null, image = "tea_trees.tex", order = 10 },
			        ["rock_flippable"] =
				        { value = "default", enable = false, spinner = null, image = "flipping_rocks.tex", order = 11 },
			        ["dungpile"] =
				        { value = "default", enable = false, spinner = null, image = "dung_piles.tex", order = 12 },
			        ["gnatmound"] =
				        { value = "default", enable = false, spinner = null, image = "gnat_mounds.tex", order = 13 },
			        ["lilypad"] =
				        { value = "default", enable = false, spinner = null, image = "lily_pads.tex", order = 14 },
			        ["lotus"] = { value = "default", enable = false, spinner = null, image = "lotus.tex", order = 15 },
			        ["nettle"] =
				        { value = "default", enable = false, spinner = null, image = "nettle.tex", order = 16 },
			        ["hanging_vine"] =
				        { value = "default", enable = false, spinner = null, image = "hanging_vines.tex", order = 17 },
			        ["ruined_sculptures"] =
			        {
				        value = "default", enable = false, spinner = null, image = "lost_sculptures.tex",
				        desc = freqency_descriptions, order = 18
			        },
			        ["antcombhome"] =
			        {
				        value = "default", enable = false, spinner = null, image = "mant_comb_homes.tex",
				        desc = yesno_descriptions, order = 19
			        },
			        ["ant_cave_lantern"] =
			        {
				        value = "default", enable = false, spinner = null, image = "mant_lamps.tex",
				        desc = yesno_descriptions, order = 20
			        },
			        ["city_lamp"] =
			        {
				        value = "default", enable = false, spinner = null, image = "lamp_posts.tex",
				        desc = yesno_descriptions, order = 21
			        },
			        ["rusted_hulks"] =
			        {
				        value = "default", enable = false, spinner = null, image = "rusted_hulks.tex",
				        desc = yesno_descriptions, order = 22
			        },
		        }
	        },
	        ["unprepared"] =
	        {
		        order = 3,
		        text = Strings.UI.SANDBOXMENU.CHOICEFOOD,
		        desc = freqency_descriptions,
		        enable = true,
		        items =
		        {
			        ["aloe"] = { value = "default", enable = true, spinner = null, image = "aloe.tex", order = 1 },
			        ["asparagus_planted"] =
				        { value = "default", enable = true, spinner = null, image = "asparagus.tex", order = 2 },
			        ["radish"] = { value = "default", enable = true, spinner = null, image = "radish.tex", order = 3 },
			        ["mushroom"] =
				        { value = "default", enable = false, spinner = null, image = "mushrooms.tex", order = 4 },
		        }
	        },
	        ["misc"] =
	        {
		        order = 1,
		        text = Strings.UI.SANDBOXMENU.CHOICEMISC,
		        desc = null,
		        enable = true,
		        items =
		        {
			        ["world_size"] =
			        {
				        value = "default", enable = false, spinner = null, image = "world_size.tex",
				        desc = size_descriptions, order = 1
			        },
			        ["temperate_season"] =
			        {
				        value = "default", enable = true, spinner = null, image = "temperate.tex",
				        desc = season_length_descriptions, order = 2
			        },
			        ["humid_season"] =
			        {
				        value = "default", enable = true, spinner = null, image = "humid.tex",
				        desc = season_length_descriptions, order = 3
			        },
			        ["lush_season"] =
			        {
				        value = "default", enable = true, spinner = null, image = "lush.tex",
				        desc = season_length_descriptions, order = 4
			        },
			        ["season_start"] =
			        {
				        value = "temperate", enable = false, spinner = null, image = "season_start.tex",
				        desc = season_start_descriptions, order = 5
			        },
			        ["day"] =
			        {
				        value = "default", enable = false, spinner = null, image = "day.tex", desc = day_descriptions,
				        order = 6
			        },
			        ["weather"] =
			        {
				        value = "default", enable = false, spinner = null, image = "rain.tex",
				        desc = freqency_descriptions, order = 7
			        },
			        ["lightning"] =
			        {
				        value = "default", enable = false, spinner = null, image = "lightning.tex",
				        desc = freqency_descriptions, order = 8
			        },
			        ["fog"] =
			        {
				        value = "default", enable = false, spinner = null, image = "fog.tex", desc = yesno_descriptions,
				        order = 9
			        },
			        ["brambles"] =
			        {
				        value = "default", enable = false, spinner = null, image = "brambles.tex",
				        desc = yesno_descriptions, order = 10
			        },
			        ["hayfever"] =
			        {
				        value = "default", enable = false, spinner = null, image = "hayfever.tex",
				        desc = yesno_descriptions, order = 11
			        },
			        ["boons"] =
			        {
				        value = "default", enable = false, spinner = null, image = "skeletons.tex",
				        desc = freqency_descriptions, order = 12
			        },
			        ["glowflycycle"] =
			        {
				        value = "default", enable = false, spinner = null, image = "glowfly_life_cycle.tex",
				        desc = yesno_descriptions, order = 13
			        },
			        ["deep_jungle_fern_noise"] =
			        {
				        value = "default", enable = false, spinner = null, image = "noise_ferns.tex",
				        desc = freqency_descriptions, order = 14
			        },
			        ["jungle_border_vine"] =
			        {
				        value = "default", enable = false, spinner = null, image = "canopy_loops.tex",
				        desc = freqency_descriptions, order = 15
			        },
			        ["lost_relics"] =
			        {
				        value = "default", enable = false, spinner = null, image = "lost_relics.tex",
				        desc = freqency_descriptions, order = 16
			        },
			        ["pig_ruins_torch"] =
			        {
				        value = "default", enable = false, spinner = null, image = "crumbling_brazier.tex",
				        desc = freqency_descriptions, order = 17
			        },
			        ["vampirebat"] =
			        {
				        value = "default", enable = false, spinner = null, image = "vampire_bats.tex",
				        desc = freqency_descriptions, order = 18
			        },
			        ["vampirebatcave"] =
			        {
				        value = "default", enable = false, spinner = null, image = "vampire_bat_caves.tex",
				        desc = freqency_descriptions, order = 19
			        },
			        ["pighouse_city"] =
			        {
				        value = "default", enable = false, spinner = null, image = "pig_houses.tex",
				        desc = yesno_descriptions, order = 20
			        },
			        ["pig_guard_tower"] =
			        {
				        value = "default", enable = false, spinner = null, image = "guard_towers.tex",
				        desc = yesno_descriptions, order = 21
			        },
			        ["pigbandit"] =
			        {
				        value = "default", enable = false, spinner = null, image = "pig_bandit.tex",
				        desc = freqency_descriptions, order = 22
			        },
			        ["pig_ruins_entrance_small"] =
			        {
				        value = "default", enable = false, spinner = null, image = "small_ruins.tex",
				        desc = freqency_descriptions, order = 23
			        },
			        ["dart_traps"] =
			        {
				        value = "default", enable = false, spinner = null, image = "dart_traps.tex",
				        desc = yesno_descriptions, order = 24
			        },
			        ["spear_traps"] =
			        {
				        value = "default", enable = false, spinner = null, image = "spike_traps.tex",
				        desc = yesno_descriptions, order = 25
			        },
			        ["door_vines"] =
			        {
				        value = "default", enable = false, spinner = null, image = "creeping_vines.tex",
				        desc = yesno_descriptions, order = 26
			        },
			        ["pugalisk_fountain"] =
			        {
				        value = "default", enable = false, spinner = null, image = "pugalisk_fountain.tex",
				        desc = yesno_descriptions, order = 27
			        },
		        }
	        },
        };

        
        protected Customise()
        {
            if (Main.PLATFORM == "PS4")
            {
                freqency_descriptions = new List<SpinnerOption>
                {
                    new(){ text = Strings.UI.SANDBOXMENU.SLIDENEVER, data = "never" },
                    new(){ text = Strings.UI.SANDBOXMENU.SLIDERARE, data = "rare" },
                    new(){ text = Strings.UI.SANDBOXMENU.SLIDEDEFAULT, data = "default" },
                    new(){ text = Strings.UI.SANDBOXMENU.SLIDEOFTEN, data = "often" },
                    new(){ text = Strings.UI.SANDBOXMENU.SLIDEALWAYS, data = "always" },
                };
            }
            else
            {
                freqency_descriptions = new List<SpinnerOption>
                {
                    new() { text = Strings.UI.SANDBOXMENU.SLIDENEVER, data = "never" },
                    new() { text = Strings.UI.SANDBOXMENU.SLIDERARE, data = "rare" },
                    new() { text = Strings.UI.SANDBOXMENU.SLIDEDEFAULT, data = "default" }
                };
                freqency_descriptions_ps4_exceptions = new List<SpinnerOption>
                {
                    new() { text = Strings.UI.SANDBOXMENU.SLIDENEVER, data = "never" },
                    new() { text = Strings.UI.SANDBOXMENU.SLIDERARE, data = "rare" },
                    new() { text = Strings.UI.SANDBOXMENU.SLIDEDEFAULT, data = "default" },
                    new() { text = Strings.UI.SANDBOXMENU.SLIDEOFTEN, data = "often" },
                    new() { text = Strings.UI.SANDBOXMENU.SLIDEALWAYS, data = "always" },
                };
            }

            if (Main.PLATFORM == "PS4")
            {
                size_descriptions = new List<SpinnerOption>
                {
                    new()
                    {
                        text = Strings.UI.SANDBOXMENU.SLIDESMALL, data = "default"
                    }, //-- 	image = "world_size_small.tex"}, 	--350x350
                    new()
                    {
                        text = Strings.UI.SANDBOXMENU.SLIDESMEDIUM, data = "medium"
                    }, //-- 	image = "world_size_medium.tex"},	--450x450
                    new()
                    {
                        text = Strings.UI.SANDBOXMENU.SLIDESLARGE, data = "large"
                    }, //-- 	image = "world_size_large.tex"},	--550x550
                };
            }
            else
            {
                size_descriptions = new List<SpinnerOption>
                {
                    new()
                    {
                        text = Strings.UI.SANDBOXMENU.SLIDESMALL, data = "default"
                    }, //-- 	image = "world_size_small.tex"}, 	--350x350
                    new()
                    {
                        text = Strings.UI.SANDBOXMENU.SLIDESMEDIUM, data = "medium"
                    }, //-- 	image = "world_size_medium.tex"},	--450x450
                    new()
                    {
                        text = Strings.UI.SANDBOXMENU.SLIDESLARGE, data = "large"
                    }, //-- 	image = "world_size_large.tex"},	--550x550
                    //--new(){ text = Strings.UI.SANDBOXMENU.SLIDESHUGE, data = "huge"},
                    //-- 		image = "world_size_huge.tex"},	--800x800
                };
            }
            
            //-- Fixup for frequency spinners that are _actually_ frequency (not density)
            if (Main.PLATFORM == "PS4")
            {
	            GROUP["monsters"].items["treeguard"] = new CustomiseItem
	            {
		            value = "default", enable = false, spinner = null, image = "treeguard.tex",
		            desc = freqency_descriptions_ps4_exceptions, order = 9
	            };
	            GROUP["monsters"].items["krampus"] = new CustomiseItem
	            {
		            value = "default", enable = false, spinner = null, image = "krampus.tex",
		            desc = freqency_descriptions_ps4_exceptions, order = 11
	            };
	            GROUP["monsters"].items["deerclops"] = new CustomiseItem
	            {
		            value = "default", enable = false, spinner = null, image = "deerclops.tex",
		            desc = freqency_descriptions_ps4_exceptions, order = 13
	            };
	            GROUP["monsters"].items["bearger"] = new CustomiseItem
	            {
		            value = "default", enable = false, spinner = null, image = "bearger.tex",
		            desc = freqency_descriptions_ps4_exceptions, order = 12
	            };
	            GROUP["monsters"].items["goosemoose"] = new CustomiseItem
	            {
		            value = "default", enable = false, spinner = null, image = "goosemoose.tex",
		            desc = freqency_descriptions_ps4_exceptions, order = 14
	            };
	            GROUP["monsters"].items["dragonfly"] = new CustomiseItem
	            {
		            value = "default", enable = false, spinner = null, image = "dragonfly.tex",
		            desc = freqency_descriptions_ps4_exceptions, order = 15
	            };
	            GROUP["monsters"].items["deciduousmonster"] = new CustomiseItem
	            {
		            value = "default", enable = false, spinner = null, image = "deciduouspoison.tex",
		            desc = freqency_descriptions_ps4_exceptions, order = 10
	            };

	            GROUP["animals"].items["hunt"] = new CustomiseItem
	            {
		            value = "default", enable = false, spinner = null, image = "tracks.tex",
		            desc = freqency_descriptions_ps4_exceptions, order = 13
	            };
	            GROUP["animals"].items["warg"] = new CustomiseItem
	            {
		            value = "default", enable = false, spinner = null, image = "warg.tex",
		            desc = freqency_descriptions_ps4_exceptions, order = 14
	            };

	            GROUP["misc"].items["weather"] = new CustomiseItem
	            {
		            value = "default", enable = false, spinner = null, image = "rain.tex",
		            desc = freqency_descriptions_ps4_exceptions, order = 11
	            };
	            GROUP["misc"].items["lightning"] = new CustomiseItem
	            {
		            value = "default", enable = false, spinner = null, image = "lightning.tex",
		            desc = freqency_descriptions_ps4_exceptions, order = 12
	            };
	            GROUP["misc"].items["frograin"] = new CustomiseItem
	            {
		            value = "default", enable = false, spinner = null, image = "frog_rain.tex",
		            desc = freqency_descriptions_ps4_exceptions, order = 13
	            };
	            GROUP["misc"].items["wildfires"] = new CustomiseItem
	            {
		            value = "default", enable = false, spinner = null, image = "smoke.tex",
		            desc = freqency_descriptions_ps4_exceptions, order = 14
	            };
            }
            
            foreach (CustomiseGroup customiseGroup in GROUP.Values)
            {
	            foreach (CustomiseItem customiseItem in customiseGroup.items.Values)
	            {
		            if (string.IsNullOrWhiteSpace(customiseItem.atlas))
			            customiseItem.atlas = "images/customization_porkland.xml";
	            }
            }
        }
    }
}