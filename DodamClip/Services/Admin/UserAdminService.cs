using DodamClip.Repositories.Admin;
using DodamClip.Models.DTOs;
using DodamClip.Models.Entities;

namespace DodamClip.Services.Admin
{
    public class UserAdminService
    {
        private readonly IUserAdminRepository _repo;
        public UserAdminService(IUserAdminRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _repo.GetAllAsync();
            return users.Select(u => new UserDto { Id = u.Id, Username = u.Username, Email = u.Email, Role = u.Role });
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var u = await _repo.GetByIdAsync(id);
            if (u == null) return null;
            return new UserDto { Id = u.Id, Username = u.Username, Email = u.Email, Role = u.Role };
        }

        public async Task UpdateAsync(int id, UserDto dto)
        {
            var u = await _repo.GetByIdAsync(id);
            if (u == null) throw new KeyNotFoundException();
            u.Username = dto.Username;
            u.Email = dto.Email;
            u.Role = dto.Role;
            await _repo.UpdateAsync(u);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}