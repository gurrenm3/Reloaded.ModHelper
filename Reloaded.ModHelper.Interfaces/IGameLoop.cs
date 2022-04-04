using System;

namespace Reloaded.ModHelper
{
    public interface IGameLoop
    {
        /// <summary>
        /// Contains information about the Time of this Game Loop, for example the time between frames.
        /// </summary>
        public abstract ITime Time { get; }

        /// <summary>
        /// The total number of times the loop has run.
        /// </summary>
        public abstract long LoopCount { get; }

        /// <summary>
        /// Used to create the actual loop. If you are hooking the game's actual loop than you would
        /// do that here.
        /// </summary>
        public abstract IGameLoop Initialize();

        /// <summary>
        /// Adds an Action to run each time the loop runs.
        /// </summary>
        /// <param name="codeToRun"></param>
        public abstract void AddListener(Action codeToRun);

        /// <summary>
        /// Removes an Action from the game loop so it no longer runs when the loop does.
        /// </summary>
        /// <param name="codeToRun"></param>
        /// <returns></returns>
        public abstract bool RemoveListener(Action codeToRun);
    }
}
