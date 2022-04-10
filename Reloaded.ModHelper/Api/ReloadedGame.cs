namespace Reloaded.ModHelper
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class ReloadedGame : IReloadedGame
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IGameLoop GameLoop { get; protected set; }
    }
}
