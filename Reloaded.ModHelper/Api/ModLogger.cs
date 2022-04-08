using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System.Drawing;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class ModLogger : IModLogger
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

        /// <summary>
        /// Initializes a <see cref="ModLogger"/> with info about this mod and an instance of the Reloaded Logger.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="logger"></param>
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
            Write($"[{_config.ModName}] ", modNameColor);
        }

        /// <summary>
        /// Write's this mod's name to the console.
        /// </summary>
        protected void WriteModNameAsync()
        {
            WriteAsync($"[{_config.ModName}] ", modNameColor);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="logLevel"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void Write(string message, LogLevel logLevel, bool writeModName = false)
        {
            Write(message, GetColorFromLogLevel(logLevel), writeModName);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="logLevel"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void Write(object message, LogLevel logLevel, bool writeModName = false)
        {
            Write(message, GetColorFromLogLevel(logLevel), writeModName);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="color"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void Write(string message, Color color, bool writeModName = false)
        {
            if (writeModName)
                WriteModName();

            _logger.Write(message, color);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="color"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void Write(object message, Color color, bool writeModName = false)
        {
            if (writeModName)
                WriteModName();

            _logger.Write(message.ToString(), color);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void Write(string message, bool writeModName = false)
        {
            if (writeModName)
                WriteModName();

            _logger.Write(message);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void Write(object message, bool writeModName = false)
        {
            if (writeModName)
                WriteModName();

            _logger.Write(message.ToString());
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="logLevel"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteAsync(string message, LogLevel logLevel, bool writeModName = false)
        {
            WriteAsync(message, GetColorFromLogLevel(logLevel), writeModName);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="logLevel"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteAsync(object message, LogLevel logLevel, bool writeModName = false)
        {
            WriteAsync(message, GetColorFromLogLevel(logLevel), writeModName);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="color"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteAsync(string message, Color color, bool writeModName = false)
        {
            if (writeModName)
                WriteModNameAsync();

            _logger.WriteAsync(message, color);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="color"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteAsync(object message, Color color, bool writeModName = false)
        {
            if (writeModName)
                WriteModNameAsync();

            WriteModNameAsync();
            _logger.WriteAsync(message.ToString(), color);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteAsync(string message, bool writeModName = false)
        {
            if (writeModName)
                WriteModNameAsync();

            _logger.WriteAsync(message);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteAsync(object message, bool writeModName = false)
        {
            if (writeModName)
                WriteModNameAsync();

            _logger.WriteAsync(message.ToString());
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="logLevel"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteLine(string message, LogLevel logLevel, bool writeModName = true)
        {
            WriteLine(message, GetColorFromLogLevel(logLevel), writeModName);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="logLevel"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteLine(object message, LogLevel logLevel, bool writeModName = true)
        {
            WriteLine(message, GetColorFromLogLevel(logLevel), writeModName);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="color"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteLine(string message, Color color, bool writeModName = true)
        {
            if (writeModName)
                WriteModName();

            _logger.WriteLine(message, color);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="color"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteLine(object message, Color color, bool writeModName = true)
        {
            if (writeModName)
                WriteModName();

            _logger.WriteLine(message.ToString(), color);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteLine(string message, bool writeModName = true)
        {
            if (writeModName)
                WriteModName();

            _logger.WriteLine(message);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteLine(object message, bool writeModName = true)
        {
            if (writeModName)
                WriteModName();

            _logger.WriteLine(message.ToString());
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="logLevel"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteLineAsync(string message, LogLevel logLevel, bool writeModName = true)
        {
            WriteLineAsync(message, GetColorFromLogLevel(logLevel), writeModName);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="logLevel"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteLineAsync(object message, LogLevel logLevel, bool writeModName = true)
        {
            WriteLineAsync(message, GetColorFromLogLevel(logLevel), writeModName);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="color"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteLineAsync(string message, Color color, bool writeModName = true)
        {
            if (writeModName)
                WriteModNameAsync();

            _logger.WriteLineAsync(message, color);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="color"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteLineAsync(object message, Color color, bool writeModName = true)
        {
            if (writeModName)
                WriteModNameAsync();

            _logger.WriteLineAsync(message.ToString(), color);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteLineAsync(string message, bool writeModName = true)
        {
            if (writeModName)
                WriteModNameAsync();

            _logger.WriteLineAsync(message);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="message"><inheritdoc/></param>
        /// <param name="writeModName"><inheritdoc/></param>
        public void WriteLineAsync(object message, bool writeModName = true)
        {
            if (writeModName)
                WriteModNameAsync();

            _logger.WriteLineAsync(message.ToString());
        }

        private Color GetColorFromLogLevel(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Error:
                    return Color.Yellow;
                case LogLevel.Warning:
                    return Color.Red;
                default:
                    return _logger.TextColor;
            }
        }
    }
}
