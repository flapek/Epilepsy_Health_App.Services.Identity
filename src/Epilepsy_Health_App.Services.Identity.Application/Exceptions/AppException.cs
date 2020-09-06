using System;
using System.Net;

namespace Epilepsy_Health_App.Services.Identity.Application.Exceptions
{
    public abstract class AppException : Exception
    {
        public virtual string Code { get; }
        public virtual HttpStatusCode StatusCodes { get; }

        protected AppException(string message) : base(message)
        {
        }
    }
}