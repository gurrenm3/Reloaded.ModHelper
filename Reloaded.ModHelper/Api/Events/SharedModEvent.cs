﻿using System;
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



    #region One Parameter

    /// <summary>
    /// A <see cref="ModEvent"/> that separates listeners by mod assembly. Useful for 
    /// any <see cref="ModEvent"/> that will be shared between multiple mods.
    /// </summary>
    public class SharedModEvent<T1>
    {
        /// <summary>
        /// Contains the <see cref="ModEvent"/> for each mod, separated by the mod's assembly.
        /// </summary>
        protected Dictionary<Assembly, ModEvent<T1>> modEvents = new Dictionary<Assembly, ModEvent<T1>>();

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
        public bool AddListener(Action<T1> listener)
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
        public bool RemoveListener(Action<T1> listener)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveListener(listener);
        }

        /// <summary>
        /// Invoke this event, causing every Listeners from every mod to execute.
        /// </summary>
        public void InvokeAll(T1 value)
        {
            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Invoke(value);
            }
        }

        /// <summary>
        /// Invoke this event, causing only the listeners from THIS MOD to execute.
        /// </summary>
        public void Invoke(T1 value)
        {
            GetModEvent()?.Invoke(value);
        }

        /// <summary>
        /// Returns the ModEvent associated with the Mod that called this method.
        /// </summary>
        /// <returns></returns>
        public ModEvent<T1> GetModEvent()
        {
            var callingMod = GetCallingMod();
            if (callingMod == null)
                return null;

            if (modEvents.TryGetValue(callingMod, out var modEvent))
                return modEvent;

            modEvent = new ModEvent<T1>();
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



    #region Two Parameters

    /// <summary>
    /// A <see cref="ModEvent"/> that separates listeners by mod assembly. Useful for 
    /// any <see cref="ModEvent"/> that will be shared between multiple mods.
    /// </summary>
    public class SharedModEvent<T1, T2>
    {
        /// <summary>
        /// Contains the <see cref="ModEvent"/> for each mod, separated by the mod's assembly.
        /// </summary>
        protected Dictionary<Assembly, ModEvent<T1, T2>> modEvents = new Dictionary<Assembly, ModEvent<T1, T2>>();

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
        public bool AddListener(Action<T1, T2> listener)
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
        public bool RemoveListener(Action<T1, T2> listener)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveListener(listener);
        }

        /// <summary>
        /// Invoke this event, causing every Listeners from every mod to execute.
        /// </summary>
        public void InvokeAll(T1 value1, T2 value2)
        {
            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Invoke(value1, value2);
            }
        }

        /// <summary>
        /// Invoke this event, causing only the listeners from THIS MOD to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2)
        {
            GetModEvent()?.Invoke(value1, value2);
        }

        /// <summary>
        /// Returns the ModEvent associated with the Mod that called this method.
        /// </summary>
        /// <returns></returns>
        public ModEvent<T1, T2> GetModEvent()
        {
            var callingMod = GetCallingMod();
            if (callingMod == null)
                return null;

            if (modEvents.TryGetValue(callingMod, out var modEvent))
                return modEvent;

            modEvent = new ModEvent<T1, T2>();
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



    #region Three Parameters

    /// <summary>
    /// A <see cref="ModEvent"/> that separates listeners by mod assembly. Useful for 
    /// any <see cref="ModEvent"/> that will be shared between multiple mods.
    /// </summary>
    public class SharedModEvent<T1, T2, T3>
    {
        /// <summary>
        /// Contains the <see cref="ModEvent"/> for each mod, separated by the mod's assembly.
        /// </summary>
        protected Dictionary<Assembly, ModEvent<T1, T2, T3>> modEvents = new Dictionary<Assembly, ModEvent<T1, T2, T3>>();

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
        public bool AddListener(Action<T1, T2, T3> listener)
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
        public bool RemoveListener(Action<T1, T2, T3> listener)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveListener(listener);
        }

        /// <summary>
        /// Invoke this event, causing every Listeners from every mod to execute.
        /// </summary>
        public void InvokeAll(T1 value1, T2 value2, T3 value3)
        {
            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Invoke(value1, value2, value3);
            }
        }

        /// <summary>
        /// Invoke this event, causing only the listeners from THIS MOD to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3)
        {
            GetModEvent()?.Invoke(value1, value2, value3);
        }

        /// <summary>
        /// Returns the ModEvent associated with the Mod that called this method.
        /// </summary>
        /// <returns></returns>
        public ModEvent<T1, T2, T3> GetModEvent()
        {
            var callingMod = GetCallingMod();
            if (callingMod == null)
                return null;

            if (modEvents.TryGetValue(callingMod, out var modEvent))
                return modEvent;

            modEvent = new ModEvent<T1, T2, T3>();
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



    #region Four Parameters

    /// <summary>
    /// A <see cref="ModEvent"/> that separates listeners by mod assembly. Useful for 
    /// any <see cref="ModEvent"/> that will be shared between multiple mods.
    /// </summary>
    public class SharedModEvent<T1, T2, T3, T4>
    {
        /// <summary>
        /// Contains the <see cref="ModEvent"/> for each mod, separated by the mod's assembly.
        /// </summary>
        protected Dictionary<Assembly, ModEvent<T1, T2, T3, T4>> modEvents = new Dictionary<Assembly, ModEvent<T1, T2, T3, T4>>();

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
        public bool AddListener(Action<T1, T2, T3, T4> listener)
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
        public bool RemoveListener(Action<T1, T2, T3, T4> listener)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveListener(listener);
        }

        /// <summary>
        /// Invoke this event, causing every Listeners from every mod to execute.
        /// </summary>
        public void InvokeAll(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Invoke(value1, value2, value3, value4);
            }
        }

        /// <summary>
        /// Invoke this event, causing only the listeners from THIS MOD to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            GetModEvent()?.Invoke(value1, value2, value3, value4);
        }

        /// <summary>
        /// Returns the ModEvent associated with the Mod that called this method.
        /// </summary>
        /// <returns></returns>
        public ModEvent<T1, T2, T3, T4> GetModEvent()
        {
            var callingMod = GetCallingMod();
            if (callingMod == null)
                return null;

            if (modEvents.TryGetValue(callingMod, out var modEvent))
                return modEvent;

            modEvent = new ModEvent<T1, T2, T3, T4>();
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



    #region Five Parameters

    /// <summary>
    /// A <see cref="ModEvent"/> that separates listeners by mod assembly. Useful for 
    /// any <see cref="ModEvent"/> that will be shared between multiple mods.
    /// </summary>
    public class SharedModEvent<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Contains the <see cref="ModEvent"/> for each mod, separated by the mod's assembly.
        /// </summary>
        protected Dictionary<Assembly, ModEvent<T1, T2, T3, T4, T5>> modEvents = new Dictionary<Assembly, ModEvent<T1, T2, T3, T4, T5>>();

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
        public bool AddListener(Action<T1, T2, T3, T4, T5> listener)
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
        public bool RemoveListener(Action<T1, T2, T3, T4, T5> listener)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveListener(listener);
        }

        /// <summary>
        /// Invoke this event, causing every Listeners from every mod to execute.
        /// </summary>
        public void InvokeAll(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Invoke(value1, value2, value3, value4, value5);
            }
        }

        /// <summary>
        /// Invoke this event, causing only the listeners from THIS MOD to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            GetModEvent()?.Invoke(value1, value2, value3, value4, value5);
        }

        /// <summary>
        /// Returns the ModEvent associated with the Mod that called this method.
        /// </summary>
        /// <returns></returns>
        public ModEvent<T1, T2, T3, T4, T5> GetModEvent()
        {
            var callingMod = GetCallingMod();
            if (callingMod == null)
                return null;

            if (modEvents.TryGetValue(callingMod, out var modEvent))
                return modEvent;

            modEvent = new ModEvent<T1, T2, T3, T4, T5>();
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