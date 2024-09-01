using Accounting.Domain.AppEntities.Identity;

namespace Accounting.Application.Abstractions
{
    public interface IJwtProvider
    {
       Task<string> CreateTokenAsync(AppUser user, List<string> roles);
    }
}
