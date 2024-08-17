using System.Collections.Generic;

public class CustomiseBase : Custom
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
    private static List<Spinner.SpinnerOption> seasonDescriptionList { get; } = new List<Spinner.SpinnerOption>
    {
        new Spinner.SpinnerOption("Only Summer", "only_summer"),
        new Spinner.SpinnerOption("Only Winter", "only_winter"),
        new Spinner.SpinnerOption("Default", "default"),
        new Spinner.SpinnerOption("Long Summer", "long_summer"),
        new Spinner.SpinnerOption("Long Winter", "long_winter"),
        new Spinner.SpinnerOption("Long Both", "long_both"),
        new Spinner.SpinnerOption("Short Both", "short_both")
    };
    private static List<Spinner.SpinnerOption> seasonStartDescriptionList { get; } =
        new List<Spinner.SpinnerOption> {
            new Spinner.SpinnerOption("Summer", "summer"),
            new Spinner.SpinnerOption("Winter", "winter")
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

    public CustomiseBase()
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
                    {"season", new CustomiseItem("default", seasonDescriptionList, false, null, "season")},
                    {
                        "season_start",
                        new CustomiseItem("summer", seasonStartDescriptionList, false, null, "season_start")
                    },
                    {"day", new CustomiseItem("default", dayDescriptionList, false, null, "day")},
                    {"weather", new CustomiseItem("default", frequencyDescriptionList, false, null, "rain")},
                    {
                        "lightning",
                        new CustomiseItem("default", frequencyDescriptionList, false, null, "lightning")
                    },
                    {"cave_entrance", new CustomiseItem("default", yesNoDescriptionList, false, null, "caves")},
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
                    {"reeds",new CustomiseItem("default", null, false, null, "reeds")},
                    {"trees",new CustomiseItem("default", null, false, null, "trees")},
                    {"flint",new CustomiseItem("default", null, false, null, "flint")},
                    {"rocks",new CustomiseItem("default", null, false, null, "rocks")},
                    {"rock",new CustomiseItem("default", null, false, null, "rock")}
                }
            )},
            {"unprepared", new CustomiseGroup("Food", frequencyDescriptionList, true,
                new Dictionary<string, CustomiseItem>
                {
                    {"berry_bush",new CustomiseItem("default", null, true, null, "berrybush")},
                    {"carrot",new CustomiseItem("default", null, true, null, "carrot")},
                    {"mushroom",new CustomiseItem("default", null, false, null, "mushrooms")}
                }
            )},
            {"animals", new CustomiseGroup("Animals", frequencyDescriptionList, false,
                new Dictionary<string, CustomiseItem>
                {
                    {"mandrake",new CustomiseItem("default", null, false, null, "mandrake")},
                    {"rabbits",new CustomiseItem("default", null, false, null, "rabbits")},
                    {"butterfly",new CustomiseItem("default", null, false, null, "butterfly")},
                    {"birds",new CustomiseItem("default", null, false, null, "birds")},
                    {"perd",new CustomiseItem("default", null, false, null, "perd")},
                    {"pigs",new CustomiseItem("default", null, false, null, "pigs")},
                    {"beefalo",new CustomiseItem("default", null, false, null, "beefalo")},
                    {"beefalo_heat",new CustomiseItem("default", null, false, null, "beefaloheat")},
                    {"hunt",new CustomiseItem("default", null, false, null, "tracks")},
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
                    {"merm",new CustomiseItem("default", null, false, null, "merms")},
                    {"tentacles",new CustomiseItem("default", null, false, null, "tentacles")},
                    {"chess",new CustomiseItem("default", null, false, null, "chess_monsters")},
                    {"lureplants",new CustomiseItem("default", null, false, null, "lureplant")},
                    {"walrus",new CustomiseItem("default", null, false, null, "mactusk")},
                    {"liefs",new CustomiseItem("default", null, false, null, "liefs")},
                    {"krampus",new CustomiseItem("default", null, false, null, "krampus")},
                    {"deerclops",new CustomiseItem("default", null, false, null, "deerclops")}
                }
            )}
        };
    }
}