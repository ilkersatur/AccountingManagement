using Accounting.Domain.Abstraction;

namespace Accounting.Domain.Repositories
{
    public interface ICommandRepository<T> : IRepository<T> where T : Entity
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task Update(T entity);
        Task UpdateRange(IEnumerable<T> entities);
        Task RemoveById(string id);
        Task Remove(T entity);
        Task RemoveRange(IEnumerable<T> entities);
    }
}
