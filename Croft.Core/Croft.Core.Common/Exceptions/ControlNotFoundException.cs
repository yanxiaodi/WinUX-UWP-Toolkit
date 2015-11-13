namespace Croft.Core.Exceptions
{
    using System;

    public class ControlNotFoundException : Exception
    {
        public ControlNotFoundException(string message)
            : base(message)
        {
        }

        public ControlNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}