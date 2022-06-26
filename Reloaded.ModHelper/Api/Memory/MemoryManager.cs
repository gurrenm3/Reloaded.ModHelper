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
        private static HashSet<IMemoryConverter> alwaysRemoveConverters = new HashSet<IMemoryConverter>();
        private static HashSet<IMemoryConverter> alwaysAddConverters = new HashSet<IMemoryConverter>()
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
            AddStaticConverters();
            RemoveConvertersToIgnore();
        }

        private void AddStaticConverters()
        {
            foreach (var item in alwaysAddConverters)
                AddConverter(item);
        }

        private void RemoveConvertersToIgnore()
        {
            foreach (var item in alwaysRemoveConverters)
                RemoveConverter(item);
        }



        /// <summary>
        /// Reads an object in memory.
        /// </summary>
        /// <typeparam name="T">The type of object to be read.</typeparam>
        /// <param name="address">The base address of this object.</param>
        /// <returns></returns>
        public T GetObject<T>(long address)
        {
            var value = GetObject(typeof(T), address);
            return value == null ? default(T) : (T)value;
        }

        /// <summary>
        /// Reads an object in memory.
        /// </summary>
        /// <param name="objectType">The type of object to be read.</param>
        /// <param name="address">The base address of this object.</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public object GetObject(Type objectType, long address)
        {
            var converter = GetConverter(objectType);
            if (converter == null)
                throw new NotSupportedException($"Cannot convert object of type {objectType.Name}. Type is not supported." +
                    $" Consider creating your own {nameof(IMemoryConverter)} to add support for this.");

            return converter.GetValue(objectType, address);
        }

        /// <summary>
        /// Sets an object in memory at the provided address.
        /// </summary>
        /// <param name="address">The base address of the object.</param>
        /// <param name="valueToSet">The new value to set at the address.</param>
        public void SetObject(long address, object valueToSet)
        {
            var converter = GetConverter(valueToSet.GetType());
            if (converter == null)
                throw new NotSupportedException($"Cannot convert object of type {valueToSet.GetType().Name}. Type is not supported." +
                    $" Consider creating your own {nameof(IMemoryConverter)} to add support for this.");

            converter.SetValue(address, valueToSet);
        }


        /// <summary>
        /// Returns the converter that can convert an object of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IMemoryConverter GetConverter<T>()
        {
            return GetConverter(typeof(T));
        }

        /// <summary>
        /// Returns the converter that can convert an object of the provided type.
        /// Will return null if converter does not exist.
        /// </summary>
        /// <param name="converterType"></param>
        /// <returns></returns>
        public IMemoryConverter GetConverter(Type converterType)
        {
            return converters.FirstOrDefault(c => c.CanConvert(converterType));
        }

        /// <summary>
        /// Returns whether or not this type of object can be converted.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool CanConvert<T>()
        {
            return CanConvert(typeof(T));
        }

        /// <summary>
        /// Returns whether or not this type of object can be converted.
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public bool CanConvert(Type objectType)
        {
            return GetConverter(objectType) != null;
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
        /// Creates a new converter and registers it with this manager.
        /// <br/>Will not allow duplicates.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="alwaysRegister">Whether or not this converter should always automatically be registered for new
        /// instances of Memory Managers.></param>
        public void AddConverter<T>(bool alwaysRegister = false) where T : IMemoryConverter
        {
            AddConverter(typeof(T), alwaysRegister);
        }

        /// <summary>
        /// Creates a new converter and registers it with this manager.
        /// <br/>Will not allow duplicates.
        /// </summary>
        /// <param name="converterType"></param>
        /// <param name="alwaysRegister"></param>
        public void AddConverter(Type converterType, bool alwaysRegister = false)
        {
            if (!converterType.IsAssignableTo(typeof(IMemoryConverter)))
                throw new Exception("Tried adding a converter that is not a MemoryConverter");

            var converter = (IMemoryConverter)Activator.CreateInstance(converterType);
            AddConverter(converter, alwaysRegister);
        }

        /// <summary>
        /// Registers the provided converter to this manager.
        /// <br/>Will not allow duplicates.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="converterToAdd"></param>
        /// <param name="alwaysRegister">Whether or not this converter should always automatically be registered for new
        /// instances of Memory Managers.</param>
        public void AddConverter<T>(T converterToAdd, bool alwaysRegister = false) where T : IMemoryConverter
        {
            if (alwaysRegister && !alwaysAddConverters.Any(c => c.GetType() == typeof(T)))
                alwaysAddConverters.Add(converterToAdd);

            // it's already here or should be ignored
            if (IsRegistered<T>() || alwaysRemoveConverters.Contains(converterToAdd))
                return;

            converters.Add(converterToAdd);
        }

        /// <summary>
        /// Remove a converter so objects of this type are no longer converted this way.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="alwaysRemove">Should this converter always be removed?</param>
        /// <returns></returns>
        public bool RemoveConverter<T>(bool alwaysRemove = false)
        {
            return RemoveConverter(typeof(T), alwaysRemove);
        }

        /// <summary>
        /// Remove a converter so objects of this type are no longer converted this way.
        /// </summary>
        /// <param name="converterType"></param>
        /// <param name="alwaysRemove">Should this converter always be removed?</param>
        /// <returns></returns>
        public bool RemoveConverter(Type converterType, bool alwaysRemove = false)
        {
            var converterToRemove = converters.FirstOrDefault(c => c.GetType() == converterType);
            return RemoveConverter(converterToRemove, alwaysRemove);
        }

        /// <summary>
        /// Remove a converter so objects of this type are no longer converted this way.
        /// </summary>
        /// <param name="converterToRemove"></param>
        /// <param name="alwaysRemove">Should this converter always be removed?</param>
        /// <returns></returns>
        public bool RemoveConverter(IMemoryConverter converterToRemove, bool alwaysRemove = false)
        {
            if (converterToRemove == null || !converters.Remove(converterToRemove)) // nothing removed.
                return false;

            if (alwaysRemove)
            {
                alwaysRemoveConverters.Add(converterToRemove);
                alwaysAddConverters.Remove(converterToRemove);
            }
            
            return true;
        }
    }
}
