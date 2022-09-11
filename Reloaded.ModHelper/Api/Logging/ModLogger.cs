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
        public string ModName { get; init; }

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
        public ILogger LoggerInstance { get; init; }

        /// <summary>
        /// Info about this mod.
        /// </summary>
        public IModConfigV1 Config { get; init; }

        private bool isNewLine = true;

        public ModLogger()
        {

        }

        /// <summary>
        /// Initializes a <see cref="ModLogger"/> with info about this mod and an instance of the Reloaded Logger.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="logger"></param>
        public ModLogger(IModConfigV1 config, ILogger logger)
        {
            Config = config;
            LoggerInstance = logger;
            ModName = Config.ModName;
        }

        /// <summary>
        /// Write's this mod's name to the console.
        /// </summary>
        protected void WriteModName()
        {
            LoggerInstance.WriteAsync($"[{Config.ModName}] ", modNameColor);
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
                LoggerInstance.WriteAsync($"[{DateTime.Now.ToString("HH:mm:ss")}] ", timeColor);

            if (writeModName)
                WriteModName();

            LoggerInstance.WriteAsync(message, color);
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
                LoggerInstance.WriteAsync($"[{DateTime.Now.ToString("HH:mm:ss")}] ", timeColor);

            if (writeModName)
                WriteModName();

            LoggerInstance.WriteAsync(message.ToString(), color);
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
                LoggerInstance.WriteAsync($"[{DateTime.Now.ToString("HH:mm:ss")}] ", timeColor);

            if (writeModName)
                WriteModName();

            LoggerInstance.WriteAsync(message);
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
                LoggerInstance.WriteAsync($"[{DateTime.Now.ToString("HH:mm:ss")}] ", timeColor);

            if (writeModName)
                WriteModName();

            LoggerInstance.WriteAsync(message.ToString());
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
            string logLevelMsg = logLevel != LogLevel.CheatEngine ? $"[{logLevel}] " : "[For CheatEngine Users] ";
            logLevelMsg = logLevel == LogLevel.Normal ? "" : logLevelMsg;
            WriteLine($"{logLevelMsg}{message}", GetColorFromLogLevel(logLevel), writeModName);
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
                LoggerInstance.WriteAsync($"[{DateTime.Now.ToString("HH:mm:ss")}] ", timeColor);

            if (writeModName)
                WriteModName();

            LoggerInstance.WriteLineAsync(message, color);
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
                LoggerInstance.WriteAsync($"[{DateTime.Now.ToString("HH:mm:ss")}] ", timeColor);

            if (writeModName)
                WriteModName();

            LoggerInstance.WriteLineAsync(msgToPrint, color);
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
                LoggerInstance.WriteAsync($"[{DateTime.Now.ToString("HH:mm:ss")}] ", timeColor);

            if (writeModName)
                WriteModName();

            LoggerInstance.WriteLineAsync(message);
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
                LoggerInstance.WriteAsync($"[{DateTime.Now.ToString("HH:mm:ss")}] ", timeColor);

            if (writeModName)
                WriteModName();

            LoggerInstance.WriteLineAsync(msgToPrint);
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
                    return LoggerInstance.TextColor;
            }
        }
    }
}
