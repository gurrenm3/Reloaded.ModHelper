namespace Reloaded.ModHelper
{
    /// <summary>
    /// A class for creating and managing a Game's loop.
    /// </summary>
    public abstract class GameLoop
    {
        /// <summary>
        /// Mod event for the Game Loop. Allows for code to subscribe to this loop.
        /// </summary>
        public ModEvent OnUpdate = new ModEvent();

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
        protected abstract void CreateLoop();

        /// <summary>
        /// Used to fire the update loop.
        /// </summary>
        protected virtual void TriggerUpdate()
        {
            OnUpdate?.Invoke();
        }
    }
}
