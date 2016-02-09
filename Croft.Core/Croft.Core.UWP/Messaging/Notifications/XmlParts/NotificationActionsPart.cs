namespace WinUX.Messaging.Notifications.XmlParts
{
    using System.Collections.Generic;

    using WinUX.Attributes.Xml;
    using WinUX.Messaging.Notifications.Enums;
    using WinUX.Messaging.Notifications.XmlParts.Interfaces;

    [XmlElement("actions")]
    internal sealed class NotificationActionsPart
    {
        internal const NotificationCommand DefaultSystemCommand = NotificationCommand.None;

        [XmlAttribute("hint-systemCommands", DefaultSystemCommand)]
        public NotificationCommand SystemCommands { get; set; } = NotificationCommand.None;

        public IList<INotificationActionsChildPart> Children { get; private set; } = new List<INotificationActionsChildPart>();
    }
}