namespace Croft.Core.Messaging.Notifications.Inputs
{
    using System;
    using System.Collections.Generic;

    using Croft.Core.Collections;
    using Croft.Core.Messaging.Notifications.Enums;
    using Croft.Core.Messaging.Notifications.XmlParts;

    public sealed class NotificationSelectionBox : INotificationInput
    {
        public NotificationSelectionBox(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            this.Id = id;
        }

        public string Id { get; }

        public string Title { get; set; }

        public string DefaultSelectionBoxItemId { get; set; }

        public IList<NotificationSelectionBoxItem> Items { get; } = new LimitedList<NotificationSelectionBoxItem>(5);

        internal NotificationInputPart ToXmlPart()
        {
            var input = new NotificationInputPart
                            {
                                Type = NotificationInputType.Selection,
                                Id = this.Id,
                                DefaultInput = this.DefaultSelectionBoxItemId,
                                Title = this.Title
                            };

            foreach (var item in this.Items)
            {
                input.Children.Add(item.ToXmlPart());
            }

            return input;
        }
    }
}