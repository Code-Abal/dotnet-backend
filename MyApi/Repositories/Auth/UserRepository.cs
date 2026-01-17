using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Models.Entities;

namespace MyApi.Repositories.Auth
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
