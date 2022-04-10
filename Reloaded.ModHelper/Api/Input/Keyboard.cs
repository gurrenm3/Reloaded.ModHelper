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
                if (pressedKeys.Contains(keyToCheck)) // It was pressed earlier. Now it's released.
                    OnKeyReleased(keyToCheck);

                return false;
            }
            else if (pressedKeys.Contains(keyToCheck)) // it's being held
            {
                OnKeyHeld(keyToCheck);
                return false;
            }

            OnKeyPressed(keyToCheck);
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
            {
                OnKeyHeld(keyToCheck);
                return true;
            }

            if (pressedKeys.Contains(keyToCheck)) // it was held before
                OnKeyReleased(keyToCheck);

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
            if (IsHeld(keyToCheck))
                return false;

            if (!releasedKeys.Contains(keyToCheck)) // it wasn't released
                return false;

            OnKeyReleased(keyToCheck);
            releasedKeys.Remove(keyToCheck);

            return true;
        }

        private static void OnKeyPressed(Key key)
        {
            if (!pressedKeys.Contains(key))
                pressedKeys.Add(key);

            releasedKeys.Remove(key);
        }

        private static void OnKeyHeld(Key key)
        {
            if (!pressedKeys.Contains(key))
                pressedKeys.Add(key);

            releasedKeys.Remove(key);
        }

        private static void OnKeyReleased(Key key)
        {
            releasedKeys.Add(key);
            pressedKeys.Remove(key);
        }
    }
}
