using Linearstar.Windows.RawInput;
using Linearstar.Windows.RawInput.Native;
using System;

namespace FullApp.Core.SystemEventsArgs
{
    public class KeyboardEventArgs : EventArgs
    {
        public KeyboardEventArgs(string text, RawInputDeviceHandle deviceHandle, RawInputDevice rawInputDevice)
        {
            Text = text;
            TextLength = text.Length;
            DeviceHandle = deviceHandle;
            RawInputDevice = rawInputDevice;
        }

        public string Text { get; }
        public int TextLength { get; }
        public RawInputDeviceHandle DeviceHandle { get; }
        public RawInputDevice RawInputDevice { get; }
    }
}
