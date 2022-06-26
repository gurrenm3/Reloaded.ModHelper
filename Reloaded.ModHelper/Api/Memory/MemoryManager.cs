using System;
using System.Collections.Generic;
using System.Linq;

namespace Reloaded.ModHelper.Api
{
    /// <summary>
    /// A universtal reader/writer for objects in memory. Can create custom converters to define how new objects
    /// should be handled.
    /// </summary>
    public class MemoryManager
    {
        private static HashSet<IMemoryConverter> staticConverters = new HashSet<IMemoryConverter>()
        {
            new PrimitiveConverter(),
            new EnumConverter()
        };

        private HashSet<IMemoryConverter> converters = new HashSet<IMemoryConverter>();

        /// <summary>
        /// Creates an instance of this memory manager.
        /// </summary>
        public MemoryManager()
        {
            RegisterStaticConverters();
        }

        private void RegisterStaticConverters()
        {
            foreach (var item in staticConverters)
                RegisterConverter(item);
        }


        /// <summary>
        /// Returns whether or not this converter is already registered.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool IsRegistered<T>()
        {
            return converters.Any(converter => converter.GetType() == typeof(T));
        }

        /// <summary>
        /// Registers a new converter to this manager.
        /// <br/>Will not allow duplicates.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="alwaysRegister">Whether or not this converter should always automatically be registered for new
        /// instances of Memory Managers.></param>
        public void RegisterConverter<T>(bool alwaysRegister = false) where T : IMemoryConverter, new()
        {
            var converter = new T();
            RegisterConverter(converter);
        }

        /// <summary>
        /// Registers the provided converter to this manager.
        /// <br/>Will not allow duplicates.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="converterToAdd"></param>
        /// <param name="alwaysRegister">Whether or not this converter should always automatically be registered for new
        /// instances of Memory Managers.</param>
        public void RegisterConverter<T>(T converterToAdd, bool alwaysRegister = false) where T : IMemoryConverter
        {
            if (alwaysRegister && !staticConverters.Any(c => c.GetType() == typeof(T)))
                staticConverters.Add(converterToAdd);

            if (IsRegistered<T>())
                return;

            converters.Add(converterToAdd);
        }
    }
}
