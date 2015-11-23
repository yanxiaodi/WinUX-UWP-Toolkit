// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlElementAttribute.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the XmlElementAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Attributes.Xml
{
    using System;

    /// <summary>
    /// The xml element attribute.
    /// </summary>
    public class XmlElementAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlElementAttribute"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the name parameter is empty or null.
        /// </exception>
        public XmlElementAttribute(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.Name = name;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }
    }
}