using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reloaded.ModHelper
{
    #region No Parameters

    /// <summary>
    /// A <see cref="ModEvent"/> that separates listeners by mod assembly. Useful for 
    /// any <see cref="ModEvent"/> that will be shared between multiple mods.
    /// </summary>
    public class SharedModEvent
    {
        /// <summary>
        /// Contains the <see cref="ModEvent"/> for each mod, separated by the mod's assembly.
        /// </summary>
        protected Dictionary<Assembly, ModEvent> modEvents = new Dictionary<Assembly, ModEvent>();

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public SharedModEvent()
        {

        }

        /// <summary>
        /// Add a Listener to the <see cref="ModEvent"/> associated with the mod that called this method.
        /// </summary>
        /// <param name="listener">The code to add to the event.</param>
        /// <returns>True if it was successfully added, otherwise false. It would fail to add if 
        /// the method failed to aquire the Assembly of the mod that called the method.</returns>
        public bool AddListener(Action listener)
        {
            var modEvent = GetModEvent();
            if (modEvent == null)
                return false;

            modEvent.AddListener(listener);
            return true;
        }

        /// <summary>
        /// Remove a Listener from the <see cref="ModEvent"/> associated with the mod that called the method.
        /// </summary>
        /// <param name="listener">The code to remove from the event.</param>
        /// <returns>True if it was successfully removed, otherwise false. It would fail to remove
        /// if the method failed to aquire the Assembly of the mod that called the method.</returns>
        public bool RemoveListener(Action listener)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveListener(listener);
        }

        /// <summary>
        /// Invoke this event, causing every Listeners from every mod to execute.
        /// </summary>
        public void InvokeAll()
        {
            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Invoke();
            }
        }

        /// <summary>
        /// Invoke this event, causing only the listeners from THIS MOD to execute.
        /// </summary>
        public void Invoke()
        {
            GetModEvent()?.Invoke();
        }

        /// <summary>
        /// Returns the ModEvent associated with the Mod that called this method.
        /// </summary>
        /// <returns></returns>
        public ModEvent GetModEvent()
        {
            var callingMod = GetCallingMod();
            if (callingMod == null)
                return null;

            if (modEvents.TryGetValue(callingMod, out var modEvent))
                return modEvent;

            modEvent = new ModEvent();
            modEvents.Add(callingMod, modEvent);
            return modEvent;
        }

        /// <summary>
        /// Returns the Assembly of the mod that called this method.
        /// </summary>
        /// <returns>If successful, the Assembly of the calling mod will be returned, otherwise null.</returns>
        protected virtual Assembly GetCallingMod()
        {
            return AssemblyUtils.GetCallingAssembly();
        }
    }

    #endregion
}
