using System.Reflection;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Extension methods for <see cref="FieldInfo"/>.
    /// </summary>
    public static class FieldInfoExtensions
    {
        /// <summary>
        /// Returns the value of a field supported by a given object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T GetValue<T>(this FieldInfo instance, object obj)
        {
            var value = instance.GetValue(obj);
            if (value == null)
                return default(T);

            return (value == null) ? default(T) : (T)value;
        }
    }
}
