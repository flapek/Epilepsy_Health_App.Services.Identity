﻿using Joint.Exception.Exceptions;
using System.Net;

namespace Epilepsy_Health_App.Services.Identity.Core.Exceptions
{
    public class EmailInUseException : DomainException
    {
        public override string Code { get; } = "email_in_use";
        public override HttpStatusCode StatusCodes { get; } = HttpStatusCode.BadRequest;
        public string Email { get; }

        public EmailInUseException(string email) : base($"Email {email} is already in use.")
        {
            Email = email;
        }
    }
}
