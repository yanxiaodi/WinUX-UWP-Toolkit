// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BasePart.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the BasePart type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Messaging.Notifications.Xml
{
    using System.IO;
    using System.Text;
    using System.Xml;

    using Croft.Core.Xml;

    /// <summary>
    /// The base part.
    /// </summary>
    public abstract class BasePart
    {
        /// <summary>
        /// Gets the XML content as a string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetXmlAsString()
        {
            using (var ms = new MemoryStream())
            {
                using (
                    var writer = XmlWriter.Create(
                        ms,
                        new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = false, NewLineOnAttributes = false })
                    )
                {
                    XmlWriterHelper.Write(writer, this);
                }

                ms.Position = 0;

                using (var reader = new StreamReader(ms))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Gets the XML document.
        /// </summary>
        /// <returns>
        /// The <see cref="XmlDocument"/>.
        /// </returns>
        public XmlDocument GetXml()
        {
            var xml = new XmlDocument();
            xml.LoadXml(this.GetXmlAsString());
            return xml;
        }
    }
}