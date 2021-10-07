using System;

namespace CleanArchitecture.Domain.Exceptions
{
    public class AreaViolationException : Exception
    {
        public AreaViolationException(string message)
            : base(message)
        {
        }
    }
}