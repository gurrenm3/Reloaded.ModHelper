using System;
using System.Collections.Generic;
using System.Reflection;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Extension methods for System.Reflection.Assembly
    /// </summary>
	public static class AssemblyExtensions
	{
        /// <summary>
        /// Gets all types in this Assembly who have a base class of <paramref name="baseType"/>
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="baseType">The base type you are looking for</param>
        /// <returns></returns>
        public static List<Type> GetTypesWithBase(this Assembly assembly, Type baseType)
        {
            List<Type> foundTypes = null;
            foreach (var type in assembly.GetTypes())
            {
                if (type.BaseType != baseType)
                    continue;

                if (foundTypes == null)
                    foundTypes = new List<Type>();

                foundTypes.Add(type);
            }
            return foundTypes;
        }
    }
}