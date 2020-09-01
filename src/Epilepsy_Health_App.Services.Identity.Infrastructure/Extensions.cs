using Epilepsy_Health_App.Services.Identity.Application.Services;
using Epilepsy_Health_App.Services.Identity.Infrastructure.Auth;
using Epilepsy_Health_App.Services.Identity.Infrastructure.Cookies;
using Epilepsy_Health_App.Services.Identity.Infrastructure.Exceptions;
using Epilepsy_Health_App.Services.Identity.Infrastructure.Mongo;
using Joint;
using Joint.Auth;
using Joint.CQRS.Queries;
using Joint.Docs.Swagger;
using Joint.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pacco.Services.Identity.Infrastructure.Auth;

namespace Epilepsy_Health_App.Services.Identity.Infrastructure
{
    public static class Extensions
    {
        public static IJointBuilder AddInfrastructure(this IJointBuilder builder)
        {
            builder
                .AddWebApi()
                .AddJwt()
                .AddErrorHandler<ExceptionToResponseMapper>()
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher()
                .AddSwaggerDocs();

            builder.Services.AddTransient<ICookieFactory, CookieFactory>();
            builder.Services.AddTransient<IJwtProvider, JwtProvider>();
            builder.Services.AddTransient<IPasswordService, PasswordService>();
            builder.Services.AddTransient<IRng, Rng>();


            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseJoint()
                .UseErrorHandler()
                .UseSwaggerDocs()
                .UseMongo()
                .UseAuthentication()
                .UseAuthorization();

            return app;
        }

    }
}
