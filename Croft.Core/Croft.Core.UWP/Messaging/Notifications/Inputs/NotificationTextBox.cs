namespace WinUX.Messaging.Notifications.Inputs
{
    using System;

    using WinUX.Messaging.Notifications.Enums;
    using WinUX.Messaging.Notifications.XmlParts;

    public sealed class NotificationTextBox : INotificationInput
    {
        public NotificationTextBox(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            this.Id = id;
        }

        public string Id { get; }

        public string Title { get; set; }

        public string PlaceholderContent { get; set; }

        public string DefaultInput { get; set; }

        internal NotificationInputPart ToXmlPart()
        {
            return new NotificationInputPart
                       {
                           Id = this.Id,
                           Type = NotificationInputType.Text,
                           DefaultInput = this.DefaultInput,
                           PlaceholderContent = this.PlaceholderContent,
                           Title = this.Title
                       };
        }
    }
}