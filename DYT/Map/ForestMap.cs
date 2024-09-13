using System.Collections.Generic;
using Newtonsoft.Json;

namespace DYT.Map
{
    public class ForestMap
    {
        public static Dictionary<string, float> MULTIPLY = new()
        {
            ["never"] = 0,
            ["rare"] = 0.5f,
            ["default"] = 1,
            ["often"] = 1.5f,
            ["mostly"] = 1.67f, //-- Not sure this is getting used...?
            ["always"] = 2,
        };
        
        private static bool SKIP_GEN_CHECKS = false;
        private static string level_type = "";
        private static List<string> merm = new(){ "mermhouse" };
        private static List<string> trees = new()
        {
            "evergreen", "evergreen_sparse", "deciduoustree", "marsh_tree"
        };
        private static List<string> rocks = new(){"rocks", "rock1", "rock2", "rock_flintless"};
        private static List<string> grass = new(){"grass","grass_tall","grass_tall_patch"};
        private static Customise customise;

        
        static ForestMap()
        {
            new Terrain();
            new Water();
            new TreasureHunt();


            if (!string.IsNullOrWhiteSpace(WorldGenMain.GEN_PARAMETERS))
            {
                GenParameters parameters =
                    JsonConvert.DeserializeObject<GenParameters>(WorldGenMain.GEN_PARAMETERS);
                level_type = parameters.level_type;
            }

            if (level_type == "shipwrecked" || level_type == "volcano")
            {
                merm = new List<string> { "mermhouse_fisher" };
                trees = new List<string> { "jungletree", "palmtree", "mangrovetree" };
                rocks = new List<string>
                {
                    "rocks", "rock1", "rock2", "rock_flintless", "magmarock", "magmarock_gold"
                };
                grass = new List<string> { "grass", "grass_water" };
            }


            customise = new CustomisePork();
        }
    }
}