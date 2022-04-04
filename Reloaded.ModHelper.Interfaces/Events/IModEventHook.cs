using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Represents a ModEvent that works best with Hooks.
    /// <br/>Can be used to fire a mod event before and after a hook runs.
    /// </summary
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
        public IModEvent<EventParams<T1>> Prefix { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public IModEvent<T1> Postfix { get; set; }
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
        public IModEvent<EventParams<T1, T2>> Prefix { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public IModEvent<T1, T2> Postfix { get; set; }
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
        public IModEvent<EventParams<T1, T2, T3>> Prefix { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public IModEvent<T1, T2, T3> Postfix { get; set; }
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
        public IModEvent<EventParams<T1, T2, T3, T4>> Prefix { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public IModEvent<T1, T2, T3, T4> Postfix { get; set; }
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
        public IModEvent<EventParams<T1, T2, T3, T4, T5>> Prefix { get; set; }

        /// <summary>
        /// Use this after the hook executes.
        /// </summary>
        public IModEvent<T1, T2, T3, T4, T5> Postfix { get; set; }
    }
}
