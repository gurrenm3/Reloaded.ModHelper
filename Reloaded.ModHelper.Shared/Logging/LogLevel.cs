namespace Reloaded.ModHelper
{
    /// <summary>
    /// Used to specify what level this message should be logged as.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Treat this message as a normal message.
        /// </summary>
        Normal,

        /// <summary>
        /// Treat this message as an error.
        /// </summary>
        Error,

        /// <summary>
        /// Treat this message as a warning.
        /// </summary>
        Warning, 

        /// <summary>
        /// Post this as a "For Cheat Engine Users" notification.
        /// </summary>
        CheatEngine
    }
}
