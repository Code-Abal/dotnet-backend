using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Models.Entities;

namespace MyApi.Repositories.Admin
{
    public class UserAdminRepository : IUserAdminRepository
    {
        private readonly ApplicationDbContext _db;

        public UserAdminRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task DeleteAsync(User user)
        {
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
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
