namespace Croft.Core.Validation.Rules
{
    public class DoubleValidationRule : ValidationRule
    {
        public override string ErrorMessage => "Value is not a valid number.";

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            double val;
            return double.TryParse(value.ToString(), out val);
        }
    }
}