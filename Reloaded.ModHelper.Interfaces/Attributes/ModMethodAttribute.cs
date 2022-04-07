using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A base class for method attributes. Supports load order.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class ModMethodAttribute : Attribute
    {
        /// <summary>
        /// Contains which classes this depends on and therefore should be loaded before this one.
        /// <br/>Note: can only load after classes within the same assembly. You cannot load after a class from another 
        /// project/assembly.
        /// </summary>
        public Type[] dependencies;

        /// <summary>
        /// Reflects whether or not this attribute was already loaded.
        /// </summary>
        public bool IsAttributeLoaded { get; set; }

        /// <summary>
        /// Initializes this attribute without specifying a load order.
        /// </summary>
        public ModMethodAttribute()
        {
            
        }

        /// <summary>
        /// Initializes this attribute, specifying the execution order.
        /// <br/><br/>If multiple methods use this same attribute, use <paramref name="dependencies"/> to specify 
        /// which classes should have their methods run before this one. If left null then the multiple events using this
        /// will execute in no particular order.
        /// 
        /// <br/><br/>Note: can only load after classes within the same assembly. You cannot load after a class from another 
        /// project/assembly.
        /// </summary>
        /// <param name="dependencies">Specifies which classes using this attribute should run before this.</param>
        public ModMethodAttribute(params Type[] dependencies)
        {
            this.dependencies = dependencies;
        }

        /// <summary>
        /// Called automatically when a <see cref="ModMethodAttribute"/> is being loaded. Used to determine what happens
        /// with this <see cref="ModMethodAttribute"/>.
        /// </summary>
        /// <param name="modMethodPair">Attribute that's currently being loaded</param>
        public abstract void OnAttributeLoaded(ModMethodAttributeInfo modMethodPair);
    }
}
