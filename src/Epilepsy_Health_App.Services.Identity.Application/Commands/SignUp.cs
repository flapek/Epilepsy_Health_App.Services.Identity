using Joint.CQRS.Commands;
using System;

namespace Epilepsy_Health_App.Services.Identity.Application.Commands
{
    public class SignUp : ICommand
    {
        public Guid UserId { get; }
        public string Email { get; }
        public string Password { get; }

        public SignUp(Guid userId, string email, string password)
        {
            UserId = userId == Guid.Empty ? Guid.NewGuid() : userId;
            Email = email;
            Password = password;
        }
    }
}
