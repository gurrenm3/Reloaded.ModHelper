using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// DLL Imports from Window's api for User32.dll
    /// </summary>
    public static class User32
    {
        /// <summary>
        /// Places (posts) a message in the message queue associated with the thread that created the specified window and returns without waiting for the thread to process the message.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose window procedure is to receive the message.</param>
        /// <param name="Msg">The message to be posted.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// <br/><br/>If the function fails, the return value is zero.To get extended error information, call <see cref="Kernel32.GetLastError"/>. GetLastError returns ERROR_NOT_ENOUGH_QUOTA when the limit is hit.</returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-postmessagea </remarks>
        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        /// <summary>
        /// Retrieves a handle to the foreground window (the window with which the user is currently working). The system assigns a slightly higher priority to the thread that creates the foreground window than it does to other threads.
        /// </summary>
        /// <returns>The return value is a handle to the foreground window. The foreground window can be NULL in certain circumstances, such as when a window is losing activation.</returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getforegroundwindow </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// Retrieves the status of the specified virtual key. The status specifies whether the key is up, down, or toggled (on, off—alternating each time the key is pressed).
        /// </summary>
        /// <param name="keyCode">A virtual key. If the desired virtual key is a letter or digit (A through Z, a through z, or 0 through 9), nVirtKey must be set to the ASCII value of that character. For other keys, it must be a virtual-key code.</param>
        /// <returns>The return value specifies the status of the specified virtual key, as follows: <br/> If the high-order bit is 1, the key is down; otherwise, it is up.<br/>If the low-order bit is 1, the key is toggled.A key, such as the CAPS LOCK key, is toggled if it is turned on.The key is off and untoggled if the low-order bit is 0. A toggle key's indicator light (if any) on the keyboard will be on when the key is toggled, and off when the key is untoggled.</returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getkeystate </remarks>
        [DllImport("user32.dll")]
        public static extern short GetKeyState(Key keyCode);

        /// <summary>
        /// Retrieves the status of the specified virtual key. The status specifies whether the key is up, down, or toggled (on, off—alternating each time the key is pressed).
        /// </summary>
        /// <param name="mouseButton">A virtual key. If the desired virtual key is a letter or digit (A through Z, a through z, or 0 through 9), nVirtKey must be set to the ASCII value of that character. For other keys, it must be a virtual-key code.</param>
        /// <returns>The return value specifies the status of the specified virtual key, as follows: <br/> If the high-order bit is 1, the key is down; otherwise, it is up.<br/>If the low-order bit is 1, the key is toggled.A key, such as the CAPS LOCK key, is toggled if it is turned on.The key is off and untoggled if the low-order bit is 0. A toggle key's indicator light (if any) on the keyboard will be on when the key is toggled, and off when the key is untoggled.</returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getkeystate </remarks>
        [DllImport("user32.dll")]
        public static extern short GetKeyState(MouseButton mouseButton);

        /// <summary>
        /// Retrieves the position of the mouse cursor, in screen coordinates.
        /// </summary>
        /// <param name="lpPoint">A pointer to a POINT structure that receives the screen coordinates of the cursor.</param>
        /// <returns>Returns nonzero if successful or zero otherwise. To get extended error information, call <see cref="Kernel32.GetLastError"/></returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getcursorpos </remarks>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out Point lpPoint);

        /// <summary>
        /// Retrieves a handle to the top-level window whose class name and window name match the specified strings. This function does not search child windows. This function does not perform a case-sensitive search.
        /// </summary>
        /// <param name="lpClassName">The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of lpClassName; the high-order word must be zero.
        /// <br/>If lpClassName points to a string, it specifies the window class name. The class name can be any name registered with RegisterClass or RegisterClassEx, or any of the predefined control-class names.
        /// <br/>If lpClassName is NULL, it finds any window whose title matches the lpWindowName parameter.</param>
        /// <param name="lpWindowName">The window name (the window's title). If this parameter is NULL, all window names match.</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has the specified class name and window name. 
        /// <br/>If the function fails, the return value is NULL.To get extended error information, call <see cref="Kernel32.GetLastError"/></returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-findwindowa </remarks>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified window. The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
        /// </summary>
        /// <param name="hwnd">A handle to the window.</param>
        /// <param name="lpRect">A pointer to a <see cref="Rectangle"/> structure that receives the screen coordinates of the upper-left and lower-right corners of the window.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// <br/>If the function fails, the return value is zero.To get extended error information, call <see cref="Kernel32.GetLastError"/></returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowrect </remarks>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out Rectangle lpRect);

        /// <summary>
        /// Retrieves a handle to the desktop window. The desktop window covers the entire screen. The desktop window is the area on top of which other windows are painted.
        /// </summary>
        /// <returns>The return value is a handle to the desktop window.</returns>
        /// <remarks>Documentation: https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdesktopwindow </remarks>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();
    }
}
