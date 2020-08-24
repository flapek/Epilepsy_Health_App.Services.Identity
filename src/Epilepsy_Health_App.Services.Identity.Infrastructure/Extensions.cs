using Convey;
using Convey.CQRS.Queries;
using Convey.Docs.Swagger;
using Convey.WebApi;
using Convey.WebApi.Swagger;
using Epilepsy_Health_App.Services.Identity.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Builder;
using SCL.Auth;

namespace Epilepsy_Health_App.Services.Identity.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            return builder
                .AddErrorHandler<ExceptionToResponseMapper>()
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher()
                .AddJwt()
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
