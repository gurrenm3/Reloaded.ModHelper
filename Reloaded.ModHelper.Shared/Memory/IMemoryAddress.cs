namespace Reloaded.ModHelper
{
    /// <summary>
    /// Represents an address in memory. Used to directly read/write the value at this location.
    /// </summary>
    /// <typeparam name="T">The type of value stored at this address.</typeparam>
    public interface IMemoryAddress<T>
    {
        /// <summary>
        /// The pointer of the address
        /// </summary>
        public long Address { get; set; }

        /// <summary>
        /// Write a value to this address.
        /// </summary>
        /// <param name="valueToWrite"></param>
        public void Write(T valueToWrite);

        /// <summary>
        /// Read the value stored at this address.
        /// </summary>
        /// <returns></returns>
        public T Read();
    }
}
