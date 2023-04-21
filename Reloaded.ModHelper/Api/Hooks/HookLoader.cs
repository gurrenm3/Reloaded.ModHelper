using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A Hook Loader that can be used to easily load any hooks.
    /// </summary>
    public class HookLoader
    {
        private List<IModHook> loadedHookInstances = new List<IModHook>();
        private List<Type> loadedHooks = new List<Type>();
        private ReloadedMod thisMod;

        public HookLoader(ReloadedMod mod)
        {
            thisMod = mod;
        }

        /// <summary>
        /// Searches THIS assembly for all hooks using <see cref="IModHook"/> and automatically registers them.
        /// </summary>
        /// <returns>True if any hooks were registered, otherwise false.</returns>
        public List<IModHook> RegisterHooks()
        {
            var hooks = thisMod.ModAssembly.GetTypesWithInterface<IModHook>();

            foreach (var hook in hooks)
            {
                if (loadedHooks.Contains(hook))
                    continue;

                IModHook hookInstance = (IModHook)Activator.CreateInstance(hook);
                bool initialized = hookInstance.InitHook(thisMod.Logger, thisMod.ReloadedHooks);
                if (!initialized)
                    continue;

                loadedHookInstances.Add(hookInstance);
                loadedHooks.Add(hook);
            }

            return loadedHookInstances;
        }
    }
}
