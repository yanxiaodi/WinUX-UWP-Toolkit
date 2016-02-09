namespace WinUX.Messaging.Notifications.Content
{
    using System;

    using WinUX.Messaging.Notifications.XmlParts;

    public sealed class NotificationImageSource
    {
        public NotificationImageSource(string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            this.Source = source;
        }

        public string Source { get; }

        public string Description { get; set; }

        public bool AddImageQuery { get; set; } = NotificationImagePart.DefaultAddImageQuery;

        internal NotificationImagePart ToXmlPart()
        {
            var notificationImagePart = new NotificationImagePart();

            this.PopulateXmlPartFromSource(notificationImagePart);

            return notificationImagePart;
        }

        internal void PopulateXmlPartFromSource(NotificationImagePart image)
        {
            image.Source = this.Source;
            image.Description = this.Description;
            image.AddImageQuery = this.AddImageQuery;
        }

        public override string ToString()
        {
            return this.Source;
        }
    }
}