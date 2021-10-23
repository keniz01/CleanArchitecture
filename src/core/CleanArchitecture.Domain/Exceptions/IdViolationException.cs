using System;

namespace CleanArchitecture.Domain.Exceptions
{
    public class IdViolationException : Exception
    {
        public IdViolationException(string message)
            : base(message)
        {
        }
    }
}