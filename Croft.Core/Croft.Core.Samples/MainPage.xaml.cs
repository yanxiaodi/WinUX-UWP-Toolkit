// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPage.xaml.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Samples
{
    using System;

    using Windows.UI.Notifications;
    using Windows.UI.Xaml;

    using Croft.Core.Messaging.Notifications.Actions;
    using Croft.Core.Messaging.Notifications.Content;
    using Croft.Core.Messaging.Notifications.Enums;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnSnoozeAndDismissClicked(object sender, RoutedEventArgs e)
        {
            var notification = new NotificationContent
            {
                Visual = new NotificationVisual
                {
                    Title = new NotificationText
                    {
                        Text = "Hello, World!"
                    },
                    BodyLineOne = new NotificationText
                    {
                        Text = string.Format("Alarm - {0}", DateTime.Now.ToString("hh:mm tt"))
                    }
                },
                Launch = "HelloWorldAlarm",
                Scenario = NotificationScenario.Reminder,
                Actions = new SnoozeAndDismissAction()
            };

            var xml = notification.ToXmlDocument();
            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(xml));
        }
    }
}