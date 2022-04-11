using System;
using System.Linq;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Extension methods for <see cref="System.Type"/>
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Returns whether or not this type is a Numeric type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNumeric(this Type type)
        {
            var numericTypes = new Type[] { typeof(byte), typeof(int), typeof(long), typeof(float), typeof(double), typeof(decimal), };
            return numericTypes.Contains(type);
        }
    }
}
