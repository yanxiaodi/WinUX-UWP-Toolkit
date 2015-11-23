// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationAudioPart.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the NotificationAudioPart type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Messaging.Notifications.Xml
{
    using System;

    using Croft.Core.Attributes.Xml;

    /// <summary>
    /// The notification audio part.
    /// </summary>
    [XmlElement("audio")]
    public class NotificationAudioPart
    {
        private const bool DefaultLoop = false;

        private const bool DefaultSilent = false;

        /// <summary>
        /// Gets or sets the Uri source of the audio file.
        /// </summary>
        [XmlAttribute("src")]
        public Uri Src { get; set; }

        [XmlAttribute("loop", DefaultLoop)]
        public bool Loop { get; set; } = DefaultLoop;

        [XmlAttribute("silent", DefaultSilent)]
        public bool Silent { get; set; } = DefaultSilent;
    }
}