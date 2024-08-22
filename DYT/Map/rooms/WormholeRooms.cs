// ------------------------------------------------------------------------------------
// -- WORMHOLE ------------------------------------------------------------------------
// ------------------------------------------------------------------------------------
namespace DYT.Map.rooms
{
    public class WormholeRooms
    {
        static WormholeRooms()
        {
	        Rooms.AddRoom("Wormhole_Swamp", new Room
	        {
		        colour = { r = 1, g = 0, b = 0, a = 0.3f },
		        value = Constant.GROUND.MARSH,
		        contents =
		        {
			        countprefabs =
			        {
				        ["wormhole_MARKER"] = () => 1,
			        },
			        distributepercent = 0.3f,
			        distributeprefabs =
			        {
				        ["marsh_tree"] = 2,
				        ["marsh_bush"] = 4,
				        ["rocks"] = 2,
			        },
		        }
	        });
	        Rooms.AddRoom("Wormhole_Plains", new Room
	        {
		        colour = { r = 1, g = 0, b = 0, a = 0.3f },
		        value = Constant.GROUND.SAVANNA,
		        contents =
		        {
			        countprefabs =
			        {
				        ["wormhole_MARKER"] = () => 1,
			        },
			        distributepercent = 0.3f,
			        distributeprefabs =
			        {
				        ["grass"] = 3,
				        ["rocks"] = 2,
				        ["rock1"] = 0.5f,
				        ["rock2"] = 0.5f,
			        },
		        }
	        });
	        Rooms.AddRoom("Wormhole_Burnt", new Room
	        {
		        colour = { r = 1, g = 0, b = 0, a = 0.3f },
		        value = Constant.GROUND.FOREST,
		        contents =
		        {
			        countprefabs =
			        {
				        ["wormhole_MARKER"] = () => 1,
			        },
			        distributepercent = 0.3f,
			        distributeprefabs =
			        {
				        ["grass"] = 0.5f,
				        ["sapling"] = 0.5f,
				        ["rocks"] = 3,
				        ["evergreen"] = 7,
			        },
			        prefabdata =
			        {
				        ["evergreen"] = ()=>"{burnt=true}",
			        }
		        }
	        });
	        Rooms.AddRoom("Wormhole", new Room
	        {
		        colour = { r = 1, g = 0, b = 0, a = 0.3f },
		        value = Constant.GROUND.FOREST,
		        contents =
		        {
			        countprefabs =
			        {
				        ["wormhole_MARKER"] = () => 1,
			        },
			        distributepercent = 0.3f,
			        distributeprefabs =
			        {
				        ["grass"] = 1,
				        ["sapling"] = 1,
				        ["rocks"] = 3,
				        ["evergreen_normal"] = 1,
				        ["evergreen_short"] = 5,
				        ["evergreen_tall"] = 1,
			        }
		        }
	        });
	        Rooms.AddRoom("Sinkhole", new Room
	        {
		        //-- This room is used to tag for the caves - it will be removed later
		        colour = { r = 0, g = 0, b = 0, a = 0.9f },
		        value = Constant.GROUND.FOREST,
		        contents =
		        {
			        countprefabs =
			        {
				        ["cave_entrance"] = () => 1,
			        },
			        distributepercent = 0.3f,
			        distributeprefabs =
			        {
				        ["grass"] = 1,
				        ["sapling"] = 1,
				        ["rocks"] = 3,
				        ["evergreen_normal"] = 1,
				        ["evergreen_short"] = 5,
				        ["evergreen_tall"] = 1,
			        }
		        }
	        });

	        Rooms.AddRoom("GrassySinkhole", new Room
	        {
		        colour = { r = 0, g = 0, b = 0, a = 0.9f },
		        value = Constant.GROUND.GRASS,
		        contents =
		        {
			        countprefabs =
			        {
				        ["cave_entrance"] = () => 1,
			        },
			        distributepercent = 0.3f,
			        distributeprefabs =
			        {
				        ["grass"] = 1,
				        ["sapling"] = 1,
				        ["rocks"] = 3,
				        ["deciduoustree_normal"] = 1,
				        ["deciduoustree_short"] = 5,
				        ["deciduoustree_tall"] = 1,
			        }
		        }
	        });
        }
    }
}