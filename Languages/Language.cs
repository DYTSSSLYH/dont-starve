using DYT;

/**
 * Here is where you can select a language file to override the default english strings
 * The game currently only supports ASCII (sadly), so not all languages can be supported at this time.
 */
public class Language
{
    public static string APP_REGION = "NONE";


    public static Loc.Locale GetCurrentLocale()
    {
        return Loc.GetLocale(GameLogic.Profile.GetLanguageID());
    }
    

    public static void Init()
    {
        LanguageTranslator.UseLongestLocs(false);
        Loc.SetCurrentLocale(GetCurrentLocale());
        Loc.Locale currentLocale = Loc.GetLocale();
        if (currentLocale != null)
        {
            string file = Loc.GetStringFile(currentLocale.id);
            LanguageTranslator.LoadPOFile(file, currentLocale.code);
            TheSim.SetUseUnicode(Loc.GetUseUnicode());
        }
    }
}