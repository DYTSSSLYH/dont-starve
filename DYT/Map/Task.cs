using System.Collections.Generic;
using UnityEngine;

namespace DYT.Map
{
    public class Task
    {
        public string id;
        public List<string> locks; //-- what locks this task
        public List<string> keys_given; //-- the key that this task provides
        public Dictionary<string, int> room_choices;
        public int room_bg;
        public string background_room;
        public Color colour;

        public Task(){}
        public Task(string id, Task data)
        {
            this.id = id;
            
            locks = data.locks;
            keys_given = data.keys_given;
            room_choices = data.room_choices;
            room_bg = data.room_bg;
            background_room = data.background_room;
            colour = data.colour;
        }
    }
}