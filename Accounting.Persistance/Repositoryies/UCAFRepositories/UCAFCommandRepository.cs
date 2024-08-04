using Accounting.Domain.CompanyEntities;
using Accounting.Domain.Repositories.UCAFRepositories;

namespace Accounting.Persistance.Repositoryies.UCAFRepositories
{
    public sealed class UCAFCommandRepository : 
        CommandRepository<UniformChartOfAccount>, IUCAFCommandRepository
    {
    }
}
