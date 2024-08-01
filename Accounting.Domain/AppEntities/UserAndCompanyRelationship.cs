using Accounting.Domain.Abstraction;
using Accounting.Domain.AppEntities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting.Domain.AppEntities
{
    public sealed class UserAndCompanyRelationship : Entity
    {
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        [ForeignKey("CompanyId")]
        public string CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
