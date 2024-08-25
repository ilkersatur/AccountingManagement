using Accounting.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using Accounting.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Presentation.Controller
{
    public sealed class UCAFsController : ApiController
    {
        public UCAFsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> CreateUCAF(CreateUCAFRequest request)
        {
            CreateUCAFResponse response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
