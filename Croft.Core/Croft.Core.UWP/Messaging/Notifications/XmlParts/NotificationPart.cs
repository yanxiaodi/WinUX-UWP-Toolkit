namespace Croft.Core.Messaging.Notifications.XmlParts
{
    using Croft.Core.Messaging.Notifications.Enums;

    [XmlElement("toast")]
    internal sealed class NotificationPart : XmlPartBase
    {
        internal const NotificationScenario DefaultScenario = NotificationScenario.Default;
        internal const NotificationActivationType DefaultActivationType = NotificationActivationType.Foreground;
        internal const NotificationDuration DefaultDuration = NotificationDuration.Short;

        [XmlAttribute("activationType", DefaultActivationType)]
        public NotificationActivationType ActivationType { get; set; } = DefaultActivationType;

        [XmlAttribute("duration", DefaultDuration)]
        public NotificationDuration Duration { get; set; } = DefaultDuration;

        [XmlAttribute("launch")]
        public string Launch { get; set; }

        [XmlAttribute("scenario", DefaultScenario)]
        public NotificationScenario Scenario { get; set; } = DefaultScenario;

        public NotificationVisualPart VisualPart { get; set; }

        public NotificationAudioPart Audio { get; set; }

        public NotificationActionsPart Actions { get; set; }
    }
}