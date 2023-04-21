using System;
using System.Runtime.InteropServices;
using System.Text;

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
        public static long GetPointer(this string str)
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

        /// <summary>
        /// Returns a new string in reverse order.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static unsafe string ReverseString(this string str)
        {
            var temp = stackalloc char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                temp[i] = str[str.Length - i - 1];
            }

            return new string(temp);
        }

        /// <summary>
        /// Convert this string to it's Hexadecimal equivelant.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="add0x">Should 0x be added to the beginning of each byte? Ex: 0x8</param>
        /// <param name="separateBySpace">Should each byte be separated by a space?</param>
        /// <returns></returns>
        public static string ToHex(this string input, bool add0x = false, bool separateBySpace = false)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
                if (add0x)
                    sb.Append("0x");

                sb.AppendFormat("{0:x}", (int)c);

                if (separateBySpace)
                    sb.Append(" ");
            }
            return sb.ToString().Trim();
        }
    }
}
