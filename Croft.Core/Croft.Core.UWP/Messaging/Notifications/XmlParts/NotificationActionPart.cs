namespace Croft.Core.Messaging.Notifications.XmlParts
{
    using Croft.Core.Messaging.Notifications;
    using Croft.Core.Messaging.Notifications.Enums;
    using Croft.Core.Messaging.Notifications.XmlParts.Interfaces;

    [XmlElement("action")]
    internal sealed class NotificationActionPart : INotificationActionsChildPart
    {
        internal const NotificationActivationType DefaultActivationType = NotificationActivationType.Foreground;

        [XmlAttribute("content")]
        public string Content { get; set; }

        [XmlAttribute("arguments")]
        public string Arguments { get; set; }

        [XmlAttribute("activationType", DefaultActivationType)]
        public NotificationActivationType ActivationType { get; set; } = DefaultActivationType;

        [XmlAttribute("imageUri")]
        public string ImageUri { get; set; }

        [XmlAttribute("hint-inputId")]
        public string InputId { get; set; }
    }
}