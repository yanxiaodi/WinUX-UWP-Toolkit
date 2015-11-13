namespace Croft.Core.Validation.Rules
{
    using System.Text.RegularExpressions;

    public class UrlValidationRule : ValidationRule
    {
        public override string ErrorMessage => "Value is not a valid URL.";

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

            const string UrlPattern =
                @"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";

            var reg = new Regex(UrlPattern, RegexOptions.IgnoreCase);
            return reg.IsMatch(val);
        }
    }
}