using Joint.CQRS.Commands;
using System;

namespace Epilepsy_Health_App.Services.Identity.Application.Commands
{
    public class SignUp : ICommand
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public SignUp(Guid userId, string email, string password)
        {
            UserId = userId == Guid.Empty ? Guid.NewGuid() : userId;
            Email = email;
            Password = password;
        }
    }
}
