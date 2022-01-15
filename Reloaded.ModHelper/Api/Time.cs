using System.Diagnostics;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Provides information about Time.
    /// </summary>
    public static class Time
    {
        /// <summary>
        /// The interval in seconds from the last frame to the current one.
        /// </summary>
        public static double DeltaTime { get; private set; }

        /// <summary>
        /// The total number of frames since the start of the game.
        /// </summary>
        public static long FrameCount { get; private set; }

        /// <summary>
        /// The total number of milliseconds that have passed since initialization.
        /// </summary>
        public static double TotalMilliseconds { get; private set; }

        /// <summary>
        /// The total number of seconds that have passed since initialization.
        /// </summary>
        public static double TotalSeconds { get; private set; }

        private static Stopwatch stopwatch; // used to track time between update calls
        private static long lastElapsedTime; // the last time the stopwatch was used for checking time. Stores the total elapsed time.
        private static bool isInitialized; // used to prevent accidentally initializing more than once

        /// <summary>
        /// Initialize the Time class with a <see cref="GameLoop"/>, allowing it to update properly.
        /// </summary>
        /// <param name="gameLoop">The <see cref="GameLoop"/> to initialize the class with. Needed to properly update time information.</param>
        public static void Initialize(GameLoop gameLoop)
        {
            if (isInitialized) return;

            stopwatch = new Stopwatch();
            stopwatch.Start();
            gameLoop.OnUpdate.AddListener(() => Update());

            isInitialized = true;
        }

        private static void Update()
        {
            TotalMilliseconds = stopwatch.ElapsedMilliseconds;
            TotalSeconds = TotalMilliseconds * 1000;
            DeltaTime = CalcDeltaTime();
            FrameCount++;
        }

        private static double CalcDeltaTime()
        {
            double deltaTime = (TotalMilliseconds - (double)lastElapsedTime) / 1000; // dividing by 1000 because ther are 1000 ms in 1 second
            lastElapsedTime = stopwatch.ElapsedMilliseconds;
            return deltaTime;
        }
    }
}
