namespace Reloaded.ModHelper
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class ModEventHook : IModEventHook
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool IsRunning => _isFiring;

        /// <summary>
        /// Backing field for <see cref="IsRunning"/>.
        /// </summary>
        protected bool _isFiring = false;

        /// <summary>
        /// Initializes this object and sets up backing field for <see cref="IsRunning"/>.
        /// </summary>
        public ModEventHook()
        {
            Before += () => _isFiring = true;
            After.OnFinishedRunning += () => _isFiring = false;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent Before {get; set;} = new ModEvent();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent After { get; set; } = new ModEvent();
    }



    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class ModEventHook<T1> : IModEventHook<T1>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool IsRunning => _isFiring;

        /// <summary>
        /// Backing field for <see cref="IsRunning"/>.
        /// </summary>
        protected bool _isFiring = false;

        /// <summary>
        /// Initializes this object and sets up backing field for <see cref="IsRunning"/>.
        /// </summary>
        public ModEventHook()
        {
            Before += (a1) => _isFiring = true;
            After.OnFinishedRunning += () => _isFiring = false;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<EventParam<T1>> Before { get; set; } = new ModEvent<EventParam<T1>>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<EventParam<T1>> After { get; set; } = new ModEvent<EventParam<T1>>();
        IModEvent<T1> IModEventHook<T1>.Before { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        IModEvent<T1> IModEventHook<T1>.After { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }

/*

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class ModEventHook<T1, T2> : IModEventHook<T1, T2>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool IsRunning => _isFiring;

        /// <summary>
        /// Backing field for <see cref="IsRunning"/>.
        /// </summary>
        protected bool _isFiring = false;

        /// <summary>
        /// Initializes this object and sets up backing field for <see cref="IsRunning"/>.
        /// </summary>
        public ModEventHook()
        {
            Before += (a1, a2) => _isFiring = true;
            After.OnFinishedRunning += () => _isFiring = false;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<EventParam<T1>, EventParam<T2>> Before { get; set; } = new ModEvent<EventParam<T1>, EventParam<T2>>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<EventParam<T1>, EventParam<T2>> After { get; set; } = new ModEvent<EventParam<T1>, EventParam<T2>>();
    }



    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class ModEventHook<T1, T2, T3> : IModEventHook<T1, T2, T3>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool IsRunning => _isFiring;

        /// <summary>
        /// Backing field for <see cref="IsRunning"/>.
        /// </summary>
        protected bool _isFiring = false;

        /// <summary>
        /// Initializes this object and sets up backing field for <see cref="IsRunning"/>.
        /// </summary>
        public ModEventHook()
        {
            Before += (a1, a2, a3) => _isFiring = true;
            After.OnFinishedRunning += () => _isFiring = false;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>> Before { get; set; } = new ModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>> After { get; set; } = new ModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>>();
    }



    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class ModEventHook<T1, T2, T3, T4> : IModEventHook<T1, T2, T3, T4>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool IsRunning => _isFiring;

        /// <summary>
        /// Backing field for <see cref="IsRunning"/>.
        /// </summary>
        protected bool _isFiring = false;

        /// <summary>
        /// Initializes this object and sets up backing field for <see cref="IsRunning"/>.
        /// </summary>
        public ModEventHook()
        {
            Before += (a1, a2, a3, a4) => _isFiring = true;
            After.OnFinishedRunning += () => _isFiring = false;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>, EventParam<T4>> Before { get; set; } = new ModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>, EventParam<T4>>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>, EventParam<T4>> After { get; set; } = new ModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>, EventParam<T4>>();
    }



    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class ModEventHook<T1, T2, T3, T4, T5> : IModEventHook<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool IsFiring => _isFiring;

        /// <summary>
        /// Backing field for <see cref="IsFiring"/>.
        /// </summary>
        protected bool _isFiring = false;

        /// <summary>
        /// Initializes this object and sets up backing field for <see cref="IsFiring"/>.
        /// </summary>
        public ModEventHook()
        {
            Before += (a1, a2, a3, a4, a5) => _isFiring = true;
            After.OnFinishedRunning += () => _isFiring = false;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>, EventParam<T4>, EventParam<T5>> Before { get; set; } = new ModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>, EventParam<T4>, EventParam<T5>>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>, EventParam<T4>, EventParam<T5>> After { get; set; } = new ModEvent<EventParam<T1>, EventParam<T2>, EventParam<T3>, EventParam<T4>, EventParam<T5>>();
    }*/
}
