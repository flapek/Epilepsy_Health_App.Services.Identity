using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;

namespace Epilepsy_Health_App.Services.Identity.Application
{
    public static class Extensions
    {
        public static IConveyBuilder AddApplication(this IConveyBuilder builder)
            => builder
                .AddCommandHandlers()
                .AddEventHandlers()
                .AddInMemoryCommandDispatcher()
                .AddInMemoryEventDispatcher();
    }
}
