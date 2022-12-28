using FullApp.Core.SystemEventsArgs;
using FullApp.SharedServices.KeyloggerServices;
using FullApp.SharedServices.Interface;
using Linearstar.Windows.RawInput;
using Linearstar.Windows.RawInput.Native;
using System;

namespace FullApp.SharedServices
{
    public class KeyloggerService : IKeyloggerService
    {
        public event EventHandler NewKeyboardEvent;

        public void KeyboardRegisteredAndHook(nint hwnd)
        {
            InputDevices.KeyboardRegisteredAndHook(hwnd);
            KeyboardHook.KeyboardEvent += KeyboardHook_KeyboardEvent;
        }

        private void KeyboardHook_KeyboardEvent(string text, RawInputDeviceHandle handle, RawInputDevice inputDevice)
        {
            OnNewKeyboardEvent(new KeyboardEventArgs(text, handle, inputDevice));
        }

        public void KeyboardUnregistered()
        {
            KeyboardHook.KeyboardEvent -= KeyboardHook_KeyboardEvent;
            InputDevices.KeyboardUnregistered();
        }

        protected virtual void OnNewKeyboardEvent(KeyboardEventArgs e)
        {
            NewKeyboardEvent?.Invoke(this, e);
        }
    }
}