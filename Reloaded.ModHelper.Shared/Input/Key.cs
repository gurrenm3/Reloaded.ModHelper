namespace Reloaded.ModHelper
{
    // taken from https://github.com/dotnet/pinvoke/blob/master/src/User32/User32%2BVirtualKey.cs
    /// <summary>
    /// KeyCodes for User32 Key Press methods
    /// </summary>
    public enum Key : ushort
    {
        /// <Summary>
        /// Backspace Key
        /// </Summary>
        Back = 0x08,

        /// <Summary>
        /// Tab Key
        /// </Summary>
        Tab = 0x09,

        /// <Summary>
        /// Clear Key
        /// </Summary>
        Clear = 0x0c,

        /// <Summary>
        /// Return Key
        /// </Summary>
        Return = 0x0d,

        /// <Summary>
        /// Shift Key
        /// </Summary>
        Shift = 0x10,

        /// <Summary>
        /// Control Key
        /// </Summary>
        Control = 0x11,

        /// <Summary>
        /// Alt Key
        /// </Summary>
        Menu = 0x12,

        /// <Summary>
        /// Pause Key
        /// </Summary>
        Pause = 0x13,

        /// <Summary>
        /// Caps Lock Key
        /// </Summary>
        CapsLock = 0x14,

        /// <Summary>
        /// Esc Key
        /// </Summary>
        Escape = 0x1b,

        /// <Summary>
        /// Ime Accept
        /// </Summary>
        Accept = 0x1e,

        /// <Summary>
        /// Spacebar
        /// </Summary>
        Space = 0x20,

        /// <Summary>
        /// Page Up Key
        /// </Summary>
        PageUp = 0x21,

        /// <Summary>
        /// Page Down Key
        /// </Summary>
        PageDown = 0x22,

        /// <Summary>
        /// End Key
        /// </Summary>
        End = 0x23,

        /// <Summary>
        /// Home Key
        /// </Summary>
        Home = 0x24,

        /// <Summary>
        /// Left Arrow Key
        /// </Summary>
        LeftArrow = 0x25,

        /// <Summary>
        /// Up Arrow Key
        /// </Summary>
        UpArrow = 0x26,

        /// <Summary>
        /// Right Arrow Key
        /// </Summary>
        RightArrow = 0x27,

        /// <Summary>
        /// Down Arrow Key
        /// </Summary>
        DownArrow = 0x28,

        /// <Summary>
        /// Select Key
        /// </Summary>
        Select = 0x29,

        /// <Summary>
        /// Print Screen Key
        /// </Summary>
        PrintScreen = 0x2c,

        /// <Summary>
        /// Ins Key
        /// </Summary>
        Insert = 0x2d,

        /// <Summary>
        /// Del Key
        /// </Summary>
        Delete = 0x2e,

        /// <Summary>
        /// 0 Key
        /// </Summary>
        Key_0 = 0x30,

        /// <Summary>
        /// 1 Key
        /// </Summary>
        Key_1 = 0x31,

        /// <Summary>
        /// 2 Key
        /// </Summary>
        Key_2 = 0x32,

        /// <Summary>
        /// 3 Key
        /// </Summary>
        Key_3 = 0x33,

        /// <Summary>
        /// 4 Key
        /// </Summary>
        Key_4 = 0x34,

        /// <Summary>
        /// 5 Key
        /// </Summary>
        Key_5 = 0x35,

        /// <Summary>
        /// 6 Key
        /// </Summary>
        Key_6 = 0x36,

        /// <Summary>
        /// 7 Key
        /// </Summary>
        Key_7 = 0x37,

        /// <Summary>
        /// 8 Key
        /// </Summary>
        Key_8 = 0x38,

        /// <Summary>
        /// 9 Key
        /// </Summary>
        Key_9 = 0x39,

        /// <Summary>
        /// A Key
        /// </Summary>
        A = 0x41,

        /// <Summary>
        /// B Key
        /// </Summary>
        B = 0x42,

        /// <Summary>
        /// C Key
        /// </Summary>
        C = 0x43,

        /// <Summary>
        /// D Key
        /// </Summary>
        D = 0x44,

        /// <Summary>
        /// E Key
        /// </Summary>
        E = 0x45,

        /// <Summary>
        /// F Key
        /// </Summary>
        F = 0x46,

        /// <Summary>
        /// G Key
        /// </Summary>
        G = 0x47,

        /// <Summary>
        /// H Key
        /// </Summary>
        H = 0x48,

        /// <Summary>
        /// I Key
        /// </Summary>
        I = 0x49,

        /// <Summary>
        /// J Key
        /// </Summary>
        J = 0x4a,

        /// <Summary>
        /// K Key
        /// </Summary>
        K = 0x4b,

        /// <Summary>
        /// L Key
        /// </Summary>
        L = 0x4c,

        /// <Summary>
        /// M Key
        /// </Summary>
        M = 0x4d,

        /// <Summary>
        /// N Key
        /// </Summary>
        N = 0x4e,

        /// <Summary>
        /// O Key
        /// </Summary>
        O = 0x4f,

        /// <Summary>
        /// P Key
        /// </Summary>
        P = 0x50,

        /// <Summary>
        /// Q Key
        /// </Summary>
        Q = 0x51,

        /// <Summary>
        /// R Key
        /// </Summary>
        R = 0x52,

        /// <Summary>
        /// S Key
        /// </Summary>
        S = 0x53,

        /// <Summary>
        /// T Key
        /// </Summary>
        T = 0x54,

        /// <Summary>
        /// U Key
        /// </Summary>
        U = 0x55,

        /// <Summary>
        /// V Key
        /// </Summary>
        V = 0x56,

        /// <Summary>
        /// W Key
        /// </Summary>
        W = 0x57,

        /// <Summary>
        /// X Key
        /// </Summary>
        X = 0x58,

        /// <Summary>
        /// Y Key
        /// </Summary>
        Y = 0x59,

        /// <Summary>
        /// Z Key
        /// </Summary>
        Z = 0x5a,

        /// <Summary>
        /// Left Windows Key (Natural Keyboard)
        /// </Summary>
        LWindows = 0x5b,

        /// <Summary>
        /// Right Windows Key (Natural Keyboard)
        /// </Summary>
        RWindows = 0x5c,

        /// <Summary>
        /// Computer Sleep Key
        /// </Summary>
        Sleep = 0x5f,

        /// <Summary>
        /// Numeric Keypad 0 Key
        /// </Summary>
        Numpad0 = 0x60,

        /// <Summary>
        /// Numeric Keypad 1 Key
        /// </Summary>
        Numpad1 = 0x61,

        /// <Summary>
        /// Numeric Keypad 2 Key
        /// </Summary>
        Numpad2 = 0x62,

        /// <Summary>
        /// Numeric Keypad 3 Key
        /// </Summary>
        Numpad3 = 0x63,

        /// <Summary>
        /// Numeric Keypad 4 Key
        /// </Summary>
        Numpad4 = 0x64,

        /// <Summary>
        /// Numeric Keypad 5 Key
        /// </Summary>
        Numpad5 = 0x65,

        /// <Summary>
        /// Numeric Keypad 6 Key
        /// </Summary>
        Numpad6 = 0x66,

        /// <Summary>
        /// Numeric Keypad 7 Key
        /// </Summary>
        Numpad7 = 0x67,

        /// <Summary>
        /// Numeric Keypad 8 Key
        /// </Summary>
        Numpad8 = 0x68,

        /// <Summary>
        /// Numeric Keypad 9 Key
        /// </Summary>
        Numpad9 = 0x69,

        /// <Summary>
        /// Multiply Key
        /// </Summary>
        Multiply = 0x6a,

        /// <Summary>
        /// Add Key
        /// </Summary>
        Add = 0x6b,

        /// <Summary>
        /// Separator Key
        /// </Summary>
        Separator = 0x6c,

        /// <Summary>
        /// Subtract Key
        /// </Summary>
        Subtract = 0x6d,

        /// <Summary>
        /// Decimal Key
        /// </Summary>
        Decimal = 0x6e,

        /// <Summary>
        /// Divide Key
        /// </Summary>
        Divide = 0x6f,

        /// <Summary>
        /// F1 Key
        /// </Summary>
        F1 = 0x70,

        /// <Summary>
        /// F2 Key
        /// </Summary>
        F2 = 0x71,

        /// <Summary>
        /// F3 Key
        /// </Summary>
        F3 = 0x72,

        /// <Summary>
        /// F4 Key
        /// </Summary>
        F4 = 0x73,

        /// <Summary>
        /// F5 Key
        /// </Summary>
        F5 = 0x74,

        /// <Summary>
        /// F6 Key
        /// </Summary>
        F6 = 0x75,

        /// <Summary>
        /// F7 Key
        /// </Summary>
        F7 = 0x76,

        /// <Summary>
        /// F8 Key
        /// </Summary>
        F8 = 0x77,

        /// <Summary>
        /// F9 Key
        /// </Summary>
        F9 = 0x78,

        /// <Summary>
        /// F10 Key
        /// </Summary>
        F10 = 0x79,

        /// <Summary>
        /// F11 Key
        /// </Summary>
        F11 = 0x7a,

        /// <Summary>
        /// F12 Key
        /// </Summary>
        F12 = 0x7b,

        /// <Summary>
        /// F13 Key
        /// </Summary>
        F13 = 0x7c,

        /// <Summary>
        /// F14 Key
        /// </Summary>
        F14 = 0x7d,

        /// <Summary>
        /// F15 Key
        /// </Summary>
        F15 = 0x7e,

        /// <Summary>
        /// F16 Key
        /// </Summary>
        F16 = 0x7f,

        /// <Summary>
        /// F17 Key
        /// </Summary>
        F17 = 0x80,

        /// <Summary>
        /// F18 Key
        /// </Summary>
        F18 = 0x81,

        /// <Summary>
        /// F19 Key
        /// </Summary>
        F19 = 0x82,

        /// <Summary>
        /// F20 Key
        /// </Summary>
        F20 = 0x83,

        /// <Summary>
        /// F21 Key
        /// </Summary>
        F21 = 0x84,

        /// <Summary>
        /// F22 Key
        /// </Summary>
        F22 = 0x85,

        /// <Summary>
        /// F23 Key
        /// </Summary>
        F23 = 0x86,

        /// <Summary>
        /// F24 Key
        /// </Summary>
        F24 = 0x87,

        /// <Summary>
        /// Num Lock Key
        /// </Summary>
        Numlock = 0x90,

        /// <Summary>
        /// Scroll Lock Key
        /// </Summary>
        Scroll = 0x91,

        /// <Summary>
        /// Left Shift Key
        /// </Summary>
        LShift = 0xa0,

        /// <Summary>
        /// Right Shift Key
        /// </Summary>
        RShift = 0xa1,

        /// <Summary>
        /// Left Control Key
        /// </Summary>
        LControl = 0xa2,

        /// <Summary>
        /// Right Control Key
        /// </Summary>
        RControl = 0xa3,

        /// <Summary>
        /// Left Menu Key
        /// </Summary>
        LMenu = 0xa4,

        /// <Summary>
        /// Right Menu Key
        /// </Summary>
        RMenu = 0xa5
    }
}
