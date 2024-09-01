using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Application.Features.AppFeatures.CompanyFeatures.AppUserFeatures.Login
{
    public sealed class LoginResponse
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string NameLastName { get; set; }
    }
}
