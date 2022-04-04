using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// 
    /// </summary>
    public class ModLogger
    {
        /// <summary>
        /// The color that this mod's name should be.
        /// </summary>
        public Color modNameColor = Color.LightGreen;

        /// <summary>
        /// Instance of the logger.
        /// </summary>
        protected ILogger _logger;

        /// <summary>
        /// Info about this mod.
        /// </summary>
        protected IModConfigV1 _config;

        public ModLogger(IModConfigV1 config, ILogger logger)
        {
            _config = config;
            _logger = logger;
        }

        /// <summary>
        /// Write's this mod's name to the console.
        /// </summary>
        protected void WriteModName()
        {
            _logger.Write($"[{_config.ModName}]: ", modNameColor);
        }

        /// <summary>
        /// Write a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="insertModName">Set to true if you want the mod's name inserted at the beginning
        /// of the message.</param>
        public void Write(object message, bool insertModName = false)
        {
            Write(message.ToString(), insertModName);
        }

        /// <summary>
        /// Write a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="insertModName">Set to true if you want the mod's name inserted at the beginning
        /// of the message.</param>
        public void Write(string message, bool insertModName = false)
        {
            if (insertModName)
                WriteModName();

            _logger.Write(message);
        }

        /// <summary>
        /// Write a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="messageColor">The color of the message.</param>
        /// <param name="insertModName">Set to true if you want the mod's name inserted at the beginning
        /// of the message.</param>
        public void Write(object message, Color messageColor, bool insertModName = false)
        {
            Write(message.ToString(), messageColor, insertModName);
        }

        /// <summary>
        /// Write a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="messageColor">The color of the message.</param>
        /// <param name="insertModName">Set to true if you want the mod's name inserted at the beginning
        /// of the message.</param>
        public void Write(string message, Color messageColor, bool insertModName = false)
        {
            if (insertModName)
                WriteModName();

            _logger.Write(message, messageColor);
        }

        /// <summary>
        /// Write a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        public void WriteLine(object message)
        {
            WriteLine(message.ToString());
        }

        /// <summary>
        /// Write a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        public void WriteLine(string message)
        {
            WriteModName();
            _logger.WriteLine(message);
        }

        /// <summary>
        /// Write a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="messageColor">The color of the message.</param>
        public void WriteLine(object message, Color messageColor)
        {
            WriteLine(message.ToString(), messageColor);
        }

        /// <summary>
        /// Write a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="messageColor">The color of the message.</param>
        public void WriteLine(string message, Color messageColor)
        {
            WriteModName();
            _logger.WriteLine(message, messageColor);
        }
    }
}
