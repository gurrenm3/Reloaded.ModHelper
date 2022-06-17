namespace Reloaded.ModHelper
{
    /// <summary>
    /// Represents a Mod Setting with a value of type <see cref="string"/>.
    /// </summary>
    public class ModSettingString : ModSetting
    {
        /// <summary>
        /// The current value of this setting.
        /// </summary>
        public new string Value { get => (string)base.Value; set => SetValue(value); }

        /// <summary>
        /// The minimum length this string can be.
        /// </summary>
        public int MinLength { get; set; } = 0;

        /// <summary>
        /// The maximum length this string can be.
        /// </summary>
        public int MaxLength { get; set; } = int.MaxValue;


        /// <summary>
        /// Initializes this mod setting with a value of false.
        /// </summary>
        public ModSettingString() : this(default(string))
        {
        }

        /// <summary>
        /// Initializes this mod setting with an initial value.
        /// </summary>
        /// <param name="initialValue"></param>
        public ModSettingString(string initialValue)
        {
            _value = default(string);
            Value = initialValue;
        }

        private void SetValue(string newValue)
        {
            if (newValue == null || (newValue.Length >= MinLength && newValue.Length <= MaxLength))
                base.Value = newValue;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
