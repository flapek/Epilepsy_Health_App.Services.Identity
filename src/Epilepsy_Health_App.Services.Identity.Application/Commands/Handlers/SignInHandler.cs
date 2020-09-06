using Epilepsy_Health_App.Services.Identity.Application.DTO;
using Epilepsy_Health_App.Services.Identity.Application.Services;
using Joint.CQRS.Commands;
using System.Threading.Tasks;

namespace Epilepsy_Health_App.Services.Identity.Application.Commands.Handlers
{
    public class SignInHandler : ICommandHandler<SignIn, AuthDto>
    {
        readonly IIdentityService _identityService;

        public SignInHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public Task<AuthDto> HandleAsync(SignIn command) => _identityService.SignInAsync(command);
    }
}
