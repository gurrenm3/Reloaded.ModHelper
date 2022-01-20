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
        public static Vector2 GetCursorPos()
        {
            User32.GetCursorPos(out System.Drawing.Point position);
            return new Vector2(position);
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
    }
}
