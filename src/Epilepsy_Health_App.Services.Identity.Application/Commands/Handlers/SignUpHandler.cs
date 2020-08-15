using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Epilepsy_Health_App.Services.Identity.Application.Services;

namespace Epilepsy_Health_App.Services.Identity.Application.Commands.Handlers
{
    // Simple wrapper
    internal sealed  class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IIdentityService _identityService;

        public SignUpHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public Task HandleAsync(SignUp command) => _identityService.SignUpAsync(command);
    }
}