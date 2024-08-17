using System.Collections.Generic;

public class Loc
{
    public class Locale
    {
        public Constant.LANGUAGE id;
        public Constant.LANGUAGE? altId;
        public string strings;
        public string code;
        public float scale;
        public bool in_steam_menu;
        public bool in_console_menu;
        public bool shrink_to_fit_word;
        public bool use_unicode;
    }
    private static List<Locale> _localizationList = new()
    {
        new Locale
        {
            id = Constant.LANGUAGE.FRENCH,
            altId = null,
            strings = "french.po",
            code = "fr",
            scale = 1.0f,
            in_steam_menu = false,
            in_console_menu = true,
            shrink_to_fit_word = true
        },
        new Locale
        {
            id = Constant.LANGUAGE.CHINESE_S,
            altId = Constant.LANGUAGE.CHINESE_T,
            strings = "chinese_s.po",
            code = "zh",
            scale = 0.85f,
            in_steam_menu = true,
            in_console_menu = true,
            shrink_to_fit_word = false,
            use_unicode = true
        }
    };

    private static string LOC_ROOT_DIR = "Scripts/Languages/";
    
    public static Locale currentLocale = null;


    public static void SetCurrentLocale(Locale locale)
    {
        currentLocale = locale;
    }
    
    public static Locale GetLocale(Constant.LANGUAGE? languageId = null)
    {
        if (languageId == null) return currentLocale;

        return _localizationList.Find(
            localization => localization.id == languageId || localization.altId == languageId);
    }
    
    public static string GetLocaleCode(Constant.LANGUAGE? lang_id = null)
    {
        Locale locale = GetLocale(lang_id);
        return locale == null ? "en" : locale.code;
    }

    public static string GetStringFile(Constant.LANGUAGE languageId)
    {
        Locale locale = GetLocale(languageId);
        string file = null;
        if (locale != null)
        {
            file = LOC_ROOT_DIR + locale.strings;
        }
        return file;
    }

    public static float GetTextScale()
    {
        return currentLocale == null ? 1.0f : currentLocale.scale;
    }

    public static bool GetUseUnicode()
    {
        return currentLocale == null ? true : currentLocale.use_unicode;
    }
}