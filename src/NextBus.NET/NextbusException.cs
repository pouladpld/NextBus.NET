using System;

namespace NextBus.NET
{
    public class NextBusException : Exception
    {
        public bool ShouldRetry { get; internal set; }

        public NextBusException()
        {
        }

        public NextBusException(string message)
            : base(message)
        {
        }

        public NextBusException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }

}