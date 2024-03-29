﻿using System;

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
                ConsoleUtils.WriteError($"{nameof(EnumConverter)}: Unable to check if type is convertable because it is null");
                return false;
            }

            return EnumUtils.IsEnum(typeToCheck);
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
            return EnumUtils.GetValue(enumType, address);

            /*var underlyingType = Enum.GetUnderlyingType(enumType); // this is the datatype, ex: int, uint, etc
            var enumId = manager.GetValue(address, underlyingType); // actual numeric enum value, ex: id = 32

            try
            {
                return Enum.ToObject(enumType, enumId);
            }
            catch (Exception)
            {
                ConsoleUtils.WriteError("Faield to get enum value");
                return null;
            }*/
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
            EnumUtils.SetValue(address, valueToSet);

            /*var enumType = valueToSet.GetType();
            var underlyingType = Enum.GetUnderlyingType(enumType);


            if (underlyingType == typeof(int))
            {
                int enumId = (int)valueToSet;
                *(int*)(address) = enumId;
            }
            else if (underlyingType == typeof(uint))
            {
                uint enumId = (uint)valueToSet;
                *(uint*)(address) = enumId;
            }
            else if (underlyingType == typeof(byte))
            {
                byte enumId = (byte)valueToSet;
                *(byte*)(address) = enumId;
            }
            else if (underlyingType == typeof(sbyte))
            {
                sbyte enumId = (sbyte)valueToSet;
                *(sbyte*)(address) = enumId;
            }
            else if (underlyingType == typeof(long))
            {
                long enumId = (long)valueToSet;
                *(long*)(address) = enumId;
            }
            else if (underlyingType == typeof(ulong))
            {
                ulong enumId = (ulong)valueToSet;
                *(ulong*)(address) = enumId;
            }
            else if (underlyingType == typeof(short))
            {
                short enumId = (short)valueToSet;
                *(short*)(address) = enumId;
            }
            else if (underlyingType == typeof(ushort))
            {
                ushort enumId = (ushort)valueToSet;
                *(ushort*)(address) = enumId;
            }
            else
            {
                ConsoleUtils.WriteError($"Failed to set enum! Converter doesn't support enums of type: {enumType.Name}");
            }*/
        }
    }
}
