using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A universtal reader/writer for objects in memory. Can create custom converters to define how new objects
    /// should be handled.
    /// </summary>
    public interface IMemoryManager
    {
        /// <summary>
        /// Add a type to the Ignore list. Will not convert any objects of this type if found.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="alwaysIgnore">Indicates whether or not this type should be always be ignored,
        /// including on new Memory Managers. If set to false then it will only be ignored on this Manager.</param>
        public void IgnoreType<T>(bool alwaysIgnore = false);

        /// <summary>
        /// Add a type to the Ignore list. Will not convert any objects of this type if found.
        /// </summary>
        /// <param name="typeToIgnore"></param>
        /// <param name="alwaysIgnore">Indicates whether or not this type should be always be ignored,
        /// including on new Memory Managers. If set to false then it will only be ignored on this Manager.</param>
        public void IgnoreType(Type typeToIgnore, bool alwaysIgnore = false);

        /// <summary>
        /// Returns whether or not this type is in the list of types to ignore.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool ShouldIgnoreType<T>();

        /// <summary>
        /// Returns whether or not this type is in the list of types to ignore.
        /// </summary>
        /// <param name="typeToCheck"></param>
        /// <returns></returns>
        public bool ShouldIgnoreType(Type typeToCheck);

        

        /// <summary>
        /// Returns whether or not this type of object can be converted.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool CanConvert<T>();

        /// <summary>
        /// Returns whether or not this type of object can be converted.
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public bool CanConvert(Type objectType);


        /// <summary>
        /// Returns the converter that can convert an object of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IMemoryConverter GetObjectConverter<T>();

        /// <summary>
        /// Returns the converter that can convert an object of the provided type.
        /// Will return null if converter does not exist.
        /// </summary>
        /// <param name="objectToConvert"></param>
        /// <returns></returns>
        public IMemoryConverter GetObjectConverter(Type objectToConvert);

        /// <summary>
        /// Returns the converter of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IMemoryConverter GetConverter<T>();

        /// <summary>
        /// Returns the converter with the provided type.
        /// </summary>
        /// <param name="converterType"></param>
        /// <returns></returns>
        public IMemoryConverter GetConverter(Type converterType);


        /// <summary>
        /// Creates a new converter and registers it with this manager.
        /// <br/>Will not allow duplicates.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="alwaysRegister">Whether or not this converter should always automatically be registered for new
        /// instances of Memory Managers.></param>
        public void AddConverter<T>(bool alwaysRegister = false) where T : IMemoryConverter;

        /// <summary>
        /// Creates a new converter and registers it with this manager.
        /// <br/>Will not allow duplicates.
        /// </summary>
        /// <param name="converterType"></param>
        /// <param name="alwaysRegister"></param>
        public void AddConverter(Type converterType, bool alwaysRegister = false);

        /// <summary>
        /// Registers the provided converter to this manager.
        /// <br/>Will not allow duplicates.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="converterToAdd"></param>
        /// <param name="alwaysRegister">Whether or not this converter should always automatically be registered for new
        /// instances of Memory Managers.</param>
        public void AddConverter<T>(T converterToAdd, bool alwaysRegister = false) where T : IMemoryConverter;



        /// <summary>
        /// Creates a new converter and registers it with this manager.
        /// <br/>Will not allow duplicates.
        /// <br/><br/>Will be registered as a Priority Converter and will therefore always be checked first, before
        /// Non-Priority converters.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="alwaysRegister">Whether or not this converter should always automatically be registered for new
        /// instances of Memory Managers.></param>
        public void AddPriorityConverter<T>(bool alwaysRegister = false) where T : IMemoryConverter;

        /// <summary>
        /// Creates a new converter and registers it with this manager.
        /// <br/>Will not allow duplicates.
        /// <br/><br/>Will be registered as a Priority Converter and will therefore always be checked first, before
        /// Non-Priority converters.
        /// </summary>
        /// <param name="converterType"></param>
        /// <param name="alwaysRegister"></param>
        public void AddPriorityConverter(Type converterType, bool alwaysRegister = false);

        /// <summary>
        /// Registers the provided converter to this manager.
        /// <br/>Will not allow duplicates.
        /// <br/><br/>Will be registered as a Priority Converter and will therefore always be checked first, before
        /// Non-Priority converters.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="converterToAdd"></param>
        /// <param name="alwaysRegister">Whether or not this converter should always automatically be registered for new
        /// instances of Memory Managers.</param>
        public void AddPriorityConverter<T>(T converterToAdd, bool alwaysRegister = false) where T : IMemoryConverter;




        /// <summary>
        /// Remove a converter so objects of this type are no longer converted this way.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="alwaysRemove">Should this converter always be removed?</param>
        /// <returns></returns>
        public bool RemoveConverter<T>(bool alwaysRemove = false);

        /// <summary>
        /// Remove a converter so objects of this type are no longer converted this way.
        /// </summary>
        /// <param name="converterType"></param>
        /// <param name="alwaysRemove">Should this converter always be removed?</param>
        /// <returns></returns>
        public bool RemoveConverter(Type converterType, bool alwaysRemove = false);

        /// <summary>
        /// Remove a converter so objects of this type are no longer converted this way.
        /// </summary>
        /// <param name="converterToRemove"></param>
        /// <param name="alwaysRemove">Should this converter always be removed?</param>
        /// <returns></returns>
        public bool RemoveConverter(IMemoryConverter converterToRemove, bool alwaysRemove = false);



        /// <summary>
        /// Reads an object in memory.
        /// </summary>
        /// <typeparam name="T">The type of object to be read.</typeparam>
        /// <param name="address">The base address of this object.</param>
        /// <returns></returns>
        public T GetValue<T>(long address);

        /// <summary>
        /// Reads an object in memory.
        /// </summary>
        /// <param name="objectType">The type of object to be read.</param>
        /// <param name="address">The base address of this object.</param>
        /// <returns></returns>
        public object GetValue(long address, Type objectType);

        /// <summary>
        /// Reads an object in memory on a separate thread and returns when its done.
        /// Use this for big objects so you don't lock the game.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <returns></returns>
        public Task<T> GetValueAsync<T>(long address);

        /// <summary>
        /// Reads an object in memory on a separate thread and returns when its done.
        /// Use this for big objects so you don't lock the game.
        /// </summary>
        /// <param name="valueType"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public Task<object> GetValueAsync(long address, Type valueType);

        /// <summary>
        /// Sets an object in memory at the provided address on a separate thread and returns when its done.
        /// Use this for big objects so you don't lock the game.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="valueToSet"></param>
        /// <returns></returns>
        public Task SetValueAsync(long address, object valueToSet);

        /// <summary>
        /// Sets an object in memory at the provided address.
        /// </summary>
        /// <param name="address">The base address of the object.</param>
        /// <param name="valueToSet">The new value to set at the address.</param>
        public void SetValue(long address, object valueToSet);
    }
}
