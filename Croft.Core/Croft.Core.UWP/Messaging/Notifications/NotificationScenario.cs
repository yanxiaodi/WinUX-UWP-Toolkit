// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationScenario.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the NotificationScenario type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Messaging.Notifications
{
    using Croft.Core.Attributes;

    /// <summary>
    /// The notification scenario.
    /// </summary>
    public enum NotificationScenario
    {
        /// <summary>
        /// The default notification behavior, shows for a short time and dismisses.
        /// </summary>
        Default,

        /// <summary>
        /// The alarm notification behavior, shows an alarm notification with the default alarm sound which stays on-screen until dismissed by the user.
        /// </summary>
        [EnumString("alarm")]
        Alarm,

        /// <summary>
        /// The reminder notification behavior, shows a notification which stays on-screen until dismissed by the user.
        /// </summary>
        [EnumString("reminder")]
        Reminder,

        /// <summary>
        /// The incoming call notification behavior, shows an incoming call notification with the default call sound which stays on-screen until actioned by the user. On Windows Phone, will show a full screen notification.
        /// </summary>
        [EnumString("incomingCall")]
        IncomingCall
    }
}