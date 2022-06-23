using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Represents an address in memory. Used to directly read/write the value at this location.
    /// </summary>
    /// <typeparam name="T">The type of value stored at this address.</typeparam>
    public unsafe class MemoryAddress<T> : IMemoryAddress<T>
    {
        /// <summary>
        /// The address of this item in memory.
        /// </summary>
        public long Address { get; set; }

        /// <summary>
        /// Initializes a default memory address.
        /// </summary>
        public MemoryAddress()
        {

        }

        /// <summary>
        /// Initializes this object with the provided memory address.
        /// </summary>
        /// <param name="address"></param>
        public MemoryAddress(long address)
        {
            Address = address;
        }

        /// <summary>
        /// Initializes this object with a signature pattern to the desired memory address.
        /// </summary>
        /// <param name="pattern"></param>
        public MemoryAddress(string pattern)
        {
            Signature signature = new Signature(pattern);
            var address = signature.Scan();
            if (address == 0)
                throw new Exception("Failed to get address for pattern");
            Address = address;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public T Read()
        {
            if (typeof(T) == typeof(bool))
                return (T)Convert.ChangeType((*(bool*)Address), typeof(T));
            else if (typeof(T) == typeof(byte))
                return (T)Convert.ChangeType((*(byte*)Address), typeof(T));
            else if (typeof(T) == typeof(int))
                return (T)Convert.ChangeType((*(int*)Address), typeof(T));
            else if (typeof(T) == typeof(long))
                return (T)Convert.ChangeType((*(long*)Address), typeof(T));
            else if (typeof(T) == typeof(double))
                return (T)Convert.ChangeType((*(double*)Address), typeof(T));
            else if (typeof(T) == typeof(float))
                return (T)Convert.ChangeType((*(float*)Address), typeof(T));
            else if (typeof(T) == typeof(decimal))
                return (T)Convert.ChangeType((*(decimal*)Address), typeof(T));
            else if (typeof(T) == typeof(char))
                return (T)Convert.ChangeType((*(char*)Address), typeof(T));
            else
                throw new NotImplementedException("MemoryAddress currently does not support typeof(T)");
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="valueToWrite"></param>
        public void Write(T valueToWrite)
        {
            if (typeof(T) == typeof(bool))
                *(bool*)Address = (bool)Convert.ChangeType(valueToWrite, typeof(bool));
            else if (typeof(T) == typeof(byte))
                *(byte*)Address = (byte)Convert.ChangeType(valueToWrite, typeof(byte));
            else if (typeof(T) == typeof(int))
                *(int*)Address = (int)Convert.ChangeType(valueToWrite, typeof(int));
            else if (typeof(T) == typeof(long))
                *(long*)Address = (long)Convert.ChangeType(valueToWrite, typeof(long));
            else if (typeof(T) == typeof(double))
                *(double*)Address = (double)Convert.ChangeType(valueToWrite, typeof(double));
            else if (typeof(T) == typeof(float))
                *(float*)Address = (float)Convert.ChangeType(valueToWrite, typeof(float));
            else if (typeof(T) == typeof(decimal))
                *(decimal*)Address = (decimal)Convert.ChangeType(valueToWrite, typeof(decimal));
            else if (typeof(T) == typeof(char))
                *(char*)Address = (char)Convert.ChangeType(valueToWrite, typeof(char));
            else
                throw new NotImplementedException("MemoryAddress currently does not support typeof(T)");
        }
    }
}
