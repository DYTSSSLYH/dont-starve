using System.Collections.Generic;
using DYT;

public class DlcSupportString
{
    // A table of which strings use prefixes and which use suffixes when constructing names in EntityScript
    public static Dictionary<string, bool> USE_PREFIX = new Dictionary<string, bool>
    {
        {Strings.SMOLDERINGITEM, true},
        {Strings.WITHEREDITEM, true},
        {Strings.WET_PREFIX.FOOD, true},
        {Strings.WET_PREFIX.CLOTHING, true},
        {Strings.WET_PREFIX.TOOL, true},
        {Strings.WET_PREFIX.FUEL, true},
        {Strings.WET_PREFIX.GENERIC, true},
        // Special case using inst.wet_prefix set on wet goop to WET_PREFIX.WETGOOP
        {Strings.WET_PREFIX.WETGOOP, true},
        // Special case using inst.wet_prefix set on wet goop to WET_PREFIX.WETGOOP
        {Strings.NAMES.WETGOOP, true},
        // Special case using inst.wet_prefix on rabbit hole set to WET_PREFIX.RABBITHOLE
        {Strings.WET_PREFIX.RABBITHOLE, true},
        // Special case using inst.wet_prefix on rabbit hole set to WET_PREFIX.RABBITHOLE
        {Strings.NAMES.RABBITHOLE, true}
    };
}