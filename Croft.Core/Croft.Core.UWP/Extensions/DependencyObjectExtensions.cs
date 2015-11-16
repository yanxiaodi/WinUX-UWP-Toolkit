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

    public static class DependencyObjectExtensions
    {
        public static IDisposable ListenToProperty(this DependencyObject obj, string propertyName, DependencyPropertyChangedEventHandler eventHandler)
        {
            return new DependencyPropertyListener(obj, propertyName, eventHandler);
        }
    }
}