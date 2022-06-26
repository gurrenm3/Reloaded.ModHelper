using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Reloaded.ModHelper
{
    public class ModSettingsManager
    {
        /// <summary>
        /// Action that is called when a settings file is changed. Only works if settings file is being watched.
        /// </summary>
        public Action onSettingsChanged;

        /// <summary>
        /// Contains any settings that were loaded with this manager.
        /// </summary>
        public List<ModSettingInfo> LoadedModSettings => _loadedModSettings;
        private List<ModSettingInfo> _loadedModSettings;

        /// <summary>
        /// Reflects whether or not any mod settings are loaded.
        /// </summary>
        public bool HasModSettings => LoadedModSettings != null && LoadedModSettings.Count > 0;

        private FileSystemWatcher _settingsWatcher;
        private Task _settingsWatcherTask;

        private string settingsFile;
        private IModLogger logger;
        private object owner;
        private bool useSettingsWatcher;
        private FileInfo settingsFileInfo;

        /// <summary>
        /// Creates an instance of this manager.
        /// </summary>
        /// <param name="settingsOwer">the object that has Mod Settings as fields/properties.</param>
        /// <param name="logger"></param>
        /// <param name="settingsFile">the location of the settings file.</param>
        /// <param name="useSettingsWatcher">Determines whether or not the settings file will be
        /// constantly watched for any changes.</param>
        public ModSettingsManager(object settingsOwer, IModLogger logger, string settingsFile, bool useSettingsWatcher = false)
        {
            if (string.IsNullOrEmpty(settingsFile))
            {
                logger.WriteLine($"Cannot manage settings file because the path was invalid!", LogLevel.Error);
                return;
            }

            this.logger = logger;
            this.settingsFile = settingsFile;
            owner = settingsOwer;
            this.useSettingsWatcher = useSettingsWatcher;

            var fileInfo = new FileInfo(settingsFile);
            if (!fileInfo.Directory.Exists)
                fileInfo.Directory.Create();

            if (useSettingsWatcher)
                InitSettingsWatcher();
        }

        /// <summary>
        /// Registers all mod settings in this class.
        /// </summary>
        public List<ModSettingInfo> PopulateModSettings()
        {
            _loadedModSettings = GetActiveModSettings();

            if (!HasModSettings)
                return null;

            // update variables with loaded values.
            foreach (var item in _loadedModSettings)
            {
                if (item.variable is FieldInfo field)
                    field.SetValue(owner, item.setting);
                else if (item.variable is PropertyInfo property)
                    property.SetValue(owner, item.setting);
            }

            return _loadedModSettings;
        }

        /// <summary>
        /// Saves settings to settings file.
        /// </summary>
        public void SaveModSettings()
        {
            // TODO. Don't save settings file if there are no loaded settings and delete if file exists
            /*if (_loadedModSettings == null || !_loadedModSettings.Any())
            {
                bool directoryNotExist = !settingsFileInfo.Directory.Exists;
                if (directoryNotExist)
                    return;

                var files = settingsFileInfo.Directory.GetFiles();
                bool noFilesFound = files.Length == 0;
                if (noFilesFound)
                {
                    logger.WriteLine("Personal ");
                    settingsFileInfo.Directory.Delete();
                }

                bool onlySettngsFile = files.Length == 1 && files[0].FullName == settingsFileInfo.FullName;
            }*/

            string json = JsonConvert.SerializeObject(_loadedModSettings, Formatting.Indented);
            if (!File.Exists(settingsFile) || File.ReadAllText(settingsFile) != json)
                File.WriteAllText(settingsFile, json);
        }


        private void InitSettingsWatcher()
        {
            _settingsWatcher = new FileSystemWatcher(new FileInfo(settingsFile).Directory.FullName);
            _settingsWatcherTask = Task.Run(() =>
            {
                logger.WriteLine("Settings watcher started. Searching for changes to settings file...");
                
                while (true)
                {
                    var changedFile = _settingsWatcher.WaitForChanged(WatcherChangeTypes.Changed);
                    if (!settingsFile.EndsWith(changedFile.Name))
                        continue;

                    logger.WriteLine($"Settings file for {logger.ModName} was changed!");
                    Thread.Sleep(30); // sleeping to prevent race condition.
                    logger.WriteLine($"Settings were updated to latest changes from file.");
                    PopulateModSettings();
                    onSettingsChanged?.Invoke();
                }
            });
        }

        private List<ModSettingInfo> GetActiveModSettings()
        {
            var currentSettings = GetMemberModSettings();
            if (currentSettings == null || currentSettings.Count == 0)
                return null;

            var loadedSettings = LoadModSettingsFromFile();
            if (loadedSettings == null || loadedSettings.Count == 0)
                return currentSettings;

            foreach (var loaded in loadedSettings)
            {
                var current = currentSettings.FirstOrDefault(setting => setting.variableName == loaded.variableName);
                if (current == null)
                    continue;

                current.setting = loaded.setting;
            }

            return currentSettings;
        }

        private List<ModSettingInfo> GetMemberModSettings()
        {
            var type = owner.GetType();

            // Get all possible variables
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                .Where(field => field.FieldType.IsAssignableTo(typeof(ModSetting)));

            // not used for now because of issue where properties are duplicated.
            /*var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                .Where(property => property.PropertyType.IsAssignableTo(typeof(ModSetting)));*/

            var members = new HashSet<MemberInfo>();
            foreach (var item in fields)
                members.Add(item);

            /*foreach (var item in properties)
                members.Add(item);*/


            List<ModSettingInfo> modSettings = new List<ModSettingInfo>();
            foreach (var member in members)
            {
                ModSetting setting = null;
                if (member is FieldInfo field)
                    setting = field.GetValue(owner) as ModSetting;

                if (member is PropertyInfo property)
                    setting = property.GetValue(owner) as ModSetting;

                var info = new ModSettingInfo(member.Name, setting);
                info.variable = member;
                modSettings.Add(info);
            }

            return modSettings;
        }

        private List<ModSettingInfo> LoadModSettingsFromFile()
        {
            if (!File.Exists(settingsFile))
                return null;

            var json = File.ReadAllText(settingsFile);
            var loadedSettings = JsonConvert.DeserializeObject<List<ModSettingInfo>>(json, new ModSettingConverter(logger));
            return loadedSettings;
        }
    }
}
