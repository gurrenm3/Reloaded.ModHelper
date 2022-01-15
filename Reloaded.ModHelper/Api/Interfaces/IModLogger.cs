using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A Logger that automatically adds a mod's name to each message.
    /// </summary>
    public interface IModLogger
    {
        /// <summary>
        /// The original Logger being used by the mod.
        /// </summary>
        ILogger BaseLogger { get; }

        /// <summary>
        /// Info about the mod. Used to logging the mod's name in each message.
        /// </summary>
        IModConfigV1 ModInfo { get; }


        #region ModLogger.Write

        /// <summary>
        /// Writes a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void Write(string message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void Write(int message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void Write(long message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void Write(bool message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void Write(double message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void Write(float message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void Write(decimal message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void Write(byte message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void Write(byte[] message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void Write(char[] message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void Write(char message, LogType logType = LogType.Normal);

        #endregion


        #region ModLogger.WriteLine

        /// <summary>
        /// Writes a new line to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteLine(string message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a new line to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteLine(bool message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a new line to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteLine(int message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a new line to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteLine(long message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a new line to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteLine(float message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a new line to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteLine(double message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a new line to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteLine(decimal message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a new line to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteLine(byte message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a new line to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteLine(byte[] message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a new line to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteLine(char message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a new line to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteLine(char[] message, LogType logType = LogType.Normal);

        #endregion



        /// <summary>
        /// Writes a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteAsync(string message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a new line to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteLineAsync(string message, LogType logType = LogType.Normal);
    }
}