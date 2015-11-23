// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationActionsPart.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the NotificationActionsPart type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Messaging.Notifications.Xml
{
    using System.Collections.Generic;

    using Croft.Core.Attributes.Xml;

    /// <summary>
    /// The notification actions part.
    /// </summary>
    [XmlElement("actions")]
    public class NotificationActionsPart
    {
        private const NotificationSystemCommand DefaultSystemCommand = NotificationSystemCommand.None;

        [XmlAttribute("hint-systemCommands", DefaultSystemCommand)]
        public NotificationSystemCommand SystemCommands { get; set; } = DefaultSystemCommand;

        public IList<INotificationActionsChildPart> Children { get; private set; } = new List<INotificationActionsChildPart>();
    }
}
