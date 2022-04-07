using System;
using System.Reflection;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Used to link a <see cref="ModMethodAttribute"/> with the method it was applied to.
    /// </summary>
    public class ModMethodAttributeInfo
    {
        /// <summary>
        /// The instance of the ModMethodAttribute
        /// </summary>
        public ModMethodAttribute Attribute { get; private set; }

        /// <summary>
        /// The Method that has this attribtue.
        /// </summary>
        public MethodInfo TargetMethod { get; private set; }

        /// <summary>
        /// The class that contains the target method.
        /// </summary>
        public Type TargetClass { get; private set; }

        /// <summary>
        /// Initializes this object with the attribute and target method.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="targetMethod"></param>
        public ModMethodAttributeInfo(ModMethodAttribute attribute, Type targetClass, MethodInfo targetMethod)
        {
            Attribute = attribute;
            TargetClass = targetClass;
            TargetMethod = targetMethod;
        }
    }
}
