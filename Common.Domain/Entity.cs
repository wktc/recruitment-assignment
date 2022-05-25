using System;
using System.Collections.Generic;
using Common.Domain.ValueObjects;

namespace Common.Domain
{
    public abstract class Entity<TId> : IEntity, IEquatable<Entity<TId>>
        where TId : ValueObject, IId, new()
    {
        private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        public virtual IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        public virtual TId Id { get; protected set; }
        public virtual IId GetId() => Id;

        protected Entity()
        {
            Id = new TId();
        }

        protected Entity(TId id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity<TId>);
        }

        public virtual bool Equals(Entity<TId> other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            return Id.Equals(other.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Entity<TId> a, Entity<TId> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<TId> a, Entity<TId> b)
        {
            return !(a == b);
        }

        public virtual void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
