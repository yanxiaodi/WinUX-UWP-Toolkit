namespace Croft.Core.Messaging.Notifications.Content
{
    using Croft.Core.Messaging.Notifications.Enums;
    using Croft.Core.Messaging.Notifications.XmlParts;

    public sealed class NotificationAppLogo
    {
        public NotificationImageSource Source { get; set; }

        public NotificationImageCrop Crop { get; set; } = NotificationImagePart.DefaultCrop;

        internal NotificationImagePart ToXmlPart()
        {
            var notificationImagePart = new NotificationImagePart
                                            {
                                                Placement =
                                                    NotificationImagePlacement.AppLogoOverride,
                                                Crop = this.Crop
                                            };

            this.Source?.PopulateXmlPartFromSource(notificationImagePart);

            return notificationImagePart;
        }
    }
}