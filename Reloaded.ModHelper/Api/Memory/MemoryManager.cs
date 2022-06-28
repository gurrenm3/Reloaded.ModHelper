using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A universtal reader/writer for objects in memory. Can create custom converters to define how new objects
    /// should be handled.
    /// </summary>
    public class MemoryManager : IMemoryManager
    {
        private static HashSet<IMemoryConverter> alwaysRemoveConverters = new HashSet<IMemoryConverter>();
        private static HashSet<IMemoryConverter> alwaysAddConverters = new HashSet<IMemoryConverter>()
        {
            new PrimitiveConverter(),
            new StringConverter()
        };

        private HashSet<IMemoryConverter> converters = new HashSet<IMemoryConverter>();

        /// <summary>
        /// Creates an instance of this memory manager.
        /// </summary>
        public MemoryManager()
        {
            AddInstanceConverters();
            AddStaticConverters();
            RemoveConvertersToIgnore();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"><inheritdoc/></typeparam>
        /// <param name="address"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public T GetValue<T>(long address)
        {
            var value = GetValue(typeof(T), address);
            return value == null ? default(T) : (T)value;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <returns></returns>
        public async Task<T> GetValueAsync<T>(long address)
        {
            try
            {
                var value = await GetValueAsync(typeof(T), address);
                return value == null ? default(T) : (T)value;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="valueType"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public async Task<object> GetValueAsync(Type valueType, long address)
        {
            try { return await Task.Run(() => GetValue(valueType, address)); }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="address"></param>
        /// <param name="valueToSet"></param>
        /// <returns></returns>
        public async Task SetValueAsync(long address, object valueToSet)
        {
            try
            {
                await Task.Run(() =>
                {
                    SetValue(address, valueToSet);
                });
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="objectType"><inheritdoc/></param>
        /// <param name="address"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public object GetValue(Type objectType, long address)
        {
            var converter = GetConverter(objectType);
            if (converter == null)
                throw new NotSupportedException($"Cannot convert object of type {objectType.Name}. Type is not supported." +
                    $" Consider creating your own {nameof(IMemoryConverter)} to add support for this.");

            return converter.GetValue(objectType, address);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="address"><inheritdoc/></param>
        /// <param name="valueToSet"><inheritdoc/></param>
        public void SetValue(long address, object valueToSet)
        {
            var converter = GetConverter(valueToSet.GetType());
            if (converter == null)
                throw new NotSupportedException($"Cannot convert object of type {valueToSet.GetType().Name}. Type is not supported." +
                    $" Consider creating your own {nameof(IMemoryConverter)} to add support for this.");

            converter.SetValue(address, valueToSet);
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"><inheritdoc/></typeparam>
        /// <returns><inheritdoc/></returns>
        public IMemoryConverter GetConverter<T>()
        {
            return GetConverter(typeof(T));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="converterType"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public IMemoryConverter GetConverter(Type converterType)
        {
            return converters.FirstOrDefault(c => c.CanConvert(converterType));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"><inheritdoc/></typeparam>
        /// <returns><inheritdoc/></returns>
        public bool CanConvert<T>()
        {
            return CanConvert(typeof(T));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="objectType"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool CanConvert(Type objectType)
        {
            return GetConverter(objectType) != null;
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"><inheritdoc/></typeparam>
        /// <returns><inheritdoc/></returns>
        public bool IsRegistered<T>()
        {
            return converters.Any(converter => converter.GetType() == typeof(T));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"><inheritdoc/></typeparam>
        /// <param name="alwaysRegister"><inheritdoc/></param>
        public void AddConverter<T>(bool alwaysRegister = false) where T : IMemoryConverter
        {
            AddConverter(typeof(T), alwaysRegister);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="converterType"><inheritdoc/></param>
        /// <param name="alwaysRegister"><inheritdoc/></param>
        public void AddConverter(Type converterType, bool alwaysRegister = false)
        {
            if (!converterType.IsAssignableTo(typeof(IMemoryConverter)))
                throw new Exception("Tried adding a converter that is not a MemoryConverter");

            var converter = (IMemoryConverter)Activator.CreateInstance(converterType);
            AddConverter(converter, alwaysRegister);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"><inheritdoc/></typeparam>
        /// <param name="converterToAdd"><inheritdoc/></param>
        /// <param name="alwaysRegister"><inheritdoc/></param>
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
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="alwaysRemove"><inheritdoc/></param>
        /// <returns></returns>
        public bool RemoveConverter<T>(bool alwaysRemove = false)
        {
            return RemoveConverter(typeof(T), alwaysRemove);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="converterType"><inheritdoc/></param>
        /// <param name="alwaysRemove"><inheritdoc/></param>
        /// <returns></returns>
        public bool RemoveConverter(Type converterType, bool alwaysRemove = false)
        {
            var converterToRemove = converters.FirstOrDefault(c => c.GetType() == converterType);
            return RemoveConverter(converterToRemove, alwaysRemove);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="converterToRemove"><inheritdoc/></param>
        /// <param name="alwaysRemove"><inheritdoc/></param>
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

        private void AddInstanceConverters()
        {
            if (!alwaysAddConverters.Any(c => c.GetType() == typeof(EnumConverter)))
                alwaysAddConverters.Add(new EnumConverter(this));
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
    }
}
