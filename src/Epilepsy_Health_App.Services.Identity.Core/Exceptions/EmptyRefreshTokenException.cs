using Joint.Exception.Exceptions;
using System.Net;

namespace Epilepsy_Health_App.Services.Identity.Core.Exceptions
{
    public class EmptyRefreshTokenException : DomainException
    {
        public override string Code { get; } = "empty_refresh_token";
        public override HttpStatusCode StatusCodes { get; } = HttpStatusCode.BadRequest;

        public EmptyRefreshTokenException() : base("Empty refresh token.")
        {
        }
    }
}
