namespace WinUX.Messaging.Notifications.Actions
{
    using WinUX.Messaging.Notifications.Enums;
    using WinUX.Messaging.Notifications.XmlParts;

    public sealed class SnoozeAndDismissAction : INotificationAction
    {
        internal NotificationActionsPart ToXmlPart()
        {
            return new NotificationActionsPart { SystemCommands = NotificationCommand.SnoozeAndDismiss };
        }
    }
}