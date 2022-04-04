using System;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A ModEvent that separates listeners by mod assembly. Useful for 
    /// any ModEvent that will be shared between multiple mods.
    /// </summary>
    public interface ISharedModEvent
    {
        /// <summary>
        /// Add a Listener to the ModEvent associated with the mod that called this method.
        /// </summary>
        /// <param name="listener">The code to add to the event.</param>
        /// <returns>True if it was successfully added, otherwise false. It would fail to add if 
        /// the method failed to aquire the Assembly of the mod that called the method.</returns>
        public bool AddListener(Action listener);

        /// <summary>
        /// Remove a Listener from the ModEvent associated with the mod that called the method.
        /// </summary>
        /// <param name="listener">The code to remove from the event.</param>
        /// <returns>True if it was successfully removed, otherwise false. It would fail to remove
        /// if the method failed to aquire the Assembly of the mod that called the method.</returns>
        public bool RemoveListener(Action listener);

        /// <summary>
        /// Invoke this event, causing every Listeners from every mod to execute.
        /// </summary>
        public void InvokeAll();

        /// <summary>
        /// Invoke this event, causing only the listeners from THIS MOD to execute.
        /// </summary>
        public void Invoke();

        /// <summary>
        /// Returns the ModEvent associated with the Mod that called this method.
        /// </summary>
        /// <returns></returns>
        public IModEvent GetModEvent();

        /// <summary>
        /// Implicitly add a listener to this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">Listener to add</param>
        /// <returns></returns>
        public static ISharedModEvent operator +(ISharedModEvent modEvent, Action codeToRun)
        {
            modEvent.AddListener(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a listener to this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">Listener to remove</param>
        /// <returns></returns>
        public static ISharedModEvent operator -(ISharedModEvent modEvent, Action codeToRun)
        {
            modEvent.RemoveListener(codeToRun);
            return modEvent;
        }
    }



    /// <summary>
    /// A ModEvent that separates listeners by mod assembly. Useful for 
    /// any ModEvent that will be shared between multiple mods.
    /// </summary>
    public interface ISharedModEvent<T1>
    {
        /// <summary>
        /// Add a Listener to the ModEvent associated with the mod that called this method.
        /// </summary>
        /// <param name="listener">The code to add to the event.</param>
        /// <returns>True if it was successfully added, otherwise false. It would fail to add if 
        /// the method failed to aquire the Assembly of the mod that called the method.</returns>
        public bool AddListener(Action<T1> listener);

        /// <summary>
        /// Remove a Listener from the ModEvent associated with the mod that called the method.
        /// </summary>
        /// <param name="listener">The code to remove from the event.</param>
        /// <returns>True if it was successfully removed, otherwise false. It would fail to remove
        /// if the method failed to aquire the Assembly of the mod that called the method.</returns>
        public bool RemoveListener(Action<T1> listener);

        /// <summary>
        /// Invoke this event, causing every Listeners from every mod to execute.
        /// </summary>
        public void InvokeAll(T1 value);

        public void InvokeAll(ref T1 value);

        /// <summary>
        /// Invoke this event, causing only the listeners from THIS MOD to execute.
        /// </summary>
        public void Invoke(T1 value);

        /// <summary>
        /// Returns the ModEvent associated with the Mod that called this method.
        /// </summary>
        /// <returns></returns>
        public IModEvent<T1> GetModEvent();

        /// <summary>
        /// Implicitly add a listener to this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">Listener to add</param>
        /// <returns></returns>
        public static ISharedModEvent<T1> operator +(ISharedModEvent<T1> modEvent, Action<T1> codeToRun)
        {
            modEvent.AddListener(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a listener to this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">Listener to remove</param>
        /// <returns></returns>
        public static ISharedModEvent<T1> operator -(ISharedModEvent<T1> modEvent, Action<T1> codeToRun)
        {
            modEvent.RemoveListener(codeToRun);
            return modEvent;
        }
    }



    /// <summary>
    /// A ModEvent that separates listeners by mod assembly. Useful for 
    /// any ModEvent that will be shared between multiple mods.
    /// </summary>
    public interface ISharedModEvent<T1, T2>
    {
        /// <summary>
        /// Add a Listener to the ModEvent associated with the mod that called this method.
        /// </summary>
        /// <param name="listener">The code to add to the event.</param>
        /// <returns>True if it was successfully added, otherwise false. It would fail to add if 
        /// the method failed to aquire the Assembly of the mod that called the method.</returns>
        public bool AddListener(Action<T1, T2> listener);

        /// <summary>
        /// Remove a Listener from the ModEvent associated with the mod that called the method.
        /// </summary>
        /// <param name="listener">The code to remove from the event.</param>
        /// <returns>True if it was successfully removed, otherwise false. It would fail to remove
        /// if the method failed to aquire the Assembly of the mod that called the method.</returns>
        public bool RemoveListener(Action<T1, T2> listener);

        /// <summary>
        /// Invoke this event, causing every Listeners from every mod to execute.
        /// </summary>
        public void InvokeAll(T1 value1, T2 value2);

        /// <summary>
        /// Invoke this event, causing only the listeners from THIS MOD to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2);

        /// <summary>
        /// Returns the ModEvent associated with the Mod that called this method.
        /// </summary>
        /// <returns></returns>
        public IModEvent<T1, T2> GetModEvent();

        /// <summary>
        /// Implicitly add a listener to this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">Listener to add</param>
        /// <returns></returns>
        public static ISharedModEvent<T1, T2> operator +(ISharedModEvent<T1, T2> modEvent, Action<T1, T2> codeToRun)
        {
            modEvent.AddListener(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a listener to this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">Listener to remove</param>
        /// <returns></returns>
        public static ISharedModEvent<T1, T2> operator -(ISharedModEvent<T1, T2> modEvent, Action<T1, T2> codeToRun)
        {
            modEvent.RemoveListener(codeToRun);
            return modEvent;
        }
    }



    /// <summary>
    /// A ModEvent that separates listeners by mod assembly. Useful for 
    /// any ModEvent that will be shared between multiple mods.
    /// </summary>
    public interface ISharedModEvent<T1, T2, T3>
    {
        /// <summary>
        /// Add a Listener to the ModEvent associated with the mod that called this method.
        /// </summary>
        /// <param name="listener">The code to add to the event.</param>
        /// <returns>True if it was successfully added, otherwise false. It would fail to add if 
        /// the method failed to aquire the Assembly of the mod that called the method.</returns>
        public bool AddListener(Action<T1, T2, T3> listener);

        /// <summary>
        /// Remove a Listener from the ModEvent associated with the mod that called the method.
        /// </summary>
        /// <param name="listener">The code to remove from the event.</param>
        /// <returns>True if it was successfully removed, otherwise false. It would fail to remove
        /// if the method failed to aquire the Assembly of the mod that called the method.</returns>
        public bool RemoveListener(Action<T1, T2, T3> listener);

        /// <summary>
        /// Invoke this event, causing every Listeners from every mod to execute.
        /// </summary>
        public void InvokeAll(T1 value1, T2 value2, T3 value3);

        /// <summary>
        /// Invoke this event, causing only the listeners from THIS MOD to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3);

        /// <summary>
        /// Returns the ModEvent associated with the Mod that called this method.
        /// </summary>
        /// <returns></returns>
        public IModEvent<T1, T2, T3> GetModEvent();

        /// <summary>
        /// Implicitly add a listener to this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">Listener to add</param>
        /// <returns></returns>
        public static ISharedModEvent<T1, T2, T3> operator +(ISharedModEvent<T1, T2, T3> modEvent, Action<T1, T2, T3> codeToRun)
        {
            modEvent.AddListener(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a listener to this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">Listener to remove</param>
        /// <returns></returns>
        public static ISharedModEvent<T1, T2, T3> operator -(ISharedModEvent<T1, T2, T3> modEvent, Action<T1, T2, T3> codeToRun)
        {
            modEvent.RemoveListener(codeToRun);
            return modEvent;
        }
    }



    /// <summary>
    /// A ModEvent that separates listeners by mod assembly. Useful for 
    /// any ModEvent that will be shared between multiple mods.
    /// </summary>
    public interface ISharedModEvent<T1, T2, T3, T4>
    {
        /// <summary>
        /// Add a Listener to the ModEvent associated with the mod that called this method.
        /// </summary>
        /// <param name="listener">The code to add to the event.</param>
        /// <returns>True if it was successfully added, otherwise false. It would fail to add if 
        /// the method failed to aquire the Assembly of the mod that called the method.</returns>
        public bool AddListener(Action<T1, T2, T3, T4> listener);

        /// <summary>
        /// Remove a Listener from the ModEvent associated with the mod that called the method.
        /// </summary>
        /// <param name="listener">The code to remove from the event.</param>
        /// <returns>True if it was successfully removed, otherwise false. It would fail to remove
        /// if the method failed to aquire the Assembly of the mod that called the method.</returns>
        public bool RemoveListener(Action<T1, T2, T3, T4> listener);

        /// <summary>
        /// Invoke this event, causing every Listeners from every mod to execute.
        /// </summary>
        public void InvokeAll(T1 value1, T2 value2, T3 value3, T4 value4);

        /// <summary>
        /// Invoke this event, causing only the listeners from THIS MOD to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4);

        /// <summary>
        /// Returns the ModEvent associated with the Mod that called this method.
        /// </summary>
        /// <returns></returns>
        public IModEvent<T1, T2, T3, T4> GetModEvent();

        /// <summary>
        /// Implicitly add a listener to this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">Listener to add</param>
        /// <returns></returns>
        public static ISharedModEvent<T1, T2, T3, T4> operator +(ISharedModEvent<T1, T2, T3, T4> modEvent, Action<T1, T2, T3, T4> codeToRun)
        {
            modEvent.AddListener(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a listener to this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">Listener to remove</param>
        /// <returns></returns>
        public static ISharedModEvent<T1, T2, T3, T4> operator -(ISharedModEvent<T1, T2, T3, T4> modEvent, Action<T1, T2, T3, T4> codeToRun)
        {
            modEvent.RemoveListener(codeToRun);
            return modEvent;
        }
    }



    /// <summary>
    /// A ModEvent that separates listeners by mod assembly. Useful for 
    /// any ModEvent that will be shared between multiple mods.
    /// </summary>
    public interface ISharedModEvent<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Add a Listener to the ModEvent associated with the mod that called this method.
        /// </summary>
        /// <param name="listener">The code to add to the event.</param>
        /// <returns>True if it was successfully added, otherwise false. It would fail to add if 
        /// the method failed to aquire the Assembly of the mod that called the method.</returns>
        public bool AddListener(Action<T1, T2, T3, T4, T5> listener);

        /// <summary>
        /// Remove a Listener from the ModEvent associated with the mod that called the method.
        /// </summary>
        /// <param name="listener">The code to remove from the event.</param>
        /// <returns>True if it was successfully removed, otherwise false. It would fail to remove
        /// if the method failed to aquire the Assembly of the mod that called the method.</returns>
        public bool RemoveListener(Action<T1, T2, T3, T4, T5> listener);

        /// <summary>
        /// Invoke this event, causing every Listeners from every mod to execute.
        /// </summary>
        public void InvokeAll(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5);

        /// <summary>
        /// Invoke this event, causing only the listeners from THIS MOD to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5);

        /// <summary>
        /// Returns the ModEvent associated with the Mod that called this method.
        /// </summary>
        /// <returns></returns>
        public IModEvent<T1, T2, T3, T4, T5> GetModEvent();

        /// <summary>
        /// Implicitly add a listener to this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">Listener to add</param>
        /// <returns></returns>
        public static ISharedModEvent<T1, T2, T3, T4, T5> operator +(ISharedModEvent<T1, T2, T3, T4, T5> modEvent, Action<T1, T2, T3, T4, T5> codeToRun)
        {
            modEvent.AddListener(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a listener to this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">Listener to remove</param>
        /// <returns></returns>
        public static ISharedModEvent<T1, T2, T3, T4, T5> operator -(ISharedModEvent<T1, T2, T3, T4, T5> modEvent, Action<T1, T2, T3, T4, T5> codeToRun)
        {
            modEvent.RemoveListener(codeToRun);
            return modEvent;
        }
    }
}
