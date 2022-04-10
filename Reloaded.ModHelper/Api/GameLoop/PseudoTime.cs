using System.Diagnostics;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Provides information about the passage of time within a <see cref="PseudoGameLoop"/>.
    /// </summary>
    public class PseudoTime : ITime
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public double DeltaTime => _deltaTime;
        private double _deltaTime;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public double TotalMilliseconds => _totalMilliseconds;
        private double _totalMilliseconds;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public double TotalSeconds => TotalMilliseconds * 1000;

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
        public PseudoTime(IGameLoop gameLoop)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            gameLoop.OnUpdate.Prefix += Update;
            isInitialized = true;
        }

        /// <summary>
        /// Method that actually updates all Time info.
        /// </summary>
        protected virtual void Update()
        {
            _totalMilliseconds = stopwatch.ElapsedMilliseconds;
            _deltaTime = CalcDeltaTime();
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
