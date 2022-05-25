using System.Text.RegularExpressions;
using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects
{
    public abstract class NumericStringValueObject : StringValueObject
    {
        protected NumericStringValueObject()
        {
        }

        protected NumericStringValueObject(string value, int? maxLength = null, int minLength = 1)
        : base(value, maxLength, minLength)
        {
            if (!Regex.IsMatch(Value, @"^\d*$")) 
                throw new InvalidValueObjectDomainException(GetType().Name, $"Value {value} is not numeric");
        }
    }
}

