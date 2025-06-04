using dotnet_security_api.Models;
using dotnet_security_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_security_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            if (login.Username == "admin" && login.Password == "123")
            {
                var token = _jwtService.GenerateToken(login.Username);
                return Ok(new { token });
            }

            return Unauthorized("Credenciais inválidas.");
        }
    }
}
