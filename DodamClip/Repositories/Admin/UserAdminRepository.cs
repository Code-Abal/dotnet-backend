using Microsoft.EntityFrameworkCore;
using DodamClip.Data;
using DodamClip.Models.Entities;

namespace DodamClip.Repositories.Admin
{
    public class UserAdminRepository : IUserAdminRepository
    {
        private readonly ApplicationDbContext _db;
        public UserAdminRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task DeleteAsync(int id)
        {
            var u = await _db.Users.FindAsync(id);
            if (u != null)
            {
                _db.Users.Remove(u);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _db.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task UpdateAsync(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }
    }
}