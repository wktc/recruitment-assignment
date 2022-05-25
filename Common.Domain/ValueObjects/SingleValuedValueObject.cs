using System.Collections.Generic;
using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects
{
    public abstract class SingleValuedValueObject<TValue> : ValueObject, ISingleValueObject
    {
        public TValue Value { get; protected set; }

        protected SingleValuedValueObject()
        {
        }

        protected SingleValuedValueObject(TValue value)
        {
            Value = value ?? throw new InvalidValueObjectDomainException(GetType().Name, nameof(Value));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
