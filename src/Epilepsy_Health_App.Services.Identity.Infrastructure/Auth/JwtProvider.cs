using Convey.Auth;
using Epilepsy_Health_App.Services.Identity.Application.DTO;
using Epilepsy_Health_App.Services.Identity.Application.Services;
using System;
using System.Collections.Generic;

namespace Epilepsy_Health_App.Services.Identity.Infrastructure.Auth
{
    internal sealed class JwtProvider : IJwtProvider
    {
        private readonly IJwtHandler _jwtHandler;

        public JwtProvider(IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }

        public AuthDto Create(Guid userId, string role, string audience = null,
            IDictionary<string, IEnumerable<string>> claims = null)
        {
            var jwt = _jwtHandler.CreateToken(userId.ToString("N"), role, audience, claims);

            return new AuthDto
            {
                AccessToken = jwt.AccessToken,
                Role = jwt.Role,
                Expires = jwt.Expires
            };
        }
    }
}
