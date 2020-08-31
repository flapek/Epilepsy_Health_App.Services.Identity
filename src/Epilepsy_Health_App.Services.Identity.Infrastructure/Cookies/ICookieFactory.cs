using Microsoft.AspNetCore.Mvc;
using System;

namespace Epilepsy_Health_App.Services.Identity.Infrastructure.Cookies
{
    public interface ICookieFactory
    {
        void SetResponseTokenCookie(ControllerBase controllerBase, string token, DateTime expire);
    }
}
