using System;

namespace Reloaded.ModHelper
{
    public class ByteReader
    {
        /// <summary>
        /// The Endian type for this PC.
        /// </summary>
        public static readonly EndianType SystemEndian = BitConverter.IsLittleEndian ?
            EndianType.Little : EndianType.Big;

        public readonly EndianType endianInUse;

        public ByteReader(EndianType endianInUse)
        {
            this.endianInUse = endianInUse;
        }

        /// <summary>
        /// Read a number of bytes at the provided address.
        /// </summary>
        /// <param name="address">Address to start reading from</param>
        /// <param name="count">Number of bytes to read.</param>
        /// <returns></returns>
        public byte[] ReadBytes(long address, int count)
        {
            var bytes = new byte[count];

            for (int i = 0; i < count; i++)
                bytes[i] = ReadByte(address + i);

            if (endianInUse != SystemEndian)
                Array.Reverse(bytes);

            return bytes;
        }

        /// <summary>
        /// Read one byte at the provided address.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public unsafe byte ReadByte(long address)
        {
            return *(byte*)address;
        }
    }
}
