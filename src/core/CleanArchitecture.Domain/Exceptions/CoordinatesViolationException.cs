using System;

namespace CleanArchitecture.Domain.Exceptions
{
    public class CoordinatesViolationException : Exception
    {
        public CoordinatesViolationException(string message)
            : base(message)
        {
        }
    }
}