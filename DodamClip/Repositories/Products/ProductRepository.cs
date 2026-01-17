using Microsoft.EntityFrameworkCore;
using DodamClip.Data;
using DodamClip.Models.Entities;

namespace DodamClip.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var p = await _db.Products.FindAsync(id);
            if (p != null)
            {
                _db.Products.Remove(p);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _db.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
        }
    }
}