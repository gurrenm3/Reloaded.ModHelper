namespace Reloaded.ModHelper
{
    public class DebugLogger
    {
        internal static bool Enabled { get; set; } = false;

        IModLogger _logger;
        int count;

        public DebugLogger(IModLogger logger)
        {
            _logger = logger;

/*#if DEBUG
            Enabled = true;
            _logger.WriteLine("Debug Logger has been enabled. This is used to track the state" +
                " of your mod while your debugging it. You may see a lot more" +
                " console messages as a result. Build your mod in Release mode if you don't" +
                " want to see it");
#endif*/
        }

        public void WriteLine(string message)
        {
            if (!Enabled)
                return;

            _logger.WriteLine(message);
        }
    }
}
