namespace Reloaded.ModHelper
{
    /// <summary>
    /// Represents a boolean value Mod Setting that can be true or false.
    /// </summary>
    public class ModSettingBool : ModSetting
    {
        public bool IsCheckbox { get; set; } = true;
        public ModSettingBool() : this(false)
        {
        }

        public ModSettingBool(bool initialValue) : base(initialValue)
        {
        }
    }
}
