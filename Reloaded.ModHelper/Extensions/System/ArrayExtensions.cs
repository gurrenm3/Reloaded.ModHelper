using System;
using System.Collections.Generic;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Extension methods for <see cref="System.Array"/>.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Performs an action on each element of the specified array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="codeToRun">The action to perform on each element in the array.</param>
        public static void ForEach<T>(this T[] array, Action<T> codeToRun)
        {
            Array.ForEach(array, codeToRun);
        }

        /// <summary>
        /// Performs an action on each element of the specified array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="codeToRun">The action to perform on each element in the array.</param>
        public static void ForEach(this Array array, Action<object> codeToRun)
        {
            for (int i = 0; i < array.Length; i++)
            {
                codeToRun.Invoke(array.GetValue(i));
            }
        }
    }
}
