using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A base class for custom attributes that will only work on Methods.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class ModMethodAttribute : ModAttrAttribute
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ModMethodAttribute() : base()
        {
            
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="dependencies"><inheritdoc/></param>
        public ModMethodAttribute(params Type[] dependencies) : base(dependencies)
        {
            
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public abstract override void OnAttributeLoaded();
    }
}
