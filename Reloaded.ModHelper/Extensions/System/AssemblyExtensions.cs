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
        /// Gets all classes that have the interface <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static List<Type> GetTypesWithInterface<T>(this Assembly assembly) where T : class
        {
            string interfaceName = nameof(IModHook);
            var types = assembly.GetTypes();

            List<Type> result = new List<Type>();
            foreach (var type in types)
            {
                var typeInterface = type.GetInterface(interfaceName);
                if (typeInterface == null)
                    continue;

                result.Add(type);
            }

            return result;
        }

        /// <summary>
        /// Gets all types in this Assembly who have a base class of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static List<Type> GetTypesWithBase<T>(this Assembly assembly)
        {
            return assembly.GetTypesWithBase(typeof(T));
        }

        /// <summary>
        /// Gets all types in this Assembly who have a base class of <paramref name="baseType"/>
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="baseType">The base type you are looking for</param>
        /// <returns></returns>
        public static List<Type> GetTypesWithBase(this Assembly assembly, Type baseType)
        {
            List<Type> foundTypes = new List<Type>();
            foreach (var type in assembly.GetTypes())
            {
                if (type.BaseType != baseType)
                    continue;

                foundTypes.Add(type);
            }
            return foundTypes;
        }
    }
}