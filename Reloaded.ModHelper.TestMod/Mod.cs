using Reloaded.Hooks.Definitions;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;

namespace Reloaded.ModHelper.Testing
{
    /// <summary>
    /// Your mod logic goes here.
    /// </summary>
    public class Mod : ReloadedMod
    {
        public Mod(IModConfig _config, IReloadedHooks _hooks, ILogger _logger) : base(_config, _hooks, _logger)
        {
            
        }
    }
}