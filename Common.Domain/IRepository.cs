using System.Threading.Tasks;

namespace Common.Domain
{
    public interface IRepository
    {
    }

    public interface IRepository<TAggregateRoot, in TId>
        where TAggregateRoot : IAggregateRoot<TId>
        where TId : IId, new()
    {
        ValueTask InsertAsync(TAggregateRoot aggregateRoot);

        ValueTask<TAggregateRoot> GetAsync(TId id);
        ValueTask<TAggregateRoot> GetOrNullAsync(TId id);

        ValueTask DeleteAsync(TAggregateRoot aggregateRoot);
        ValueTask DeleteAsync(TId id);

        ValueTask<bool> ExistsAsync(TId id);
        ValueTask<int> CountAsync();
        ValueTask<bool> AnyAsync();
    }
}
