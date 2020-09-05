using System;
using System.Net;

namespace Epilepsy_Health_App.Services.Identity.Core.Exceptions
{
    public abstract class DomainException : Exception
    {
        public virtual string Code { get; }
        public virtual HttpStatusCode StatusCodes { get; }

        protected DomainException(string message) : base(message)
        {
        }
    }
}