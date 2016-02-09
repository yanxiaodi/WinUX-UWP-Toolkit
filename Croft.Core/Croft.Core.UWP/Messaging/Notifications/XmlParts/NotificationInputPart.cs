namespace WinUX.Messaging.Notifications.XmlParts
{
    using System.Collections.Generic;

    using WinUX.Attributes.Xml;
    using WinUX.Messaging.Notifications.Enums;
    using WinUX.Messaging.Notifications.XmlParts.Interfaces;

    [XmlElement("input")]
    internal sealed class NotificationInputPart : INotificationActionsChildPart
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("type")]
        public NotificationInputType Type { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("placeHolderContent")]
        public string PlaceholderContent { get; set; }

        [XmlAttribute("defaultInput")]
        public string DefaultInput { get; set; }

        public IList<INotificationInputChildPart> Children { get; private set; } = new List<INotificationInputChildPart>();
    }
}