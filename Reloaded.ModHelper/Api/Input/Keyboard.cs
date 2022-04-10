using System;
using System.Collections.Generic;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Gets information from and interacts with the physical computer keyboard.
    /// </summary>
    public static class Keyboard
    {
        private static HashSet<Key> pressedKeys = new HashSet<Key>();
        private static HashSet<Key> releasedKeys = new HashSet<Key>();

        /// <summary>
        /// The 
        /// </summary>
        const UInt32 WM_KEYDOWN = 0x0100;

        static Keyboard()
        {

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

        /// <summary>
        /// Returns whether or not a <see cref="Key"/> was pressed on this frame.
        /// <br/>Must be used in a GameLoop to work properly. Does not count if the key is being held.
        /// </summary>
        /// <param name="keyToCheck"></param>
        /// <returns></returns>
        public static bool IsPressed(Key keyToCheck)
        {
            if (!keyToCheck.IsPressed())
            {
                
            }
            else if (pressedKeys.Contains(keyToCheck)) // it's being held
            {
                return false;
            }

            pressedKeys.Add(keyToCheck);
            return true;
        }

        /// <summary>
        /// Returns whether or not a <see cref="Key"/> is currently being held down.
        /// <br/>Must be used in a GameLoop to work properly.
        /// </summary>
        /// <param name="keyToCheck"></param>
        /// <returns></returns>
        public static bool IsHeld(Key keyToCheck)
        {
            if (keyToCheck.IsPressed())
                return true;

            if (pressedKeys.Contains(keyToCheck))
                releasedKeys.Add(keyToCheck);

            return false;
        }

        /// <summary>
        /// Returns whether or not a <see cref="Key"/> was released on this frame.
        /// <br/>Must be used in a GameLoop to work properly.
        /// </summary>
        /// <param name="keyToCheck"></param>
        /// <returns></returns>
        public static bool IsReleased(Key keyToCheck)
        {
            if (!releasedKeys.Contains(keyToCheck))
                return false;

            releasedKeys.Remove(keyToCheck);
            pressedKeys.Remove(keyToCheck);

            return true;
        }
    }
}
