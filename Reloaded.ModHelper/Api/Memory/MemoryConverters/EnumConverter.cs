using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A converter used to get/set enums in memory.
    /// </summary>
    public unsafe class EnumConverter : IMemoryConverter
    {
        IMemoryManager manager;

        /// <summary>
        /// Creates this object with a memory manager.
        /// </summary>
        /// <param name="manager"></param>
        public EnumConverter(IMemoryManager manager)
        {
            if (manager == null)
                throw new NullReferenceException($"Can't create {nameof(EnumConverter)} because the provided" +
                    $" {nameof(MemoryManager)} was null!");

            this.manager = manager;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="typeToCheck"></param>
        /// <returns></returns>
        public bool CanConvert(Type typeToCheck)
        {
            if (typeToCheck == null)
            {
                ConsoleUtil.LogError($"{nameof(EnumConverter)}: Unable to check if type is convertable because it is null");
                return false;
            }

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
        public object GetValue(long address, Type enumType)
        {
            if (address <= 0)
            {
                ConsoleUtil.LogError($"{nameof(EnumConverter)}: Can't get enum value because address was {address} and is not valid");
                return null;
            }
            if (enumType == null)
            {
                ConsoleUtil.LogError($"{nameof(EnumConverter)}: Can't get enum value because provided type is null");
                return null;
            }

            var underlyingType = Enum.GetUnderlyingType(enumType); // this is the datatype, ex: int, uint, etc
            var enumId = manager.GetValue(address, underlyingType);

            foreach (var enumValue in Enum.GetValues(enumType))
            {
                var enumAsUnderlyingType = Convert.ChangeType(enumValue, underlyingType);
                if (enumAsUnderlyingType.Equals(enumId))
                {
                    return enumValue;
                }
            }

            return null;
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
            if (address <= 0)
            {
                ConsoleUtil.LogError($"{nameof(EnumConverter)}: Can't set enum value because address was {address} and is not valid");
                return;
            }
            if (valueToSet == null)
            {
                ConsoleUtil.LogError($"{nameof(EnumConverter)}: Can't set enum value. Provided object is null");
                return;
            }

            int enumId = (int)valueToSet;
            *(int*)(address) = enumId;
        }
    }
}
