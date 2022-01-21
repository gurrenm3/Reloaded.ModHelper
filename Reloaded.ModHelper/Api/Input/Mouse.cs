using System;
using System.Drawing;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// 
    /// </summary>
    public class Mouse
    {
        /// <summary>
        /// Get the position of the cursor in screen coordinates
        /// </summary>
        /// <returns></returns>
        public static Vector2 GetPosition()
        {
            User32.GetCursorPos(out System.Drawing.Point position);
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
		/// Returns true while the mouse button associated with <paramref name="mouseButton"/> is pressed.
        /// <br/><br/>NOTE: Best if used in an Update method.
		/// </summary>
		/// <param name="mouseButton">The Mouse Button to check for.</param>
		/// <returns></returns>
        public static bool IsPressed(MouseButton mouseButton)
        {
            return mouseButton.IsPressed();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="buttonToSimulate"></param>
        public static void SimulatePress(MouseButton buttonToSimulate)
        {
            throw new NotImplementedException();
        }
    }
}
