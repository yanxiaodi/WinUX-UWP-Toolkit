namespace Croft.Core.Messaging.Notifications.XmlParts
{
    using System;

    using Croft.Core.Messaging.Notifications;

    [XmlElement("audio")]
    internal sealed class NotificationAudioPart
    {
        internal const bool DefaultLoop = false;
        internal const bool DefaultSilent = false;

        [XmlAttribute("src")]
        public Uri SourceUri { get; set; }

        [XmlAttribute("loop", DefaultLoop)]
        public bool Loop { get; set; } = DefaultLoop;

        [XmlAttribute("silent", DefaultSilent)]
        public bool Silent { get; set; } = DefaultSilent;
    }
}