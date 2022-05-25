using System;
using Common.Domain.ValueObjects.Identifiers;

namespace Common.Domain.User.ValueObjects
{
    public class UserId : GuidIdValueObject
    {
        public UserId() : base()
        {
        }

        public UserId(Guid id) : base(id)
        {
        }

        public static UserId CreateOrNull(Guid? id) => id is null ? null : new UserId(id.Value);
    }
}
