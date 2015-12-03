namespace Croft.Core.Messaging.Notifications.Actions
{
    using Croft.Core.Messaging.Notifications.Enums;
    using Croft.Core.Messaging.Notifications.XmlParts;

    public sealed class SnoozeAndDismissAction : INotificationAction
    {
        internal NotificationActionsPart ToXmlPart()
        {
            return new NotificationActionsPart { SystemCommands = NotificationCommand.SnoozeAndDismiss };
        }
    }
}