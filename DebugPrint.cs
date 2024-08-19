using System;
using System.Collections.Generic;
using UnityEngine;

public class DebugPrint
{
    public static string CWD = Application.dataPath;


    
    private static Action<object[]> print_loggers;

    public static void AddPrintLogger(Action<object[]> fn)
    {
        print_loggers += fn;
    }

    private static string dir = CWD;

    private static string packstring(object[] objectArray)
    {
        string str = "";
        foreach (object v in objectArray) str += $"{v}\t";
        return str;
    }

    // this wraps print in code that shows what line number it is coming from,
    // and pushes it out to all of the print loggers
    public static void print(params object[] objectArray)
    {
        string str = "";
        str = packstring(objectArray);

        print_loggers(new object[]{str});
    }
    
    
    // This keeps a record of the last n print lines,
    // so that we can feed it into the debug console when it is visible
    private static List<string> debugstr = new List<string>();
    private static int MAX_CONSOLE_LINES = 20;

    private static void consolelog(object[] objectArray)
    {
        string str = packstring(objectArray);
        str = str.Replace(dir, "");
        
        foreach (string line in str.Split("\r\n")) debugstr.Add(line);

        while (debugstr.Count > MAX_CONSOLE_LINES)
        {
            debugstr.RemoveAt(0);
        }
    }

    public static List<string> GetConsoleOutputList()
    {
        return debugstr;
    }



    static DebugPrint()
    {
        dir = dir.Replace("\\", "/") + "/";
        
        // add our print loggers
        AddPrintLogger(consolelog);
    }
}