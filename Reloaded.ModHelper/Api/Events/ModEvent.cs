using System;
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
        /// Called automatically once during <see cref="Run"/> once all listeners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedRunning { get; set; } 

        private List<Action> _listeners = new List<Action>();

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/>.
        /// </summary>
        public ModEvent(bool useOnFinishedInvoking = true)
        {
            if (useOnFinishedInvoking)
                OnFinishedRunning = new ModEvent(false);
        }

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/> and adds a listener to it.
        /// </summary>
        /// <param name="action">Listener to add.</param>
        public ModEvent(Action action)
        {
            AddRunner(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public List<Action> GetListeners()
        {
            return _listeners;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddRunner(Action action)
        {
            _listeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(int index)
        {
            return _listeners.Remove(_listeners.ElementAt(index));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(Action action)
        {
            return _listeners.Remove(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Run()
        {
            if (_listeners.Any())
            {
                _listeners.InvokeAll();
                OnFinishedRunning?.Run();
            }
        }

        List<Action> IModEvent.GetRunners()
        {
            throw new NotImplementedException();
        }
    }

    #endregion



    #region Mod Event (One Parameter)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// </summary>
    public class ModEvent<T1> : IModEvent<T1>
    {
        /// <summary>
        /// Called automatically once during <see cref="Run"/> once all listeners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedRunning { get; set; }

        private List<Action<T1>> _listeners = new List<Action<T1>>();
        private List<ActionRef1<T1>> _refListeners = new List<ActionRef1<T1>>();

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/>.
        /// </summary>
        /// <param name="useOnFinishedInvoking">Specify whether or not <see cref="OnFinishedRunning"/>
        /// will be used and therefore should be initialized.</param>
        public ModEvent(bool useOnFinishedInvoking = true)
        {
            if (useOnFinishedInvoking)
                OnFinishedRunning = new ModEvent(false);
        }

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/> and adds a listener to it.
        /// </summary>
        /// <param name="action">Listener to add.</param>
        public ModEvent(Action<T1> action)
        {
            AddRunner(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public List<Action<T1>> GetListeners()
        {
            return _listeners;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddRunner(Action<T1> action)
        {
            _listeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddRunner(ActionRef1<T1> action)
        {
            _refListeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(int index)
        {
            return _listeners.Remove(_listeners.ElementAt(index));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(Action<T1> action)
        {
            return _listeners.Remove(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="value"><inheritdoc/></param>
        public void Run(T1 value)
        {
            for (int i = 0; i < _refListeners.Count; i++)
            {
                _refListeners[i].Invoke(ref value);
            }

            if (_listeners.Any())
            {
                _listeners.InvokeAll(value);
            }

            OnFinishedRunning?.Run();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="value"><inheritdoc/></param>
        public void Run(ref T1 value)
        {
            for (int i = 0; i < _refListeners.Count; i++)
            {
                _refListeners[i].Invoke(ref value);
            }

            if (_listeners.Any())
            {
                _listeners.InvokeAll(value);
            }

            OnFinishedRunning?.Run();
        }

        public List<Action<T1>> GetRunners()
        {
            throw new NotImplementedException();
        }

        public bool RemoveRunner(ActionRef1<T1> codeToRemove)
        {
            throw new NotImplementedException();
        }
    }

    #endregion


/*
    #region Mod Event (Two Parameters)

    /// <summary>
    /// A custom event type that allows for multiple "listeners" that can easily be invoked all at once.
    /// </summary>
    public class ModEvent<T1, T2> : IModEvent<T1, T2>
    {
        /// <summary>
        /// Called automatically once during <see cref="Run"/> once all listeners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedRunning { get; set; }

        private List<Action<T1, T2>> _listeners = new List<Action<T1, T2>>();

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/>.
        /// </summary>
        /// <param name="useOnFinishedInvoking">Specify whether or not <see cref="OnFinishedRunning"/>
        /// will be used and therefore should be initialized.</param>
        public ModEvent(bool useOnFinishedInvoking = true)
        {
            if (useOnFinishedInvoking)
                OnFinishedRunning = new ModEvent(false);
        }

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/> and adds a listener to it.
        /// </summary>
        /// <param name="action">Listener to add.</param>
        public ModEvent(Action<T1, T2> action)
        {
            AddRunner(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public List<Action<T1, T2>> GetRunners()
        {
            return _listeners;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddRunner(Action<T1, T2> action)
        {
            _listeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(int index)
        {
            return _listeners.Remove(_listeners.ElementAt(index));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(Action<T1, T2> action)
        {
            return _listeners.Remove(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Run(T1 value1, T2 value2)
        {
            if (_listeners.Any())
            {
                _listeners.InvokeAll(value1, value2);
                OnFinishedRunning?.Run();
            }
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
        /// Called automatically once during <see cref="Run"/> once all listeners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedRunning { get; set; }

        private List<Action<T1, T2, T3>> _listeners = new List<Action<T1, T2, T3>>();

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/>.
        /// </summary>
        /// <param name="useOnFinishedInvoking">Specify whether or not <see cref="OnFinishedRunning"/>
        /// will be used and therefore should be initialized.</param>
        public ModEvent(bool useOnFinishedInvoking = true)
        {
            if (useOnFinishedInvoking)
                OnFinishedRunning = new ModEvent(false);
        }

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/> and adds a listener to it.
        /// </summary>
        /// <param name="action">Listener to add.</param>
        public ModEvent(Action<T1, T2, T3> action)
        {
            AddRunner(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public List<Action<T1, T2, T3>> GetRunners()
        {
            return _listeners;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddRunner(Action<T1, T2, T3> action)
        {
            _listeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(int index)
        {
            return _listeners.Remove(_listeners.ElementAt(index));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(Action<T1, T2, T3> action)
        {
            return _listeners.Remove(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Run(T1 value1, T2 value2, T3 value3)
        {
            if (_listeners.Any())
            {
                _listeners.InvokeAll(value1, value2, value3);
                OnFinishedRunning?.Run();
            }
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
        /// Called automatically once during <see cref="Run"/> once all listeners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedRunning { get; set; }

        private List<Action<T1, T2, T3, T4>> _listeners = new List<Action<T1, T2, T3, T4>>();


        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/>.
        /// </summary>
        /// <param name="useOnFinishedInvoking">Specify whether or not <see cref="OnFinishedRunning"/>
        /// will be used and therefore should be initialized.</param>
        public ModEvent(bool useOnFinishedInvoking = true)
        {
            if (useOnFinishedInvoking)
                OnFinishedRunning = new ModEvent(false);
        }

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/> and adds a listener to it.
        /// </summary>
        /// <param name="action">Listener to add.</param>
        public ModEvent(Action<T1, T2, T3, T4> action)
        {
            AddRunner(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public List<Action<T1, T2, T3, T4>> GetRunners()
        {
            return _listeners;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddRunner(Action<T1, T2, T3, T4> action)
        {
            _listeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(int index)
        {
            return _listeners.Remove(_listeners.ElementAt(index));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(Action<T1, T2, T3, T4> action)
        {
            return _listeners.Remove(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Run(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            if (_listeners.Any())
            {
                _listeners.InvokeAll(value1, value2, value3, value4);
                OnFinishedRunning?.Run();
            }
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
        /// Called automatically once during <see cref="Run"/> once all listeners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedRunning { get; set; }

        private List<Action<T1, T2, T3, T4, T5>> _listeners = new List<Action<T1, T2, T3, T4, T5>>();

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/>.
        /// </summary>
        /// <param name="useOnFinishedInvoking">Specify whether or not <see cref="OnFinishedRunning"/>
        /// will be used and therefore should be initialized.</param>
        public ModEvent(bool useOnFinishedInvoking = true)
        {
            if (useOnFinishedInvoking)
                OnFinishedRunning = new ModEvent(false);
        }

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/> and adds a listener to it.
        /// </summary>
        /// <param name="action">Listener to add.</param>
        public ModEvent(Action<T1, T2, T3, T4, T5> action)
        {
            AddRunner(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public List<Action<T1, T2, T3, T4, T5>> GetRunners()
        {
            return _listeners;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddRunner(Action<T1, T2, T3, T4, T5> action)
        {
            _listeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(int index)
        {
            return _listeners.Remove(_listeners.ElementAt(index));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveRunner(Action<T1, T2, T3, T4, T5> action)
        {
            return _listeners.Remove(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Run(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            if (_listeners.Any())
            {
                _listeners.InvokeAll(value1, value2, value3, value4, value5);
                OnFinishedRunning?.Run();
            }
        }
    }

    #endregion*/
}
