using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// An interface for making/using Game Loops
    /// </summary>
    public interface IGameLoop
    {
        /// <summary>
        /// Called each time the update loop executes.
        /// </summary>
        public IModEventHook OnUpdate { get; set; }

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
    }
}
