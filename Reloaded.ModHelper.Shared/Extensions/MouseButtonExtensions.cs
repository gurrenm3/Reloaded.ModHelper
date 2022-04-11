namespace Reloaded.ModHelper
{
	/// <summary>
	/// Extension methods for <see cref="MouseButton"/>.
	/// </summary>
	public static class MouseButtonExtensions
	{
		/// <summary>
		/// Returns true while the user holds down this button.
		/// </summary>
		/// <param name="mouseButton">The button to check for.</param>
		/// <returns></returns>
		/// <remarks>The summary for this method was based off of Unity Documentation</remarks>
		public static bool IsPressed(this MouseButton mouseButton)
		{
			var state = User32.GetKeyState(mouseButton);
			return state < 0; // bool isHeld = state < 0;
		}
    }
}