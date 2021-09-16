using System;
using System.Runtime.Serialization;

namespace CleanArchitecture.Domain.Common
{
    public class InputViolationException : Exception
    {
        public InputViolationException(string message)
            : base(message)
        {
        }

        public InputViolationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public InputViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}