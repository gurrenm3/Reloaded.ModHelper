namespace Reloaded.ModHelper
{
	/// <summary>
	/// Extension methods for <see cref="Key"/>.
	/// </summary>
	public static class KeyCodeExtensions
	{
		/// <summary>
		/// Returns true while the user holds down this key.
		/// </summary>
		/// <param name="key">The key to check for.</param>
		/// <returns>If the Key is down, it will return true. Otherwise it return false</returns>
		/// <remarks>The summary for this method was based off of Unity Documentation</remarks>
		public static bool IsPressed(this Key key)
		{
			var state = User32.GetKeyState(key);
			return state < 0; // bool isHeld = state < 0;
		}
    }
}