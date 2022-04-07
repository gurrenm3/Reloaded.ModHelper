using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A base class for custom attributes that will only work on Classes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class ModClassAttribute : ModAttrAttribute
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ModClassAttribute() : base()
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="dependencies"><inheritdoc/></param>
        public ModClassAttribute(Type[] dependencies) : base(dependencies)
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override abstract void OnAttributeLoaded();
    }
}
