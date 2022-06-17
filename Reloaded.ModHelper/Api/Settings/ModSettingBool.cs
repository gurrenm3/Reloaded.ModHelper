namespace Reloaded.ModHelper
{
    /// <summary>
    /// Represents a Mod Setting with a value of type <see cref="bool"/>.
    /// </summary>
    public class ModSettingBool : ModSetting
    {
        /// <summary>
        /// The different ways a mod setting can be displayed in game.
        /// </summary>
        public enum DisplayType
        {
            /// <summary>
            /// Display as a checkbox.
            /// </summary>
            Checkbox, 
            
            /// <summary>
            /// Display as a button.
            /// </summary>
            Button
        }

        /// <summary>
        /// Represents how this mod setting should be displayed in game.
        /// </summary>
        public DisplayType Display { get; set; } = DisplayType.Button;


        /// <summary>
        /// The current value of this setting.
        /// </summary>
        public new bool Value { get => (bool)base.Value; set => base.Value = value; }


        /// <summary>
        /// Initializes this mod setting with a value of false.
        /// </summary>
        public ModSettingBool() : this(default(bool))
        {
        }

        /// <summary>
        /// Initializes this mod setting with an initial value.
        /// </summary>
        /// <param name="initialValue"></param>
        public ModSettingBool(bool initialValue)
        {
            _value = default(bool);
            Value = initialValue;
        }
    }
}
