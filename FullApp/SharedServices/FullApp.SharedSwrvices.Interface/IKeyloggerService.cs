using System;

namespace FullApp.SharedServices.Interface
{
    public interface IKeyloggerService
    {
        void KeyboardUnregistered();
        void KeyboardRegisteredAndHook(nint hwnd);

        event EventHandler NewKeyboardEvent;
    }
}
