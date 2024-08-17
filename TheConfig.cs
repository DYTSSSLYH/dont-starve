using System.Collections.Generic;
using DYT;

public class TheConfig
{
    private static Dictionary<string, bool> _options;

    public static void SetOptions(Dictionary<string, bool> options)
    {
        foreach (string k in options.Keys)
        {
            if (!_options.ContainsKey(k)) _options.Add(k, options[k]);
            _options[k] = options[k];
        }
    }

    public static bool IsEnabled(string option)
    {
        if (!_options.ContainsKey(option)) return false;
        else return _options[option];
    }

    private static Dictionary<string, bool> defaults = new Dictionary<string, bool>
    {
        { "hide_vignette", false },
        { "force_netbookmode", false }
    };

    private static Dictionary<string, Dictionary<string, bool>> platform_overrides =
        new Dictionary<string, Dictionary<string, bool>>
        {
            { "NACL", new Dictionary<string, bool> { { "force_netbookmode", true } } },
            {
                "ANDROID",
                new Dictionary<string, bool> { { "hide_vignette", true }, { "force_netbookmode", true } }
            },
            { "IOS", new Dictionary<string, bool> { { "hide_vignette", true }, { "force_netbookmode", true } } }
        };
    
    
    public static void Init()
    {
        _options = new Dictionary<string, bool>();
        SetOptions(defaults);
        
        if (platform_overrides.ContainsKey(Main.PLATFORM)) SetOptions(platform_overrides[Main.PLATFORM]);
    }
}