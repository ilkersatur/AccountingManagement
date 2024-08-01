using Accounting.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using Accounting.Domain.AppEntities;

namespace Accounting.Application.Services.AppServices
{
    public interface ICompanyService
    {
        Task CreateCompany(CreateCompanyRequest request);
        Task MigrateCompanyDatabases();
        Task<Company?> GetCompanyByName(string name);
    }
}
