namespace WinUX.Messaging.Notifications.Buttons
{
    using System;

    using WinUX.Messaging.Notifications.Enums;
    using WinUX.Messaging.Notifications.XmlParts;

    public sealed class NotificationButton : INotificationButton
    {
        public NotificationButton(string content, string arguments)
        {
            if (content == null) throw new ArgumentNullException(nameof(content));

            if (arguments == null) throw new ArgumentNullException(nameof(arguments));

            this.Content = content;
            this.Arguments = arguments;
        }

        public string Content { get; }

        public string Arguments { get; }

        public NotificationActivationType ActivationType { get; set; } = NotificationActivationType.Foreground;

        public string ImageUri { get; set; }

        public string TextBoxId { get; set; }

        internal NotificationActionPart ToXmlPart()
        {
            return new NotificationActionPart
                       {
                           Content = this.Content,
                           Arguments = this.Arguments,
                           ActivationType = this.ActivationType,
                           ImageUri = this.ImageUri,
                           InputId = this.TextBoxId
                       };
        }
    }
}