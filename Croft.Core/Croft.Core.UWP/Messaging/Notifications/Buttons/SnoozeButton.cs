namespace WinUX.Messaging.Notifications.Buttons
{
    using System;

    using WinUX.Messaging.Notifications.Enums;
    using WinUX.Messaging.Notifications.XmlParts;

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