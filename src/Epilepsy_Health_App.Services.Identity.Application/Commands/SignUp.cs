using Joint.CQRS.Commands;
using System;
using System.Text.Json.Serialization;

namespace Epilepsy_Health_App.Services.Identity.Application.Commands
{
    public class SignUp : ICommand
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public SignUp(string email, string password)
        {
            UserId = Guid.NewGuid();
            Email = email;
            Password = password;
        }
    }
}
