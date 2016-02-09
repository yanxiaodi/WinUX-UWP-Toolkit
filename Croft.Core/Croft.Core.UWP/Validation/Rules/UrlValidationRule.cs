namespace WinUX.Validation.Rules
{
    using System;

    using WinUX.Validation.Rules.Common;

    public class UrlValidationRule : ValidationRule
    {
        /// <summary>
        /// Gets the error message to display for the rule.
        /// </summary>
        public override string ErrorMessage => "Value is not a valid URL.";

        /// <summary>
        /// Validates an object value with this rule.
        /// </summary>
        /// <param name="value">
        /// The value to validate.
        /// </param>
        /// <returns>
        /// Returns a boolean value indicating whether the object was validated with the rule.
        /// </returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            var val = value.ToString();
            if (string.IsNullOrWhiteSpace(val))
            {
                return true;
            }

            return Uri.IsWellFormedUriString(val, UriKind.Absolute);

            //const string UrlPattern =
            //    @"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";

            //var reg = new Regex(UrlPattern, RegexOptions.IgnoreCase);
            //return reg.IsMatch(val);
        }
    }
}