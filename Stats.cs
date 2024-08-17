using System.Collections.Generic;
using DYT;
using UnityEngine;

public class Stats
{
    public static bool STATS_ENABLE;

    #region non-user-facing Tracking stats

    public static object TrackingEventsStats = new object();
    public static object TrackingTimingStats = new object();
    
    private class GameStats
    {
        public static int StatsLastTrodCount;
        public static bool super;
    }

    #endregion

    #region GAME Stats and details to be sent to server on game complete

    public static Dictionary<string, int> ProfileStats;
    public static object MainMenuStats = new object();

    public static void SuUsedAdd(string item, int? value = null)
    {
        GameStats.super = true;
        ProfileStatsAdd(item, value);
    }

    // Run some analysis and save stats when player pauses
    public static void RecordPauseStats()
    {
        if (!GameLogic.STATS_ENABLE || !MainFunctions.IsPaused()) return;
        
        Debug.Log("RecordPauseStats");
    }

    // value is optional, 1 if nil
    public static void ProfileStatsAdd(string item, int? value = null)
    {
        int val = value.GetValueOrDefault(1);

        if (ProfileStats.ContainsKey(item)) ProfileStats[item] += val;
        else ProfileStats[item] = val;
    }
    
    
    // TODO
    public static void SendAccumulatedProfileStats(){}

    // Periodically upload and refresh the player stats,
    // so we always have up-to-date stats even if they close/crash the game.
    public static int StatsHeartbeatRemaining = 30;

    #endregion

    static Stats()
    {
        STATS_ENABLE = false;
        // NOTE: There is also a call to 'anon/start' in dontstarve/main.cpp which has to be un/commented
        
        
        TrackingEventsStats = new object();
        TrackingTimingStats = new object();
        GameStats.StatsLastTrodCount = 0;

        
        ProfileStats = new Dictionary<string, int>();
    }
}