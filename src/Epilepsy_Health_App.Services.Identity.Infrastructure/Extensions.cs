using Epilepsy_Health_App.Services.Identity.Infrastructure.Exceptions;
using Joint;
using Joint.Auth;
using Joint.CQRS.Queries;
using Joint.Docs.Swagger;
using Joint.WebApi;
using Microsoft.AspNetCore.Builder;

namespace Epilepsy_Health_App.Services.Identity.Infrastructure
{
    public static class Extensions
    {
        public static IJointBuilder AddInfrastructure(this IJointBuilder builder)
        {
            builder
                .AddJwt()
                .AddErrorHandler<ExceptionToResponseMapper>()
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher();

            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandler()
                .UseSwaggerDocs()
                .UseJoint()
                .UseAuthentication()
                .UseAuthorization();

            return app;
        }

    }
}
