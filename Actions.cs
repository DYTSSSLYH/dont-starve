using System;
using System.Reflection;
using DYT;

public class Actions
{
    private float priority = 0;
    private Func<bool> fn = () => false;
    private Action strfn = null;
    private Action testfn = null;
    private bool instant = false;
    private bool rmb = false;
    private float distance = -1;
    private bool crosseswaterboundary = false;
    private bool mount_enabled = false;
    private bool valid_hold_action = false;
    private bool overrides_direct_walk;
    
    private string str;
    private string id;


    private class Data
    {
        public object mount_enabled;
        public object valid_hold_action;

        public Data()
        {
        }

        public Data(object mountEnabled, object validHoldAction)
        {
            mount_enabled = mountEnabled;
            valid_hold_action = validHoldAction;
        }
    }
    private Actions(Data data = null, object priority = null, object instant = null, object rmb = null,
        object distance = null, object crosseswaterboundary = null, bool overrides_direct_walk = false)
    {
        if (priority != null) this.priority = Convert.ToSingle(priority);
        if (instant != null) this.instant = (bool)instant;
        if (rmb != null) this.rmb = (bool)rmb;
        if (distance != null) this.distance = Convert.ToSingle(distance);
        if (crosseswaterboundary != null) this.crosseswaterboundary = (bool)crosseswaterboundary;
        if (data != null)
        {
            if (data.mount_enabled != null) mount_enabled = (bool)data.mount_enabled;
            if (data.valid_hold_action != null) valid_hold_action = (bool)data.valid_hold_action;
        }
        this.overrides_direct_walk = overrides_direct_walk;
    }


    // for pigs reparing broken pig town structures
    public static Actions FIX = new Actions(new Data(), null, null, null, 2);
    public static Actions REPAIR = new Actions(new Data { mount_enabled = true });
    public static Actions REPAIRBOAT = new Actions(new Data { valid_hold_action = true }, null, null, null, 3);
    public static Actions READ = new Actions(new Data { mount_enabled = true });
    public static Actions READMAP = new Actions(new Data { mount_enabled = true });
    public static Actions DROP = new Actions(new Data { mount_enabled = true }, -1);
    public static Actions TRAVEL = new Actions(new Data(), 2);
    public static Actions CHOP = new Actions(new Data(), null, null, null, 2);
    public static Actions ATTACK = new Actions(new Data { mount_enabled = true }, 2, true);
    public static Actions WHACK = new Actions(new Data { mount_enabled = true }, 2, true);
    public static Actions FORCEATTACK = new Actions(new Data { mount_enabled = true }, 2, true);
    public static Actions EAT = new Actions(new Data(true, true));
    public static Actions PICK = new Actions(new Data { mount_enabled = true });
    public static Actions PICKUP = new Actions(new Data { mount_enabled = true }, 2);
    public static Actions MINE = new Actions(new Data());
    public static Actions DIG = new Actions(new Data(), null, null, true);
    public static Actions GIVE = new Actions(new Data(true, true));
    public static Actions COOK = new Actions(new Data { valid_hold_action = true }, 2);
    public static Actions DRY = new Actions(new Data());
    public static Actions ADDFUEL = new Actions(new Data(true, true), 0.5f);
    public static Actions SHOP = new Actions(new Data());
    public static Actions ADDWETFUEL = new Actions(new Data(true, true));
    public static Actions LIGHT = new Actions(new Data(), -4, null, null, 1.5f);
    public static Actions EXTINGUISH = new Actions(new Data(), 0);
    public static Actions LOOKAT = new Actions(new Data { mount_enabled = true }, -3, true);
    public static Actions TALKTO = new Actions(new Data { mount_enabled = true }, 3, true);
    public static Actions WALKTO = new Actions(new Data { mount_enabled = true }, -4);
    public static Actions DODGE = new Actions(new Data(), -5, null, null, 2, null, true);
    public static Actions BAIT = new Actions(new Data());
    public static Actions CHECKTRAP = new Actions(new Data { mount_enabled = true }, 2);
    public static Actions BUILD = new Actions(new Data { mount_enabled = true });
    public static Actions PLANT = new Actions(new Data());
    public static Actions PLANTONGROWABLE = new Actions(new Data());
    public static Actions HARVEST = new Actions(new Data { valid_hold_action = true });
    public static Actions GOHOME = new Actions(new Data());
    public static Actions SLEEPIN = new Actions(new Data());
    public static Actions EQUIP = new Actions(new Data { mount_enabled = true }, 0, true);
    public static Actions UNEQUIP = new Actions(new Data { mount_enabled = true }, -2, true);

    // OPEN_SHOP = new Actions();
    public static Actions SHAVE = new Actions(new Data { mount_enabled = true });
    public static Actions STORE = new Actions(new Data { valid_hold_action = true });
    public static Actions RUMMAGE = new Actions(new Data { mount_enabled = true }, 1, null, true, 2);
    public static Actions DEPLOY = new Actions(new Data(), 0);
    // DEPLOY_AT_RANGE is deprecated, ACTIONS.DEPLOY now has deploy distance = 1
    public static Actions DEPLOY_AT_RANGE = new Actions(new Data(), 0, null, null, 1);
    public static Actions LAUNCH = new Actions(new Data(), null, null, null, 3, true);
    public static Actions RETRIEVE = new Actions(new Data(), 1, null, null, 3, true);
    public static Actions PLAY = new Actions(new Data { mount_enabled = true });
    public static Actions NET = new Actions(new Data(), 3);
    public static Actions CATCH = new Actions(new Data { mount_enabled = true }, 3, true);
    public static Actions FISHOCEAN = new Actions(new Data(), 0, false, false, 8);
    public static Actions FISH = new Actions(new Data());
    public static Actions REEL = new Actions(new Data(), 0, true);
    public static Actions POLLINATE = new Actions(new Data());
    public static Actions FERTILIZE = new Actions(new Data { valid_hold_action = true }, -1);
    public static Actions DEMOLISH_ROOM = new Actions(new Data());
    public static Actions BUILD_ROOM = new Actions(new Data());
    public static Actions SMOTHER = new Actions(new Data { mount_enabled = true });
    public static Actions MANUALEXTINGUISH = new Actions(new Data());
    public static Actions RANGEDSMOTHER = new Actions(new Data(), 0, true);
    public static Actions RANGEDLIGHT = new Actions(new Data { mount_enabled = true }, -4, true);
    public static Actions LAYEGG = new Actions(new Data());
    public static Actions HAMMER = new Actions(new Data(), 3, null, null, 2);
    public static Actions TERRAFORM = new Actions(new Data());
    public static Actions JUMPIN = new Actions(new Data());
    public static Actions USEDOOR = new Actions(new Data());
    public static Actions RESETMINE = new Actions(new Data(), 3);
    public static Actions ACTIVATE = new Actions(new Data());
    public static Actions MURDER = new Actions(new Data { mount_enabled = true }, 0);
    public static Actions HEAL = new Actions(new Data(true, true));
    public static Actions CUREPOISON = new Actions(new Data { mount_enabled = true });
    public static Actions INVESTIGATE = new Actions(new Data { mount_enabled = true });
    public static Actions UNLOCK = new Actions(new Data());
    public static Actions TEACH = new Actions(new Data { mount_enabled = true });
    public static Actions TURNON = new Actions(new Data(), 2.5);
    public static Actions TURNOFF = new Actions(new Data(), 2);
    public static Actions SEW = new Actions(new Data(true, true));
    public static Actions STEAL = new Actions(new Data());
    public static Actions USEITEM = new Actions(new Data(), 1, true);
    public static Actions TAKEITEM = new Actions(new Data());
    public static Actions MAKEBALLOON = new Actions(new Data(true, true));
    public static Actions CASTSPELL = new Actions(new Data { mount_enabled = true }, -1, false, true, 20, true);
    public static Actions BLINK = new Actions(new Data { mount_enabled = true }, 10, false, true, 36);
    public static Actions PEER = new Actions(new Data { mount_enabled = true }, 0, false, true, 40, true);
    public static Actions COMBINESTACK = new Actions(new Data { mount_enabled = true });
    public static Actions TOGGLE_DEPLOY_MODE = new Actions(new Data(), 1, true);

    public static Actions SUMMONGUARDIAN = new Actions(new Data(), 0, false, false, 5);
    public static Actions LAVASPIT = new Actions(new Data(), 0, false, false, 2);
    public static Actions HAIRBALL = new Actions(new Data(), 0, false, false, 3);
    public static Actions CATPLAYGROUND = new Actions(new Data(), 0, false, false, 1);
    public static Actions CATPLAYAIR = new Actions(new Data(), 0, false, false, 2);
    public static Actions STEALMOLEBAIT = new Actions(new Data(), 0, false, false, .75);
    public static Actions MAKEMOLEHILL = new Actions(new Data(), 4, false, false, 0);
    public static Actions MOLEPEEK = new Actions(new Data(), 0, false, false, 1);
    public static Actions BURY = new Actions(new Data(), 0, false, false);
    public static Actions FEED = new Actions(new Data { mount_enabled = true }, 0, false, true);
    public static Actions FAN = new Actions(new Data { mount_enabled = true }, 0, false, true);
    public static Actions UPGRADE = new Actions(new Data { valid_hold_action = true }, 0, false, true);
    public static Actions MOUNT = new Actions(new Data(), 1, null, null, 6);

    // OLD unused SW action
    public static Actions SEARCH = new Actions(new Data(), 1, null, null, 4);
    public static Actions DISMOUNT = new Actions(new Data { mount_enabled = true }, 1, null, null, 2.5);
    public static Actions HACK = new Actions(new Data(), null, null, null, 1.75);
    public static Actions SHEAR = new Actions(new Data(), null, null, null, 1.75);
    public static Actions SPY = new Actions(new Data { mount_enabled = true }, null, null, null, 2.0);
    public static Actions NIBBLE = new Actions(new Data(), 0, null, null, 3);
    // For equipped items 
    public static Actions TOGGLEON = new Actions(new Data { mount_enabled = true }, 2);
    // For equipped items 
    public static Actions TOGGLEOFF = new Actions(new Data { mount_enabled = true }, 2);
    public static Actions STICK = new Actions(new Data());
    public static Actions MATE = new Actions(new Data());
    public static Actions CRAB_HIDE = new Actions(new Data());
    // Don't know where this comes from
    public static Actions DRINK = new Actions(new Data { mount_enabled = true });
    public static Actions TIGERSHARK_FEED = new Actions(new Data());
    public static Actions FLUP_HIDE = new Actions(new Data());
    public static Actions PEAGAWK_TRANSFORM = new Actions(new Data());
    // CHECK
    public static Actions THROW = new Actions(new Data { mount_enabled = true }, 0, false, true, 20, true);
    // CHECK
    public static Actions LAUNCH_THROWABLE = new Actions(new Data(), 0, false, true, 20, true);
    public static Actions DIGDUNG = new Actions(new Data { mount_enabled = true });
    public static Actions MOUNTDUNG = new Actions(new Data());
    public static Actions STOCK = new Actions(new Data());

    public static Actions SPECIAL_ACTION = new Actions(new Data(), null, null, null, 1.2);
    public static Actions SPECIAL_ACTION2 = new Actions(new Data(), null, null, null, 1.2);
    public static Actions RENOVATE = new Actions(new Data());
    public static Actions DISARM = new Actions(new Data(), 1, null, null, 1.5);
    public static Actions REARM = new Actions(new Data(), 1, null, null, 1.5);
    public static Actions WEIGHDOWN = new Actions(new Data(), null, null, null, 1.5);
    public static Actions DISLODGE = new Actions(new Data());
    public static Actions BARK = new Actions(new Data(), null, null, null, 3);
    public static Actions RANSACK = new Actions(new Data(), null, null, null, 0.5);
    public static Actions PAN = new Actions(new Data(), null, null, null, 1);
    public static Actions INFEST = new Actions(new Data(), null, null, null, 0.5);
    public static Actions GAS = new Actions(new Data { mount_enabled = true }, null, null, null, 1.5);

    // made distict from MOUNT due to the range problem of MOUNT
    public static Actions RIDE_MOUNT = new Actions(new Data(), 1);
    public static Actions BRUSH = new Actions(new Data(), 3);
    public static Actions SADDLE = new Actions(new Data(), 1);
    public static Actions UNSADDLE = new Actions(new Data(), 3);
    public static Actions BLANK = new Actions(new Data());

    public static Actions BUNDLE = new Actions(new Data(), 2, null, true);
    public static Actions BUNDLESTORE = new Actions(new Data(), null, true);
    public static Actions WRAPBUNDLE = new Actions(new Data(), null, true);
    public static Actions UNWRAP = new Actions(new Data(), 3, null, true);

    public static Actions DRAW = new Actions(new Data());
    public static Actions UNPIN = new Actions(new Data());
    public static Actions CHARGE_UP = new Actions(new Data(), 2, true);


    public static void Init()
    {
        Type actionsType = typeof(Actions);
        FieldInfo[] fieldInfos = actionsType.GetFields();
        Type stringsActionType = typeof(Strings.ACTIONS);
        foreach (FieldInfo fieldInfo in fieldInfos)
        {
            if (!fieldInfo.IsStatic) continue;
            
            string fieldInfoName = fieldInfo.Name;
            Actions value = (Actions)fieldInfo.GetValue(null);
            FieldInfo field = stringsActionType.GetField(fieldInfoName);
            value.str = (string)(field == null ? "ACTION" : field.GetValue(null));
            value.id = fieldInfoName;
        }

        #region set up the action functions!

        

        #endregion
    }
}