using System;
using System.Collections.Generic;
using System.Drawing;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// 
    /// </summary>
    public class Mouse
    {
        private static HashSet<MouseButton> pressedButtons = new HashSet<MouseButton>();
        private static HashSet<MouseButton> releasedButtons = new HashSet<MouseButton>();

        /// <summary>
        /// Get the position of the cursor in screen coordinates
        /// </summary>
        /// <returns></returns>
        public static Vector2 GetPosition()
        {
            User32.GetCursorPos(out Point position);
            return new Vector2(position);
        }

        /// <summary>
        /// TODO
        /// </summary>
        public static void SetPosition(double x, double y)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="position"></param>
        public static void SetPosition(Vector2 position)
        {
            SetPosition(position.X, position.Y);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="position"></param>
        public static void SetPosition(Point position)
        {
            SetPosition(position.X, position.Y);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="amount"></param>
        public static void Scroll(int amount)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="buttonToSimulate"></param>
        public static void SimulatePress(MouseButton buttonToSimulate)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Returns whether or not a <see cref="MouseButton"/> was pressed on this frame.
        /// <br/>Must be used in a GameLoop to work properly. Does not count if the key is being held.
        /// </summary>
        /// <param name="buttonToCheck"></param>
        /// <returns></returns>
        public static bool IsPressed(MouseButton buttonToCheck)
        {
            if (!buttonToCheck.IsPressed() || pressedButtons.Contains(buttonToCheck))
                return false;

            pressedButtons.Add(buttonToCheck);
            return true;
        }

        /// <summary>
        /// Returns whether or not a <see cref="MouseButton"/> is currently being held down.
        /// <br/>Must be used in a GameLoop to work properly.
        /// </summary>
        /// <param name="buttonToCheck"></param>
        /// <returns></returns>
        public static bool IsHeld(MouseButton buttonToCheck)
        {
            if (buttonToCheck.IsPressed())
                return true;

            if (pressedButtons.Contains(buttonToCheck))
                releasedButtons.Add(buttonToCheck);

            return false;
        }

        /// <summary>
        /// Returns whether or not a <see cref="MouseButton"/> was released on this frame.
        /// <br/>Must be used in a GameLoop to work properly.
        /// </summary>
        /// <param name="buttonToCheck"></param>
        /// <returns></returns>
        public static bool IsReleased(MouseButton buttonToCheck)
        {
            if (!releasedButtons.Contains(buttonToCheck))
                return false;

            releasedButtons.Remove(buttonToCheck);
            pressedButtons.Remove(buttonToCheck);

            return true;
        }
    }
}
