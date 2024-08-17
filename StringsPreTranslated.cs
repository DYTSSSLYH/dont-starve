﻿using System;
using DYT;

public class StringsPreTranslated
{
    private enum Language
    {
        ENGLISH = 0,
        ENGLISH_UK = 1,
        FRENCH = 2,
        FRENCH_CA = 3,
        SPANISH = 4,
        SPANISH_LA = 5,
        GERMAN = 6,
        ITALIAN = 7,
        PORTUGUESE = 8,
        PORTUGUESE_BR = 9,
        DUTCH = 10,
        FINNISH = 11,
        SWEDISH = 12,
        DANISH = 13,
        NORWEGIAN = 14,
        POLISH = 15,
        RUSSIAN = 16,
        TURKISH = 17,
        ARABIC = 18,
        KOREAN = 19,
        JAPANESE = 20,
        CHINESE_T = 21,
        CHINESE_S = 22,
        CHINESE_S_RAIL = 23
    }

    public static void Init()
    {
        int capacity = Enum.GetNames(typeof(Language)).Length;
        for (int i = 0; i < capacity; i++)
        {
            Strings.PRETRANSLATED.LANGUAGES.Add(null);
            Strings.PRETRANSLATED.LANGUAGES_TITLE.Add(null);
            Strings.PRETRANSLATED.LANGUAGES_BODY.Add(null);
            Strings.PRETRANSLATED.LANGUAGES_YES.Add(null);
            Strings.PRETRANSLATED.LANGUAGES_NO.Add(null);
        }
        
        
        Strings.PRETRANSLATED.LANGUAGES[(int)Language.ENGLISH] = "English";
        Strings.PRETRANSLATED.LANGUAGES[(int)Language.FRENCH] = "Français (French)";
        Strings.PRETRANSLATED.LANGUAGES[(int)Language.SPANISH] = "Español (Spanish)";
        Strings.PRETRANSLATED.LANGUAGES[(int)Language.SPANISH] = "Español (Spanish)";
        Strings.PRETRANSLATED.LANGUAGES[(int)Language.SPANISH_LA] =
            "Español - América Latina\n(Spanish - Latin America)";
        Strings.PRETRANSLATED.LANGUAGES[(int)Language.GERMAN] = "Deutsch (German)";
        Strings.PRETRANSLATED.LANGUAGES[(int)Language.ITALIAN] = "Italiano (Italian)";
        Strings.PRETRANSLATED.LANGUAGES[(int)Language.PORTUGUESE_BR] = "Português (Portuguese)";
        Strings.PRETRANSLATED.LANGUAGES[(int)Language.POLISH] = "Polski (Polish)";
        Strings.PRETRANSLATED.LANGUAGES[(int)Language.RUSSIAN] = "Русский (Russian)";
        Strings.PRETRANSLATED.LANGUAGES[(int)Language.KOREAN] = "한국어 (Korean)";
        Strings.PRETRANSLATED.LANGUAGES[(int)Language.CHINESE_S] = "简体中文 (Simplified Chinese)";
        
        Strings.PRETRANSLATED.LANGUAGES_TITLE[(int)Language.ENGLISH] = "Translation Option";
        Strings.PRETRANSLATED.LANGUAGES_TITLE[(int)Language.FRENCH] = "Option de traduction";
        Strings.PRETRANSLATED.LANGUAGES_TITLE[(int)Language.SPANISH] = "Opción de traducción";
        Strings.PRETRANSLATED.LANGUAGES_TITLE[(int)Language.SPANISH_LA] = "Opción de traducción";
        Strings.PRETRANSLATED.LANGUAGES_TITLE[(int)Language.GERMAN] = "Übersetzungsoption";
        Strings.PRETRANSLATED.LANGUAGES_TITLE[(int)Language.ITALIAN] = "Opzione di traduzione";
        Strings.PRETRANSLATED.LANGUAGES_TITLE[(int)Language.PORTUGUESE_BR] = "Opção de Tradução";
        Strings.PRETRANSLATED.LANGUAGES_TITLE[(int)Language.POLISH] = "Opcja tłumaczenia";
        Strings.PRETRANSLATED.LANGUAGES_TITLE[(int)Language.RUSSIAN] = "Вариант перевода";
        Strings.PRETRANSLATED.LANGUAGES_TITLE[(int)Language.KOREAN] = "번역 옵션";
        Strings.PRETRANSLATED.LANGUAGES_TITLE[(int)Language.CHINESE_S] = "语言设定";
        
        Strings.PRETRANSLATED.LANGUAGES_BODY[(int)Language.ENGLISH] =
            "Your interface language is set to English. " +
            "Would you like to enable the translation for your language?";
        Strings.PRETRANSLATED.LANGUAGES_BODY[(int)Language.FRENCH] =
            "Votre langue d'interface est définie sur Français. " +
            "Voulez-vous activer la traduction pour votre langue?";
        Strings.PRETRANSLATED.LANGUAGES_BODY[(int)Language.SPANISH] =
            "El idioma de la interfaz está configurado a español. ¿Quieres permitir la traducción a tu idioma?";
        Strings.PRETRANSLATED.LANGUAGES_BODY[(int)Language.SPANISH_LA] =
            "El idioma de la interfaz está configurado a español. ¿Quieres permitir la traducción a tu idioma?";
        Strings.PRETRANSLATED.LANGUAGES_BODY[(int)Language.GERMAN] =
            "Deine Sprache ist auf Deutsch eingestellt. " +
            "Möchtest du die Übersetzung für deine Sprache aktivieren?";
        Strings.PRETRANSLATED.LANGUAGES_BODY[(int)Language.ITALIAN] =
            "La lingua dell'interfaccia è impostata su italiano. " +
            "Vorresti abilitare la traduzione per la tua lingua?";
        Strings.PRETRANSLATED.LANGUAGES_BODY[(int)Language.PORTUGUESE_BR] =
            "O idioma da interface está definido como português. " +
            "Gostaria de habilitar a tradução para o seu idioma?";
        Strings.PRETRANSLATED.LANGUAGES_BODY[(int)Language.POLISH] =
            "Język interfejsu został określony jako: polski. " +
            "Czy życzysz sobie włączyć tłumaczenie na twój język?";
        Strings.PRETRANSLATED.LANGUAGES_BODY[(int)Language.RUSSIAN] =
            "В качестве языка интерфейса выбран русский. Вам требуется перевод на ваш язык?";
        Strings.PRETRANSLATED.LANGUAGES_BODY[(int)Language.KOREAN] =
            "인터페이스 언어가 한국어로 설정되어 있습니다. 해당 언어의 번역을 사용 하시겠습니까?";
        Strings.PRETRANSLATED.LANGUAGES_BODY[(int)Language.CHINESE_S] = "是否把语言设定为中文？";
        
        Strings.PRETRANSLATED.LANGUAGES_YES[(int)Language.ENGLISH] = "Yes";
        Strings.PRETRANSLATED.LANGUAGES_YES[(int)Language.FRENCH] = "Oui";
        Strings.PRETRANSLATED.LANGUAGES_YES[(int)Language.SPANISH] = "Sí";
        Strings.PRETRANSLATED.LANGUAGES_YES[(int)Language.SPANISH_LA] = "Sí";
        Strings.PRETRANSLATED.LANGUAGES_YES[(int)Language.GERMAN] = "Ja";
        Strings.PRETRANSLATED.LANGUAGES_YES[(int)Language.ITALIAN] = "Sì";
        Strings.PRETRANSLATED.LANGUAGES_YES[(int)Language.PORTUGUESE_BR] = "Sim";
        Strings.PRETRANSLATED.LANGUAGES_YES[(int)Language.POLISH] = "Tak";
        Strings.PRETRANSLATED.LANGUAGES_YES[(int)Language.RUSSIAN] = "Да";
        Strings.PRETRANSLATED.LANGUAGES_YES[(int)Language.KOREAN] = "예";
        Strings.PRETRANSLATED.LANGUAGES_YES[(int)Language.CHINESE_S] = "是";
        
        Strings.PRETRANSLATED.LANGUAGES_NO[(int)Language.ENGLISH] = "No";
        Strings.PRETRANSLATED.LANGUAGES_NO[(int)Language.FRENCH] = "Non";
        Strings.PRETRANSLATED.LANGUAGES_NO[(int)Language.SPANISH] = "No";
        Strings.PRETRANSLATED.LANGUAGES_NO[(int)Language.SPANISH_LA] = "No";
        Strings.PRETRANSLATED.LANGUAGES_NO[(int)Language.GERMAN] = "Nein";
        Strings.PRETRANSLATED.LANGUAGES_NO[(int)Language.ITALIAN] = "No";
        Strings.PRETRANSLATED.LANGUAGES_NO[(int)Language.PORTUGUESE_BR] = "Não";
        Strings.PRETRANSLATED.LANGUAGES_NO[(int)Language.POLISH] = "Nie";
        Strings.PRETRANSLATED.LANGUAGES_NO[(int)Language.RUSSIAN] = "Нет";
        Strings.PRETRANSLATED.LANGUAGES_NO[(int)Language.KOREAN] = "아니";
        Strings.PRETRANSLATED.LANGUAGES_NO[(int)Language.CHINESE_S] = "否";
    }
}