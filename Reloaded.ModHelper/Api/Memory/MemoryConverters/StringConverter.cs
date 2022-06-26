using System;
using System.Runtime.InteropServices;

namespace Reloaded.ModHelper.Api
{
    /// <summary>
    /// Used to convert strings and char*.
    /// </summary>
    public unsafe class StringConverter : IMemoryConverter
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="typeToCheck"></param>
        /// <returns></returns>
        public bool CanConvert(Type typeToCheck)
        {
            return typeToCheck == typeof(string) || typeToCheck == typeof(char*);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool CanConvert<T>()
        {
            return CanConvert(typeof(T));
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="valueType"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public object GetValue(Type valueType, long address)
        {
            return Strings.ToString(address);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <returns></returns>
        public T GetValue<T>(long address)
        {
            return (T)GetValue(typeof(T), address);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="address"></param>
        /// <param name="valueToSet"></param>
        public void SetValue(long address, object valueToSet)
        {
            long valueAddress = (long)Marshal.StringToHGlobalAnsi(valueToSet.ToString());
            *(char*)address = *(char*)valueAddress;
        }
    }
}
