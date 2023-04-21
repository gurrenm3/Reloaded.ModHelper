namespace Reloaded.ModHelper
{
    /// <summary>
    /// Extension Methods for <see cref="int"/>
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Returns this value in Hex format.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string ToHex(this int instance)
        {
            return instance.ToString("x");
        }
    }
}
