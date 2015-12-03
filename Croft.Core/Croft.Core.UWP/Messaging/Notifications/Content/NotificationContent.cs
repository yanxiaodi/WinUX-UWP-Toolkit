namespace Croft.Core.Messaging.Notifications.Content
{
    using System;

    using Windows.Data.Xml.Dom;

    using Croft.Core.Messaging.Notifications.Actions;
    using Croft.Core.Messaging.Notifications.Enums;
    using Croft.Core.Messaging.Notifications.XmlParts;

    public sealed class NotificationContent : INotificationContent
    {
        public NotificationVisual Visual { get; set; }

        public NotificationAudio Audio { get; set; }

        public INotificationAction Actions { get; set; }

        public NotificationScenario Scenario { get; set; }

        public NotificationDuration Duration { get; set; }

        public string Launch { get; set; }

        public NotificationActivationType ActivationType { get; set; }

        public string ToXmlString()
        {
            return this.ToXmlPart().ToXmlString();
        }

        public XmlDocument ToXmlDocument()
        {
            var doc = new XmlDocument();
            doc.LoadXml(this.ToXmlString());
            return doc;
        }

        internal NotificationPart ToXmlPart()
        {
            var toast = new NotificationPart
                            {
                                ActivationType = this.ActivationType,
                                Duration = this.Duration,
                                Launch = this.Launch,
                                Scenario = this.Scenario
                            };

            if (this.Visual != null)
            {
                toast.VisualPart = this.Visual.ToXmlPart();
            }

            if (this.Audio != null)
            {
                toast.Audio = this.Audio.ToXmlPart();
            }

            if (this.Actions != null)
            {
                toast.Actions = ConvertToActionsXmlPart(this.Actions);
            }

            return toast;
        }

        private static NotificationActionsPart ConvertToActionsXmlPart(INotificationAction action)
        {
            var customAction = action as CustomAction;
            var snoozeAndDismissAction = action as SnoozeAndDismissAction;

            if (customAction != null)
            {
                return customAction.ToXmlPart();
            }

            if (snoozeAndDismissAction != null)
            {
                return snoozeAndDismissAction.ToXmlPart();
            }

            throw new InvalidOperationException(
                string.Format("The '{0}' action type is not supported.", action.GetType()));
        }
    }
}