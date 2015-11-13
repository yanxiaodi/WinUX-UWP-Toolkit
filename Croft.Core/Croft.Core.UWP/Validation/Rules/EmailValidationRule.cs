namespace Croft.Core.Validation.Rules
{
    using System.Text.RegularExpressions;

    public class EmailValidationRule : ValidationRule
    {
        public override string ErrorMessage => "Value is not a valid e-mail.";

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

            const string EmailPattern =
                @"^([0-9a-zA-Z](?>[-.+\w]*[0-9a-zA-Z])*@(?>[0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";

            var regex = new Regex(EmailPattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(val);
        }
    }
}