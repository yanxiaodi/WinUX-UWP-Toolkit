namespace Croft.Core.Messaging.Notifications.Enums
{
    using Croft.Core.Attributes;

    public enum NotificationActivationType
    {
        Foreground,

        [EnumString("background")]
        Background,

        [EnumString("protocol")]
        Protocol,

        [EnumString("system")]
        System
    }
}