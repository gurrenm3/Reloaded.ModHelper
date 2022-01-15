namespace Reloaded.ModHelper
{
    /// <summary>
    /// Contains information about the Computer Screen.
    /// </summary>
    public static class Screen
    {
        /// <summary>
        /// The Screen Dimensions of this computer.
        /// </summary>
        public static Rect screenDimensions;

        /// <summary>
        /// The position of the center of the screen.
        /// </summary>
        public static Vector2 centerScreen;

        
        static Screen()
        {
            User32.GetWindowRect(User32.GetDesktopWindow(), out screenDimensions);
            centerScreen = screenDimensions.Center;
        }
    }
}
