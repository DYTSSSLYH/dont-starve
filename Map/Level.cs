using System.Collections.Generic;

public class Level
{
    public enum LevelType
    {
        Survival,
        ReginOfGiants,
        Shipwrecked,
        Hamlet,
        Cave,
        Adventure,
        Volcano,
        Test,
        Custom,
        Unknown
    }

    public string id;
    public string name;
    public string description;
    public Dictionary<string, string> overrides;


    public Level(string id, string name, string description, Dictionary<string, string> overrides)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.overrides = overrides;
    }
}