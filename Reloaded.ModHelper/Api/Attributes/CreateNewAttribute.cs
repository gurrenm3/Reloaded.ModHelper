using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// An attribute that indicates the class this is attached to should automatically be instantiated.
    /// </summary>
    public class CreateNewAttribute : ModClassAttribute
    {
        /// <summary>
        /// The instance that was created.
        /// </summary>
        private object instance;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public CreateNewAttribute() : base()
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="dependencies"><inheritdoc/></param>
        public CreateNewAttribute(params Type[] dependencies) : base(dependencies)
        {

        }

        /// <summary>
        /// <inheritdoc/> Will create an instance of <see cref="ModAttrInfo.TargetClass"/>.
        /// </summary>
        public override void OnAttributeLoaded()
        {
            instance = CreateInstance();
        }

        /// <summary>
        /// Returns the instance that was created when this attribute was loaded.
        /// </summary>
        /// <returns></returns>
        public object GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// Set's the instance value of this attribute.
        /// </summary>
        /// <param name="newInstance"></param>
        public void SetInstance(object newInstance)
        {
            instance = newInstance;
        }

        /// <summary>
        /// Creates an instance of the target class.
        /// </summary>
        /// <returns></returns>
        public virtual object CreateInstance()
        {
            return Activator.CreateInstance(Info.TargetClass);
        }
    }
}
