using System;
using System.Runtime.InteropServices;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Extension methods for <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Can be used to get this string's address in memory.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long GetAddress(this string str)
        {
            return (long)Marshal.StringToHGlobalAnsi(str);
        }

        /// <summary>
        /// Performs the specified action on each character of this string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="codeToRun">The action to perform on each character in this string.</param>
        public static void ForEach(this string str, Action<char> codeToRun)
        {
            for (int i = 0; i < str.Length; i++)
            {
                codeToRun.Invoke(str[i]);
            }
        }
    }
}
