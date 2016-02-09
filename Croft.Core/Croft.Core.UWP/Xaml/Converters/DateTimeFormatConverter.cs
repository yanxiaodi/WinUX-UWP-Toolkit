// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeFormatConverter.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the DateTimeFormatConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Xaml.Converters
{
    using System;

    using Windows.UI.Xaml.Data;

    public class DateTimeFormatConverter : IValueConverter
    {
        /// <summary>
        /// Converts a DateTime value to a formatted string using a parameter format value.
        /// </summary>
        /// <example>
        /// <TextBlock Text="{Binding DateOfBirth, Converter={StaticResource DateTimeConverter}, ConverterParameter='dd/MM/yyyy'}" />
        /// </example>
        /// <returns>
        /// Returns a formatted string representation of the DateTime value.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var dt = value as DateTime?;
            if (dt == null)
            {
                return string.Empty;
            }

            if (dt.Value == DateTime.MinValue)
            {
                return string.Empty;
            }

            var format = parameter as string;
            return format == null ? dt.Value.ToString() : dt.Value.ToString(format);
        }

        /// <summary>
        /// ConvertBack is not supported for the DateTimeFormatConverter.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}