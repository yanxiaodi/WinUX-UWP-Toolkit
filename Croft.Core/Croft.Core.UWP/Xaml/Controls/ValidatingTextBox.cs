namespace WinUX.Xaml.Controls
{
    using System.Linq;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    using WinUX.Exceptions;
    using WinUX.Extensions;
    using WinUX.Validation;

    public class ValidatingTextBox : TextBox
    {
        public static readonly DependencyProperty IsInvalidProperty = DependencyProperty.Register(
            "IsInvalid",
            typeof(bool),
            typeof(ValidatingTextBox),
            new PropertyMetadata(false));

        public static readonly DependencyProperty IsMandatoryProperty = DependencyProperty.Register(
            "IsMandatory",
            typeof(bool),
            typeof(ValidatingTextBox),
            new PropertyMetadata(false, Update));

        public static readonly DependencyProperty ValidationRulesProperty =
            DependencyProperty.Register(
                "ValidationRules",
                typeof(ValidationRules),
                typeof(ValidatingTextBox),
                new PropertyMetadata(null, Update));

        public static readonly DependencyProperty MandatoryValidationMessageProperty =
            DependencyProperty.Register(
                "MandatoryValidationMessage",
                typeof(string),
                typeof(ValidatingTextBox),
                new PropertyMetadata("Text required."));

        private bool _isTemplateApplied;

        private TextBlock _errorMessage;

        private TextBlock _remainingCounter;

        public ValidatingTextBox()
        {
            this.DefaultStyleKey = typeof(ValidatingTextBox);

            this.ListenToProperty("Visibility", this.OnVisibilityChanged);
        }

        public ValidationRules ValidationRules
        {
            get
            {
                return (ValidationRules)this.GetValue(ValidationRulesProperty);
            }
            set
            {
                this.SetValue(ValidationRulesProperty, value);
            }
        }

        public bool IsMandatory
        {
            get
            {
                return (bool)this.GetValue(IsMandatoryProperty);
            }
            set
            {
                this.SetValue(IsMandatoryProperty, value);
            }
        }

        public bool IsInvalid
        {
            get
            {
                return (bool)this.GetValue(IsInvalidProperty);
            }
            set
            {
                this.SetValue(IsInvalidProperty, value);
            }
        }

        public string MandatoryValidationMessage
        {
            get
            {
                return (string)this.GetValue(MandatoryValidationMessageProperty);
            }
            set
            {
                this.SetValue(MandatoryValidationMessageProperty, value);
            }
        }

        protected override void OnApplyTemplate()
        {
            this._remainingCounter = (TextBlock)this.GetTemplateChild("RemainingCounter");
            this._errorMessage = (TextBlock)this.GetTemplateChild("ErrorMessage");

            if (this._remainingCounter == null)
            {
                throw new ControlNotFoundException(
                    "Could not find the RemainingCounter TextBlock for the ValidatingTextBox control.");
            }

            if (this._errorMessage == null)
            {
                throw new ControlNotFoundException(
                    "Could not find the ErrorMessage TextBlock for the ValidatingTextBox control.");
            }

            if (this.MaxLength == 0)
            {
                this._remainingCounter.Visibility = Visibility.Collapsed;
            }

            this.Update();

            if (!this._isTemplateApplied)
            {
                this.TextChanged += this.OnTextChanged;
                this._isTemplateApplied = true;
            }

            base.OnApplyTemplate();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            this.Update();
        }

        private void Update()
        {
            if (this._errorMessage != null)
            {
                this.UpdateRemainingCounter();

                bool[] isInvalid = { !this.IsMandatoryValidationMet() };

                if (!isInvalid[0])
                {
                    if (this.ValidationRules != null)
                    {
                        foreach (var rule in this.ValidationRules.Rules.TakeWhile(rule => !isInvalid[0]))
                        {
                            isInvalid[0] = !rule.IsValid(this.Text);

                            if (isInvalid[0])
                            {
                                this._errorMessage.Text = rule.ErrorMessage;
                            }
                        }
                    }
                }

                this.IsInvalid = isInvalid[0];

                VisualStateManager.GoToState(this, this.IsInvalid ? "Invalid" : "Valid", true);
            }
        }

        private bool IsMandatoryValidationMet()
        {
            if (this.IsMandatory)
            {
                if (string.IsNullOrWhiteSpace(this.Text))
                {
                    this._errorMessage.Text = this.MandatoryValidationMessage;
                    VisualStateManager.GoToState(this, "Mandatory", true);
                    return false;
                }
            }

            return true;
        }

        private void UpdateRemainingCounter()
        {
            if (this._remainingCounter != null)
            {
                if (this.MaxLength == 0)
                {
                    this._remainingCounter.Visibility = Visibility.Collapsed;
                    return;
                }

                var remainingChar = string.Format("{0}/{1}", this.Text.Length, this.MaxLength);

                this._remainingCounter.Text = remainingChar;

                this._remainingCounter.Visibility = this.MaxLength > 0 ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private static void Update(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as ValidatingTextBox;
            control?.Update();
        }

        private void OnVisibilityChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this._isTemplateApplied)
            {
                if (e.NewValue != e.OldValue)
                {
                    this.Update();
                }
            }
        }
    }
}