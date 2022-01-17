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
        public ModEvent OnUpdate { get; protected set; } = new ModEvent();
        
        /// <summary>
        /// 
        /// </summary>
        public Time Time { get; protected set; } = new Time();


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
        public abstract GameLoop Create();
    }
}
