using System;
using System.Collections;
using System.Collections.Generic;

namespace Reloaded.ModHelper
{
    public class VirtualArray<T> : IVirtualCollection<T>
    {
        public int ElementOffset { get; set; }
        public int Count { get; protected set; }

        public T this[int index]
        {
            get => ElementAt(index);
            set => test = value;
        }

        T test;

        public readonly long address;
        protected readonly SortedDictionary<int, T> values;

        public VirtualArray(long address, int arraySize, int elementSize = 0)
        {
            this.address = address;
            Count = arraySize;
            values = new SortedDictionary<int, T>();

            if (elementSize != 0)
                ElementOffset = elementSize;
            else
            {
                //ElementOffset = ;
                
            }
        }

        public T ElementAt(int index)
        {
            if (index > Count)
                throw new IndexOutOfRangeException();

            if (values.TryGetValue(index, out var value))
                return value;

            // assume it's a primitive for now cuz it's easier.

            value = PrimitiveUtils.GetValue<T>(address + (index * ElementOffset));
            values.Add(index, value);
            return value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return ElementAt(i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
