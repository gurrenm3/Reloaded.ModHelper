using System;
using System.Collections.Generic;

namespace Reloaded.ModHelper
{
    public interface IModEventBase
    {
        /// <summary>
        /// Called automatically once during "<see cref="Run"/>()" once all runners have finished being invoked.
        /// </summary>
        public IModEvent OnFinishedRunning { get; set; }

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="index">The index of the Action to remove.</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(int index);
    }

    /// <summary>
    /// A custom event type that allows for multiple "runners" that can easily be invoked all at once.
    /// </summary>
    public interface IModEvent : IModEventBase
    {
        /// <summary>
        /// Returns a list of all of the current runners on this event.
        /// </summary>
        public List<Action> GetRunners();

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// </summary>
        /// <param name="codeToRun">Action to add as a runner.</param>
        public void AddRunner(Action codeToRun);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(Action codeToRemove);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// </summary>
        public void Run();

        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent operator +(IModEvent modEvent, Action codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent operator -(IModEvent modEvent, Action codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }
    }




    /// <summary>
    /// A custom event type that allows for multiple "runners" that can easily be invoked all at once.
    /// </summary>
    public interface IModEvent<T1> : IModEventBase
    {
        /// <summary>
        /// Returns a list of all of the current runners on this event.
        /// </summary>
        public List<Action<T1>> GetRunners();

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// </summary>
        /// <param name="codeToRun">Action to add as a runner.</param>
        public void AddRunner(Action<T1> codeToRun);

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called. 
        /// <br/>Allows passing argument by reference.
        /// </summary>
        /// <param name="codeToRun"></param>
        public void AddRunner(ActionRef1<T1> codeToRun);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(Action<T1> codeToRemove);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(ActionRef1<T1> codeToRemove);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// </summary>
        public void Run(T1 value);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        /// <param name="value"></param>
        public void Run(ref T1 value);

        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1> operator +(IModEvent<T1> modEvent, Action<T1> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1> operator +(IModEvent<T1> modEvent, ActionRef1<T1> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1> operator -(IModEvent<T1> modEvent, Action<T1> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1> operator -(IModEvent<T1> modEvent, ActionRef1<T1> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }
    }




    /// <summary>
    /// A custom event type that allows for multiple "runners" that can easily be invoked all at once.
    /// </summary>
    public interface IModEvent<T1, T2> : IModEventBase
    {
        /// <summary>
        /// Returns a list of all of the current runners on this event.
        /// </summary>
        public List<Action<T1, T2>> GetRunners();

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// </summary>
        /// <param name="codeToRun">Action to add as a runner.</param>
        public void AddRunner(Action<T1, T2> codeToRun);

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        /// <param name="codeToRun">Action to add as a runner.</param>
        public void AddRunner(ActionRef1<T1, T2> codeToRun);

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        /// <param name="codeToRun">Action to add as a runner.</param>
        public void AddRunner(ActionRef2<T1, T2> codeToRun);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(Action<T1, T2> codeToRemove);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(ActionRef1<T1, T2> codeToRemove);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(ActionRef2<T1, T2> codeToRemove);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// </summary>
        public void Run(T1 value1, T2 value2);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        public void Run(ref T1 value1, T2 value2);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        public void Run(ref T1 value1, ref T2 value2);


        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2> operator +(IModEvent<T1, T2> modEvent, Action<T1, T2> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2> operator +(IModEvent<T1, T2> modEvent, ActionRef1<T1, T2> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }


        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2> operator +(IModEvent<T1, T2> modEvent, ActionRef2<T1, T2> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1, T2> operator -(IModEvent<T1, T2> modEvent, Action<T1, T2> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1, T2> operator -(IModEvent<T1, T2> modEvent, ActionRef1<T1, T2> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1, T2> operator -(IModEvent<T1, T2> modEvent, ActionRef2<T1, T2> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }
    }



    /// <summary>
    /// A custom event type that allows for multiple "runners" that can easily be invoked all at once.
    /// </summary>
    public interface IModEvent<T1, T2, T3> : IModEventBase
    {
        /// <summary>
        /// Returns a list of all of the current runners on this event.
        /// </summary>
        public List<Action<T1, T2, T3>> GetRunners();

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// </summary>
        /// <param name="codeToRun">Action to add as a runner.</param>
        public void AddRunner(Action<T1, T2, T3> codeToRun);

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        /// <param name="codeToRun">Action to add as a runner.</param>
        public void AddRunner(ActionRef1<T1, T2, T3> codeToRun);

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        /// <param name="codeToRun">Action to add as a runner.</param>
        public void AddRunner(ActionRef2<T1, T2, T3> codeToRun);

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        /// <param name="codeToRun">Action to add as a runner.</param>
        public void AddRunner(ActionRef3<T1, T2, T3> codeToRun);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(Action<T1, T2, T3> codeToRemove);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(ActionRef1<T1, T2, T3> codeToRemove);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(ActionRef2<T1, T2, T3> codeToRemove);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(ActionRef3<T1, T2, T3> codeToRemove);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// </summary>
        public void Run(T1 value1, T2 value2, T3 value3);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        public void Run(ref T1 value1, T2 value2, T3 value3);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        public void Run(ref T1 value1, ref T2 value2, T3 value3);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        public void Run(ref T1 value1, ref T2 value2, ref T3 value3);
        

        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3> operator +(IModEvent<T1, T2, T3> modEvent, Action<T1, T2, T3> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3> operator +(IModEvent<T1, T2, T3> modEvent, ActionRef1<T1, T2, T3> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3> operator +(IModEvent<T1, T2, T3> modEvent, ActionRef2<T1, T2, T3> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3> operator +(IModEvent<T1, T2, T3> modEvent, ActionRef3<T1, T2, T3> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3> operator -(IModEvent<T1, T2, T3> modEvent, Action<T1, T2, T3> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3> operator -(IModEvent<T1, T2, T3> modEvent, ActionRef1<T1, T2, T3> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3> operator -(IModEvent<T1, T2, T3> modEvent, ActionRef2<T1, T2, T3> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3> operator -(IModEvent<T1, T2, T3> modEvent, ActionRef3<T1, T2, T3> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }
    }



    /// <summary>
    /// A custom event type that allows for multiple "runners" that can easily be invoked all at once.
    /// </summary>
    public interface IModEvent<T1, T2, T3, T4> : IModEventBase
    {
        /// <summary>
        /// Returns a list of all of the current runners on this event.
        /// </summary>
        public List<Action<T1, T2, T3, T4>> GetRunners();

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// </summary>
        /// <param name="codeToRun">Action to add as a runner.</param>
        public void AddRunner(Action<T1, T2, T3, T4> codeToRun);

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        /// <param name="codeToRun">Action to add as a runner.</param>
        public void AddRunner(ActionRef1<T1, T2, T3, T4> codeToRun);

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        /// <param name="codeToRun">Action to add as a runner.</param>
        public void AddRunner(ActionRef2<T1, T2, T3, T4> codeToRun);

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        /// <param name="codeToRun">Action to add as a runner.</param>
        public void AddRunner(ActionRef3<T1, T2, T3, T4> codeToRun);

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        /// <param name="codeToRun">Action to add as a runner.</param>
        public void AddRunner(ActionRef4<T1, T2, T3, T4> codeToRun);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(Action<T1, T2, T3, T4> codeToRemove);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(ActionRef1<T1, T2, T3, T4> codeToRemove);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(ActionRef2<T1, T2, T3, T4> codeToRemove);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(ActionRef3<T1, T2, T3, T4> codeToRemove);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(ActionRef4<T1, T2, T3, T4> codeToRemove);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// </summary>
        public void Run(T1 value1, T2 value2, T3 value3, T4 value4);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        public void Run(ref T1 value1, T2 value2, T3 value3, T4 value4);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        public void Run(ref T1 value1, ref T2 value2, T3 value3, T4 value4);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        public void Run(ref T1 value1, ref T2 value2, ref T3 value3, T4 value4);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        public void Run(ref T1 value1, ref T2 value2, ref T3 value3, ref T4 value4);


        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4> operator +(IModEvent<T1, T2, T3, T4> modEvent, Action<T1, T2, T3, T4> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4> operator +(IModEvent<T1, T2, T3, T4> modEvent, ActionRef1<T1, T2, T3, T4> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4> operator +(IModEvent<T1, T2, T3, T4> modEvent, ActionRef2<T1, T2, T3, T4> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4> operator +(IModEvent<T1, T2, T3, T4> modEvent, ActionRef3<T1, T2, T3, T4> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4> operator +(IModEvent<T1, T2, T3, T4> modEvent, ActionRef4<T1, T2, T3, T4> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4> operator -(IModEvent<T1, T2, T3, T4> modEvent, Action<T1, T2, T3, T4> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4> operator -(IModEvent<T1, T2, T3, T4> modEvent, ActionRef1<T1, T2, T3, T4> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4> operator -(IModEvent<T1, T2, T3, T4> modEvent, ActionRef2<T1, T2, T3, T4> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4> operator -(IModEvent<T1, T2, T3, T4> modEvent, ActionRef3<T1, T2, T3, T4> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4> operator -(IModEvent<T1, T2, T3, T4> modEvent, ActionRef4<T1, T2, T3, T4> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }
    }



    /// <summary>
    /// A custom event type that allows for multiple "runners" that can easily be invoked all at once.
    /// </summary>
    public interface IModEvent<T1, T2, T3, T4, T5> : IModEventBase
    {
        /// <summary>
        /// Returns a list of all of the current runners on this event.
        /// </summary>
        public List<Action<T1, T2, T3, T4, T5>> GetRunners();

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// </summary>
        /// <param name="codeToAdd">Action to add as a runner.</param>
        public void AddRunner(Action<T1, T2, T3, T4, T5> codeToAdd);

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        /// <param name="codeToAdd">Action to add as a runner.</param>
        public void AddRunner(ActionRef1<T1, T2, T3, T4, T5> codeToAdd);

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        /// <param name="codeToAdd">Action to add as a runner.</param>
        public void AddRunner(ActionRef2<T1, T2, T3, T4, T5> codeToAdd);

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        /// <param name="codeToAdd">Action to add as a runner.</param>
        public void AddRunner(ActionRef3<T1, T2, T3, T4, T5> codeToAdd);

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        /// <param name="codeToAdd">Action to add as a runner.</param>
        public void AddRunner(ActionRef4<T1, T2, T3, T4, T5> codeToAdd);

        /// <summary>
        /// Add a new runner from this event. It will be activated whenever <see cref="Run"/> is called.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        /// <param name="codeToAdd">Action to add as a runner.</param>
        public void AddRunner(ActionRef5<T1, T2, T3, T4, T5> codeToAdd);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(Action<T1, T2, T3, T4, T5> codeToRemove);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(ActionRef1<T1, T2, T3, T4, T5> codeToRemove);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(ActionRef2<T1, T2, T3, T4, T5> codeToRemove);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(ActionRef3<T1, T2, T3, T4, T5> codeToRemove);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(ActionRef4<T1, T2, T3, T4, T5> codeToRemove);

        /// <summary>
        /// Remove a runner from this ModEvent.
        /// </summary>
        /// <param name="codeToRemove">Action to remove</param>
        /// <returns>If removal is successful this will return true, otherwise false.</returns>
        public bool RemoveRunner(ActionRef5<T1, T2, T3, T4, T5> codeToRemove);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// </summary>
        public void Run(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        public void Run(ref T1 value1, T2 value2, T3 value3, T4 value4, T5 value5);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        public void Run(ref T1 value1, ref T2 value2, T3 value3, T4 value4, T5 value5);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        public void Run(ref T1 value1, ref T2 value2, ref T3 value3, T4 value4, T5 value5);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        public void Run(ref T1 value1, ref T2 value2, ref T3 value3, ref T4 value4, T5 value5);

        /// <summary>
        /// Run this event, causing all runners to execute.
        /// <br/>Allows passing argument by reference.
        /// </summary>
        public void Run(ref T1 value1, ref T2 value2, ref T3 value3, ref T4 value4, ref T5 value5);


        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4, T5> operator +(IModEvent<T1, T2, T3, T4, T5> modEvent, Action<T1, T2, T3, T4, T5> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4, T5> operator +(IModEvent<T1, T2, T3, T4, T5> modEvent, ActionRef1<T1, T2, T3, T4, T5> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4, T5> operator +(IModEvent<T1, T2, T3, T4, T5> modEvent, ActionRef2<T1, T2, T3, T4, T5> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4, T5> operator +(IModEvent<T1, T2, T3, T4, T5> modEvent, ActionRef3<T1, T2, T3, T4, T5> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4, T5> operator +(IModEvent<T1, T2, T3, T4, T5> modEvent, ActionRef4<T1, T2, T3, T4, T5> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly add a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to add</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4, T5> operator +(IModEvent<T1, T2, T3, T4, T5> modEvent, ActionRef5<T1, T2, T3, T4, T5> codeToRun)
        {
            modEvent.AddRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4, T5> operator -(IModEvent<T1, T2, T3, T4, T5> modEvent, Action<T1, T2, T3, T4, T5> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4, T5> operator -(IModEvent<T1, T2, T3, T4, T5> modEvent, ActionRef1<T1, T2, T3, T4, T5> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4, T5> operator -(IModEvent<T1, T2, T3, T4, T5> modEvent, ActionRef2<T1, T2, T3, T4, T5> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4, T5> operator -(IModEvent<T1, T2, T3, T4, T5> modEvent, ActionRef3<T1, T2, T3, T4, T5> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4, T5> operator -(IModEvent<T1, T2, T3, T4, T5> modEvent, ActionRef4<T1, T2, T3, T4, T5> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }

        /// <summary>
        /// Implicitly remove a runner from this ModEvent.
        /// </summary>
        /// <param name="modEvent"></param>
        /// <param name="codeToRun">runner to remove</param>
        /// <returns></returns>
        public static IModEvent<T1, T2, T3, T4, T5> operator -(IModEvent<T1, T2, T3, T4, T5> modEvent, ActionRef5<T1, T2, T3, T4, T5> codeToRun)
        {
            modEvent.RemoveRunner(codeToRun);
            return modEvent;
        }
    }
}
