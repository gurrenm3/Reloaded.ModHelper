using System;
using System.Collections.Generic;
using System.Diagnostics;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Used to communicate between mod's and the API.
    /// </summary>
    public class ModController : IModController
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public static ModController instance;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public List<IModBase> LoadedMods { get; set; } = new List<IModBase>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Process GameProcess { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModLoader ModLoader { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ILogger Logger { get; set; }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="modLoader"><inheritdoc/></param>
        /// <param name="logger"><inheritdoc/></param>
        public ModController(IModLoader modLoader, ILogger logger)
        {
            this.ModLoader = modLoader;
            this.Logger = logger;
            instance = this;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="mod"><inheritdoc/></param>
        /// <param name="modInfo"><inheritdoc/></param>
        public void RegisterMod(IModBase mod, IModConfigV1 modInfo)
        {
            mod.ModLoader = ModLoader;
            mod.ModInfo = modInfo;
            //mod.Logger = new ModLogger(Logger, modInfo);
            mod.GameProcess = GameProcess;
            LoadedMods.Add(mod);

            if (mod is ModBase modBase)
                modBase.Initialize();

            mod.Awake();
            mod.Start();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="mod"><inheritdoc/></param>
        public void UnregisterMod(IModBase mod)
        {
            LoadedMods.Remove(mod);
            mod.OnModUnregistered();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="patch"><inheritdoc/></param>
        public void RunModEvent(Action<IModBase> patch)
        {
            LoadedMods.ForEach(mod => patch.Invoke(mod));
        }
    }
}