namespace Croft.Core.Messaging.Notifications.Enums
{
    using Croft.Core.Attributes;

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