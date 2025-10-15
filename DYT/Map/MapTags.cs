using System.Collections.Generic;

namespace DYT.Map
{
    public class MapTags
    {
	    public delegate void TagHandler(Dictionary<string, bool> dic, out string type, out string extra);
	    
        public Dictionary<string, bool> TagData = new Dictionary<string, bool>
        {
            ["Chester_Eyebone"] = true,
            ["Packim_Fishbone"] = true,
        };

        public Dictionary<string, TagHandler> Tag = new Dictionary<string, TagHandler>
        {
	        //-- porkland tags
	        ["interior_potential"] =
		        (Dictionary<string, bool> tagdata, out string type, out string extra) =>
		        {
			        type = "GLOBALTAG";
			        extra = "interior_potential";
		        },
	        ["City2"] = (Dictionary<string, bool> tagdata, out string type, out string extra) =>
	        {
		        type = "GLOBALTAG";
		        extra = "City2";
	        },
	        ["City1"] = (Dictionary<string, bool> tagdata, out string type, out string extra) =>
	        {
		        type = "GLOBALTAG";
		        extra = "City1";
	        },
	        ["Suburb"] = (Dictionary<string, bool> tagdata, out string type, out string extra) =>
	        {
		        type = "GLOBALTAG";
		        extra = "Suburb";
	        },
	        ["City_Foundation"] = (Dictionary<string, bool> tagdata, out string type, out string extra) =>
	        {
		        type = "GLOBALTAG";
		        extra = "City_Foundation";
	        },
	        ["Cultivated"] = (Dictionary<string, bool> tagdata, out string type, out string extra) =>
	        {
		        type = "GLOBALTAG";
		        extra = "Cultivated";
	        },
	        ["Bramble"] = (Dictionary<string, bool> tagdata, out string type, out string extra) =>
	        {
		        type = "GLOBALTAG";
		        extra = "Bramble";
	        },
	        ["Canopy"] = (Dictionary<string, bool> tagdata, out string type, out string extra) =>
	        {
		        type = "TAG";
		        extra = "Canopy";
	        },
	        ["Maze"] = (Dictionary<string, bool> tagdata, out string type, out string extra) =>
	        {
		        type = "GLOBALTAG";
		        extra = "Maze";
	        },
	        ["MazeEntrance"] = (Dictionary<string, bool> tagdata, out string type, out string extra) =>
	        {
		        type = "GLOBALTAG";
		        extra = "MazeEntrance";
	        },
	        ["Labyrinth"] = (Dictionary<string, bool> tagdata, out string type, out string extra) =>
	        {
		        type = "GLOBALTAG";
		        extra = "Labyrinth";
	        },
	        ["LabyrinthEntrance"] =
		        (Dictionary<string, bool> tagdata, out string type, out string extra) =>
		        {
			        type = "GLOBALTAG";
			        extra = "LabyrinthEntrance";
		        },
	        ["OverrideCentroid"] =
		        (Dictionary<string, bool> tagdata, out string type, out string extra) =>
		        {
			        type = "GLOBALTAG";
			        extra = "OverrideCentroid";
		        },
	        ["RoadPoison"] = (Dictionary<string, bool> tagdata, out string type, out string extra) =>
	        {
		        type = "TAG";
		        extra = "RoadPoison";
	        },
	        ["ForceConnected"] = (Dictionary<string, bool> tagdata, out string type, out string extra) =>
	        {
		        type = "TAG";
		        extra = "ForceConnected";
	        },
	        ["ForceDisconnected"] =
		        (Dictionary<string, bool> tagdata, out string type, out string extra) =>
		        {
			        type = "TAG";
			        extra = "ForceDisconnected";
		        },
	        ["OneshotWormhole"] = (Dictionary<string, bool> tagdata, out string type, out string extra) =>
	        {
		        type = "TAG";
		        extra = "OneshotWormhole";
	        },
	        ["ExitPiece"] = (Dictionary<string, bool> tagdata, out string type, out string extra) =>
	        {
		        type = "TAG";
		        extra = "ExitPiece";
	        },
	        ["Town"] = (Dictionary<string, bool> tagdata, out string type, out string extra) =>
	        {
		        type = "TAG";
		        extra = "0x000001";
	        },
	        ["Chester_Eyebone"] = (Dictionary<string, bool> tagdata, out string type, out string extra) =>
	        {
		        type = null;
		        extra = null;
		        if (tagdata["Chester_Eyebone"] == false) return;
				tagdata["Chester_Eyebone"] = false;
		        type = "ITEM";
		        extra = "chester_eyebone";
	        },
	        ["Packim_Fishbone"] = (Dictionary<string, bool> tagdata, out string type, out string extra) =>
	        {
		        type = null;
		        extra = null;
		        if (tagdata["Packim_Fishbone"] == false) return;
		        tagdata["Packim_Fishbone"] = false;
		        type = "ITEM";
		        extra = "packim_fishbone";
	        },
	        ["sandstorm"] = (Dictionary<string, bool> tagdata, out string type, out string extra) =>
	        {
		        type = "TAG";
		        extra = "sandstorm";
	        },
        };
    }
}