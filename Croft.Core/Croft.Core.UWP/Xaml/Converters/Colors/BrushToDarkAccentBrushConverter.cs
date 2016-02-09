// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BrushToDarkAccentBrushConverter.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the BrushToDarkAccentBrushConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Xaml.Converters.Colors
{
    using System;

    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media;

    using WinUX.Extensions;

    /// <summary>
    /// The brush to dark accent brush converter.
    /// </summary>
    public class BrushToDarkAccentBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var brush = (SolidColorBrush)value;

            var accentColor = brush.Color.ToAccentColor();

            var newColor = accentColor.ToDarkAccentColor();

            var result = new SolidColorBrush(newColor);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
