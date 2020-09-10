using Joint.Exception.Exceptions;
using System;
using System.Net;

namespace Epilepsy_Health_App.Services.Identity.Application.Exceptions
{
    public class UserNotFoundException : AppException
    {
        public override string Code { get; } = "user_not_found";
        public override HttpStatusCode StatusCodes { get; } = HttpStatusCode.NotFound;
        public Guid UserId { get; }

        public UserNotFoundException(Guid userId) : base($"User with ID: '{userId}' was not found.")
        {
            UserId = userId;
        }
    }
}
