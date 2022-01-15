using System.Drawing;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Class for managing user input, like key and mouse press
    /// </summary>
    public class Input
    {
        /// <summary>
        /// Default constructor for Input class
        /// </summary>
        public Input()
        {

        }

        /// <summary>
		/// Returns true while the user holds down the key identified by the <paramref name="key"/> KeyCode enum parameter.
		/// </summary>
		/// <param name="key">The key to check for</param>
		/// <returns></returns>
		/// <remarks>The summary for this method was taken from Unity Documentation</remarks>
        public static bool IsPressed(KeyCode key)
        {
            return key.IsPressed();
        }


        /// <summary>
		/// Returns true while the user holds down the Mouse Button identified by the <paramref name="mouseButton"/> Mouse enum parameter.
		/// </summary>
		/// <param name="mouseButton">The Mouse Button to check for</param>
		/// <returns></returns>
		/// <remarks>The summary for this method is based off of Unity Documentation</remarks>
        public static bool IsPressed(MouseButton mouseButton)
        {
            return mouseButton.IsPressed();
        }

        /// <summary>
        /// Get the position of the cursor in screen coordinates
        /// </summary>
        /// <returns></returns>
        public static Vector2 GetMousePos()
        {
            User32.GetCursorPos(out Point position);
            return new Vector2(position);
        }
    }
}
