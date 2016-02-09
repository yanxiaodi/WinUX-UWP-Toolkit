namespace WinUX.Messaging.Notifications.Content
{
    using Windows.Data.Xml.Dom;

    public interface INotificationContent
    {
        string ToXmlString();

        XmlDocument ToXmlDocument();
    }
}