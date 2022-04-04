using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Extension methods for <see cref="System.Type"/>
    /// </summary>
    public static class TypeExtensionsz
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
