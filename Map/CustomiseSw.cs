using System.Collections.Generic;

public class CustomSw : Custom
{
    private static List<Spinner.SpinnerOption> sizeDescriptionList { get; } = new List<Spinner.SpinnerOption>
    {
        new Spinner.SpinnerOption("Default", "default"),
        new Spinner.SpinnerOption("Medium", "medium"),
        new Spinner.SpinnerOption("Large", "large"),
        new Spinner.SpinnerOption("Huge", "huge")
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
            new Spinner.SpinnerOption("Mild", "mild"),
            new Spinner.SpinnerOption("Hurricane", "wet"),
            new Spinner.SpinnerOption("Monsoon", "green"),
            new Spinner.SpinnerOption("Dry", "dry"),
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
    private static List<Spinner.SpinnerOption> rateDescriptionList { get; } = new List<Spinner.SpinnerOption>
    {
        new Spinner.SpinnerOption("None", "never"),
        new Spinner.SpinnerOption("Much Less", "very_rare"),
        new Spinner.SpinnerOption("Less", "rare"),
        new Spinner.SpinnerOption("Default", "default"),
        new Spinner.SpinnerOption("More", "often"),
        new Spinner.SpinnerOption("Lots", "always")
    };

    
    public CustomSw()
    {
        group = new Dictionary<string, CustomiseGroup> {
            {"misc", new CustomiseGroup("World", null, true, new Dictionary<string, CustomiseItem> {
                {"world_size", new CustomiseItem("default", sizeDescriptionList, false,
                    "Images/customization_shipwrecked", "world_size")},
                {"mild_season", new CustomiseItem("default", seasonLengthDescriptionList, true,
                    "Images/customization_shipwrecked", "mild")},
                {"wet_season", new CustomiseItem("default", seasonLengthDescriptionList, true,
                    "Images/customization_shipwrecked", "hurricane")},
                {"green_season", new CustomiseItem("default", seasonLengthDescriptionList, true,
                    "Images/customization_shipwrecked", "monsoon")},
                {"dry_season", new CustomiseItem("default", seasonLengthDescriptionList, true,
                    "Images/customization_shipwrecked", "dry")},
                {"season_start", new CustomiseItem("mild", seasonStartDescriptionList, false,
                    "Images/customization_shipwrecked", "season_start")},
                {"day", new CustomiseItem("default", dayDescriptionList, false,
                    "Images/customization_shipwrecked", "day")},
                {"weather", new CustomiseItem("default", frequencyDescriptionList, false,
                    "Images/customization_shipwrecked", "rain")},
                {"lightning", new CustomiseItem("default", frequencyDescriptionList, false,
                    "Images/customization_shipwrecked", "lightning")},
                {"touchstone", new CustomiseItem("default", frequencyDescriptionList, false,
                    "Images/customization_shipwrecked", "resurrection")},
                {"boons", new CustomiseItem("default", frequencyDescriptionList, false,
                    "Images/customization_shipwrecked", "skeletons")},
                {"volcano", new CustomiseItem("default", yesNoDescriptionList, false,
                    "Images/customization_shipwrecked", "volcano")},
                {"dragoonegg", new CustomiseItem("default", frequencyDescriptionList, false,
                    "Images/customization_shipwrecked", "dragooneggs")},
                {"tides", new CustomiseItem("default", yesNoDescriptionList, false,
                    "Images/customization_shipwrecked", "tides")},
                {"floods", new CustomiseItem("default", frequencyDescriptionList, false,
                    "Images/customization_shipwrecked", "floods")},
                {"ocean_waves", new CustomiseItem("default", rateDescriptionList, false,
                    "Images/customization_shipwrecked", "waves")},
                {"poison", new CustomiseItem("default", yesNoDescriptionList, false,
                    "Images/customization_shipwrecked", "poison")}
            })},
            {"resources", new CustomiseGroup("Resources", frequencyDescriptionList, false,
                new Dictionary<string, CustomiseItem> {
                    {"flowers",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "flowers")},
                    {"grass",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "grass")},
                    {"sapling",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "sapling")},
                    {"reeds",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "reeds")},
                    {"trees",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "trees")},
                    {"flint",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "flint")},
                    {"rock",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "rock")},
                    
                    {"fishinhole",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "shoals")},
                    {"seashell",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "seashell")},
                    {"bush_vine",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "vines")},
                    {"seaweed",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "seaweed")},
                    {"sandhill",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "sand")},
                    {"crate",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "crates")},
                    {"bioluminescence",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "bioluminescence")},
                    {"coral",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "coral")},
                    {"coral_brain_rock",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "braincoral")},
                    {"bamboo",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "bamboo")},
                    {"tidalpool",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "tidalpools")},                    
                    {"poison_hole",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "poisonhole")}
                }
            )},
            {"unprepared", new CustomiseGroup("Food", frequencyDescriptionList, true,
                new Dictionary<string, CustomiseItem> {
                    {"berry_bush", new CustomiseItem("default", null, true,
                        "Images/customization_shipwrecked", "berrybush")},
                    {"sweet_potato", new CustomiseItem("default", null, true,
                        "Images/customization_shipwrecked", "sweetpotatos")},
                    {"mushroom", new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "mushrooms")},
                    
                    {"limpets", new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "limpets")},
                    {"mussel_farm", new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "mussels")}
                }
            )},
            {"animals", new CustomiseGroup("Animals", frequencyDescriptionList, false,
                new Dictionary<string, CustomiseItem> {
                    {"butterfly",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "butterfly")},
                    {"birds",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "birds")},
                    {"wildbores",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "wildbores")},
                    {"bees",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "beehive")},
                    {"angry_bees",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "wasphive")},
                    {"tall_birds",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "tallbirds")},
                    
                    {"whale_hunt",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "whales")},
                    {"crabhole",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "crabbits")},
                    {"ox",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "ox")},
                    {"solofish",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "dogfish")},
                    {"doydoy",new CustomiseItem("default", yesNoDescriptionList, false,
                        "Images/customization_shipwrecked", "doydoy")},
                    {"jellyfish",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "jellyfish")},
                    {"lobster",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "lobsters")},
                    {"seagull",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "seagulls")},
                    {"ballphin",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "ballphins")},
                    {"primeape",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "monkeys")}
                }
            )},
            {"monsters", new CustomiseGroup("Monsters", frequencyDescriptionList, false,
                new Dictionary<string, CustomiseItem> {
                    {"spiders",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "spiders")},
                    {"crocodog",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "crocodog")},
                    {"merm",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "merms")},
                    {"lureplants",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "lureplant")},
                    {"treeguard",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "palmguard")},
                    {"krampus",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "krampus")},
                    
                    {"twister",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "twister")},
                    {"tigershark",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "tigershark")},
                    {"kraken",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "kraken")},
                    {"flup",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "flups")},
                    {"mosquito",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "mosquitos")},
                    {"swordfish",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "swordfish")},
                    {"stungray",new CustomiseItem("default", null, false,
                        "Images/customization_shipwrecked", "stinkrays")}
                }
            )}
        };
    }
}