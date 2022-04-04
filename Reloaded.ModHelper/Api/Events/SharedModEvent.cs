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
    public class SharedModEvent : IModEvent
    {
        /// <summary>
        /// Contains the <see cref="ModEvent"/> for each mod, separated by the mod's assembly.
        /// </summary>
        protected Dictionary<Assembly, IModEvent> modEvents = new Dictionary<Assembly, IModEvent>();

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public SharedModEvent()
        {

        }

        /// <summary>
        /// <inheritdoc/> Only returns listeners for this mod.
        /// </summary>
        /// <returns></returns>
        public List<Action> GetListeners()
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return null;

            return modEvent.GetListeners();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public void AddListener(Action listener)
        {
            var modEvent = GetModEvent();
            if (modEvent != null)
                modEvent.AddListener(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(int index)
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return false;

            return modEvent.RemoveListener(index);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(Action listener)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveListener(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Invoke()
        {
            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Invoke();
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public IModEvent GetModEvent()
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
    public class SharedModEvent<T1> : IModEvent<T1>
    {
        /// <summary>
        /// Contains the <see cref="ModEvent"/> for each mod, separated by the mod's assembly.
        /// </summary>
        protected Dictionary<Assembly, IModEvent<T1>> modEvents = new Dictionary<Assembly, IModEvent<T1>>();

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public SharedModEvent()
        {

        }

        /// <summary>
        /// <inheritdoc/> Only returns listeners for this mod.
        /// </summary>
        /// <returns></returns>
        public List<Action<T1>> GetListeners()
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return null;

            return modEvent.GetListeners();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public void AddListener(Action<T1> listener)
        {
            var modEvent = GetModEvent();
            if (modEvent == null)
                return;

            modEvent.AddListener(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(int index)
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return false;

            return modEvent.RemoveListener(index);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(Action<T1> listener)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveListener(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Invoke(T1 value1)
        {
            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Invoke(value1);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public IModEvent<T1> GetModEvent()
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
    public class SharedModEvent<T1, T2> : IModEvent<T1, T2>
    {
        /// <summary>
        /// Contains the <see cref="ModEvent"/> for each mod, separated by the mod's assembly.
        /// </summary>
        protected Dictionary<Assembly, IModEvent<T1, T2>> modEvents = new Dictionary<Assembly, IModEvent<T1, T2>>();

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public SharedModEvent()
        {

        }

        /// <summary>
        /// <inheritdoc/> Only returns listeners for this mod.
        /// </summary>
        /// <returns></returns>
        public List<Action<T1, T2>> GetListeners()
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return null;

            return modEvent.GetListeners();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public void AddListener(Action<T1, T2> listener)
        {
            var modEvent = GetModEvent();
            if (modEvent == null)
                return;

            modEvent.AddListener(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(int index)
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return false;

            return modEvent.RemoveListener(index);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(Action<T1, T2> listener)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveListener(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Invoke(T1 value1, T2 value2)
        {
            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Invoke(value1, value2);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public IModEvent<T1, T2> GetModEvent()
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
    public class SharedModEvent<T1, T2, T3> : IModEvent<T1, T2, T3>
    {
        /// <summary>
        /// Contains the <see cref="ModEvent"/> for each mod, separated by the mod's assembly.
        /// </summary>
        protected Dictionary<Assembly, IModEvent<T1, T2, T3>> modEvents = new Dictionary<Assembly, IModEvent<T1, T2, T3>>();

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public SharedModEvent()
        {

        }

        /// <summary>
        /// <inheritdoc/> Only returns listeners for this mod.
        /// </summary>
        /// <returns></returns>
        public List<Action<T1, T2, T3>> GetListeners()
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return null;

            return modEvent.GetListeners();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public void AddListener(Action<T1, T2, T3> listener)
        {
            var modEvent = GetModEvent();
            if (modEvent == null)
                return;

            modEvent.AddListener(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(int index)
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return false;

            return modEvent.RemoveListener(index);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(Action<T1, T2, T3> listener)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveListener(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3)
        {
            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Invoke(value1, value2, value3);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public IModEvent<T1, T2, T3> GetModEvent()
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
    public class SharedModEvent<T1, T2, T3, T4> : IModEvent<T1, T2, T3, T4>
    {
        /// <summary>
        /// Contains the <see cref="ModEvent"/> for each mod, separated by the mod's assembly.
        /// </summary>
        protected Dictionary<Assembly, IModEvent<T1, T2, T3, T4>> modEvents = new Dictionary<Assembly, IModEvent<T1, T2, T3, T4>>();

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public SharedModEvent()
        {

        }

        /// <summary>
        /// <inheritdoc/> Only returns listeners for this mod.
        /// </summary>
        /// <returns></returns>
        public List<Action<T1, T2, T3, T4>> GetListeners()
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return null;

            return modEvent.GetListeners();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public void AddListener(Action<T1, T2, T3, T4> listener)
        {
            var modEvent = GetModEvent();
            if (modEvent == null)
                return;

            modEvent.AddListener(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(int index)
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return false;

            return modEvent.RemoveListener(index);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(Action<T1, T2, T3, T4> listener)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveListener(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Invoke(value1, value2, value3, value4);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public IModEvent<T1, T2, T3, T4> GetModEvent()
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
    public class SharedModEvent<T1, T2, T3, T4, T5> : IModEvent<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Contains the <see cref="ModEvent"/> for each mod, separated by the mod's assembly.
        /// </summary>
        protected Dictionary<Assembly, IModEvent<T1, T2, T3, T4, T5>> modEvents = new Dictionary<Assembly, IModEvent<T1, T2, T3, T4, T5>>();

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public SharedModEvent()
        {

        }

        /// <summary>
        /// <inheritdoc/> Only returns listeners for this mod.
        /// </summary>
        /// <returns></returns>
        public List<Action<T1, T2, T3, T4, T5>> GetListeners()
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return null;

            return modEvent.GetListeners();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public void AddListener(Action<T1, T2, T3, T4, T5> listener)
        {
            var modEvent = GetModEvent();
            if (modEvent == null)
                return;

            modEvent.AddListener(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(int index)
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return false;

            return modEvent.RemoveListener(index);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(Action<T1, T2, T3, T4, T5> listener)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveListener(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Invoke(value1, value2, value3, value4, value5);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public IModEvent<T1, T2, T3, T4, T5> GetModEvent()
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
