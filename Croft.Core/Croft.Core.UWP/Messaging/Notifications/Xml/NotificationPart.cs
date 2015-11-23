// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationPart.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the NotificationPart type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Messaging.Notifications.Xml
{
    using Croft.Core.Attributes.Xml;

    /// <summary>
    /// The notification part.
    /// </summary>
    [XmlElement("toast")]
    public class NotificationPart : BasePart
    {
        private const NotificationScenario DefaultScenario = NotificationScenario.Default;
        private const NotificationActivationType DefaultActivationType = NotificationActivationType.Foreground;
        private const NotificationDuration DefaultDuration = NotificationDuration.Short;

        [XmlAttribute("activationType", DefaultActivationType)]
        public NotificationActivationType ActivationType { get; set; } = DefaultActivationType;

        [XmlAttribute("duration", DefaultDuration)]
        public NotificationDuration Duration { get; set; } = DefaultDuration;
        
        [XmlAttribute("launch")]
        public string Launch { get; set; }

        [XmlAttribute("scenario", DefaultScenario)]
        public NotificationScenario Scenario { get; set; } = DefaultScenario;

        public NotificationVisualPart Visual { get; set; }

        public NotificationAudioPart Audio { get; set; }

        public NotificationActionsPart Actions { get; set; }
    }
}
