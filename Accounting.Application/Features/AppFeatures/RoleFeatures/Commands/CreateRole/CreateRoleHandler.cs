using Accounting.Application.Services.AppServices;
using Accounting.Domain.AppEntities.Identity;
using MediatR;

namespace Accounting.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleRequest, CreateRoleResponse>
    {
        private readonly IRoleService _roleService;

        public CreateRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CreateRoleResponse> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleService.GetByCode(request.Code);

            if (role != null)
            {
                throw new Exception("Bu role daha önce oluşturuldu");
            }

            await _roleService.AddAsync(request);
            return new();
        }
    }
}
