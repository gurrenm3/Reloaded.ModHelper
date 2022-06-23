using System;

namespace Reloaded.ModHelper
{
    public static class ConsoleUtil
    {
        /// <summary>
        /// Uses Console.WriteLine to log an error
        /// </summary>
        /// <param name="message"></param>
        public static void LogError(string message)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[Exception occured]");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" {message}");
            Console.ForegroundColor = originalColor;
        }
    }
}
