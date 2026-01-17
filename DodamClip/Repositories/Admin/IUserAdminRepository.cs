using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DodamClip.Models.Entities;

namespace DodamClip.Repositories.Admin
{
    public interface IUserAdminRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
