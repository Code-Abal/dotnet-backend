using System;
using System.Threading.Tasks;
using MyApi.Models.Entities;

namespace MyApi.Repositories.Auth
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
