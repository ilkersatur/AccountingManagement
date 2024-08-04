
using Microsoft.EntityFrameworkCore;

namespace Accounting.Domain
{
    public interface IContectService
    {
        DbContext CreateDbContextInstance(string companyId);
    }
}
