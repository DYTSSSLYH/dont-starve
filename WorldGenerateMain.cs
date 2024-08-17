using System.Collections.Generic;

public class WorldGenerateMain
{
    private static Dictionary<string, object> profileStats = new Dictionary<string, object>();

    public static Dictionary<string, object> GetProfileStats()
    {
        if (profileStats.Count != 0) return profileStats;

        return null;
    }
}