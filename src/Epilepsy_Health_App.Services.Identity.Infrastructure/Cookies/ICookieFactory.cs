﻿using Microsoft.AspNetCore.Mvc;

namespace Epilepsy_Health_App.Services.Identity.Infrastructure.Cookies
{
    public interface ICookieFactory
    {
        void SetResponseRefreshTokenCookie(ControllerBase controllerBase, string token);
        string GetRefreshTokenFromCookie(ControllerBase controllerBase);
    }
}
