namespace Reloaded.ModHelper
{
    /// <summary>
    /// Represents a Mod Setting with a value of type <see cref="double"/>.
    /// </summary>
    public class ModSettingDouble : ModSetting
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
        public new double Value { get => (double)base.Value; set => SetValue(value); }

        /// <summary>
        /// The lowest this value can go.
        /// </summary>
        public double Minimum { get; set; } = double.MinValue;

        /// <summary>
        /// The highest this value can go.
        /// </summary>
        public double Maximum { get; set; } = double.MaxValue;


        /// <summary>
        /// Initializes this mod setting with a value of 0.0.
        /// </summary>
        public ModSettingDouble() : this(default(double))
        {
        }

        /// <summary>
        /// Initializes this mod setting with an initial value.
        /// </summary>
        /// <param name="initialValue"></param>
        public ModSettingDouble(double initialValue)
        {
            _value = default(double);
            Value = initialValue;
        }

        private void SetValue(double newValue)
        {
            if (newValue >= Minimum && newValue <= Maximum)
                base.Value = newValue;
        }
    }
}
