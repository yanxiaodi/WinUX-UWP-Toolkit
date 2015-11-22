// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependencyObjectExtensions.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Extensions
{
    using System;

    using Windows.UI.Xaml;

    using Croft.Core.Common;

    /// <summary>
    /// A collection of DependencyObject extensions.
    /// </summary>
    public static class DependencyObjectExtensions
    {
        /// <summary>
        /// Listens to changes of a property on a DependencyObject.
        /// </summary>
        /// <param name="obj">
        /// The DependencyObject.
        /// </param>
        /// <param name="propertyName">
        /// The property name to listen to.
        /// </param>
        /// <param name="eventHandler">
        /// The event handler which will fire when the property changes.
        /// </param>
        /// <returns>
        /// The <see cref="IDisposable"/>.
        /// </returns>
        public static IDisposable ListenToProperty(this DependencyObject obj, string propertyName, DependencyPropertyChangedEventHandler eventHandler)
        {
            return new DependencyPropertyListener(obj, propertyName, eventHandler);
        }
    }
}