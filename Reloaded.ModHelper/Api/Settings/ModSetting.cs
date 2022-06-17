using Newtonsoft.Json;
using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Represents a mod setting.
    /// </summary>
    public abstract class ModSetting
    {
        /// <summary>
        /// the backingfield for <see cref="Value"/>. Avoid setting this directly.
        /// </summary>
        protected object _value;

        /// <summary>
        /// Represents the original type of this setting. Used for json serialization/deserialization.
        /// </summary>
        public Type type => GetType();

        /// <summary>
        /// Event called whenever the value is changed.
        /// </summary>
        public IModEvent<object> OnValueChanged { get; set; }

        /// <summary>
        /// The current value of this setting.
        /// </summary>
        public virtual object Value
        {
            get { return _value; }
            set 
            {
                if (value != _value)
                {
                    _value = value;
                    OnValueChanged?.Invoke(_value);
                }
            }
        }


        public ModSetting()
        {
        }

        /// <summary>
        /// Initializes this mod setting with an initial value.
        /// </summary>
        /// <param name="initialValue"></param>
        public ModSetting(object initialValue) : this()
        {
            Value = initialValue;
        }

        /// <summary>
        /// Returns whether or not this setting should be displayed in game.
        /// <br/>Will only work if your game has support for in game settings.
        /// </summary>
        public virtual bool ShowInGame()
        {
            return true;
        }

        /// <summary>
        /// Converts this Mod Setting into json.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Creates a Mod Setting based on the provided json.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static ModSetting FromJson(string json)
        {
            var converter = new ModSettingConverter();
            var modSetting = JsonConvert.DeserializeObject<ModSetting>(json, converter);
            return modSetting;
        }
    }
}
