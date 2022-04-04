using System;
using System.Collections.Generic;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A Hook Loader that can be used to easily load any hooks.
    /// </summary>
    public class HookLoader
    {
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
        public bool RegisterHooks()
        {
            bool foundHooks = false;
            var hooks = thisMod.ModAssembly.GetTypesWithInterface<IModHook>();

            foreach (var hook in hooks)
            {
                if (loadedHooks.Contains(hook))
                    continue;

                IModHook hookInstance = (IModHook)Activator.CreateInstance(hook);
                hookInstance.InitHook(thisMod.Logger, thisMod.Hooks);
                loadedHooks.Add(hook);
                foundHooks = true;
            }

            return foundHooks;
        }
    }
}
