using Accounting.Domain;
using Accounting.Domain.AppEntities;
using Accounting.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Persistance
{
    public sealed class ContextService : IContectService
    {
        private readonly AppDbContext _appDbContext;

        public ContextService(AppDbContext appDbContext)
        {
                _appDbContext = appDbContext;
        }
        public DbContext CreateDbContextInstance(string companyId)
        {
            Company company = _appDbContext.Set<Company>().Find(companyId);

            return new CompanyDbContext(company);
        }
    }
}
