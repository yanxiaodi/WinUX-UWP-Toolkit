// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumStringAttribute.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the EnumStringAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Attributes
{
    using System;

    /// <summary>
    /// The Enum string attribute.
    /// </summary>
    public class EnumStringAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumStringAttribute"/> class.
        /// </summary>
        /// <param name="enumString">
        /// The enum string.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the enumString parameter is empty or null.
        /// </exception>
        public EnumStringAttribute(string enumString)
        {
            if (string.IsNullOrWhiteSpace(enumString))
            {
                throw new ArgumentNullException(nameof(enumString));
            }

            this.String = enumString;
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        public string String { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return this.String;
        }
    }
}
