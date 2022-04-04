﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class SharedModEventHook : IModEventHook
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent Prefix { get; set; } = new SharedModEvent();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent Postfix { get; set; } = new SharedModEvent();
    }



    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class SharedModEventHook<T1> : IModEventHook<T1>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<T1> Prefix { get; set; } = new SharedModEvent<T1>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<T1> Postfix { get; set; } = new SharedModEvent<T1>();
    }



    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class SharedModEventHook<T1, T2> : IModEventHook<T1, T2>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<T1, T2> Prefix { get; set; } = new SharedModEvent<T1, T2>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<T1, T2> Postfix { get; set; } = new SharedModEvent<T1, T2>();
    }



    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class SharedModEventHook<T1, T2, T3> : IModEventHook<T1, T2, T3>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<T1, T2, T3> Prefix { get; set; } = new SharedModEvent<T1, T2, T3>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<T1, T2, T3> Postfix { get; set; } = new SharedModEvent<T1, T2, T3>();
    }



    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class SharedModEventHook<T1, T2, T3, T4> : IModEventHook<T1, T2, T3, T4>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<T1, T2, T3, T4> Prefix { get; set; } = new SharedModEvent<T1, T2, T3, T4>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<T1, T2, T3, T4> Postfix { get; set; } = new SharedModEvent<T1, T2, T3, T4>();
    }



    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class SharedModEventHook<T1, T2, T3, T4, T5> : IModEventHook<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<T1, T2, T3, T4, T5> Prefix { get; set; } = new SharedModEvent<T1, T2, T3, T4, T5>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<T1, T2, T3, T4, T5> Postfix { get; set; } = new SharedModEvent<T1, T2, T3, T4, T5>();
    }
}
