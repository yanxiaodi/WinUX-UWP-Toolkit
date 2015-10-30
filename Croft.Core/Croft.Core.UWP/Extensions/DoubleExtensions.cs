// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DoubleExtensions.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.UWP.Extensions
{
    using System;

    /// <summary>
    /// The double extensions.
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
        /// The <see cref="string"/>.
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

            return string.Format("{0}{1}", Math.Round(fileSize, 2), sizeType);
        }
    }
}
