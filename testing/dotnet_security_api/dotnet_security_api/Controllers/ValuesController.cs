using dotnet_security_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_security_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("jwt")]
        public IActionResult GetJwtProtected()
        {
            return Ok("Você acessou com JWT!");
        }

        [Authorize(AuthenticationSchemes = "Basic")]
        [HttpGet("basic")]
        public IActionResult GetBasicProtected()
        {
            return Ok("Você acessou com Basic Auth!");
        }
    }
}
