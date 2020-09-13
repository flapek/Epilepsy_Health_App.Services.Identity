using Joint.Builders;
using Joint.CQRS.Commands;
using Joint.CQRS.Events;

namespace Epilepsy_Health_App.Services.Identity.Application
{
    public static class Extensions
    {
        public static IJointBuilder AddApplication(this IJointBuilder builder)
        {
            return builder
                .AddCommandHandlers()
                .AddEventHandlers()
                .AddInMemoryCommandDispatcher()
                .AddInMemoryEventDispatcher();
        }
    }
}
