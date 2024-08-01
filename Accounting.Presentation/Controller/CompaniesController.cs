using Accounting.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using Accounting.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase;
using Accounting.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Presentation.Controller
{
    public sealed class CompaniesController : ApiController
    {
        public CompaniesController(IMediator _mediator) : base(_mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCompany(CreateCompanyRequest request)
        {
            CreateCompanyResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> MigrateCompanyDatabases()
        {
            MigrateCompanyDatabasesRequest request = new();

            MigrateCompanyDatabasesResponse response =  await _mediator.Send(request);

            return Ok(response);
        }
    }
}
