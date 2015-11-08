// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableExtensions.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the EnumerableExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The enumerable extensions.
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
        /// The <see cref="bool"/>.
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
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToCommaSeparatedString<T>(this IEnumerable<T> collection)
        {
            return string.Join(",", collection);
        }
    }
}