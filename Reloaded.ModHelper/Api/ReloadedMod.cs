using Reloaded.Hooks.Definitions;
using Reloaded.Mod.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A base class for Reloaded2 mods
    /// </summary>
    public abstract class ReloadedMod : ModAttributeContainer
    {
        /// <summary>
        /// Represents the location of the personalized folder for this specific mod.
        /// Used to help separate different mods and to store important assets, setting files, etc.
        /// <br/><br/>Example: "Actual_Game_Directory/Mods/My Mod"
        /// </summary>
        public virtual string MyModDirectory { get; }

        /// <summary>
        /// The path to the settings file.
        /// </summary>
        public virtual string SettingsFile => $"{MyModDirectory}\\settings.json";

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
        /// Contains any hooks that were registered by this mod. Will not contain hooks made by other mods.
        /// </summary>
        public List<IModHook> LoadedHooks { get; private set; }

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
        /// The directory for this mod in the Reloaded2 Mod Manager.
        /// </summary>
        public string ReloadedModDirectory { get; private set; }

        /// <summary>
        /// Reflects whether or not the Debugger should be attached.
        /// <br/>Only runs once in the mod's constructor.
        /// </summary>
        protected virtual bool EnableDebugger { get; }

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public ReloadedMod(ModContext context, bool autoInitialize = true) 
            : this(context.ModConfig, context.Hooks, context.Logger, autoInitialize)
        {
            
        }

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
            if (EnableDebugger)
                Debugger.Launch();

            Logger = _logger;
            ModConfig = _config;
            ReloadedHooks = _hooks;

            Logger.WriteLine("-------- Mod Info --------", Color.LawnGreen);
            Logger.WriteLine($"{_config.ModName} v{_config.ModVersion}");
            Logger.WriteLine($"by {_config.ModAuthor}");

            if (!string.IsNullOrEmpty(_config.ModDescription))
                Logger.WriteLine($"{_config.ModDescription}");

            Logger.WriteLine("--------------------------");

            Awake();

            if (autoInitialize)
                Initialize();
        }



        /// <summary>
        /// Called once when this mod has finished initializing.
        /// </summary>
        protected virtual void OnInitialized()
        {
            Logger.WriteLine(GetRegisterHooksMessage());
        }

        /// <summary>
        /// Called once before this mod has initialized; after the logger, config, and hook instance have been set.
        /// </summary>
        protected virtual void Awake() { }



        /// <summary>
        /// Initialize this mod. Normally this is automatically called and it can only be called once.
        /// </summary>
        protected void Initialize()
        {
            if (_isInitialized)
                return;

            Logger.WriteLine("Initializing...");

            ModAssembly = AssemblyUtils.GetCallingAssembly();
            ReloadedModDirectory = Path.GetDirectoryName(ModAssembly.Location);
            Logger.WriteLine($"Mod Directory: {ReloadedModDirectory}");

            LoadModAttributes();
            RegisterHooks();
            RegisterModSettings();

            _isInitialized = true;
            OnInitialized();
        }

        private void LoadModAttributes()
        {
            Logger.WriteLine("Loading Mod Attributes...");

            LoadInstanceAttributes();
            ModAttributeLoader.LoadAllFromAssembly(ModAssembly, out var loadedFromAssembly);

            if (loadedFromAssembly != null)
                LoadedModAttributes.AddRange(loadedFromAssembly);

            if (LoadedModAttributes == null || !LoadedModAttributes.Any())
            {
                Logger.WriteLine("No Mod Attributes were registered by this mod.");
                return;
            }

            Logger.WriteLine($"Successfully registered {(LoadedModAttributes.Count == 1 ? "one ModAttribute" : $"{LoadedModAttributes.Count} ModAttributes")} found in this mod.");
        }

        private void RegisterHooks()
        {
            var hookLoader = new HookLoader(this);
            LoadedHooks = hookLoader.RegisterHooks();
        }

        protected virtual string GetRegisterHooksMessage()
        {
            if (!LoadedHooks.Any())
                return "No new hooks were registered by this mod.";

            return $"Successfully registered {(LoadedHooks.Count == 1 ? "one hook" : $"{LoadedHooks.Count} hooks")} found in this mod.";
        }

        private void RegisterModSettings()
        {
            if (string.IsNullOrEmpty(MyModDirectory))
            {
                Logger.WriteLine($"{nameof(MyModDirectory)} was not set. This isn't bad," +
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


        #region Reloaded ModBase stuff

        /// <summary>
        /// Returns true if the suspend functionality is supported, else false.
        /// </summary>
        public virtual bool CanSuspend() => false;

        /// <summary>
        /// Returns true if the unload functionality is supported, else false.
        /// </summary>
        public virtual bool CanUnload() => false;

        /// <summary>
        /// Suspends your mod, i.e. mod stops performing its functionality but is not unloaded.
        /// <br/><br/>Some tips if you wish to support this (CanSuspend == true)
        /// <br/>A. Undo memory modifications.
        /// <br/>B. Deactivate hooks. (Reloaded.Hooks Supports This!)
        /// </summary>
        public virtual void Suspend() { }

        /// <summary>
        /// Unloads your mod, i.e. mod stops performing its functionality but is not unloaded.
        /// <br/><br/>Some tips if you wish to support this (CanUnload == true).
        /// <br/>A. Execute Suspend(). [Suspend should be reusable in this method]
        /// <br/>B. Release any unmanaged resources, e.g. Native memory.
        /// </summary>
        /// <remarks>In most cases, calling suspend here is sufficient.</remarks>
        public virtual void Unload() { }

        /// <summary>
        /// Automatically called by the mod loader when the mod is about to be unloaded.
        /// </summary>
        public virtual void Disposing() { }

        /// <summary>
        /// Automatically called by the mod loader when the mod is about to be unloaded.
        /// <br/><br/>Some tips if you wish to support this (CanSuspend == true)
        /// <br/>A. Redo memory modifications.
        /// <br/>B. Re-activate hooks. (Reloaded.Hooks Supports This!)
        /// </summary>
        public virtual void Resume() { }

        #endregion


        #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ReloadedMod() { }
#pragma warning restore CS8618
        #endregion
    }
}