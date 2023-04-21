using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Extension Methods for <see cref="decimal"/>
    /// </summary>
    public static class DecimalExtensions
    {
        /// <summary>
        /// Returns this value in Hex format.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string ToHex(this decimal instance)
        {
            return instance.ToString("x");
        }
    }
}
