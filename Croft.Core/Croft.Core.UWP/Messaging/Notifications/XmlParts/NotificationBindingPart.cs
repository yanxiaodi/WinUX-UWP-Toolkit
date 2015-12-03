namespace Croft.Core.Messaging.Notifications.XmlParts
{
    using System;
    using System.Collections.Generic;

    using Croft.Core.Messaging.Notifications;
    using Croft.Core.Messaging.Notifications.Enums;
    using Croft.Core.Messaging.Notifications.XmlParts.Interfaces;

    [XmlElement("binding")]
    internal sealed class NotificationBindingPart
    {
        internal const bool DefaultAddImageQuery = false;

        public NotificationBindingPart(NotificationTemplateType template)
        {
            this.Template = template;
        }

        [XmlAttribute("template")]
        public NotificationTemplateType Template { get; private set; }

        [XmlAttribute("addImageQuery", DefaultAddImageQuery)]
        public bool AddImageQuery { get; set; } = DefaultAddImageQuery;

        [XmlAttribute("baseUri")]
        public Uri BaseUri { get; set; }

        [XmlAttribute("lang")]
        public string Language { get; set; }

        public IList<INotificationBindingPart> Children { get; private set; } = new List<INotificationBindingPart>();
    }
}