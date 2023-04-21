using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Reloaded.ModHelper
{
    public class VirtualList<T> : IEnumerable<T>//: IVirtualCollection<T>
    {
        public T this[int index] { get => ElementAt(index); set => throw new NotImplementedException(); }

        public int ElementOffset { get; set; }
        public Func<int> Count { get; set; } //{ get => PrimitiveUtils.GetValue<int>(address + 0x8); }

        public readonly long address;

        protected readonly SortedDictionary<int, T> values;

        public VirtualList(long address)
        {
            this.address = address;
            values = new SortedDictionary<int, T>();
        }

        public VirtualList(long address, int count)
        {
            this.address = address;
            values = new SortedDictionary<int, T>();
            //Count = count;
        }

        public void Add(T itemToAdd)
        {
            values.Add(values.Count, itemToAdd);
        }

        public List<T> GetItems()
        {
            var items = new List<T>();
            foreach (var item in values)
            {
                items.Add(item.Value);
            }
            return items;
        }

        public T ElementAt(int index)
        {
            if (index > Count()) 
                throw new IndexOutOfRangeException();

            if (values.TryGetValue(index, out var value))
                return value;

            // has a constructor that takes an address
            bool hasCtorWithAddress = typeof(T).GetConstructors().Any(c =>
            {
                var args = c.GetParameters();
                return args.Length == 1 && args[0].ParameterType == typeof(long);
            });

            if (!hasCtorWithAddress)
            {
                value = (T)Activator.CreateInstance(typeof(T));
            }
            else
            {
                var elementAddress = address + (index * ElementOffset);
                value = (T)Activator.CreateInstance(typeof(T), elementAddress);
            }

            values.Add(index, value);
            return value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count(); i++)
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
