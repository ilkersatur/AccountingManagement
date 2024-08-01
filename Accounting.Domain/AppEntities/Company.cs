using Accounting.Domain.Abstraction;

namespace Accounting.Domain.AppEntities
{
    public sealed class Company : Entity
    {
        public string CompanyName { get; set; }

        public string? CompanyAddress { get; set; }

        public string? IdentityNumber { get; set; }

        public string? TaxDepartment { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string ServerName { get; set; }

        public string DatabaseName { get; set; }

        public string UserId { get; set; }

        public string Password { get; set; }
    }
}
