using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System.Drawing;
using System.Text;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A Logger that automatically adds a mod's name to each message.
    /// </summary>
    public class ModLogger : IModLogger
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModConfigV1 ModInfo { get; private set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ILogger BaseLogger { get; private set; }

        /// <summary>
        /// The color to set the Mod's name to.
        /// </summary>
        public Color ModNameColor { get; set; } = Color.FromArgb(126, 244, 105);


        /// <summary>
        /// Creates a new instance of <see cref="ModLogger"/>.
        /// </summary>
        /// <param name="baseLogger"></param>
        /// <param name="modInfo"></param>
        public ModLogger(ILogger baseLogger, IModConfigV1 modInfo)
        {
            BaseLogger = baseLogger;
            ModInfo = modInfo;
        }


        #region ModLogger.Write

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Write(bool message, LogType logType = LogType.Normal) => Write(message.ToString(), logType);
        
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Write(int message, LogType logType = LogType.Normal) => Write(message.ToString(), logType);
        
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Write(long message, LogType logType = LogType.Normal) => Write(message.ToString(), logType);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Write(double message, LogType logType = LogType.Normal) => Write(message.ToString(), logType);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Write(float message, LogType logType = LogType.Normal) => Write(message.ToString(), logType);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Write(decimal message, LogType logType = LogType.Normal) => Write(message.ToString(), logType);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Write(byte message, LogType logType = LogType.Normal) => Write(message.ToString(), logType);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Write(char message, LogType logType = LogType.Normal) => Write(message.ToString(), logType);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Write(string message, LogType logType = LogType.Normal)
        {
            WriteModName(ModNameColor);
            var logColor = GetLogColor(logType);
            BaseLogger.Write(message, logColor);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Write(char[] message, LogType logType = LogType.Normal)
        {
            var sr = new StringBuilder();
            message.ForEach(c => sr.Append(c));
            Write(sr.ToString());
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Write(byte[] message, LogType logType = LogType.Normal)
        {
            var sr = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                sr.Append(message[i]);
                if (i < message.Length - 1) // add space between bytes for readability, except at the end
                    sr.Append(" ");
            }
            Write(sr.ToString());
        }

        #endregion


        #region ModLogger.WriteLine

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(bool message, LogType logType = LogType.Normal) => WriteLine(message.ToString(), logType);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(int message, LogType logType = LogType.Normal) => WriteLine(message.ToString(), logType);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(double message, LogType logType = LogType.Normal) => WriteLine(message.ToString(), logType);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(long message, LogType logType = LogType.Normal) => WriteLine(message.ToString(), logType);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(float message, LogType logType = LogType.Normal) => WriteLine(message.ToString(), logType);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(decimal message, LogType logType = LogType.Normal) => WriteLine(message.ToString(), logType);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(byte message, LogType logType = LogType.Normal) => WriteLine(message.ToString(), logType);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(char message, LogType logType = LogType.Normal) => WriteLine(message.ToString(), logType);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(string message, LogType logType = LogType.Normal)
        {
            WriteModName(ModNameColor);
            var logColor = GetLogColor(logType);
            BaseLogger.WriteLine(message, logColor);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(byte[] message, LogType logType = LogType.Normal)
        {
            var sr = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                sr.Append(message[i]);
                if (i < message.Length - 1) // add space between bytes for readability, except at the end
                    sr.Append(" ");
            }
            WriteLine(sr.ToString());
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(char[] message, LogType logType = LogType.Normal)
        {
            var sr = new StringBuilder();
            message.ForEach(c => sr.Append(c));
            WriteLine(sr.ToString());
        }

        #endregion


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteAsync(string message, LogType logType = LogType.Normal)
        {
            WriteModName(ModNameColor);
            var logColor = GetLogColor(logType);
            BaseLogger.WriteAsync(message, logColor);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLineAsync(string message, LogType logType = LogType.Normal)
        {
            WriteModName(ModNameColor);
            var logColor = GetLogColor(logType);
            BaseLogger.WriteLineAsync(message, logColor);
        }

        private void WriteModName(Color color) => BaseLogger.Write($"[{ModInfo.ModName}] ", color);

        private Color GetLogColor(LogType logType)
        {
            Color logColor = BaseLogger.TextColor;
            switch (logType)
            {
                case LogType.Warning:
                    logColor = Color.Yellow;
                    break;
                case LogType.Error:
                    logColor = Color.Red;
                    break;
                default:
                    break;
            }
            return logColor;
        }
    }
}
