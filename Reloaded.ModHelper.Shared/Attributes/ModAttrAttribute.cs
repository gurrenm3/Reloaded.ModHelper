using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Base class for custom attributes.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public abstract class ModAttrAttribute : Attribute
    {
        /// <summary>
        /// Contains all of the info about this specific Attribute.
        /// </summary>
        public ModAttrInfo Info { get; set; }

        /// <summary>
		/// An instance of the class that created this, if it exists and if this <see cref="ModAttrAttribute" /> is NOT static.
		/// </summary>
        public object ClassInstance { get; set; }

        /// <summary>
        /// Reflects whether or not this <see cref="ModAttrAttribute"/> has any dependents.
        /// </summary>
        public bool HasDependencies => Info?.dependencies?.Length > 0;

        /// <summary>
        /// Creates an instance of this attribute without specifying any dependencies or a load order.
        /// </summary>
        public ModAttrAttribute()
        {
            Info = new ModAttrInfo(this);
        }

        /// <summary>
        /// Creates an instance of this attribute while specifying which classes have Attributes that this one depends on.
        /// <br/>This is effectively specifying a Load Order, in which the dependents must be loaded before this one.
        /// <br/>If no dependencies are provided then this Attribute will load in no specific order.
        /// <br/><br/>Dependent Types can only be from the same project/Assembly and cannot be originally located in another project or mod.
        /// </summary>
        /// <param name="dependencies">The classes that any dependents are located in. Can only be Types from the same project/Assebly.</param>
        public ModAttrAttribute(Type[] dependencies) : this()
        {
            Info.dependencies = dependencies;
        }

        /// <summary>
        /// Called automatically when a <see cref="ModAttrAttribute"/> is being loaded. Used to determine what happens
        /// with this <see cref="ModAttrAttribute"/>.
        /// </summary>
        public virtual void OnAttributeLoaded() { }
    }
}
