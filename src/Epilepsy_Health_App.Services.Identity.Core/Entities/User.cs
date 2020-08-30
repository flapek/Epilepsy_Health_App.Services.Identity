using Epilepsy_Health_App.Services.Identity.Core.Exceptions;
using System;

namespace Epilepsy_Health_App.Services.Identity.Core.Entities
{
    public class User : AggregateRoot
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public User(Guid id, string email, string password, DateTime createdAt)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new InvalidEmailException(email);
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidPasswordException();
            }

            Id = id;
            Email = email.ToLowerInvariant();
            Password = password;
            CreatedAt = createdAt;
        }
    }
}
