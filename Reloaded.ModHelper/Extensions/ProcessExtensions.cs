using System.Diagnostics;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Extension methods for the Process class
    /// </summary>
    public static class ProcessExtensions
    {
        /// <summary>
        /// Returns if this process is 64bit or not
        /// </summary>
        /// <param name="process"></param>
        /// <returns>If Process is 64bit, this method will return true. Otherwise it will return false</returns>
        public static bool Is64Bit(this Process process)
        {
            Kernel32.IsWow64Process(process.Handle, out bool is32Bit);
            return !is32Bit;
        }
    }
}
