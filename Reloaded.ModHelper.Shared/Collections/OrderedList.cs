using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Reloaded.ModHelper
{
    /// <summary>
    /// Represents a list that is automatically ordered whenever an item is added.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OrderedList<T> : IList<T>
    {
        // see above for the comparer implementation 
        private readonly IComparer<T> comparer;
        private readonly List<T> innerList = new List<T>();

        /// <summary>
        /// Creates an ordered list with a default comparer.
        /// </summary>
        public OrderedList()
            : this(Comparer<T>.Default)
        {
        }

        /// <summary>
        /// Creates an ordered list with a provided comparer.
        /// </summary>
        /// <param name="comparer"></param>
        public OrderedList(IComparer<T> comparer)
        {
            this.comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        }

        public T this[int index]
        {
            get => this.innerList[index];
            set => throw new NotSupportedException("Cannot set an indexed item in a sorted list.");
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public int Count => this.innerList.Count;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// <inheritdoc/> Automatically re-orders the list after it's been added.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            int index = innerList.BinarySearch(item, comparer);
            index = (index >= 0) ? index : ~index;
            innerList.Insert(index, item);
        }

        /// <summary>
        /// Adds the elements in the specified collection to this list while ensuring they
        /// are in the proper order.
        /// </summary>
        /// <param name="collection"></param>
        public void AddRange(ICollection<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                Add(collection.ElementAt(i));
            }
        }

        /// <summary>
        /// Adds the elements in the specified collection to this list while ensuring they
        /// are in the proper order.
        /// </summary>
        /// <param name="collection"></param>
        public void AddRange(T[] collection)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                Add(collection[i]);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Clear() => this.innerList.Clear();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool Contains(T item) => this.innerList.Contains(item);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void CopyTo(T[] array, int arrayIndex) => this.innerList.CopyTo(array);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IEnumerator<T> GetEnumerator() => this.innerList.GetEnumerator();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public int IndexOf(T item) => this.innerList.IndexOf(item);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Insert(int index, T item) => throw new NotSupportedException("Cannot insert an indexed item in a sorted list.");

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool Remove(T item) => this.innerList.Remove(item);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void RemoveAt(int index) => this.innerList.RemoveAt(index);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
