﻿using Joint.Exception.Exceptions;
using System.Net;

namespace Epilepsy_Health_App.Services.Identity.Core.Exceptions
{
    public class InvalidRefreshTokenException : DomainException
    {
        public override string Code { get; } = "invalid_refresh_token";
        public override HttpStatusCode StatusCodes { get; } = HttpStatusCode.BadRequest;

        public InvalidRefreshTokenException() : base("Invalid refresh token.")
        {
        }
    }
}
