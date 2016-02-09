namespace WinUX.Messaging.Notifications.Content
{
    using WinUX.Messaging.Notifications.Enums;
    using WinUX.Messaging.Notifications.XmlParts;

    public sealed class NotificationImage
    {
        public NotificationImageSource Source { get; set; }

        internal NotificationImagePart ToXmlPart()
        {
            var notificationImagePart = new NotificationImagePart { Placement = NotificationImagePlacement.Inline };

            this.Source?.PopulateXmlPartFromSource(notificationImagePart);

            return notificationImagePart;
        }
    }
}