using Joint.Exception.Exceptions;
using System.Net;

namespace Epilepsy_Health_App.Services.Identity.Core.Exceptions
{
    public class InvalidCredentialsException : DomainException
    {
        public override string Code { get; } = "invalid_credentials";
        public override HttpStatusCode StatusCodes { get; } = HttpStatusCode.Unauthorized;
        public string Email { get; }

        public InvalidCredentialsException(string email) : base("Invalid credentials.")
        {
            Email = email;
        }
    }
}
