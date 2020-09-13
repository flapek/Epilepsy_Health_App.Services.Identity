using Epilepsy_Health_App.Services.Identity.Core.Entities;
using System;

namespace Epilepsy_Health_App.Services.Identity.Application.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserDto()
        {
        }

        public UserDto(User user)
        {
            Id = user.Id;
            Email = user.Email;
            CreatedAt = user.CreatedAt;
        }
    }
}