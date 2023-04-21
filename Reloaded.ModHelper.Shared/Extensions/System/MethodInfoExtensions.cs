using System.Reflection;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Extension methods for <see cref="MethodInfo"/>.
    /// </summary>
    public static class MethodInfoExtensions
    {
        /// <summary>
        /// Run this method without providing an instance or any arguments.
        /// <br/>For use with static methods.
        /// </summary>
        /// <param name="instance"></param>
        public static void Invoke(this MethodInfo instance)
        {
            instance.Invoke(null, null);
        }

        /// <summary>
        /// Run this method with an object instance but no arguments.
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="instance">The instance of the object calling this method</param>
        public static void Invoke(this MethodInfo methodInfo, object instance)
        {
            methodInfo.Invoke(instance, null);
        }
    }
}
