using Joint.Exception.Exceptions;
using System.Net;

namespace Epilepsy_Health_App.Services.Identity.Core.Exceptions
{
    public class InvalidEmailOrPasswordException : DomainException
    {
        public override string Code { get; } = "invalid_email_or_password";
        public override HttpStatusCode StatusCodes { get; } = HttpStatusCode.BadRequest;

        public InvalidEmailOrPasswordException(string email) : base($"Invalid email: {email} or password.")
        {
        }
    }
}