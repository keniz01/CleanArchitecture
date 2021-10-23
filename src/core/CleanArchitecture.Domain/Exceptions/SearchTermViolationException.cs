using System;

namespace CleanArchitecture.Domain.Exceptions
{
    public class SearchTermViolationException : Exception
    {
        public SearchTermViolationException(string message)
            : base(message)
        {
        }
    }
}