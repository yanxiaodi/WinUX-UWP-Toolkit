// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanFormatConverter.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Xaml.Converters
{
    using System;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    /// <summary>
    ///     The boolean format converter.
    /// </summary>
    public class BooleanFormatConverter : DependencyObject, IValueConverter
    {
        public static readonly DependencyProperty PositiveValueProperty = DependencyProperty.Register(
            "PositiveValue",
            typeof(string),
            typeof(BooleanFormatConverter),
            new PropertyMetadata("Yes"));

        public static readonly DependencyProperty NegativeValueProperty = DependencyProperty.Register(
            "NegativeValue",
            typeof(string),
            typeof(BooleanFormatConverter),
            new PropertyMetadata("No"));

        /// <summary>
        ///     Gets or sets the negative value.
        /// </summary>
        public string NegativeValue
        {
            get
            {
                return (string)this.GetValue(NegativeValueProperty);
            }
            set
            {
                this.SetValue(NegativeValueProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the positive value.
        /// </summary>
        public string PositiveValue
        {
            get
            {
                return (string)this.GetValue(PositiveValueProperty);
            }
            set
            {
                this.SetValue(PositiveValueProperty, value);
            }
        }

        /// <summary>
        /// Converts a bool value to a string value.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="targetType">
        /// The target Type.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <param name="language">
        /// The language.
        /// </param>
        /// <returns>
        /// Returns PositiveValue if true, else NegativeValue.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var b = value as bool?;
            return b == null ? string.Empty : (b.Value ? this.PositiveValue : this.NegativeValue);
        }

        /// <summary>
        /// Converts a string value to a bool value.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="targetType">
        /// The target Type.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <param name="language">
        /// The language.
        /// </param>
        /// <returns>
        /// Returns true if PositiveValue, else false.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var s = value as string;
            if (s == null)
            {
                return null;
            }

            if (s == this.PositiveValue)
            {
                return true;
            }

            if (s == this.NegativeValue)
            {
                return false;
            }

            return null;
        }
    }
}