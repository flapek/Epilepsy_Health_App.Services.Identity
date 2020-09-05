using Epilepsy_Health_App.Services.Identity.Application.DTO;
using Epilepsy_Health_App.Services.Identity.Application.Services;
using Joint.Auth;
using System;

namespace Epilepsy_Health_App.Services.Identity.Infrastructure.Auth
{
    public class JwtProvider : IJwtProvider
    {
        private readonly IJwtHandler _jwtHandler;

        public JwtProvider(IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }

        public AuthDto Create(Guid userId, string email)
        {
            var jwt = _jwtHandler.CreateToken(userId.ToString(), email);

            return new AuthDto
            {
                Id = userId,
                AccessToken = jwt.AccessToken,
                RefreshToken = jwt.RefreshToken,
            };
        }
    }
}