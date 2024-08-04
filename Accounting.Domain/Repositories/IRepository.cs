using Accounting.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        void SetDbContextInstance(DbContext context);

        DbSet<T> Entity { get; set; }
    }
}
