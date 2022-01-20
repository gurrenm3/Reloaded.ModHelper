using System;
using System.Runtime.InteropServices;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Utility methods for Strings
    /// </summary>
    public static unsafe class Strings
    {
        /// <summary>
        /// Attempt to convert a void pointer to a string. Will only work if the void pointer already represents a string
        /// </summary>
        /// <param name="pointer"></param>
        /// <returns>The string stored at the address if there is one, otherwise null.</returns>
        public static string ToString(void* pointer) => pointer != null ? ToString((IntPtr)pointer) : null;

        /// <summary>
        /// Attempt to convert the value stored at an address to a string. Will only work if address already holds a string
        /// </summary>
        /// <param name="address"></param>
        /// <returns>The string stored at the address if there is one, otherwise null.</returns>
        public static string ToString(long address) => ToString((IntPtr)address);

        /// <summary>
        /// Attempt to convert an IntPtr to a string. Will only work if the IntPtr already holds a string
        /// </summary>
        /// <param name="address"></param>
        /// <returns>The string stored at the address if there is one, otherwise null.</returns>
        public static string ToString(IntPtr address)
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
