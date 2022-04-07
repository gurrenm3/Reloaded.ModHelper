using System;
using System.Diagnostics;

namespace Reloaded.ModHelper
{
    public static class Keyboard
    {
        /// <summary>
        /// The 
        /// </summary>
        const UInt32 WM_KEYDOWN = 0x0100;



        static Keyboard()
        {

        }

        /// <summary>
        /// Returns true while the Keyboard button associated with <paramref name="keyToCheck"/> is pressed.
        /// <br/><br/>NOTE: Best if used in an Update method.
        /// </summary>
        /// <param name="keyToCheck"></param>
        /// <returns>True if the key is currently pressed, otherwise false.</returns>
        public static bool IsPressed(Key keyToCheck)
        {
            return keyToCheck.IsPressed();
        }

        /// <summary>
        /// TODO: Once implemented will simulate a keypress to the program.
        /// </summary>
        /// <param name="keyToSimulate"></param>
        public static void SimulatePress(Key keyToSimulate)
        {
            throw new NotImplementedException();
            //User32.PostMessage(Process.GetCurrentProcess().MainWindowHandle, )
        }
    }
}
