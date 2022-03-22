using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A base class for reloaded2 mods
    /// </summary>
    public class ReloadedMod : IRegisterHooks
    {
        /// <summary>
        /// The instance of the logger.
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public ReloadedMod(ILogger _logger)
        {
            Logger = _logger;
        }

        /// <summary>
        /// Call this to easily register hooks into the game.
        /// </summary>
        /// <param name="hooksInstance"></param>
        public virtual void RegisterHooks(IReloadedHooks hooksInstance) { }
    }
}
