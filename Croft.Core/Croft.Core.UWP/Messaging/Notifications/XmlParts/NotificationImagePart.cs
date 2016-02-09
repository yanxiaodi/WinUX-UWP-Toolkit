namespace WinUX.Messaging.Notifications.XmlParts
{
    using WinUX.Attributes.Xml;
    using WinUX.Messaging.Notifications.Enums;
    using WinUX.Messaging.Notifications.XmlParts.Interfaces;

    [XmlElement("image")]
    internal sealed class NotificationImagePart : INotificationBindingPart
    {
        internal const NotificationImagePlacement DefaultPlacement = NotificationImagePlacement.Inline;
        internal const bool DefaultAddImageQuery = false;
        internal const NotificationImageCrop DefaultCrop = NotificationImageCrop.None;

        [XmlAttribute("src")]
        public string Source { get; set; }

        [XmlAttribute("alt")]
        public string Description { get; set; }

        [XmlAttribute("addImageQuery", DefaultAddImageQuery)]
        public bool AddImageQuery { get; set; } = DefaultAddImageQuery;

        [XmlAttribute("placement", DefaultPlacement)]
        public NotificationImagePlacement Placement { get; set; } = DefaultPlacement;

        [XmlAttribute("hint-crop", DefaultCrop)]
        public NotificationImageCrop Crop { get; set; } = DefaultCrop;
    }
}