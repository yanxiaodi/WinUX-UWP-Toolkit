namespace WinUX.Messaging.Notifications.Content
{
    using System;
    using System.Collections.Generic;

    using WinUX.Collections;
    using WinUX.Messaging.Notifications.Enums;
    using WinUX.Messaging.Notifications.XmlParts;

    public sealed class NotificationVisual
    {
        public int? Version { get; set; }

        public string Language { get; set; }

        public Uri BaseUri { get; set; }

        public bool AddImageQuery { get; set; } = NotificationVisualPart.DefaultAddImageQuery;

        public NotificationText Title { get; set; }

        public NotificationText BodyLineOne { get; set; }

        public NotificationText BodyLineTwo { get; set; }

        public IList<NotificationImage> InlineImages { get; } = new LimitedList<NotificationImage>(6);

        public NotificationAppLogo AppLogoOverride { get; set; }

        internal NotificationVisualPart ToXmlPart()
        {
            var notificationVisualPart = new NotificationVisualPart
                                             {
                                                 Version = this.Version,
                                                 Language = this.Language,
                                                 BaseUri = this.BaseUri,
                                                 AddImageQuery = this.AddImageQuery
                                             };

            var notificationBindingPart = new NotificationBindingPart(NotificationTemplateType.ToastGeneric);

            if (this.Title == null)
            {
                if (this.BodyLineOne != null || this.BodyLineTwo != null)
                {
                    notificationBindingPart.Children.Add(new NotificationTextPart());
                }
            }
            else
            {
                notificationBindingPart.Children.Add(this.Title.ToXmlPart());
            }

            if (this.BodyLineOne == null)
            {
                if (this.BodyLineTwo != null)
                {
                    notificationBindingPart.Children.Add(new NotificationTextPart());
                }
            }
            else
            {
                notificationBindingPart.Children.Add(this.BodyLineOne.ToXmlPart());
            }

            if (this.BodyLineTwo != null)
            {
                notificationBindingPart.Children.Add(this.BodyLineTwo.ToXmlPart());
            }

            foreach (var img in this.InlineImages)
            {
                notificationBindingPart.Children.Add(img.ToXmlPart());
            }

            if (this.AppLogoOverride != null)
            {
                notificationBindingPart.Children.Add(this.AppLogoOverride.ToXmlPart());
            }

            notificationVisualPart.Bindings.Add(notificationBindingPart);

            return notificationVisualPart;
        }
    }
}