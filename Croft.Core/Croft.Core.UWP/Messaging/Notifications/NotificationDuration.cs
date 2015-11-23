// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationDuration.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the NotificationDuration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Messaging.Notifications
{
    using Croft.Core.Attributes;

    /// <summary>
    /// The notification duration.
    /// </summary>
    public enum NotificationDuration
    {
        /// <summary>
        /// The default duration, shows for a short time.
        /// </summary>
        Short,

        /// <summary>
        /// The long duration, shows for a longer time.
        /// </summary>
        [EnumString("long")]
        Long
    }
}