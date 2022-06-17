using System;
using System.Reflection;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Used to track Mod Settings and pair them with their original variable.
    /// </summary>
    public class ModSettingInfo
    {
        /// <summary>
        /// The actual variable for this mod setting.
        /// </summary>
        [NonSerialized]
        public MemberInfo variable;

        /// <summary>
        /// Represents the name of the mod setting variable.
        /// </summary>
        public readonly string variableName;

        /// <summary>
        /// Represents the actual mod setting.
        /// </summary>
        public ModSetting setting;

        public ModSettingInfo(string variableName, ModSetting setting)
        {
            this.setting = setting;
            this.variableName = variableName;
        }
    }
}
