using System;

namespace Reloaded.ModHelper
{
    public static class ConsoleUtil
    {
        /// <summary>
        /// Uses Console.WriteLine to log messages.
        /// </summary>
        /// <param name="ex">Exception to log.</param>
        public static void LogException(Exception ex)
        {
            int exceptionCount = 0;
            var currentException = ex;
            while (currentException != null)
            {
                if (exceptionCount >= 5) // don't want an infinite loop
                    break;

                string msgTitle = exceptionCount == 0 ? "Exception Message" : "Inner Exception";
                LogError($"\n{msgTitle}: {currentException.Message}\nStack Trace: {currentException.StackTrace}");
                currentException = currentException.InnerException;
                exceptionCount++;
            }            
        }

        /// <summary>
        /// Uses Console.WriteLine to log an error
        /// </summary>
        /// <param name="message"></param>
        public static void LogError(string message)
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

        /// <summary>
        /// Uses Console.WriteLine to log a warning.
        /// </summary>
        /// <param name="message"></param>
        public static void LogWarning(string message)
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

        /// <summary>
        /// Uses Console.WriteLine to log a notice.
        /// </summary>
        /// <param name="message"></param>
        public static void LogNotice(string message)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{DateTime.Now.ToString("HH:mm:ss")}]");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" [Notice]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" {message}");
            Console.ForegroundColor = originalColor;
        }

        /// <summary>
        /// Uses Console.WriteLine to log a message.
        /// </summary>
        /// <param name="message"></param>
        public static void Log(string message)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{DateTime.Now.ToString("HH:mm:ss")}]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" {message}");
            Console.ForegroundColor = originalColor;
        }
    }
}
