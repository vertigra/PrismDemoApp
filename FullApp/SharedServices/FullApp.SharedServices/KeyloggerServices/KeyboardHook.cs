using Linearstar.Windows.RawInput;
using Linearstar.Windows.RawInput.Native;
using System;
using System.Text;
using System.Windows.Input;
using static FullApp.SharedServices.KeyloggerServices.KeyExtension;

namespace FullApp.SharedServices.KeyloggerServices
{
    internal class KeyboardHook
    {
        internal delegate void KeyboardEventHandler(string text, RawInputDeviceHandle handle, RawInputDevice inputDevice);
        internal static event KeyboardEventHandler KeyboardEvent;

        private static readonly StringBuilder sb = new();
        private static readonly KeyConverter kc = new();
        private const int cWmInput = 0x00FF;

        internal static IntPtr Create(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
        {
            if (msg != cWmInput)
                return IntPtr.Zero;

            RawInputData data = RawInputData.FromHandle(lparam);
            RawInputDeviceHandle sourceDeviceHandle = data.Header.DeviceHandle;
            RawInputDevice sourceDevice = data.Device;

            // is example how get data only from one keyboard
            // if (sourceDevice.ProductId != 21587)
            // return IntPtr.Zero;
            switch (data)
            {
                case RawInputKeyboardData keyboard:

                    if (keyboard.Keyboard.Flags.HasFlag(RawKeyboardFlags.Up))
                    {
                        VirtualKeys keys = (VirtualKeys)keyboard.Keyboard.VirutalKey;
                        Key key = keys.ToVirtualKey();

                        if (key == Key.None)
                        {
                            // skip characters that are not converted to VirtualKey
                            // (only numbers and enter are converted)
                        }

                        if (key == Key.Enter)
                        {
                            string text = sb.ToString();
                            KeyboardEvent?.Invoke(text, sourceDeviceHandle, sourceDevice);
                            sb.Clear();
                        }
                        else
                        {
                            sb.Append(kc.ConvertToString(key));
                        }
                    }

                    break;
            }


            return IntPtr.Zero;
        }
    }
}
