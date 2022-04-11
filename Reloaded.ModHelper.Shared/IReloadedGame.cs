namespace Reloaded.ModHelper
{
    /// <summary>
    /// Manages info about the game that's currently being modded.
    /// </summary>
    public interface IReloadedGame
    {
        /// <summary>
        /// Represents the game loop.
        /// </summary>
        public IGameLoop GameLoop { get; }
    }
}
