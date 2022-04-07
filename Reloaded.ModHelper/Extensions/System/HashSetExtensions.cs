using System;
using System.Collections.Generic;
using System.Linq;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Extension methods for <see cref="HashSet{T}"/>
    /// </summary>
    public static class HashSetExtensions
    {
        /// <summary>
        /// Iterates over each item in this HashSet, executing it in <paramref name="action"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hashSet"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this HashSet<T> hashSet, Action<T> action)
        {
            var enumerator = hashSet.GetEnumerator();
            while (enumerator.MoveNext())
            {
                action(enumerator.Current);
            }
        }
    }
}
