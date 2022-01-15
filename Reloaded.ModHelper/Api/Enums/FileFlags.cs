namespace Reloaded.ModHelper
{
    /// <summary>
    /// Used with <see cref="CFile"/>.<br/>These flags describe whether a file is opened in read or write mode, whether an end-of-file 
    /// or a serious error occured, and whether the file is open in binary or text mode.
    /// </summary>
    /// <remarks>Documentation: http://tigcc.ticalc.org/doc/stdio.html#FileFlags </remarks>
    public enum FileFlags : short
    {
        /// <summary>
        /// File is opened in Read-only mode.
        /// </summary>
        Read = 1,

        /// <summary>
        /// File is opened in Write-only mode.
        /// </summary>
        Write = 2,

        /// <summary>
        /// File is opened in Read/Write mode.
        /// </summary>
        ReadWrite = 3,

        /// <summary>
        /// Indicates a serious error occured.
        /// </summary>
        Error = 10, 

        /// <summary>
        /// End of file.
        /// </summary>
        EndOfFile = 20, 

        /// <summary>
        /// Indicates whether or not the file is opened in Binary/text mode.
        /// </summary>
        BinaryText = 40
    }
}
