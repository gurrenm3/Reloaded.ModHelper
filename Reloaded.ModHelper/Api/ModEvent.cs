using System;
using System.Collections.Generic;
using System.Linq;

namespace Reloaded.ModHelper
{

    #region Mod Event (No Parameters)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// </summary>
    public class ModEvent
    {
        /// <summary>
        /// All of the current listeners on this event. Each will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        public List<Action> Listeners { get; private set; } = new List<Action>();

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/>.
        /// </summary>
        public ModEvent()
        {

        }

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/> and adds a listener to it.
        /// </summary>
        /// <param name="action">Listener to add.</param>
        public ModEvent(Action action)
        {
            AddListener(action);
        }

        /// <summary>
        /// Add a new listener to this event. It will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        /// <param name="action">Action to add as a listener.</param>
        public void AddListener(Action action)
        {
            Listeners.Add(action);
        }

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="action">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(Action action)
        {
            return Listeners.Remove(action);
        }

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="index">The index of the Action to remove.</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(int index)
        {
            return Listeners.Remove(Listeners.ElementAt(index));
        }

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke()
        {
            Listeners.InvokeAll();
        }
    }

    #endregion



    #region Mod Event (One Parameter)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// </summary>
    public class ModEvent<T>
    {
        /// <summary>
        /// All of the current listeners on this event. Each will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        public List<Action<T>> Listeners { get; private set; } = new List<Action<T>>();

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/>.
        /// </summary>
        public ModEvent()
        {

        }

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/> and adds a listener to it.
        /// </summary>
        /// <param name="action">Listener to add.</param>
        public ModEvent(Action<T> action)
        {
            AddListener(action);
        }

        /// <summary>
        /// Add a new listener to this event. It will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        /// <param name="action">Action to add as a listener.</param>
        public void AddListener(Action<T> action)
        {
            Listeners.Add(action);
        }

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="action">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(Action<T> action)
        {
            return Listeners.Remove(action);
        }

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="index">The index of the Action to remove.</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(int index)
        {
            return Listeners.Remove(Listeners.ElementAt(index));
        }

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke(T value)
        {
            Listeners.InvokeAll(value);
        }
    }

    #endregion



    #region Mod Event (Two Parameters)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// </summary>
    public class ModEvent<T1, T2>
    {
        /// <summary>
        /// All of the current listeners on this event. Each will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        public List<Action<T1, T2>> Listeners { get; private set; } = new List<Action<T1, T2>>();

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/>.
        /// </summary>
        public ModEvent()
        {

        }

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/> and adds a listener to it.
        /// </summary>
        /// <param name="action">Listener to add.</param>
        public ModEvent(Action<T1, T2> action)
        {
            AddListener(action);
        }

        /// <summary>
        /// Add a new listener to this event. It will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        /// <param name="action">Action to add as a listener.</param>
        public void AddListener(Action<T1, T2> action)
        {
            Listeners.Add(action);
        }

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="action">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(Action<T1, T2> action)
        {
            return Listeners.Remove(action);
        }

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="index">The index of the Action to remove.</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(int index)
        {
            return Listeners.Remove(Listeners.ElementAt(index));
        }

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2)
        {
            Listeners.InvokeAll(value1, value2);
        }
    }

    #endregion



    #region Mod Event (Three Parameters)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// </summary>
    public class ModEvent<T1, T2, T3>
    {
        /// <summary>
        /// All of the current listeners on this event. Each will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        public List<Action<T1, T2, T3>> Listeners { get; private set; } = new List<Action<T1, T2, T3>>();

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/>.
        /// </summary>
        public ModEvent()
        {

        }

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/> and adds a listener to it.
        /// </summary>
        /// <param name="action">Listener to add.</param>
        public ModEvent(Action<T1, T2, T3> action)
        {
            AddListener(action);
        }

        /// <summary>
        /// Add a new listener to this event. It will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        /// <param name="action">Action to add as a listener.</param>
        public void AddListener(Action<T1, T2, T3> action)
        {
            Listeners.Add(action);
        }

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="action">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(Action<T1, T2, T3> action)
        {
            return Listeners.Remove(action);
        }

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="index">The index of the Action to remove.</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(int index)
        {
            return Listeners.Remove(Listeners.ElementAt(index));
        }

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3)
        {
            Listeners.InvokeAll(value1, value2, value3);
        }
    }

    #endregion



    #region Mod Event (Four Parameters)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// </summary>
    public class ModEvent<T1, T2, T3, T4>
    {
        /// <summary>
        /// All of the current listeners on this event. Each will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        public List<Action<T1, T2, T3, T4>> Listeners { get; private set; } = new List<Action<T1, T2, T3, T4>>();

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/>.
        /// </summary>
        public ModEvent()
        {

        }

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/> and adds a listener to it.
        /// </summary>
        /// <param name="action">Listener to add.</param>
        public ModEvent(Action<T1, T2, T3, T4> action)
        {
            AddListener(action);
        }

        /// <summary>
        /// Add a new listener to this event. It will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        /// <param name="action">Action to add as a listener.</param>
        public void AddListener(Action<T1, T2, T3, T4> action)
        {
            Listeners.Add(action);
        }

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="action">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(Action<T1, T2, T3, T4> action)
        {
            return Listeners.Remove(action);
        }

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="index">The index of the Action to remove.</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(int index)
        {
            return Listeners.Remove(Listeners.ElementAt(index));
        }

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            Listeners.InvokeAll(value1, value2, value3, value4);
        }
    }

    #endregion



    #region Mod Event (Five Parameters)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// </summary>
    public class ModEvent<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// All of the current listeners on this event. Each will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        public List<Action<T1, T2, T3, T4, T5>> Listeners { get; private set; } = new List<Action<T1, T2, T3, T4, T5>>();

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/>.
        /// </summary>
        public ModEvent()
        {

        }

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/> and adds a listener to it.
        /// </summary>
        /// <param name="action">Listener to add.</param>
        public ModEvent(Action<T1, T2, T3, T4, T5> action)
        {
            AddListener(action);
        }

        /// <summary>
        /// Add a new listener to this event. It will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        /// <param name="action">Action to add as a listener.</param>
        public void AddListener(Action<T1, T2, T3, T4, T5> action)
        {
            Listeners.Add(action);
        }

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="action">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(Action<T1, T2, T3, T4, T5> action)
        {
            return Listeners.Remove(action);
        }

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="index">The index of the Action to remove.</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(int index)
        {
            return Listeners.Remove(Listeners.ElementAt(index));
        }

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            Listeners.InvokeAll(value1, value2, value3, value4, value5);
        }
    }

    #endregion
}
