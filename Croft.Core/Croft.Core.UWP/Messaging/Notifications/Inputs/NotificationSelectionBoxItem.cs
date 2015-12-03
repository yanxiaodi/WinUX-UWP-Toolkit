namespace Croft.Core.Messaging.Notifications.Inputs
{
    using System;

    using Croft.Core.Messaging.Notifications.XmlParts;

    public sealed class NotificationSelectionBoxItem
    {
        public NotificationSelectionBoxItem(string id, string content)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            this.Id = id;
            this.Content = content;
        }

        public string Id { get; }

        public string Content { get; }

        internal NotificationSelectionPart ToXmlPart()
        {
            return new NotificationSelectionPart { Id = this.Id, Content = this.Content };
        }
    }
}