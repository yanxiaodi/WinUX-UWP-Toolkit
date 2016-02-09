// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BrushToLightAccentColorConverter.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the BrushToLightAccentColorConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Xaml.Converters.Colors
{
    using System;

    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media;

    using WinUX.Extensions;

    /// <summary>
    /// The brush to light accent color converter.
    /// </summary>
    public class BrushToLightAccentColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var brush = (SolidColorBrush)value;
            var accentColor = brush.Color.ToAccentColor();

            return accentColor.ToLightAccentColor();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
