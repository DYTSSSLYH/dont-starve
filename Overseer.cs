using DYT;
using UnityEngine;

public static class Overseer
{
    #region

    // Functions to perform local analysis of the player's game
    // and keep track of accumulated stats (to reduce amount of data sent)
    
    #endregion
    
    // Track time related events and activities.
    // Do whatever time-series and statistical analysis on the fly with the data
    // and give it to the stats system
    
    public class TIMETRACKER_TYPE
    {
        public static string
            CUMULATIVE_ONLY = "CumulativeOnly",
            ONSET_ONLY = "OnsetOnly",
            FIRST_AND_LAST = "FirstAndLast";
    }


    private static int AFK_TIME = 0;
    private static float lastInputTime = 0;
    private static float lastIdleDuration = 0;
    private static float pauseScreenStart = 0;
    private static float pauseDuration = 0;
    private static string pauseReason = "";
    private static bool isAFK = true;
    
    public static void OverseerPauseCheck(string reason){}

    private static float UpdateInputTime()
    {
        float t;
        if (MainFunctions.IsPaused())
        {
            t = MainFunctions.GetTime();
            if (t > lastInputTime) //means this is the first time into the paused HUD
            {
                lastIdleDuration = t - lastInputTime;
                lastInputTime = t;
            }
            if (pauseReason == "minimap")
            {
                pauseDuration = MainFunctions.GetTimeReal() - pauseScreenStart;
                // The sim is paused during the minimap display, but I don't want to put a callback
                // into WallUpdate to be called every few frames, so here I check to see if the
                // time between inputs was long enough to be considered AFK and
                if (pauseDuration > AFK_TIME && SimUtil.GetPlayer() != null)
                {
                    // Add stat about AFK during minimap
                    Debug.Log("============================= AFK during minimap" + pauseDuration);
                    SimUtil.GetPlayer().SendMessage("minimapAFK", pauseDuration);
                }
                pauseScreenStart = MainFunctions.GetTimeReal();
                lastIdleDuration = pauseDuration;
            }else{}
            return lastIdleDuration;
        }
        t = MainFunctions.GetTime();
        lastIdleDuration = t - lastInputTime;
        lastInputTime = t;
        if (isAFK && SimUtil.GetPlayer() != null) //Player not instantiated at first
        {
            Debug.Log("++++++++++++++++++++++++++++++++++ return to game");
            SimUtil.GetPlayer().SendMessage("returntogame");
        }
        isAFK = false;
        return lastIdleDuration;
    }

    public static void IdlePlayerCheck(out float id, out bool isAfk)
    {
        id = MainFunctions.GetTime() - lastInputTime;
        isAfk = isAFK;
        if (id > AFK_TIME)
        {
            if (!isAFK && SimUtil.GetPlayer() != null) //Player not instantiated at first
            {
                Debug.Log("---------------------------------- is AFK");
                SimUtil.GetPlayer().SendMessage("awayfromgame", SendMessageOptions.DontRequireReceiver);
            }
            isAfk = true;
        }
    }
    
    private static void MoveCheck()
    {
        if (TheInput.IsControlPressed(Constant.CONTROL_PRIMARY)) UpdateInputTime();
    }
    
    public static void Init()
    {
        TheInput.AddTextInputHandler(_ => UpdateInputTime());
        TheInput.AddKeyHandler(_ => UpdateInputTime());
        TheInput.AddControlHandler(Constant.CONTROL_PRIMARY.ToString(), _ => UpdateInputTime());
        TheInput.AddControlHandler(Constant.CONTROL_ZOOM_IN.ToString(), _ => UpdateInputTime());
        TheInput.AddControlHandler(Constant.CONTROL_ZOOM_OUT.ToString(), _ => UpdateInputTime());
        TheInput.AddMoveHandler(_ => MoveCheck());

        Scheduler.ExecutePeriodic(
            AFK_TIME / 2, () => IdlePlayerCheck(out float id, out bool isAfk), null, 0);
    }

    
    
    static Overseer()
    {
        MainFunctions.PlayerPauseCheck = (paused, reason) =>
        {
            if (paused)
            {
                pauseScreenStart = MainFunctions.GetTimeReal() / 1000;
                pauseDuration = 0;
                pauseReason = string.IsNullOrWhiteSpace(reason) ? "" : reason;
                OverseerPauseCheck(reason);
            }
            else UpdateInputTime(); //updates pauseDuration
        };
    }
}