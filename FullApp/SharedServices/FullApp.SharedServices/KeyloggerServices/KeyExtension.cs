using System.Windows.Input;

namespace FullApp.SharedServices.KeyloggerServices
{
    internal class KeyExtension
    {
        internal enum VirtualKeys
        {
            Enter = 13,
            D0 = 48,
            D1 = 49,
            D2 = 50,
            D3 = 51,
            D4 = 52,
            D5 = 53,
            D6 = 54,
            D7 = 55,
            D8 = 56,
            D9 = 57
        }
    }

    internal static class Extesion
    {
        public static Key ToVirtualKey(this KeyExtension.VirtualKeys keys)
        {
            return keys switch
            {
                KeyExtension.VirtualKeys.Enter => Key.Enter,
                KeyExtension.VirtualKeys.D0 => Key.D0,
                KeyExtension.VirtualKeys.D1 => Key.D1,
                KeyExtension.VirtualKeys.D2 => Key.D2,
                KeyExtension.VirtualKeys.D3 => Key.D3,
                KeyExtension.VirtualKeys.D4 => Key.D4,
                KeyExtension.VirtualKeys.D5 => Key.D5,
                KeyExtension.VirtualKeys.D6 => Key.D6,
                KeyExtension.VirtualKeys.D7 => Key.D7,
                KeyExtension.VirtualKeys.D8 => Key.D8,
                KeyExtension.VirtualKeys.D9 => Key.D9,
                _ => Key.None,
            };
        }
    }
}
