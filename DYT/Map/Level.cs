using System.Collections.Generic;
using DYT.Map.levels;

namespace DYT.Map
{
    public class LEVELTYPE
    {
        public static int
            SURVIVAL = 1,
            CAVE = 2,
            ADVENTURE = 3,
            TEST = 4,
            UNKNOWN = 5,
            CUSTOM = 6,
            VOLCANO = 7,
            SHIPWRECKED = 8,
            PORKLAND = 9;
    }

    public class Level
    {
        public class Piece
        {
            public string restrict_to;
            public int count;
            public List<string> tasks;
        }
        public bool override_level_string;
        public string id;
        public string name;
        public string desc;
        public List<string> tasks;
        public Dictionary<object, object> overrides;
        public Dictionary<string, Substitute> substitutes;
        public Dictionary<string, List<List<string>>> override_triggers;
        public Dictionary<string, Piece> set_pieces;
        public int numoptionaltasks;
        public bool nomaxwell;
        public List<string> optionaltasks;
        public bool hideminimap;
        public string teleportaction;
        public string teleportmaxwell;
        public int min_playlist_position;
        public int max_playlist_position = 999;
        public List<string> ordered_story_setpieces;
        public List<string> required_prefabs;
        public int numrandom_set_pieces;
        public List<string> random_set_pieces;

        public Level(){}
        public Level(Level data)
        {
            id = string.IsNullOrWhiteSpace(data.id) ? "UNKNOWN_ID" : data.id;
            name = data.name ?? "";
            desc = data.desc ?? "";
            tasks = data.tasks ?? new List<string>();
            overrides = data.overrides ?? new Dictionary<object, object>();
            substitutes = data.substitutes ?? new Dictionary<string, Substitute>();
            override_triggers = data.override_triggers;
            set_pieces = data.set_pieces ?? new Dictionary<string, Piece>();
            numoptionaltasks = data.numoptionaltasks;
            nomaxwell = data.nomaxwell;
            optionaltasks = data.optionaltasks ?? new List<string>();
            hideminimap = data.hideminimap;
            teleportaction = data.teleportaction;
            teleportmaxwell = data.teleportmaxwell;
            min_playlist_position = data.min_playlist_position;
            max_playlist_position = data.max_playlist_position;
            ordered_story_setpieces = data.ordered_story_setpieces;
            required_prefabs = data.required_prefabs;

            numrandom_set_pieces = data.numrandom_set_pieces;
            random_set_pieces = data.random_set_pieces;
        }
    }
}