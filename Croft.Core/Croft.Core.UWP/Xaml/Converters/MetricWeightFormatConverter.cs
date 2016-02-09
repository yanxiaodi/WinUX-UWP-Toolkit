// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetricWeightFormatConverter.cs" company="James Croft">
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
    /// The metric weight format converter.
    /// </summary>
    public class MetricWeightFormatConverter : DependencyObject, IValueConverter
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
        /// Converts a double value to a formatted string representing the value as an imperial or metric weight.
        /// </summary>
        /// <returns>
        /// Returns a string in the format {x}kg {x}g for metric or {x}st {x}lbs for imperial.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return string.Empty;
            }

            double kiloDouble;
            var parse = double.TryParse(value.ToString(), out kiloDouble);

            if (!parse)
            {
                return value.ToString();
            }

            switch (this.TargetUnitOfMeasure)
            {
                case UnitOfMeasure.Metric:
                    return CalculateMetricWeight(kiloDouble);
                case UnitOfMeasure.Imperial:
                    return CalculateImperialWeight(kiloDouble);
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Convert back is not supported by the MetricWeightFormatConverter.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        private static object CalculateImperialWeight(double kiloDouble)
        {
            var pounds = Math.Round(kiloDouble * 2.20462);
            var stone = new KeyValuePair<int, double>((int)pounds / 14, pounds % 14);

            return $"{stone.Key}st {stone.Value}lbs";
        }

        private static object CalculateMetricWeight(double kiloDouble)
        {
            var kiloSplit = kiloDouble.ToString().Split('.');
            if (kiloSplit.Any())
            {
                int kilos;
                var kilosParsed = int.TryParse(kiloSplit[0], out kilos);

                if (kilosParsed && kiloSplit.Length == 1)
                {
                    return $"{kilos}kg";
                }

                if (kilosParsed && kiloSplit.Length == 2)
                {
                    int grams;
                    var gramsParsed =
                        int.TryParse(
                            kiloSplit[1].Substring(0, kiloSplit[1].Length >= 3 ? 3 : kiloSplit[1].Length),
                            out grams);

                    if (gramsParsed)
                    {
                        var outVal = kiloSplit[1];
                        var count = 3 - outVal.Length;

                        // Need to multiply the grams value so it represents grams correctly
                        for (var i = 1; i <= count; ++i)
                        {
                            grams = grams * 10;
                        }

                        return $"{kilos}kg {grams}g";
                    }
                }
            }

            return kiloDouble.ToString();
        }
    }
}