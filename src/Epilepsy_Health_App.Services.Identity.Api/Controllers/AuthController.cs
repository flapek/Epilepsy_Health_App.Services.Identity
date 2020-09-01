using Epilepsy_Health_App.Services.Identity.Application.Commands;
using Epilepsy_Health_App.Services.Identity.Application.DTO;
using Epilepsy_Health_App.Services.Identity.Infrastructure.Cookies;
using Joint.CQRS.Commands;
using Joint.CQRS.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        
        [Authorize]
        [HttpPost("SingOut")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SingUp(SignUp command)
        {
            await _commandDispatcher.SendAsync(command);
            return Ok(new object());
        }

        [HttpPost("SignIn")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> SignIn(SignIn command)
        {
            var token = await _commandDispatcher.SendAsync<AuthDto>(command);
            _cookieFactory.SetResponseTokenCookie(this, token.RefreshToken, token.Expires);
            return Accepted(token);
        }

        [HttpPost("registry")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> SignOut()
        {
            return Accepted(new object());
        }
    }
}
