using System;
using System.Runtime.Serialization;

namespace CleanArchitecture.Domain.Common
{
    public class ContinentViolationException : Exception
    {
        public ContinentViolationException(string message)
            : base(message)
        {
        }

        public ContinentViolationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ContinentViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}