using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reloaded.ModHelper
{
    public interface ITime
    {
        /// <summary>
        /// How much time has passed, in seconds, between the last GameLoop iteration and the current one.
        /// </summary>
        public double DeltaTime { get; }

        /// <summary>
        /// The total number of milliseconds that have passed since initialization.
        /// </summary>
        public double TotalMilliseconds { get; }

        /// <summary>
        /// The total number of seconds that have passed since initialization.
        /// </summary>
        public double TotalSeconds { get; }
    }
}
