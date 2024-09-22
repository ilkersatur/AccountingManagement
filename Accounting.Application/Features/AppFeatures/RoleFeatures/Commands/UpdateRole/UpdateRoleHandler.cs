using Accounting.Application.Services.AppServices;
using Accounting.Domain.AppEntities.Identity;
using MediatR;

namespace Accounting.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleRequest, UpdateRoleResponse>
    {
        private readonly IRoleService _roleService;

        public UpdateRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<UpdateRoleResponse> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleService.GetById(request.Id);

            if (role == null)
            {
                throw new Exception("Bu role daha bulunamadı");
            }

            if (role.Code != request.Code)
            {
                AppRole checkRole = await _roleService.GetByCode(request.Code);

                if (checkRole != null)
                {
                    throw new Exception("Bu role daha önce oluşturuldu");
                }
            }

            role.Code = request.Code;
            role.Name = request.Name;

            await _roleService.UpdateAsync(role);

            return new();
        }

    }
}