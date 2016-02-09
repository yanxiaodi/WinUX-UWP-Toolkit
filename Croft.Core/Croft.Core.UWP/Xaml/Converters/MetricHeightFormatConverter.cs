// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetricHeightFormatConverter.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Xaml.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    using WinUX.Enums;

    /// <summary>
    /// The metric height format converter.
    /// </summary>
    public class MetricHeightFormatConverter : DependencyObject, IValueConverter
    {
        public static readonly DependencyProperty TargetUnitOfMeasureProperty =
            DependencyProperty.Register(
                "TargetUnitOfMeasure",
                typeof(UnitOfMeasure),
                typeof(MetricHeightFormatConverter),
                new PropertyMetadata(UnitOfMeasure.Imperial));

        /// <summary>
        /// Gets or sets the target unit of measure.
        /// </summary>
        public UnitOfMeasure TargetUnitOfMeasure
        {
            get
            {
                return (UnitOfMeasure)this.GetValue(TargetUnitOfMeasureProperty);
            }
            set
            {
                this.SetValue(TargetUnitOfMeasureProperty, value);
            }
        }


        /// <summary>
        /// Converts a double value to a formatted string representing the value as an imperial or metric height.
        /// </summary>
        /// <returns>
        /// Returns a string in the format {x}m {x}cm for metric or {x}ft {x}in for imperial.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return string.Empty;
            }

            double metersDouble;
            var parse = double.TryParse(value.ToString(), out metersDouble);

            if (!parse)
            {
                return value.ToString();
            }

            switch (this.TargetUnitOfMeasure)
            {
                case UnitOfMeasure.Metric:
                    return CalculateMetricHeight(metersDouble);
                case UnitOfMeasure.Imperial:
                    return CalculateImperialHeight(metersDouble);
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Convert back is not supported by the MetricHeightFormatConverter.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        private static object CalculateMetricHeight(double metersDouble)
        {
            var metersSplit = metersDouble.ToString().Split('.');
            if (metersSplit.Any())
            {
                int meters;
                var metersParsed = int.TryParse(metersSplit[0], out meters);

                if (metersParsed && metersSplit.Length == 1)
                {
                    return $"{meters}m";
                }

                if (metersParsed && metersSplit.Length == 2)
                {
                    int centimeters;
                    var centimetersParsed =
                        int.TryParse(
                            metersSplit[1].Substring(0, metersSplit[1].Length >= 2 ? 2 : metersSplit[1].Length),
                            out centimeters);

                    if (centimetersParsed)
                    {
                        var outVal = metersSplit[1];
                        var count = 2 - outVal.Length;

                        // Need to multiply the centimeter value so it represents centimeters correctly
                        for (var i = 1; i <= count; ++i)
                        {
                            centimeters = centimeters * 10;
                        }

                        return $"{meters}m {centimeters}cm";
                    }
                }
            }

            return metersDouble.ToString();
        }

        private static object CalculateImperialHeight(double metersDouble)
        {
            var inches = Math.Round(metersDouble * 39.3700787);
            var feet = new KeyValuePair<int, double>((int)inches / 12, inches % 12);

            return $"{feet.Key}ft {feet.Value}in";
        }
    }
}