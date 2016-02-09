// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationRules.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the ValidationRules type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Validation
{
    using System.Collections.Generic;

    using WinUX.Validation.Rules.Common;

    /// <summary>
    /// A collection for containing ValidationRules.
    /// </summary>
    public class ValidationRules
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationRules"/> class.
        /// </summary>
        public ValidationRules()
        {
            this.Rules = new List<ValidationRule>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationRules"/> class.
        /// </summary>
        /// <param name="rules">
        /// A set of ValidationRules to initialize with.
        /// </param>
        public ValidationRules(List<ValidationRule> rules)
        {
            this.Rules = rules;
        }

        /// <summary>
        /// Gets the collection of ValidationRules.
        /// </summary>
        public List<ValidationRule> Rules { get; }
    }
}