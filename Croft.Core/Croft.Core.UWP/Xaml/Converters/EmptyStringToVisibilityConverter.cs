// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmptyStringToVisibilityConverter.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the EmptyStringToVisibilityConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Xaml.Converters
{
    using System;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    public class EmptyStringToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a string value to a Visibility value.
        /// </summary>
        /// <returns>
        /// Returns Visibility.Visible if the string is not null or whitespace, else Visibility.Collapsed.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return Visibility.Collapsed;
            }

            var dt = value as DateTime?;
            if (dt != null)
            {
                return dt.Value == DateTime.MinValue ? Visibility.Collapsed : Visibility.Visible;
            }

            var s = value.ToString();
            return IsStringEmpty(s) ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <summary>
        /// ConvertBack is not supported for the EmptyStringToVisibilityConverter.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        private static bool IsStringEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value) || value == "0";
        }
    }
}