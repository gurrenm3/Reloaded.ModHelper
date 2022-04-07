using HarmonyLib;
using Reloaded.Hooks.Definitions;
using Reloaded.Mod.Interfaces;
using System.Drawing;
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
        /// An instance of Harmony, specifically for this mod. Used to HarmonyPatch.
        /// <br/>This can be used to hook C# functions from any library.
        /// </summary>
        public Harmony HarmonyLib { get; protected set; }

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public ReloadedMod(IModConfig _config, IReloadedHooks _hooks, ILogger _logger)
        {
            ModConfig = _config;
            Hooks = _hooks;
            Logger = new ModLogger(_config, _logger);

            Logger.WriteLine("Initializing...");

            ModAssembly = AssemblyUtils.GetCallingAssembly();

            InitHarmony();
            RegisterHooks();
        }

        /// <summary>
        /// Called when this mod's Harmony Instance is created. Override it to change how it's made.
        /// </summary>
        /// <returns></returns>
        public virtual Harmony CreateHarmonyInstance()
        {
            string harmonyId = $"{ModConfig.ModAuthor.Replace(" ", "_")}.{ModConfig.ModName.Replace(" ", "_")}";
            return new Harmony(harmonyId);
        }

        /// <summary>
        /// Initializes Harmony with this mod.
        /// <br/>Harmony is a very powerful tool that allows mod makers to hook C# functions.
        /// It's unlikely that many modders will use it, however it's a nice convenience to have already in place.
        /// </summary>
        private void InitHarmony()
        {
            HarmonyLib = CreateHarmonyInstance();

            HarmonyLib.PatchAll(this.ModAssembly);
            Logger.Write("Harmony instance created with id:  ", insertModName: true);
            Logger.Write($"\"{HarmonyLib.Id}\"", Color.RosyBrown);
            Logger.Write($"\n");
        }

        private void RegisterHooks()
        {
            var hookLoader = new HookLoader(this);

            bool foundHooks = hookLoader.RegisterHooks();
            string message = foundHooks ? "Successfully registered hooks from this mod." : "This mod didn't have any hooks to register.";
            Logger.WriteLine(message);
        }
    }
}