using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Epilepsy_Health_App.Services.Identity.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        [HttpGet("Identity")]
        public async Task<IActionResult> Identity()
        {
            return Ok("I would identity you");
        }

    }
}
