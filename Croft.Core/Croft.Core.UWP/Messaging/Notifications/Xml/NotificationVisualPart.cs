// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationVisualPart.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the NotificationVisualPart type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Messaging.Notifications.Xml
{
    using System;
    using System.Collections.Generic;

    using Croft.Core.Attributes.Xml;

    /// <summary>
    /// The notification visual part.
    /// </summary>
    [XmlElement("visual")]
    public class NotificationVisualPart
    {
        private const bool DefaultAddImageQuery = false;

        [XmlAttribute("addImageQuery", DefaultAddImageQuery)]
        public bool AddImageQuery { get; set; } = DefaultAddImageQuery;

        [XmlAttribute("baseUri")]
        public Uri BaseUri { get; set; }

        [XmlAttribute("lang")]
        public string Language { get; set; }

        [XmlAttribute("version")]
        public int? Version { get; set; }

        public IList<NotificationBindingPart> Bindings { get; private set; } = new List<NotificationBindingPart>();
    }
}
