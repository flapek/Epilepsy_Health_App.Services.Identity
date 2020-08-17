using System;
using Convey.CQRS.Events;

namespace Epilepsy_Health_App.Services.Identity.Application.Events
{
    [Contract]
    public class SignedIn : IEvent
    {
        public Guid UserId { get; }
        public string Role { get; }

        public SignedIn(Guid userId, string role)
        {
            UserId = userId;
            Role = role;
        }
    }
}