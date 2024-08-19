using System;
using System.Collections.Generic;
using DYT;
using DYT.Widgets;
using UnityEngine;
using Screen = DYT.Widgets.Screen;
using Text = DYT.Widgets.Text;

public class FrontEnd : MonoBehaviour
{
    public Text consoletext { get; private set; }
    public Widget helptext { get; private set; }
    
    public GameObject consoleScreen;
    public AudioClip click_mouseover_controller;
    
    private float REPEAT_TIME = 0.15f;
    private float PAGE_REPEAT_TIME = 0.25f;
    private float SCROLL_REPEAT_TIME = 0.05f;
    private float MOUSE_SCROLL_REPEAT_TIME = 0;
    private float save_fade_time = 0.5f;
    
    private List<Screen> screenstack = new();
    private Transform screenroot;
    private Widget overlayroot;
    private List<int> ignoreups = new();
    private Image blackoverlay;
    private Image topblackoverlay;
    private Text helptexttext;
    private float alpha = 0.0f;
    private Text title;
    private Text subtitle;
    private GameObject saving_indicator;
    private GameObject gameinterface;
    private bool displayingerror = false;
    private bool tracking_mouse = true;
    private float repeat_time;
    private float page_repeat_time;
    private bool topFadeHidden = false;
    private List<Widget> updating_widgets = new();
    private int num_pending_saves = 0;
    private int save_indicator_time_left = 0;
    private int save_indicator_fade_time = 0;
    private object save_indicator_fade = null;
    private bool autosave_enabled = true;
    private bool fade_title_in;
    private float fade_title_time;
    private bool fade_title_out;
    private bool focus_locked;
    private float? fade_delay_time;
    private Action delayovercb;
    private bool? fadedir;
    private float self_fade_time;
    private float total_fade_time;
    private Action fadecb;
    private float fade_title_alpha;
    
    private float fade_time = 2;
    private float scroll_repeat_time;
    private List<Widget> updating_widgets_alt;
    
    private void Awake()
    {
        screenroot = transform.Find("ScreenRoot");
        overlayroot = transform.Find("OverlayRoot").GetComponent<Widget>().Init();
        consoletext = transform.Find("ConsoleText").GetComponent<Text>();
        blackoverlay = screenroot.Find("BlackOverlay").GetComponent<Image>();
        topblackoverlay = overlayroot.transform.Find("TopBlackOverlay").GetComponent<Image>();
        helptext = overlayroot.transform.Find("HelpText").GetComponent<Widget>();
        helptexttext = overlayroot.transform.Find("HelpText").Find("HelpTextText").GetComponent<Text>();
        title = overlayroot.transform.Find("Title").GetComponent<Text>();
        subtitle = overlayroot.transform.Find("SubTitle").GetComponent<Text>();
        saving_indicator = transform.Find("SavingIndicator").gameObject;
        gameinterface = transform.Find("GameInterface").gameObject;
    }

    private void Start()
    {
        HideTitle();
        
        TheInput.AddKeyHandler(objectArray => OnRawKey(objectArray[0], objectArray[1]));
        TheInput.AddKeyHandler(objectArray => OnTextInput((string)objectArray[0]));
        
        repeat_time = REPEAT_TIME;
        page_repeat_time = PAGE_REPEAT_TIME;
    }

    public void ShowTopFade()
    {
        topFadeHidden = false;
        topblackoverlay.Show();
    }
    
    public Widget GetFocusWidget()
    {
        return screenstack.Count == 0 ? null : screenstack[^1].GetDeepestFocus();
    }

    public string GetHelpText()
    {
        List<string> list = new List<string>();

        Widget widget = GetFocusWidget();
        if (widget != null && widget.GetHelpText != null)
        {
            string str = widget.GetHelpText();
            if (!string.IsNullOrWhiteSpace(str)) list.Add(str);
        }

        if (screenstack.Count > 0 && screenstack[^1] != widget)
        {
            string str = screenstack[^1].GetHelpText();
            if (!string.IsNullOrWhiteSpace(str)) list.Add(str);
        }

        return string.Join("  ", list);
    }

    public bool OnFocusMove(int dir, bool down)
    {
        if (focus_locked) return true;


        if (screenstack.Count > 0)
        {
            if (screenstack[^1].OnFocusMove(dir, down))
            {
                Main.TheFrontEnd.GetSound().PlayOneShot(click_mouseover_controller);
                tracking_mouse = false;
                return true;
            }
            else if (tracking_mouse && down && screenstack[^1].SetDefaultFocus())
            {
                tracking_mouse = false;
                return true;
            }
        }

        return false;
    }

    public bool OnControl(int control, bool down, bool isrepeat = false)
    {
        // handle focus moves
        
        if (!isrepeat && !down && ignoreups.Contains(control))
        {
            ignoreups.Remove(control);
            return true;
        }


        if (screenstack.Count > 0)
        {
            Screen screen = screenstack[^1];
            // map this one for buttons
            if (control == Constant.CONTROL_PRIMARY) control = Constant.CONTROL_ACCEPT;
            if (screen.OnControl(control, down)) return true;
        }

        if (Main.CONSOLE_ENABLED && !down && control == Constant.CONTROL_OPEN_DEBUG_CONSOLE)
        {
            PushScreen(Instantiate(consoleScreen).GetComponent<ConsoleScreen>());
            return true;
        }

        if (Main.SHOWLOG_ENABLED && !down && control == Constant.CONTROL_TOGGLE_LOG)
        {
            if (consoletext.shown) HideConsoleLog();
            else ShowConsoleLog();
            return true;
        }

        return false;
    }
    
    public void DoTitleFade(float dt)
    {
        if (fade_title_in || fade_title_out)
        {
            dt = Mathf.Min(dt, 1 / 30f);
            if (fade_title_in && fade_title_time < fade_time) fade_title_time += dt;
            else if (fade_title_out && fade_title_time > 0) fade_title_time -= dt;

            fade_title_alpha = Easing.inOutCubic(fade_title_time, 0, 1, fade_time);
            
            title.SetAlpha(fade_title_alpha);
            subtitle.SetAlpha(fade_title_alpha);
            
            if (fade_title_in && fade_title_time >= fade_time) StartTileFadeOut();
        }
    }

    public void StartTileFadeOut()
    {
        fade_title_in = false;
        fade_title_out = true;
    }

    public void HideTitle()
    {
        title.gameObject.SetActive(false);
        subtitle.gameObject.SetActive(false);

        fade_title_in = false;
        fade_title_time = 0;
        fade_title_out = false;
    }

    public void LockFocus(bool lockFocus)
    {
        focus_locked = lockFocus;
    }


    public AudioSource GetSound()
    {
        return gameinterface.GetComponent<AudioSource>();
    }

    public void SetFadeLevel(float alpha)
    {
        this.alpha = alpha;
        if (alpha <= 0)
        {
            blackoverlay.gameObject.SetActive(false);
            topblackoverlay.gameObject.SetActive(false);
        }
        else
        {
            blackoverlay.gameObject.SetActive(false);
            blackoverlay.SetTint(0, 0, 0, alpha);
            if (!topFadeHidden) topblackoverlay.gameObject.SetActive(false);
            topblackoverlay.SetTint(0, 0, 0, alpha);
        }
    }

    public void DoFadingUpdate(float dt)
    {
        dt = Mathf.Min(dt, 1 / 30f);

        if (fade_delay_time.HasValue)
        {
            fade_delay_time -= dt;
            if (fade_delay_time.Value <= 0)
            {
                fade_delay_time = null;
                if (delayovercb != null)
                {
                    delayovercb();
                    delayovercb = null;
                }
            }
        }
        else if (fadedir.HasValue)
        {
            self_fade_time += dt;

            float alpha = 0;
            if (fadedir.HasValue)
            {
                if (total_fade_time == 0) alpha = 0;
                else alpha = Easing.inOutCubic(self_fade_time, 1, -1, total_fade_time);
            }
            else
            {
                if (total_fade_time == 0) alpha = 1;
                else alpha = Easing.outCubic(self_fade_time, 0, 1, total_fade_time);
            }
            
            SetFadeLevel(alpha);
            if (self_fade_time >= total_fade_time)
            {
                fadedir = null;
                if (fadecb != null)
                {
                    fadecb();
                    fadecb = null;
                }
            }
        }
    }

    public void UpdateConsoleOutput()
    {
        string consolestr = "";
        List<string> consoleOutputList = DebugPrint.GetConsoleOutputList();
        for (int i = 0; i < consoleOutputList.Count; i++)
        {
            string consoleOutput = consoleOutputList[i];

            consolestr += i == consoleOutputList.Count - 1 ? consoleOutput : $"{consoleOutput}\n";
        }
        consolestr += "\n(Press CTRL+L to close this log)";
        consoletext.TextWidget.text = consolestr;
    }
    
    // TODO: DEBUGGER_ENABLED、CHEATS_ENABLED、saving_indicator
    public void UpdateInternal(float dt)
    {
        if (consoletext.gameObject.activeInHierarchy) UpdateConsoleOutput();
        
        DoFadingUpdate(dt);
        DoTitleFade(dt);

        if (screenstack.Count > 0) screenstack[^1].OnUpdate(dt);

        if (repeat_time > 0) repeat_time -= dt;

        if (TheInput.IsControlPressed(Constant.CONTROL_PREVVALUE)
            || TheInput.IsControlPressed(Constant.CONTROL_NEXTVALUE)
            || TheInput.IsControlPressed(Constant.CONTROL_PAGELEFT)
            || TheInput.IsControlPressed(Constant.CONTROL_PAGERIGHT))
        {
            page_repeat_time -= dt;
        }
        else page_repeat_time = PAGE_REPEAT_TIME;

        if (page_repeat_time <= 0)
        {
            page_repeat_time = PAGE_REPEAT_TIME;
            if (TheInput.IsControlPressed(Constant.CONTROL_PREVVALUE))
            {
                OnControl(Constant.CONTROL_PREVVALUE, false, true);
                ignoreups.Add(Constant.CONTROL_PREVVALUE);
            }
            else if (TheInput.IsControlPressed(Constant.CONTROL_NEXTVALUE))
            {
                OnControl(Constant.CONTROL_NEXTVALUE, false, true);
                ignoreups.Add(Constant.CONTROL_NEXTVALUE);
            }
            else if (TheInput.IsControlPressed(Constant.CONTROL_PAGELEFT))
            {
                OnControl(Constant.CONTROL_PAGELEFT, false, true);
                ignoreups.Add(Constant.CONTROL_PAGELEFT);
            }
            else if (TheInput.IsControlPressed(Constant.CONTROL_PAGERIGHT))
            {
                OnControl(Constant.CONTROL_PAGERIGHT, false, true);
                ignoreups.Add(Constant.CONTROL_PAGERIGHT);
            }
        }
        
        // Scroll repeat
        if (!(TheInput.IsControlPressed(Constant.CONTROL_SCROLLBACK) ||
              TheInput.IsControlPressed(Constant.CONTROL_SCROLLFWD)))
        {
            scroll_repeat_time = -1;
        }
        else if (scroll_repeat_time > dt) scroll_repeat_time -= dt;
        else if (TheInput.IsControlPressed(Constant.CONTROL_SCROLLBACK))
        {
            float local_repeat_time = TheInput.GetControlIsMouseWheel(Constant.CONTROL_SCROLLBACK)
                ? MOUSE_SCROLL_REPEAT_TIME
                : SCROLL_REPEAT_TIME;
            if (scroll_repeat_time < 0)
            {
                scroll_repeat_time = local_repeat_time > dt ? local_repeat_time - dt : 0;
            }
            else
            {
                scroll_repeat_time = local_repeat_time;
                OnControl(Constant.CONTROL_SCROLLBACK, true);
            }
        }
        else if (TheInput.IsControlPressed(Constant.CONTROL_SCROLLFWD))
        {
            float local_repeat_time = TheInput.GetControlIsMouseWheel(Constant.CONTROL_SCROLLFWD)
                ? MOUSE_SCROLL_REPEAT_TIME
                : SCROLL_REPEAT_TIME;
            if (scroll_repeat_time < 0)
            {
                scroll_repeat_time = local_repeat_time > dt ? local_repeat_time - dt : 0;
            }
            else
            {
                scroll_repeat_time = local_repeat_time;
                OnControl(Constant.CONTROL_SCROLLFWD, true);
            }
        }

        if (repeat_time < 0)
        {
            repeat_time = REPEAT_TIME;
            if (TheInput.IsControlPressed(Constant.CONTROL_MOVE_LEFT)
                || TheInput.IsControlPressed(Constant.CONTROL_FOCUS_LEFT))
            {
                OnFocusMove(Constant.MOVE_LEFT, true);
            }
            else if (TheInput.IsControlPressed(Constant.CONTROL_MOVE_RIGHT)
                || TheInput.IsControlPressed(Constant.CONTROL_FOCUS_RIGHT))
            {
                OnFocusMove(Constant.MOVE_RIGHT, true);
            }
            else if (TheInput.IsControlPressed(Constant.CONTROL_MOVE_UP)
                || TheInput.IsControlPressed(Constant.CONTROL_FOCUS_UP))
            {
                OnFocusMove(Constant.MOVE_UP, true);
            }
            else if (TheInput.IsControlPressed(Constant.CONTROL_MOVE_DOWN)
                     || TheInput.IsControlPressed(Constant.CONTROL_FOCUS_DOWN))
            {
                OnFocusMove(Constant.MOVE_DOWN, true);
            }
            else repeat_time = 0;
        }

        if (tracking_mouse && !focus_locked)
        {
            List<GameObject> entitiesUnderMouse = TheInput.GetAllEntitiesUnderMouse();
            if (entitiesUnderMouse.Count > 0 && entitiesUnderMouse[0].GetComponent<Widget>() != null)
            {
                entitiesUnderMouse[0].GetComponent<Widget>().SetFocus();
            }
            else
            {
                if (screenstack.Count > 0) screenstack[^1].SetFocus();
            }
        }

        if (updating_widgets_alt == null) updating_widgets_alt = new List<Widget>();
        
        foreach (Widget updatingWidget in updating_widgets) updating_widgets_alt.Add(updatingWidget);
        
        foreach (Widget updatingWidgetAlt in updating_widgets_alt)
        {
            if (updatingWidgetAlt.enabled)
            {
                typeof(Widget).GetMethod("OnUpdate").Invoke(updatingWidgetAlt, new object[]{dt});
            }
        }
        updating_widgets_alt.Clear();
        
        helptext.Hide();
        if (TheInput.ControllerAttached())
        {
            string str = GetHelpText();
            if (!string.IsNullOrWhiteSpace(str))
            {
                helptext.Show();
                helptexttext.SetString(str);
            }
        }
    }

    public void StartUpdatingWidget(Widget w)
    {
        updating_widgets.Add(w);
    }

    public void StopUpdatingWidget(Widget w)
    {
        updating_widgets.Remove(w);
    }

    
    public void PushScreen(Screen screen, bool forceOverBugScreen = false)
    {
        focus_locked = false;
        
        // jcheng: don't allow any other screens to push if we're displaying an error
        // kaj: unless it's the bugreporter, then they're forced
        if (!Main.TheFrontEnd.IsDisplayingError() || forceOverBugScreen)
        {
            MainFunctions.Print(Constant.VERBOSITY.DEBUG, "FrontEnd:PushScreen", screen.name);
            
            screen.transform.SetParent(screenroot, false);
            screenstack.Add(screen);
            
            UpdateInternal(0);
        }
    }
    
    public void ClearScreens()
    {
        while (screenstack.Count > 0)
        {
            Screen screen = screenstack[^1];
            Destroy(screen.gameObject);
            screenstack.Remove(screen);
        }
    }

    public void ShowConsoleLog()
    {
        consoletext.Show();
    }

    public void HideConsoleLog()
    {
        consoletext.Hide();
    }

    public void DoFadeIn(float time_to_take)
    {
        Fade(true, time_to_take);
    }

    public void Fade(bool in_or_out, float time_to_take,
        Action cb = null, float? fade_delay_time = null, Action delayovercb = null)
    {
        fadedir = in_or_out;
        total_fade_time = time_to_take;
        fadecb = cb;
        fade_time = 0;
        if (in_or_out) SetFadeLevel(1);
        else
        {
            // starting a fade out, make the top fade visible again
            // this place it can actually be out of sync with the backfade, so make it full trans
            topblackoverlay.SetTint(0, 0, 0, 0);
            ShowTopFade();
        }
        this.fade_delay_time = fade_delay_time;
        this.delayovercb = delayovercb;
    }

    public void PopScreen(Screen screen = null)
    {
        Screen oldHead = screenstack.Count > 0 ? screenstack[^1] : null;
        if (screen != null)
        {
            MainFunctions.Print(Constant.VERBOSITY.DEBUG, "FrontEnd:PopScreen", screen.name);
            for (int i = 0; i < screenstack.Count; i++)
            {
                Screen v = screenstack[i];
                if (v == screen)
                {
                    if (oldHead == screen) screen.OnBecomeInactive();
                    screenstack.Remove(screen);
                    screen.OnDestroy();
                    screen.transform.parent = null;
                    break;
                }
            }
        }
        else
        {
            MainFunctions.Print(Constant.VERBOSITY.DEBUG, "FrontEnd:PopScreen");
            if (screenstack.Count > 0)
            {
                screen = screenstack[^1];
                screenstack.RemoveAt(screenstack.Count - 1);
                screen.OnBecomeInactive();
                screen.OnDestroy();
                screen.transform.parent = null;
            }
        }

        if (screenstack.Count > 0 && oldHead != screenstack[^1])
        {
            screenstack[^1].OnBecomeActive();

            UpdateInternal(0);
        }
    }

    public Screen GetActiveScreen()
    {
        if (screenstack.Count > 0 && screenstack[^1]) return screenstack[^1];
        else return null;
    }

    public void ShowScreen(Screen screen)
    {
        ClearScreens();
        if (screen) PushScreen(screen);
    }

    public void OnRawKey(object key, object down)
    {
        Screen screen = GetActiveScreen();
        if (screen != null)
        {
            if (!screen.OnRawKey(key, down)){}
        }
    }

    public void OnTextInput(string text)
    {
        Screen screen = GetActiveScreen();
        if (screen != null) screen.OnTextInput(text);
    }

    public void DisplayError(Screen screen)
    {
        if (displayingerror == false)
        {
            DebugPrint.print("SCRIPT ERROR! Showing error screen");
            
            ShowScreen(screen);
            overlayroot.Hide();
            consoletext.Hide();
            blackoverlay.Hide();
            title.Hide();
            subtitle.Hide();

            displayingerror = true;
        }
    }

    public bool IsDisplayingError()
    {
        return displayingerror;
    }
}