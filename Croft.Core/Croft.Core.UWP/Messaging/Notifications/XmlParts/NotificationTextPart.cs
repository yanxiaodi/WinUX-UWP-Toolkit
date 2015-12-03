namespace Croft.Core.Messaging.Notifications.XmlParts
{
    using Croft.Core.Messaging.Notifications;
    using Croft.Core.Messaging.Notifications.XmlParts.Interfaces;

    [XmlElement("text")]
    internal sealed class NotificationTextPart : INotificationBindingPart
    {
        [XmlContent]
        public string Text { get; set; }
        
        [XmlAttribute("lang")]
        public string Language { get; set; }
    }
}