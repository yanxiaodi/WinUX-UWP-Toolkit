// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InverseBooleanToVisibilityConverter.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the InverseBooleanToVisibilityConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Xaml.Converters
{
    using System;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    public class InverseBooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a bool value to a Visibility value.
        /// </summary>
        /// <returns>
        /// Returns Visibility.Collapsed if true, else Visibility.Visible.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool? b = value as bool?;
            return b == null ? Visibility.Collapsed : (b.Value ? Visibility.Collapsed : Visibility.Visible);
        }

        /// <summary>
        /// Converts a Visibility value to a bool value.
        /// </summary>
        /// <returns>
        /// Returns true if Visiblility.Collapsed, else false.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var v = value as Visibility?;
            return v == null ? (object)null : v.Value == Visibility.Collapsed;
        }
    }
}