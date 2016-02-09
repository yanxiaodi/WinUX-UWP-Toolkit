namespace WinUX.Messaging.Notifications.Content
{
    using WinUX.Messaging.Notifications.XmlParts;

    public sealed class NotificationText
    {
        public string Text { get; set; }

        public string Language { get; set; }

        internal NotificationTextPart ToXmlPart()
        {
            return new NotificationTextPart { Text = this.Text, Language = this.Language };
        }
    }
}