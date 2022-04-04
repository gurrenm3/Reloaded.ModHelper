namespace Reloaded.ModHelper
{
    /// <summary>
    /// Represents a ModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary>
    public interface IModEventHook
    {
        /// <summary>
        /// Use this before the hook executes.
        /// </summary>
        public IModEvent Prefix { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public IModEvent Postfix { get; set; }
    }


    /// <summary>
    /// Represents a ModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary>
    public interface IModEventHook<T1>
    {
        /// <summary>
        /// Use this before the hook executes.
        /// </summary>
        public IModEvent<EventParam<T1>> Prefix { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public IModEvent<EventParam<T1>> Postfix { get; set; }
    }



    /// <summary>
    /// Represents a ModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary>
    public interface IModEventHook<T1, T2>
    {
        /// <summary>
        /// Use this before the hook executes.
        /// </summary>
        public IModEvent<EventParam<T1>, EventParam<T2>> Prefix { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public IModEvent<EventParam<T1>, EventParam<T2>> Postfix { get; set; }
    }




    /// <summary>
    /// Represents a ModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary>
    public interface IModEventHook<T1, T2, T3>
    {
        /// <summary>
        /// Use this before the hook executes.
        /// </summary>
        public IModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>> Prefix { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public IModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>> Postfix { get; set; }
    }



    /// <summary>
    /// Represents a ModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary>
    public interface IModEventHook<T1, T2, T3, T4>
    {
        /// <summary>
        /// Use this before the hook executes.
        /// </summary>
        public IModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>, EventParam<T4>> Prefix { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public IModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>, EventParam<T4>> Postfix { get; set; }
    }



    /// <summary>
    /// Represents a ModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary>
    public interface IModEventHook<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Use this before the hook executes.
        /// </summary>
        public IModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>, EventParam<T4>, EventParam<T5>> Prefix { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public IModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>, EventParam<T4>, EventParam<T5>> Postfix { get; set; }
    }
}
