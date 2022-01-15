namespace Reloaded.ModHelper
{
    /// <summary>
    /// A <see cref="GameLoop"/> that isn't connected to the Game's actual loop.
    /// <br/>Using this will allow access to Update behaviors but it won't be in sync with the game.
    /// To have a <see cref="GameLoop"/> that is syncronized with the game you will need to create a class
    /// that impliments <see cref="GameLoop"/> and hooks the Game's update loop.
    /// </summary>
    public class PseudoGameLoop : GameLoop
    {
        /// <summary>
        /// Creates a default instance of a pseudo-GameLoop.
        /// </summary>
        public PseudoGameLoop() : base()
        {

        }

        /// <summary>
        /// Used to create the actual loop.
        /// </summary>
        protected override void CreateLoop()
        {
            
        }
    }
}
