// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidatingTextBox.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the ValidatingTextBox type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Croft.Core.Xaml.Controls
{
    using System.Linq;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    using Croft.Core.Exceptions;
    using Croft.Core.Validation;

    /// <summary>
    /// The validating text box control.
    /// </summary>
    public class ValidatingTextBox : TextBox
    {
        public static readonly DependencyProperty IsInvalidProperty = DependencyProperty.Register(
            "IsInvalid",
            typeof(bool),
            typeof(ValidatingTextBox),
            new PropertyMetadata(true));

        public static readonly DependencyProperty IsMandatoryProperty = DependencyProperty.Register(
            "IsMandatory",
            typeof(bool),
            typeof(ValidatingTextBox),
            new PropertyMetadata(false));

        public static readonly DependencyProperty ValidationRulesProperty =
            DependencyProperty.Register(
                "ValidationRules",
                typeof(ValidationRules),
                typeof(ValidatingTextBox),
                new PropertyMetadata(null));

        private TextBlock _remainingCounter;

        private TextBlock _errorMessage;

        private bool _isTemplateApplied;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatingTextBox"/> class.
        /// </summary>
        public ValidatingTextBox()
        {
            this.DefaultStyleKey = typeof(ValidatingTextBox);
        }

        /// <summary>
        /// Gets or sets the collection of ValidationRules.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether the control's value is mandatory.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether the control's value is invalid.
        /// </summary>
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

        private bool IsMandatoryValidationMet()
        {
            if (this.IsMandatory)
            {
                if (string.IsNullOrWhiteSpace(this.Text))
                {
                    this._errorMessage.Text = "A value is required.";
                    VisualStateManager.GoToState(this, "Mandatory", true);
                    return false;
                }
            }

            return true;
        }

        private void UpdateRemainingCounter()
        {
            var remainingChar = string.Format("{0}/{1}", this.Text.Length, this.MaxLength);

            this._remainingCounter.Text = remainingChar;

            this._remainingCounter.Visibility = this.MaxLength > 0 ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
