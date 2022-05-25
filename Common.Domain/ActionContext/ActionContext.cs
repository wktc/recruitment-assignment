using System.Collections.Generic;
using Common.Domain.User.ValueObjects;
using Common.Domain.ValueObjects;

namespace Common.Domain.ActionContext
{
    public class ActionContext : ValueObject
    {
        public UserId UserId { get; }

        public ActionContext(UserId userId)
        {
            UserId = userId;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return UserId;
        }
    }
}
