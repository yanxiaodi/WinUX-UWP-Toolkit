namespace WinUX.Messaging.Notifications.Content
{
    using WinUX.Messaging.Notifications.Enums;
    using WinUX.Messaging.Notifications.XmlParts;

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