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
        public static Vector2f GetPosition()
        {
            User32.GetCursorPos(out Point position);
            return new Vector2f(position);
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
        public static void SetPosition(Vector2f position)
        {
            SetPosition(position.x, position.y);
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
        /// <br/>Must be used in a GameLoop to work properly. Does not count if the button is being held.
        /// </summary>
        /// <param name="buttonToCheck"></param>
        /// <returns></returns>
        public static bool IsPressed(MouseButton buttonToCheck)
        {
            if (!buttonToCheck.IsPressed())
            {
                if (pressedButtons.Contains(buttonToCheck)) // It was pressed earlier. Now it's released.
                    OnButtonReleased(buttonToCheck);

                return false;
            }
            else if (pressedButtons.Contains(buttonToCheck)) // it's being held
            {
                OnButtonHeld(buttonToCheck);
                return false;
            }

            OnButtonPressed(buttonToCheck);
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
            {
                OnButtonHeld(buttonToCheck);
                return true;
            }

            if (pressedButtons.Contains(buttonToCheck)) // it was held before
                OnButtonReleased(buttonToCheck);

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
            if (IsHeld(buttonToCheck)) // it's being held
                return false;

            if (!releasedButtons.Contains(buttonToCheck)) // it wasn't released
                return false;

            OnButtonReleased(buttonToCheck);
            releasedButtons.Remove(buttonToCheck);

            return true;
        }

        private static void OnButtonPressed(MouseButton button)
        {
            if (!pressedButtons.Contains(button))
                pressedButtons.Add(button);

            releasedButtons.Remove(button);
        }

        private static void OnButtonHeld(MouseButton button)
        {
            if (!pressedButtons.Contains(button))
                pressedButtons.Add(button);

            releasedButtons.Remove(button);
        }

        private static void OnButtonReleased(MouseButton button)
        {
            releasedButtons.Add(button);
            pressedButtons.Remove(button);
        }
    }
}
