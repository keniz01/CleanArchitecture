using System;
using System.Runtime.Serialization;

namespace CleanArchitecture.Domain.Common
{
    public class RegionViolationException : Exception
    {
        public RegionViolationException(string message)
            : base(message)
        {
        }

        public RegionViolationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public RegionViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}