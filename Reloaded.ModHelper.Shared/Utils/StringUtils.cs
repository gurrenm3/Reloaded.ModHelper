using System;
using System.Runtime.InteropServices;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Provides some utility methods for strings.
    /// </summary>
    public static unsafe class StringUtils
    {
        /// <summary>
        /// Returns whether or not the provided type is a string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsString<T>() => IsString(typeof(T));

        /// <summary>
        /// Returns whether or not the provided type is a string.
        /// </summary>
        /// <param name="typeToCheck"></param>
        /// <returns></returns>
        public static bool IsString(Type typeToCheck)
        {
            return typeToCheck == typeof(string) || typeToCheck == typeof(char*);
        }

        /// <summary>
        /// Returns the value held at the provided address.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static string GetValue(long address)
        {
            return ToString(address);
        }

        /// <summary>
        /// Sets the value at <paramref name="address"/> to <paramref name="valueToSet"/>.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="valueToSet"></param>
        public static void SetValue(long address, object valueToSet)
        {
            string value = valueToSet == null ? "" : valueToSet.ToString();
            long valueAddress = (long)Marshal.StringToHGlobalAnsi(value);

            *(char*)address = *(char*)valueAddress;
        }


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
                try
                {
                    var convertedString = Marshal.PtrToStringAnsi(address);
                    return convertedString;
                }
                catch (Exception ex)
                {

                }
            }
            return null;
        }
    }
}
