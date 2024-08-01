using Accounting.Application.Services.AppServices;
using Accounting.Domain.AppEntities;
using MediatR;

namespace Accounting.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
    internal class CreateCompanyHandler : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
    {
        private readonly ICompanyService _companyService;

        public CreateCompanyHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
        {
            Company company = await _companyService.GetCompanyByName(request.CompanyName);

            if (company != null) throw new Exception("Bu şirket ismi daha önce kullanılmış");

            await _companyService.CreateCompany(request);
            return new();
        }
    }
}
