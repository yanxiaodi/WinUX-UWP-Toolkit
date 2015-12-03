namespace Croft.Core.Messaging.Notifications.XmlParts
{
    using System.Collections.Generic;

    using Croft.Core.Messaging.Notifications;
    using Croft.Core.Messaging.Notifications.Enums;
    using Croft.Core.Messaging.Notifications.XmlParts.Interfaces;

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