using Epilepsy_Health_App.Services.Identity.Application.Services;
using Joint.CQRS.Commands;
using System;
using System.Threading.Tasks;

namespace Epilepsy_Health_App.Services.Identity.Application.Commands.Handlers
{
    public class SignOutHandler : ICommandHandler<SignOut>
    {
        readonly IIdentityService _identityService;

        public SignOutHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public Task HandleAsync(SignOut command) => _identityService.SignOutAsync(command);
    }
}
