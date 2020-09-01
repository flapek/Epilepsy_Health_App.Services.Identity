using Epilepsy_Health_App.Services.Identity.Application.DTO;
using Joint.CQRS.Commands;

namespace Epilepsy_Health_App.Services.Identity.Application.Commands
{
    public class SignIn : ICommand<AuthDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
