using System;
using System.Runtime.Serialization;

namespace CleanArchitecture.Domain.Common
{
    public class CapitalCityViolationException : Exception
    {
        public CapitalCityViolationException(string message)
            : base(message)
        {
        }

        public CapitalCityViolationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CapitalCityViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}