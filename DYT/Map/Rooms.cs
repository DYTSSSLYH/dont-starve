using System;
using System.Collections.Generic;
using UnityEngine;

namespace DYT.Map
{
	public class Room
	{
		public Color colour;
		public int value;
	        
		public class Contents
		{
			public Dictionary<string, Func<float>> countprefabs;
		}
		public Contents contents;
	}
    public class Rooms
    {
        public static void MakeSetpieceBlockerRoom(object blocker_name){}

        public static Dictionary<string, Room> rooms = new();
        public static void AddRoom(string name, Room data)
        {
            rooms.Add(name, data);
        }
        

	    static Rooms()
	    {
			// -- "Special" rooms
			// require("map/rooms/test")
			// require("map/rooms/pigs")
			// require("map/rooms/merms")
			// require("map/rooms/chess")
			// require("map/rooms/spider")
			// require("map/rooms/walrus")
			// require("map/rooms/wormhole")
			// require("map/rooms/beefalo")
			// require("map/rooms/graveyard")
			// require("map/rooms/tallbird")
			// require("map/rooms/bee")
			// require("map/rooms/mandrake")
			//
			// require("map/rooms/caves")
			// require("map/rooms/ruins")
			//
			// require("map/rooms/blockers")
			// require("map/rooms/starts")
			//
			// -- "Background" rooms
			//
			// require("map/rooms/terrain_dirt")
			// require("map/rooms/terrain_forest")
			// require("map/rooms/terrain_grass")
			// require("map/rooms/terrain_impassable")
			// require("map/rooms/terrain_marsh")
			// require("map/rooms/terrain_noise")
			// require("map/rooms/terrain_rocky")
			// require("map/rooms/terrain_savanna")
			//
			// require("map/rooms/terrain_sinkhole")
			// require("map/rooms/terrain_fungus")
			// require("map/rooms/terrain_cave")
			// require("map/rooms/terrain_mazes")
			//
			// -- SW ROOMS
			// require("map/rooms/terrain_beach")
			// require("map/rooms/terrain_island")
			// require("map/rooms/terrain_jungle")
			// require("map/rooms/terrain_ocean")
			// require("map/rooms/terrain_tidalmarsh")
			// require("map/rooms/terrain_magmafield")
			// require("map/rooms/terrain_meadow")
			// require("map/rooms/terrain_mangrove")
			// require("map/rooms/shipwrecked_rooms")
			// require("map/rooms/water_content")
			// require("map/rooms/volcano")
			//
			// --PORKLAND ROOMS
			// require("map/rooms/terrain_rainforest")
			// require("map/rooms/terrain_deeprainforest")
			// require("map/rooms/terrain_cultivated")
			// require("map/rooms/terrain_suburb")
			// require("map/rooms/terrain_city")
			// require("map/rooms/terrain_painted")
			// require("map/rooms/terrain_battleground")
			// require("map/rooms/terrain_plains")
			// require("map/rooms/terrain_pinacle")
			//
			// require("map/rooms/terrain_impassable")
			//
			//
			// -- DLC ROOMS?
			// require("map/rooms/DLCrooms")

			// ------------------------------------------------------------------------------------
			// -- EXIT ROOM -----------------------------------------------------------------------
			// ------------------------------------------------------------------------------------
		    
		    AddRoom("Exit", new Room
		    {
			    colour = { r = 0.3f, g = 0.2f, b = 0.1f, a = 0.3f },
			    value = Constant.GROUND.FOREST,
			    contents = new Room.Contents
			    {
				    countprefabs = new Dictionary<string, Func<float>>
				    {
					    ["teleportato_base"] = () => 1,
					    ["spiderden"] = () => 5 + WorldGenMain.random.Next(3),
					    ["gravestone"] = () => 4 + WorldGenMain.random.Next(4),
					    ["mound"] = () => 4 + WorldGenMain.random.Next(4)
				    }
			    }
		    });
	    }
    }
}