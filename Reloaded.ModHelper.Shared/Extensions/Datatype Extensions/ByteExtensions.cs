using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Extension Methods for <see cref="byte"/>
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        /// Returns this value in Hex format.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string ToHex(this byte instance)
        {
            return instance.ToString("X");
        }
    }
}
