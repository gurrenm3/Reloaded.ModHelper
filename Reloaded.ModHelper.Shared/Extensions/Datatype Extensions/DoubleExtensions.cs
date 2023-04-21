using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Extension Methods for <see cref="double"/>
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Returns this value in Hex format.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string ToHex(this double instance)
        {
            return instance.ToString("x");
        }
    }
}
