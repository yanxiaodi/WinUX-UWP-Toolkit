namespace Croft.Core.Messaging.Notifications.Content
{
    using Croft.Core.Messaging.Notifications.Enums;
    using Croft.Core.Messaging.Notifications.XmlParts;

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