using System.Diagnostics;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Provides information about Time. Must be connected to a <see cref="GameLoop"/> to function properly.
    /// </summary>
    public class Time
    {
        /// <summary>
        /// How much time has passed, in seconds, between the last GameLoop iteration and the current one.
        /// </summary>
        public double DeltaTime { get; protected set; }

        /// <summary>
        /// The total number of milliseconds that have passed since initialization.
        /// </summary>
        public double TotalMilliseconds { get; protected set; }

        /// <summary>
        /// The total number of seconds that have passed since initialization.
        /// </summary>
        public double TotalSeconds { get => TotalMilliseconds * 1000; }

        /// <summary>
        /// Used to track time between update calls.
        /// </summary>
        protected Stopwatch stopwatch;

        /// <summary>
        /// The last time the stopwatch was used for checking time. Stores the total elapsed time.
        /// </summary>
        protected long lastElapsedTime;

        /// <summary>
        /// Has this object already been initialized?
        /// </summary>
        protected bool isInitialized;

        /// <summary>
        /// Creates an instance of this class with a Gameloop, allowing it to update properly.
        /// </summary>
        /// <param name="gameLoop">The game loop to initialize with, allowing access to Time info about the loop.</param>
        public Time(GameLoop gameLoop)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            gameLoop.Run(Update);
            isInitialized = true;
        }

        /// <summary>
        /// Method that actually updates all Time info.
        /// </summary>
        protected virtual void Update()
        {
            TotalMilliseconds = stopwatch.ElapsedMilliseconds;
            DeltaTime = CalcDeltaTime();
        }

        /// <summary>
        /// Used to calculate the time since the last loop iteration, otherwise known as delta time.
        /// </summary>
        /// <returns>The time since the last loop iteration, known as delta time.</returns>
        protected virtual double CalcDeltaTime()
        {
            double deltaTime = (TotalMilliseconds - (double)lastElapsedTime) / 1000; // dividing by 1000 because ther are 1000 ms in 1 second
            lastElapsedTime = stopwatch.ElapsedMilliseconds;
            return deltaTime;
        }
    }
}
