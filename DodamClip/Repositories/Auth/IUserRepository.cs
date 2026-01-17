using System;
using System.Threading.Tasks;
using DodamClip.Models.Entities;

namespace DodamClip.Repositories.Auth
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
