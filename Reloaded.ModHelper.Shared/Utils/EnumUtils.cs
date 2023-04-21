using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Utility methods for Enums.
    /// </summary>
    public static unsafe class EnumUtils
    {
        /// <summary>
        /// Returns whether or not the provided type is an enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsEnum<T>() => IsEnum(typeof(T));

        /// <summary>
        /// Returns whether or not the provided type is an enum.
        /// </summary>
        /// <param name="typeToCheck"></param>
        /// <returns></returns>
        public static bool IsEnum(Type typeToCheck)
        {
            return typeToCheck.IsEnum;
        }

        /// <summary>
        /// Returns the value held at the provided address as type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <returns></returns>
        public static T GetValue<T>(long address) => (T)GetValue(typeof(T), address);

        /// <summary>
        /// Returns the value held at the provided address as the specified type.
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public static object GetValue(Type enumType, long address)
        {
            var underlyingType = Enum.GetUnderlyingType(enumType); // this is the datatype, ex: int, uint, etc
            var enumId = PrimitiveUtils.GetValue(underlyingType, address); // actual numeric enum value, ex: id = 32

            try
            {
                return Enum.ToObject(enumType, enumId);
            }
            catch (Exception)
            {
                ConsoleUtils.WriteError("Faield to get enum value");
                return null;
            }
        }

        /// <summary>
        /// Set's the value held at <paramref name="address"/> to <paramref name="valueToSet"/>.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="valueToSet"></param>
        public static void SetValue(long address, object valueToSet)
        {
            var enumType = valueToSet.GetType();
            var underlyingType = Enum.GetUnderlyingType(enumType);

            PrimitiveUtils.SetValue(address, valueToSet, underlyingType);
        }
    }
}
