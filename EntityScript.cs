using System;
using System.Collections.Generic;
using DYT;
using UnityEngine;
using UnityEngine.Assertions;

public class EntityScript : MonoBehaviour
{
    public static object StopUpdatingComponents = new();
    public static object nearsightednames = null;
    
    public GameObject entity { get; private set; }
    public Dictionary<string, MonoBehaviour> components { get; private set; }
    
    private int GUID;
    private float spawntime;
    private bool persists;
    private bool inlimbo;
    private string name;
    private object data;
    private object listeners;
    private object updatecomponents;
    private object inherentactions;
    private object event_listeners;
    private object event_listening;
    private List<Periodic> pendingtasks;
    private object children;
    private int age;
    private object ininterior;

    private Dictionary<MonoBehaviour, string> wallupdatecomponents;
    private List<string> _tagList = new();

    public EntityScript Init()
    {
        entity = gameObject;
        components = new Dictionary<string, MonoBehaviour>();
        GUID = entity.GetInstanceID();
        spawntime = MainFunctions.GetTime();
        persists = true;
        inlimbo = false;
        name = null;
        
        data = null;
        listeners = null;
        updatecomponents = null;
        inherentactions = null;
        event_listeners = null;
        event_listening = null;
        pendingtasks = null;
        children = null;
        age = 0;
        ininterior = null;
        
        return this;
    }
    
    public void StartWallUpdatingComponent(MonoBehaviour cmp)
    {
        if (wallupdatecomponents == null)
        {
            wallupdatecomponents = new Dictionary<MonoBehaviour, string>();
            Main.NewWallUpdatingEnts.Add(GUID, this);
        }

        string cmpname = null;
        foreach (string key in components.Keys)
        {
            if (components[key] == cmp)
            {
                cmpname = key;
                break;
            }
        }
        
        wallupdatecomponents.Add(cmp, string.IsNullOrWhiteSpace(cmpname) ? "component" : cmpname);
    }
    

    public void AddTag(string tag)
    {
        _tagList.Add(tag);
    }
    
    public bool HasTag(string tag)
    {
        return _tagList.Contains(tag);
    }

    public void AddComponent(string name, MonoBehaviour monoBehaviour)
    {
        if (components.ContainsKey(name)) DebugPrint.print($"component {name} already exists in prefab!");
        Assert.IsNotNull(monoBehaviour, $"component {name} does not exist!");
        
        components.Add(name, monoBehaviour);
        List<ModManager.ParamObjectArrayHandler> postinitfns =
            ModManager.GetPostInitFns("ComponentPostInit", name);

        foreach (ModManager.ParamObjectArrayHandler fn in postinitfns) fn(monoBehaviour, this);
    }


    private void task_finish(Periodic task, bool success, EntityScript inst)
    {
        if (inst && inst.pendingtasks != null && inst.pendingtasks.Contains(task))
        {
            pendingtasks.Remove(task);
        }
        else DebugPrint.print("   NOT FOUND");
    }

    public Periodic DoTaskInTime(float time, Action fn, params object[] array)
    {
        if (pendingtasks == null) pendingtasks = new List<Periodic>();

        Periodic per = Scheduler.ExecuteInTime(time, fn, GUID, this, array);
        pendingtasks.Add(per);
        per.onfinish = task_finish;
        return per;
    }
}