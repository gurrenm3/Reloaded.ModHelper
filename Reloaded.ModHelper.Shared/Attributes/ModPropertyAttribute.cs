using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A base class for custom attributes that will only work on Properties.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ModPropertyAttribute : ModAttrAttribute
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ModPropertyAttribute() : base()
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="dependencies"><inheritdoc/></param>
        public ModPropertyAttribute(Type[] dependencies) : base(dependencies)
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override abstract void OnAttributeLoaded();

        /// <summary>
        /// Returns the current value of the Property this is attached to.
        /// </summary>
        /// <returns></returns>
        public object GetValue()
        {
            return Info.TargetProperty?.GetValue(null);
        }

        /// <summary>
        /// Sets the value of the Property this is attached to.
        /// </summary>
        /// <param name="newValue">The new value for the Property to hold.</param>
        public void SetValue(object newValue)
        {
            Info.TargetField?.SetValue(null, newValue);
        }
    }
}
