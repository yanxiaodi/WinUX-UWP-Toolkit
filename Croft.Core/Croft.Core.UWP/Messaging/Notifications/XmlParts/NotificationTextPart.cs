namespace WinUX.Messaging.Notifications.XmlParts
{
    using WinUX.Attributes.Xml;
    using WinUX.Messaging.Notifications.XmlParts.Interfaces;

    [XmlElement("text")]
    internal sealed class NotificationTextPart : INotificationBindingPart
    {
        [XmlContent]
        public string Text { get; set; }
        
        [XmlAttribute("lang")]
        public string Language { get; set; }
    }
}