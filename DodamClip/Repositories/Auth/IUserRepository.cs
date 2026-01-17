using DodamClip.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DodamClip.Repositories.Auth
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}