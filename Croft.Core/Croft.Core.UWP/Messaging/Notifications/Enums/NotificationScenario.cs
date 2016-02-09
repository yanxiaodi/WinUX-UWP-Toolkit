namespace WinUX.Messaging.Notifications.Enums
{
    using WinUX.Attributes;

    public enum NotificationScenario
    {
        Default,

        [EnumString("alarm")]
        Alarm,

        [EnumString("reminder")]
        Reminder,

        [EnumString("incomingCall")]
        IncomingCall
    }
}