namespace WinUX.Messaging.Notifications.Enums
{
    using WinUX.Attributes;

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