namespace Croft.Core.Messaging.Notifications.XmlParts
{
    using System;
    using System.Collections.Generic;

    using Croft.Core.Messaging.Notifications;

    [XmlElement("visual")]
    internal sealed class NotificationVisualPart
    {
        internal const bool DefaultAddImageQuery = false;

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