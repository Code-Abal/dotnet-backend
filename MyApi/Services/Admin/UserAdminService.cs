using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApi.Models.DTOs;
using MyApi.Repositories.Admin;

namespace MyApi.Services.Admin
{
    public class UserAdminService : IUserAdminService
    {
        private readonly IUserAdminRepository _repo;

        public UserAdminService(IUserAdminRepository repo)
        {
            _repo = repo;
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return;
            await _repo.DeleteAsync(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _repo.GetAllAsync();
            return users.Select(u => new UserDto { Id = u.Id, Email = u.Email, FullName = u.FullName, Role = u.Role });
        }

        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            var u = await _repo.GetByIdAsync(id);
            if (u == null) return null;
            return new UserDto { Id = u.Id, Email = u.Email, FullName = u.FullName, Role = u.Role };
        }

        public async Task UpdateAsync(UserDto dto)
        {
            var user = await _repo.GetByIdAsync(dto.Id);
            if (user == null) return;
            user.FullName = dto.FullName;
            user.Role = dto.Role;
            await _repo.UpdateAsync(user);
        }
    }
}
