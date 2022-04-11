using System.Drawing;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A logger for Reloaded2 Mods. Every write method is async to prevent messages from interrupting each other.
    /// </summary>
    public interface IModLogger
    {
        /// <summary>
        /// Write additional text to the Console without proceeding to the next line.
        /// </summary>
        /// <param name="message">Message to write to the Console.</param>
        /// <param name="logLevel">The level to log this message as. Changes the color of the message and is helpful for quickly 
        /// identifying a message as an error or warning.</param>
        /// <param name="writeModName">[Optional] Set to true if you want to have the mod's name written at the front of this message</param>
        public void Write(string message, LogLevel logLevel, bool writeModName = false);

        /// <summary>
        /// Write additional text to the Console without proceeding to the next line.
        /// </summary>
        /// <param name="message">Message to write to the Console.</param>
        /// <param name="logLevel">The level to log this message as. Changes the color of the message and is helpful for quickly 
        /// identifying a message as an error or warning.</param>
        /// <param name="writeModName">[Optional] Set to true if you want to have the mod's name written at the front of this message</param>
        public void Write(object message, LogLevel logLevel, bool writeModName = false);

        /// <summary>
        /// Write additional text to the Console without proceeding to the next line.
        /// </summary>
        /// <param name="message">Message to write to the Console.</param>
        /// <param name="color">The color this message should be written as. Useful for making your message appear
        /// with a custom color</param>
        /// <param name="writeModName">[Optional] Set to true if you want to have the mod's name written at the front of this message</param>
        public void Write(string message, Color color, bool writeModName = false);

        /// <summary>
        /// Write additional text to the Console without proceeding to the next line.
        /// </summary>
        /// <param name="message">Message to write to the Console.</param>
        /// <param name="color">The color this message should be written as. Useful for making your message appear
        /// with a custom color</param>
        /// <param name="writeModName">[Optional] Set to true if you want to have the mod's name written at the front of this message</param>
        public void Write(object message, Color color, bool writeModName = false);

        /// <summary>
        /// Write additional text to the Console without proceeding to the next line.
        /// </summary>
        /// <param name="message">Message to write to the Console.</param>
        /// <param name="writeModName">[Optional] Set to true if you want to have the mod's name written at the front of this message</param>
        public void Write(string message, bool writeModName = false);

        /// <summary>
        /// Write additional text to the Console without proceeding to the next line.
        /// <param name="message">Message to write to the Console.</param>
        /// <param name="writeModName">[Optional] Set to true if you want to have the mod's name written at the front of this message</param>
        public void Write(object message, bool writeModName = false);



        /// <summary>
        /// Writes a message to the Console, ending the current line and moving to the next.
        /// </summary>
        /// <param name="message">Message to write to the Console.</param>
        /// <param name="logLevel">The level to log this message as. Changes the color of the message and is helpful for quickly 
        /// identifying a message as an error or warning.</param>
        /// <param name="writeModName">[Optional] Set to false if you do not want to have the mod's name written at the front of this message</param>
        public void WriteLine(string message, LogLevel logLevel, bool writeModName = true);

        /// <summary>
        /// Writes a message to the Console, ending the current line and moving to the next.
        /// </summary>
        /// <param name="message">Message to write to the Console.</param>
        /// <param name="logLevel">The level to log this message as. Changes the color of the message and is helpful for quickly 
        /// identifying a message as an error or warning.</param>
        /// <param name="writeModName">[Optional] Set to false if you do not want to have the mod's name written at the front of this message</param>
        public void WriteLine(object message, LogLevel logLevel, bool writeModName = true);

        /// <summary>
        /// Writes a message to the Console, ending the current line and moving to the next.
        /// </summary>
        /// <param name="message">Message to write to the Console.</param>
        /// <param name="color">The color this message should be written as. Useful for making your message appear
        /// with a custom color</param>
        /// <param name="writeModName">[Optional] Set to false if you do not want to have the mod's name written at the front of this message</param>
        public void WriteLine(string message, Color color, bool writeModName = true);

        /// <summary>
        /// Writes a message to the Console, ending the current line and moving to the next.
        /// </summary>
        /// <param name="message">Message to write to the Console.</param>
        /// <param name="color">The color this message should be written as. Useful for making your message appear
        /// with a custom color</param>
        /// <param name="writeModName">[Optional] Set to false if you do not want to have the mod's name written at the front of this message</param>
        public void WriteLine(object message, Color color, bool writeModName = true);

        /// <summary>
        /// Writes a message to the Console, ending the current line and moving to the next.
        /// </summary>
        /// <param name="message">Message to write to the Console.</param>
        /// <param name="writeModName">[Optional] Set to false if you do not want to have the mod's name written at the front of this message</param>
        public void WriteLine(string message, bool writeModName = true);

        /// <summary>
        /// Writes a message to the Console, ending the current line and moving to the next.
        /// </summary>
        /// <param name="message">Message to write to the Console.</param>
        /// <param name="writeModName">[Optional] Set to false if you do not want to have the mod's name written at the front of this message</param>
        public void WriteLine(object message, bool writeModName = true);
    }
}
