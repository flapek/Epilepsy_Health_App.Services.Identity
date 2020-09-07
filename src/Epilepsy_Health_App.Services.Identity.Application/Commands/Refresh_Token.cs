using Epilepsy_Health_App.Services.Identity.Application.DTO;
using Joint.CQRS.Commands;

namespace Epilepsy_Health_App.Services.Identity.Application.Commands
{
    public class Refresh_Token : ICommand<AuthDto>
    {
        public string RefreshToken { get; set; }
    }
}
