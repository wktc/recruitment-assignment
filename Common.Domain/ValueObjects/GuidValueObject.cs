using System;

namespace Common.Domain.ValueObjects
{
    public abstract class GuidValueObject : SingleValuedValueObject<Guid>
    {
        protected GuidValueObject()
        {
        }

        protected GuidValueObject(Guid value) : base(value)
        {
        }

        public override string ToString() => Value.ToString();

        public static implicit operator Guid(GuidValueObject id)
        {
            return id.Value;
        }
    }
}

