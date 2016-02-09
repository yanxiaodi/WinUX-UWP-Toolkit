namespace WinUX.Diagnostics
{
    using System.Diagnostics.Tracing;

    public sealed class Logger : EventSource
    {
        public static Logger Log = new Logger();

        /// <summary>
        /// Write a debug event to the log
        /// </summary>
        /// <param name="message">
        /// Message to write to the log
        /// </param>
        [Event(1, Level = EventLevel.Verbose)]
        public void Debug(string message)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine($"Debug event: {message}");
            this.WriteEvent(1, message);
#endif
        }

        /// <summary>
        /// Write a informational event to the log
        /// </summary>
        /// <param name="message">
        /// Message to write to the log
        /// </param>
        [Event(2, Level = EventLevel.Informational)]
        public void Info(string message)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine($"Info event: {message}");
#endif

            this.WriteEvent(2, message);
        }

        /// <summary>
        /// Write a warning event to the log
        /// </summary>
        /// <param name="message">
        /// Message to write to the log
        /// </param>
        [Event(3, Level = EventLevel.Warning)]
        public void Warning(string message)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine($"Warning event: {message}");
#endif

            this.WriteEvent(3, message);
        }

        /// <summary>
        /// Write an error event to the log
        /// </summary>
        /// <param name="message">
        /// Message to write to the log
        /// </param>
        [Event(4, Level = EventLevel.Error)]
        public void Error(string message)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine($"Error event: {message}");
#endif

            this.WriteEvent(4, message);
        }

        /// <summary>
        /// Write a critical error event to the log
        /// </summary>
        /// <param name="message">
        /// Message to write to the log
        /// </param>
        [Event(5, Level = EventLevel.Critical)]
        public void Critical(string message)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine($"Critical event: {message}");
#endif

            this.WriteEvent(5, message);
        }
    }
}