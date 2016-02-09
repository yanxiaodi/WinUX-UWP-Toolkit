// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependencyObjectExtensions.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Extensions
{
    using System;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Media;

    using WinUX.Common;

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

        /// <summary>
        /// Finds a child DependencyObject of a certain type from the given DependencyObject.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object to find.
        /// </typeparam>
        /// <param name="d">
        /// The DependencyObject to start looking from.
        /// </param>
        /// <returns>
        /// Returns the requested object, if it exists.
        /// </returns>
        public static T FindChildElementOfType<T>(this DependencyObject d) where T : DependencyObject
        {
            if (d == null)
            {
                return null;
            }

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(d); i++)
            {
                var child = VisualTreeHelper.GetChild(d, i);

                var result = child as T ?? FindChildElementOfType<T>(child);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }
    }
}