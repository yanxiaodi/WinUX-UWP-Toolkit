// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControlNotFoundException.cs" company="James Croft">
//   Copyright (c) 2015 James Croft.
// </copyright>
// <summary>
//   Defines the ControlNotFoundException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinUX.Exceptions
{
    using System;

    /// <summary>
    /// An exception designed to be thrown when a control is missing.
    /// </summary>
    public class ControlNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlNotFoundException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception error message.
        /// </param>
        public ControlNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlNotFoundException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception error message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public ControlNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}