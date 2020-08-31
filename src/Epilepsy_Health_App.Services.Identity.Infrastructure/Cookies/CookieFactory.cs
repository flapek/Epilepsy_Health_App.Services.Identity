using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Epilepsy_Health_App.Services.Identity.Infrastructure.Cookies
{
    internal sealed class CookieFactory : ICookieFactory
    {
        public void SetResponseTokenCookie(ControllerBase controllerBase, string token, DateTime expire)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expire
            };
            controllerBase.Response.Cookies.Append("RefreshToken", token, cookieOptions);
        }
    }
}
