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
        private static HashSet<IMemoryConverter> alwaysAddPriorityConverters = new HashSet<IMemoryConverter>();
        private static HashSet<IMemoryConverter> alwaysRemoveConverters = new HashSet<IMemoryConverter>();
        private static HashSet<IMemoryConverter> alwaysAddConverters = new HashSet<IMemoryConverter>()
        {
            new PrimitiveConverter(),
            new StringConverter()
        };
        private static HashSet<Type> alwaysIgnoreList = new HashSet<Type>();

        private Dictionary<Type, IMemoryConverter> converterCache = new Dictionary<Type, IMemoryConverter>();
        private HashSet<IMemoryConverter> priorityConverters = new HashSet<IMemoryConverter>();
        private HashSet<IMemoryConverter> converters = new HashSet<IMemoryConverter>();
        private HashSet<Type> ignoreList = new HashSet<Type>();

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
        /// <typeparam name="T"></typeparam>
        /// <param name="alwaysIgnore"><inheritdoc/></param>
        public void IgnoreType<T>(bool alwaysIgnore = false) => IgnoreType(typeof(T), alwaysIgnore);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="typeToIgnore"></param>
        /// <param name="alwaysIgnore"><inheritdoc/></param>
        public void IgnoreType(Type typeToIgnore, bool alwaysIgnore = false)
        {
            if (typeToIgnore == null)
            {
                ConsoleUtil.LogError("Can't add type fo ignore list. Type is null");
                return;
            }

            if (alwaysIgnore)
                alwaysIgnoreList.Add(typeToIgnore);

            ignoreList.Add(typeToIgnore);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool ShouldIgnoreType<T>() => ShouldIgnoreType(typeof(T));

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="typeToCheck"></param>
        /// <returns></returns>
        public bool ShouldIgnoreType(Type typeToCheck)
        {
            if (typeToCheck == null)
            {
                ConsoleUtil.LogError("Can't check if Type should be ignored because it is null");
                return false;
            }

            return ignoreList.Contains(typeToCheck) || alwaysIgnoreList.Contains(typeToCheck);
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"><inheritdoc/></typeparam>
        /// <param name="address"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public T GetValue<T>(long address)
        {
            var value = GetValue(address, typeof(T));
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
                var value = await GetValueAsync(address, typeof(T));
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
        public async Task<object> GetValueAsync(long address, Type valueType)
        {
            try { return await Task.Run(() => GetValue(address, valueType)); }
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
        public object GetValue(long address, Type objectType)
        {
            IMemoryConverter converter;

            if (objectType == null)
            {
                ConsoleUtil.LogError("Get get value because type is null");
                return null;
            }

            if (ShouldIgnoreType(objectType))
                return null;

            converter = GetObjectConverter(objectType);
            if (converter == null)
            {
                ConsoleUtil.LogError($"Cannot convert object of type {objectType.Name}. Type is not supported." +
                    $" Consider creating your own {nameof(IMemoryConverter)} to add support for this.");
                return null;
            }

            return converter.GetValue(address, objectType);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="address"><inheritdoc/></param>
        /// <param name="valueToSet"><inheritdoc/></param>
        public void SetValue(long address, object valueToSet)
        {
            if (valueToSet == null)
            {
                ConsoleUtil.LogError("Can't set value because it is null");
                return;
            }

            IMemoryConverter converter;
            if (ShouldIgnoreType(valueToSet.GetType()))
                return;

            converter = GetObjectConverter(valueToSet.GetType());
            if (converter == null)
            {
                ConsoleUtil.LogError($"Cannot convert object of type {valueToSet.GetType().Name}. Type is not supported." +
                        $" Consider creating your own {nameof(IMemoryConverter)} to add support for this.");
                return;
            }

            converter.SetValue(address, valueToSet);
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IMemoryConverter GetConverter<T>()
        {
            return GetObjectConverter(typeof(T));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="converterType"></param>
        /// <returns></returns>
        public IMemoryConverter GetConverter(Type converterType)
        {
            var priorityConverter = priorityConverters.FirstOrDefault(c => c.CanConvert(converterType));
            if (priorityConverter != null)
                return priorityConverter;

            return converters.FirstOrDefault(c => c.GetType() == converterType);
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"><inheritdoc/></typeparam>
        /// <returns><inheritdoc/></returns>
        public IMemoryConverter GetObjectConverter<T>()
        {
            return GetObjectConverter(typeof(T));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="converterType"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public IMemoryConverter GetObjectConverter(Type converterType)
        {
            IMemoryConverter converter;

            if (ShouldIgnoreType(converterType))
                return null;

            var priorityConverter = priorityConverters.FirstOrDefault(c => c.CanConvert(converterType));
            if (priorityConverter != null)
            {
                return priorityConverter;
            }

            converter = converters.FirstOrDefault(c => c.CanConvert(converterType));

            return converter;
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
            if (objectType == null)
            {
                ConsoleUtil.LogError("Unable to check if type is convertable. Provided type is null");
                return false;
            }

            return GetObjectConverter(objectType) != null;
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"><inheritdoc/></typeparam>
        /// <returns><inheritdoc/></returns>
        public bool IsRegistered<T>()
        {
            bool isPriorityConverter = priorityConverters.Any(converter => converter.GetType() == typeof(T));
            bool isRegularConverter = converters.Any(converter => converter.GetType() == typeof(T));
            return isPriorityConverter || isRegularConverter;
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
            {
                ConsoleUtil.LogError("Tried adding a converter that is not a MemoryConverter");
                return;
            }

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
        /// <param name="alwaysRegister"></param>
        public void AddPriorityConverter<T>(bool alwaysRegister = false) where T : IMemoryConverter
        {
            AddPriorityConverter(typeof(T), alwaysRegister);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="priorityType"></param>
        /// <param name="alwaysRegister"></param>
        public void AddPriorityConverter(Type priorityType, bool alwaysRegister = false)
        {
            if (!priorityType.IsAssignableTo(typeof(IMemoryConverter)))
            {
                ConsoleUtil.LogError("Tried adding a priority converter that is not a MemoryConverter");
                return;
            }

            var priorityConverter = (IMemoryConverter)Activator.CreateInstance(priorityType);
            AddPriorityConverter(priorityConverter, alwaysRegister);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="converterToAdd"></param>
        /// <param name="alwaysRegister"></param>
        public void AddPriorityConverter<T>(T converterToAdd, bool alwaysRegister = false) where T : IMemoryConverter
        {
            if (alwaysRegister && !alwaysAddPriorityConverters.Any(c => c.GetType() == typeof(T)))
                alwaysAddPriorityConverters.Add(converterToAdd);

            // it's already here or should be ignored
            if (IsRegistered<T>() || alwaysRemoveConverters.Contains(converterToAdd))
                return;

            priorityConverters.Add(converterToAdd);
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
            var priorityConverter = priorityConverters.FirstOrDefault(c => c.CanConvert(converterType));
            if (priorityConverter != null)
                return RemoveConverter(priorityConverter, alwaysRemove);

            var converterToRemove = converters.FirstOrDefault(c => c.GetType() == converterType);
            return RemoveConverter(priorityConverter, alwaysRemove);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="converterToRemove"><inheritdoc/></param>
        /// <param name="alwaysRemove"><inheritdoc/></param>
        /// <returns></returns>
        public bool RemoveConverter(IMemoryConverter converterToRemove, bool alwaysRemove = false)
        {
            if (converterToRemove == null || !priorityConverters.Remove(converterToRemove) || !converters.Remove(converterToRemove)) // nothing removed.
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
