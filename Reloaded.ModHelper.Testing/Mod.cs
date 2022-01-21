using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;

namespace Reloaded.ModHelper.Testing
{
    /// <summary>
    /// Your mod logic goes here.
    /// </summary>
    public class Mod : ReloadedMod
    {
        public Mod(IReloadedHooks hooks, ILogger logger) : base(hooks, logger)
        {
            
        }
    }
}