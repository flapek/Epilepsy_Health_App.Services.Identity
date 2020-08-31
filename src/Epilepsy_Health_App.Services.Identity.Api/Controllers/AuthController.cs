using Epilepsy_Health_App.Services.Identity.Infrastructure.Cookies;
using Joint.CQRS.Commands;
using Joint.CQRS.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Epilepsy_Health_App.Services.Identity.Api.Controllers
{

    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        readonly ICommandDispatcher _commandDispatcher;
        readonly IQueryDispatcher _queryDispatcher;
        readonly ICookieFactory _cookieFactory;

        public AuthController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, ICookieFactory cookieFactory)
        {
            this._commandDispatcher = commandDispatcher;
            this._queryDispatcher = queryDispatcher;
            this._cookieFactory = cookieFactory;
        }

        [HttpPost("registry")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Registry()
        {

            return Ok(new object());
        }
        
        [HttpPost("SignIn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SignIn()
        {

            return Ok(new object());
        }
        
        [Authorize]
        [HttpPost("SingOut")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SingOut()
        {

            return Ok(new object());
        }


    }
}
