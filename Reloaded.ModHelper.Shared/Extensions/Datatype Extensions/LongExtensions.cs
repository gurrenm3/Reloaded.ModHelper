namespace Reloaded.ModHelper
{
    /// <summary>
    /// Extension Methods for <see cref="long"/>
    /// </summary>
    public static class LongExtensions
    {
        /// <summary>
        /// Returns this value in Hex format.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string ToHex(this long instance)
        {
            return instance.ToString("X");
        }
    }
}
