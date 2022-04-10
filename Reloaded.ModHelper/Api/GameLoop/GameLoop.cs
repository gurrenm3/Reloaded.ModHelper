using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A class for creating and managing a Game's loop.
    /// </summary>
    public abstract class GameLoop : IGameLoop
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEventHook OnUpdate { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public abstract ITime Time { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public abstract long LoopCount { get; }


        /// <summary>
        /// Creates a <see cref="GameLoop"/> with default implementation.
        /// </summary>
        public GameLoop()
        {
            
        }

        /// <summary>
        /// Used to create the actual loop. If you are hooking the game's actual loop than you would
        /// do that here.
        /// </summary>
        public abstract IGameLoop Initialize();
    }
}