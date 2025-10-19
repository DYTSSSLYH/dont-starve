using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using XLua;

namespace DYT
{
    public class TheInputProxyBridge
    {
        // Snapshot of all devices in the system for stable index mapping between calls.
        private readonly List<InputDevice> _devices = new List<InputDevice>();

        public TheInputProxyBridge()
        {
            RebuildSnapshot();
            InputSystem.onDeviceChange += OnDeviceChange;
        }

        private void OnDeviceChange(InputDevice device, InputDeviceChange change)
        {
            // Any structural device change should trigger a rebuild (added, removed, reconnected, disconnected, enabled/disabled).
            switch (change)
            {
                case InputDeviceChange.Added:
                case InputDeviceChange.Removed:
                case InputDeviceChange.Disconnected:
                case InputDeviceChange.Reconnected:
                case InputDeviceChange.Enabled:
                case InputDeviceChange.Disabled:
                case InputDeviceChange.ConfigurationChanged:
                    RebuildSnapshot();
                    break;
            }
        }

        private void RebuildSnapshot()
        {
            _devices.Clear();
            ReadOnlyArray<InputDevice> all = InputSystem.devices; // ReadOnlyArray<InputDevice>
            foreach (InputDevice inputDevice in all)
            {
                _devices.Add(inputDevice);
            }
        }

        private bool TryGetDeviceByIndex(int index, out InputDevice device)
        {
            if (index < 0 || index >= _devices.Count)
            {
                device = null;
                return false;
            }
            device = _devices[index];
            return device != null;
        }

        // Enable/disable any device by index (including keyboard/mouse/gamepad/etc.)
        public void EnableInputDevice(int index, bool enable)
        {
            if (!TryGetDeviceByIndex(index, out var device)) return;

            if (enable)
            {
                if (!device.enabled)
                    InputSystem.EnableDevice(device);
            }
            else
            {
                if (device.enabled)
                    InputSystem.DisableDevice(device);
            }
        }

        public int GetInputDeviceCount()
        {
            return _devices.Count;
        }

        public bool IsInputDeviceEnabled(int index)
        {
            return TryGetDeviceByIndex(index, out var device) && device.enabled;
        }

        public bool IsInputDeviceConnected(int index)
        {
            // In the new Input System, "added" ~ present in system; disconnected devices are typically removed.
            return TryGetDeviceByIndex(index, out var device) && device.added;
        }
    }
}