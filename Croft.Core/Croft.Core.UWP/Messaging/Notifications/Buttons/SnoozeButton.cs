namespace Croft.Core.Messaging.Notifications.Buttons
{
    using System;

    using Croft.Core.Messaging.Notifications.Enums;
    using Croft.Core.Messaging.Notifications.XmlParts;

    public sealed class SnoozeButton : INotificationButton
    {
        public string Content { get; }

        public string SelectionBoxId { get; set; }

        public SnoozeButton()
        {
        }

        public SnoozeButton(string content)
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
                           Arguments = "snooze",
                           ActivationType = NotificationActivationType.System,
                           InputId = this.SelectionBoxId
                       };
        }
    }
}