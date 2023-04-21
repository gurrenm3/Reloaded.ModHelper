using System;
using System.Collections.Generic;

namespace Reloaded.ModHelper
{
    public interface IVirtualCollection<T> : IEnumerable<T>
    {
        T this[int index] { get; set; }

        public int ElementOffset { get; set; }

        int Count { get; }

        T ElementAt(int index);
    }
}
