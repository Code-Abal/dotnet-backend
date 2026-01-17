using Microsoft.AspNetCore.Mvc;
using DodamClip.Services.Admin;
using DodamClip.Models.DTOs;

namespace DodamClip.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly UserAdminService _admin;
        public AdminController(UserAdminService admin)
        {
            _admin = admin;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _admin.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var u = await _admin.GetByIdAsync(id);
            if (u == null) return NotFound();
            return Ok(u);
        }

        [HttpPut("users/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto dto)
        {
            try
            {
                await _admin.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _admin.DeleteAsync(id);
            return NoContent();
        }
    }
}