﻿using System;
using System.Collections.Generic;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// </summary>
    public interface IModEvent
    {
        /// <summary>
        /// All of the current listeners on this event. Each will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        public List<Action> Listeners { get; }

        /// <summary>
        /// Add a new listener to this event. It will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        /// <param name="action">Action to add as a listener.</param>
        public void AddListener(Action action);

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="index">The index of the Action to remove.</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(int index);

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="action">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(Action action);

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke();

        /// <summary>
        /// Implicitly add a listener to this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">Listener to add</param>
        /// <returns></returns>
        public static IModEvent operator +(IModEvent modEvent, Action codeToRun)
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
        public static IModEvent operator -(IModEvent modEvent, Action codeToRun)
        {
            modEvent.RemoveListener(codeToRun);
            return modEvent;
        }
    }




    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// </summary>
    public interface IModEvent<T>
    {
        /// <summary>
        /// All of the current listeners on this event. Each will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        public List<Action<T>> Listeners { get; }

        /// <summary>
        /// Add a new listener to this event. It will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        /// <param name="action">Action to add as a listener.</param>
        public void AddListener(Action<T> action);

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="index">The index of the Action to remove.</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(int index);

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="action">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(Action<T> action);

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke(T value);

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke(ref T value);

        /// <summary>
        /// Implicitly add a listener to this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">Listener to add</param>
        /// <returns></returns>
        public static IModEvent<T> operator +(IModEvent<T> modEvent, Action<T> codeToRun)
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
        public static IModEvent<T> operator -(IModEvent<T> modEvent, Action<T> codeToRun)
        {
            modEvent.RemoveListener(codeToRun);
            return modEvent;
        }
    }




    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// </summary>
    public interface IModEvent<T1, T2>
    {
        /// <summary>
        /// All of the current listeners on this event. Each will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        public List<Action<T1, T2>> Listeners { get; }

        /// <summary>
        /// Add a new listener to this event. It will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        /// <param name="action">Action to add as a listener.</param>
        public void AddListener(Action<T1, T2> action);

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="index">The index of the Action to remove.</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(int index);

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="action">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(Action<T1, T2> action);

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2);

        /// <summary>
        /// Implicitly add a listener to this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">Listener to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2> operator +(IModEvent<T1, T2> modEvent, Action<T1, T2> codeToRun)
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
        public static IModEvent<T1, T2> operator -(IModEvent<T1, T2> modEvent, Action<T1, T2> codeToRun)
        {
            modEvent.RemoveListener(codeToRun);
            return modEvent;
        }
    }



    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// </summary>
    public interface IModEvent<T1, T2, T3>
    {
        /// <summary>
        /// All of the current listeners on this event. Each will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        public List<Action<T1, T2, T3>> Listeners { get; }

        /// <summary>
        /// Add a new listener to this event. It will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        /// <param name="action">Action to add as a listener.</param>
        public void AddListener(Action<T1, T2, T3> action);

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="index">The index of the Action to remove.</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(int index);

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="action">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(Action<T1, T2, T3> action);

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3);

        /// <summary>
        /// Implicitly add a listener to this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">Listener to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3> operator +(IModEvent<T1, T2, T3> modEvent, Action<T1, T2, T3> codeToRun)
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
        public static IModEvent<T1, T2, T3> operator -(IModEvent<T1, T2, T3> modEvent, Action<T1, T2, T3> codeToRun)
        {
            modEvent.RemoveListener(codeToRun);
            return modEvent;
        }
    }



    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// </summary>
    public interface IModEvent<T1, T2, T3, T4>
    {
        /// <summary>
        /// All of the current listeners on this event. Each will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        public List<Action<T1, T2, T3, T4>> Listeners { get; }

        /// <summary>
        /// Add a new listener to this event. It will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        /// <param name="action">Action to add as a listener.</param>
        public void AddListener(Action<T1, T2, T3, T4> action);

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="index">The index of the Action to remove.</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(int index);

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="action">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(Action<T1, T2, T3, T4> action);

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4);

        /// <summary>
        /// Implicitly add a listener to this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">Listener to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4> operator +(IModEvent<T1, T2, T3, T4> modEvent, Action<T1, T2, T3, T4> codeToRun)
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
        public static IModEvent<T1, T2, T3, T4> operator -(IModEvent<T1, T2, T3, T4> modEvent, Action<T1, T2, T3, T4> codeToRun)
        {
            modEvent.RemoveListener(codeToRun);
            return modEvent;
        }
    }



    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// </summary>
    public interface IModEvent<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// All of the current listeners on this event. Each will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        public List<Action<T1, T2, T3, T4, T5>> Listeners { get; }

        /// <summary>
        /// Add a new listener to this event. It will be activated whenever <see cref="Invoke"/> is called.
        /// </summary>
        /// <param name="action">Action to add as a listener.</param>
        public void AddListener(Action<T1, T2, T3, T4, T5> action);

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="index">The index of the Action to remove.</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(int index);

        /// <summary>
        /// Remove a listener from <see cref="Listeners"/>
        /// </summary>
        /// <param name="action">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveListener(Action<T1, T2, T3, T4, T5> action);

        /// <summary>
        /// Invoke this event, causing all Listeners to execute.
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5);

        /// <summary>
        /// Implicitly add a listener to this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">Listener to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4, T5> operator +(IModEvent<T1, T2, T3, T4, T5> modEvent, Action<T1, T2, T3, T4, T5> codeToRun)
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
        public static IModEvent<T1, T2, T3, T4, T5> operator -(IModEvent<T1, T2, T3, T4, T5> modEvent, Action<T1, T2, T3, T4, T5> codeToRun)
        {
            modEvent.RemoveListener(codeToRun);
            return modEvent;
        }
    }
}
