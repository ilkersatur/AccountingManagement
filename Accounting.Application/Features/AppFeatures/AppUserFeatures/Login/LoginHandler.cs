using Accounting.Application.Abstractions;
using Accounting.Domain.AppEntities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Application.Features.AppFeatures.AppUserFeatures.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<AppUser> _userManager;

        public LoginHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.Users
                .Where(x => x.UserName == request.EmailOrUserName || x.Email == request.EmailOrUserName)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı.");
            }

            var checkerUser = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!checkerUser)
            {
                throw new Exception("Şifreniz hatalı!");
            }

            List<string> roles = new();

            LoginResponse response = new()
            {
                Email = user.Email,
                NameLastName = user.NameLastName,
                UserId = user.Id,
                Token = await _jwtProvider.CreateTokenAsync(user, roles)
            };

            return response;
        }
    }
}
