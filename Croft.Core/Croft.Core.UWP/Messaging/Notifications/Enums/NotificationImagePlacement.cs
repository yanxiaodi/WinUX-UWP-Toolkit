namespace Croft.Core.Messaging.Notifications.Enums
{
    using Croft.Core.Attributes;

    internal enum NotificationImagePlacement
    {
        Inline,

        [EnumString("appLogoOverride")]
        AppLogoOverride
    }
}