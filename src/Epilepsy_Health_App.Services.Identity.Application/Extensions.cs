using Epilepsy_Health_App.Services.Identity.Application.Services;
using Epilepsy_Health_App.Services.Identity.Application.Services.Identity;
using Joint;
using Joint.CQRS.Commands;
using Joint.CQRS.Events;
using Microsoft.Extensions.DependencyInjection;

namespace Epilepsy_Health_App.Services.Identity.Application
{
    public static class Extensions
    {
        public static IJointBuilder AddApplication(this IJointBuilder builder)
        {
            builder.Services.AddTransient<IIdentityService, IdentityService>();
            builder.Services.AddTransient<IRefreshTokenService, RefreshTokenService>();

            return builder
                .AddCommandHandlers()
                .AddEventHandlers()
                .AddInMemoryCommandDispatcher()
                .AddInMemoryEventDispatcher();
        }
    }
}
