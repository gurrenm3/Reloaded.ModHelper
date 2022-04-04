﻿using Reloaded.Hooks.Definitions;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Interface that can be used to automatically register any and all hooks.
    /// </summary>
    public interface IModHook
    {
        /// <summary>
        /// The name of this hook. Meant to make it more obvious what this hook is.
        /// </summary>
        public abstract string HookName { get; }

        /// <summary>
        /// Used to initialize a hook.
        /// </summary>
        /// <param name="_logger"></param>
        /// <param name="_hooks"></param>
        public void InitHook(ModLogger _logger, IReloadedHooks _hooks);
    }
}