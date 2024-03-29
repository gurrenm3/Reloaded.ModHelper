﻿namespace Reloaded.ModHelper
{
    /// <summary>
    /// Represents a Mod Setting with a value of type <see cref="int"/>.
    /// </summary>
    public class ModSettingInt : ModSetting
    {
        /// <summary>
        /// The different ways a mod setting can be displayed in game.
        /// </summary>
        public enum DisplayType
        {
            /// <summary>
            /// Display as a textbox.
            /// </summary>
            Textbox,

            /// <summary>
            /// Display as a slider.
            /// </summary>
            Slider
        }

        /// <summary>
        /// Represents how this mod setting should be displayed in game.
        /// </summary>
        public DisplayType Display { get; set; } = DisplayType.Slider;

        /// <summary>
        /// The current value of this setting.
        /// </summary>
        public new int Value { get => (int)base.Value; set => SetValue(value); }

        /// <summary>
        /// The lowest this value can go.
        /// </summary>
        public int Minimum { get; set; } = int.MinValue;

        /// <summary>
        /// The highest this value can go.
        /// </summary>
        public int Maximum { get; set; } = int.MaxValue;


        /// <summary>
        /// Initializes this mod setting with a value of 0.
        /// </summary>
        public ModSettingInt() : this(default(int))
        {
        }

        /// <summary>
        /// Initializes this mod setting with an initial value.
        /// </summary>
        /// <param name="initialValue"></param>
        public ModSettingInt(int initialValue)
        {
            _value = default(int);
            Value = initialValue;
        }

        private void SetValue(int newValue)
        {
            if (newValue >= Minimum && newValue <= Maximum)
                base.Value = newValue;
        }
    }
}
