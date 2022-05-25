using System;

namespace Common.Domain.Exceptions
{
    public class InvalidValueObjectDomainException : DomainException
    {
        public InvalidValueObjectDomainException(string source, string message, Exception innerException = null)
            : base(source, null, message, innerException)
        {
        }

        public InvalidValueObjectDomainException(string source, Enum errorCode, string message, Exception innerException = null)
            : base(source, errorCode, message, innerException)
        {
        }
    }
}
