using HarmonyLib;
using Reloaded.Hooks.Definitions;
using Reloaded.Mod.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A base class for Reloaded2 mods
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
        public IModLogger Logger { get; set; }

        /// <summary>
        /// An instance of Harmony, specifically for this mod. Used to HarmonyPatch.
        /// <br/>This can be used to hook C# functions from any library.
        /// </summary>
        public Harmony HarmonyLib { get; protected set; }

        /// <summary>
        /// A list of any <see cref="ModAttrAttribute"/> that were registered for this mod.
        /// </summary>
        public List<ModAttrAttribute> LoadedModAttributes => _loadedModAttributes;
        private List<ModAttrAttribute> _loadedModAttributes;

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public ReloadedMod(IModConfig _config, IReloadedHooks _hooks, ILogger _logger)
        {
            ModConfig = _config;
            Hooks = _hooks;
            Logger = new ModLogger(_config, _logger);

            Logger.WriteLineAsync("Initializing...");

            ModAssembly = AssemblyUtils.GetCallingAssembly();
            ModAttributeLoader.LoadAllFromAssembly(ModAssembly, out _loadedModAttributes);

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

            try
            {
                HarmonyLib.PatchAll(this.ModAssembly);
                Logger.WriteAsync("Harmony instance created with id:  ", writeModName: true);
                Logger.WriteAsync($"\"{HarmonyLib.Id}\"", Color.RosyBrown);
                Logger.WriteAsync($"\n");
            }
            catch (System.Exception ex)
            {
                if (ex.Message == "A non-collectible assembly may not reference a collectible assembly.")
                {
                    throw new System.Exception($"Failed to load Harmony. Cannot use Class Attributs with dependencies from other projects/Assemblies." +
                        $" Check all of your Classes and make sure that none of them are using an Attribute or {nameof(ModAttrAttribute)} that" +
                        $" references a Type from another mod/Assembly.");
                }
                throw;
            }
            
        }

        private void RegisterHooks()
        {
            var hookLoader = new HookLoader(this);

            bool foundHooks = hookLoader.RegisterHooks();
            string message = foundHooks ? "Successfully registered the hooks found in this mod." : "No new hooks were registered by this mod.";
            Logger.WriteLineAsync(message);
        }
    }
}