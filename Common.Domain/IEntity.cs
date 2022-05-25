using System.Collections.Generic;

namespace Common.Domain
{
    public interface IEntity<out TId> : IEntity
    {
        TId Id { get; }
    }

    public interface IEntity
    {
        IId GetId();

        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        void ClearDomainEvents();
    }
}
