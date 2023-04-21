using System;
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
        public float DeltaTime { get; private set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public double TotalMilliseconds { get; private set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DateTime Now => DateTime.Now;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public double TotalSeconds => TotalMilliseconds / 1000;

        /// <summary>
        /// Used to track time between update calls.
        /// </summary>
        protected Stopwatch stopwatch;

        /// <summary>
        /// The last time the stopwatch was used for checking time. Stores the total elapsed time.
        /// </summary>
        protected double lastElapsedTime;

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
            gameLoop.OnUpdate.Before += Update;
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
        protected virtual float CalcDeltaTime()
        {
            float deltaTime = ((float)TotalMilliseconds - (float)lastElapsedTime) / 1000; // dividing by 1000 because ther are 1000 ms in 1 second
            lastElapsedTime = stopwatch.ElapsedMilliseconds;
            return deltaTime;
        }
    }
}
