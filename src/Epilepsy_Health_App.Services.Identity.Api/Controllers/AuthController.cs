using Epilepsy_Health_App.Services.Identity.Application.Commands;
using Epilepsy_Health_App.Services.Identity.Application.DTO;
using Epilepsy_Health_App.Services.Identity.Application.Exceptions;
using Epilepsy_Health_App.Services.Identity.Core.Exceptions;
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
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _cookieFactory = cookieFactory;
        }


        [HttpPost("SignUp")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(EmailInUseException), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignUp([FromBody] SignUp command)
        {
            await _commandDispatcher.SendAsync(command);
            return Accepted();
        }

        [HttpPost("SignIn")]
        [ProducesResponseType(typeof(AuthDto), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InvalidEmailOrPasswordException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InvalidCredentialsException), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SignIn([FromBody] SignIn command)
        {
            var token = await _commandDispatcher.SendAsync<AuthDto>(command);
            _cookieFactory.SetResponseRefreshTokenCookie(this, token.RefreshToken);
            return Accepted(token);
        }

        [HttpPost("SignOut")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(EmptyRefreshTokenException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InvalidRefreshTokenException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SignOut()
        {
            SignOut command = new SignOut { RefreshToken = _cookieFactory.GetRefreshTokenFromCookie(this) };
            await _commandDispatcher.SendAsync(command);
            return Accepted();
        }

        [HttpPost("Refresh-Token")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(InvalidRefreshTokenException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RevokedRefreshTokenException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UserNotFoundException), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Refresh_Token()
        {
            var command = new Refresh_Token { RefreshToken = _cookieFactory.GetRefreshTokenFromCookie(this) };

            var token = await _commandDispatcher.SendAsync<AuthDto>(command);
            _cookieFactory.SetResponseRefreshTokenCookie(this, token.RefreshToken);
            return Accepted(token);
        }

        [Authorize]
        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok("Good job!!");
        }
    }
}
