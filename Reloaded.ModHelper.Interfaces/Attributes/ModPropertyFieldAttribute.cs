using System;
using System.Reflection;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A base class for custom attributes that will work on both Properties and Fields.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public abstract class ModPropertyFieldAttribute : ModAttrAttribute
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ModPropertyFieldAttribute() : base()
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="dependencies"><inheritdoc/></param>
        public ModPropertyFieldAttribute(params Type[] dependencies) : base(dependencies)
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="attribute"><inheritdoc/></param>
        public abstract override void OnAttributeLoaded();

        /// <summary>
        /// Will return the target of this Attribute. If it was attached to a Property then it will return <see cref="ModAttrInfo.TargetProperty"/>,
        /// otherwise it will return <see cref="ModAttrInfo.TargetField"/>.
        /// </summary>
        /// <returns></returns>
        public MemberInfo GetTarget()
        {
            return Info.TargetProperty != null ? Info.TargetProperty : Info.TargetField;
        }

        /// <summary>
        /// Returns the current value of the Property or Field this is attached to.
        /// </summary>
        /// <returns></returns>
        public object GetValue()
        {
            return Info.TargetProperty != null ? Info.TargetProperty?.GetValue(null) : Info.TargetField?.GetValue(null);
        }

        /// <summary>
        /// Sets the value of the Property or Field this is attached to.
        /// </summary>
        /// <param name="newValue">The new value for the Field to hold.</param>
        public void SetValue(object newValue)
        {
            Info.TargetProperty?.SetValue(null, newValue);
            Info.TargetField?.SetValue(null, newValue);
        }
    }
}
