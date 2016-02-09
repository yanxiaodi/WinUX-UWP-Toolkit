namespace WinUX.Extensions
{
    using Windows.UI;

    using WinUX.Enums;

    public static class ColorExtensions
    {
        /// <summary>
        /// Converts a color value to a string representation of the value in hex.
        /// </summary>
        /// <param name="color">The color to convert.</param>
        /// <returns>Returns a string containing the hex value.</returns>
        public static string ToHex(this Color color)
        {
            return $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        /// <summary>
        /// Converts a color value to an AccentColor value.
        /// </summary>
        /// <param name="color">The color to convert.</param>
        /// <returns>Returns an AccentColor representaiton of the Color value.</returns>
        public static AccentColor ToAccentColor(this Color color)
        {
            var hexValue = color.ToHex();

            switch (hexValue)
            {
                case "#FFA4C400":
                    return AccentColor.Lime; // Lime
                case "#FF60A917":
                    return AccentColor.Green; // Green
                case "#FF008A00":
                    return AccentColor.Emerald; // Emerald
                case "#FF00ABA9":
                case "#FF0099BC":
                case "#FF2D7D9A":
                    return AccentColor.Teal; // Teal
                case "#FF1BA1E2":
                    return AccentColor.Cyan; // Cyan
                case "#FF3E65FF":
                case "#FF0078D7":
                case "#FF0063B1":
                    return AccentColor.Cobalt; // Cobalt
                case "#FFAA00FF":
                    return AccentColor.Violet; // Violet
                case "#FFF472D0":
                case "#FFE74856":
                    return AccentColor.Pink; // Pink
                case "#FFD80073":
                    return AccentColor.Magenta; // Magenta
                case "#FFA20025":
                case "#FFE51400":
                case "#FFE81123":
                    return AccentColor.Red; // Crimson/Red
                case "#FFFA6800":
                case "#FFFF8C00":
                case "#FFF7630C":
                    return AccentColor.Orange; // Orange
                case "#FFF0A30A":
                    return AccentColor.Amber; // Amber
                case "#FFE3C800":
                case "#FFFFB900":
                    return AccentColor.Yellow; // Yellow
            }

            return AccentColor.Indigo; // Indigo (Default)
        }
    }
}