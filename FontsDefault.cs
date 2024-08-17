using System.Collections.Generic;

public class FontsDefault
{
    public static string
        DEFAULTFONT = "opensans",
        DIALOGFONT = "opensans",
        TITLEFONT = "bp100",
        UIFONT = "bp50",
        BUTTONFONT = "buttonfont",
        NUMBERFONT = "stint-ucr",
        TALKINGFONT = "talkingfont",
        TALKINGFONT_WATHGRITHR = "talkingfont_wathgrithr",
        TALKINGFONT_WORMWOOD = "talkingfont_wormwood",
        SMALLNUMBERFONT = "stint-small",
        BODYTEXTFONT = "stint-ucr",

        CONTROLLERS = "controllers",

        FALLBACK_FONT = "fallback_font",
        FALLBACK_FONT_OUTLINE = "fallback_font_outline";

    public static List<string> DEFAULT_FALLBACK_TABLE = new List<string>
    {
        CONTROLLERS,
        FALLBACK_FONT,
    };

    public static List<string> DEFAULT_FALLBACK_TABLE_OUTLINE = new List<string>
    {
        CONTROLLERS,
        FALLBACK_FONT_OUTLINE,
    };

    private static string font_posfix = "";
    
    public class Font
    {
        public string filename;
        public string alias;
        public List<string> fallback;
        public int adjustadvance;
    }
    public static List<Font> FONTS;

    public static void Init()
    {
        // This gets called from the build pipeline too
        string lang = LanguageTranslator.defaultlang;

        // Some languages need their own font
        List<string> specialFontLangs = new List<string> { "jp" };
        
        foreach (string v in specialFontLangs)
        {
            if (v == lang) font_posfix = "__" + lang;
        }

        FONTS = new List<Font>
        {
            new Font
            {
                filename = "fonts/talkingfont" + font_posfix + ".zip", alias = TALKINGFONT,
                fallback = DEFAULT_FALLBACK_TABLE_OUTLINE
            },
            new Font
            {
                filename = "fonts/talkingfont_wathgrithr.zip", alias = TALKINGFONT_WATHGRITHR,
                fallback = DEFAULT_FALLBACK_TABLE_OUTLINE
            },
            new Font
            {
                filename = "fonts/talkingfont_wormwood.zip", alias = TALKINGFONT_WORMWOOD,
                fallback = DEFAULT_FALLBACK_TABLE_OUTLINE
            },
            new Font
            {
                filename = "fonts/stint-ucr50" + font_posfix + ".zip", alias = BODYTEXTFONT,
                fallback = DEFAULT_FALLBACK_TABLE_OUTLINE
            },
            new Font
            {
                filename = "fonts/stint-ucr20" + font_posfix + ".zip", alias = SMALLNUMBERFONT,
                fallback = DEFAULT_FALLBACK_TABLE_OUTLINE
            },
            new Font
            {
                filename = "fonts/opensans50" + font_posfix + ".zip", alias = DEFAULTFONT,
                fallback = DEFAULT_FALLBACK_TABLE_OUTLINE
            },
            new Font
            {
                filename = "fonts/belisaplumilla50" + font_posfix + ".zip", alias = UIFONT,
                fallback = DEFAULT_FALLBACK_TABLE_OUTLINE, adjustadvance = -2
            },
            new Font
            {
                filename = "fonts/belisaplumilla100" + font_posfix + ".zip", alias = TITLEFONT,
                fallback = DEFAULT_FALLBACK_TABLE_OUTLINE
            },
            new Font
            {
                filename = "fonts/buttonfont" + font_posfix + ".zip", alias = BUTTONFONT,
                fallback = DEFAULT_FALLBACK_TABLE
            },

            new Font { filename = "fonts/controllers" + font_posfix + ".zip", alias = CONTROLLERS },

            new Font { filename = "fonts/fallback_full_packed" + font_posfix + ".zip", alias = FALLBACK_FONT },
            new Font
            {
                filename = "fonts/fallback_full_outline_packed" + font_posfix + ".zip", alias = FALLBACK_FONT_OUTLINE
            },
        };
    }
}