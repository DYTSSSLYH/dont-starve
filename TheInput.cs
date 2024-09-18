using System;
using System.Collections.Generic;
using DYT;
using UnityEngine;
using UnityEngine.InputSystem;

public static class TheInput
{
    private static EventProcessor onkey = new EventProcessor(); //all keys, down and up, with key param
    private static EventProcessor onkeyup = new EventProcessor(); //specific key up, no parameters
    private static EventProcessor onkeydown = new EventProcessor(); //specific key down, no parameters
    private static EventProcessor onmouseup = new EventProcessor();
    private static EventProcessor onmousedown = new EventProcessor();
    private static EventProcessor position = new EventProcessor();
    private static EventProcessor oncontrol = new EventProcessor();
    private static EventProcessor ontextinput = new EventProcessor();
    private static EventProcessor ongesture = new EventProcessor();
    private static object hoverinst = null;
    private static bool enabledebugtoggle = true;
    private static bool mouse_enabled = true;
    private class PickCondition
    {
        public object condition;
        public object weight;

        public PickCondition(object condition, object weight)
        {
            this.condition = condition;
            this.weight = weight;
        }
    }
    private static Dictionary<string, PickCondition> pickConditions =
        new Dictionary<string, PickCondition>();

    private static List<GameObject> entitiesundermouse;
    
    private static bool IgnoreMinisign(GameObject ent)
    {
        return ent.CompareTag("sign");
    }
    private static bool PrioritizeMiniSign(GameObject ent)
    {
        // TODO
        return false;
    }
    public static void Init()
    {
        DisableAllControllers();
        
        AddPickCondition("fishinhole", ent => ent.name == "fishinhole", 2);
        AddPickCondition("notOnFloor", ent => ent.CompareTag("OnFloor"), 1);
        
        // The mouse now tries to ignore mini signs.
        // Solving the issue with mini signs and chests in the same place.
        AddPickCondition("IgnoreMinisign", IgnoreMinisign, -1);
        AddPickCondition("PrioritizeMiniSign", PrioritizeMiniSign, 2);
    }
    
    public static void DisableAllControllers()
    {
        for (int i = 0; i < TheInputProxy.GetInputDeviceCount() - 1; i++)
        {
            if (TheInputProxy.IsInputDeviceEnabled(i) && TheInputProxy.IsInputDeviceConnected(i))
            {
                TheInputProxy.EnableInputDevice(i, false);
            }
        }
    }
    
    public static void EnableAllControllers()
    {
        for (int i = 0; i < TheInputProxy.GetInputDeviceCount() - 1; i++)
        {
            if (TheInputProxy.IsInputDeviceConnected(i)) TheInputProxy.EnableInputDevice(i, true);
        }
    }
    
    public static bool ControllerAttached()
    {
        return false;
    }
    
    public static bool ControllerConnected()
    {
        if (Main.PLATFORM == "PS4") return true;
        else if (Main.PLATFORM == "NACL") return false;
        else
        {
            // need to take enabled into account
            for (int i = 0; i < TheInputProxy.GetInputDeviceCount(); i++)
            {
                if (i >= 0 && TheInputProxy.IsInputDeviceConnected(i)) return true;
            }
            return false;
        }
    }


    public static void AddTextInputHandler(Action<object[]> fn)
    {
        ontextinput.AddEventHandler("text", fn);
    }

    public static void AddKeyHandler(Action<object[]> fn)
    {
        onkey.AddEventHandler("onkey", fn);
    }

    public static void AddMoveHandler(Action<object[]> fn)
    {
        position.AddEventHandler("move", fn);
    }

    public static void AddControlHandler(string control, Action<object[]> fn)
    {
        onkey.AddEventHandler(control, fn);
    }

    public static List<GameObject> GetAllEntitiesUnderMouse()
    {
        if (mouse_enabled)
        {
            return entitiesundermouse == null ? new List<GameObject>() : entitiesundermouse;
        }
        return new List<GameObject>();
    }


    public static bool EnableDebugToggle(bool enable)
    {
        return enabledebugtoggle = enable;
    }

    public static bool IsControlPressed(int control)
    {
        return Keyboard.current[(Key)control].isPressed;
    }
    
    public static void AddPickCondition(string name, Func<GameObject, bool> condition, object weight)
    {
        pickConditions.Add(name, new PickCondition(condition, weight));
    }


    public static string GetLocalizedControl(int deviceId, int controlId,
        bool? use_default_mapping = null)
    {
        if (!use_default_mapping.HasValue) use_default_mapping = false;

        bool hasControl = TheInputProxy.GetLocalizedControl(deviceId, controlId, use_default_mapping.Value,
            out List<InputBinding> inputs);
        string text = "";
        if (!hasControl) text = STRINGS.UI.CONTROLSSCREEN.INPUTS[6][1];
        else
        {
            // concatenate the inputs
            for (int i = 0; i < inputs.Count; i++)
            {
                text += inputs[i].name;
                if (i < inputs.Count - 1) text += " + ";
            }
        }
        return text;
    }

    public static bool GetControlIsMouseWheel(int controlId)
    {
        if (ControllerAttached()) return false;
        string localized = GetLocalizedControl(0, controlId);
        List<string> stringtable = STRINGS.UI.CONTROLSSCREEN.INPUTS[1];
        return localized == stringtable[1003] || localized == stringtable[1004];
    }
}