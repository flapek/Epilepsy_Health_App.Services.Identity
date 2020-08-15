using Epilepsy_Health_App.Services.Identity.Application.DTO;
using System;
using System.Collections.Generic;

namespace Epilepsy_Health_App.Services.Identity.Application.Services
{
    public interface IJwtProvider
    {
        AuthDto Create(Guid userId, string role, string audience = null,
            IDictionary<string, IEnumerable<string>> claims = null);
    }
}
