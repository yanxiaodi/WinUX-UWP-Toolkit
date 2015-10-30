// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.UWP.Extensions
{
    using System;

    /// <summary>
    /// The string extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Provides further checking on a string to see if it is a Date or numeric value, they are considered as empty.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsEmpty(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return true;

            if (text == "01/01/0001 00:00:00")
                return true;

            if (text == "01/01/0001")
                return true;

            return text == "0";
        }

        /// <summary>
        /// Checks whether the date string is valid.
        /// </summary>
        /// <param name="dateString">
        /// The date string.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsValidDate(this string dateString)
        {
            DateTime dt;
            return DateTime.TryParse(dateString, out dt) && dt != DateTime.MinValue && dt.Year != 1601;
        }
    }
}