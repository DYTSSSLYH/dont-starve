namespace DYT.Map.levels
{
    public class VolcanoLevels
    {
        static VolcanoLevels()
        {
            //----------------------------------
            //-- Volcano levels
            //----------------------------------

            Levels.AddLevel(LEVELTYPE.VOLCANO, new Level
            {
                id = "VOLCANO_LEVEL",
                name = "VOLCANO_LEVEL",
                overrides =
                {
                    { "world_size", "mini" },
                    { "loop_percent", "always" },
                    //--{"waves", 			"off"},
                    { "location", "volcanolevel" },
                    { "boons", "never" },
                    { "poi", "never" },
                    { "traps", "never" },
                    { "protected", "never" },
                    { "start_setpeice", "VolcanoStart" },
                    { "start_node", "VolcanoNoise" },
                },

                tasks =
                {
                    "Volcano"
                },

                background_node_range = new[] { 0, 0 },
                required_prefabs =
                {
                    "volcano_altar",
                    "obsidian_workbench"
                },
            });
        }
    }
}