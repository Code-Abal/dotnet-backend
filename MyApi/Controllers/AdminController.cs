using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MyApi.Services.Admin;
using MyApi.Models.DTOs;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IUserAdminService _service;

        public AdminController(IUserAdminService service)
        {
            _service = service;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPut("users/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserDto dto)
        {
            if (id != dto.Id) return BadRequest();
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("users/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
