using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A converter for dynamically reading/writing values in memory.
    /// </summary>
    public interface IMemoryConverter
    {
        /// <summary>
        /// Returns whether or not the provided type can be converted by this converter.
        /// </summary>
        /// <param name="typeToCheck"></param>
        /// <returns></returns>
        public bool CanConvert(Type typeToCheck);

        /// <summary>
        /// Returns whether or not the provided type can be converted by this converter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool CanConvert<T>();

        /// <summary>
        /// Returns the value stored at the provided address.
        /// </summary>
        /// <param name="valueType"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public object GetValue(Type valueType, long address);

        /// <summary>
        /// Returns the value stored at the provided address
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <returns></returns>
        public T GetValue<T>(long address);

        /// <summary>
        /// Set's the value of the object held at this address.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="valueToSet"></param>
        public void SetValue(long address, object valueToSet);
    }
}
