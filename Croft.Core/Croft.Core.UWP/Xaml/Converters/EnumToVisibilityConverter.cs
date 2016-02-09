// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumToVisibilityConverter.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the EnumToVisibilityConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Xaml.Converters
{
    using System;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    public class EnumToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts an Enum value to a Visibility value using a parameter Enum value to check.
        /// </summary>
        /// <example>
        /// <TextBlock Text="None" Visibility="{Binding CurrentEnumType, ConverterParameter=None, Converter={StaticResource EnumToVisibilityConverter}}" />
        /// <TextBlock Text="Show" Visibility="{Binding CurrentEnumType, ConverterParameter=Show, Converter={StaticResource EnumToVisibilityConverter}}" />
        /// </example>
        /// <returns>
        /// Returns Visibility.Visible if the Enum value matches the parameter value, else Visibility.Collapsed.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var stringEnumToCheck = parameter as string;
            if (stringEnumToCheck == null)
            {
                return Visibility.Collapsed;
            }

            if (value is string)
            {
                return parameter.Equals(value) ? Visibility.Visible : Visibility.Collapsed;
            }

            if (!Enum.IsDefined(value.GetType(), value))
            {
                return Visibility.Collapsed;
            }

            var enumToCheck = Enum.Parse(value.GetType(), stringEnumToCheck);
            return enumToCheck.Equals(value) ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// ConvertBack is not supported for the EnumToVisibilityConverter.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}