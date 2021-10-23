using System;

namespace CleanArchitecture.Domain.Exceptions
{
    public class CountryViolationException : Exception
    {
        public CountryViolationException(string message)
            : base(message)
        {
        }
    }
}