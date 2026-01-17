using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyApi.Services.Auth;
using MyApi.Models.DTOs;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] LoginDto dto)
        {
            var user = await _auth.RegisterAsync(dto);
            if (user == null) return BadRequest("User already exists");
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _auth.LoginAsync(dto);
            if (user == null) return Unauthorized();
            return Ok(user);
        }
    }
}
