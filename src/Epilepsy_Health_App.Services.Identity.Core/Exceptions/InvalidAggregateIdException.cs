using Joint.Exception.Exceptions;
using System.Net;

namespace Epilepsy_Health_App.Services.Identity.Core.Exceptions
{
    public class InvalidAggregateIdException : DomainException
    {
        public override string Code { get; } = "invalid_aggregate_id";
        public override HttpStatusCode StatusCodes { get; } = HttpStatusCode.BadRequest;

        public InvalidAggregateIdException() : base($"Invalid aggregate id.")
        {
        }
    }
}
