using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Reloaded.ModHelper
{
    public class ValueCache
    {
        Dictionary<string, object> valueCache = new Dictionary<string, object>();

        public ValueCache()
        {

        }

        public T GetValue<T>([CallerMemberName] string key = "")
        {
            valueCache.TryGetValue(key, out var value);
            return value is T valueAsT ? valueAsT : default;
        }

        public object GetValue([CallerMemberName] string key = "")
        {
            valueCache.TryGetValue(key, out var value);
            return value;
        }

        public T GetOrAddValue<T>([CallerMemberName] string key = "")
        {
            return (T)valueCache.GetOrAdd(key, default(T));
        }

        public object GetOrAddValue(object initialValue, [CallerMemberName] string key = "")
        {
            return valueCache.GetOrAdd(key, initialValue);
        }

        public T GetOrAddValue<T>(T initialValue, [CallerMemberName] string key = "")
        {
            var value = (T)valueCache.GetOrAdd(key, initialValue);
            return value;
        }

        public void AddOrUpdateValue(object value, [CallerMemberName] string key = "")
        {
            valueCache.AddOrUpdate(key, value);
        }
    }
}
