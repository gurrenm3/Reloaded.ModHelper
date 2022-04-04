﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Reloaded.ModHelper
{

    #region Mod Event (No Parameters)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// </summary>
    public class ModEvent : IModEvent
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public List<Action> Listeners => _listeners;
        private List<Action> _listeners = new List<Action>();

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
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddListener(Action action)
        {
            Listeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(Action action)
        {
            return Listeners.Remove(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(int index)
        {
            return Listeners.Remove(Listeners.ElementAt(index));
        }

        /// <summary>
        /// <inheritdoc/>
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
    public class ModEvent<T> : IModEvent<T>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public List<Action<T>> Listeners => _listeners;
        private List<Action<T>> _listeners = new List<Action<T>>();

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
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddListener(Action<T> action)
        {
            Listeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(Action<T> action)
        {
            return Listeners.Remove(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(int index)
        {
            return Listeners.Remove(Listeners.ElementAt(index));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="value"><inheritdoc/></param>
        public void Invoke(T value)
        {
            Listeners.InvokeAll(value);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="value"><inheritdoc/></param>
        public void Invoke(ref T value)
        {
            Listeners.InvokeAll(value);
        }
    }

    #endregion



    #region Mod Event (Two Parameters)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// </summary>
    public class ModEvent<T1, T2> : IModEvent<T1, T2>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public List<Action<T1, T2>> Listeners => _listeners;
        private List<Action<T1, T2>> _listeners = new List<Action<T1,T2>>();

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
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddListener(Action<T1, T2> action)
        {
            Listeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(Action<T1, T2> action)
        {
            return Listeners.Remove(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(int index)
        {
            return Listeners.Remove(Listeners.ElementAt(index));
        }

        /// <summary>
        /// <inheritdoc/>
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
    public class ModEvent<T1, T2, T3> : IModEvent<T1, T2, T3>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public List<Action<T1, T2, T3>> Listeners => _listeners;
        private List<Action<T1, T2, T3>> _listeners = new List<Action<T1, T2, T3>>();

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
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddListener(Action<T1, T2, T3> action)
        {
            Listeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(Action<T1, T2, T3> action)
        {
            return Listeners.Remove(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(int index)
        {
            return Listeners.Remove(Listeners.ElementAt(index));
        }

        /// <summary>
        /// <inheritdoc/>
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
    public class ModEvent<T1, T2, T3, T4> : IModEvent<T1, T2, T3, T4>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public List<Action<T1, T2, T3, T4>> Listeners => _listeners;
        private List<Action<T1, T2, T3, T4>> _listeners = new List<Action<T1, T2, T3, T4>>();


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
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddListener(Action<T1, T2, T3, T4> action)
        {
            Listeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(Action<T1, T2, T3, T4> action)
        {
            return Listeners.Remove(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(int index)
        {
            return Listeners.Remove(Listeners.ElementAt(index));
        }

        /// <summary>
        /// <inheritdoc/>
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
    public class ModEvent<T1, T2, T3, T4, T5> : IModEvent<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public List<Action<T1, T2, T3, T4, T5>> Listeners => _listeners;
        private List<Action<T1, T2, T3, T4, T5>> _listeners = new List<Action<T1, T2, T3, T4, T5>>();

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
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddListener(Action<T1, T2, T3, T4, T5> action)
        {
            Listeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(Action<T1, T2, T3, T4, T5> action)
        {
            return Listeners.Remove(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(int index)
        {
            return Listeners.Remove(Listeners.ElementAt(index));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            Listeners.InvokeAll(value1, value2, value3, value4, value5);
        }
    }

    #endregion
}
