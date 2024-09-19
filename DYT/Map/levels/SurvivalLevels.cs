using Newtonsoft.Json;

namespace DYT.Map.levels
{
    public class SurvivalLevels
    {
        static SurvivalLevels()
        {
            //----------------------------------
            //-- Survival levels
            //----------------------------------
            bool rog_installed = false;
            string level_type = null;

            if (!string.IsNullOrWhiteSpace(Main.GEN_PARAMETERS))
            {
                GenParameters parameters =
                    JsonConvert.DeserializeObject<GenParameters>(Main.GEN_PARAMETERS);
                rog_installed = parameters.ROGEnabled;
                level_type = parameters.level_type;
            }

            if (DLCSupportWorldGen.IsDLCEnabled(DLCSupportWorldGen.REIGN_OF_GIANTS) || rog_installed ||
                level_type == "shipwrecked" || level_type == "volcano")
                new SurvivalSwLevels();
            else new SurvivalStandardLevels();
        }
    }
}