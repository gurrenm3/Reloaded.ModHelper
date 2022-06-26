using System;

namespace Reloaded.ModHelper
{
    public unsafe class EnumConverter : IMemoryConverter
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="typeToCheck"></param>
        /// <returns></returns>
        public bool CanConvert(Type typeToCheck)
        {
            return typeToCheck.IsEnum;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool CanConvert<T>()
        {
            return typeof(T).IsEnum;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public object GetValue(Type enumType, long address)
        {
            var values = Enum.GetValues(enumType);
            if (values == null)
                throw new Exception($"Failed to get values for the enum \"{enumType.Name}\"");

            int enumId = *(int*)(address);
            var value = values.GetValue(enumId);
            if (value == null)
                throw new Exception($"Failed to read value for the enum \"{enumType.Name}\"." +
                    $" Enum does not have any values with an ID of {enumId}");
            return value;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <returns></returns>
        public T GetValue<T>(long address)
        {
            var value = GetValue(typeof(T), address);
            return value == null ? default(T) : (T)value;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="address"></param>
        /// <param name="valueToSet"></param>
        public void SetValue(long address, object valueToSet)
        {
            int enumId = (int)valueToSet;
            *(int*)(address) = enumId;
        }
    }
}
