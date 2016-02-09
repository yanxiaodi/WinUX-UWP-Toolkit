// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccentColorExtensions.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   The accent color extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Extensions
{
    using Windows.UI;

    using WinUX.Enums;

    /// <summary>
    /// A collection of AccentColor extensions.
    /// </summary>
    public static class AccentColorExtensions
    {
        /// <summary>
        /// Represents an AccentColor value as a dark Color value.
        /// </summary>
        /// <param name="accentColor">
        /// The accent color.
        /// </param>
        /// <returns>
        /// Returns a dark Color value for the given AccentColor.
        /// </returns>
        public static Color ToDarkAccentColor(this AccentColor accentColor)
        {
            var newColor = "#FF303f9f".ToColor(); // Indigo (Default)

            switch (accentColor)
            {
                case AccentColor.Lime:
                    newColor = "#FFAFB42B".ToColor();
                    break;
                case AccentColor.Green:
                    newColor = "#FF689F38".ToColor();
                    break;
                case AccentColor.Emerald:
                    newColor = "#FF388E3C".ToColor();
                    break;
                case AccentColor.Teal:
                    newColor = "#FF00796B".ToColor();
                    break;
                case AccentColor.Cyan:
                    newColor = "#FF0097A7".ToColor();
                    break;
                case AccentColor.Cobalt:
                    newColor = "#FF1976D2".ToColor();
                    break;
                case AccentColor.Violet:
                    newColor = "#FF512DA8".ToColor();
                    break;
                case AccentColor.Pink:
                    newColor = "#FFC2185B".ToColor(); 
                    break;
                case AccentColor.Magenta:
                    newColor = "#FF7B1FA2".ToColor();
                    break;
                case AccentColor.Red:
                    newColor = "#FFD32F2F".ToColor();
                    break;
                case AccentColor.Orange:
                    newColor = "#FFF57C00".ToColor();
                    break;
                case AccentColor.Amber:
                    newColor = "#FFFFA000".ToColor();
                    break;
                case AccentColor.Yellow:
                    newColor = "#FFFBC02D".ToColor();
                    break;
            }

            return newColor;
        }

        /// <summary>
        /// Represents an AccentColor value as a light Color value.
        /// </summary>
        /// <param name="accentColor">
        /// The accent color.
        /// </param>
        /// <returns>
        /// Returns a light Color value for the given AccentColor.
        /// </returns>
        public static Color ToLightAccentColor(this AccentColor accentColor)
        {
            var newColor = "#FFC5CAE9".ToColor(); // Indigo (Default)

            switch (accentColor)
            {
                case AccentColor.Lime:
                    newColor = "#FFF0F4C3".ToColor();
                    break;
                case AccentColor.Green:
                    newColor = "#FFDCEDC8".ToColor();
                    break;
                case AccentColor.Emerald:
                    newColor = "#FFC8E6C9".ToColor();
                    break;
                case AccentColor.Teal:
                    newColor = "#FFB2DFDB".ToColor(); 
                    break;
                case AccentColor.Cyan:
                    newColor = "#FFB2EBF2".ToColor(); 
                    break;
                case AccentColor.Cobalt:
                    newColor = "#FFBBDEFB".ToColor();
                    break;
                case AccentColor.Violet:
                    newColor = "#FFD1C4E9".ToColor(); 
                    break;
                case AccentColor.Pink:
                    newColor = "#FFF8BBD0".ToColor(); 
                    break;
                case AccentColor.Magenta:
                    newColor = "#FFE1BEE7".ToColor(); 
                    break;
                case AccentColor.Red:
                    newColor = "#FFFFCDD2".ToColor(); 
                    break;
                case AccentColor.Orange:
                    newColor = "#FFFFE0B2".ToColor(); 
                    break;
                case AccentColor.Amber:
                    newColor = "#FFFFECB3".ToColor(); 
                    break;
                case AccentColor.Yellow:
                    newColor = "#FFFFF9C4".ToColor(); 
                    break;
            }

            return newColor;
        }

        /// <summary>
        /// Represents an AccentColor value as a primary Color value.
        /// </summary>
        /// <param name="accentColor">
        /// The accent color.
        /// </param>
        /// <returns>
        /// Returns a primary Color for the given AccentColor.
        /// </returns>
        public static Color ToPrimaryAccentColor(this AccentColor accentColor)
        {
            var newColor = "#FF3F51B5".ToColor(); // Indigo (Default)

            switch (accentColor)
            {
                case AccentColor.Lime:
                    newColor = "#FFCDDC39".ToColor();
                    break;
                case AccentColor.Green:
                    newColor = "#FF8BC34A".ToColor(); 
                    break;
                case AccentColor.Emerald:
                    newColor = "#FF4CAF50".ToColor(); 
                    break;
                case AccentColor.Teal:
                    newColor = "#FF009688".ToColor(); 
                    break;
                case AccentColor.Cyan:
                    newColor = "#FF00BCD4".ToColor(); 
                    break;
                case AccentColor.Cobalt:
                    newColor = "#FF2196F3".ToColor(); 
                    break;
                case AccentColor.Violet:
                    newColor = "#FF673AB7".ToColor(); 
                    break;
                case AccentColor.Pink:
                    newColor = "#FFE91E63".ToColor(); 
                    break;
                case AccentColor.Magenta:
                    newColor = "#FF9C27B0".ToColor(); 
                    break;
                case AccentColor.Red:
                    newColor = "#FFF44336".ToColor();
                    break;
                case AccentColor.Orange:
                    newColor = "#FFFF9800".ToColor(); 
                    break;
                case AccentColor.Amber:
                    newColor = "#FFFFC107".ToColor(); 
                    break;
                case AccentColor.Yellow:
                    newColor = "#FFFFEB3B".ToColor(); 
                    break;
            }

            return newColor;
        }
    }
}
