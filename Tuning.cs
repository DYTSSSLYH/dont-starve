public class Tuning
{
    // each segment of the clock is 30 seconds
    private static int seg_time = 30;
    private static int total_day_time = seg_time * 16;

    private static int day_segs = 10;
    private static int dusk_segs = 4;
    private static int night_segs = 2;

    // default day composition. changes in winter, etc
    private static int day_time = seg_time * day_segs;
    private static int dusk_time = seg_time * dusk_segs;
    private static int night_time = seg_time * night_segs;

    private static int wilson_attack = 34;
    private static int wilson_health = 150;
    private static int calories_per_day = 75;

    private static float wilson_attack_period = 0.5f;
    //-----------------------
    
    private static int perish_warp = 1;//--/200

    public static float
	    DEMO_TIME = total_day_time * 2 + day_time * 0.2f,
	    AUTOSAVE_INTERVAL = total_day_time,
	    SEG_TIME = seg_time,
	    TOTAL_DAY_TIME = total_day_time,
	    DAY_SEGS_DEFAULT = day_segs,
	    DUSK_SEGS_DEFAULT = dusk_segs,
	    NIGHT_SEGS_DEFAULT = night_segs;

    public static int
	    STACK_SIZE_LARGEITEM = 10,
	    STACK_SIZE_MEDITEM = 20,
	    STACK_SIZE_SMALLITEM = 40,

	    GOLDENTOOLFACTOR = 4,

	    DARK_CUTOFF = 0;

    public static float
	    DARK_SPAWNCUTOFF = 0.1f,
	    WILSON_HEALTH = wilson_health,
	    WILSON_ATTACK_PERIOD = 0.5f,
	    WILSON_HUNGER = 150, //--stomach size
	    WILSON_HUNGER_RATE = calories_per_day / total_day_time; //--calories burnt per day

    public static int
	    WX78_MIN_HEALTH = 100,
	    WX78_MIN_HUNGER = 100,
	    WX78_MIN_SANITY = 100,

	    WX78_MAX_HEALTH = 400,
	    WX78_MAX_HUNGER = 200,
	    WX78_MAX_SANITY = 300,

	    WILSON_SANITY = 200,
	    WILLOW_SANITY = 120;

    public static float
	    HAMMER_LOOT_PERCENT = 0.5f,
	    BURNT_HAMMER_LOOT_PERCENT = 0.25f,
	    AXE_USES = 100,
	    HAMMER_USES = 75,
	    SHOVEL_USES = 25,
	    PITCHFORK_USES = 25,
	    PICKAXE_USES = 33,
	    BUGNET_USES = 10,
	    SPEAR_USES = 150,
	    WATHGRITHR_SPEAR_USES = 200,
	    SPIKE_USES = 100,
	    FISHINGROD_USES = 9,
	    TRAP_USES = 8,
	    BOOMERANG_USES = 10,
	    BOOMERANG_DISTANCE = 12,
	    NIGHTSWORD_USES = 100,
	    ICESTAFF_USES = 20,
	    FIRESTAFF_USES = 20,
	    TELESTAFF_USES = 5,
	    HAMBAT_USES = 100,
	    BATBAT_USES = 75,
	    MULTITOOL_AXE_PICKAXE_USES = 800,
	    RUINS_BAT_USES = 200,

	    REDAMULET_USES = 20,
	    REDAMULET_CONVERSION = 5,

	    BLUEAMULET_FUEL = total_day_time * 0.75f,
	    BLUEGEM_COOLER = -20,

	    PURPLEAMULET_FUEL = total_day_time * 0.4f,

	    YELLOWAMULET_FUEL = total_day_time,
	    YELLOWSTAFF_USES = 20,
	    YELLOWSTAFF_STAR_DURATION = total_day_time * 3.5f,

	    ORANGEAMULET_USES = 225,
	    ORANGEAMULET_RANGE = 4,
	    ORANGEAMULET_ICD = 0.33f,
	    ORANGESTAFF_USES = 20,

	    NIGHTMAREFUEL_FINITEUSESREPAIRVALUE = 50,

	    GREENAMULET_USES = 5,
	    GREENAMULET_INGREDIENTMOD = 0.5f,
	    GREENSTAFF_USES = 5;

    public static int
	    BRUSH_USES = 75,

	    FISHING_MINWAIT = 2,
	    FISHING_MAXWAIT = 20,

	    RESEARCH_MACHINE_DIST = 4,

	    UNARMED_DAMAGE = 10,
	    NIGHTSWORD_DAMAGE = wilson_attack * 2;
	    //-------
    public static float
	    BATBAT_DAMAGE = wilson_attack * 1.25f,
	    BATBAT_DRAIN = wilson_attack * 0.2f,
	    //-------

	    SPIKE_DAMAGE = wilson_attack * 1.5f,
	    HAMBAT_DAMAGE = wilson_attack * 1.75f,
	    HAMBAT_MIN_DAMAGE_MODIFIER = 0.5f,
	    SPEAR_DAMAGE = wilson_attack,
	    WATHGRITHR_SPEAR_DAMAGE = wilson_attack * 1.25f,
	    AXE_DAMAGE = wilson_attack * 0.8f,
	    PICK_DAMAGE = wilson_attack * 0.8f,
	    BOOMERANG_DAMAGE = wilson_attack * 0.8f,
	    TORCH_DAMAGE = wilson_attack * 0.5f,
	    HAMMER_DAMAGE = wilson_attack * 0.5f,
	    SHOVEL_DAMAGE = wilson_attack * 0.5f,
	    PITCHFORK_DAMAGE = wilson_attack * 0.5f,
	    BUGNET_DAMAGE = wilson_attack * 0.125f,
	    FISHINGROD_DAMAGE = wilson_attack * 0.125f,
	    UMBRELLA_DAMAGE = wilson_attack * 0.5f,
	    CANE_DAMAGE = wilson_attack * 0.5f,
	    BEAVER_DAMAGE = wilson_attack * 1.5f,
	    MULTITOOL_DAMAGE = wilson_attack * 1.25f,
	    RUINS_BAT_DAMAGE = wilson_attack * 1.75f,
	    NIGHTSTICK_DAMAGE = wilson_attack * 0.85f, //-- Due to the damage being electric, it will get multiplied by 1.5f against any mob

	    CANE_SPEED_MULT = 1.25f,
	    PIGGYBACK_SPEED_MULT = 0.9f,
	    RUINS_BAT_SPEED_MULT = 1.1f,

	    TORCH_ATTACK_IGNITE_PERCENT = 1,

	    SPRING_COMBAT_MOD = 1.33f,

	    PIG_DAMAGE = 33,
	    PIG_HEALTH = 250,
	    PIG_ATTACK_PERIOD = 3,
	    PIG_TARGET_DIST = 16,
	    PIG_LOYALTY_MAXTIME = 2.5f * total_day_time,
	    PIG_LOYALTY_PER_HUNGER = total_day_time / 25,
	    PIG_MIN_POOP_PERIOD = seg_time * 0.5f,

	    SPIDER_LOYALTY_MAXTIME = 2.5f * total_day_time,
	    SPIDER_LOYALTY_PER_HUNGER = total_day_time / 25,

	    WEREPIG_DAMAGE = 40,
	    WEREPIG_HEALTH = 350,
	    WEREPIG_ATTACK_PERIOD = 2,

	    PIG_GUARD_DAMAGE = 33,
	    PIG_GUARD_HEALTH = 300,
	    PIG_GUARD_ATTACK_PERIOD = 1.5f,
	    PIG_GUARD_TARGET_DIST = 8,
	    PIG_GUARD_DEFEND_DIST = 20,

	    PIG_RUN_SPEED = 5,
	    PIG_WALK_SPEED = 3,

	    WEREPIG_RUN_SPEED = 7,
	    WEREPIG_WALK_SPEED = 3,

	    WILSON_WALK_SPEED = 4,
	    WILSON_RUN_SPEED = 6,
	    PERD_SPAWNCHANCE = 0.1f,
	    PERD_DAMAGE = 20,
	    PERD_HEALTH = 50,
	    PERD_ATTACK_PERIOD = 3,
	    PERD_RUN_SPEED = 8,
	    PERD_WALK_SPEED = 3,

	    MERM_DAMAGE = 30,
	    MERM_HEALTH = 250,
	    MERM_ATTACK_PERIOD = 3,
	    MERM_RUN_SPEED = 8,
	    MERM_WALK_SPEED = 3,
	    MERM_TARGET_DIST = 10,
	    MERM_DEFEND_DIST = 30,

	    WALRUS_DAMAGE = 33,
	    WALRUS_HEALTH = 150,
	    WALRUS_ATTACK_PERIOD = 3,
	    WALRUS_ATTACK_DIST = 15,
	    WALRUS_DART_RANGE = 25,
	    WALRUS_MELEE_RANGE = 5,
	    WALRUS_TARGET_DIST = 10,
	    WALRUS_LOSETARGET_DIST = 30,
	    WALRUS_REGEN_PERIOD = total_day_time * 2.5f,

	    LITTLE_WALRUS_DAMAGE = 22,
	    LITTLE_WALRUS_HEALTH = 100,
	    LITTLE_WALRUS_ATTACK_PERIOD = 3 * 1.7f,
	    LITTLE_WALRUS_ATTACK_DIST = 15,

	    PIPE_DART_DAMAGE = 100,

	    PENGUIN_DAMAGE = 33,
	    PENGUIN_HEALTH = 150,
	    PENGUIN_ATTACK_PERIOD = 3,
	    PENGUIN_ATTACK_DIST = 2.5f,
	    PENGUIN_MATING_SEASON_LENGTH = 6,
	    PENGUIN_MATING_SEASON_WAIT = 1,
	    PENGUIN_MATING_SEASON_BABYDELAY = total_day_time * 1.5f,
	    PENGUIN_MATING_SEASON_BABYDELAY_VARIANCE = 0.5f * total_day_time,
	    PENGUIN_TARGET_DIST = 15,
	    PENGUIN_CHASE_DIST = 30,
	    PENGUIN_FOLLOW_TIME = 10,
	    PENGUIN_HUNGER = total_day_time * 12, //-- takes all winter to starve
	    PENGUIN_STARVE_TIME = total_day_time * 12,
	    PENGUIN_STARVE_KILL_TIME = 20;

    public static int
	    KNIGHT_DAMAGE = 40,
	    KNIGHT_HEALTH = 300,
	    KNIGHT_ATTACK_PERIOD = 2,
	    KNIGHT_WALK_SPEED = 5,
	    KNIGHT_TARGET_DIST = 10,

	    BISHOP_DAMAGE = 40,
	    BISHOP_HEALTH = 300,
	    BISHOP_ATTACK_PERIOD = 4,
	    BISHOP_ATTACK_DIST = 6,
	    BISHOP_WALK_SPEED = 5,
	    BISHOP_TARGET_DIST = 12,

	    ROOK_DAMAGE = 45,
	    ROOK_HEALTH = 300,
	    ROOK_ATTACK_PERIOD = 2,
	    ROOK_WALK_SPEED = 5,
	    ROOK_RUN_SPEED = 16,
	    ROOK_TARGET_DIST = 12,

	    MINOTAUR_DAMAGE = 100,
	    MINOTAUR_HEALTH = 2500,
	    MINOTAUR_ATTACK_PERIOD = 2,
	    MINOTAUR_WALK_SPEED = 5,
	    MINOTAUR_RUN_SPEED = 17,
	    MINOTAUR_TARGET_DIST = 25,
	    MINOTAUR_LEAP_CD = 10;

    public static float
	    SLURTLE_DAMAGE = 25,
	    SLURTLE_HEALTH = 600,
	    SLURTLE_ATTACK_PERIOD = 4,
	    SLURTLE_ATTACK_DIST = 2.5f,
	    SLURTLE_WALK_SPEED = 3,
	    SLURTLE_TARGET_DIST = 10,
	    SLURTLE_SHELL_ABSORB = 0.95f,
	    SLURTLE_DAMAGE_UNTIL_SHIELD = 150,

	    SLURTLE_EXPLODE_DAMAGE = 300,
	    SLURTLESLIME_EXPLODE_DAMAGE = 50,

	    SNURTLE_WALK_SPEED = 4,
	    SNURTLE_DAMAGE = 5,
	    SNURTLE_HEALTH = 200,
	    SNURTLE_SHELL_ABSORB = 0.8f,
	    SNURTLE_DAMAGE_UNTIL_SHIELD = 10,
	    SNURTLE_EXPLODE_DAMAGE = 300,

	    LIGHTNING_DAMAGE = 10,

	    ELECTRIC_WET_DAMAGE_MULT = 1,
	    ELECTRIC_DAMAGE_MULT = 1.5f,

	    LIGHTNING_GOAT_DAMAGE = 25,
	    LIGHTNING_GOAT_ATTACK_RANGE = 3,
	    LIGHTNING_GOAT_ATTACK_PERIOD = 2,
	    LIGHTNING_GOAT_WALK_SPEED = 4,
	    LIGHTNING_GOAT_RUN_SPEED = 8,
	    LIGHTNING_GOAT_TARGET_DIST = 5,
	    LIGHTNING_GOAT_CHASE_DIST = 30,
	    LIGHTNING_GOAT_FOLLOW_TIME = 30,
	    LIGHTNING_GOAT_MATING_SEASON_BABYDELAY = total_day_time * 1.5f,
	    LIGHTNING_GOAT_MATING_SEASON_BABYDELAY_VARIANCE = 0.5f * total_day_time,

	    BUZZARD_DAMAGE = 15,
	    BUZZARD_ATTACK_RANGE = 2,
	    BUZZARD_ATTACK_PERIOD = 2,
	    BUZZARD_WALK_SPEED = 4,
	    BUZZARD_RUN_SPEED = 8,
	    BUZZARD_HEALTH = 125,

	    FREEZING_KILL_TIME = 120,
	    STARVE_KILL_TIME = 120,
	    HUNGRY_THRESH = 0.333f,

	    GRUEDAMAGE = wilson_health * 0.667f,

	    MARSHBUSH_DAMAGE = wilson_health * 0.02f,
	    CACTUS_DAMAGE = wilson_health * 0.04f,

	    GHOST_SPEED = 2,
	    GHOST_HEALTH = 200,
	    GHOST_RADIUS = 1.5f,
	    GHOST_DAMAGE = wilson_health * 0.1f,
	    GHOST_DMG_PERIOD = 1.2f,
	    GHOST_DMG_PLAYER_PERCENT = 1,

	    ABIGAIL_SPEED = 5,
	    ABIGAIL_HEALTH = wilson_health * 4,
	    ABIGAIL_DAMAGE_PER_SECOND = 20,
	    ABIGAIL_DMG_PERIOD = 1.5f,
	    ABIGAIL_DMG_PLAYER_PERCENT = 0.25f,

	    MIN_LEAF_CHANGE_TIME = 0.1f * day_time,
	    MAX_LEAF_CHANGE_TIME = 3 * day_time,
	    MIN_SWAY_FX_FREQUENCY = 1 * seg_time,
	    MAX_SWAY_FX_FREQUENCY = 2 * seg_time,
	    SWAY_FX_FREQUENCY = 1 * seg_time;

    
    public static float
	    SHADOWWAXWELL_LIFETIME = total_day_time * 2.5f,
	    SHADOWWAXWELL_SPEED = 6,
	    SHADOWWAXWELL_DAMAGE = 40,
	    SHADOWWAXWELL_LIFE = 75,
	    SHADOWWAXWELL_ATTACK_PERIOD = 2,
	    SHADOWWAXWELL_SANITY_PENALTY = 55,
	    SHADOWWAXWELL_HEALTH_COST = 15,
	    SHADOWWAXWELL_FUEL_COST = 2,

	    LIVINGTREE_CHANCE = 0.55f;
}