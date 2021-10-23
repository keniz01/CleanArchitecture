using System;

namespace CleanArchitecture.Domain.Exceptions
{
    public class ContinentViolationException : Exception
    {
        public ContinentViolationException(string message)
            : base(message)
        {
        }
    }
}