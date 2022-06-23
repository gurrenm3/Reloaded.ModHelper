using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System;
using System.Drawing;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class ModLogger : IModLogger
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string ModName => _modName;
        private string _modName;

        /// <summary>
        /// The color that this mod's name should be.
        /// </summary>
        public Color modNameColor = Color.LightBlue;//Color.LightGreen;//Color.Coral

        /// <summary>
        /// The color that the time of the log should be.
        /// </summary>
        public Color timeColor = Color.LawnGreen; //Color.Aqua;//Color.Brown;//Color.Chartreuse;

        /// <summary>
        /// Instance of the logger.
        /// </summary>
        protected ILogger _logger;

        /// <summary>
        /// Info about this mod.
        /// </summary>
        protected IModConfigV1 _config;

        private bool isNewLine = true;

        /// <summary>
        /// Initializes a <see cref="ModLogger"/> with info about this mod and an instance of the Reloaded Logger.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="logger"></param>
        public ModLogger(IModConfigV1 config, ILogger logger)
        {
            _config = config;
            _logger = logger;
            _modName = _config.ModName;
        }

        /// <summary>
        /// Write's this mod's name to the console.
        /// </summary>
        protected void WriteModName()
        {
            _logger.WriteAsync($"[{_config.ModName}] ", modNameColor);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="logLevel"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void Write(string message, LogLevel logLevel, bool writeModName = false)
        {
            string logLevelMsg = logLevel != LogLevel.CheatEngine ? logLevel.ToString() : "For CheatEngine Users";
            Write($"[{logLevelMsg}] {message}", GetColorFromLogLevel(logLevel), writeModName);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="logLevel"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void Write(object message, LogLevel logLevel, bool writeModName = false)
        {
            string logLevelMsg = logLevel != LogLevel.CheatEngine ? logLevel.ToString() : "For CheatEngine Users";
            Write($"[{logLevelMsg}] {message}", GetColorFromLogLevel(logLevel), writeModName);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="color"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void Write(string message, Color color, bool writeModName = false)
        {
            if (isNewLine)
                _logger.WriteAsync($"[{DateTime.Now.ToString("HH:mm:ss")}] ", timeColor);

            if (writeModName)
                WriteModName();

            _logger.WriteAsync(message, color);
            isNewLine = false;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="color"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void Write(object message, Color color, bool writeModName = false)
        {
            if (isNewLine)
                _logger.WriteAsync($"[{DateTime.Now.ToString("HH:mm:ss")}] ", timeColor);

            if (writeModName)
                WriteModName();

            _logger.WriteAsync(message.ToString(), color);
            isNewLine = false;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void Write(string message, bool writeModName = false)
        {
            if (isNewLine)
                _logger.WriteAsync($"[{DateTime.Now.ToString("HH:mm:ss")}] ", timeColor);

            if (writeModName)
                WriteModName();

            _logger.WriteAsync(message);
            isNewLine = false;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void Write(object message, bool writeModName = false)
        {
            if (isNewLine)
                _logger.WriteAsync($"[{DateTime.Now.ToString("HH:mm:ss")}] ", timeColor);

            if (writeModName)
                WriteModName();

            _logger.WriteAsync(message.ToString());
            isNewLine = false;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="logLevel"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteLine(string message, LogLevel logLevel, bool writeModName = true)
        {
            string logLevelMsg = logLevel != LogLevel.CheatEngine ? logLevel.ToString() : "For CheatEngine Users";
            WriteLine($"[{logLevelMsg}] {message}", GetColorFromLogLevel(logLevel), writeModName);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="logLevel"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteLine(object message, LogLevel logLevel, bool writeModName = true)
        {
            string logLevelMsg = logLevel != LogLevel.CheatEngine ? logLevel.ToString() : "For CheatEngine Users";
            WriteLine($"[{logLevelMsg}] {message}", GetColorFromLogLevel(logLevel), writeModName);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="color"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteLine(string message, Color color, bool writeModName = true)
        {
            if (isNewLine)
                _logger.WriteAsync($"[{DateTime.Now.ToString("HH:mm:ss")}] ", timeColor);

            if (writeModName)
                WriteModName();

            _logger.WriteLineAsync(message, color);
            isNewLine = true;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="color"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteLine(object message, Color color, bool writeModName = true)
        {
            string msgToPrint = message.ToString();

            if (isNewLine)
                _logger.WriteAsync($"[{DateTime.Now.ToString("HH:mm:ss")}] ", timeColor);

            if (writeModName)
                WriteModName();

            _logger.WriteLineAsync(msgToPrint, color);
            isNewLine = true;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteLine(string message, bool writeModName = true)
        {
            if (isNewLine)
                _logger.WriteAsync($"[{DateTime.Now.ToString("HH:mm:ss")}] ", timeColor);

            if (writeModName)
                WriteModName();

            _logger.WriteLineAsync(message);
            isNewLine = true;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteLine(object message, bool writeModName = true)
        {
            string msgToPrint = message.ToString();

            if (isNewLine)
                _logger.WriteAsync($"[{DateTime.Now.ToString("HH:mm:ss")}] ", timeColor);

            if (writeModName)
                WriteModName();

            _logger.WriteLineAsync(msgToPrint);
            isNewLine = true;
        }

        private Color GetColorFromLogLevel(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Error:
                    return Color.Red;
                case LogLevel.Warning:
                    return Color.Yellow;
                default:
                    return _logger.TextColor;
            }
        }
    }
}
