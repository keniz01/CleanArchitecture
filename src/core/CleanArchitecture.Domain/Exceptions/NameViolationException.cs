using System;

namespace CleanArchitecture.Domain.Exceptions
{
    public class NameViolationException : Exception
    {
        public NameViolationException(string message)
            : base(message)
        {
        }
    }
}