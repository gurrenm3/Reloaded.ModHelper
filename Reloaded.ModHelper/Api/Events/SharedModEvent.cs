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
        /// Called automatically once during <see cref="Run"/> once all listeners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedRunning { get; set; }

        /// <summary>
        /// Contains the <see cref="ModEvent"/> for each mod, separated by the mod's assembly.
        /// </summary>
        protected Dictionary<Assembly, IModEvent> modEvents = new Dictionary<Assembly, IModEvent>();

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public SharedModEvent(bool useOnFinishedInvoking = true)
        {
            if (useOnFinishedInvoking)
                OnFinishedRunning = new SharedModEvent(false);
        }

        /// <summary>
        /// <inheritdoc/> Only returns listeners for this mod.
        /// </summary>
        /// <returns></returns>
        public List<Action> GetRunners()
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return null;

            return modEvent.GetRunners();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public void AddRunner(Action listener)
        {
            var modEvent = GetModEvent();
            if (modEvent != null)
                modEvent.AddRunner(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(int index)
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return false;

            return modEvent.RemoveRunner(index);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(Action listener)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveRunner(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Run()
        {
            if (!modEvents.Any())
                return;

            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Run();
            }

            OnFinishedRunning?.Run();
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
        /// Called automatically once during <see cref="Run"/> once all listeners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedRunning { get; set; }

        /// <summary>
        /// Contains the <see cref="ModEvent"/> for each mod, separated by the mod's assembly.
        /// </summary>
        protected Dictionary<Assembly, IModEvent<T1>> modEvents = new Dictionary<Assembly, IModEvent<T1>>();

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public SharedModEvent(bool useOnFinishedInvoking = true)
        {
            if (useOnFinishedInvoking)
                OnFinishedRunning = new SharedModEvent(false);
        }

        /// <summary>
        /// <inheritdoc/> Only returns listeners for this mod.
        /// </summary>
        /// <returns></returns>
        public List<Action<T1>> GetRunners()
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return null;

            return modEvent.GetRunners();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public void AddRunner(Action<T1> listener)
        {
            var modEvent = GetModEvent();
            if (modEvent == null)
                return;

            modEvent.AddRunner(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddRunner(ActionRef1<T1> listener)
        {
            var modEvent = GetModEvent();
            if (modEvent == null)
                return;

            modEvent.AddRunner(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(int index)
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return false;

            return modEvent.RemoveRunner(index);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="codeToRemove"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(Action<T1> codeToRemove)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveRunner(codeToRemove);
        }

        public bool RemoveRunner(ActionRef1<T1> codeToRemove)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveRunner(codeToRemove);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Run(T1 value1)
        {
            if (!modEvents.Any())
                return;

            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Run(value1);
            }

            OnFinishedRunning?.Run();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Run(ref T1 value1)
        {
            if (!modEvents.Any())
                return;

            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Run(ref value1);
            }

            OnFinishedRunning?.Run();
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
        /// Called automatically once during <see cref="Run"/> once all listeners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedRunning { get; set; }

        /// <summary>
        /// Contains the <see cref="ModEvent"/> for each mod, separated by the mod's assembly.
        /// </summary>
        protected Dictionary<Assembly, IModEvent<T1, T2>> modEvents = new Dictionary<Assembly, IModEvent<T1, T2>>();

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public SharedModEvent(bool useOnFinishedInvoking = true)
        {
            if (useOnFinishedInvoking)
                OnFinishedRunning = new SharedModEvent(false);
        }

        /// <summary>
        /// <inheritdoc/> Only returns listeners for this mod.
        /// </summary>
        /// <returns></returns>
        public List<Action<T1, T2>> GetRunners()
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return null;

            return modEvent.GetRunners();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public void AddRunner(Action<T1, T2> listener)
        {
            var modEvent = GetModEvent();
            if (modEvent == null)
                return;

            modEvent.AddRunner(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(int index)
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return false;

            return modEvent.RemoveRunner(index);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(Action<T1, T2> listener)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveRunner(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Run(T1 value1, T2 value2)
        {
            if (!modEvents.Any())
                return;

            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Run(value1, value2);
            }

            OnFinishedRunning?.Run();
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

            throw new Exception("FIX THIS ERROR! UNCOMMENT CODE BELOW");
            //modEvent = new ModEvent<T1, T2>();
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

        public void AddRunner(ActionRef1<T1, T2> codeToRun)
        {
            throw new NotImplementedException();
        }

        public void AddRunner(ActionRef2<T1, T2> codeToRun)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRunner(ActionRef1<T1, T2> codeToRemove)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRunner(ActionRef2<T1, T2> codeToRemove)
        {
            throw new NotImplementedException();
        }

        public void Run(ref T1 value1, T2 value2)
        {
            throw new NotImplementedException();
        }

        public void Run(ref T1 value1, ref T2 value2)
        {
            throw new NotImplementedException();
        }
    }

    #endregion
/*


    #region Three Parameters

    /// <summary>
    /// A <see cref="ModEvent"/> that separates listeners by mod assembly. Useful for 
    /// any <see cref="ModEvent"/> that will be shared between multiple mods.
    /// </summary>
    public class SharedModEvent<T1, T2, T3> : IModEvent<T1, T2, T3>
    {
        /// <summary>
        /// Called automatically once during <see cref="Run"/> once all listeners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedRunning { get; set; }

        /// <summary>
        /// Contains the <see cref="ModEvent"/> for each mod, separated by the mod's assembly.
        /// </summary>
        protected Dictionary<Assembly, IModEvent<T1, T2, T3>> modEvents = new Dictionary<Assembly, IModEvent<T1, T2, T3>>();

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public SharedModEvent(bool useOnFinishedInvoking = true)
        {
            if (useOnFinishedInvoking)
                OnFinishedRunning = new SharedModEvent(false);
        }

        /// <summary>
        /// <inheritdoc/> Only returns listeners for this mod.
        /// </summary>
        /// <returns></returns>
        public List<Action<T1, T2, T3>> GetRunners()
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return null;

            return modEvent.GetRunners();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public void AddRunner(Action<T1, T2, T3> listener)
        {
            var modEvent = GetModEvent();
            if (modEvent == null)
                return;

            modEvent.AddRunner(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(int index)
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return false;

            return modEvent.RemoveRunner(index);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(Action<T1, T2, T3> listener)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveRunner(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Run(T1 value1, T2 value2, T3 value3)
        {
            if (!modEvents.Any())
                return;

            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Run(value1, value2, value3);
            }

            OnFinishedRunning?.Run();
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
        /// Called automatically once during <see cref="Run"/> once all listeners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedRunning { get; set; }

        /// <summary>
        /// Contains the <see cref="ModEvent"/> for each mod, separated by the mod's assembly.
        /// </summary>
        protected Dictionary<Assembly, IModEvent<T1, T2, T3, T4>> modEvents = new Dictionary<Assembly, IModEvent<T1, T2, T3, T4>>();

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public SharedModEvent(bool useOnFinishedInvoking = true)
        {
            if (useOnFinishedInvoking)
                OnFinishedRunning = new SharedModEvent(false);
        }

        /// <summary>
        /// <inheritdoc/> Only returns listeners for this mod.
        /// </summary>
        /// <returns></returns>
        public List<Action<T1, T2, T3, T4>> GetRunners()
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return null;

            return modEvent.GetRunners();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public void AddRunner(Action<T1, T2, T3, T4> listener)
        {
            var modEvent = GetModEvent();
            if (modEvent == null)
                return;

            modEvent.AddRunner(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(int index)
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return false;

            return modEvent.RemoveRunner(index);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(Action<T1, T2, T3, T4> listener)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveRunner(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Run(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            if (!modEvents.Any())
                return;

            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Run(value1, value2, value3, value4);
            }

            OnFinishedRunning?.Run();
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
        /// Called automatically once during <see cref="Run"/> once all listeners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedRunning { get; set; }

        /// <summary>
        /// Contains the <see cref="ModEvent"/> for each mod, separated by the mod's assembly.
        /// </summary>
        protected Dictionary<Assembly, IModEvent<T1, T2, T3, T4, T5>> modEvents = new Dictionary<Assembly, IModEvent<T1, T2, T3, T4, T5>>();

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public SharedModEvent(bool useOnFinishedInvoking = true)
        {
            if (useOnFinishedInvoking)
                OnFinishedRunning = new SharedModEvent(false);
        }

        /// <summary>
        /// <inheritdoc/> Only returns listeners for this mod.
        /// </summary>
        /// <returns></returns>
        public List<Action<T1, T2, T3, T4, T5>> GetRunners()
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return null;

            return modEvent.GetRunners();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public void AddRunner(Action<T1, T2, T3, T4, T5> listener)
        {
            var modEvent = GetModEvent();
            if (modEvent == null)
                return;

            modEvent.AddRunner(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(int index)
        {
            var callingMod = GetCallingMod();
            if (callingMod == null || !modEvents.TryGetValue(callingMod, out var modEvent))
                return false;

            return modEvent.RemoveRunner(index);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="listener"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(Action<T1, T2, T3, T4, T5> listener)
        {
            var modEvent = GetModEvent();
            return modEvent == null ? false : modEvent.RemoveRunner(listener);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Run(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            if (!modEvents.Any())
                return;

            for (int i = 0; i < modEvents.Count; i++)
            {
                modEvents.ElementAt(i).Value?.Run(value1, value2, value3, value4, value5);
            }

            OnFinishedRunning?.Run();
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

    #endregion*/
}
