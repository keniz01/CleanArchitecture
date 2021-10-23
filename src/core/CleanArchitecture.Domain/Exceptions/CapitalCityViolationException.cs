using System;

namespace CleanArchitecture.Domain.Exceptions
{
    public class CapitalCityViolationException : Exception
    {
        public CapitalCityViolationException(string message)
            : base(message)
        {
        }
    }
}