using Epilepsy_Health_App.Services.Identity.Application.DTO;
using Epilepsy_Health_App.Services.Identity.Application.Services;
using Joint.CQRS.Commands;
using System;
using System.Threading.Tasks;

namespace Epilepsy_Health_App.Services.Identity.Application.Commands.Handlers
{
    public class Refresh_TokenHandler : ICommandHandler<Refresh_Token, AuthDto>
    {
        readonly IRefreshTokenService _refreshTokenService;

        public Refresh_TokenHandler(IRefreshTokenService refreshTokenService)
        {
            _refreshTokenService = refreshTokenService;
        }

        public Task<AuthDto> HandleAsync(Refresh_Token command) => _refreshTokenService.UseAsync(command.RefreshToken);
    }
}
