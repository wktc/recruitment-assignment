using Common.Domain.ValueObjects;

namespace Common.Domain
{
    public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot<TId>
        where TId : ValueObject, IId, new()
    {
        protected AggregateRoot() : base() 
        { }

        protected AggregateRoot(TId id) : base(id) 
        { }
    }
}