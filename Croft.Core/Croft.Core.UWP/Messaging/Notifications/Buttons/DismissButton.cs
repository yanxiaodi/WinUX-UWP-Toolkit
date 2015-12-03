namespace Croft.Core.Messaging.Notifications.Buttons
{
    using System;

    using Croft.Core.Messaging.Notifications.Enums;
    using Croft.Core.Messaging.Notifications.XmlParts;

    public sealed class DismissButton : INotificationButton
    {
        public string Content { get; }

        public DismissButton()
        {
        }

        public DismissButton(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            this.Content = content;
        }

        internal NotificationActionPart ToXmlPart()
        {
            return new NotificationActionPart
                       {
                           Content = this.Content ?? string.Empty,
                           Arguments = "dismiss",
                           ActivationType = NotificationActivationType.System
                       };
        }
    }
}