namespace Croft.Core.Validation.Rules
{
    public class IntValidationRule : ValidationRule
    {
        public override string ErrorMessage => "Value is not a valid number.";

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            int val;
            return int.TryParse(value.ToString(), out val);
        }
    }
}