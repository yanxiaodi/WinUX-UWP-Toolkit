// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObservableCollectionExtensions.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    /// <summary>
    /// A collection of ObservableCollection extensions.
    /// </summary>
    public static class ObservableCollectionExtensions
    {
        /// <summary>
        /// Adds the elements of the given items to add to the end of the ObservableCollection.
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <param name="itemsToAdd">
        /// The items to add to the collection.
        /// </param>
        /// <typeparam name="T">
        /// The type of object within the collections.
        /// </typeparam>
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> itemsToAdd)
        {
            if (itemsToAdd == null)
            {
                return;
            }

            foreach (var item in itemsToAdd)
            {
                collection.Add(item);
            }
        }

        /// <summary>
        /// Sorts the items within the collection by the given key selector.
        /// </summary>
        /// <param name="collection">
        /// The collection to sort.
        /// </param>
        /// <param name="keySelector">
        /// The key selector.
        /// </param>
        /// <typeparam name="T">
        /// The type of item within the collection.
        /// </typeparam>
        /// <typeparam name="TKey">
        /// The type to order by.
        /// </typeparam>
        public static void SortBy<T, TKey>(this ObservableCollection<T> collection, Func<T, TKey> keySelector)
        {
            if (collection == null || collection.Count <= 1)
                return;

            var newIndex = 0;
            foreach (var oldIndex in collection.OrderBy(keySelector).Select(collection.IndexOf))
            {
                if (oldIndex != newIndex)
                    collection.Move(oldIndex, newIndex);

                newIndex++;
            }
        }
    }
}