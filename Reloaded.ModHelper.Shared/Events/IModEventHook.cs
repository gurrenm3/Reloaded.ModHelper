namespace Reloaded.ModHelper
{
    /// <summary>
    /// Represents a ModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary>
    public interface IModEventHook
    {
        /// <summary>
        /// Reflects whether or not the hook is currently firing.
        /// <br/>This will be set to true once <see cref="Before"/> starts firing and will be set to
        /// false once <see cref="After"/> has finished.
        /// </summary>
        public bool IsRunning { get; }

        /// <summary>
        /// Use this before the hook executes.
        /// </summary>
        public IModEvent Before { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public IModEvent After { get; set; }
    }


    /// <summary>
    /// Represents a ModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary>
    public interface IModEventHook<T1>
    {
        /// <summary>
        /// Reflects whether or not the hook is currently firing.
        /// <br/>This will be set to true once <see cref="Before"/> starts firing and will be set to
        /// false once <see cref="After"/> has finished.
        /// </summary>
        public bool IsRunning { get; }

        /// <summary>
        /// Use this before the hook executes.
        /// </summary>
        public IModEvent<T1> Before { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public IModEvent<T1> After { get; set; }
    }



    /// <summary>
    /// Represents a ModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary>
    public interface IModEventHook<T1, T2>
    {
        /// <summary>
        /// Reflects whether or not the hook is currently firing.
        /// <br/>This will be set to true once <see cref="Before"/> starts firing and will be set to
        /// false once <see cref="After"/> has finished.
        /// </summary>
        public bool IsRunning { get; }

        /// <summary>
        /// Use this before the hook executes.
        /// </summary>
        public IModEvent<T1, T2> Before { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public IModEvent<T1, T2> After { get; set; }
    }




    /// <summary>
    /// Represents a ModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary>
    public interface IModEventHook<T1, T2, T3>
    {
        /// <summary>
        /// Reflects whether or not the hook is currently firing.
        /// <br/>This will be set to true once <see cref="Before"/> starts firing and will be set to
        /// false once <see cref="After"/> has finished.
        /// </summary>
        public bool IsRunning { get; }

        /// <summary>
        /// Use this before the hook executes.
        /// </summary>
        public IModEvent<T1, T2, T3> Before { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public IModEvent<T1, T2, T3> After { get; set; }
    }



    /// <summary>
    /// Represents a ModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary>
    public interface IModEventHook<T1, T2, T3, T4>
    {
        /// <summary>
        /// Reflects whether or not the hook is currently firing.
        /// <br/>This will be set to true once <see cref="Before"/> starts firing and will be set to
        /// false once <see cref="After"/> has finished.
        /// </summary>
        public bool IsRunning { get; }

        /// <summary>
        /// Use this before the hook executes.
        /// </summary>
        public IModEvent<T1, T2, T3, T4> Before { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public IModEvent<T1, T2, T3, T4> After { get; set; }
    }



    /// <summary>
    /// Represents a ModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary>
    public interface IModEventHook<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Reflects whether or not the hook is currently firing.
        /// <br/>This will be set to true once <see cref="Before"/> starts firing and will be set to
        /// false once <see cref="After"/> has finished.
        /// </summary>
        public bool IsFiring { get; }

        /// <summary>
        /// Use this before the hook executes.
        /// </summary>
        public IModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>, EventParam<T4>, EventParam<T5>> Before { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public IModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>, EventParam<T4>, EventParam<T5>> After { get; set; }
    }
}
