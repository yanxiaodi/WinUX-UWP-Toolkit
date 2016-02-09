// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Extensions
{
    using System;
    using System.Text;

    /// <summary>
    /// A collection of string extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Provides further checking on a string to see if it is a Date or numeric value, they are considered as empty.
        /// </summary>
        /// <param name="text">
        /// The text to check.
        /// </param>
        /// <returns>
        /// Returns a boolean value indicating whether the text is empty.
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
        /// The date string to check.
        /// </param>
        /// <returns>
        /// Returns a boolean value indicating whether the text is a valid DateTime value.
        /// </returns>
        public static bool IsValidDate(this string dateString)
        {
            DateTime dt;
            return DateTime.TryParse(dateString, out dt) && dt != DateTime.MinValue && dt.Year != 1601;
        }

        /// <summary>
        /// Converts a string to an array of bytes.
        /// </summary>
        /// <param name="str">
        /// The string to convert.
        /// </param>
        /// <returns>
        /// Returns the given string as an array of <see cref="byte"/>.
        /// </returns>
        public static byte[] ToByteArray(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
    }
}