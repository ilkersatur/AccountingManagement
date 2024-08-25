
using Accounting.Application.Services.AppServices;
using Accounting.Application.Services.CompanyServices;
using Accounting.Domain.Repositories.UCAFRepositories;
using Accounting.Domain;
using Accounting.Persistance.Repositoryies.UCAFRepositories;
using Accounting.Persistance.Services.AppServices;
using Accounting.Persistance.Services.CompanyServices;
using Accounting.Persistance;

namespace Accounting.WebApi.Configurations
{
    public class PersistanceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            #region Context UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContectService, ContextService>();
            #endregion

            #region Services
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUCAFService, UCAFService>();
            #endregion

            #region Repositories
            services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
            services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
            #endregion
        }
    }
}
