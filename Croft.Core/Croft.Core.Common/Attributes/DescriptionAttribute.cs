// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DescriptionAttribute.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the DescriptionAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Attributes
{
    using System;

    /// <summary>
    /// The description attribute.
    /// </summary>
    public class DescriptionAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DescriptionAttribute"/> class.
        /// </summary>
        /// <param name="description">
        /// The description.
        /// </param>
        public DescriptionAttribute(string description)
        {
            this.Description = description;
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
    }
}