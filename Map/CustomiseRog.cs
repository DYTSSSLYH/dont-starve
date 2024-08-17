using System.Collections.Generic;

public class CustomiseRog : Custom
{
    private static List<Spinner.SpinnerOption> sizeDescriptionList { get; } = new List<Spinner.SpinnerOption>
    {
        new Spinner.SpinnerOption("Default", "default"),
        new Spinner.SpinnerOption("Medium", "medium"),
        new Spinner.SpinnerOption("Large", "large"),
        new Spinner.SpinnerOption("Huge", "huge")
    };
    private static List<Spinner.SpinnerOption> branchingDescriptionList { get; } =
        new List<Spinner.SpinnerOption> {
            new Spinner.SpinnerOption("Never", "never"),
            new Spinner.SpinnerOption("Least", "least"),
            new Spinner.SpinnerOption("Default", "default"),
            new Spinner.SpinnerOption("Most", "most")
        };
    private static List<Spinner.SpinnerOption> loopDescriptionList { get; } = new List<Spinner.SpinnerOption>
    {
        new Spinner.SpinnerOption("Never", "never"),
        new Spinner.SpinnerOption("Default", "default"),
        new Spinner.SpinnerOption("Always", "always")
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
            new Spinner.SpinnerOption("Autumn or Spring", "default"),
            new Spinner.SpinnerOption("Autumn", "autumn"),
            new Spinner.SpinnerOption("Winter", "winter"),
            new Spinner.SpinnerOption("Spring", "spring"),
            new Spinner.SpinnerOption("Summer", "summer"),
            new Spinner.SpinnerOption("Random", "random")
        };
    private static List<Spinner.SpinnerOption> dayDescriptionList { get; } = new List<Spinner.SpinnerOption>
    {
        new Spinner.SpinnerOption("Only Day", "only_day"),
        new Spinner.SpinnerOption("Only Dusk", "only_dusk"),
        new Spinner.SpinnerOption("Long Night", "only_night"),
        new Spinner.SpinnerOption("Default", "default"),
        new Spinner.SpinnerOption("Long Day", "long_day"),
        new Spinner.SpinnerOption("Long Dusk", "long_dusk"),
        new Spinner.SpinnerOption("Long Night", "long_night")
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

    
    public CustomiseRog()
    {
        group = new Dictionary<string, CustomiseGroup> {
            {"misc", new CustomiseGroup("World", null, true, new Dictionary<string, CustomiseItem>
                {
                    {"world_size", new CustomiseItem("default", sizeDescriptionList, false, null, "world_size")},
                    {
                        "branching",
                        new CustomiseItem("default", branchingDescriptionList, false, null, "world_branching")
                    },
                    {"loop", new CustomiseItem("default", loopDescriptionList, false, null, "world_loop")},
                    {"autumn", new CustomiseItem("default", seasonLengthDescriptionList, true, null, "autumn")},
                    {"winter", new CustomiseItem("default", seasonLengthDescriptionList, true, null, "winter")},
                    {"spring", new CustomiseItem("default", seasonLengthDescriptionList, true, null, "spring")},
                    {"summer", new CustomiseItem("default", seasonLengthDescriptionList, true, null, "summer")},
                    {
                        "season_start",
                        new CustomiseItem("default", seasonStartDescriptionList, false, null, "season_start")
                    },
                    {"day", new CustomiseItem("default", dayDescriptionList, false, null, "day")},
                    {"cave_entrance", new CustomiseItem("default", yesNoDescriptionList, false, null, "caves")},
                    {"weather", new CustomiseItem("default", frequencyDescriptionList, false, null, "rain")},
                    {
                        "lightning",
                        new CustomiseItem("default", frequencyDescriptionList, false, null, "lightning")
                    },
                    {
                        "frog_rain",
                        new CustomiseItem("default", frequencyDescriptionList, false, null, "frog_rain")
                    },
                    {"wildfires", new CustomiseItem("default", frequencyDescriptionList, false, null, "smoke")},
                    {
                        "touchstone",
                        new CustomiseItem("default", frequencyDescriptionList, false, null, "resurrection")
                    },
                    {"boons", new CustomiseItem("default", frequencyDescriptionList, false, null, "skeletons")}
                }
            )},
            {"resources", new CustomiseGroup("Resources", frequencyDescriptionList, false,
                new Dictionary<string, CustomiseItem>
                {
                    {"flowers",new CustomiseItem("default", null, false, null, "flowers")},
                    {"grass",new CustomiseItem("default", null, false, null, "grass")},
                    {"sapling",new CustomiseItem("default", null, false, null, "sapling")},
                    {"marsh_bush",new CustomiseItem("default", null, false, null, "marsh_bush")},
                    {"tumbleweed",new CustomiseItem("default", null, false, null, "tumbleweeds")},
                    {"reeds",new CustomiseItem("default", null, false, null, "reeds")},
                    {"trees",new CustomiseItem("default", null, false, null, "trees")},
                    {"flint",new CustomiseItem("default", null, false, null, "flint")},
                    {"rock",new CustomiseItem("default", null, false, null, "rock")},
                    {"rock_ice",new CustomiseItem("default", null, false, null, "iceboulder")}
                }
            )},
            {"unprepared", new CustomiseGroup("Food", frequencyDescriptionList, true,
                new Dictionary<string, CustomiseItem>
                {
                    {"berry_bush", new CustomiseItem("default", null, true, null, "berrybush")},
                    {"carrot", new CustomiseItem("default", null, true, null, "carrot")},
                    {"mushroom", new CustomiseItem("default", null, false, null, "mushrooms")},
                    {"cactus", new CustomiseItem("default", null, false, null, "cactus")}
                }
            )},
            {"animals", new CustomiseGroup("Animals", frequencyDescriptionList, false,
                new Dictionary<string, CustomiseItem>
                {
                    {"mandrake",new CustomiseItem("default", null, false, null, "mandrake")},
                    {"rabbits",new CustomiseItem("default", null, false, null, "rabbits")},
                    {"moles",new CustomiseItem("default", null, false, null, "mole")},
                    {"butterfly",new CustomiseItem("default", null, false, null, "butterfly")},
                    {"birds",new CustomiseItem("default", null, false, null, "birds")},
                    {"buzzard",new CustomiseItem("default", null, false, null, "buzzard")},
                    {"catcoon",new CustomiseItem("default", null, false, null, "catcoon")},
                    {"perd",new CustomiseItem("default", null, false, null, "perd")},
                    {"pigs",new CustomiseItem("default", null, false, null, "pigs")},
                    {"lightning_goat",new CustomiseItem("default", null, false, null, "lightning_goat")},
                    {"beefalo",new CustomiseItem("default", null, false, null, "beefalo")},
                    {"beefalo_heat",new CustomiseItem("default", null, false, null, "beefaloheat")},
                    {"hunt",new CustomiseItem("default", null, false, null, "tracks")},
                    {"warg",new CustomiseItem("default", null, false, null, "warg")},
                    {"penguins",new CustomiseItem("default", null, false, null, "penguin")},
                    {"frogs",new CustomiseItem("default", null, false, null, "ponds")},
                    {"bees",new CustomiseItem("default", null, false, null, "beehive")},
                    {"angry_bees",new CustomiseItem("default", null, false, null, "wasphive")},
                    {"tall_birds",new CustomiseItem("default", null, false, null, "tallbirds")}
                }
            )},
            {"monsters", new CustomiseGroup("Monsters", frequencyDescriptionList, false,
                new Dictionary<string, CustomiseItem>
                {
                    {"spiders",new CustomiseItem("default", null, false, null, "spiders")},
                    {"hounds",new CustomiseItem("default", null, false, null, "hounds")},
                    {"hound_mound",new CustomiseItem("default", null, false, null, "houndmound")},
                    {"merm",new CustomiseItem("default", null, false, null, "merms")},
                    {"tentacles",new CustomiseItem("default", null, false, null, "tentacles")},
                    {"chess",new CustomiseItem("default", null, false, null, "chess_monsters")},
                    {"lureplants",new CustomiseItem("default", null, false, null, "lureplant")},
                    {"walrus",new CustomiseItem("default", null, false, null, "mactusk")},
                    {"liefs",new CustomiseItem("default", null, false, null, "liefs")},
                    {"deciduous_monster",new CustomiseItem("default", null, false, null, "deciduouspoison")},
                    {"krampus",new CustomiseItem("default", null, false, null, "krampus")},
                    {"bearger",new CustomiseItem("default", null, false, null, "bearger")},
                    {"deerclops",new CustomiseItem("default", null, false, null, "deerclops")},
                    {"goose_moose",new CustomiseItem("default", null, false, null, "goosemoose")},
                    {"dragonfly",new CustomiseItem("default", null, false, null, "dragonfly")}
                }
            )}
        };
    }
}