namespace Croft.Core.Messaging.Notifications.Enums
{
    using Croft.Core.Attributes;

    public enum NotificationDuration
    {
        Short,

        [EnumString("long")]
        Long
    }
}