using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.ValueObjects;

namespace Infrastructure.Repositories
{
    public abstract class Repository<TAggregateRoot, TId> : IRepository<TAggregateRoot, TId>
        where TAggregateRoot : class, IAggregateRoot<TId>
        where TId : ValueObject, IId, new()
    {
        protected ICollection<TAggregateRoot> Collection = new Collection<TAggregateRoot>();

        protected Repository()
        {
        }
        
        public async ValueTask InsertAsync(TAggregateRoot aggregateRoot) => Collection.Add(aggregateRoot);

        public async ValueTask<TAggregateRoot> GetAsync(TId id) 
            => await GetOrNullAsync(id) ?? throw new ApplicationException("Object not found.");

        public async ValueTask<TAggregateRoot> GetOrNullAsync(TId id) => Collection.SingleOrDefault(x => x.Id.Equals(id));

        public async ValueTask DeleteAsync(TAggregateRoot aggregateRoot) => Collection.Remove(aggregateRoot);

        public async ValueTask DeleteAsync(TId id)
        {
            var aggregateRoot = await GetAsync(id);

            await DeleteAsync(aggregateRoot);
        }

        public async ValueTask<bool> ExistsAsync(TId id) => Collection.Any(x => x.Id.Equals(id));

        public async ValueTask<bool> AnyAsync() => Collection.Any();
        public async ValueTask<int> CountAsync() => Collection.Count;
    }
}
