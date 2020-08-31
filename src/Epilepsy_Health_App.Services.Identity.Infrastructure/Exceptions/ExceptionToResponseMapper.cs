using System;
using System.Net;
using Epilepsy_Health_App.Services.Identity.Application.Exceptions;
using Epilepsy_Health_App.Services.Identity.Core.Exceptions;
using Joint.WebApi.Exceptions;

namespace Epilepsy_Health_App.Services.Identity.Infrastructure.Exceptions
{
    internal sealed class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        public ExceptionResponse Map(Exception exception)
            => exception switch
            {
                DomainException ex => new ExceptionResponse(new { code = ex.Code, reason = ex.Message }, HttpStatusCode.BadRequest),
                AppException ex => new ExceptionResponse(new { code = ex.Code, reason = ex.Message }, HttpStatusCode.BadRequest),
                _ => new ExceptionResponse(new { code = "error", reason = "There was an error." }, HttpStatusCode.BadRequest)
            };
    }
}
