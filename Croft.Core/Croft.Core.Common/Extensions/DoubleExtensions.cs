// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DoubleExtensions.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Extensions
{
    using System;

    /// <summary>
    /// The collection of double extensions.
    /// </summary>
    public static class DoubleExtensions
    {
        private const double KiloByte = 1024;

        private const double MegaByte = KiloByte * 1024;

        private const double GigaByte = MegaByte * 1024;

        /// <summary>
        /// Converts a double byte value to a file size represented as a string.
        /// </summary>
        /// <param name="fileSize">
        /// File size represented in bytes.
        /// </param>
        /// <returns>
        /// Returns a string representation of the bytes as a file size.
        /// </returns>
        public static string ToFileSize(this double fileSize)
        {
            string sizeType;
            if (fileSize > GigaByte)
            {
                fileSize /= GigaByte;
                sizeType = "GB";
            }
            else if (fileSize > MegaByte)
            {
                fileSize /= MegaByte;
                sizeType = "MB";
            }
            else if (fileSize > KiloByte)
            {
                fileSize /= KiloByte;
                sizeType = "KB";
            }
            else
            {
                sizeType = "B";
            }

            return $"{Math.Round(fileSize, 2)}{sizeType}";
        }
    }
}