namespace Croft.Core.Messaging.Notifications.XmlParts
{
    using System.Collections.Generic;

    using Croft.Core.Messaging.Notifications;
    using Croft.Core.Messaging.Notifications.Enums;
    using Croft.Core.Messaging.Notifications.XmlParts.Interfaces;

    [XmlElement("actions")]
    internal sealed class NotificationActionsPart
    {
        internal const NotificationCommand DefaultSystemCommand = NotificationCommand.None;

        [XmlAttribute("hint-systemCommands", DefaultSystemCommand)]
        public NotificationCommand SystemCommands { get; set; } = NotificationCommand.None;

        public IList<INotificationActionsChildPart> Children { get; private set; } = new List<INotificationActionsChildPart>();
    }
}