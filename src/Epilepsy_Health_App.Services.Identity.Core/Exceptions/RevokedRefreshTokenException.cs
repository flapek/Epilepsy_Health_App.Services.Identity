using System.Net;

namespace Epilepsy_Health_App.Services.Identity.Core.Exceptions
{
    public class RevokedRefreshTokenException : DomainException
    {
        public override string Code { get; } = "revoked_refresh_token";
        public override HttpStatusCode StatusCodes { get; } = HttpStatusCode.BadRequest;

        public RevokedRefreshTokenException() : base("Revoked refresh token.")
        {
        }
    }
}
