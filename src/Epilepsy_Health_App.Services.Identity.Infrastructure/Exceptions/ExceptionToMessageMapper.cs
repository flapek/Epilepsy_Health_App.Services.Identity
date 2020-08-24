using System;
using Convey.MessageBrokers.RabbitMQ;
using Epilepsy_Health_App.Services.Identity.Application.Commands;
using Epilepsy_Health_App.Services.Identity.Application.Events.Rejected;
using Epilepsy_Health_App.Services.Identity.Core.Exceptions;

namespace Epilepsy_Health_App.Services.Identity.Infrastructure.Exceptions
{
    internal sealed class ExceptionToMessageMapper : IExceptionToMessageMapper
    {
        public object Map(Exception exception, object message)
            => exception switch

            {
                _ => null
            };
    }
}
