using System;
using System.Runtime.InteropServices;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Utility methods for Strings
    /// </summary>
    public static unsafe class StringUtil
    {
        /// <summary>
        /// Attempt to convert a void pointer to a string. Will only work if the void pointer already represents a string
        /// </summary>
        /// <param name="pointer"></param>
        /// <returns></returns>
        public static string TryToString(void* pointer) => pointer != null ? TryToString((IntPtr)pointer) : null;

        /// <summary>
        /// Attempt to convert the value stored at an address to a string. Will only work if address already holds a string
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static string TryToString(long address) => TryToString((IntPtr)address);

        /// <summary>
        /// Attempt to convert an IntPtr to a string. Will only work if the IntPtr already holds a string
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static string TryToString(IntPtr address)
        {
            if (address != IntPtr.Zero)
            {
                var convertedString = Marshal.PtrToStringAnsi(address);
                return convertedString;
            }
            return null;
        }
    }
}
