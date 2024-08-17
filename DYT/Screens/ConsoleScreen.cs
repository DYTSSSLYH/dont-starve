using System.Collections.Generic;
using System.IO;
using DYT;
using UnityEngine;
using Screen = DYT.Widgets.Screen;

public class ConsoleScreen : Screen
{
    private static List<string> CONSOLE_HISTORY;
    private static int SUGGESTIONS_MAX;
    
    #region GLOBAL FUNCTIONS

    public static void SaveConsoleHistory()
    {
        int index = CONSOLE_HISTORY.Count > SUGGESTIONS_MAX ? CONSOLE_HISTORY.Count - SUGGESTIONS_MAX : 0;
        
        File.WriteAllLines(
            Application.dataPath + "/console_history.txt",
            CONSOLE_HISTORY.GetRange(index, SUGGESTIONS_MAX)
        );
    }

    public static void ExecuteConsoleCommand(string fnStr)
    {
        if (!string.IsNullOrWhiteSpace(fnStr)) CONSOLE_HISTORY.Add(fnStr);
        
        SaveConsoleHistory();
    }

    #endregion

    static ConsoleScreen()
    {
        CONSOLE_HISTORY = new List<string>();
        SUGGESTIONS_MAX = 15;
    }
    
    
    private int autocompleteOffset;
    private object autocompletePrefix;
    private object autocompleteObj;
    private string autocompleteObjName;
    private bool suggesting;
    private object highlight;
    private string suggest_replace;
    
    
    public void Run(string fnStr)
    {
        Stats.SuUsedAdd("console_used");
        
        ExecuteConsoleCommand(fnStr);
    }

    public void Close()
    {
        MainFunctions.SetPause(false);
        TheInput.EnableDebugToggle(true);
        Main.TheFrontEnd.PopScreen();
    }
    
    public void OnTextEntered(string text)
    {
        Run(text);
        Close();
        if (Main.TheFrontEnd.consoletext.closeonrun.HasValue)
        {
            Main.TheFrontEnd.HideConsoleLog();
            Main.TheFrontEnd.consoletext.closeonrun = null;
        }
    }
    
    public void DoInit()
    {
        MainFunctions.SetPause(true, "console");
        TheInput.EnableDebugToggle(false);

        autocompleteOffset = -1;
        autocompletePrefix = null;
        autocompleteObj = null;
        autocompleteObjName = "";
        
        suggesting = false;
        highlight = null;
        suggest_replace = "";
    }
    

    // Start is called before the first frame update
    private void Start()
    {
        DoInit();
    }
}