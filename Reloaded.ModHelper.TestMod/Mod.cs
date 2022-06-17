using Reloaded.Hooks.Definitions;
using Reloaded.Mod.Interfaces;
using System;

namespace Reloaded.ModHelper.Testing
{
    /// <summary>
    /// Your mod logic goes here.
    /// </summary>
    public class Mod : ReloadedMod
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override string MyModFolder => $"{Environment.CurrentDirectory}\\Mods\\{ModConfig.ModName}";

        public Mod(IModConfig _config, IReloadedHooks _hooks, ILogger _logger) : base(_config, _hooks, _logger)
        {
            
        }
    }
}