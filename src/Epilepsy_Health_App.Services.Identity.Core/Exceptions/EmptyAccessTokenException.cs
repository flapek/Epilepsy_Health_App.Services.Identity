﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Epilepsy_Health_App.Services.Identity.Core.Exceptions
{
    public class EmptyAccessTokenException : DomainException
    {
        public override string Code { get; } = "empty_access_token";
        public override HttpStatusCode StatusCodes { get; } = HttpStatusCode.BadRequest;

        public EmptyAccessTokenException() : base("Empty access token.")
        {

        }

    }
}