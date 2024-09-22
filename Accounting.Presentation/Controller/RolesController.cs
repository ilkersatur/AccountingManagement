using Accounting.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using Accounting.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using Accounting.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using Accounting.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;
using Accounting.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Presentation.Controller
{
    public class RolesController : ApiController
    {
        public RolesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> CreateRole(CreateRoleRequest request)
        {
            CreateRoleResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> UpdateRole(UpdateRoleRequest request)
        {
            UpdateRoleResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> DeleteRole(DeleteRoleRequest request)
        {
            DeleteRoleResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetAllRoles()
        {
            GetAllRolesRequest request = new();
            GetAllRolesResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
