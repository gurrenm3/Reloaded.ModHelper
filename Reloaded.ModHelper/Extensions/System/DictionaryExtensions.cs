using System.Collections.Generic;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Extension methods for Dictionaries.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Allows you to Add or Update a KeyValuePair in this dictionary. If it doesn't already exist the pair will be
        /// added, otherwise the existing one will be updated with the provided <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (!dictionary.TryAdd(key, value))
                dictionary[key] = value;
        }

        /// <summary>
        /// Gets the value in the dictionary with this key, or if it's not present it will add it.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if(dictionary.TryGetValue(key, out var v))
                return v;

            dictionary.Add(key, value);
            return value;
        }
    }
}
