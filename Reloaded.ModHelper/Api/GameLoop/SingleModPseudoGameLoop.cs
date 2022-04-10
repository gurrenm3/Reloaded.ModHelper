using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A <see cref="PseudoGameLoop"/> that is better when used by a single mod, rather 
    /// than being shared between multiple. Unlike <see cref="SharedPseudoGameLoop"/>, this
    /// does not separate Loop Events by mod assembly, meaning all of them are stored together.
    /// This could be a hassle which is why there are two implementations.
    /// </summary>
    internal class SingleModPseudoGameLoop : PseudoGameLoop
    {
        public SingleModPseudoGameLoop(int timeBetweenLoops) : base(timeBetweenLoops)
        {
            OnUpdate = new ModEventHook();
        }
    }
}
