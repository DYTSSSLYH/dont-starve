using System;
using System.Collections.Generic;
using DYT;

public class Periodic
{
    public Action fn;
    public object id;
    public float period;
    public object limit;
    public float nexttick;
    public List<Periodic> list;
    public Action<Periodic, bool, EntityScript> onfinish;
    public object[] arg;

    public Periodic(Action fn, float period, object limit, object id, float nexttick, params object[] arg)
    {
        this.fn = fn;
        this.id = id;
        this.period = period;
        this.limit = limit;
        this.nexttick = nexttick;
        list = null;
        onfinish = null;
        
        this.arg = arg;
    }
}

public static class Scheduler
{
    public static string HIBERNATE = "hibernate";
    public static string SLEEP = "sleep";
    
    public static object tasks = new();
    public static object running = new();
    public static object waitingfortick = new();
    public static object waking = new();
    public static object hibernating = new();
    public static Dictionary<float, List<Periodic>> attime = new();

    
    public static Periodic ExecuteInTime(float timefromnow, Action fn,  int? id = null,
        params object[] array)
    {
        return ExecutePeriodic(timefromnow, fn, 1, null, id, array);
    }
    
    public static void GetListForTimeFromNow(float dt, out List<Periodic> list, out float wakeuptick)
    {
        float nowtick = MainFunctions.GetTick();
        wakeuptick = MathF.Floor((MainFunctions.GetTime() + dt) / MainFunctions.GetTickTime());
        if (wakeuptick <= nowtick) wakeuptick = nowtick + 1;

        if (attime.ContainsKey(wakeuptick)) list = attime[wakeuptick];
        else
        {
            list = new List<Periodic>();
            attime.Add(wakeuptick, list);
        }
    }
    
    public static Periodic ExecutePeriodic(float period, Action fn, object limit,
        float? initialdelay = null, int? id = null, params object[] array)
    {
        GetListForTimeFromNow(
            initialdelay.GetValueOrDefault(period), out List<Periodic> list, out float nexttick);
        Periodic periodic = new(fn, period, limit, id, nexttick, array);
        list.Add(periodic);
        periodic.list = list;
        return periodic;
    }
}