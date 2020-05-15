using System;

namespace PlanHub.Domain.Exceptions
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string validationErrorMessage) : base(validationErrorMessage)
        {
        }
    }
}
