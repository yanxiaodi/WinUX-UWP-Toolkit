namespace Croft.Core.Messaging.Notifications.Actions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Croft.Core.Collections;
    using Croft.Core.Messaging.Notifications.Buttons;
    using Croft.Core.Messaging.Notifications.Inputs;
    using Croft.Core.Messaging.Notifications.XmlParts;

    public sealed class CustomAction : INotificationAction
    {
        public IList<INotificationInput> Inputs { get; } = new LimitedList<INotificationInput>(5);

        public IList<INotificationButton> Buttons { get; } = new LimitedList<INotificationButton>(5);

        internal NotificationActionsPart ToXmlPart()
        {
            var notificationActionsPart = new NotificationActionsPart();

            foreach (var inputPart in this.Inputs.Select(ConvertInputToInputXmlPart))
            {
                notificationActionsPart.Children.Add(inputPart);
            }

            foreach (var actionPart in this.Buttons.Select(ConvertButtonToActionXmlPart))
            {
                notificationActionsPart.Children.Add(actionPart);
            }

            return notificationActionsPart;
        }

        private static NotificationActionPart ConvertButtonToActionXmlPart(INotificationButton button)
        {
            var notificationButton = button as NotificationButton;
            var dismissButton = button as DismissButton;
            var snoozeButton = button as SnoozeButton;

            if (notificationButton != null)
            {
                return notificationButton.ToXmlPart();
            }

            if (dismissButton != null)
            {
                return dismissButton.ToXmlPart();
            }

            if (snoozeButton != null)
            {
                return snoozeButton.ToXmlPart();
            }

            throw new InvalidOperationException(
                string.Format("The '{0}' button type is not supported.", button.GetType()));
        }

        private static NotificationInputPart ConvertInputToInputXmlPart(INotificationInput input)
        {
            var textBox = input as NotificationTextBox;
            var selectionBox = input as NotificationSelectionBox;

            if (textBox != null)
            {
                return textBox.ToXmlPart();
            }

            if (selectionBox != null)
            {
                return selectionBox.ToXmlPart();
            }

            throw new InvalidOperationException(
                string.Format("The '{0}' input type is not supported.", input.GetType()));
        }
    }
}