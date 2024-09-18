using System.Collections.Generic;
using DYT;

public class DlcSupportString
{
    // A table of which strings use prefixes and which use suffixes when constructing names in EntityScript
    public static Dictionary<string, bool> USE_PREFIX = new Dictionary<string, bool>
    {
        {STRINGS.SMOLDERINGITEM, true},
        {STRINGS.WITHEREDITEM, true},
        {STRINGS.WET_PREFIX.FOOD, true},
        {STRINGS.WET_PREFIX.CLOTHING, true},
        {STRINGS.WET_PREFIX.TOOL, true},
        {STRINGS.WET_PREFIX.FUEL, true},
        {STRINGS.WET_PREFIX.GENERIC, true},
        // Special case using inst.wet_prefix set on wet goop to WET_PREFIX.WETGOOP
        {STRINGS.WET_PREFIX.WETGOOP, true},
        // Special case using inst.wet_prefix set on wet goop to WET_PREFIX.WETGOOP
        {STRINGS.NAMES.WETGOOP, true},
        // Special case using inst.wet_prefix on rabbit hole set to WET_PREFIX.RABBITHOLE
        {STRINGS.WET_PREFIX.RABBITHOLE, true},
        // Special case using inst.wet_prefix on rabbit hole set to WET_PREFIX.RABBITHOLE
        {STRINGS.NAMES.RABBITHOLE, true}
    };
}