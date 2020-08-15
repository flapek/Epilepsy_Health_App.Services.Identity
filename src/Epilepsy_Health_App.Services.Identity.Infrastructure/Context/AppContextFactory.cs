﻿using Convey.MessageBrokers;
using Epilepsy_Health_App.Services.Identity.Application;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Epilepsy_Health_App.Services.Identity.Infrastructure.Context
{
    internal sealed class AppContextFactory : IAppContextFactory
    {
        private readonly ICorrelationContextAccessor _contextAccessor;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppContextFactory(ICorrelationContextAccessor contextAccessor, IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = contextAccessor;
            _httpContextAccessor = httpContextAccessor;
        }

        public IAppContext Create()
        {
            if (_contextAccessor.CorrelationContext is { })
            {
                var payload = JsonConvert.SerializeObject(_contextAccessor.CorrelationContext);

                return string.IsNullOrWhiteSpace(payload)
                    ? AppContext.Empty
                    : new AppContext(JsonConvert.DeserializeObject<CorrelationContext>(payload));
            }

            var context = _httpContextAccessor.GetCorrelationContext();

            return context is null ? AppContext.Empty : new AppContext(context);
        }
    }
}
