using Reloaded.Hooks.Definitions;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A base class for reloaded2 mods
    /// </summary>
    public class ReloadedMod
    {
        /// <summary>
        /// Info about this mod.
        /// </summary>
        public IModConfig ModConfig { get; set; }

        /// <summary>
        /// The instance of the hook injector.
        /// </summary>
        public IReloadedHooks Hooks { get; set; }

        /// <summary>
        /// The assembly for this mod.
        /// </summary>
        public Assembly ModAssembly { get; private set; }

        /// <summary>
        /// The instance of the logger.
        /// </summary>
        public ModLogger Logger { get; set; }

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public ReloadedMod(IModConfig _config, IReloadedHooks _hooks, ILogger _logger)
        {
            ModConfig = _config;
            Hooks = _hooks;
            Logger = new ModLogger(_config, _logger);

            Logger.WriteLine("Initializing...");

            ModAssembly = GetModAssembly();
            
            RegisterHooks();
        }

        /// <summary>
        /// Used to get the assembly for this mod.
        /// </summary>
        /// <returns></returns>
        protected virtual Assembly GetModAssembly()
        {
            return AssemblyUtils.GetCallingAssembly();
        }

        private void RegisterHooks()
        {
            var hookLoader = new HookLoader(this);

            bool foundHooks = hookLoader.RegisterHooks();
            string message = foundHooks ? "Successfully registered hooks." : "No hooks registered.";
            Logger.WriteLine(message);
        }
    }
}
