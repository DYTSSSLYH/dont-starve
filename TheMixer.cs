using System.Collections.Generic;
using DYT;
using UnityEngine;

public class Mix
{
    public string name;
    public Dictionary<string, float> levels;
    public int priority;
    public int fadeintime;

    
    public Mix(string name = "")
    {
        this.name = name;
        levels = new Dictionary<string, float>();
        priority = 0;
        fadeintime = 1;
    }


    public void Apply()
    {
        foreach (string key in levels.Keys) TheSim.instance.SetSoundVolume(key, levels[key]);
    }
    
    public void SetLevel(string channel, float level)
    {
        levels.TryAdd(channel, level);
        levels[channel] = level;
    }
}

public class TheMixer
{
    private static readonly Dictionary<string, Mix> mixes = new Dictionary<string, Mix>();
    private static List<Mix> stack = new List<Mix>();
    
    private static object lowpassfilters = new object();
    private static object highpassfilters = new object();
    private static Mix snapshot;
    private static int fadetimer;

    
    public static Mix AddNewMix(string name, int? fadetime, int? priority,
        Dictionary<string, float> levels)
    {
        Mix mix = new Mix(name);
        mix.fadeintime = fadetime.GetValueOrDefault(1);
        mix.priority = priority.GetValueOrDefault(0);
        
        mixes.Add(name, mix);
        foreach (string key in levels.Keys) mix.SetLevel(key, levels[key]);

        return mix;
    }

    public static Mix CreateSnapshot()
    {
        Mix top = stack.Count == 0 ? null : stack[0];
        if (top != null)
        {
            Mix snap = new Mix();
            foreach (string key in top.levels.Keys) snap.SetLevel(key, TheSim.instance.GetSoundVolume(key));
            return snap;
        }

        return null;
    }
    
    public static void Blend()
    {
        snapshot = CreateSnapshot();
        fadetimer = 0;
    }
    
    public static float GetLevel(string level)
    {
        return TheSim.instance.GetSoundVolume(level);
    }
    
    public static void SetLevel(string name, float level)
    {
        TheSim.instance.SetSoundVolume(name, level);
    }
    
    public static void PopMix(string mixname)
    {
        Mix top = stack[0];

        for (int i = 0; i < stack.Count; i++)
        {
            Mix v = stack[i];
            if (mixname == v.name)
            {
                stack.RemoveAt(i);
                if (top != stack[0]) Blend();
                break;
            }
        }
    }


    public static void PushMix(string mixname)
    {
        if (!mixes.ContainsKey(mixname)) return;
        
        Mix mix = mixes[mixname];

        Mix current = stack.Count == 0 ? null : stack[0];
        
        stack.Add(mix);
        stack.Sort((mix1, mix2) => mix1.priority - mix2.priority);
        
        if (current != null && current != stack[0]) Blend();
        else if (current == null) mix.Apply();
    }
}