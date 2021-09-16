using System;
using System.Runtime.Serialization;

namespace CleanArchitecture.Domain.Common
{
    public class IdViolationException : Exception
    {
        public IdViolationException(string message)
            : base(message)
        {
        }

        public IdViolationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public IdViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}