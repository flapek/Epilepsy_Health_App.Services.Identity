using Epilepsy_Health_App.Services.Identity.Application.DTO;
using System;

namespace Epilepsy_Health_App.Services.Identity.Application.Services
{
    public interface IJwtProvider
    {
        AuthDto Create(Guid userId, string email);
    }
}
