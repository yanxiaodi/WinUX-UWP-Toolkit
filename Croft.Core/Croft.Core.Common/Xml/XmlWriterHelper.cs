namespace WinUX.Xml
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Xml;

    using WinUX.Attributes.Xml;
    using WinUX.Extensions;

    public static class XmlWriterHelper
    {
        public static void Write(XmlWriter writer, object xmlElement)
        {
            var elementAttribute = xmlElement.GetType().GetTypeInfo().GetCustomAttributes().OfType<XmlElementAttribute>().FirstOrDefault();
            if (elementAttribute == null) return;

            writer.WriteStartElement(elementAttribute.Name);

            var elementProperties = xmlElement.GetType().GetTypeInfo().DeclaredProperties;

            var childElements = new List<object>();
            object content = null;

            foreach (var propertyInfo in elementProperties)
            {
                var propertyValue = propertyInfo.GetValue(xmlElement);

                var attributes = propertyInfo.GetCustomAttributes().ToList();

                var propertyXmlAttribute = attributes.OfType<XmlAttributeAttribute>().FirstOrDefault();
                if (propertyXmlAttribute != null)
                {
                    var defaultValue = propertyXmlAttribute.DefaultValue;

                    if (!object.Equals(propertyValue, defaultValue) && propertyValue != null)
                    {
                        writer.WriteAttributeString(propertyXmlAttribute.Name, ToEnumString(propertyValue));
                    }
                }
                else if (attributes.OfType<XmlContentAttribute>().Any())
                {
                    content = propertyValue;
                }
                else
                {
                    if (propertyValue != null)
                    {
                        childElements.Add(propertyValue);
                    }
                }
            }

            foreach (var childElement in childElements)
            {
                if (childElement is IEnumerable)
                {
                    foreach (var child in childElement as IEnumerable)
                    {
                        Write(writer, child);
                    }

                    continue;
                }

                Write(writer, childElement);
            }

            var contentString = content?.ToString();
            if (!string.IsNullOrWhiteSpace(contentString))
            {
                writer.WriteString(contentString);
            }

            writer.WriteEndElement();
        }

        private static string ToEnumString(object propertyValue)
        {
            var type = propertyValue.GetType();

            if (type.GetTypeInfo().IsEnum)
            {
                var enumStringAttr = (propertyValue as Enum).GetEnumStringAttribute();

                if (enumStringAttr != null)
                {
                    return enumStringAttr.String;
                }
            }

            return propertyValue.ToString();
        }
    }
}