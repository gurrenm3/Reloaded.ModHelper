using System;
using System.IO;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A binary reader that can read in little or big endian.
    /// <br/>Sources:
    /// <br/>1. https://github.com/cmkushnir/NMSModBuilder/blob/883d16841c4e65d954adfddb33e0eb487c389e0e/Common/Utility/EndianBinaryReader.cs
    /// <br/>2. https://github.com/maikelwever/Zio_PSArcFIleSystem/blob/master/Zio.PSArcFileSystem/PSArcFileSystem.cs
    /// </summary>
    public class EndianBinaryReader : BinaryReader
    {
        /// <summary>
        /// The Endian type for this PC.
        /// </summary>
        public static readonly EndianType SystemEndian = BitConverter.IsLittleEndian ?
            EndianType.Little : EndianType.Big;

        /// <summary>
        /// The Endian type currently be used by this reader.
        /// </summary>
        public EndianType EndianInUse { get; private set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public EndianBinaryReader(Stream inputStream, EndianType endianType) : base(inputStream)
        {
            this.EndianInUse = endianType;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override short ReadInt16() => BitConverter.ToInt16(ReadForEndianness(sizeof(short), EndianInUse));

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override int ReadInt32() => BitConverter.ToInt32(ReadForEndianness(sizeof(int), EndianInUse));

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override long ReadInt64() => BitConverter.ToInt64(ReadForEndianness(sizeof(long), EndianInUse));

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override ushort ReadUInt16() => BitConverter.ToUInt16(ReadForEndianness(sizeof(ushort), EndianInUse));

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override uint ReadUInt32() => BitConverter.ToUInt32(ReadForEndianness(sizeof(uint), EndianInUse));

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override ulong ReadUInt64() => BitConverter.ToUInt64(ReadForEndianness(sizeof(ulong), EndianInUse));


        /// <summary>
        /// Reads the next 3 bytes as a uint.
        /// <br/>Taken from https://github.com/cmkushnir/NMSModBuilder/blob/883d16841c4e65d954adfddb33e0eb487c389e0e/Common/Utility/EndianBinaryReader.cs
        /// </summary>
        /// <returns></returns>
        public uint ReadUInt24()
        {
            return BitConverter.ToUInt32(EndianRead(3, 4));
        }

        /// <summary>
        /// Reads the next 5 bytes as a ulong.
        /// <br/>Taken from https://github.com/cmkushnir/NMSModBuilder/blob/883d16841c4e65d954adfddb33e0eb487c389e0e/Common/Utility/EndianBinaryReader.cs
        /// </summary>
        /// <returns></returns>
        public ulong ReadUInt40()
        {
            return BitConverter.ToUInt64(EndianRead(5, 8));
        }

        /// <summary>
        /// Read a number of bytes.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public override byte[] ReadBytes(int count)
        {
            return ReadForEndianness(count, EndianInUse);
        }

        /// <summary>
        /// Reads a number of bytes from the start point.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        protected byte[] EndianRead(int start, int count)
        {
            var from = base.ReadBytes(start);
            var to = new byte[count];

            if (EndianInUse != SystemEndian) Array.Reverse(from);
            var offset = (SystemEndian == EndianType.Big) ? (count - start) : 0;
            Buffer.BlockCopy(from, 0, to, offset, start);

            return to;
        }

        private byte[] ReadForEndianness(int bytesToRead, EndianType endianness)
        {
            var bytesRead = base.ReadBytes(bytesToRead);

            if ((endianness == EndianType.Little && !BitConverter.IsLittleEndian)
                || (endianness == EndianType.Big && BitConverter.IsLittleEndian))
            {
                Array.Reverse(bytesRead);
            }

            return bytesRead;
        }
    }
}
