namespace Reloaded.ModHelper
{
    /// <summary>
    /// Represents a SharedModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary>
    public interface ISharedModEventHook
    {
        /// <summary>
        /// Use this before the hook executes.
        /// </summary>
        public ISharedModEvent Prefix{ get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public ISharedModEvent Postfix { get; set; }
    }


    /// <summary>
    /// Represents a ModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary>
    public interface ISharedModEventHook<T1>
    {
        /// <summary>
        /// Use this before the hook executes.
        /// </summary>
        public ISharedModEvent<T1> Prefix { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public ISharedModEvent<T1> Postfix { get; set; }
    }



    /// <summary>
    /// Represents a ModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary>
    public interface ISharedModEventHook<T1, T2>
    {
        /// <summary>
        /// Use this before the hook executes.
        /// </summary>
        public ISharedModEvent<T1, T2> Prefix { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public ISharedModEvent<T1, T2> Postfix { get; set; }
    }




    /// <summary>
    /// Represents a ModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary>
    public interface ISharedModEventHook<T1, T2, T3>
    {
        /// <summary>
        /// Use this before the hook executes.
        /// </summary>
        public ISharedModEvent<T1, T2, T3> Prefix { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public ISharedModEvent<T1, T2, T3> Postfix { get; set; }
    }



    /// <summary>
    /// Represents a ModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary>
    public interface ISharedModEventHook<T1, T2, T3, T4>
    {
        /// <summary>
        /// Use this before the hook executes.
        /// </summary>
        public ISharedModEvent<T1, T2, T3, T4> Prefix { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public ISharedModEvent<T1, T2, T3, T4> Postfix { get; set; }
    }



    /// <summary>
    /// Represents a ModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary>
    public interface ISharedModEventHook<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// Use this before the hook executes.
        /// </summary>
        public ISharedModEvent<T1, T2, T3, T4, T5> Prefix { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public ISharedModEvent<T1, T2, T3, T4, T5> Postfix { get; set; }
    }
}
