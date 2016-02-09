// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableExtensions.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the EnumerableExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A collection of IEnumerable extensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Checks whether a collection of items is null or empty.
        /// </summary>
        /// <param name="collection">
        /// The collection to check.
        /// </param>
        /// <typeparam name="T">
        /// The type of object within the collection.
        /// </typeparam>
        /// <returns>
        /// Returns a boolean value indicating whether the collection is null or empty.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || !collection.Any();
        }

        /// <summary>
        /// Converts a collection of objects to a comma separated string representing the objects.
        /// </summary>
        /// <param name="collection">
        /// The collection to join.
        /// </param>
        /// <typeparam name="T">
        /// The type of object within the collection
        /// </typeparam>
        /// <returns>
        /// Returns a string representation of the items within the collection separated by a comma.
        /// </returns>
        public static string ToCommaSeparatedString<T>(this IEnumerable<T> collection)
        {
            return string.Join(",", collection);
        }

        /// <summary>
        /// Compares a collection of objects of a given type with another collection of objects with the same given type to see if they are the same.
        /// </summary>
        /// <param name="collection">
        /// The initial collection of items.
        /// </param>
        /// <param name="collectionX">
        /// The collection to compare with.
        /// </param>
        /// <typeparam name="T">
        /// The type of objects in the collections.
        /// </typeparam>
        /// <returns>
        /// Returns a boolean value, true if collection contains all the items in collectionX, else false.
        /// </returns>
        public static bool Matches<T>(this IEnumerable<T> collection, IEnumerable<T> collectionX)
        {
            if (collection == null && collectionX == null)
            {
                return true;
            }

            if (collection == null)
            {
                return false;
            }

            if (collectionX == null)
            {
                return false;
            }

            var list1 = collection as IList<T> ?? collection.ToList();
            var list2 = collectionX as IList<T> ?? collectionX.ToList();

            return list1.ToList().Count == list2.ToList().Count
                   && list1.OrderBy(t => t).SequenceEqual(list2.OrderBy(t => t));
        }
    }
}