using System;
using System.Collections.Generic;
using System.Linq;

namespace Reloaded.ModHelper
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class FindOffsetAttribute : ModAttrAttribute
    {
        private static List<FindOffsetResult> cache = new();
        private static ByteReader byteReader;

        /// <summary>
        /// The offset that was found frim the pattern + numBytesToOffset
        /// </summary>
        public int DiscoveredOffset { get; private set; }

        public long PatternAddress { get; private set; }
        public readonly string searchPattern;
        public readonly int numBytesToOffset;

        private readonly int bytesToRead;

        public override void OnAttributeLoaded()
        {
            base.OnAttributeLoaded();

            if (byteReader == null)
                byteReader = new ByteReader(EndianType.Little);

            //ConsoleUtils.WriteLine($"Finding offset for {Info.TargetProperty.Name}");
            DiscoveredOffset = FindOffsetFromPattern(out var _patternAddress);
            PatternAddress = _patternAddress;
        }

        public FindOffsetAttribute(string searchPattern, int numBytesToOffset, int numBytesToRead = 4)
        {
            this.searchPattern = searchPattern;
            this.numBytesToOffset = numBytesToOffset;
            bytesToRead = numBytesToRead;

            
        }

        private int FindOffsetFromPattern(out long address)
        {
            var existingItem = cache.FirstOrDefault(item => item.searchPattern == searchPattern && item.numBytesToOffset == numBytesToOffset);
            if (existingItem.patternAddress != 0) // if it's been found before.
            {
                address = existingItem.patternAddress;
                return existingItem.discoveredOffset;
            }

            address = new Signature(searchPattern).Scan() + numBytesToOffset;
            if (address == numBytesToOffset)
                return -1;

            int offset = 0;
            var bytes = byteReader.ReadBytes(address, bytesToRead);

            if (bytesToRead == 2)
                offset = BitConverter.ToInt16(bytes);
            else if (bytesToRead == 4)
                offset = BitConverter.ToInt32(bytes);

            cache.Add(new FindOffsetResult()
            {
                searchPattern = searchPattern,
                numBytesToOffset = numBytesToOffset,
                patternAddress = address,
                discoveredOffset = offset
            });

            return offset;
        }
    }
}
