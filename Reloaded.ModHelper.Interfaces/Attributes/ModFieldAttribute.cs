using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A base class for custom attributes that will only work on Fields.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public abstract class ModFieldAttribute : ModAttrAttribute
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ModFieldAttribute() : base()
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="dependencies"><inheritdoc/></param>
        public ModFieldAttribute(params Type[] dependencies) : base(dependencies)
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public abstract override void OnAttributeLoaded();

        /// <summary>
        /// Returns the current value of the Field this is attached to.
        /// </summary>
        /// <returns></returns>
        public object GetValue()
        {
            return Info.TargetField?.GetValue(null);
        }

        /// <summary>
        /// Sets the value of the Property this is attached to.
        /// </summary>
        /// <param name="newValue">The new value for the Field to hold.</param>
        public void SetValue(object newValue)
        {
            Info.TargetField?.SetValue(null, newValue);
        }
    }
}
