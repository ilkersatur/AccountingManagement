using Microsoft.AspNetCore.Identity;

namespace Accounting.Domain.AppEntities.Identity
{
    public sealed class AppUser : IdentityUser<string>
    {
        public string CompanyId {  get; set; }
    }
}
