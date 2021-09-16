using System;
using System.Runtime.Serialization;

namespace CleanArchitecture.Domain.Common
{
    public class CoordinatesViolationException : Exception
    {
        public CoordinatesViolationException(string message)
            : base(message)
        {
        }

        public CoordinatesViolationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CoordinatesViolationException(SerializationInfo info, StreamingContext context)
            : base(info,  context)
        {
        }
    }
}