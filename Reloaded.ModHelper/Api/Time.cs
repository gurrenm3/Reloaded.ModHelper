using System.Diagnostics;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Provides information about Time. Must be connected to a <see cref="GameLoop"/> to function properly.
    /// </summary>
    public class Time
    {
        /// <summary>
        /// The interval in seconds from the last frame to the current one.
        /// </summary>
        public double DeltaTime { get; private set; } = -1;

        /// <summary>
        /// The total number of frames since the start of the game.
        /// </summary>
        public long FrameCount { get; private set; } = -1;

        /// <summary>
        /// The total number of milliseconds that have passed since initialization.
        /// </summary>
        public double TotalMilliseconds { get; private set; } = -1;

        /// <summary>
        /// The total number of seconds that have passed since initialization.
        /// </summary>
        public double TotalSeconds { get; private set; } = -1;

        private Stopwatch stopwatch; // used to track time between update calls
        private long lastElapsedTime; // the last time the stopwatch was used for checking time. Stores the total elapsed time.
        private bool isInitialized;

        /// <summary>
        /// Initializes this Time object with a Gameloop, allowing it to update properly.
        /// </summary>
        /// <param name="gameLoop"></param>
        public void Initialize(GameLoop gameLoop)
        {
            if (isInitialized) return;
            
            stopwatch = new Stopwatch();
            stopwatch.Start();
            gameLoop.OnUpdate.AddListener(() => Update());
            isInitialized = true;
        }

        private void Update()
        {
            TotalMilliseconds = stopwatch.ElapsedMilliseconds;
            TotalSeconds = TotalMilliseconds * 1000;
            DeltaTime = CalcDeltaTime();
            FrameCount++;
        }

        private double CalcDeltaTime()
        {
            double deltaTime = (TotalMilliseconds - (double)lastElapsedTime) / 1000; // dividing by 1000 because ther are 1000 ms in 1 second
            lastElapsedTime = stopwatch.ElapsedMilliseconds;
            return deltaTime;
        }
    }
}
