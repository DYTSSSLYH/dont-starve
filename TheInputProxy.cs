using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public static class TheInputProxy
{
    private static readonly Player _player = new Player();
    

    public static void EnableInputDevice(int i, bool enable)
    {
        if (enable) InputSystem.EnableDevice(_player.devices.Value[i]);
        else InputSystem.DisableDevice(_player.devices.Value[i]);
    }

    public static bool GetLocalizedControl(int deviceId, int controlId, bool use_default_mapping,
        out List<InputBinding> inputs)
    {
        InputAction inputAction = _player.FindAction(controlId.ToString());
        
        InputDevice playerDevice = null;
        
        if (_player.devices.HasValue)
        {
            foreach (InputDevice tempDevice in _player.devices.Value)
            {
                if (tempDevice.deviceId == deviceId)
                {
                    playerDevice = tempDevice;
                    break;
                }
            }
        }

        if (playerDevice == null)
        {
            inputs = null;
            return false;
        }

        inputs = new List<InputBinding>();
        foreach (InputBinding binding in inputAction.bindings)
        {
            if (binding.name.Contains(playerDevice.name))
            {
                inputs.Add(binding);
            }
        }

        return true;
    }
    
    public static int GetInputDeviceCount()
    {
        return _player.devices.GetValueOrDefault(new ReadOnlyArray<InputDevice>()).Count;
    }
    
    public static bool IsInputDeviceEnabled(int i)
    {
        return _player.devices.Value[i].enabled;
    }
    
    public static bool IsInputDeviceConnected(int i)
    {
        return _player.devices.GetValueOrDefault(new ReadOnlyArray<InputDevice>())[i].added;
    }
    
    public static PlayerProfile.Control SaveControls(int i)
    {
        InputDevice inputDevice = _player.devices.Value[i];
        
        return new PlayerProfile.Control
        {
            guid = inputDevice.deviceId,
            data = inputDevice.ReadValueAsObject(),
            enabled = inputDevice.enabled,
        };
    }



    public static void FlushInput(){}
}