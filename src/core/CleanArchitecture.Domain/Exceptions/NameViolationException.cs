using System;
using System.Runtime.Serialization;

namespace CleanArchitecture.Domain.Exceptions
{
    public class NameViolationException : Exception
    {
        public NameViolationException(string message)
            : base(message)
        {
        }

        public NameViolationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NameViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}