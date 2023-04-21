namespace Reloaded.ModHelper
{
    /// <summary>
    /// Utility methods for manipulating memory
    /// </summary>
    public static unsafe class MemoryUtils
    {
        /// <summary>
        /// Get's the address at baseAddress plus all the offsets.
        /// </summary>
        /// <param name="baseAddress">The starting address to get the offsets from.</param>
        /// <param name="offsets">The offsets that will take you to the desired address.</param>
        /// <returns>If successful, the desired address will be returned. Otherwise -1 will re returned to indicate failure.</returns>
        public static long GetAddressFromOffsets(long baseAddress, params int[] offsets)
        {
            long resultAddress = baseAddress;
            for (int i = 0; i < offsets.Length; i++)
            {
                int currentOffset = offsets[i];
                var tempAddress = *(long*)resultAddress + currentOffset;
                if (tempAddress == currentOffset) // the equation above is invalid.
                    return -1;

                resultAddress = tempAddress;
            }

            return resultAddress;
        }
    }
}
