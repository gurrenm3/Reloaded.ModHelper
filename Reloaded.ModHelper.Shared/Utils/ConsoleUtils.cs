using System;
using System.Drawing;

namespace Reloaded.ModHelper
{
    public static class ConsoleUtils
    {
        /// <summary>
        /// Uses Console.WriteLine to log messages.
        /// </summary>
        /// <param name="ex">Exception to log.</param>
        public static void WriteException(Exception ex)
        {
            int exceptionCount = 0;
            var currentException = ex;
            while (currentException != null)
            {
                if (exceptionCount >= 5) // don't want an infinite loop
                    break;

                string msgTitle = exceptionCount == 0 ? "Exception Message" : "Inner Exception";
                WriteError($"\n{msgTitle}: {currentException.Message}\nStack Trace: {currentException.StackTrace}");
                currentException = currentException.InnerException;
                exceptionCount++;
            }            
        }

        /// <summary>
        /// Uses Console.WriteLine to log an error
        /// </summary>
        /// <param name="message"></param>
        public static void WriteError(string message)
        {
            if (IModLogger.Instance != null)
            {
                IModLogger.Instance.WriteLine(message, LogLevel.Error);
            }
            else
            {
                var originalColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"[{DateTime.Now.ToString("HH:mm:ss")}]");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" [Error]");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($" {message}");
                Console.ForegroundColor = originalColor;
            }
        }

        /// <summary>
        /// Uses Console.WriteLine to log a warning.
        /// </summary>
        /// <param name="message"></param>
        public static void WriteWarning(string message)
        {
            if (IModLogger.Instance != null)
            {
                IModLogger.Instance.WriteLine(message, LogLevel.Warning);
            }
            else
            {
                var originalColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"[{DateTime.Now.ToString("HH:mm:ss")}]");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" [Warning]");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($" {message}");
                Console.ForegroundColor = originalColor;
            }
        }

        public static void WriteLine(object message)
        {
            WriteLine(message.ToString());
        }

        /// <summary>
        /// Uses Console.WriteLine to log a message.
        /// </summary>
        /// <param name="message"></param>
        public static void WriteLine(string message)
        {
            if (IModLogger.Instance != null)
            {
                IModLogger.Instance.WriteLine(message);
            }
            else
            {
                var originalColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"[{DateTime.Now.ToString("HH:mm:ss")}]");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($" {message}");
                Console.ForegroundColor = originalColor;
            }
        }

        public static void WriteLine(string message, Color color)
        {
            if (IModLogger.Instance != null)
            {
                IModLogger.Instance.WriteLine(message, color, true);
                return;
            }
            ConsoleColor foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[" + DateTime.Now.ToString("HH:mm:ss") + "]");
            Console.ForegroundColor = ConvertColor(color);
            Console.WriteLine(" " + message);
            Console.ForegroundColor = foregroundColor;
        }

        public static ConsoleColor ConvertColor(Color color)
        {
            int closestIndex = 0;
            double closestDistance = double.MaxValue;
            foreach (object obj in Enum.GetValues(typeof(ConsoleColor)))
            {
                ConsoleColor consoleColor = (ConsoleColor)obj;
                Color consoleColorRgb = Color.FromName(consoleColor.ToString());
                double distance = ColorDistance(color, consoleColorRgb);
                if (distance < closestDistance)
                {
                    closestIndex = (int)consoleColor;
                    closestDistance = distance;
                }
            }
            return (ConsoleColor)closestIndex;
        }

        private static double ColorDistance(Color color1, Color color2)
        {
            double num = (double)(color1.R - color2.R);
            double greenDifference = (double)(color1.G - color2.G);
            double blueDifference = (double)(color1.B - color2.B);
            return Math.Sqrt(num * num + greenDifference * greenDifference + blueDifference * blueDifference);
        }
    }
}
