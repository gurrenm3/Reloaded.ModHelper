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
    public abstract class ReloadedMod
    {
        /// <summary>
        /// Represents the location of the personalized folder for this specific mod.
        /// Used to help separate different mods and to store importnat assets, setting files, etc.
        /// <br/><br/>Example: "Actual_Game_Directory/Mods/My Mod"
        /// </summary>
        public virtual string MyModFolder { get; }

        /// <summary>
        /// The path to the settings file.
        /// </summary>
        public virtual string SettingsFile => $"{MyModFolder}\\settings.json";

        /// <summary>
        /// Override this and set it to true if you want to constantly check for changes to your
        /// settings file and automatically change to them if any are found. Consumes unnesessary resources
        /// so use only if you need to.
        /// </summary>
        public virtual bool ShouldUpdateSettings { get; set; } = false;

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

        /// <summary>
        /// Contains any Mod Setting found in this class.
        /// </summary>
        public List<ModSettingInfo> LoadedModSettings => settingsManager?.LoadedModSettings;

        /// <summary>
        /// Manager for the settings loaded by this mod.
        /// </summary>
        protected ModSettingsManager settingsManager;

        /// <summary>
        /// Reflects whether or not this mod has finished initializing.
        /// </summary>
        public bool IsInitialized => _isInitialized;
        private bool _isInitialized;


        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public ReloadedMod(IModConfig _config, IReloadedHooks _hooks, ILogger _logger, bool autoInitialize = true) 
            : this(_config, _hooks, new ModLogger(_config, _logger), autoInitialize)
        {
        }

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public ReloadedMod(IModConfig _config, IReloadedHooks _hooks, IModLogger _logger, bool autoInitialize = true)
        {
            Logger = _logger;
            ModConfig = _config;
            ReloadedHooks = _hooks;

            Logger.WriteLine("-------- Mod Info --------");
            Logger.WriteLine($"{_config.ModName} v{_config.ModVersion}");
            Logger.WriteLine($"by {_config.ModAuthor}");
            Logger.WriteLine("--------------------------");

            Awake();

            if (autoInitialize)
                Initialize();
        }



        /// <summary>
        /// Called once when this mod has finished initializing.
        /// </summary>
        protected virtual void OnInitialized() { }

        /// <summary>
        /// Called once before this mod has initialized; after the logger, config, and hook instance have been set.
        /// </summary>
        protected virtual void Awake() { }



        /// <summary>
        /// Initialize this mod. Normally this is automatically called and it can only be called once.
        /// </summary>
        protected virtual void Initialize()
        {
            if (_isInitialized)
                return;

            Logger.WriteLine("Initializing...");

            ModAssembly = AssemblyUtils.GetCallingAssembly();            
            ModAttributeLoader.LoadAllFromAssembly(ModAssembly, out _loadedModAttributes);

            InitHarmony();
            RegisterHooks();
            RegisterModSettings();

            _isInitialized = true;
            OnInitialized();
        }

        /// <summary>
        /// Called when this mod's Harmony Instance is created. Override it to change how it's made.
        /// </summary>
        /// <returns></returns>
        public virtual Harmony CreateHarmonyInstance()
        {
            string harmonyId = $"{ModConfig.ModAuthor}.{ModConfig.ModName}".Replace(" ", "_");
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
                Logger.WriteLine($"\"{HarmonyLib.Id}\"", Color.RosyBrown, writeModName: false);
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

        private void RegisterModSettings()
        {
            if (string.IsNullOrEmpty(MyModFolder))
            {
                Logger.WriteLine($"{nameof(MyModFolder)} was not set. This isn't bad," +
                    $" but you won't be able to add custom assets or mod settings until" +
                    $" you set this.");
                return;
            }

            settingsManager = new ModSettingsManager(this, Logger, SettingsFile, ShouldUpdateSettings);
            settingsManager.PopulateModSettings();
            settingsManager.SaveModSettings();// saving json to make sure file exists and is updated.

            string message = settingsManager.HasModSettings ? $"Registered {LoadedModSettings.Count} Mod Settings!"
                : "No Mod Settings loaded";

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