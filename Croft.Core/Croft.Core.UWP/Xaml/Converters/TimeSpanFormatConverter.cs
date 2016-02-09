// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeSpanFormatConverter.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Xaml.Converters
{
    using System;

    using Windows.UI.Xaml.Data;

    /// <summary>
    /// The time span format converter.
    /// </summary>
    public class TimeSpanFormatConverter : IValueConverter
    {
        /// <summary>
        /// Converts a TimeSpan value to a formatted string using a parameter format value.
        /// </summary>
        /// <example>
        /// <TextBlock Text="{Binding TimeOfBirth, Converter={StaticResource TimeSpanFormatConverter}, ConverterParameter='hh:mm'}" />
        /// </example>
        /// <returns>
        /// Returns a formatted string representation of the TimeSpan value.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var ts = value as TimeSpan?;
            if (ts == null)
            {
                return string.Empty;
            }

            if (ts.Value == TimeSpan.MinValue)
            {
                return string.Empty;
            }

            var format = parameter as string;
            return format == null ? ts.Value.ToString() : ts.Value.ToString(format);
        }

        /// <summary>
        /// ConvertBack is not supported for the TimeSpanFormatConverter.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
