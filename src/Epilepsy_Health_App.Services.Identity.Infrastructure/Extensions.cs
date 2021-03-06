﻿using Epilepsy_Health_App.Services.Identity.Application.Services;
using Epilepsy_Health_App.Services.Identity.Application.Services.Identity;
using Epilepsy_Health_App.Services.Identity.Core.Repositories;
using Epilepsy_Health_App.Services.Identity.Infrastructure.Auth;
using Epilepsy_Health_App.Services.Identity.Infrastructure.Cookies;
using Epilepsy_Health_App.Services.Identity.Infrastructure.Exceptions;
using Epilepsy_Health_App.Services.Identity.Infrastructure.Mongo;
using Epilepsy_Health_App.Services.Identity.Infrastructure.Mongo.Documents;
using Epilepsy_Health_App.Services.Identity.Infrastructure.Mongo.Repositories;
using Joint;
using Joint.Auth;
using Joint.Builders;
using Joint.CQRS.Queries;
using Joint.DB.Mongo;
using Joint.DBRedis;
using Joint.Discovery.Consul;
using Joint.Exception;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Epilepsy_Health_App.Services.Identity.Infrastructure
{
    public static class Extensions
    {
        public static IJointBuilder AddInfrastructure(this IJointBuilder builder)
        {
            builder.Services.AddTransient<ICookieFactory, CookieFactory>();
            builder.Services.AddTransient<IJwtProvider, JwtProvider>();
            builder.Services.AddTransient<IPasswordService, PasswordService>();
            builder.Services.AddSingleton<IPasswordHasher<IPasswordService>, PasswordHasher<IPasswordService>>();
            builder.Services.AddTransient<IRng, Rng>();
            builder.Services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IIdentityService, IdentityService>();
            builder.Services.AddTransient<IRefreshTokenService, RefreshTokenService>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return builder
                .AddJwt()
                .AddMongo()
                .AddMongoRepository<UserDocument, Guid>("users")
                .AddMongoRepository<RefreshTokenDocument, Guid>("refreshTokens")
                .AddRedis()
                .AddConsul()
                .AddErrorHandler<ExceptionToResponseMapper>()
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher();
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandler()
                .UseJoint()
                .UseAccessTokenValidator()
                .UseMongo()
                .UseAuthentication()
                .UseAuthorization();

            return app;
        }
    }
}
