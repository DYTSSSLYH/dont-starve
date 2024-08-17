using System.Collections.Generic;

public class CustomPork : Custom
{
    private static List<Spinner.SpinnerOption> sizeDescriptionList { get; } = new List<Spinner.SpinnerOption>
    {
        new Spinner.SpinnerOption("Default", "default"),
        new Spinner.SpinnerOption("Medium", "medium"),
        new Spinner.SpinnerOption("Large", "large")
    };
    private static List<Spinner.SpinnerOption> seasonLengthDescriptionList { get; } =
        new List<Spinner.SpinnerOption> {
            new Spinner.SpinnerOption("None", "no_season"),
            new Spinner.SpinnerOption("Very Short", "very_short_season"),
            new Spinner.SpinnerOption("Short", "short_season"),
            new Spinner.SpinnerOption("Default", "default"),
            new Spinner.SpinnerOption("Long", "long_season"),
            new Spinner.SpinnerOption("Very Long", "very_long_season"),
            new Spinner.SpinnerOption("Random", "random")
        };
    private static List<Spinner.SpinnerOption> seasonStartDescriptionList { get; } =
        new List<Spinner.SpinnerOption> {
            new Spinner.SpinnerOption("Temperate", "temperate"),
            new Spinner.SpinnerOption("Humid", "humid"),
            new Spinner.SpinnerOption("Lush", "lush"),
            new Spinner.SpinnerOption("Random", "random")
        };
    private static List<Spinner.SpinnerOption> dayDescriptionList { get; } = new List<Spinner.SpinnerOption>
    {
        new Spinner.SpinnerOption("Default", "default"),

        new Spinner.SpinnerOption("Long Day", "long_day"),
        new Spinner.SpinnerOption("Long Dusk", "long_dusk"),
        new Spinner.SpinnerOption("Long Night", "long_night"),

        new Spinner.SpinnerOption("No Day", "no_day"),
        new Spinner.SpinnerOption("No Dusk", "no_dusk"),
        new Spinner.SpinnerOption("No Night", "no_night"),

        new Spinner.SpinnerOption("Only Day", "only_day"),
        new Spinner.SpinnerOption("Only Dusk", "only_dusk"),
        new Spinner.SpinnerOption("Long Night", "only_night"),
    };
    private static List<Spinner.SpinnerOption> frequencyDescriptionList { get; } =
        new List<Spinner.SpinnerOption> {
            new Spinner.SpinnerOption("None", "never"),
            new Spinner.SpinnerOption("Less", "rare"),
            new Spinner.SpinnerOption("Default", "default"),
            new Spinner.SpinnerOption("More", "often"),
            new Spinner.SpinnerOption("Lots", "always")
        };
    private static List<Spinner.SpinnerOption> yesNoDescriptionList { get; } = new List<Spinner.SpinnerOption>
    {
        new Spinner.SpinnerOption("Yes", "default"),
        new Spinner.SpinnerOption("No", "never")
    };

    
    public CustomPork()
    {
        group = new Dictionary<string, CustomiseGroup> {
            {"misc", new CustomiseGroup("World", null, true, new Dictionary<string, CustomiseItem> {
                {"world_size", new CustomiseItem("default", sizeDescriptionList, false,
                    "Images/customization_hamlet", "world_size")},
                {"temperate_season", new CustomiseItem("default", seasonLengthDescriptionList, true,
                    "Images/customization_hamlet", "temperate")},
                {"humid_season", new CustomiseItem("default", seasonLengthDescriptionList, true,
                    "Images/customization_hamlet", "humid")},
                {"lush_season", new CustomiseItem("default", seasonLengthDescriptionList, true,
                    "Images/customization_hamlet", "lush")},
                {"season_start", new CustomiseItem("temperate", seasonStartDescriptionList, false,
                    "Images/customization_hamlet", "season_start")},
                {"day", new CustomiseItem("default", dayDescriptionList, false,
                    "Images/customization_hamlet", "day")},
                {"weather", new CustomiseItem("default", frequencyDescriptionList, false,
                    "Images/customization_hamlet", "rain")},
                {"lightning", new CustomiseItem("default", frequencyDescriptionList, false,
                    "Images/customization_hamlet", "lightning")},
                {"fog", new CustomiseItem("default", yesNoDescriptionList, false,
                    "Images/customization_hamlet", "fog")},
                {"brambles", new CustomiseItem("default", yesNoDescriptionList, false,
                    "Images/customization_hamlet", "brambles")},
                {"hayfever", new CustomiseItem("default", yesNoDescriptionList, false,
                    "Images/customization_hamlet", "hayfever")},
                {"boons", new CustomiseItem("default", frequencyDescriptionList, false,
                    "Images/customization_hamlet", "skeletons")},
                {"glowfly_life_cycle", new CustomiseItem("default", yesNoDescriptionList, false,
                    "Images/customization_hamlet", "glowfly_life_cycle")},
                {"deep_jungle_fern_noise", new CustomiseItem("default", frequencyDescriptionList, false,
                    "Images/customization_hamlet", "noise_ferns")},
                {"jungle_border_vine", new CustomiseItem("default", frequencyDescriptionList, false,
                    "Images/customization_hamlet", "canopy_loops")},
                {"lost_relics", new CustomiseItem("default", frequencyDescriptionList, false,
                    "Images/customization_hamlet", "lost_relics")},
                {"pig_ruins_torch", new CustomiseItem("default", frequencyDescriptionList, false,
                    "Images/customization_hamlet", "crumbling_brazier")},
                {"vampire_bat", new CustomiseItem("default", frequencyDescriptionList, false,
                    "Images/customization_hamlet", "vampire_bats")},
                {"vampire_bat_cave", new CustomiseItem("default", frequencyDescriptionList, false,
                    "Images/customization_hamlet", "vampire_bat_caves")},
                {"pig_house_city", new CustomiseItem("default", yesNoDescriptionList, false,
                    "Images/customization_hamlet", "pig_houses")},
                {"pig_guard_tower", new CustomiseItem("default", yesNoDescriptionList, false,
                    "Images/customization_hamlet", "guard_towers")},
                {"pig_bandit", new CustomiseItem("default", frequencyDescriptionList, false,
                    "Images/customization_hamlet", "pig_bandit")},
                {"pig_ruins_entrance_small", new CustomiseItem("default", frequencyDescriptionList, false,
                    "Images/customization_hamlet", "small_ruins")},
                {"dart_traps", new CustomiseItem("default", yesNoDescriptionList, false,
                    "Images/customization_hamlet", "dart_traps")},
                {"spear_traps", new CustomiseItem("default", yesNoDescriptionList, false,
                    "Images/customization_hamlet", "spike_traps")},
                {"door_vines", new CustomiseItem("default", yesNoDescriptionList, false,
                    "Images/customization_hamlet", "creeping_vines")},
                {"pugalisk_fountain", new CustomiseItem("default", yesNoDescriptionList, false,
                    "Images/customization_hamlet", "pugalisk_fountain")}
            })},
            {"resources", new CustomiseGroup("Resources", frequencyDescriptionList, false,
                new Dictionary<string, CustomiseItem> {
                    {"flowers", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "flowers")},
                    {"flowers_rainforest", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "tropical_flowers")},
                    {"grass", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "tall_grass")},
                    {"grass_bunches", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "grass_bunches")},
                    {"sapling", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "sapling")},
                    {"reeds", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "reeds")},
                    {"rainforest_tree", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "rainforest_trees")},
                    {"clawpalmtree", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "claw_trees")},
                    {"tuber_tree", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "tuber_trees")},
                    {"tea_tree", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "tea_trees")},
                    {"rock_flippable", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "flipping_rocks")},
                    {"dung_pile", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "dung_piles")},
                    {"gnat_mound", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "gnat_mounds")},
                    {"lily_pad", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "lily_pads")},
                    {"lotus", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "lotus")},
                    {"nettle", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "nettle")},
                    {"hanging_vine", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "hanging_vines")},
                    {"ruined_sculptures", new CustomiseItem("default", frequencyDescriptionList, false,
                        "Images/customization_hamlet", "lost_sculptures")},
                    {"ant_comb_home", new CustomiseItem("default", yesNoDescriptionList, false,
                        "Images/customization_hamlet", "mant_comb_homes")},
                    {"ant_cave_lantern", new CustomiseItem("default", yesNoDescriptionList, false,
                        "Images/customization_hamlet", "mant_lamps")},
                    {"city_lamp", new CustomiseItem("default", yesNoDescriptionList, false,
                        "Images/customization_hamlet", "lamp_posts")},
                    {"rusted_hulks", new CustomiseItem("default", yesNoDescriptionList, false,
                        "Images/customization_hamlet", "rusted_hulks")}
                }
            )},
            {"unprepared", new CustomiseGroup("Food", frequencyDescriptionList, true,
                new Dictionary<string, CustomiseItem> {
                    {"aloe", new CustomiseItem("default", null, true,
                        "Images/customization_hamlet", "aloe")},
                    {"asparagus_planted", new CustomiseItem("default", null, true,
                        "Images/customization_hamlet", "asparagus")},
                    {"radish", new CustomiseItem("default", null, true,
                        "Images/customization_hamlet", "radish")},
                    {"mushroom", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "mushrooms")}
                }
            )},
            {"animals", new CustomiseGroup("Animals", frequencyDescriptionList, false,
                new Dictionary<string, CustomiseItem> {
                    {"butterfly", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "butterfly")},
                    {"birds", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "kingfisher")},
                    {"glowfly", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "glowflies")},
                    {"hippopotamoose", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "hippopotamoose")},
                    {"pog", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "pogs")},
                    {"pangolden", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "pangolden")},
                    {"peagawk", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "peagawk")},
                    {"thunderbird", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "thunderbirds")},
                    {"dung_beetle", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "dung_beetles")},
                    {"piko", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "orange_pikos")}
                }
            )},
            {"monsters", new CustomiseGroup("Monsters", frequencyDescriptionList, false,
                new Dictionary<string, CustomiseItem> {
                    {"mandrake_man", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "mandrake_men")},
                    {"ant_man", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "mants")},
                    {"giant_grub", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "giant_grubs")},
                    {"frog_poison", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "poison_dart_frogs")},
                    {"mosquito", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "mosquitos")},
                    {"bat", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "bats")},
                    {"weevole", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "weevole")},
                    {"gnat", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "gnat")},
                    {"bill", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "platypine")},
                    {"snake", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "snakes")},
                    {"scorpion", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "scorpions")},
                    {"grabbing_vine", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "grabbing_vines")},
                    {"mean_flytrap", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "mean_flytraps")},
                    {"adult_flytrap", new CustomiseItem("default", null, false,
                        "Images/customization_hamlet", "adult_flytraps")},
                    {"pig_ghost", new CustomiseItem("default", yesNoDescriptionList, false,
                        "Images/customization_hamlet", "pig_ghosts")},
                    {"roc", new CustomiseItem("default", yesNoDescriptionList, false,
                        "Images/customization_hamlet", "roc")},
                    {"pugalisk", new CustomiseItem("default", yesNoDescriptionList, false,
                        "Images/customization_hamlet", "pugalisk")},
                    {"ant_queen", new CustomiseItem("default", yesNoDescriptionList, false,
                        "Images/customization_hamlet", "mant_queen")}
                }
            )}
        };
    }
}