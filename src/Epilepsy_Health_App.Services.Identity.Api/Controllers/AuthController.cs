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

    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ICookieFactory _cookieFactory;

        public AuthController(ICommandDispatcher commandDispatcher, ICookieFactory cookieFactory)
        {
            _commandDispatcher = commandDispatcher;
            _cookieFactory = cookieFactory;
        }

        /// <summary>
        /// Sign up user
        /// </summary>
        /// <param name="command">Request body which user would be sign up</param>
        /// <returns>status code 201 created</returns>
        [HttpPost("sign-up")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]                 // typeof(EmailInUseException)
        public async Task<IActionResult> SignUp([FromBody] SignUp command)
        {
            await _commandDispatcher.SendAsync(command);
            return Accepted();
        }

        /// <summary>
        /// Sign in user 
        /// </summary>
        /// <param name="command">Request body which user would be sign in</param>
        /// <returns>AuthDto</returns>
        [HttpPost("sign-in")]
        [ProducesResponseType(typeof(AuthDto), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]                 // typeof(InvalidEmailOrPasswordException)
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]               // typeof(InvalidCredentialsException)
        public async Task<IActionResult> SignIn([FromBody] SignIn command)
        {
            var token = await _commandDispatcher.SendAsync<AuthDto>(command);
            _cookieFactory.SetResponseRefreshTokenCookie(this, token.RefreshToken);
            return Accepted(token);
        }

        /// <summary>
        /// Sign out user and revoke access and refresh token
        /// </summary>
        /// <param name="command">Request body which user would be sign out</param>
        /// <returns>status code 202</returns>
        [HttpPost("sign-out")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]                 // typeof(InvalidRefreshTokenException)/typeof(EmptyRefreshTokenException)
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SignOut([FromBody] SignOut command)
        {
            command.RefreshToken = _cookieFactory.GetRefreshTokenFromCookie(this);
            await _commandDispatcher.SendAsync(command);
            return Accepted();
        }


        /// <summary>
        /// Refresh token after expire access token
        /// </summary>
        /// <returns>AuthDto</returns>
        [HttpPost("refresh-token")]
        [ProducesResponseType(typeof(AuthDto), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]                 // typeof(RevokedRefreshTokenException)/typeof(InvalidRefreshTokenException)
        [ProducesResponseType(StatusCodes.Status404NotFound)]                   // typeof(UserNotFoundException)
        public async Task<IActionResult> Refresh_Token()
        {
            var command = new Refresh_Token { RefreshToken = _cookieFactory.GetRefreshTokenFromCookie(this) };

            var token = await _commandDispatcher.SendAsync<AuthDto>(command);
            _cookieFactory.SetResponseRefreshTokenCookie(this, token.RefreshToken);
            return Accepted(token);
        }

        /// <summary>
        /// This route is for test. 
        /// If you have access token from LogIn request try to send it there. 
        /// </summary>
        /// <returns>If pass return success string</returns>
        [Authorize]
        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok("Good job!!");
        }
    }
}
