using Reloaded.Memory.Sigscan;
using Reloaded.Memory.Sigscan.Structs;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A utility class for performing Signature Scans.
    /// </summary>
    /// <remarks>This is just a small abstraction of <see cref="Scanner"/> for easier reusability.</remarks>
    public class Signature
    {
        private static Process gameProc;
        private static bool initialized;
        private static long baseAddress;
        private static Scanner scanner;

        /// <summary>
        /// A cleaned version of the original pattern this <see cref="Signature"/> was created with.
        /// </summary>
        public readonly string sigPattern;
        private long cachedScanAddress = -1;


        /// <summary>
        /// Creates a <see cref="Signature"/> with its associated pattern.
        /// </summary>
        /// <param name="pattern">The pattern that corresponds to this <see cref="Signature"/> in memory. Will be used during <see cref="Scan(bool)"/>.</param>
        public Signature(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
                throw new BadSignaturePatternException();

            InitIfNecessary();
            sigPattern = CleanPattern(pattern);
        }

        /// <summary>
        /// Performs the scan to search for this pattern in Memory.
        /// </summary>
        /// <param name="cacheResult">Should the result be cached so it can be accessed later?</param>
        /// <returns></returns>
        /// <remarks>Uses Uses to <see cref="Scanner.FindPattern(string)"/> to find the address
        /// and combines it with the baseAddress of the game to get the final address.</remarks>
        public long Scan(bool cacheResult = true)
        {
            if (cachedScanAddress != -1 && cacheResult)
                return cachedScanAddress;

            var searchResult = scanner.FindPattern(sigPattern);
            var scanAddress = baseAddress + searchResult.Offset;
            return cacheResult ? cachedScanAddress = scanAddress : scanAddress;
        }

        /// <summary>
        /// Performs the scan to search for this pattern in Memory. Returns every address that matches this pattern.
        /// </summary>
        /// <returns></returns>
        public List<long> ScanAll()
        {
            var results = new List<long>();

            var lastOffset = -1;
            while (true)
            {
                lastOffset = scanner.FindPattern(sigPattern, lastOffset + 1).Offset;
                if (lastOffset == -1)
                    break;

                long functionAddress = (long)gameProc.MainModule.BaseAddress + lastOffset;
                results.Add(functionAddress);
            }

            return results;
        }

        /// <summary>
        /// Initializes the required variables if they haven't been initialized yet.
        /// </summary>
        private void InitIfNecessary()
        {
            if (initialized) return;

            gameProc = Process.GetCurrentProcess();
            baseAddress = (long)gameProc.MainModule.BaseAddress;
            scanner = new Scanner(gameProc, gameProc.MainModule);
            initialized = true;
        }

        /// <summary>
        /// Cleans the Pattern. Replaces all single '?' with "??" and removes all trailing whitespace.
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private string CleanPattern(string pattern)
        {
            string cleanedPattern = "";
            pattern.Split(' ').ForEach(str => cleanedPattern += str == "?" ? " ??" : $" {str}");
            return cleanedPattern.Trim();
        }
    }
}
