using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyApi.Models.Entities;

namespace MyApi.Repositories.Admin
{
    public interface IUserAdminRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
