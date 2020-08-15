using Convey.CQRS.Queries;
using Epilepsy_Health_App.Services.Identity.Application.DTO;
using System;

namespace Epilepsy_Health_App.Services.Identity.Application.Queries
{
    public class GetUser : IQuery<UserDto>
    {
        public Guid UserId { get; set; }
    }
}
