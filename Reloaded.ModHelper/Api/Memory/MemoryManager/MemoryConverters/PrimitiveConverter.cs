using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A memory converter for converting primitive values or decimals
    /// </summary>
    public unsafe class PrimitiveConverter : IMemoryConverter
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
                ConsoleUtils.WriteError($"{nameof(PrimitiveConverter)}: Unable to check if type is convertable because it's null.");
                return false;
            }

            return PrimitiveUtils.IsPrimitive(typeToCheck);
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
            return PrimitiveUtils.GetValue(valueType, address);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <returns></returns>
        public T GetValue<T>(long address)
        {
            var value = GetValue(address, typeof(T));
            return value == null ? default(T) : (T)value;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="address"></param>
        /// <param name="valueToSet"></param>
        public void SetValue(long address, object valueToSet)
        {
            PrimitiveUtils.SetValue(address, valueToSet);
        }
    }
}
