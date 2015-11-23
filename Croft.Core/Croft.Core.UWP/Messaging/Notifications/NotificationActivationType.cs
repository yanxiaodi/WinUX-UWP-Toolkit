// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationActivationType.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the NotificationActivationType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Messaging.Notifications
{
    using Croft.Core.Attributes;

    /// <summary>
    /// The notification activation type.
    /// </summary>
    public enum NotificationActivationType
    {
        /// <summary>
        /// The default notification activation type. App is launched into foreground.
        /// </summary>
        Foreground,

        /// <summary>
        /// The background notification activation type. Response is sent to the background task of your app.
        /// </summary>
        [EnumString("background")]
        Background,

        /// <summary>
        /// The protocol notification activation type. Launch a different app using protocol activiation.
        /// </summary>
        [EnumString("protocol")]
        Protocol
    }
}