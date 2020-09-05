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


        [HttpPost("SignUp")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignUp([FromBody] SignUp command)
        {
            await _commandDispatcher.SendAsync(command);
            return Accepted();
        }

        [HttpPost("SignIn")]
        [ProducesResponseType(typeof(AuthDto), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignIn([FromBody] SignIn command)
        {
            var token = await _commandDispatcher.SendAsync<AuthDto>(command);
            _cookieFactory.SetResponseTokenCookie(this, token.RefreshToken, token.Expires);
            return Accepted(token);
        }

        [Authorize]
        [HttpPost("SignOut")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignOut()
        {
            return Accepted(new object());
        }
    }
}
