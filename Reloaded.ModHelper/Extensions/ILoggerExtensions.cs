using Reloaded.Mod.Interfaces;
using System.Drawing;

namespace Reloaded.ModHelper
{
	/// <summary>
	/// Extension methods for Reloaded Logger
	/// </summary>
	public static class ILoggerExtensions
	{
		/// <summary>
		/// Writes a new line to the console output
		/// </summary>
		/// <param name="iLogger"></param>
		/// <param name="message">Message to print</param>
		public static void WriteLine(this ILogger iLogger, bool message)
		{
			iLogger.WriteLine(message.ToString());
		}

		/// <summary>
		/// Writes a new line to the console output
		/// </summary>
		/// <param name="iLogger"></param>
		/// <param name="message">Message to print</param>
		/// <param name="color">The color to print the message in</param>
		public static void WriteLine(this ILogger iLogger, bool message, Color color)
        {
            iLogger.WriteLine(message.ToString(), color);
        }

		/// <summary>
		/// Writes a new line to the console output
		/// </summary>
		/// <param name="iLogger"></param>
		/// <param name="message">Message to print</param>
		public static void WriteLine(this ILogger iLogger, char message)
		{
			iLogger.WriteLine(message.ToString());
		}

		/// <summary>
		/// Writes a new line to the console output
		/// </summary>
		/// <param name="iLogger"></param>
		/// <param name="message">Message to print</param>
		/// <param name="color">The color to print the message in</param>
		public static void WriteLine(this ILogger iLogger, char message, Color color)
		{
			iLogger.WriteLine(message.ToString(), color);
		}
	}
}