using DodamClip.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DodamClip.Repositories.Admin
{
    public interface IUserAdminRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}