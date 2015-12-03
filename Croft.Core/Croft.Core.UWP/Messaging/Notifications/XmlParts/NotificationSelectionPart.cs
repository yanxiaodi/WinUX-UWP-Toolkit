namespace Croft.Core.Messaging.Notifications.XmlParts
{
    using Croft.Core.Messaging.Notifications;
    using Croft.Core.Messaging.Notifications.XmlParts.Interfaces;

    [XmlElement("selection")]
    internal sealed class NotificationSelectionPart : INotificationInputChildPart
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("content")]
        public string Content { get; set; }
    }
}