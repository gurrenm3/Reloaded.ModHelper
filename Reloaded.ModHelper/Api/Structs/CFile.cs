using System.Runtime.InteropServices;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Represents a FILE Pointer in the C Programming language. TODO
    /// </summary>
    /// <remarks>Documentation: https://codingpointer.com/c-tutorial/file-pointers , and http://tigcc.ticalc.org/doc/stdio.html#FILE </remarks>
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct CFile
    {
        /// <summary>
        /// Current position of file pointer (absolute address).
        /// </summary>
        [FieldOffset(0x0)]
        public char* currentPos;

        /// <summary>
        /// Pointer to the base of the file.
        /// </summary>
        [FieldOffset(0x0)]
        public void* basePointer;

        /// <summary>
        /// File handle.
        /// </summary>
        [FieldOffset(0x0)]
        public ushort handle;

        /// <summary>
        /// File status flags. Describes info about how the file was opened/it's current status. 
        /// Check documentation for more info.
        /// </summary>
        [FieldOffset(0x0)]
        public FileFlags flags;

        /// <summary>
        /// 1-byte buffer for ungetc (b15=1 if non-empty).
        /// </summary>
        [FieldOffset(0x0)]
        public short unget;

        /// <summary>
        /// Number of currently allocated bytes for the file.
        /// </summary>
        [FieldOffset(0x0)]
        public ulong alloc;

        /// <summary>
        /// Number of bytes allocated at once.
        /// </summary>
        [FieldOffset(0x0)]
        public ushort buffincrement;
    }
}
