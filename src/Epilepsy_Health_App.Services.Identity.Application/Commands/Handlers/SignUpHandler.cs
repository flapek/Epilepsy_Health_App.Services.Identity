using Epilepsy_Health_App.Services.Identity.Application.Services;
using Joint.CQRS.Commands;
using System.Threading.Tasks;

namespace Epilepsy_Health_App.Services.Identity.Application.Commands.Handlers
{
    public class SignUpHandler : ICommandHandler<SignUp>
    {
        readonly IIdentityService _identityService;

        public SignUpHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public Task HandleAsync(SignUp command) => _identityService.SignUpAsync(command);
    }
}
