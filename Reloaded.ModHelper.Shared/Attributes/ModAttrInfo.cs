using System;
using System.Reflection;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Holds data about a <see cref="ModAttrAttribute"/> and the code it was attached to.
    /// </summary>
    public class ModAttrInfo
    {
        /// <summary>
        /// Contains which classes this Attribute depends on and therefore should be loaded before this.
        /// <br/>This is effectively used to specify a load order, in which <see cref="ModAttrAttribute"/> from these Dependent Types
        /// will be loaded before this one.
        /// <br/>Note: can only load after classes within the same assembly. You cannot load after a class from another 
        /// project/assembly.
        /// </summary>
        public Type[] dependencies;

        /// <summary>
        /// Reflects whether or not this attribute was already loaded.
        /// </summary>
        public bool IsAttributeLoaded { get; set; }

        /// <summary>
        /// The instance of the ModAttribute this is related to.
        /// </summary>
        public ModAttrAttribute Attribute { get; set; }

        /// <summary>
        /// If <see cref="Attribute"/> is attached to a Constructor, this will be info about that Constructor. Otherwise this will be null.
        /// </summary>
        public ConstructorInfo TargetConstructor { get; set; }

        /// <summary>
        /// If <see cref="Attribute"/> is attached to a Method, this will be info about that Method. Otherwise this will be null.
        /// </summary>
        public MethodInfo TargetMethod { get; set; }

        /// <summary>
        /// If <see cref="Attribute"/> is attached to a Property, this will be info about that Property. Otherwise this will be null.
        /// </summary>
        public PropertyInfo TargetProperty { get; set; }

        /// <summary>
        /// If <see cref="Attribute"/> is attached to a Field, this will be info about that Field. Otherwise this will be null.
        /// </summary>
        public FieldInfo TargetField { get; set; }

        /// <summary>
        /// The class that the attribute was applied to. This will never be null.
        /// </summary>
        public Type TargetClass { get; set; }


        /// <summary>
        /// Initializes this object with an Attribute
        /// </summary>
        /// <param name="attribute"></param>
        public ModAttrInfo(ModAttrAttribute attribute)
        {
            Attribute = attribute;
        }

        /// <summary>
        /// Initializes this object with an Attribute and its target Class
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="targetClass"></param>
        public ModAttrInfo(ModAttrAttribute attribute, Type targetClass) : this(attribute)
        {
            TargetClass = targetClass;
        }

        /// <summary>
        /// Initializes this object with an Attribute and its target Method.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="targetClass"></param>
        /// <param name="targetMethod"></param>
        public ModAttrInfo(ModAttrAttribute attribute, Type targetClass, MethodInfo targetMethod) : this(attribute, targetClass)
        {
            TargetMethod = targetMethod;
        }

        /// <summary>
        /// Initializes this object with an Attribute and its target Property.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="targetClass"></param>
        /// <param name="targetProperty"></param>
        public ModAttrInfo(ModAttrAttribute attribute, Type targetClass, PropertyInfo targetProperty) : this(attribute, targetClass)
        {
            TargetProperty = targetProperty;
        }

        /// <summary>
        /// Initializes this object with an Attribute and its target Field.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="targetClass"></param>
        /// <param name="targetField"></param>
        public ModAttrInfo(ModAttrAttribute attribute, Type targetClass, FieldInfo targetField) : this(attribute, targetClass)
        {
            TargetField = targetField;
        }
    }
}
