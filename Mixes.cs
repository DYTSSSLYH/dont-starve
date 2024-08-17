using System.Collections.Generic;

public class Mixes
{
    private static string
        amb = "set_ambience/ambience",
        cloud = "set_ambience/cloud",
        music = "set_music/soundtrack",
        voice = "set_sfx/voice",
        movement = "set_sfx/movement",
        creature = "set_sfx/creature",
        player = "set_sfx/player",
        HUD = "set_sfx/HUD",
        sfx = "set_sfx/sfx",
        slurp = "set_sfx/everything_else_muted",
        twister = "set_sfx/twister_attack",
        mute = "set_sfx/everything_else_muted",
        shadow = "set_sfx/shadow";

    public static void Init()
    {
        //function Mixer:AddNewMix(name, fadetime, priority, levels, reverb)

        TheMixer.AddNewMix("normal", 2, 1, new Dictionary<string, float>
        {
            { amb, 0.8f },
            { cloud, 0 },
            { music, 1 },
            { voice, 1 },
            { movement, 1 },
            { creature, 1 },
            { player, 1 },
            { HUD, 1 },
            { sfx, 1 },
            { slurp, 1 },
            { twister, 1 },
            // { twister, 1 },
            { shadow, 1 },
        });
        //function Mixer:AddNewMix(name, fadetime, priority, levels, reverb)
        TheMixer.AddNewMix("high", 2, 3, new Dictionary<string, float>
        {
            { amb, 0.2f },
            { cloud, 1 },
            { music, 0.5f },
            { voice, 0.7f },
            { movement, 0.7f },
            { creature, 0.7f },
            { player, 0.7f },
            { HUD, 1 },
            { sfx, 0.7f },
            { slurp, 1 },
            { twister, 1 },
            { shadow, 0.7f },
        });
        //function Mixer:AddNewMix(name, fadetime, priority, levels, reverb)
        TheMixer.AddNewMix("start", 1, 0, new Dictionary<string, float>
        {
            { amb, 0.8f },
            { cloud, 0 },
            { music, 1 },
            { voice, 1 },
            { movement, 1 },
            { creature, 1 },
            { player, 1 },
            { HUD, 1 },
            { sfx, 1 },
            { slurp, 1 },
            { twister, 1 },
            { shadow, 1 },
        });
        //function Mixer:AddNewMix(name, fadetime, priority, levels, reverb)
        TheMixer.AddNewMix("pause", 1, 4, new Dictionary<string, float>
        {
            { amb, 0.1f },
            { cloud, 0.1f },
            { music, 0 },
            { voice, 0 },
            { movement, 0 },
            { creature, 0 },
            { player, 0 },
            { HUD, 1 },
            { sfx, 0 },
            { slurp, 0 },
            { twister, 1 },
            { shadow, 0 },
        });
        //function Mixer:AddNewMix(name, fadetime, priority, levels, reverb)
        TheMixer.AddNewMix("death", 1, 6, new Dictionary<string, float>
        {
            { amb, 0.2f },
            { cloud, 0.2f },
            { music, 0 },
            { voice, 1 },
            { movement, 0.8f },
            { creature, 0.8f },
            { player, 1 },
            { HUD, 1 },
            { sfx, 0.8f },
            { slurp, 0.8f },
            { twister, 1 },
            { shadow, 0.8f },
        });
        //function Mixer:AddNewMix(name, fadetime, priority, levels, reverb)
        TheMixer.AddNewMix("slurp", 1, 1, new Dictionary<string, float>
        {
            { amb, 0.2f },
            { cloud, 0.2f },
            { music, 0.5f },
            { voice, 0.7f },
            { movement, 0.7f },
            { creature, 0.7f },
            { player, 0.7f },
            { HUD, 1 },
            { sfx, 0.7f },
            { slurp, 1 },
            { twister, 1 },
            { shadow, 0.7f },
        });
        //function Mixer:AddNewMix(name, fadetime, priority, levels, reverb)
        TheMixer.AddNewMix("twister", 1, 7, new Dictionary<string, float> //3.5 
        {
            { amb, 0.6f },
            { cloud, 0.6f },
            { music, 0.8f },
            { voice, 0.6f },
            { movement, 0.6f },
            { creature, 0.5f },
            { player, 0.6f },
            { HUD, 1 },
            { sfx, 0.6f },
            { slurp, 0.1f },
            { twister, 1 },
            { shadow, 0.5f },
        });
        //function Mixer:AddNewMix(name, fadetime, priority, levels, reverb)
        TheMixer.AddNewMix("mute", 0, 4, new Dictionary<string, float>
        {
            { amb, 0.1f },
            { cloud, 0.1f },
            { music, 0 },
            { voice, 0 },
            { movement, 0 },
            { creature, 0 },
            { player, 0 },
            { HUD, 1 },
            { sfx, 0 },
            // { slurp, 0 },
            { twister, 0 },
            { mute, 1 },
            { shadow, 0 },
        });
        //function Mixer:AddNewMix(name, fadetime, priority, levels, reverb)
        TheMixer.AddNewMix("boss_fight", 1, 4, new Dictionary<string, float>
        {
            { amb, 0.2f },
            { cloud, 0 },
            { music, 1 },
            { voice, 1 },
            { movement, 0.3f },
            { creature, 1 },
            { player, 0.5f },
            { HUD, 1 },
            { sfx, 0.7f },
            { slurp, 1 },
            { twister, 1 },
            { shadow, 0.3f },
        });
        //function Mixer:AddNewMix(name, fadetime, priority, levels, reverb)
        TheMixer.AddNewMix("fog", 2, 1, new Dictionary<string, float>
        {
            { amb, 0.5f },
            { cloud, 0 },
            { music, 1 },
            { voice, 1 },
            { movement, 1 },
            { creature, 0.5f },
            { player, 1 },
            { HUD, 1 },
            { sfx, 1 },
            { slurp, 1 },
            { twister, 1 },
            { shadow, 0.3f },
        });
        //function Mixer:AddNewMix(name, fadetime, priority, levels, reverb)
        TheMixer.AddNewMix("shadow", 1, 3, new Dictionary<string, float>
        {
            { amb, 0.2f },
            { cloud, 0 },
            { music, 1 },
            { voice, 1 },
            { movement, 1 },
            { creature, 1 },
            { player, 1 },
            { HUD, 1 },
            { sfx, 1 },
            { slurp, 1 },
            { twister, 1 },
            { shadow, 0.3f },
        });

        TheMixer.AddNewMix("boom", 0, 4, new Dictionary<string, float>
        {
            { amb, 0.1f },
            { cloud, 0.1f },
            { music, 0.5f },
            { voice, 0 },
            { movement, 0 },
            { creature, 1 },
            { player, 0 },
            { HUD, 1 },
            { sfx, 1 },
            { slurp, 0 },
            { twister, 1 },
            { shadow, 0 },
        });
    }
}