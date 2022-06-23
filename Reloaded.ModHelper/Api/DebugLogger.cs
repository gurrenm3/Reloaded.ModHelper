namespace Reloaded.ModHelper
{
    public class DebugLogger
    {
        public bool Enabled { get; set; } = true;
        IModLogger _logger;
        int count;

        public DebugLogger(IModLogger logger)
        {
            _logger = logger;
        }

        public void Log()
        {
            if (!Enabled)
                return;

            _logger.WriteLine(count);
            count++;
        }
    }
}
