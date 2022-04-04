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
        public SharedModEvent ModEvents { get; private set; } = new SharedModEvent();
        
        public SharedPseudoGameLoop(int timeBetweenLoops) : base(timeBetweenLoops)
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="codeToRun"></param>
        public override void AddListener(Action codeToRun)
        {
            ModEvents.AddListener(codeToRun);
        }        

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="codeToRun"></param>
        /// <returns></returns>
        public override bool RemoveListener(Action codeToRun)
        {
            return ModEvents.RemoveListener(codeToRun);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override void RunLoop()
        {
            ModEvents.Invoke();
        }
    }
}
