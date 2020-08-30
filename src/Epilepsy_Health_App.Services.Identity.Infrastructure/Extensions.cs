using Epilepsy_Health_App.Services.Identity.Infrastructure.Exceptions;
using Joint;
using Joint.Auth;
using Microsoft.AspNetCore.Builder;

namespace Epilepsy_Health_App.Services.Identity.Infrastructure
{
    public static class Extensions
    {
        public static IJointBuilder AddInfrastructure(this IJointBuilder builder)
        {
            return builder
                .AddJwt()
                .AddErrorHandler<ExceptionToResponseMapper>()
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher()
                .AddExceptionToMessageMapper<ExceptionToMessageMapper>()
                .AddWebApiSwaggerDocs();
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandler()
                .UseSwaggerDocs()
                .UseConvey()
                .UseAuthentication()
                .UseAuthorization();

            return app;
        }

    }
}
