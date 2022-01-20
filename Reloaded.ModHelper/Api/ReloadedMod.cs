using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;

namespace Reloaded.ModHelper
{
    public class ReloadedMod
    {
        public ReloadedMod()
        {

        }

        public ReloadedMod(IReloadedHooks hooks, ILogger logger) : this()
        {

        }

        /// <summary>
        /// Called when the game is exited.
        /// </summary>
        public virtual void OnExit() { }
    }
}
