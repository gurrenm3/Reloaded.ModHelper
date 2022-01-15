namespace Reloaded.ModHelper
{
    /// <summary>
    /// Extension methods for <see cref="Memory_Basic_Info"/> and <see cref="Memory_Basic_Info64"/>
    /// </summary>
    public static class MemoryBasicInfoExtensions
    {
        /// <summary>
        /// Returns if this region in memory is free or not
        /// </summary>
        /// <param name="memoryInfo"></param>
        /// <returns></returns>
        public static bool IsRegionFree(this Memory_Basic_Info memoryInfo)
        {
            return memoryInfo.State == MemoryAllocateType.Free;
        }

        /// <summary>
        /// Returns if this region in memory is free or not
        /// </summary>
        /// <param name="memoryInfo"></param>
        /// <returns></returns>
        public static bool IsRegionFree(this Memory_Basic_Info64 memoryInfo)
        {
            return memoryInfo.State == MemoryAllocateType.Free;
        }
    }
}
