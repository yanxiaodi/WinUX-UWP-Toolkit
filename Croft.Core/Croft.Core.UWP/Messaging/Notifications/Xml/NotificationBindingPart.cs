// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationBindingPart.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the NotificationBindingPart type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Messaging.Notifications.Xml
{
    using System;
    using System.Collections.Generic;

    using Windows.UI.Notifications;

    using Croft.Core.Attributes.Xml;

    /// <summary>
    /// The notification binding part.
    /// </summary>
    [XmlElement("binding")]
    public class NotificationBindingPart
    {
        private const bool DefaultAddImageQuery = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationBindingPart"/> class.
        /// </summary>
        /// <param name="template">
        /// The template.
        /// </param>
        public NotificationBindingPart(ToastTemplateType template)
        {
            this.Template = template;
        }

        /// <summary>
        /// Gets the template.
        /// </summary>
        [XmlAttribute("template")]
        public ToastTemplateType Template { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether to append a query string to the image Uri in the notification. 
        /// </summary>
        /// <remarks>
        /// Use this if your image Uri supports query strings for requesting different scale factors. 
        /// </remarks>
        [XmlAttribute("addImageQuery", DefaultAddImageQuery)]
        public bool AddImageQuery { get; set; } = DefaultAddImageQuery;

        /// <summary>
        /// Gets or sets the base uri.
        /// </summary>
        [XmlAttribute("baseUri")]
        public Uri BaseUri { get; set; }

        [XmlAttribute("lang")]
        public string Language { get; set; }

        public IList<INotificationBindingChildPart> Children { get; private set; } =
            new List<INotificationBindingChildPart>();
    }
}