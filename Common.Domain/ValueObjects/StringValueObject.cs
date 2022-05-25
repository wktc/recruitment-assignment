using System.Collections.Generic;
using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects
{
    public abstract class StringValueObject : SingleValuedValueObject<string>
    {
        protected StringValueObject()
        { }

        protected StringValueObject(string value, int? maxLength = null, int minLength = 1) : base(value?.Trim())
        {
            if (minLength < 1) throw new InvalidValueObjectDomainException(GetType().Name, "MinLength cannot be smaller than 1");

            if(maxLength.HasValue && maxLength < minLength) throw new InvalidValueObjectDomainException(GetType().Name, "MaxLength cannot be smaller than MinLength");

            if (Value.Length < minLength) throw new InvalidValueObjectDomainException(GetType().Name, $"Value ({value}) is too short, min length: {minLength}");

            if (maxLength.HasValue && Value.Length > maxLength.Value) throw new InvalidValueObjectDomainException(GetType().Name, $"Value ({value}) is too long, max length: {maxLength}");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value.ToLower();
        }

        public override string ToString() => Value;

        public static implicit operator string(StringValueObject str) => str?.Value;
    }
}

