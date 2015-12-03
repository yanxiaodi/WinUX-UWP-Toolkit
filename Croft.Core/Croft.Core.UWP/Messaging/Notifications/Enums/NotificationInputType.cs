namespace Croft.Core.Messaging.Notifications.Enums
{
    using Croft.Core.Attributes;

    internal enum NotificationInputType
    {
        [EnumString("text")]
        Text,

        [EnumString("selection")]
        Selection
    }
}