using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Utility methods for <see cref="Assembly"/>.
    /// </summary>
    public static class AssemblyUtils
    {
        // taken from https://www.codeproject.com/tips/791878/get-calling-assembly-from-stacktrace
        /// <summary>
        /// Returns all of the assemblies that are involved in calling this method.
        /// </summary>
        /// <returns></returns>
        public static HashSet<Assembly> GetCallingAssembliesByStackTrace()
        {
            HashSet<Assembly> stackAssemblies = new HashSet<Assembly>();
            new StackTrace().GetFrames().ForEach(frame => stackAssemblies.Add(frame.GetMethod().DeclaringType.Assembly));
            return stackAssemblies;
        }

        /// <summary>
        /// Get the Assembly that's directly responsible for calling this method.
        /// <br/><br/><see cref="Assembly.GetCallingAssembly"/> doesn't work if one assembly calls another assembly.
        /// This method will always return exactly which Assembly was responsible for the call, regardless of who called it
        /// or how nested the function calls are.
        /// </summary>
        /// <returns></returns>
        public static Assembly GetCallingAssembly()
        {
            var assemblies = GetCallingAssembliesByStackTrace();
            var callingAsm = assemblies.ElementAt(assemblies.Count - 2); // offset of 2 because it's second from the end
            return callingAsm;
        }
    }
}
