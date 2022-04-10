using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A <see cref="PseudoGameLoop"/> thats better for being shared amongst multiple mods.
    /// Separates Loop Events by mod assembly, which is why it's better for multiple mods.
    /// If you intend for this loop to only be used by a single mod then use
    /// <see cref="SingleModPseudoGameLoop"/> instead.
    /// </summary>
    internal class SharedPseudoGameLoop : PseudoGameLoop
    {        
        public SharedPseudoGameLoop(int timeBetweenLoops) : base(timeBetweenLoops)
        {
            OnUpdate = new SharedModEventHook();
        }
    }
}
