public class Tuning
{
    // each segment of the clock is 30 seconds
    private static int seg_time = 30;
    private static int total_day_time = seg_time * 16;

    private static int day_segs = 10;
    private static int dusk_segs = 10;
    private static int night_segs = 10;

    // default day composition. changes in winter, etc
    private static int day_time = seg_time * day_segs;
    private static int dusk_time = seg_time * dusk_segs;
    private static int night_time = seg_time * night_segs;

    private static int wilson_attack = 34;
    private static int wilson_health = 150;
    private static int calories_per_day = 75;

    private static float wilson_attack_period = 0.5f;

    // /200
    private static int perish_warp = 1;

    public static float DEMO_TIME = total_day_time * 2 + day_time * 0.2f;

    public static int
        AUTOSAVE_INTERVAL = total_day_time,
        SEG_TIME = seg_time,
        TOTAL_DAY_TIME = total_day_time,
        DAY_SEGS_DEFAULT = day_segs,
        DUSK_SEGS_DEFAULT = dusk_segs,
        NIGHT_SEGS_DEFAULT = night_segs,
        STACK_SIZE_LARGEITEM = 10,
        STACK_SIZE_MEDITEM = 20,
        STACK_SIZE_SMALLITEM = 40;
}