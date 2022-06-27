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
                return false;

            return typeToCheck.IsPrimitive || typeToCheck == typeof(decimal);
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
            if (valueType == typeof(bool))
                return *(bool*)address;
            if (valueType == typeof(byte))
                return *(byte*)address;
            if (valueType == typeof(sbyte))
                return *(sbyte*)address;
            if (valueType == typeof(Int16))
                return *(Int16*)address;
            if (valueType == typeof(UInt16))
                return *(UInt16*)address;
            if (valueType == typeof(Int32))
                return *(Int32*)address;
            if (valueType == typeof(UInt32))
                return *(UInt32*)address;
            if (valueType == typeof(Int64))
                return *(Int64*)address;
            if (valueType == typeof(UInt64))
                return *(UInt64*)address;
            if (valueType == typeof(IntPtr))
                return *(IntPtr*)address;
            if (valueType == typeof(UIntPtr))
                return *(UIntPtr*)address;
            if (valueType == typeof(char))
                return *(char*)address;
            if (valueType == typeof(decimal))
                return *(decimal*)address;
            if (valueType == typeof(double))
                return *(double*)address;
            if (valueType == typeof(Single))
                return *(Single*)address;

            throw new NotSupportedException("Converter is not capable of reading this value type in memory.");
        }

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
            var valueType = valueToSet.GetType();

            if (valueType == typeof(bool))
                *(bool*)address = (bool)valueToSet;
            else if (valueType == typeof(byte))
                *(byte*)address = (byte)valueToSet;
            else if (valueType == typeof(sbyte))
                *(sbyte*)address = (sbyte)valueToSet;
            else if (valueType == typeof(Int16))
                *(Int16*)address = (Int16)valueToSet;
            else if (valueType == typeof(UInt16))
                *(UInt16*)address = (UInt16)valueToSet;
            else if (valueType == typeof(Int32))
                *(Int32*)address = (Int32)valueToSet;
            else if (valueType == typeof(UInt32))
                *(UInt32*)address = (UInt32)valueToSet;
            else if (valueType == typeof(Int64))
                *(Int64*)address = (Int64)valueToSet;
            else if (valueType == typeof(UInt64))
                *(UInt64*)address = (UInt64)valueToSet;
            else if (valueType == typeof(IntPtr))
                *(IntPtr*)address = (IntPtr)valueToSet;
            else if (valueType == typeof(UIntPtr))
                *(UIntPtr*)address = (UIntPtr)valueToSet;
            else if (valueType == typeof(char))
                *(char*)address = (char)valueToSet;
            else if (valueType == typeof(decimal))
                *(decimal*)address = (decimal)valueToSet;
            else if (valueType == typeof(double))
                *(double*)address = (double)valueToSet;
            else if (valueType == typeof(Single))
                *(Single*)address = (Single)valueToSet;
            else
                throw new NotSupportedException($"Primitives Converter is not capable of setting the type {valueType.Name} in memory.");
        }
    }
}
