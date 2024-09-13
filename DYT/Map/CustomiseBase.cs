using System.Collections.Generic;

namespace DYT.Map
{
    public class CustomiseBase : Customise
    {
        private static List<SpinnerOption> branchingDescriptionList { get; } =
            new()
            {
                new SpinnerOption("Never", "never"),
                new SpinnerOption("Least", "least"),
                new SpinnerOption("Default", "default"),
                new SpinnerOption("Most", "most")
            };
        private static List<SpinnerOption> loopDescriptionList { get; } = new()
        {
            new SpinnerOption("Never", "never"),
            new SpinnerOption("Default", "default"),
            new SpinnerOption("Always", "always")
        };
    }
}