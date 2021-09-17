using System;
using System.Runtime.Serialization;

namespace CleanArchitecture.Domain.Common
{
    public class CountryViolationException : Exception
    {
        public CountryViolationException(string message)
            : base(message)
        {
        }

        public CountryViolationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CountryViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}