﻿using System.Collections.Generic;
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
        /// Get the assembly that called an API method, based on StackTrace. 
        /// Need to use this instead of Assembly.GetCallingAssembly() for API methods
        /// </summary>
        /// <returns></returns>
        private static Assembly GetCallingAssemblyByStackTrace(int asmIndex)
        {
            // this doesn't work when there's an API using the ModHelper API. 
            //return stackAssemblies.FirstOrDefault(ownerAssembly => ownerAssembly != thisAssembly); 

            var stackAssemblies = GetCallingAssembliesByStackTrace();
            return stackAssemblies[asmIndex];
        }

        /// <summary>
        /// Returns all of the assemblies that are involved in calling this method.
        /// </summary>
        /// <returns></returns>
        public static List<Assembly> GetCallingAssembliesByStackTrace()
        {
            List<Assembly> stackAssemblies = new List<Assembly>();
            new StackTrace().GetFrames().ForEach(frame => stackAssemblies.Add(frame.GetMethod().DeclaringType.Assembly));
            return stackAssemblies;
        }

        /// <summary>
        /// Get the assembly that used this method. If the API used this method then it will
        /// return the API assembly, otherwise it will return a mod's assembly
        /// </summary>
        /// <returns></returns>
        public static Assembly GetCallingAssembly(int asmIndex = 6)
        {
            var callingAsm = GetCallingAssemblyByStackTrace(asmIndex);

            return callingAsm.FullName.Contains("System.Private.CoreLib")
                ? Assembly.GetExecutingAssembly() : callingAsm;
        }
    }
}
