namespace WinUX.Validation.Rules
{
    using WinUX.Validation.Rules.Common;

    public class DoubleValidationRule : ValidationRule
    {
        /// <summary>
        /// Gets the error message to display for the rule.
        /// </summary>
        public override string ErrorMessage => "Value is not a valid number.";

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

            double dblVal;
            return double.TryParse(val, out dblVal);
        }
    }
}