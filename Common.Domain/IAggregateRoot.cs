

namespace Common.Domain
{
    public interface IAggregateRoot<out TId> : IAggregateRoot, IEntity<TId>
        where TId : IId, new()
    {
    }

    public interface IAggregateRoot : IEntity
    {
    }
}