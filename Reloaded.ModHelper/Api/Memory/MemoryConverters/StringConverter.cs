using System;
using System.Runtime.InteropServices;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Used to convert strings and char pointers.
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
            if (typeToCheck == null)
            {
                ConsoleUtil.LogError($"{nameof(StringConverter)}: Unable to check if type is convertable because it's null.");
                return false;
            }

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
        public object GetValue(long address, Type valueType)
        {
            if (address <= 0)
            {
                ConsoleUtil.LogError($"{nameof(StringConverter)}: Can't get string value because address" +
                    $" was {address} and is not valid");
                return null;
            }
            if (valueType == null)
            {
                ConsoleUtil.LogError($"{nameof(StringConverter)}: Can't get string value because the provided type is null!");
                return null;
            }

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
            return (T)GetValue(address, typeof(T));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="address"></param>
        /// <param name="valueToSet"></param>
        public void SetValue(long address, object valueToSet)
        {
            if (address <= 0)
            {
                ConsoleUtil.LogError($"{nameof(StringConverter)}: Can't set string value because address" +
                    $" was {address} and is not valid");
                return;
            }

            string value = valueToSet == null ? "" : valueToSet.ToString();
            long valueAddress = (long)Marshal.StringToHGlobalAnsi(value);
            *(char*)address = *(char*)valueAddress;
        }
    }
}
