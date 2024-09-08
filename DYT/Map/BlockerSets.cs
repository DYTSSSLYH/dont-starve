using System.Collections.Generic;

namespace DYT.Map
{
    public class BlockerSets
    {
        public static List<string>

            //-- Walls are kind of "misc"

            walls_easy = new() { "DenseRocks", "InsanityWall" },
            walls_hard = new() { "SanityWall" },
            all_walls = Util.ArrayUnion(walls_easy, walls_hard),

            //-- By Monsters

            chess_easy = new(),
            chess_hard = new() { "Chessfield", "ChessfieldA", "ChessfieldB", "ChessfieldC" },
            all_chess = Util.ArrayUnion(chess_easy, chess_hard),

            tallbirds_easy = new() { "TallbirdfieldSmallA", "Tallbirdfield" },
            tallbirds_hard = new() { "TallbirdfieldA", "TallbirdfieldB" },
            all_tallbirds = Util.ArrayUnion(tallbirds_easy, tallbirds_hard),

            spiders_easy = new() { "SpiderfieldEasy", "SpiderfieldEasyA", "SpiderfieldEasyB" },
            spiders_hard = new() { "Spiderfield", "SpiderfieldA", "SpiderfieldB", "SpiderfieldC" },
            all_spiders = Util.ArrayUnion(spiders_easy, spiders_hard),

            bees_easy = new() { "Waspnests" },
            bees_hard = new(),
            all_bees = Util.ArrayUnion(bees_easy, bees_hard),

            pigs_easy = new() { "PigGuardpostEasy" },
            pigs_hard = new() { "PigGuardpost", "PigGuardpostB" },
            all_pigs = Util.ArrayUnion(pigs_easy, pigs_hard),

            tentacles_easy = new() { "TentaclelandSmallA" },
            tentacles_hard = new() { "TentaclelandA", "Tentacleland" },
            all_tentacles = Util.ArrayUnion(tentacles_easy, tentacles_hard),

            merms_easy = new(),
            merms_hard = new() { "Mermfield" },
            all_merms = Util.ArrayUnion(merms_easy, merms_hard),

            hounds_easy = new(),
            hounds_hard = new() { "Moundfield" },
            all_hounds = Util.ArrayUnion(hounds_easy, hounds_hard),

            //-- By terrain

            forest_easy = Util.ArrayUnion(spiders_easy, pigs_easy),
            forest_hard = Util.ArrayUnion(spiders_hard, pigs_hard),
            all_forest = Util.ArrayUnion(forest_easy, forest_hard),

            rocky_easy = Util.ArrayUnion(tallbirds_easy, pigs_easy, hounds_easy),
            rocky_hard = Util.ArrayUnion(tallbirds_hard, pigs_hard, hounds_hard),
            all_rocky = Util.ArrayUnion(rocky_easy, rocky_hard),

            grass_easy = Util.ArrayUnion(bees_easy, pigs_easy),
            grass_hard = Util.ArrayUnion(bees_hard, pigs_hard),
            all_grass = Util.ArrayUnion(grass_easy, grass_hard),

            marsh_easy = Util.ArrayUnion(tentacles_easy, merms_easy),
            marsh_hard = Util.ArrayUnion(tentacles_hard, merms_hard),
            all_marsh = Util.ArrayUnion(marsh_easy, marsh_hard),

            //-- Some special seasonal ones...

            winter_hard = new() { "Deerclopsfield", "Walrusfield" },

            //-- Meta-sets
            all_easy = Util.ArrayUnion(pigs_easy, spiders_easy, tallbirds_easy,
                chess_easy, tentacles_easy, walls_easy),

            all_hard = Util.ArrayUnion(pigs_hard, spiders_hard, tallbirds_hard,
                chess_hard, tentacles_hard, walls_hard),

            //-- Note, this "all" actually skips out on some super-specific ones like the winter ones.
            all = Util.ArrayUnion(all_easy, all_hard),

            all_hard_winter = Util.ArrayUnion(all_hard, winter_hard);
    }
}