using Accounting.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;

namespace Accounting.Application.Services.CompanyServices
{
    public interface IUCAFService
    {
        Task CreateUcafAsync(CreateUCAFRequest request);
    }
}
