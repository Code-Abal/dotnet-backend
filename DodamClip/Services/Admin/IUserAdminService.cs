using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DodamClip.Models.DTOs;

namespace DodamClip.Services.Admin
{
    public interface IUserAdminService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(Guid id);
        Task UpdateAsync(UserDto dto);
        Task DeleteAsync(Guid id);
    }
}
