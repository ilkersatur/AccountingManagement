using Accounting.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using Accounting.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using Accounting.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using Accounting.Domain.AppEntities.Identity;

namespace Accounting.Application.Services.AppServices
{
    public interface IRoleService
    {
        Task AddAsync(CreateRoleRequest request);
        Task UpdateAsync(AppRole request);
        Task DeleteAsync(AppRole request);
        Task<IList<AppRole>> GetAllRolesAsync();
        Task<AppRole> GetById(string id);
        Task<AppRole> GetByCode(string code);
    }
}
