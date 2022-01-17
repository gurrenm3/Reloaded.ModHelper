using System;
using System.Collections.Generic;

namespace Reloaded.ModHelper
{

    #region Mod Event (No Parameters)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once. 
    /// <br/>Unlike the traditional <see cref="ModEvent"/> this one doesn't support removing listeners.
    /// </summary>
    public class ReadOnlyModEvent
    {
        /// <summary>
        /// All of the current listeners on this event. Each will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        public List<Action> Listeners { get; set; }

        /// <summary>
        /// Add a new listener to this event. It will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        /// <param name="action">Action to add as a listener.</param>
        public void AddListener(Action action)
        {
            if (Listeners == null)
                Listeners = new List<Action>();

            Listeners.Add(action);
        }

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke()
        {
            Listeners?.InvokeAll();
        }
    }

    #endregion



    #region Mod Event (One Parameter)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// <br/>Unlike the traditional <see cref="ModEvent"/> this one doesn't support removing listeners.
    /// </summary>
    public class ReadOnlyModEvent<T>
    {
        /// <summary>
        /// All of the current listeners on this event. Each will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        public List<Action<T>> Listeners { get; set; }

        /// <summary>
        /// Add a new listener to this event. It will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        /// <param name="action">Action to add as a listener.</param>
        public void AddListener(Action<T> action)
        {
            if (Listeners == null)
                Listeners = new List<Action<T>>();

            Listeners.Add(action);
        }

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke(T value)
        {
            Listeners?.InvokeAll(value);
        }
    }

    #endregion



    #region Mod Event (Two Parameters)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// <br/>Unlike the traditional <see cref="ModEvent"/> this one doesn't support removing listeners.
    /// </summary>
    public class ReadOnlyModEvent<T1, T2>
    {
        /// <summary>
        /// All of the current listeners on this event. Each will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        public List<Action<T1, T2>> Listeners { get; set; }

        /// <summary>
        /// Add a new listener to this event. It will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        /// <param name="action">Action to add as a listener.</param>
        public void AddListener(Action<T1, T2> action)
        {
            if (Listeners == null)
                Listeners = new List<Action<T1, T2>>();

            Listeners.Add(action);
        }

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2)
        {
            Listeners?.InvokeAll(value1, value2);
        }
    }

    #endregion



    #region Mod Event (Three Parameters)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// <br/>Unlike the traditional <see cref="ModEvent"/> this one doesn't support removing listeners.
    /// </summary>
    public class ReadOnlyModEvent<T1, T2, T3>
    {
        /// <summary>
        /// All of the current listeners on this event. Each will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        public List<Action<T1, T2, T3>> Listeners { get; set; }

        /// <summary>
        /// Add a new listener to this event. It will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        /// <param name="action">Action to add as a listener.</param>
        public void AddListener(Action<T1, T2, T3> action)
        {
            if (Listeners == null)
                Listeners = new List<Action<T1, T2, T3>>();

            Listeners.Add(action);
        }

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3)
        {
            Listeners?.InvokeAll(value1, value2, value3);
        }
    }

    #endregion



    #region Mod Event (Four Parameters)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// <br/>Unlike the traditional <see cref="ModEvent"/> this one doesn't support removing listeners.
    /// </summary>
    public class ReadOnlyModEvent<T1, T2, T3, T4>
    {
        /// <summary>
        /// All of the current listeners on this event. Each will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        public List<Action<T1, T2, T3, T4>> Listeners { get; set; }

        /// <summary>
        /// Add a new listener to this event. It will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        /// <param name="action">Action to add as a listener.</param>
        public void AddListener(Action<T1, T2, T3, T4> action)
        {
            if (Listeners == null)
                Listeners = new List<Action<T1, T2, T3, T4>>();

            Listeners.Add(action);
        }

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            Listeners?.InvokeAll(value1, value2, value3, value4);
        }
    }

    #endregion



    #region Mod Event (Five Parameters)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// <br/>Unlike the traditional <see cref="ModEvent"/> this one doesn't support removing listeners.
    /// </summary>
    public class ReadOnlyModEvent<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// All of the current listeners on this event. Each will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        public List<Action<T1, T2, T3, T4, T5>> Listeners { get; set; }

        /// <summary>
        /// Add a new listener to this event. It will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        /// <param name="action">Action to add as a listener.</param>
        public void AddListener(Action<T1, T2, T3, T4, T5> action)
        {
            if (Listeners == null)
                Listeners = new List<Action<T1, T2, T3, T4, T5>>();

            Listeners.Add(action);
        }

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            Listeners?.InvokeAll(value1, value2, value3, value4, value5);
        }
    }

    #endregion
}
