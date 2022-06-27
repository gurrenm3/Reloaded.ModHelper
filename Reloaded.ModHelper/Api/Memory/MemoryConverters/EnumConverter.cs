﻿using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A converter used to get/set enums in memory.
    /// </summary>
    public unsafe class EnumConverter : IMemoryConverter
    {
        IMemoryManager manager;

        public EnumConverter(IMemoryManager manager)
        {
            this.manager = manager;
        }

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
            var underlyingType = Enum.GetUnderlyingType(enumType); // this is the datatype, ex: int, uint, etc
            var enumId = manager.GetValue(underlyingType, address);

            foreach (var enumValue in Enum.GetValues(enumType))
            {
                var enumAsUnderlyingType = Convert.ChangeType(enumValue, underlyingType);
                if (enumAsUnderlyingType.Equals(enumId))
                {
                    return enumValue;
                }
            }

            return null;

            /*var values = Enum.GetValues(enumType);
            if (values == null)
                throw new Exception($"Failed to get values for the enum \"{enumType.Name}\"");

            int enumId = *(int*)(address);
            //var value = values.GetValue(enumId);
            var value = Convert.ChangeType(enumId, enumType);
            if (value == null)
                throw new Exception($"Failed to read value for the enum \"{enumType.Name}\"." +
                    $" Enum does not have any values with an ID of {enumId}");
            return value;*/
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
