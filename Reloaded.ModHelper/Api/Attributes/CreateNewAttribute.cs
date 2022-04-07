using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// An attribute that indicates the class this is attached to should automatically be instantiated.
    /// </summary>
    public class CreateNewAttribute : ModMethodAttribute
    {
        /// <summary>
        /// The instance that was created.
        /// </summary>
        public object instance;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modMethodInfo"></param>
        public override void OnAttributeLoaded(ModMethodAttributeInfo modMethodInfo)
        {
            instance = Activator.CreateInstance(modMethodInfo.TargetClass);
        }
    }
}
