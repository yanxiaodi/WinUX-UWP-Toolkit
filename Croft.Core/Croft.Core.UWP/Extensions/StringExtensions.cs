// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Extensions
{
    using System.Globalization;

    using Windows.UI;

    /// <summary>
    /// A collection of string extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts an ARGB hex value to a Color.
        /// </summary>
        /// <param name="argbHexValue">
        /// The ARGB hex value represented as a string.
        /// </param>
        /// <returns>
        /// Returns the Color representation of the ARGB hex string value.
        /// </returns>
        public static Color ToColor(this string argbHexValue)
        {
            var val = argbHexValue.ToUpper();

            var color = new Color
            {
                A = byte.Parse(val.Substring(1, 2), NumberStyles.AllowHexSpecifier),
                R = byte.Parse(val.Substring(3, 2), NumberStyles.AllowHexSpecifier),
                G = byte.Parse(val.Substring(5, 2), NumberStyles.AllowHexSpecifier),
                B = byte.Parse(val.Substring(7, 2), NumberStyles.AllowHexSpecifier)
            };

            return color;
        }
    }
}