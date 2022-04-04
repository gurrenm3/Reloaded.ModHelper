using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class SharedModEventHook : ISharedModEventHook
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ISharedModEvent Prefix { get; set; } = new SharedModEvent();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ISharedModEvent Postfix { get; set; } = new SharedModEvent();
    }



    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class SharedModEventHook<T1> : ISharedModEventHook<T1>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ISharedModEvent<T1> Prefix { get; set; } = new SharedModEvent<T1>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ISharedModEvent<T1> Postfix { get; set; } = new SharedModEvent<T1>();
    }



    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class SharedModEventHook<T1, T2> : ISharedModEventHook<T1, T2>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ISharedModEvent<T1, T2> Prefix { get; set; } = new SharedModEvent<T1, T2>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ISharedModEvent<T1, T2> Postfix { get; set; } = new SharedModEvent<T1, T2>();
    }



    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class SharedModEventHook<T1, T2, T3> : ISharedModEventHook<T1, T2, T3>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ISharedModEvent<T1, T2, T3> Prefix { get; set; } = new SharedModEvent<T1, T2, T3>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ISharedModEvent<T1, T2, T3> Postfix { get; set; } = new SharedModEvent<T1, T2, T3>();
    }



    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class SharedModEventHook<T1, T2, T3, T4> : ISharedModEventHook<T1, T2, T3, T4>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ISharedModEvent<T1, T2, T3, T4> Prefix { get; set; } = new SharedModEvent<T1, T2, T3, T4>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ISharedModEvent<T1, T2, T3, T4> Postfix { get; set; } = new SharedModEvent<T1, T2, T3, T4>();
    }



    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class SharedModEventHook<T1, T2, T3, T4, T5> : ISharedModEventHook<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ISharedModEvent<T1, T2, T3, T4, T5> Prefix { get; set; } = new SharedModEvent<T1, T2, T3, T4, T5>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ISharedModEvent<T1, T2, T3, T4, T5> Postfix { get; set; } = new SharedModEvent<T1, T2, T3, T4, T5>();
    }
}
