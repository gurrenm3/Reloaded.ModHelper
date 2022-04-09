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
        /// Called automatically once during <see cref="Invoke"/> once all listeners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedInvoking { get; set; } 

        private List<Action> _listeners = new List<Action>();

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/>.
        /// </summary>
        public ModEvent(bool useOnFinishedInvoking = true)
        {
            if (useOnFinishedInvoking)
                OnFinishedInvoking = new ModEvent(false);
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
        /// <returns></returns>
        public List<Action> GetListeners()
        {
            return _listeners;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddListener(Action action)
        {
            _listeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(int index)
        {
            return _listeners.Remove(_listeners.ElementAt(index));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(Action action)
        {
            return _listeners.Remove(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Invoke()
        {
            if (_listeners.Any())
            {
                _listeners.InvokeAll();
                OnFinishedInvoking?.Invoke();
            }
        }

        List<Action> IModEvent.GetListeners()
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
        /// Called automatically once during <see cref="Invoke"/> once all listeners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedInvoking { get; set; }

        private List<Action<T1>> _listeners = new List<Action<T1>>();

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/>.
        /// </summary>
        public ModEvent(bool useOnFinishedInvoking = true)
        {
            if (useOnFinishedInvoking)
                OnFinishedInvoking = new ModEvent(false);
        }

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/> and adds a listener to it.
        /// </summary>
        /// <param name="action">Listener to add.</param>
        public ModEvent(Action<T1> action)
        {
            AddListener(action);
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
        public void AddListener(Action<T1> action)
        {
            _listeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(int index)
        {
            return _listeners.Remove(_listeners.ElementAt(index));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(Action<T1> action)
        {
            return _listeners.Remove(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="value"><inheritdoc/></param>
        public void Invoke(T1 value)
        {
            if (_listeners.Any())
            {
                _listeners.InvokeAll(value);
                OnFinishedInvoking?.Invoke();
            }    
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
        /// Called automatically once during <see cref="Invoke"/> once all listeners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedInvoking { get; set; }

        private List<Action<T1, T2>> _listeners = new List<Action<T1, T2>>();

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/>.
        /// </summary>
        public ModEvent(bool useOnFinishedInvoking = true)
        {
            if (useOnFinishedInvoking)
                OnFinishedInvoking = new ModEvent(false);
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
        /// <returns></returns>
        public List<Action<T1, T2>> GetListeners()
        {
            return _listeners;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddListener(Action<T1, T2> action)
        {
            _listeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(int index)
        {
            return _listeners.Remove(_listeners.ElementAt(index));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(Action<T1, T2> action)
        {
            return _listeners.Remove(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Invoke(T1 value1, T2 value2)
        {
            if (_listeners.Any())
            {
                _listeners.InvokeAll(value1, value2);
                OnFinishedInvoking?.Invoke();
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
        /// Called automatically once during <see cref="Invoke"/> once all listeners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedInvoking { get; set; }

        private List<Action<T1, T2, T3>> _listeners = new List<Action<T1, T2, T3>>();

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/>.
        /// </summary>
        public ModEvent(bool useOnFinishedInvoking = true)
        {
            if (useOnFinishedInvoking)
                OnFinishedInvoking = new ModEvent(false);
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
        /// <returns></returns>
        public List<Action<T1, T2, T3>> GetListeners()
        {
            return _listeners;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddListener(Action<T1, T2, T3> action)
        {
            _listeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(int index)
        {
            return _listeners.Remove(_listeners.ElementAt(index));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(Action<T1, T2, T3> action)
        {
            return _listeners.Remove(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3)
        {
            if (_listeners.Any())
            {
                _listeners.InvokeAll(value1, value2, value3);
                OnFinishedInvoking?.Invoke();
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
        /// Called automatically once during <see cref="Invoke"/> once all listeners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedInvoking { get; set; }

        private List<Action<T1, T2, T3, T4>> _listeners = new List<Action<T1, T2, T3, T4>>();


        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/>.
        /// </summary>
        public ModEvent(bool useOnFinishedInvoking = true)
        {
            if (useOnFinishedInvoking)
                OnFinishedInvoking = new ModEvent(false);
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
        /// <returns></returns>
        public List<Action<T1, T2, T3, T4>> GetListeners()
        {
            return _listeners;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddListener(Action<T1, T2, T3, T4> action)
        {
            _listeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(int index)
        {
            return _listeners.Remove(_listeners.ElementAt(index));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(Action<T1, T2, T3, T4> action)
        {
            return _listeners.Remove(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            if (_listeners.Any())
            {
                _listeners.InvokeAll(value1, value2, value3, value4);
                OnFinishedInvoking?.Invoke();
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
        /// Called automatically once during <see cref="Invoke"/> once all listeners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedInvoking { get; set; }

        private List<Action<T1, T2, T3, T4, T5>> _listeners = new List<Action<T1, T2, T3, T4, T5>>();

        /// <summary>
        /// Creates an instance of <see cref="ModEvent"/>.
        /// </summary>
        public ModEvent(bool useOnFinishedInvoking = true)
        {
            if (useOnFinishedInvoking)
                OnFinishedInvoking = new ModEvent(false);
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
        /// <returns></returns>
        public List<Action<T1, T2, T3, T4, T5>> GetListeners()
        {
            return _listeners;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        public void AddListener(Action<T1, T2, T3, T4, T5> action)
        {
            _listeners.Add(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="index"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(int index)
        {
            return _listeners.Remove(_listeners.ElementAt(index));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="action"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public bool RemoveListener(Action<T1, T2, T3, T4, T5> action)
        {
            return _listeners.Remove(action);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Invoke(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            if (_listeners.Any())
            {
                _listeners.InvokeAll(value1, value2, value3, value4, value5);
                OnFinishedInvoking?.Invoke();
            }
        }
    }

    #endregion
}
