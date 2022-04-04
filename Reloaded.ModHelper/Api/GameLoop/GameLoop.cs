﻿using System;

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