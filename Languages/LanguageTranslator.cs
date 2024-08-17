using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using DYT;

/**
 * Revised version by WrathOf using msgctxt field for po/t file
 * msgctxt is set to the "path" in the table structure which is guaranteed unique
 * versus the string values (msgid) which are not.
 *
 * Added a file format field to the po file so can support old format po files
 * and new format po files.  The new format ones will contain all entries from
 * the strings table which the old format cannot support.
 */
public class LanguageTranslator
{
    private static Dictionary<string, Dictionary<string, string>> languages =
        new Dictionary<string, Dictionary<string, string>>();
    public static string defaultlang = null;
    private static string dbFile = null;
    
    public static bool use_longest_locs = false;

    
    public static void UseLongestLocs(bool to)
    {
        use_longest_locs = to;
    }

    // Join multiline strings in a po file, return array of joined strings
    private static string[] JoinPOFileMultilineStrings(string fileName)
    {
        List<string> lines = new List<string>();
        string workline = "";
        bool started = false;
        foreach (string i in File.ReadAllLines(fileName))
        {
            // skip the header
            if (i.StartsWith("#")) started = true;

            // if our buffer ands with '"' and current line starts with '"'
            if (started && workline.EndsWith("\"") && i.StartsWith("\""))
            {
                //  append, stripping out end and start quotes
                workline = workline.Substring(0, workline.Length - 1) + i.Substring(1);
            }
            // otherwise, flush it
            else
            {
                lines.Add(workline);
                workline = i;
            }
        }
        // flush what we had left
        lines.Add(workline);

        return lines.ToArray();
    }
    
    
    
    // New version
    public static void LoadPOFile(string fileName, string languageCode)
    {
        if (dbFile != null) File.AppendAllText(dbFile, $"Translator: Loading PO file: {fileName}\n");

        string file = Util.resolvefilepath(fileName);
        DebugPrint.Print($"Translator:LoadPOFile - loading file: {file}");
        if (!File.Exists(file))
        {
            DebugPrint.Print($"Translator:LoadPOFile - Specified language file {file} not found.");
            return;
        }

        Dictionary<string, string> strings = new Dictionary<string, string>();
        bool newFormatFlag = false;
        string currentId = null;
        bool msgStrFlag = false;
        string currentString = "";
        foreach (string line in JoinPOFileMultilineStrings(file))
        {
            // Skip lines until find an id using new format
            if (newFormatFlag && currentId == null)
            {
                Match match = Regex.Match(line, "^msgctxt(\\s*)\"(\\S*)\"");
                if (match.Groups.Count >= 3)
                {
                    currentId = match.Groups[2].Value;
                    if (dbFile != null) File.AppendAllText(dbFile, $"Found new format id: {currentId}\n");
                }
            }
            // Skip lines until find an id using old format (reference field)
            else if (!newFormatFlag && currentId == null)
            {
                Match match = Regex.Match(line, @"^#:(\s*)(\S*)");
                if (match.Groups.Count >= 3)
                {
                    currentId = match.Groups[2].Value;
                    if (dbFile != null) File.AppendAllText(dbFile, $"Found old format id: {currentId}\n");
                }
            }
            // Gather up parts of translated text (since POedit breaks it up into 80 char strings)
            else if (msgStrFlag)
            {
                Match match = Regex.Match(line, "^(\\s*)\"(.*)\"");
                // Found blank line or next entry (assumes blank line after each entry or at least a #. line)
                if (match.Groups.Count < 3)
                {
                    // Store translated text if provided
                    if (currentString != "")
                    {
                        strings.Add(currentId, ConvertEscapeCharactersToRaw(currentString));
                        
                        if (dbFile != null)
                            File.AppendAllText(dbFile, $"Found id: {currentId}\tFound str: {currentString}\n");
                    }
                    currentString = "";
                    msgStrFlag = false;
                    currentId = null;
                }
                // Combine text with previously gathered text
                else currentString += match.Groups[2].Value;
            }
            // Have id, so look for translated text
            else if (currentId != null)
            {
                Match match = Regex.Match(line, "^msgstr(\\s*)\"(.*)\"");
                if (match.Groups.Count >= 3)
                {
                    string c2 = match.Groups[2].Value;
                    // Found multi-line entry so flag to gather it up
                    if (c2 == "") msgStrFlag = true;
                    // Found translated text so store it
                    else
                    {
                        strings.Add(currentId, ConvertEscapeCharactersToRaw(c2));
                        
                        if (dbFile != null)
                            File.AppendAllText(dbFile, $"Found id: {currentId}\tFound str: {c2}\n");
                        
                        currentId = null;
                    }
                }
            }
            // skip line
            else{}

            // Search for new format field if not already found
            if (!newFormatFlag)
            {
                if (line == "\"POT Version: 2.0\"" || line == "X-Generator: Poedit")
                {
                    // Assume that Poedit is generating the new format files with msgctxt
                    newFormatFlag = true;
                    
                    if (dbFile != null) File.AppendAllText(dbFile, "Found new file format\n");
                }
            }
        }

        if (!languages.ContainsKey(languageCode)) languages.Add(languageCode, strings);
        else languages[languageCode] = strings;
        defaultlang = languageCode;
        
        if (dbFile != null) File.AppendAllText(dbFile, "Done!\n");
    }

    
    // Renamed since more generic now
    public static string ConvertEscapeCharactersToRaw(string str)
    {
        string rowString = str.Replace("\\n", "\n");
        rowString = rowString.Replace("\\r", "\r");
        rowString = rowString.Replace("\\\"", "\"");

        return rowString;
    }
    
    // called by strings.lua
    public static void TranslateStringTable()
    {
        if (!string.IsNullOrWhiteSpace(dbFile))
            File.AppendAllText(dbFile, "Translator: Translating string table....\n");

        foreach (string lang in languages.Keys)
        {
            if (!use_longest_locs && lang != defaultlang) continue;

            Dictionary<string,string> map = languages[lang];
            foreach (string strid in map.Keys)
            {
                int lastIndexOf = strid.LastIndexOf('.');
                string typeName = strid.Substring(0, lastIndexOf);
                Type type = Type.GetType(typeName);
                FieldInfo fieldInfo = type.GetField(strid.Substring(lastIndexOf + 1));
                string from = (string)fieldInfo.GetValue(null);
                string to = ConvertEscapeCharactersToRaw(map[strid]);
                
                if (use_longest_locs && to.Length <= ConvertEscapeCharactersToRaw(from).Length)
                    continue;
                
                fieldInfo.SetValue(null, map[strid]);
            }
        }
    }
}