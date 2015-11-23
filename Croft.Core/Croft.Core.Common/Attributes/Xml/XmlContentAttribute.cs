// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlContentAttribute.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the XmlContentAttribute type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Attributes.Xml
{
    using System;

    /// <summary>
    /// The XML content attribute.
    /// </summary>
    /// <remarks>
    /// Adding this attribute to a property will write it out as a string in an element's body.
    /// </remarks>
    public class XmlContentAttribute : Attribute
    {
    }
}