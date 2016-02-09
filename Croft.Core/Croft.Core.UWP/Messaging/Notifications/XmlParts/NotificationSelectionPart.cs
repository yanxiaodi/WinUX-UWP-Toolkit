namespace WinUX.Messaging.Notifications.XmlParts
{
    using WinUX.Attributes.Xml;
    using WinUX.Messaging.Notifications.XmlParts.Interfaces;

    [XmlElement("selection")]
    internal sealed class NotificationSelectionPart : INotificationInputChildPart
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("content")]
        public string Content { get; set; }
    }
}