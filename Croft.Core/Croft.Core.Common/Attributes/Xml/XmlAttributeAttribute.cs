// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlAttributeAttribute.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the XmlAttributeAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Attributes.Xml
{
    using System;

    /// <summary>
    /// The XmlAttribute attribute.
    /// </summary>
    public class XmlAttributeAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlAttributeAttribute"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="defaultValue">
        /// The value.
        /// </param>
        public XmlAttributeAttribute(string name, object defaultValue = null)
        {
            this.Name = name;
            this.DefaultValue = defaultValue;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public object DefaultValue { get; }
    }
}
