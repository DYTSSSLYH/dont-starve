using System;
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
        public class StartTask
        {
            public float weight;
            public string start_setpiece;
            public string start_node;
        }
        public class SelectedTask
        {
            public int min;
            public int max;
            public List<string> task_choices;
        }
        public class WaterContent
        {
            public Func<int, bool> checkFn;
        }
        public class Treasure
        {
            public int count;
            public List<string> treasuretasks;
            public List<string> maptasks;
            public List<string> tasks;
        }
        
        public bool override_level_string;
        public object required_treasures;
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
        public Dictionary<string, int> required_prefab_count;
        public int[] background_node_range;
        public int numrandom_set_pieces;
        public List<string> random_set_pieces;
        public List<SelectedTask> selectedtasks;
        public Dictionary<string, StartTask> start_tasks;
        public Dictionary<string, Treasure> treasures;
        public int numoptional_treasures;
        public object optional_treasures;
        public int numrandom_treasures;
        public List<string> random_treasures;
        public Dictionary<string, WaterContent> water_content;
        public Dictionary<string, Piece> water_prefill_setpieces;

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
            required_prefab_count = data.required_prefab_count ?? new Dictionary<string, int>();
            background_node_range = data.background_node_range;

            numrandom_set_pieces = data.numrandom_set_pieces;
            random_set_pieces = data.random_set_pieces;

            selectedtasks = data.selectedtasks ?? new List<SelectedTask>();
            start_tasks = data.start_tasks ?? new Dictionary<string, StartTask>();
            
            treasures = data.treasures ?? new Dictionary<string, Treasure>();
            numoptional_treasures = data.numoptional_treasures;
            optional_treasures = data.optional_treasures;
            numrandom_treasures = data.numrandom_treasures;
            random_treasures = data.random_treasures ?? new List<string>();
            
            water_content = data.water_content ?? new Dictionary<string, WaterContent>();
            water_prefill_setpieces = data.water_prefill_setpieces ?? new Dictionary<string, Piece>();
        }
    }
}