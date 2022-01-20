using Reloaded.Hooks.Definitions;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System.Diagnostics;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Parent class for all mods
    /// </summary>
    public class ModBase : IModBase
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Process GameProcess { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModConfigV1 ModInfo { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModLogger Logger { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModLoader ModLoader { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IReloadedHooks HooksLib { get; set; }

        private bool initialized;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ModBase()
        {
                     
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Initialize()
        {
            /*if (initialized) return;

            Logger.WriteLine("Initializing...");

            ModLoader.GetController<IReloadedHooks>().TryGetTarget(out var hooks);
            HooksLib = hooks;
            HookLoader.Init(hooks);

            Logger.WriteLine("Finished initializing.");
            initialized = true;*/
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public virtual void Awake() { }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public virtual void Start() { }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public virtual void OnModUnregistered() { }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public virtual void OnGameExit() { }
    }
}
