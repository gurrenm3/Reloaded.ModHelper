using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Utility methods for Primitive data types.
    /// </summary>
    public static unsafe class PrimitiveUtils
    {
        /// <summary>
        /// Returns whether or not the provided type is a primitive data type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsPrimitive<T>() => IsPrimitive(typeof(T));

        /// <summary>
        /// Returns whether or not the provided type is a primitive data type.
        /// </summary>
        /// <param name="typeToCheck"></param>
        /// <returns></returns>
        public static bool IsPrimitive(Type typeToCheck)
        {
            return typeToCheck.IsPrimitive || typeToCheck == typeof(decimal);
        }

        /// <summary>
        /// Returns the value that is held at the provided address as the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <returns></returns>
        public static T GetValue<T>(long address)
        {
            var value = GetValue(typeof(T), address);
            return value == null ? default : (T)value;
        }

        /// <summary>
        /// Returns the value that is held at the provided address as the specified type.
        /// </summary>
        /// <param name="valueType"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public static object GetValue(Type valueType, long address)
        {
            // most common conversions
            if (valueType == typeof(Int32))
                return *(Int32*)address;
            if (valueType == typeof(Single))
                return *(Single*)address;
            if (valueType == typeof(bool))
                return *(bool*)address;
            if (valueType == typeof(double))
                return *(double*)address;
            if (valueType == typeof(Int64))
                return *(Int64*)address;

            // less common conversions
            if (valueType == typeof(byte))
                return *(byte*)address;
            if (valueType == typeof(sbyte))
                return *(sbyte*)address;
            if (valueType == typeof(Int16))
                return *(Int16*)address;
            if (valueType == typeof(UInt16))
                return *(UInt16*)address;
            if (valueType == typeof(UInt32))
                return *(UInt32*)address;
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

            return default;
        }

        /// <summary>
        /// Sets the value at the specified address to the provided value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <param name="valueToSet"></param>
        public static void SetValue<T>(long address, T valueToSet) => SetValue(address, valueToSet, null);

        /// <summary>
        /// Sets the value at the specified address to the provided value.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="valueToSet"></param>
        /// <param name="valueType">Specify what type the value should be treated as.</param>
        public static void SetValue(long address, object valueToSet, Type valueType = null)
        {
            if (valueType == null)
                valueType = valueToSet.GetType();

            // most common conversions
            if (valueType == typeof(Int32))
                *(Int32*)address = (Int32)valueToSet;
            else if (valueType == typeof(Single))
                *(Single*)address = (Single)valueToSet;
            else if (valueType == typeof(bool))
                *(bool*)address = (bool)valueToSet;
            else if (valueType == typeof(double))
                *(double*)address = (double)valueToSet;
            else if (valueType == typeof(Int64))
                *(Int64*)address = (Int64)valueToSet;

            // less common conversions
            else if (valueType == typeof(byte))
                *(byte*)address = (byte)valueToSet;
            else if (valueType == typeof(sbyte))
                *(sbyte*)address = (sbyte)valueToSet;
            else if (valueType == typeof(Int16))
                *(Int16*)address = (Int16)valueToSet;
            else if (valueType == typeof(UInt16))
                *(UInt16*)address = (UInt16)valueToSet;
            else if (valueType == typeof(UInt32))
                *(UInt32*)address = (UInt32)valueToSet;
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
            else
                ConsoleUtils.WriteError($"Tried setting using a non-primitive object of type \"{valueType.FullName}\" to set a primitive value.");
        }
    }
}
