using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reloaded.ModHelper
{
    internal class MultiModPseudoGameLoop : PseudoGameLoop
    {
        // using a dictionary to allow for one shared instance of the game loop with a
        // separate mod event for each mod using the shared instance.
        private Dictionary<Assembly, ModEvent> loopEvents = new Dictionary<Assembly, ModEvent>();

        public MultiModPseudoGameLoop(int timeBetweenLoops) : base(timeBetweenLoops)
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="codeToRun"></param>
        public override void Add(Action codeToRun)
        {
            var assembly = AssemblyUtils.GetCallingAssembly();
            if (assembly == null)
                return;

            if (loopEvents.TryGetValue(assembly, out var modEvent))
                modEvent.AddListener(codeToRun);
            else
                loopEvents.Add(assembly, new ModEvent(codeToRun));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="codeToRun"></param>
        /// <returns></returns>
        public override bool Remove(Action codeToRun)
        {
            var assembly = AssemblyUtils.GetCallingAssembly();
            if (assembly == null)
                return false;

            if (loopEvents.TryGetValue(assembly, out var modEvent))
                return modEvent.RemoveListener(codeToRun);

            return false;
        }

        /// <summary>
        /// Get's the mod event associated with the mod that called this method.
        /// </summary>
        /// <returns></returns>
        public override ModEvent GetModEvent()
        {
            var asm = AssemblyUtils.GetCallingAssembly();
            if (asm == null)
                return null;

            return loopEvents.TryGetValue(asm, out var modEvent) ? modEvent : null;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override void RunLoop()
        {
            for (int i = 0; i < loopEvents.Count; i++)
            {
                loopEvents.ElementAt(i).Value?.Invoke();
            }
        }
    }
}
