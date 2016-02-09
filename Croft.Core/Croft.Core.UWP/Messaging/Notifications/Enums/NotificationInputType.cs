namespace WinUX.Messaging.Notifications.Enums
{
    using WinUX.Attributes;

    internal enum NotificationInputType
    {
        [EnumString("text")]
        Text,

        [EnumString("selection")]
        Selection
    }
}