using Microsoft.AspNetCore.Mvc;
using DodamClip.Services.Auth;
using DodamClip.Models.DTOs;

namespace DodamClip.Controllers
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _auth.LoginAsync(dto);
            if (user == null) return Unauthorized();
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto dto, [FromQuery] string password)
        {
            try
            {
                var created = await _auth.RegisterAsync(dto, password);
                return CreatedAtAction(nameof(Register), new { id = created.Id }, created);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }
    }
}