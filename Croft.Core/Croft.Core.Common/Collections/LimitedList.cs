// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LimitedList.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the LimitedList type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// A collection which limits the number of items it can hold.
    /// </summary>
    /// <typeparam name="T">
    /// The type of object within the collection.
    /// </typeparam>
    public class LimitedList<T> : IList<T>
    {
        private readonly List<T> _list;

        /// <summary>
        /// Gets the limit.
        /// </summary>
        public int Limit { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LimitedList{T}"/> class.
        /// </summary>
        /// <param name="limit">
        /// The limit.
        /// </param>
        public LimitedList(int limit)
        {
            this._list = new List<T>(limit);

            this.Limit = limit;
        }

        /// <summary>
        /// Gets or sets a value at the given index within the collection.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T this[int index]
        {
            get
            {
                return this._list[index];
            }

            set
            {
                this._list[index] = value;
            }
        }

        /// <summary>
        /// Gets the number of items within the collection.
        /// </summary>
        public int Count => this._list.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (this._list.Count >= this.Limit) throw new Exception("This list is limited to " + this.Limit + " items. You cannot add more items.");

            this._list.Add(item);
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(T item)
        {
            return this._list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this._list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return this._list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            this._list.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return this._list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            this._list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}