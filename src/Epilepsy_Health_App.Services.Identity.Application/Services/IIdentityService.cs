using Epilepsy_Health_App.Services.Identity.Application.Commands;
using Epilepsy_Health_App.Services.Identity.Application.DTO;
using System;
using System.Threading.Tasks;

namespace Epilepsy_Health_App.Services.Identity.Application.Services
{
    public interface IIdentityService
    {
        Task<UserDto> GetAsync(Guid id);
        Task<AuthDto> SignInAsync(SignIn command);
        Task SignUpAsync(SignUp command);
        Task SignOutAsync(SignOut command);
    }
}
