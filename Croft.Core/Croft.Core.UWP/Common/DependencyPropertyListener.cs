// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependencyPropertyListener.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Common
{
    using System;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    public class DependencyPropertyListener : DependencyObject, IDisposable
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value",
            typeof(object),
            typeof(DependencyPropertyListener),
            new PropertyMetadata(null, OnValueChanged));

        private DependencyPropertyChangedEventHandler _eventHandler;

        public DependencyPropertyListener(
            DependencyObject obj,
            string propertyName,
            DependencyPropertyChangedEventHandler eventHandler)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));
            if (eventHandler == null) throw new ArgumentNullException(nameof(eventHandler));

            this._eventHandler = eventHandler;

            var binding = new Binding
            {
                Source = obj,
                Path = new PropertyPath(propertyName),
                Mode = BindingMode.OneWay
            };

            BindingOperations.SetBinding(this, ValueProperty, binding);
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as DependencyPropertyListener;
            control?.OnValueChanged(e);
        }

        private void OnValueChanged(DependencyPropertyChangedEventArgs e)
        {
            this._eventHandler?.Invoke(this, e);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._eventHandler = null;
                BindingOperations.SetBinding(this, ValueProperty, new Binding());
            }
        }
    }
}