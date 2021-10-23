using System;

namespace CleanArchitecture.Domain.Exceptions
{
    public class RegionViolationException : Exception
    {
        public RegionViolationException(string message)
            : base(message)
        {
        }
    }
}