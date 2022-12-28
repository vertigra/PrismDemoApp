using Linearstar.Windows.RawInput;
using System.Windows.Interop;

namespace FullApp.SharedServices.KeyloggerServices
{
    internal static class InputDevices
    {
        public static void KeyboardUnregistered()
        {
            RawInputDevice.UnregisterDevice(HidUsageAndPage.Keyboard);
        }

        private static void KeyboardRegistered(nint hwnd)
        {
            RawInputDevice.RegisterDevice(HidUsageAndPage.Keyboard, RawInputDeviceFlags.ExInputSink | RawInputDeviceFlags.NoLegacy, hwnd);
        }

        public static void KeyboardRegisteredAndHook(nint hwnd)
        {
            KeyboardRegistered(hwnd);
            HwndSource source = HwndSource.FromHwnd(hwnd);
            source.AddHook(KeyboardHook.Create);
        }

        public static RawInputDevice[] GetDevices { get; } = RawInputDevice.GetDevices();

        public static RawInputDeviceRegistration[] GetRegisteredDevices { get; } = RawInputDevice.GetRegisteredDevices();
    }
}
