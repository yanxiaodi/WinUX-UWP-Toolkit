// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlWriterHelper.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the XmlWriterHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Xml
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    using Croft.Core.Attributes.Xml;
    using Croft.Core.Extensions;

    /// <summary>
    /// An XmlWriter helper.
    /// </summary>
    public static class XmlWriterHelper
    {
        public static void Write(XmlWriter writer, object element)
        {
            var xmlElementAttr = element.GetCustomAttributesOfType<XmlElementAttribute>().FirstOrDefault();

            if (xmlElementAttr == null)
            {
                // Don't want to write out anything that doesn't use the XmlElementAttribute
                return;
            }

            writer.WriteStartElement(xmlElementAttr.Name); // Start writing an element.

            var xmlElementProps = element.GetAllProperties();

            var elements = new List<object>();
            object content = null;

            // Write out the attributes.
            foreach (var prop in xmlElementProps)
            {
                var attributes = prop.GetCustomAttributesOfType<Attribute>();

                var propXmlAttr = attributes.OfType<XmlAttributeAttribute>().FirstOrDefault();

                var propValue = prop.GetValue(element, null);

                if (propXmlAttr != null)
                {
                    // If we have an XmlAttribute to add.
                    var defaultPropValue = propXmlAttr.DefaultValue;

                    // If we have a different value to the default.
                    if (!object.Equals(propValue, defaultPropValue) && propValue != null)
                    {
                        writer.WriteAttributeString(propXmlAttr.Name, propValue.GetPropertyValueAsString());
                    }
                }
                else if (attributes.OfType<XmlContentAttribute>().Any())
                {
                    // We want to write the content out into the element
                    content = propValue;
                }
                else
                {
                    // If we get here, we have elements or collection of elements left.
                    if (propValue != null)
                    {
                        elements.Add(propValue);
                    }
                }
            }

            // Run through all of the child elements we found earlier.
            foreach (var e in elements)
            {
                if (e is IEnumerable)
                {
                    // If it's a collection, we need to write them all out.
                    foreach (var child in e as IEnumerable)
                    {
                        Write(writer, child);
                    }

                    continue;
                }

                // Else just write the element out.
                Write(writer, e);
            }

            string str = content?.ToString();
            if (!string.IsNullOrWhiteSpace(str))
            {
                writer.WriteString(str);
            }

            writer.WriteEndElement(); // Complete writing the element.
        }
    }
}