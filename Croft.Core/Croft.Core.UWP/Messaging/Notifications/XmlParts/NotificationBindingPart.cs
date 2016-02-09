namespace WinUX.Messaging.Notifications.XmlParts
{
    using System;
    using System.Collections.Generic;

    using WinUX.Attributes.Xml;
    using WinUX.Messaging.Notifications.Enums;
    using WinUX.Messaging.Notifications.XmlParts.Interfaces;

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