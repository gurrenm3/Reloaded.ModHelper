using HarmonyLib;
using Reloaded.Hooks.Definitions;
using Reloaded.Mod.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A base class for Reloaded2 mods
    /// </summary>
    public class ReloadedMod
    {
        /// <summary>
        /// Information about this mod.
        /// <br/>Contains info like Mod Name, Author, Version, etc.
        /// </summary>
        public IModConfig ModConfig { get; set; }

        /// <summary>
        /// The instance of the Reloaded hook injector.
        /// </summary>
        public IReloadedHooks ReloadedHooks { get; set; }

        /// <summary>
        /// The assembly for this mod.
        /// </summary>
        public Assembly ModAssembly { get; private set; }

        /// <summary>
        /// A Logger for writing messages to the Reloaded Console.
        /// </summary>
        public IModLogger Logger { get; set; }

        /// <summary>
        /// An instance of Harmony made specifically for this mod.
        /// <br/>This can be used to hook functions from any C# library.
        /// </summary>
        public Harmony HarmonyLib { get; private set; }

        /// <summary>
        /// Contains any <see cref="ModAttrAttribute"/> that were registered for this mod.
        /// <br/>Will be empty if none were registered by this mod.
        /// </summary>
        public List<ModAttrAttribute> LoadedModAttributes => _loadedModAttributes;
        private List<ModAttrAttribute> _loadedModAttributes;

        /// <summary>
        /// Contains any hooks that were registered by this mod. Will not contain hooks made by other mods.
        /// </summary>
        public List<IModHook> LoadedHooks => _loadedHooks;
        private List<IModHook> _loadedHooks;

        private bool isInitialized;

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public ReloadedMod(IModConfig _config, IReloadedHooks _hooks, ILogger _logger)
        {
            Logger = new ModLogger(_config, _logger);
            ModConfig = _config;
            ReloadedHooks = _hooks;
            Initialize();
        }

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public ReloadedMod(IModConfig _config, IReloadedHooks _hooks, IModLogger _logger)
        {
            Logger = _logger;
            ModConfig = _config;
            ReloadedHooks = _hooks;
            Initialize();
        }

        /// <summary>
        /// Initialize this mod. Normally this is automatically called and it can only be called once.
        /// </summary>
        protected virtual void Initialize()
        {
            if (isInitialized)
                return;

            Logger.WriteLine("Initializing...");

            ModAssembly = AssemblyUtils.GetCallingAssembly();
            ModAttributeLoader.LoadAllFromAssembly(ModAssembly, out _loadedModAttributes);

            InitHarmony();
            RegisterHooks();
            isInitialized = true;
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
                Logger.Write("Harmony instance created with id:  ", writeModName: true);
                Logger.Write($"\"{HarmonyLib.Id}\"", Color.RosyBrown);
                Logger.Write($"\n");
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

            _loadedHooks = hookLoader.RegisterHooks();
            string message = _loadedHooks.Any() ? "Successfully registered the hooks found in this mod." : "No new hooks were registered by this mod.";
            Logger.WriteLine(message);
        }

        /// <summary>
        /// Attempts to get a <see cref="ModAttrAttribute"/> from the list of loaded mod attributes.
        /// </summary>
        /// <typeparam name="T">The type of mod attribute you want to get.</typeparam>
        /// <param name="result">The resulting mod attribue. If successful, this will be the mod attribute you wanted.</param>
        /// <returns>If successful, true will be returned. Otherwise false.</returns>
        public bool TryGetModAttribute<T>(out T result) where T : ModAttrAttribute
        {
            result = default(T);

            foreach (var attribute in LoadedModAttributes)
            {
                if (!(attribute is T modAttribute))
                    continue;

                result = modAttribute;
                return true;
            }

            return false;
        }
    }
}