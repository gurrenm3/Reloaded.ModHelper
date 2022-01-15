using Reloaded.Hooks.Definitions;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System.Diagnostics;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Parent interface for all mods.
    /// </summary>
    public interface IModBase
    {
        /// <summary>
        /// The running Process for the game.
        /// </summary>
        Process GameProcess { get; set; }

        /// <summary>
        /// Info about this mod, such as the ModName, ModId, ModDescription, etc.
        /// </summary>
        IModConfigV1 ModInfo { get; set; }

        /// <summary>
        /// A Mod Logger for this mod.
        /// </summary>
        IModLogger Logger { get; set; }

        /// <summary>
        /// The ModLoader instance.
        /// </summary>
        IModLoader ModLoader { get; set; }

        /// <summary>
        /// The instance for the HookLoader.
        /// </summary>
        IReloadedHooks HooksLib { get; set; }

        /// <summary>
        /// Called once when the mod is loaded. Used by the API for early initialization of the mod
        /// before anything else has happened.
        /// <br/>Happens when the mod is Registered in <see cref="IModController"/>.
        /// <br/><br/>NOTE: This is called before <see cref="Start"/> and <see cref="Awake"/>.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Called once when the mod is loaded.
        /// <br/>Happens when the mod is Registered in <see cref="IModController"/>.
        /// <br/><br/>NOTE: This is called right before <see cref="Start"/>.
        /// </summary>
        void Awake();

        /// <summary>
        /// Called once when this mod is loaded.
        /// <br/>This happens when this mod is Registered by <see cref="IModController"/>.
        /// <br/><br/>NOTE: This is called right after <see cref="Awake"/>.
        /// </summary>
        void Start();

        /// <summary>
        /// Called once every tick.
        /// </summary>
        /// <remarks>This is a pseudo-Update method. Not actually synced to the game's tick.</remarks>
        void Update();

        /// <summary>
        /// Called when a mod is unregistered from the ModController.
        /// <br/>Currently this will only be called if you choose to unregister your mod from the API.
        /// </summary>
        void OnModUnregistered();

        /// <summary>
        /// Called when the game is closed.
        /// </summary>
        void OnGameExit();
    }
}