using System;

namespace Common.Domain.ValueObjects.Identifiers
{
    public abstract class GuidIdValueObject : GuidValueObject, IId
    {
        protected GuidIdValueObject() : base(Guid.NewGuid())
        {
        }

        protected GuidIdValueObject(Guid id) : base(id)
        {
        }

        public object GetIdValue() => Value; //todo jk KG czy jest na to test?
    }
}

